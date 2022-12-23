using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.Interfaces.UserI;
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
    public class UserRepository : IUserRepository
    {
        private readonly BoomTPContext context;

        public UserRepository(BoomTPContext context)
        {
            this.context = context;
        }
        public User Create(User obj)
        {
            context.User.Add(obj);
            return obj;
        }

        public void Delete(User obj)
        {
            context.Remove(obj);
        }

        public async Task<IEnumerable<User>> GetAll(int pageNr, int pageSize)
        {
            return await context.User.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await context.User.Include(s => s.Schedules).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<User>> GetByAuthId(string id)
        {
            return await context.User.Include(s => s.Schedules).Include(s => s.Schedules.Where(s => s.Date.Date > DateTime.Today.Date.AddDays(-5)).Where(s => s.Date.Date < DateTime.Today.Date.AddDays(+5)).OrderBy(s => s.Date)).ThenInclude(s => s.ScheduleTask).ThenInclude(t => t.Tasks).Where(p => p.AuthId == id).ToListAsync();
        }
        public async Task<List<User>> GetByAuthIdFilter(string id)
        {
            return await context.User.Include(s => s.Schedules).Include(s => s.Schedules.Where(x => x.Date.Date == DateTime.Today).OrderBy(s => s.Date)).ThenInclude(s => s.ScheduleTask).ThenInclude(t => t.Tasks).Where(p => p.AuthId == id).ToListAsync();
        }
        
        public User Update(User obj)
        {
            context.User.Update(obj);
            return obj;
        }

    }
}
