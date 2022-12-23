using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.BoomTP.Application.Interfaces.GrowSiteI;
using AP.BoomTP.Application.Interfaces.ScheduleI;
using AP.BoomTP.Application.Interfaces.ScheduleTaskI;
using AP.BoomTP.Application.Interfaces.TaskI;
using AP.BoomTP.Application.Interfaces.TreeSpeciesI;
using AP.BoomTP.Application.Interfaces.UserI;
using AP.BoomTP.Application.Interfaces.ZoneI;

namespace AP.BoomTP.Application.Interfaces
{
    public interface IUnitofWork
    {
        public IGrowSiteRepository GrowSiteRepository { get; }
        public ITreeSpeciesRepository TreeSpeciesRepository { get; }
        public IZoneRespository ZoneRespository { get; }
        public IUserRepository UserRepository { get; }
        public ITasksRepository TasksRepository { get; }
        public IScheduleRepository ScheduleRepository { get; }

        public IScheduleTaskRepository ScheduleTaskRepository { get; }

        Task Commit();
    }
}
