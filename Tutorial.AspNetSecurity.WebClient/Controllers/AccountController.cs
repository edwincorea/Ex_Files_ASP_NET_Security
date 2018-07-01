using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tutorial.AspNetSecurity.WebClient.Controllers
{
    public class AccountController : Controller
    {        
        public AccountController() { }

        [HttpPost]
        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            await HttpContext.Authentication.SignOutAsync("oidc");
        }
    }
}
