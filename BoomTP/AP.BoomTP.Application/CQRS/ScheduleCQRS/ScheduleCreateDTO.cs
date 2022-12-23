using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ScheduleCQRS
{
    public class ScheduleCreateDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int ZoneId { get; set; }
        public int ScheduleStatusId { get; set; }
/*        public int[] TaskId { get; set; }
*/    }
}
