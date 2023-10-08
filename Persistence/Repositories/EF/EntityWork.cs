using Domain.Entities.TMS; 
using Persistence.Contexts;
using Persistence.Repositories.EF.Interfaces;
using Persistence.Repositories.EF.Tables;
using Persistence.Repositories.EF.Tables.Interface;

namespace Persistence.Repositories.EF;

public class EntityWork : IEntityWork
{
    private bool _isDisposed;
    private readonly TmsDbContext _dbContext;
    

    public EntityWork(TmsDbContext dbContext) => _dbContext = dbContext;
    
    public ITaskRepository TaskRepository => new TaskRepository(_dbContext);
    public ITaskFileRepository TaskFileRepository => new TaskFileRepository(_dbContext);



    public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

    public async Task RollBackAsync() => await _dbContext.DisposeAsync();

    public void Dispose()
    { 
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;
        if (disposing) _dbContext.Dispose();

        _isDisposed = true;
    }
    
    ~EntityWork() => Dispose(false);
}