using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    public class MiestasRepo
	{
        public static List<Miestas> List()
        {
            var miestas = new List<Miestas>();

            string query = $@"SELECT * FROM `Miestas` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                miestas.Add(new Miestas
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                });
            }
            return miestas;
        }

        public static Miestas Find(int id)
        {
            var miestas = new Miestas();

            var query = $@"SELECT * FROM `Miestas` WHERE id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                miestas.Id = Convert.ToInt32(item["id"]);
                miestas.Pavadinimas = Convert.ToString(item["pavadinimas"]);
            }
            return miestas;
        }

        public static void Update(Miestas miestas)
        {
            var query =
                $@"UPDATE `Miestas` 
                SET 
                    pavadinimas=?pavadinimas 
                WHERE 
                    id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = miestas.Pavadinimas;
                    args.Add("?id", MySqlDbType.Int32).Value = miestas.Id;
                });
        }

        public static void Delete(int id)
        {
            var query =
                $@"DELETE FROM `Miestas` WHERE id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });
        }

        public static void Insert(Miestas miestas)
        {
            var query =
                $@"INSERT INTO `Miestas` (
                    pavadinimas
                ) VALUES (
                    ?pavadinimas
                )";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = miestas.Pavadinimas;
                });
        }

    }
}