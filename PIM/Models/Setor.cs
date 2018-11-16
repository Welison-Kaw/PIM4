using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PIM.Models
{
    public class Setor
    {
        [Display(Name = "Código")]
        public int id { get; set; }
        public string Nome { get; set; }
    }
}