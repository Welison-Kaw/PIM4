using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Models
{
    interface IChamadoRepositorio
    {
        IEnumerable<Chamado> GetChamado();
        Chamado GetChamadoPorID(int chamadoID);
        void InserirChamado(Chamado _chamado);
        void DeletarChamado(int chamadoID);
        void AtualizarChamado(Chamado _chamado);
    }
}
