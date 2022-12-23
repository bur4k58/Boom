
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.TasksCQRS
{
    public class UpdateTasksCommand : IRequest<TasksDTO>
    {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public float TaskTime { get; set; }
    }
    public class UpdateTasksValidator : AbstractValidator<UpdateTasksCommand>
    {
        public UpdateTasksValidator()
        {
            RuleFor(x => x.TaskTime).NotEmpty().WithMessage("TaskTime can not be null");
        }
    }
    public class UpdateTasksCommandHandler : IRequestHandler<UpdateTasksCommand, TasksDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public UpdateTasksCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TasksDTO> Handle(UpdateTasksCommand request, CancellationToken cancellationToken)
        {
            Tasks task = await uow.TasksRepository.GetById(request.Id);
            task.Title = request.Title;
            task.Description = request.Description;
            task.TaskTime = request.TaskTime;

            uow.TasksRepository.Update(task);
            await uow.Commit();

            return mapper.Map<TasksDTO>(task);
        }
    }

}
