using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	public class AsmuoRepo
	{
		public static List<AsmuoListVM> List()
		{
			var result = new List<AsmuoListVM>();

			var query =
				$@"SELECT
					md.id,
					md.vardas,
                    md.pavarde,
					mark.pavadinimas AS Lytis
				FROM
					`asmuo` md
					LEFT JOIN `lytis` mark ON mark.id=md.lytis
				ORDER BY mark.pavadinimas ASC, md.id ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new AsmuoListVM
				{
					Id = Convert.ToInt32(item["id"]),
					Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    Lytis = Convert.ToString(item["Lytis"])
				});
			}

			return result;
		}

		public static List<Asmuo> ListForMarke(int lytisID)
		{
			var result = new List<Asmuo>();

			var query = $@"SELECT * FROM `Asmuo` WHERE lytis=?lytisID ORDER BY id ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?lytisID", MySqlDbType.Int32).Value = lytisID;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new Asmuo
				{
                    Id = Convert.ToInt32(item["id"]),
                    Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    FkLytis = Convert.ToInt32(item["lytis"])
                });
			}

			return result;
		}

		public static AsmuoEditVM Find(int id)
		{
			var mevm = new AsmuoEditVM();

			var query = $@"SELECT * FROM `Asmuo` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mevm.Model.Id = Convert.ToInt32(item["id"]);
				mevm.Model.Vardas = Convert.ToString(item["vardas"]);
                mevm.Model.Pavarde = Convert.ToString(item["pavarde"]);
                mevm.Model.FkLytis = Convert.ToInt32(item["lytis"]);
			}

			return mevm;
		}

		public static AsmuoListVM FindForDeletion(int id)
		{
			var mlvm = new AsmuoListVM();

			var query =
				$@"SELECT
					md.id,
					md.vardas,
                    md.pavarde,
					mark.pavadinimas AS lytis
				FROM
					`asmuo` md
					LEFT JOIN `lytis` mark ON mark.id=md.lytis
				WHERE
					md.id = ?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mlvm.Id = Convert.ToInt32(item["id"]);
				mlvm.Vardas = Convert.ToString(item["vardas"]);
                mlvm.Pavarde = Convert.ToString(item["pavarde"]);
                mlvm.Lytis = Convert.ToString(item["lytis"]);
			}

			return mlvm;
		}

		public static void Update(AsmuoEditVM modelisEvm)
		{
			var query =
				$@"UPDATE `Asmuo` SET
                    vardas = ?vardas,
                    pavarde = ?pavarde,
                    lytis = ?fkLytis
                WHERE
                    id = ?id";
				

			Sql.Update(query, args => {
				args.Add("?vardas", MySqlDbType.VarChar).Value = modelisEvm.Model.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = modelisEvm.Model.Pavarde;
                args.Add("?fkLytis", MySqlDbType.Int32).Value = modelisEvm.Model.FkLytis;
                args.Add("?id", MySqlDbType.Int32).Value = modelisEvm.Model.Id;
            });
		}

		public static void Insert(AsmuoEditVM modelisEvm)
		{
			var query =
				$@"INSERT INTO `Asmuo`
				(
					vardas,
                    pavarde,
                    lytis
                )
				VALUES(
                    ?vardas,
                    ?pavarde,
                    ?lytis
                )";

			Sql.Insert(query, args => {
                args.Add("?vardas", MySqlDbType.VarChar).Value = modelisEvm.Model.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = modelisEvm.Model.Pavarde;
                args.Add("?lytis", MySqlDbType.Int32).Value = modelisEvm.Model.FkLytis;
                });
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `Asmuo` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}