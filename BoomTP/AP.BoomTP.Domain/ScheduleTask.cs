using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Domain
{
    public class ScheduleTask
    {
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public Status Status { get; set; }
        public int TasksId { get; set; }
        public Tasks Tasks { get; set; }
    }
    public enum Status
    {
        Made,
        Start,
        Ended
    }
}
