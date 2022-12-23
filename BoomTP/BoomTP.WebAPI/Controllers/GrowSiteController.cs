using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.Exceptions;
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Application.Interfaces.GrowSiteI;
using AP.BoomTP.Domain;
using AP.BoomTP.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace AP.BoomTP.WebAPI.Controllers
{
    public class GrowSiteController : APIv1Controller
    {
        private readonly IMediator mediator;

        public GrowSiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrowSite([FromBody] CreateGrowSiteCommand growSite)
        {
            return Created("", await mediator.Send(growSite));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGrowSite(int id, [FromBody] UpdateGrowSiteCommand growSite)
        {
            var growSiteUpdate = await mediator.Send(new UpdateGrowSiteCommand() {Address = growSite.Address, Map = growSite.Map, Name = growSite.Name, Id = id});
            if (growSiteUpdate == null)
                return NotFound();

            return Ok(growSiteUpdate);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrowSite([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await mediator.Send(new GetAllGrowSiteQuery() { pageNr = pageNr, pageSize = pageSize }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGrowSite(int id)
        {

            var growSite = await mediator.Send(new GetGrowSiteByIdQuery() { Id = id });
            if (growSite == null)
                return NotFound();

            return Ok(growSite);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteGrowSite(int id)
        {
            var growSite = await mediator.Send(new DeleteGrowSiteCommand() { Id = id });
            if (growSite == null)
                return NotFound();

            return Ok(growSite);
        }
    }
}