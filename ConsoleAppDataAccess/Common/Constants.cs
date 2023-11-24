using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDataAccess.Common
{
    internal class Constants
    {
        internal static List<string> BlackList = 
            new List<string>() { "delete", "update", "truncate", "insert", "drop", "create" };
    }
}
