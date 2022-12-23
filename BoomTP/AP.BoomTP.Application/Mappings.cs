using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.CQRS.ScheduleTaskCQRS;
using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Domain;
using AutoMapper;

namespace AP.BoomTP.Application;
internal class Mappings : Profile
{
    public Mappings()
    {
        //GrowSite
        CreateMap<GrowSite, GrowSiteDetailDTO>();
        CreateMap<GrowSite, GrowSiteDTO>();
        CreateMap<GrowSite, GrowSiteId>();
        CreateMap<GrowSite, GrowSiteName>();
        //TreeSpecies
        CreateMap<TreeSpecies, TreeSpeciesDTO>();
        CreateMap<TreeSpecies, TreeSpeciesDetailDTO>();
        CreateMap<TreeSpecies, TreeSpeciesId>();
        CreateMap<TreeSpecies, TreeSpeciesName>();
        //Zone
        CreateMap<Zone, ZoneDTO>();
        CreateMap<Zone, ZoneId>();
        CreateMap<Zone, ZoneDetail>();
        //User
        CreateMap<User, UserDTO>();
        CreateMap<User, UserDetail>();
        CreateMap<User, UserId>();
        CreateMap<User, UserUpdate>();
        //Schedule
        CreateMap<Schedule, ScheduleDTO>();
        CreateMap<Schedule, ScheduleDetailDTO>();
        CreateMap<Schedule, ScheduleId>();
        //ScheduleTask
        CreateMap<ScheduleTask, ScheduleTaskDTO>();
        CreateMap<ScheduleTask, ScheduleTaskDetailDTO>();
        CreateMap<ScheduleTask, ScheduleTaskIds>();
        //Task
        CreateMap<Tasks, TasksDTO>();
        CreateMap<Tasks, TasksDetailDTO>();
        CreateMap<Tasks, TasksId>();
    }
}
