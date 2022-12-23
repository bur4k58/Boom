using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
        public ICollection<ScheduleTask> ScheduleTask { get; set; }
    }
}
 