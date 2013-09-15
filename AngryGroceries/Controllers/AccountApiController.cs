using System.Web;
using System.Web.Http;
using AngryGroceries.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AngryGroceries.Controllers
{
    public class AccountApiController : ApiController
    {
        public AccountApiController()
        {
            IdentityManager = new AuthenticationIdentityManager(new IdentityStore(new AngryGroceriesDbContext()));
        }

        public AccountApiController(AuthenticationIdentityManager manager)
        {
            IdentityManager = manager;
        }

        public AuthenticationIdentityManager IdentityManager { get; private set; }

        private Microsoft.Owin.Security.IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public bool Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Validate the user password
                IdentityResult result = IdentityManager.Authentication.CheckPasswordAndSignIn(AuthenticationManager,
                                                                                              model.UserName,
                                                                                              model.Password,
                                                                                              model.RememberMe);
                return result.Success;
            }
            return false;
        }
    }
}
