using Business.Services.User.Interface;
using Domain.Entities.TMS;
using MediatR;

namespace Business.Features.Users.Query;

public class UserQuery : IRequest<List<UserEntity>>
{
    
}

public class UserQueryHandler : IRequestHandler<UserQuery, List<UserEntity>>
{
    private readonly IUserService _userService;

    public UserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<List<UserEntity>> Handle(UserQuery request, CancellationToken cancellationToken)
    {
        var result = _userService.get().ToList();
        return result;
    }
}