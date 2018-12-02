using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIM.DAL;
using PIM.Controllers.Repository;
using PIM.Models.Objects;

namespace PIM.Models.Repository
{
    public class ClienteRepositorio: IClienteRepositorio
    {
        private DALDataContext dal_DataContext;

        public ClienteRepositorio()
        {
            dal_DataContext = new DALDataContext();
        }

        public IEnumerable<Cliente> GetCliente()
        {
            IList<Cliente> clienteLista = new List<Cliente>();

            var consulta = from a in dal_DataContext.CLIENTEs
                           join b in dal_DataContext.DEPARTAMENTOs on a.DEPARTAMENTO equals b.ID
                           select new
                           {
                               ID = a.ID,
                               NOME = a.NOME,
                               EMAIL = a.EMAIL,
                               SENHA = a.SENHA,

                               DEPARTAMENTOID = b.ID,
                               DEPARTAMENTONOME = b.NOME,
                           };

            try
            {
                var cliente = consulta.ToList();
                foreach(var clienteDados in cliente)
                {
                    clienteLista.Add(new Cliente()
                    {
                        id = clienteDados.ID,
                        Nome = clienteDados.NOME,
                        Email = clienteDados.EMAIL,
                        Senha = clienteDados.SENHA,
                        DepartamentoID = clienteDados.DEPARTAMENTOID,
                        Departamento = new Departamento() { id = clienteDados.DEPARTAMENTOID, Nome = clienteDados.DEPARTAMENTONOME }
                    });
                }
                return clienteLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente GetClientePorID(int clienteID)
        {
            return null;
        }

        public void InserirCliente(Cliente _cliente)
        {
            //
        }

        public void DeletarCliente(int clienteID)
        {
            //
        }

        public void AtualizarCliente(Cliente _cliente)
        {
            //
        }

    }