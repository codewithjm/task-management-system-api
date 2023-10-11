using Microsoft.AspNetCore.Http; 
using Utilities.Wrappers.Interfaces;
using Microsoft.AspNetCore.Hosting;


namespace Utilities.Helpers.Interface;

public sealed class FileHelper : IFileHelper
{
    public FileHelper(IWebHostEnvironment webHostEnvironment, IPathWrapper pathWrapper)
    {
        _webHostEnvironment = webHostEnvironment;
        _pathWrapper = pathWrapper;
    }

    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IPathWrapper _pathWrapper;
 

    public async Task Write(string path, IFormFile file)
    {
        try
        { 

            // Combine the target directory with the unique file name
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, path);

            // Save the file to the specified path
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
        catch
        {
            
        } 
    }

    public async Task Write(string path, string text, string fileName)
    {
        try
        {
            string FilePath = Path.Combine(_webHostEnvironment.ContentRootPath, path);
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
  
            var filePath = Path.Combine(FilePath, fileName);
            // Create the file and open it for writing
            using (StreamWriter writer = File.CreateText(filePath))
            {
                // Write the content to the file
                writer.Write(text);
            }
             
        }
        catch(Exception ex)
        {
             
        }
        
        
    }

    
    public IFormFile Read(string path)
    {
        throw new NotImplementedException();
    }

    public string ReadText(string path)
    {
        string FilePath = Path.Combine(_webHostEnvironment.ContentRootPath, path);
        // Read the content of the file
        string content = File.ReadAllText(FilePath);

        return content;
    }

    public void Delete(string path)
    {
        string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, path);
        File.Delete(filePath);
    }

    public void Update(string current, IFormFile newFile)
    {
        throw new NotImplementedException();
    }
    
    public string GetImageUrl(string imageFile)
    {
        var imagePath = _pathWrapper.Combine(_webHostEnvironment.ContentRootPath, imageFile);
        return GetImageUrlBase64(imagePath);
    }

    private static string GetImageUrlBase64(string imagePath)
    {
        var bytes = File.ReadAllBytes(imagePath);
        return Convert.ToBase64String(bytes);
    }
}