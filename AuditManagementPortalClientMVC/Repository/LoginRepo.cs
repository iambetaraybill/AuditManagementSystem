using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditManagementPortalClientMVC.Repository
{
    public class LoginRepo : ILoginRepo
    {
        public async Task<string> GetToken()
        {
            string t = "";
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("https://localhost:44396/api/token"))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    //TempData["token"] = token;
                    t = token;
                    //ViewBag.Token = token;
                    // var t = TempData["token"].ToString();//1

                }


            }

            return t;
            //throw new NotImplementedException();
        }
    }
}
