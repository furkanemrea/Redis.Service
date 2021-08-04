using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Helper
{
    public enum ResponseCodes:int
    {
         IsEmpty = 0,
         IsNotFound = 1,
         Success=2
    }
}
