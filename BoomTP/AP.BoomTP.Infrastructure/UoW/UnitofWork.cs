using AP.BoomTP.Infrastructure.Contexts;
using AP.BoomTP.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Application.Interfaces.GrowSiteI;
using Microsoft.Data.SqlClient;
using AP.BoomTP.Application.Interfaces.TreeSpeciesI;
using AP.BoomTP.Domain;
using static Humanizer.In;
using AP.BoomTP.Application.Interfaces.ZoneI;
using AP.BoomTP.Application.Interfaces.UserI;
using AP.BoomTP.Application.Interfaces.TaskI;
using AP.BoomTP.Application.Interfaces.ScheduleI;
using AP.BoomTP.Application.Interfaces.ScheduleTaskI;

namespace AP.BoomTP.Infrastructure.UoW
{
    public class UnitofWork : IUnitofWork
    {
        private readonly BoomTPContext ctxt;
        private readonly IGrowSiteRepository growSiteRepo;
        private readonly ITreeSpeciesRepository treeSpeciesRepo;
        private readonly IZoneRespository zoneRespository;
        private readonly IUserRepository userRepository;
        private readonly ITasksRepository taskRepository;
        private readonly IScheduleRepository scheduleRepository;
        private readonly IScheduleTaskRepository scheduleTaskRepository;

        public UnitofWork(BoomTPContext ctxt, IScheduleTaskRepository scheduleTaskRepository, IGrowSiteRepository growSiteRepo, ITreeSpeciesRepository treeSpeciesRepo, IZoneRespository zoneRespository, IUserRepository userRepository, ITasksRepository taskRepository, IScheduleRepository scheduleRepository)
        {
            this.ctxt = ctxt;
            this.growSiteRepo = growSiteRepo;
            this.treeSpeciesRepo = treeSpeciesRepo;
            this.zoneRespository = zoneRespository;
            this.userRepository = userRepository;
            this.taskRepository = taskRepository;
            this.scheduleRepository = scheduleRepository;
            this.scheduleTaskRepository =scheduleTaskRepository;
        }

        public IGrowSiteRepository GrowSiteRepository => growSiteRepo;

        public ITreeSpeciesRepository TreeSpeciesRepository => treeSpeciesRepo;

        public IZoneRespository ZoneRespository => zoneRespository;

        public IUserRepository UserRepository => userRepository;

        public ITasksRepository TasksRepository => taskRepository;
        public IScheduleRepository ScheduleRepository => scheduleRepository;

        public IScheduleTaskRepository ScheduleTaskRepository => scheduleTaskRepository;
        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
