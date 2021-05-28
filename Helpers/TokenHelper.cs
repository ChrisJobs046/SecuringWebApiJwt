using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using SecuringWebApiJwt.Entities;
using Microsoft.IdentityModel.Tokens;

namespace SecuringWebApiJwt.Helpers
{
    public class TokenHelper
    {
        public const string Issuer = "http://codingsonata.com";
        public const string Audience = "http://codingsonata.com";

        public const string Secret = "OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==";

        /*
        El secret es una cadena codificada en base64, asegúrese siempre de usar una cadena larga segura para que nadie pueda adivinarlo. ¡siempre!.
        // un enfoque muy recomendado para usar es a través de la clase HMACSHA256 (), para generar un secreto tan seguro, puede consultar la función a continuación
        // puede ejecutar una pequeña prueba llamando a la función GenerateSecureSecret () para generar un secreto seguro aleatorio una vez, tomarlo y usarlo como el secreto anterior
        // o puede guardarlo en el archivo appsettings.json y luego cargarlo desde ellos, la elección es suya
        */

        public static string GenerateSecureSecret(){

            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }

        public static string GenerateToken(Customer customer){

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(Secret);

            var claimsIdentity = new ClaimsIdentity(new[] {

                new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                new Claim("IsBlosked", customer.Blocked.ToString())
            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);


            var tokenDescriptor = new SecurityTokenDescriptor{

                Subject = claimsIdentity,
                Issuer = Issuer,
                Audience = Audience,
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = signingCredentials,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}