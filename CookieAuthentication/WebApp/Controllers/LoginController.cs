using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using WebApp.Model;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        #region ctor

        readonly Business.Abstract.IAuthenticationService authenticationService;
        readonly IHttpContextAccessor httpContextAccessor;

        public LoginController(Business.Abstract.IAuthenticationService authenticationService, IHttpContextAccessor httpContextAccessor)
        {
            this.authenticationService = authenticationService;
            this.httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region login

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var claimsIdentity = authenticationService.AuthenticateMemberByEmail(loginViewModel.Email, loginViewModel.Password);
            if (ClaimsIdentityExist(claimsIdentity))
            {
                var userPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });
                var authenticationProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(10), //Cookie değerinin geçerlilik süresi için kullanılır.
                    IsPersistent = true, //Beni hatırla için kullanılır ve modelden gönderilmesi gerekir.
                };

                httpContextAccessor.HttpContext.SignInAsync(userPrincipal, authenticationProperties);

                return RedirectToAction(ActionNames.Index, ControllerNames.Home);
            }
            else
            {
                return View();
            }
        }

        static bool ClaimsIdentityExist(ClaimsIdentity claimsIdentity)
        {
            return claimsIdentity != null;
        }

        #endregion

        #region logout

        [Authorize]
        public ActionResult LogOut()
        {
            httpContextAccessor.HttpContext.SignOutAsync();

            return RedirectToHome();
        }

        ActionResult RedirectToHome()
        {
            return RedirectToAction(ActionNames.Index, ControllerNames.Home);
        }

        #endregion

        #region user access denied

        public ActionResult UserAccessDenied()
        {
            return View(nameof(UserAccessDenied));
        }

        #endregion
    }
}