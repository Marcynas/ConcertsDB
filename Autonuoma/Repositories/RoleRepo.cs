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
    public class RoleRepo
    {

        public static List<Role> List()
        {
            var roles = new List<Role>();

            string query = $@"SELECT * FROM `Role` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                roles.Add(new Role
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                });
            }

            return roles;
        }

        public static Role Find(int id)
        {
            var role = new Role();

            var query = $@"SELECT * FROM `Role` WHERE id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                role.Id = Convert.ToInt32(item["id"]);
                role.Pavadinimas = Convert.ToString(item["pavadinimas"]);
            }
            return role;
        }

        public static void Update(Role role)
        {
            var query =
                $@"UPDATE `Role` 
                SET 
                    pavadinimas=?pavadinimas 
                WHERE 
                    id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = role.Pavadinimas;
                    args.Add("?id", MySqlDbType.Int32).Value = role.Id;
                });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `Role` WHERE id=?id";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });
        }

        //insert
        public static void Insert(Role role)
        {
            var query =
                $@"INSERT INTO `Role` (
                    pavadinimas
                ) VALUES (
                    ?pavadinimas
                )";
            var dt =
                Sql.Query(query, args => {
                    args.Add("?pavadinimas", MySqlDbType.VarChar).Value = role.Pavadinimas;
                });
        }

    }
}