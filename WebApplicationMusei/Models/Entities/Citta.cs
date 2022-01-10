using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMusei.Models.Entities
{
    public class Citta
    {
        public int Id { get; set; }
        public int NazioneId { get; set; }
        public string Nome { get; set; }
    }
}
