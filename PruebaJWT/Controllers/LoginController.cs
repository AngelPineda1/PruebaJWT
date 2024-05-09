using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaJWT.Helpers;

namespace PruebaJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(string username, string password)
        {
            if (password == "ITESRC")
            {
                JwtTokenGenerator tokenGenerator = new JwtTokenGenerator();
                return Ok(tokenGenerator.GetToken(username));
            }
            return Unauthorized();  
        }
    }
}
