using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationService.Repository
{
    public class AuthRepo : IAuthRepo
    {
        private readonly IConfiguration _config;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthRepo));
        public AuthRepo(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJWT()
        {
            _log4net.Info(" GenerateJWT method of AuthRepo Called ");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
