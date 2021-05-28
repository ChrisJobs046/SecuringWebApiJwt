using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecuringWebApiJwt.Interfaces;
using SecuringWebApiJwt.Requests;

namespace SecuringWebApiJwt.Controllers
{

    /*
    tendrá un método POST que aceptará el nombre de usuario y la contraseña y devolverá el token JWT 
    junto con otros detalles del cliente si el proceso de inicio de sesión se realizó correctamente de lo 
    contrario devolverá 400 solicitudes incorrectas
    */

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerService _customService;

        public CustomersController(ICustomerService customer){

            this._customService = customer;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest){

            if(loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password)){

                return BadRequest("Missing login details");
            }

            var loginResponse = await _customService.Login(loginRequest);

            if (loginResponse == null)
            {
                return BadRequest($"Invalid credentials");
            }
            
            return Ok(loginResponse);
        }
    }
}