using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
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
    public class DeleteTreeSpeciesCommand : IRequest<TreeSpeciesId>
    {
        public int? Id { get; set; }

    }
    public class DeleteTreeSpeciesValidator : AbstractValidator<DeleteTreeSpeciesCommand>
    {
        public DeleteTreeSpeciesValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        }
    }
    public class DeleteTreeSpeciesCommandHandler : IRequestHandler<DeleteTreeSpeciesCommand, TreeSpeciesId>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteTreeSpeciesCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TreeSpeciesId> Handle(DeleteTreeSpeciesCommand request, CancellationToken cancellationToken)
        {
            if(request.Id != null)
            {
                TreeSpecies treeSpecies = await uow.TreeSpeciesRepository.GetById(request.Id.Value);
                uow.TreeSpeciesRepository.Delete(treeSpecies);
                await uow.Commit();
                return mapper.Map<TreeSpeciesId>(treeSpecies);
            }
            return null;
        }
    }
}