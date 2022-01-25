using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using WebApplicationMusei.Models.Entities;

namespace WebApplicationMusei.Helpers
{
    public static class DatabaseHelper
    {

        public static string ConnectionString { get; internal set; }

        public static List<Museo> GetAllMuseo()
        {
            var musei = new List<Museo>();
            using (var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM museo";
                musei = db.Query<Museo>(querySql).ToList();
            }
            return musei;
        }

        public static Museo GetMuseoById(int id)
        {
            var museo = new Museo();
            using (var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM museo WHERE id = @id";
                museo = db.Query<Museo>(querySql, new { id = id }).FirstOrDefault();
            }

            return museo;
        }


        public static List<Nazione> GetAllNazione()
        {
            var nazioni = new List<Nazione>();
            using (var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM nazione";
                nazioni = db.Query<Nazione>(querySql).ToList();
            }
            return nazioni;
        }

        public static Nazione SaveNazione(Nazione model)
        {
            if (model.Id == 0)
            {
                return InsertNazione(model);
            }
            else
            {
                return UpdateNazione(model);
            }
        }

        private static Nazione UpdateNazione(Nazione model)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var sqlQuery = "UPDATE nazione SET nome=@nome  WHERE id = @id";

                var affectedRows = db.Execute(sqlQuery, model);
                if (affectedRows == 1)
                    return model;
            }
            throw new Exception("Errore aggiornamento non completato");
        }

        private static Nazione InsertNazione(Nazione model)
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                var sqlQuery = "INSERT INTO nazione (nome) VALUES (@nome); " +
                        "SELECT LAST_INSERT_ID()";
                model.Id = db.Query<int>(sqlQuery, model).FirstOrDefault();
                if (model.Id > 0)
                    return model;
            }
            throw new Exception("Errore inserimento non completato");
        }

        public static Nazione GetNazioneById(int id)
        {
            var nazione = new Nazione();
            using (var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM nazione WHERE id = @id";
                nazione = db.Query<Nazione>(querySql, new { id = id }).FirstOrDefault();
            }

            return nazione;
        }

        internal static void SaveCitta(Citta model)
        {
            throw new NotImplementedException();
        }

        public static List<Citta> GetAllCitta()
        {
            var citta = new List<Citta>();
            using (var db = new MySqlConnection(ConnectionString))
            {
                var querySql = "SELECT * FROM citta AS c " +
                    "INNER JOIN nazione AS n ON c.NazioneId = n.Id";
                citta = db.Query<Citta,Nazione,Citta>(querySql,
                                (citta, nazione) =>
                                {
                                    citta.Nazione = nazione;
                                    return citta;
                                }
                                //,splitOn: "NazioneId"
                    ).ToList();
            }
            return citta;
        }

        public static Citta GetCittaById(int id)
        {
            var citta = new Citta();
            using (var db = new MySqlConnection(ConnectionString))
            {
                //var querySql = "SELECT * FROM citta WHERE id = @id";
                //citta = db.Query<Citta>(querySql, new { id = id }).FirstOrDefault();
                var querySql = "SELECT * FROM citta AS c " +
                    " INNER JOIN nazione AS n ON c.NazioneId = n.Id" +
                    "  WHERE c.id = @id";
                citta = db.Query<Citta, Nazione, Citta>(querySql,
                                (citta, nazione) =>
                                {
                                    citta.Nazione = nazione;
                                    return citta;
                                }
                                , new { id = id}
                                //,splitOn: "NazioneId"
                    ).FirstOrDefault();

            }

            return citta;
        }
    }
}
