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
        [Required]
        public int NazioneId { get; set; }
        public Nazione Nazione { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
