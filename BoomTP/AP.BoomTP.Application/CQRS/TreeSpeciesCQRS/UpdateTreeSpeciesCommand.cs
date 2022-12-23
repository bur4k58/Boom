using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
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
    public class UpdateTreeSpeciesCommand: IRequest<TreeSpeciesDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MaintenanceInstructions { get; set; }
        public string ImageUrl { get; set; }
        public int[] TaskId { get; set; }
    }

    public class UpdateTreeSpeciesValidator: AbstractValidator<UpdateTreeSpeciesCommand>
    {
        public UpdateTreeSpeciesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be null");
        }
    }
    public class UpdateTreeSpeciesCommandHandler : IRequestHandler<UpdateTreeSpeciesCommand, TreeSpeciesDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public UpdateTreeSpeciesCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TreeSpeciesDTO> Handle(UpdateTreeSpeciesCommand request, CancellationToken cancellationToken)
        {
            List<Tasks> tasks = new List<Tasks>();

            foreach (int i in request.TaskId)
            {
                Tasks task = await uow.TasksRepository.GetById(i);
                tasks.Add(task);
            }

            TreeSpecies treeSpecies= await uow.TreeSpeciesRepository.GetById(request.Id);
            treeSpecies.Name = request.Name;
            treeSpecies.MaintenanceInstructions = request.MaintenanceInstructions;
            treeSpecies.ImageUrl = request.ImageUrl;
            treeSpecies.Tasks = tasks;

            uow.TreeSpeciesRepository.Update(treeSpecies);
            await uow.Commit();

            return mapper.Map<TreeSpeciesDTO>(treeSpecies);
        }
    }
}
