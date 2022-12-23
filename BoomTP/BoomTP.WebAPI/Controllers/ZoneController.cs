using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AP.BoomTP.WebAPI.Controllers
{

    public class ZoneController : APIv1Controller
    {
        private readonly IMediator mediator;
        public ZoneController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> CreateZone([FromBody] CreateZoneCommand zone)
        {
            return Created("", await mediator.Send(zone));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllZone([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await mediator.Send(new GetAllZoneQuery { pageNr = pageNr, pageSize = pageSize }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetZone(int id)
        {

            var zone = await mediator.Send(new GetZoneByIdQuery() { Id = id });
            if (zone == null)
                return NotFound();

            return Ok(zone);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteZone(int id)
        {
            var zoneD = await mediator.Send(new DeleteZoneCommand() { Id = id });
            if (zoneD == null)
                return NotFound();

            return Ok(zoneD);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateZoneSite(int id, [FromBody] UpdateZoneCommand zone)
        {
            var zoneUpdate = await mediator.Send(new UpdateZoneCommand() { Name = zone.Name, Size = zone.Size, QrCode = zone.QrCode, GrowSiteId = zone.GrowSiteId, TreeSpeciesId = zone.TreeSpeciesId, Id = id });
            if (zoneUpdate == null)
                return NotFound();

            return Ok(zoneUpdate);
        }
    }
}