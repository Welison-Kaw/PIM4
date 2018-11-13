using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIM.Models
{
    public class Chamado
    {
        public int id { get; set; }
        public int Departamento { get; set; }
        public int GrauUrgencia { get; set; }
        public string Andar { get; set; }
        public string Equipmaento { get; set; }
        public string Descricao { get; set; }
        public int Cliente { get; set; }
        public int Funcionario { get; set; }
    }
}