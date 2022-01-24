using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMusei.Models.Entities
{
    public class Citta
    {
        public int Id { get; set; }

        [Display(Name = "Nazione")]
        public int NazioneId { get; set; }
        public Nazione Nazione { get; set; }

        public string Nome { get; set; }
    }
}
