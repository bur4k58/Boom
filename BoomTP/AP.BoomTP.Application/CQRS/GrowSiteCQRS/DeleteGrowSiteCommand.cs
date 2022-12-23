using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.GrowSiteCQRS
{
    public class DeleteGrowSiteCommand : IRequest<GrowSiteId>
    {
        public int? Id { get; set; }
    }
    public class DeleteGrowSiteValidator : AbstractValidator<DeleteGrowSiteCommand>
    {
        public DeleteGrowSiteValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        }
    }
    public class DeleteGrowSiteCommandHandler : IRequestHandler<DeleteGrowSiteCommand, GrowSiteId>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteGrowSiteCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<GrowSiteId> Handle(DeleteGrowSiteCommand request, CancellationToken cancellationToken)
        {
            if(request.Id != null)
            {
                GrowSite growSite = await uow.GrowSiteRepository.GetById(request.Id.Value);
                uow.GrowSiteRepository.Delete(growSite);
                await uow.Commit();
                return mapper.Map<GrowSiteId>(growSite);
            }
            return null;
        }
    }
}