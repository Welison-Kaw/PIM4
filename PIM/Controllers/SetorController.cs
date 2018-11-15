﻿using System;
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
    public class SetorController : Controller
    {
        private ISetorRepositorio _repositorio;

        public SetorController() :this(new SetorRepositorio())
        {
        }

        public SetorController(ISetorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ActionResult Lista()
        {
            var setor = _repositorio.GetSetor();
            return View(setor);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Problema ao deletar dados";
            }
            Setor setor = _repositorio.GetSetorPorID(id);
            return View(setor);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //ClienteModel cliente = _repositorio.GetClientePorID(id);
                _repositorio.DeletarSetor(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary { { "id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("Lista");
        }
    }
}