using System.Threading.Tasks;
using SecuringWebApiJwt.Requests;
using SecuringWebApiJwt.Responses;

namespace SecuringWebApiJwt.Interfaces
{
    public interface ICustomerService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}