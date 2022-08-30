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
    public class LytisRepo
	{
        public static List<Lytis> List()
        {
            var lytis = new List<Lytis>();

            string query = $@"SELECT * FROM `Lytis` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                lytis.Add(new Lytis
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                });
            }
            return lytis;
        }

        public static Lytis Find(int id)
        {
            var lytis = new Lytis();

            var query = $@"SELECT * FROM `Lytis` WHERE id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                lytis.Id = Convert.ToInt32(item["id"]);
                lytis.Pavadinimas = Convert.ToString(item["pavadinimas"]);
            }
            return lytis;
        }

        public static void Update(Lytis lytis)
        {
            var query =
                $@"UPDATE `Lytis` 
                SET 
                    pavadinimas=?pavadinimas 
                WHERE 
                    id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = lytis.Pavadinimas;
                    args.Add("?id", MySqlDbType.Int32).Value = lytis.Id;
                });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `Lytis` WHERE id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });
        }

        public static void Insert(Lytis lytis)
        {
            var query =
                $@"INSERT INTO `Lytis` 
                (
                    pavadinimas
                )
                VALUES
                (
                    ?pavadinimas
                )";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = lytis.Pavadinimas;
                });
        }

    }
}