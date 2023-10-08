
using Business.Services.User.Interface;
using Domain.Entities.TMS;

namespace Business.Services.User;

public class UserService : IUserService
{
    public List<UserEntity> get()
    {
        var result = new List<UserEntity>();
        result.Add(new UserEntity()
        {
            ID = 1,
            FIRST_NAME = "Amanda",
            LAST_NAME = "Cone",
            POSITION = "Junior Software Engineer",
            IMG_PATH = "amanda.jpg"
        });
        result.Add(new UserEntity()
        {
            ID = 2,
            FIRST_NAME = "Samantha",
            LAST_NAME = "Fox",
            POSITION = "Software Development Manager",
            IMG_PATH = "samatha.jpg"
        });
        result.Add(new UserEntity()
        {
            ID = 3,
            FIRST_NAME = "Jm",
            LAST_NAME = "Obias",
            POSITION = "Senior Software Engineer",
            IMG_PATH = "jm.jpg"
        });
        return result;
    }
}