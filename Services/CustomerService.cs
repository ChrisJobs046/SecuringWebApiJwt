using System.Threading.Tasks;
using SecuringWebApiJwt.Entities;
using SecuringWebApiJwt.Interfaces;
using SecuringWebApiJwt.Requests;
using SecuringWebApiJwt.Responses;
using System;
using  System.Linq;


namespace SecuringWebApiJwt.Services
{
    public class CustomerService : ICustomerService
    {

        //Aqui creamos un objeto que va a representar a nuestra base de datos, mejor dicho su instancia
        private readonly ClientesDbContext clientesDbContext;

        /*Aqui tenemos un constructor de nuestra clase en donde estamos usando injeccion de dependencias
        donde le decimos que injecte el objeto de nuestra base de datos dentro de nuestra clase a la hora de que se ejecute la
        aplicacion, diciendole que nuestro objeto externo sera igual al que derivamos dentro, usamos this, ya que this tiene
        acceso a todos los elementos y metodos de nuestra clase.
        */
        public CustomerService(ClientesDbContext _client){

            this.clientesDbContext = _client;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var cliente = clientesDbContext.Customers.SingleOrDefault(cliente => cliente.Active && cliente.Username == loginRequest.Username); 

            if(cliente == null){

                return null;
            }

            var contraseñaHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password, cliente.PasswordSalt);

            if(cliente.Password != contraseñaHash){

                return null;
            }

            var token = await Task.Run( () => TokenHelper.GenerateToken(cliente));

            return new LoginResponse { Username = cliente.Username, FirstName = cliente.FirtName, LastName = cliente.LastName, Token = token };
        }
    }
}