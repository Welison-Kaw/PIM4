using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PIM.DAL;

namespace PIM.Models
{
    public class ChamadoRepositorio: IChamadoRepositorio
    {
        private ChamadosDALDataContext chamados_DataContext;

        public ChamadoRepositorio ()
        {
            chamados_DataContext = new ChamadosDALDataContext();
        }

        public IEnumerable<Chamado> GetChamado()
        {
            IList<Chamado> chamadosLista = new List<Chamado>();
            var consulta = from q in chamados_DataContext.CHAMADOs
                           select q;

            try
            {
                var chamado = consulta.ToList();
                foreach (var chamadosDados in chamado)
                {
                    chamadosLista.Add(new Chamado()
                    {
                        id = chamadosDados.ID,
                        Departamento = chamadosDados.DEPARTAMENTO,
                        GrauUrgencia = chamadosDados.GRAU_URGENCIA,
                        Andar = chamadosDados.ANDAR,
                        Equipmaento = chamadosDados.EQUIPAMENTO,
                        Descricao = chamadosDados.DESCRICAO,
                        Cliente = chamadosDados.CLIENTE,
                        Funcionario = (int)chamadosDados.FUNCIONARIO
                    });
                }
                return chamadosLista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Chamado GetChamadoPorID(int Chamado)
        {
            return null;
        }

        public void InserirChamado(Chamado _chamado)
        {
            //
        }

        public void DeletarChamado(int _chamado)
        {
            //
        }

        public void AtualizarChamado(Chamado _chamado)
        {
            //
        }
    }
}