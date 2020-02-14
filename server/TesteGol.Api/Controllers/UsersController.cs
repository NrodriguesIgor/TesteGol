using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteGol.Api.Requests;
using TesteGol.Model.Services;

namespace TesteGol.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IAutheticationService _authenticationService;

        public UsersController(IAutheticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateRequest request)
        {
            var user = await _authenticationService
                .Authenticate(request.UserName, request.Password)
                .ConfigureAwait(false);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        [AllowAnonymous]
        [HttpOptions]
        public IActionResult Options()
        {
            HttpContext.Response.Headers.Add("Allow", "*");
            return Ok();
        }
    }
}
