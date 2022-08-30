using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'Paslauga' entity.
	/// </summary>
	public class PaslaugaRepo
	{
		public static List<Paslauga> List()
		{
			var paslaugos = new List<Paslauga>();

			string query = $@"SELECT * FROM `{Config.TblPrefix}paslaugos` ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				paslaugos.Add(new Paslauga
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Aprasymas = Convert.ToString(item["aprasymas"])
				});
			}

			return paslaugos;
		}

		public static Paslauga Find(int id)
		{
			var paslauga = new Paslauga();

			string query = 
				$@"SELECT 
					a.id,
					a.pavadinimas,
					a.aprasymas
				FROM `{Config.TblPrefix}paslaugos` a
				WHERE a.id=?id";

			var dt = 
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				paslauga.Id = Convert.ToInt32(item["id"]);
				paslauga.Pavadinimas = Convert.ToString(item["pavadinimas"]);
				paslauga.Aprasymas = Convert.ToString(item["aprasymas"]);
			}

			return paslauga;
		}

		public static void Update(Paslauga paslauga)
		{
			var query = 
				$@"UPDATE `{Config.TblPrefix}paslaugos` p 
				SET p.pavadinimas=?pavadinimas, p.aprasymas=?aprasymas 
				WHERE p.id=?id";

			Sql.Update(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = paslauga.Id;
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = paslauga.Pavadinimas;
				args.Add("?aprasymas", MySqlDbType.VarChar).Value = paslauga.Aprasymas;
			});
		}

		public static int Insert(Paslauga paslauga)
		{
			string query = 
				$@"INSERT INTO `{Config.TblPrefix}paslaugos`
				(pavadinimas,aprasymas)
				VALUES
				(?pavadinimas,?aprasymas)";

			var id =
				(int)Sql.Insert(query, args => {
					args.Add("?pavadinimas", MySqlDbType.VarChar).Value = paslauga.Pavadinimas;
					args.Add("?aprasymas", MySqlDbType.VarChar).Value = paslauga.Aprasymas;
				});

			return (int)id;
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}paslaugos` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}