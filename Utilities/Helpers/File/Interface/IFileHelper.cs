using Microsoft.AspNetCore.Http;

namespace Utilities.Helpers.Interface;

public interface IFileHelper
{
    Task Write(string path, IFormFile file);
    Task Write(string path, string text, string fileName);
    IFormFile Read(string path);

    string ReadText(string path);
    void Delete(string path);
    void Update(string current, IFormFile newFile);
}