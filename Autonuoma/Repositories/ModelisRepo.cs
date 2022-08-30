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
	public class ModelisRepo
	{
		public static List<ModelisListVM> List()
		{
			var result = new List<ModelisListVM>();

			var query =
				$@"SELECT
					md.id,
					md.pavadinimas,
					mark.pavadinimas AS marke
				FROM
					`{Config.TblPrefix}modeliai` md
					LEFT JOIN `{Config.TblPrefix}markes` mark ON mark.id=md.fk_marke
				ORDER BY mark.pavadinimas ASC, md.id ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new ModelisListVM
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Marke = Convert.ToString(item["marke"])
				});
			}

			return result;
		}

		public static List<Modelis> ListForMarke(int markeId)
		{
			var result = new List<Modelis>();

			var query = $@"SELECT * FROM `{Config.TblPrefix}modeliai` WHERE fk_marke=?markeId ORDER BY id ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?markeId", MySqlDbType.Int32).Value = markeId;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new Modelis
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					FkMarke = Convert.ToInt32(item["fk_marke"])
				});
			}

			return result;
		}

		public static ModelisEditVM Find(int id)
		{
			var mevm = new ModelisEditVM();

			var query = $@"SELECT * FROM `{Config.TblPrefix}modeliai` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mevm.Model.Id = Convert.ToInt32(item["id"]);
				mevm.Model.Pavadinimas = Convert.ToString(item["pavadinimas"]);
				mevm.Model.FkMarke = Convert.ToInt32(item["fk_marke"]);
			}

			return mevm;
		}

		public static ModelisListVM FindForDeletion(int id)
		{
			var mlvm = new ModelisListVM();

			var query =
				$@"SELECT
					md.id,
					md.pavadinimas,
					mark.pavadinimas AS marke
				FROM
					`{Config.TblPrefix}modeliai` md
					LEFT JOIN `{Config.TblPrefix}markes` mark ON mark.id=md.fk_marke
				WHERE
					md.id = ?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mlvm.Id = Convert.ToInt32(item["id"]);
				mlvm.Pavadinimas = Convert.ToString(item["pavadinimas"]);
				mlvm.Marke = Convert.ToString(item["marke"]);
			}

			return mlvm;
		}

		public static void Update(ModelisEditVM modelisEvm)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}modeliai`
				SET
					pavadinimas=?pavadinimas,
					fk_marke=?marke
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = modelisEvm.Model.Pavadinimas;
				args.Add("?marke", MySqlDbType.VarChar).Value = modelisEvm.Model.FkMarke;
				args.Add("?id", MySqlDbType.VarChar).Value = modelisEvm.Model.Id;
			});
		}

		public static void Insert(ModelisEditVM modelisEvm)
		{
			var query =
				$@"INSERT INTO `{Config.TblPrefix}modeliai`
				(
					pavadinimas,
					fk_marke
				)
				VALUES(
					?pavadinimas,
					?marke
				)";

			Sql.Insert(query, args => {
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = modelisEvm.Model.Pavadinimas;
				args.Add("?marke", MySqlDbType.VarChar).Value = modelisEvm.Model.FkMarke;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}modeliai` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}