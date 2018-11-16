using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIM.DAL;
using PIM.Controllers.Repository;

namespace PIM.Models.Repository
{
    public class SetorRepositorio: ISetorRepositorio
    {
        private SetorDALDataContext setor_DataContext;

        public SetorRepositorio()
        {
            setor_DataContext = new SetorDALDataContext();
        }

        public IEnumerable<Setor> GetSetor()
        {
            IList<Setor> setorLista = new List<Setor>();
            var consulta = from q in setor_DataContext.SETORs
                           select q;

            try
            {
                var setor = consulta.ToList();
                foreach (var setorDados in setor)
                {
                    setorLista.Add(new Setor()
                    {
                        id = setorDados.ID,
                        Nome = setorDados.NOME
                    });
                }
                return setorLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Setor GetSetorPorID(int setorID)
        {
            var query = from s in setor_DataContext.SETORs
                        where s.ID == setorID
                        select s;

            try
            {
                var setorDados = query.FirstOrDefault();
                var model = new Setor()
                {
                    id = setorDados.ID,
                    Nome = setorDados.NOME
                };
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InserirSetor(Setor setor)
        {
            try
            {
                var setorDados = new SETOR()
                {
                    //ID = setor.id,
                    NOME = setor.Nome
                };
                setor_DataContext.SETORs.InsertOnSubmit(setorDados);
                setor_DataContext.SubmitChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarSetor(int setorID)
        {
            try
            {
                SETOR setor = setor_DataContext.SETORs.Where(s => s.ID == setorID).SingleOrDefault();
                setor_DataContext.SETORs.DeleteOnSubmit(setor);
                setor_DataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarSetor(Setor setor)
        {
            try
            {
                SETOR setorDados = setor_DataContext.SETORs.Where(s => s.ID == setor.id).SingleOrDefault();
                setorDados.NOME = setor.Nome;
                setor_DataContext.SubmitChanges();
                /*Setor setordados = setor_DataContext.SETORs.Where(s => s.ID == setor.id).SingleOrDefault();
                clienteDados.nome = clienteModel.Nome;
                clienteDados.endereco = clienteModel.Endereco;
                clienteDados.telefone = clienteModel.Telefone;
                clienteDados.email = clienteModel.Email;
                clienteDados.observacao = clienteModel.Observacao;
                cliente_DataContext.SubmitChanges();*/
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}