 
using Utilities.Wrappers.Interfaces;

namespace Utilities.Wrappers;

public class PathWrapper : IPathWrapper
{
    public string Combine(string path1, string path2)
        => Path.Combine(path1, path2);

    public string Combine(string path1, string path2, string path3)
        => Path.Combine(path1, path2, path3);

    public string Combine(string path1, string path2, string path3, string path4)
        => Path.Combine(path1, path2, path3, path4);

    public string GetExtension(string path)
        => Path.GetExtension(path);

    public string GetFileNameWithoutExtension(string path)
        => Path.GetFileNameWithoutExtension(path);

    public string GetFileName(string path)
        => Path.GetFileName(path);
}
