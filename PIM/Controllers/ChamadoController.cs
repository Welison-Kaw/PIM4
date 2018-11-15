using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIM.Models;

namespace PIM.Controllers
{
    public class ChamadoController : Controller
    {
        private IChamadoRepositorio _repositorio;

        // GET: Chamado
        public ActionResult Index()
        {
            var cliente = _repositorio.GetChamado();
            return View(cliente);
        }
    }
}