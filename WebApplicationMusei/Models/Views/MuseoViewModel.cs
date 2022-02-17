using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Models.Views
{
    public class MuseoViewModel : Museo
    {

        public List<Citta> ListaCitta { get; set; }

        public MuseoViewModel() { }

        public MuseoViewModel(Museo museo, List<Citta> listaCitta) 
        {
            Id = museo.Id;
            Denominazione = museo.Denominazione;
            CittaId = museo.CittaId;
            ListaCitta = listaCitta;
        }
    }
}
