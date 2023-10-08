using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Wrappers.Interfaces;

public interface IFileWrapper
{
    void CreateDirectory(string input);
    bool Exists(string input);
}
