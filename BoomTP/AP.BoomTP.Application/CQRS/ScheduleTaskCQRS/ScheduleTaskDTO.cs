using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ScheduleStatusCQRS
{
    public class ScheduleTaskDTO
    {
        public int ScheduleId { get; set; }
        public int TasksId { get; set; }
        public Status Status { get; set; }

        public TasksDTO Tasks { get; set; }
    }
    public enum Status
    {
        Made,
        Start,
        Ended
    }
}