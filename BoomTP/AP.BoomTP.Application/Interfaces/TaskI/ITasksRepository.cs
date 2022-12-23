
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.BoomTP.Domain;
using Task = AP.BoomTP.Domain.Tasks;

namespace AP.BoomTP.Application.Interfaces.TaskI
{
    public interface ITasksRepository : IGenericRepository<Tasks>
    {
    }
}
