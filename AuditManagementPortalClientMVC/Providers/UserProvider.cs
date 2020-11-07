using AuditManagementPortalClientMVC.Models;
using AuditManagementPortalClientMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepo _userRepo;

        public UserProvider(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public bool CheckUser(User user)
        {
            List<User> users = _userRepo.GetUsers();
            foreach(User usr in users) 
            {
                if (user.Name == usr.Name && user.Password == usr.Password) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
