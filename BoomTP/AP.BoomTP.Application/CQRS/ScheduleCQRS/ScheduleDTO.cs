using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ScheduleCQRS
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ZoneId { get; set; }
        public ZoneDetail Zone { get; set; }
        public int UserId { get; set; }
        public UserDetail User { get; set; }
        public ICollection<ScheduleTaskDTO> ScheduleTask { get; set; }
    }
}
