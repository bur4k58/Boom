using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.Interfaces.ScheduleI
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task<List<Schedule>> GetAllScheduleByUserId(int id);
        Task<List<Schedule>> GetScheduleThisWeek(int id);
        Task<List<Schedule>> GetBehindScheduleQuery(int pageNr, int pageSize);
        Task<List<Schedule>> GetScheduleByDateAndId(DateTime date, int zoneId);
        Task<List<Schedule>> GetScheduleByDateAndUserId(DateTime date, int userId);
        Schedule UpdateStatus(Schedule obj);
    }
}
