using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleCQRS;
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

namespace AP.BoomTP.Application.CQRS.TreeSpeciesCQRS
{
    public class CreateTreeSpeciesCommand : IRequest<TreeSpeciesDTO>
    {
        public string Name { get; set; }
        public string MaintenanceInstructions { get; set; }
        public string ImageUrl { get; set; }
        public int[] TaskId { get; set; }

    }

    public class CreateTreeSpeciesValidator : AbstractValidator<CreateTreeSpeciesCommand>
    {
        public CreateTreeSpeciesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be null");
        }
    }

    public class CreateTreeSpeciesCommandHandler : IRequestHandler<CreateTreeSpeciesCommand, TreeSpeciesDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public CreateTreeSpeciesCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;

        }

        public async Task<TreeSpeciesDTO> Handle(CreateTreeSpeciesCommand request, CancellationToken cancellationToken)
        {
            var treeSpecies = new TreeSpecies()
            {
                Name = request.Name,
                MaintenanceInstructions = request.MaintenanceInstructions,
                ImageUrl = request.ImageUrl,
                Tasks = new List<Tasks>()
            };

            if (request.TaskId != null)
            {
                foreach (int i in request.TaskId)
                {
                    Tasks task = await uow.TasksRepository.GetById(i);
                    treeSpecies.Tasks.Add(task);
                }
            }

            uow.TreeSpeciesRepository.Create(treeSpecies);
            await uow.Commit();
            return mapper.Map<TreeSpeciesDTO>(treeSpecies);
        }
    }
}
 

