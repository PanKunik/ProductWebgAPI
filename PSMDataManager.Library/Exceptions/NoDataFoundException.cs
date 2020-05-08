using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSMDataManager.Library.Exceptions
{
    public class NoDataFoundException : Exception
    {
        public NoDataFoundException(string message) : base(message)
        {

        }
    }
}
