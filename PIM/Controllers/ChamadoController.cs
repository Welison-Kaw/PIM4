using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIM.Models.Repository;
using PIM.Models.Objects;
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

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Problema ao deletar dados";
            }
            Chamado chamado = _repositorio.GetChamadoPorID(id);
            return View(chamado);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repositorio.DeletarChamado(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}