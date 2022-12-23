using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AP.BoomTP.WebAPI.Controllers
{
    public class UserController : APIv1Controller
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await mediator.Send(new GetAllUsersQuery() { pageNr = pageNr, pageSize = pageSize }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand user)
        {
            return Created("", await mediator.Send(user));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {

            var user = await mediator.Send(new GetUserByIdQuery() { Id = id });
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        [Route("getbyauthid/{authid}")]
        public async Task<IActionResult> GetUserByAuthId(string authid)
        {

            var user = await mediator.Send(new GetUserByAuthIdQuery() { AuthId = authid });
            if (user == null)
                return NotFound();
            

            return Ok(user) ;
        }

        [HttpGet]
        [Route("getbyauthidfiltered/{authid}")]
        public async Task<IActionResult> GetUserByAuthIdFiltered(string authid)
        {

            var user = await mediator.Send(new GetUserScheduleFilteredQuery() { AuthId = authid });
            if (user == null)
                return NotFound();


            return Ok(user);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await mediator.Send(new DeleteUserCommand() { Id = id });
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand user)
        {
            var userUpdate = await mediator.Send(new UpdateUserCommand() { 
                FirstName = user.FirstName, 
                LastName = user.LastName, 
                AuthId = user.AuthId, 
                Email = user.Email, 
                ContractType = user.ContractType, 
                Role = user.Role, 
                Id = id });
            if (userUpdate == null)
                return NotFound();

            return Ok(userUpdate);
        }
    }
}
