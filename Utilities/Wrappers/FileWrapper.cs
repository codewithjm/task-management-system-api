

using Utilities.Wrappers.Interfaces;

namespace Utilities.Wrappers;

public class FileWrapper : IFileWrapper
{
    public void CreateDirectory(string input)
    {
        Directory.CreateDirectory(input);
    }

    public bool Exists(string input)
    {
        return File.Exists(input);
    }
}
