using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId.RelyingParty;

using Pulsey.Web.Api.Models;
using System.Web.Routing;
using System.Web;

namespace Pulsey.Web.Api.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static OpenIdRelyingParty _openId = new OpenIdRelyingParty();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {

            return View();

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [ValidateInput(false)]
        public ActionResult Authenticate(string returnUrl)
        {
            string googleOpenId = "https://www.google.com/accounts/o8/id";
            var response = _openId.GetResponse();

            if (response == null)
            {
                Identifier id;
                if (Identifier.TryParse(googleOpenId, out id))
                {
                    try
                    {
                        var request = _openId.CreateRequest(googleOpenId);

                        request.AddExtension(new ClaimsRequest()
                        {
                            Email = DemandLevel.Require
                        });

                        return request.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ViewData["Message"] = ex.Message;
                        return View("Login");
                    }
                }
                else
                {
                    ViewData["Message"] = "Invalid identifier";
                    return View("Login");
                }
            }
            else
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;

                        var sreg = response.GetExtension<ClaimsResponse>();

                        if (sreg != null)
                        {
                            //User user = Session["SignupProfile"] as User;
                            //    if (user != null)
                            //  {
                            //  user.Email = sreg.Email;
                            // user.Token = sreg.Email;

                            //     IUserService.SaveUser(user);
                            // }
                            // else
                            // {
                            //   user = IUserService.GetUser(sreg.Email);
                            // if (user == null)
                            // {
                            //   return RedirectToAction("Create");
                            // }
                            //}
                            // Do something with the values here, like store them in your database for this user.
                            var userData = string.Format("{0};{1};{2}", 1, "Bradley", "bratleylower@gmail.com");
                            var ticket = new FormsAuthenticationTicket(
                                           2, // magic number used by FormsAuth
                                           response.ClaimedIdentifier, // username
                                           DateTime.Now,
                                           DateTime.Now.AddDays(30),
                                           true, // "remember me"
                                           userData);

                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                            if (ticket.IsPersistent)
                            {
                                cookie.Expires = ticket.Expiration;
                            }
                            Response.SetCookie(cookie);

                            //  Response.Redirect(returnUrl ?? "/");


                        }


                        if (!String.IsNullOrEmpty(returnUrl))
                        {

                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Item");
                        }
                    case AuthenticationStatus.Canceled:
                        ViewData["Message"] = "Canceled at provider";
                        return View("Login");
                    case AuthenticationStatus.Failed:
                        ViewData["Message"] = response.Exception.Message;
                        return View("Login");
                }
            }

            return new EmptyResult();
        }

    }
}
