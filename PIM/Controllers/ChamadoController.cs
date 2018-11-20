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

        public ActionResult Edit(int id)
        {
            Chamado model = _repositorio.GetChamadoPorID(id);

            /*List<SelectListItem> items = new List<SelectListItem>();

            ISetorRepositorio _setorRepo = new SetorRepositorio();
            foreach (var SR in _setorRepo.GetSetor())
            {
                items.Add(new SelectListItem { Text = SR.Nome, Value = SR.id.ToString(), Selected = (SR.id == model.Setor.id) ? true : false });
            }
            ViewBag.SetorID = items;*/

            List<SelectListItem> grauItems = new List<SelectListItem>();
            List<SelectListItem> departamentoItems = new List<SelectListItem>();
            List<SelectListItem> clienteItems = new List<SelectListItem>();
            List<SelectListItem> funcionarioItems = new List<SelectListItem>();

            grauItems.Add(new SelectListItem { Text = "Muito Baixo", Value = "1", Selected = (1 == model.GrauUrgencia.id) ? true : false });
            grauItems.Add(new SelectListItem { Text = "Baixo", Value = "2", Selected = (2 == model.GrauUrgencia.id) ? true : false });
            grauItems.Add(new SelectListItem { Text = "Médio", Value = "3", Selected = (3 == model.GrauUrgencia.id) ? true : false });
            grauItems.Add(new SelectListItem { Text = "Alto", Value = "4", Selected = (4 == model.GrauUrgencia.id) ? true : false });
            grauItems.Add(new SelectListItem { Text = "Muito Alto", Value = "5", Selected = (5 == model.GrauUrgencia.id) ? true : false });

            IDepartamentoRepositorio _depRepo = new DepartamentoRepositorio();
            foreach (var DP in _depRepo.GetDepartamento())
            {
                departamentoItems.Add(new SelectListItem { Text = DP.Nome, Value = DP.id.ToString(), Selected = (DP.id == model.Departamento.id) ? true : false });
            }

            clienteItems.Add(new SelectListItem { Text = "Bruno", Value = "1", Selected = (1 == model.Cliente.id) ? true : false });
            clienteItems.Add(new SelectListItem { Text = "Erick", Value = "2", Selected = (2 == model.Cliente.id) ? true : false });

            funcionarioItems.Add(new SelectListItem { Text = "Adilanne", Value = "1", Selected = (1 == model.Funcionario.id) ? true : false });
            funcionarioItems.Add(new SelectListItem { Text = "Kelvin", Value = "2", Selected = (2 == model.Funcionario.id) ? true : false });
            funcionarioItems.Add(new SelectListItem { Text = "Welison", Value = "3", Selected = (3 == model.Funcionario.id) ? true : false });

            ViewBag.GrauUrgenciaID = grauItems;
            ViewBag.DepartamentoID = departamentoItems;
            ViewBag.ClienteID = clienteItems;
            ViewBag.FuncionarioID = funcionarioItems;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Chamado chamado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.AtualizarChamado(chamado);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Problemas ao salvar os dados...");
            }
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