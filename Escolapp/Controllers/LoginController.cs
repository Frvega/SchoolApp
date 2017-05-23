using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escolapp.Models;
using System.Web.Security;

namespace Escolapp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string correo_usuario, string password_usuario)
        {
            using (var contexto = new EscuelaBd())
            {
                var validar = (contexto.sp_Login(correo_usuario, password_usuario)).ToList();

                if (validar.Count != 0)
                {
                    Session["login"] = correo_usuario;
                    FormsAuthentication.SetAuthCookie(Session["login"].ToString(), true);
                    return Redirect("~/Home/Index");
                }

                else
                {
                    ViewBag.Message = "Error";
                    return View("index");
                }
            }
        }

        public ActionResult LogOut()
        {
            try
            {

                Session["login"] = null;
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                return Redirect("~/Login/index");

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}