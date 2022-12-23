using AP.BoomTP.Application.Interfaces.TaskI;
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
    public class TasksRepository : ITasksRepository
    {
        private readonly BoomTPContext context;

        public TasksRepository(BoomTPContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Tasks>> GetAll(int pageNr, int pageSize)
        {
            return await context.Tasks.Skip((pageNr - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<Tasks> GetById(int id)
        {
            return await context.Tasks.Include(t => t.TreeSpecies).
                Include(s => s.SchedulesStatus).
                FirstOrDefaultAsync(p => p.Id == id);
        }
        public Tasks Create(Tasks newTask)
        {
            context.Tasks.Add(newTask);
            return newTask;
        }
        public Tasks Update(Tasks modifiedTask)
        {
            context.Tasks.Update(modifiedTask);
            return modifiedTask;
        }

        public void Delete(Tasks task)
        {
            context.Remove(task);
        }
        public Tasks DeleteTask(int id)
        {
            var task = context.Tasks.FirstOrDefault(p => p.Id == id);
            context.Tasks.Remove(task);
            return task;
        }
    }
}
