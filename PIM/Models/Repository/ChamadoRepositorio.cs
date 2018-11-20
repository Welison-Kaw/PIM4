﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIM.DAL;
using PIM.Controllers.Repository;
using PIM.Models.Objects;

namespace PIM.Models.Repository
{
    public class ChamadoRepositorio : IChamadoRepositorio
    {
        private DALDataContext dal_DataContext;

        public ChamadoRepositorio()
        {
            dal_DataContext = new DALDataContext();
        }

        public IEnumerable<Chamado> GetChamado()
        {
            IList<Chamado> chamadoLista = new List<Chamado>();

            var consulta = from a in dal_DataContext.CHAMADOs
                           join b in dal_DataContext.DEPARTAMENTOs on a.DEPARTAMENTO equals b.ID
                           join c in dal_DataContext.GRAU_URGENCIAs on a.GRAU_URGENCIA equals c.ID
                           join d in dal_DataContext.CLIENTEs on a.CLIENTE equals d.ID
                           join e in dal_DataContext.FUNCIONARIOs on a.FUNCIONARIO equals e.ID
                           select new
                           {
                               ID = a.ID,
                               TITULO = a.TITULO,
                               DESCRICAO = a.DESCRICAO,
                               CONCLUSAO = a.CONCLUSAO,

                               DEPARTAMENTOID = b.ID,
                               DEPARTAMENTONOME = b.NOME,
                               GRAUURGENCIAID = c.ID,
                               GRAUURGENCIANOME = c.NOME,
                               CLIENTEID = d.ID,
                               CLIENTENOME = d.NOME,
                               FUNCIONARIOID = e.ID,
                               FUNCIONARIONOME = e.NOME
                           };

            try
            {
                var chamado = consulta.ToList();
                foreach (var chamadoDados in chamado)
                {
                    chamadoLista.Add(new Chamado()
                    {
                        id = chamadoDados.ID,
                        Titulo = chamadoDados.TITULO,
                        Descricao = chamadoDados.DESCRICAO,
                        Conclusao = chamadoDados.CONCLUSAO,

                        Departamento = new Departamento() { id = chamadoDados.DEPARTAMENTOID, Nome = chamadoDados.DEPARTAMENTONOME },
                        GrauUrgencia = new GrauUrgencia() { id = chamadoDados.GRAUURGENCIAID, Nome = chamadoDados.GRAUURGENCIANOME },
                        Cliente = new Cliente() { id = chamadoDados.CLIENTEID, Nome = chamadoDados.CLIENTENOME},
                        Funcionario = new Funcionario() { id = chamadoDados.FUNCIONARIOID, Nome = chamadoDados.FUNCIONARIONOME}
                    });
                }
                return chamadoLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Chamado GetChamadoPorID(int chamadoID)
        {
            return null;
        }

        public void InserirChamado(Chamado _chamado)
        {
            //
        }

        public void DeletarChamado(int chamadoID)
        {
            try
            {
                CHAMADO chamado = dal_DataContext.CHAMADOs.Where(c => c.ID == chamadoID).SingleOrDefault();
                dal_DataContext.CHAMADOs.DeleteOnSubmit(chamado);
                dal_DataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarChamado(Chamado _chamado)
        {
            //
        }
    }
}