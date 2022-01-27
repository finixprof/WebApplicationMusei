using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Models.Views
{
    public class CittaViewModel : Citta
    {

        public List<Nazione> Nazioni { get; set; }

        public CittaViewModel() { }

        public CittaViewModel(Citta citta, List<Nazione> nazioni) 
        {
            Id = citta.Id;
            Nome = citta.Nome;
            NazioneId = citta.NazioneId;
            Nazioni = nazioni;
        }
    }
}
