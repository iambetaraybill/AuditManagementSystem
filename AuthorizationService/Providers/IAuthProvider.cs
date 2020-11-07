using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Providers
{
    public interface IAuthProvider
    {
        public string GetJsonWebToken();
    }
}
