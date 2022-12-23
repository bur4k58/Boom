using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Exceptions
{
    public class ZoneException : Exception
    {
        public ZoneException(string message) : base(message)
        {

        }
    }
}
