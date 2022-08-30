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
	public class IrenginioTipasRepo
	{
		public static List<IrenginioTipasListVM> List()
		{
			var result = new List<IrenginioTipasListVM>();

			var query =
				$@"SELECT
					md.id,
                    md.pavadinimas,
					mark.pavadinimas AS Tipas
				FROM
					`Irenginio_tipas` md
					LEFT JOIN `tipas` mark ON mark.id=md.tipas
				ORDER BY mark.pavadinimas ASC, md.id ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new IrenginioTipasListVM
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Tipas = Convert.ToString(item["Tipas"])
				});
			}

			return result;
		}

		public static List<IrenginioTipas> ListForMarke(int tipasId)
		{
			var result = new List<IrenginioTipas>();

			var query = $@"SELECT * FROM `Irenginio_tipas` WHERE tipas=?tipasId ORDER BY id ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?tipasId", MySqlDbType.Int32).Value = tipasId;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new IrenginioTipas
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					FkTipas = Convert.ToInt32(item["tipas"]),
				});
			}

			return result;
		}

		public static IrenginioTipasEditVM Find(int id)
		{
			var mevm = new IrenginioTipasEditVM();

			var query = $@"SELECT * FROM `Irenginio_tipas` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mevm.Model.Id = Convert.ToInt32(item["id"]);
				mevm.Model.pavadinimas = Convert.ToString(item["pavadinimas"]);
				mevm.Model.fk_TIPASid = Convert.ToInt32(item["tipas"]);
			}

			return mevm;
		}

		public static IrenginioTipasListVM FindForDeletion(int id)
		{
			var mlvm = new IrenginioTipasListVM();

			var query =
				$@"SELECT
					md.id,
                    md.pavadinimas,
					mark.pavadinimas AS Tipas
				FROM
					`Irenginio_tipas` md
					LEFT JOIN `tipas` mark ON mark.id=md.tipas
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
				mlvm.Tipas = Convert.ToString(item["tipas"]);
			}

			return mlvm;
		}

		public static void Update(IrenginioTipasEditVM modelisEvm)
		{
			var query =
				$@"UPDATE `Irenginio_tipas`
				SET
					pavadinimas = ?pavadinimas,
					tipas=?fk_TIPASid
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?fk_TIPASid", MySqlDbType.VarChar).Value = modelisEvm.Model.fk_TIPASid;
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = modelisEvm.Model.pavadinimas;
				args.Add("?id", MySqlDbType.VarChar).Value = modelisEvm.Model.Id;
			});
		}

		public static void Insert(IrenginioTipasEditVM modelisEvm)
		{
			var query =
				$@"INSERT INTO `Irenginio_tipas`
				(
					tipas
					,pavadinimas
				)
				VALUES(
					?tipas
					,?pavadinimas
				)";

			Sql.Insert(query, args => {
				args.Add("?tipas", MySqlDbType.VarChar).Value = modelisEvm.Model.fk_TIPASid;
				args.Add("?pavadinimas", MySqlDbType.VarChar).Value = modelisEvm.Model.pavadinimas;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `Irenginio_tipas` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}