using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Interfaces.ScheduleTaskI
{
    public interface IScheduleTaskRepository : IGenericRepository<ScheduleTask>
    {
        Task<ScheduleTask> GetByScheduleIdAndTaskId(int scheduleId, int taskId);
        Task<List<ScheduleTask>> GetByScheduleId(int scheduleId);

    }
}
