using AuthorizationService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Providers
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IAuthRepo _authRepo;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthProvider));
        public AuthProvider(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }
        public string GetJsonWebToken()
        {
            _log4net.Info(" GetJsonWebToken method of AuthProvider Called ");
            string token = _authRepo.GenerateJWT();
            return token;
        }
    }
}
