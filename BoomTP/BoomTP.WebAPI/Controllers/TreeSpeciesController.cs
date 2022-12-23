using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
using AP.BoomTP.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AP.BoomTP.WebAPI.Controllers
{
    public class TreeSpeciesController : APIv1Controller
    {
        private readonly IMediator mediator;

        public TreeSpeciesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTreeSpecies([FromBody] CreateTreeSpeciesCommand treeSpecies)
        {
            return Created("", await mediator.Send(treeSpecies));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllTreeSpecies([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await mediator.Send(new GetAllTreeSpeciesQuery() { pageNr = pageNr, pageSize = pageSize }));
        }

        [HttpGet]
        [Route("{id}")]
        
        public async Task<IActionResult> GetTreeSpecies(int id)
        {

            var treeSpecies = await mediator.Send(new GetTreeSpeciesByIdQuery() { Id = id });
            if (treeSpecies == null)
                return NotFound();

            return Ok(treeSpecies);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTreeSpecies(int id)
        {
            var treeSpecies = await mediator.Send(new DeleteTreeSpeciesCommand() { Id = id });
            if (treeSpecies == null)
                return NotFound();

            return Ok(treeSpecies);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTreeSpecies(int id, [FromBody] UpdateTreeSpeciesCommand treeSpecies)
        {
            var treeSpeciesUpdate = await mediator.Send(new UpdateTreeSpeciesCommand() 
            {
                Id = id,
                MaintenanceInstructions = treeSpecies.MaintenanceInstructions,
                ImageUrl = treeSpecies.ImageUrl,
                Name = treeSpecies.Name,
                TaskId = treeSpecies.TaskId
            });

            if (treeSpeciesUpdate == null)
                return NotFound();

            return Ok(treeSpeciesUpdate);
        }
    }
}
