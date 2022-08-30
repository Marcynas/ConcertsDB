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
    public class TipasRepo
	{
        public static List<Tipas> List()
        {
            var tipai = new List<Tipas>();

            string query = $@"SELECT * FROM `Tipas` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                tipai.Add(new Tipas
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                });
            }
            return tipai;
        }

        public static Tipas Find(int id)
        {
            var tipas = new Tipas();

            var query = $@"SELECT * FROM `Tipas` WHERE id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                tipas.Id = Convert.ToInt32(item["id"]);
                tipas.Pavadinimas = Convert.ToString(item["pavadinimas"]);
            }
            return tipas;
        }

        public static void Update(Tipas tipas)
        {
            var query =
                $@"UPDATE `Tipas` 
                SET 
                    pavadinimas=?pavadinimas 
                WHERE 
                    id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = tipas.Pavadinimas;
                    args.Add("?id", MySqlDbType.Int32).Value = tipas.Id;
                });
        }

        public static void Delete(int id)
        {
            var query =
                $@"DELETE FROM `Tipas` 
                WHERE 
                    id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });
        }

        public static void Insert(Tipas tipas)
        {
            var query =
                $@"INSERT INTO `Tipas` 
                (
                    pavadinimas
                )
                VALUES
                (
                    ?pavadinimas
                )";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = tipas.Pavadinimas;
                });
        }
    }
}