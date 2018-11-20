using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIM.Models.Repository;
using PIM.Models;
using PIM.Controllers.Repository;
using System.Data;

namespace PIM.Controllers
{
    public class ChamadoController : Controller
    {
        private IChamadoRepositorio _repositorio;

        public ChamadoController() :this(new ChamadoRepositorio())
        {
        }

        public ChamadoController(IChamadoRepositorio repositorio)
        {
            ViewBag.Title = "Chamados";
            _repositorio = repositorio;
        }

        public ActionResult Index()
        {
            var chamado = _repositorio.GetChamado();
            return View(chamado);
        }
    }
}