using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Application.Interfaces.ScheduleI;
using AP.BoomTP.Domain;
using AP.BoomTP.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly BoomTPContext context;

        public ScheduleRepository(BoomTPContext context)
        {
            this.context = context;
        }

        public Schedule Create(Schedule obj)
        {
            context.Schedule.Add(obj);
            return obj;
        }

        public void Delete(Schedule obj)
        {
            context.Remove(obj);
        }

        public async Task<IEnumerable<Schedule>> GetAll(int pageNr, int pageSize)
        {
            return await context.Schedule.Include(s => s.ScheduleTask).Include(s => s.Zone).Include(s => s.User).Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetAllById(int id)
        {
            return await context.Schedule.Include(s => s.ScheduleTask).Include(s => s.Zone).Include(s => s.User).Where(s => s.UserId == id).ToListAsync();
        }

        public async Task<Schedule> GetById(int id)
        {
            return await context.Schedule.Include(s => s.ScheduleTask).FirstOrDefaultAsync(p => p.Id == id);
        }


        public Schedule Update(Schedule obj)
        {
            context.Schedule.Update(obj);
            return obj;
        }


        public async Task<List<Schedule>> GetAllScheduleByUserId(int id)
        {
            return await context.Schedule.Include(s => s.ScheduleTask).Where(s => s.UserId == id).ToListAsync();
        }

        public async Task<List<Schedule>> GetScheduleThisWeek(int id)
        {
            return await context.Schedule.Include(s => s.ScheduleTask).Where(s => s.UserId == id).Where(s => s.Date.Date >= DateTime.Today.Date.AddDays(-5)).Where(s => s.Date.Date <= DateTime.Today.Date.AddDays(+5)).ToListAsync();
        }

        public async Task<List<Schedule>> GetBehindScheduleQuery(int pageNr, int pageSize)
        {
            return await context.Schedule.Include(s => s.ScheduleTask.Where(s=>s.Status==Status.Made)).Where(s => s.Date.Date <= DateTime.Today.Date && s.ScheduleTask.Any()).Include(s => s.Zone).Include(s => s.User).Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }
            
        public Schedule UpdateStatus(Schedule obj)
        {
            context.Schedule.Update(obj);
            return obj;
        }

        public async Task<List<Schedule>> GetScheduleByDateAndId(DateTime date, int zoneId)
        {
            return await context.Schedule.Include(s => s.ScheduleTask).Where(x => x.Date.Date == date.Date && x.ZoneId == zoneId).ToListAsync();
        }

        public async Task<List<Schedule>> GetScheduleByDateAndUserId(DateTime date, int userId)
        {
            return await context.Schedule.Include(s => s.ScheduleTask).Where(x => x.Date.Date == date.Date && x.UserId == userId).ToListAsync();
        }
    }
}
