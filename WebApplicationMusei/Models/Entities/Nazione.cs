using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMusei.Models.Entities
{
    public class Nazione
    {
        public int Id { get; set; }

        [Display(Name = "Nome nazione")]
        public string Nome { get; set; }

    }
}
