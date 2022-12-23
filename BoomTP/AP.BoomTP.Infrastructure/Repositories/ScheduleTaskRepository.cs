using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.Interfaces.ScheduleI;
using AP.BoomTP.Application.Interfaces.ScheduleTaskI;
using AP.BoomTP.Domain;
using AP.BoomTP.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Infrastructure.Repositories
{
    public class ScheduleTaskRepository : IScheduleTaskRepository
    {
        private readonly BoomTPContext context;

        public ScheduleTaskRepository(BoomTPContext context)
        {
            this.context = context;
        }

        public ScheduleTask Create(ScheduleTask scheduleStatus)
        {
            context.ScheduleTask.Add(scheduleStatus);
            return scheduleStatus;
        }

        public async Task<IEnumerable<ScheduleTask>> GetAll(int pageNr, int pageSize)
        {
            return await context.ScheduleTask.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public void Delete(ScheduleTask obj)
        {
            context.Remove(obj);
        }

        public async Task<ScheduleTask> GetByScheduleIdAndTaskId(int scheduleId, int taskId)
        {
            return await context.ScheduleTask.Include(g => g.Tasks).FirstOrDefaultAsync(g => g.ScheduleId == scheduleId && g.TasksId == taskId);
        }
        public async Task<List<ScheduleTask>> GetByScheduleId(int scheduleId)
        {
            return await context.ScheduleTask.Include(g => g.Tasks).Where(g => g.ScheduleId == scheduleId).ToListAsync();
        }

        public ScheduleTask Update(ScheduleTask modifiedStatus)
        {
            context.ScheduleTask.Update(modifiedStatus);
            return modifiedStatus;
        }

        public Task<ScheduleTask> GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
