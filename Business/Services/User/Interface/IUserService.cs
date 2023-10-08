using Domain.Entities.TMS;

namespace Business.Services.User.Interface;

public interface IUserService
{
    List<UserEntity> get();
}