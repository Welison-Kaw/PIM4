using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIM.Models.Objects;

namespace PIM.Controllers
{
    public class AcessoController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            return RedirectToAction("Index", "Setor");
        }

        // GET: Acesso
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}