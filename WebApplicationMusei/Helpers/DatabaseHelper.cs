using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Helpers
{
    public static class DatabaseHelper
    {
        private static List<Museo> musei = new List<Museo>
        {
            new Museo
            {
                Id = 1,
                CittaId = 1,
                Denominazione = "xyz"
            },
            new Museo
            {
                Id = 1,
                CittaId = 5,
                Denominazione = "Bla bla bla"
            },
        };

        private static List<Citta> citta = new List<Citta>
        {
            new Citta
            {
                Id = 1,
                NazioneId = 1,
                Nome = "Roma"
            },
            new Citta
            {
                Id = 2,
                NazioneId = 1,
                Nome = "Milano"
            },
            new Citta
            {
                Id = 3,
                NazioneId = 1,
                Nome = "Reggio Emilia"
            },
            new Citta
            {
                Id = 4,
                NazioneId = 2,
                Nome = "Barcellona"
            },
            new Citta
            {
                Id = 5,
                NazioneId = 2,
                Nome = "Madrid"
            },

        };

        private static List<Nazione> nazioni = new List<Nazione>
            {
                new Nazione
                {
                    Id = 1,
                    Nome = "Italia"
                },
                new Nazione
                {
                    Id = 2,
                    Nome = "Spagna"
                }
            };

        public static List<Museo> GetAllMuseo()
        {
            return musei;
        }

        public static Museo GetMuseoById(int id)
        {
            return musei.Where(t => t.Id == id).FirstOrDefault();
        }


        public static List<Nazione> GetAllNazione()
        {
            return nazioni;
        }

        public static Nazione GetNazioneById(int id)
        {
            return nazioni.Where(t => t.Id == id).FirstOrDefault();
        }

        public static List<Citta> GetAllCitta()
        {
            return citta;
        }

        public static Citta GetCittaById(int id)
        {
            return citta.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
