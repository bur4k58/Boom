using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Exceptions
{
    public class ScheduleException : Exception
    {
        public ScheduleException(string message) : base(message)
        {

        }
    }
}
