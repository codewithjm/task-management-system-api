
using Business.Services.User.Interface;
using Domain.Entities.TMS;
using Utilities.Helpers.Interface;

namespace Business.Services.User;

public class UserService : IUserService
{
    private readonly IFileHelper _fileHelper;

    public UserService(IFileHelper fileHelper)
    {
        _fileHelper = fileHelper;
    }

    public List<UserEntity> get()
    {
        var result = new List<UserEntity>();
        result.Add(new UserEntity()
        {
            ID = 1,
            FIRST_NAME = "Amanda",
            LAST_NAME = "Cone",
            POSITION = "Junior Software Engineer",
            IMG_PATH = "Assets\\amanda.png"
        });
        result.Add(new UserEntity()
        {
            ID = 2,
            FIRST_NAME = "Samantha",
            LAST_NAME = "Fox",
            POSITION = "Software Development Manager",
            IMG_PATH = "Assets\\samatha.png"
        });
        result.Add(new UserEntity()
        {
            ID = 3,
            FIRST_NAME = "Jm",
            LAST_NAME = "Obias",
            POSITION = "Senior Software Engineer",
            IMG_PATH = "Assets\\jm.png"
        });
        foreach (var rs in result)
        {
            try
            {
                rs.IMG_PATH = "data:image/jpg;base64,"+_fileHelper.GetImageUrl(rs.IMG_PATH);
            }
            catch
            {
                rs.IMG_PATH = "";
            }
        }
        
        return result;
    }
}