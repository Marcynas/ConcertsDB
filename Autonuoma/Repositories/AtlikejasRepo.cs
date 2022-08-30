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
	public class AtlikejasRepo
	{
		public static List<AtlikejasListVM> List()
		{
			var result = new List<AtlikejasListVM>();

			var query =
				$@"SELECT
					md.id,
					md.vardas,
                    md.pavarde,
                    md.zanras,
                    md.kontaktai,
					mark.pavadinimas AS Lytis
				FROM
					`atlikejas` md
					LEFT JOIN `lytis` mark ON mark.id=md.lytis
				ORDER BY mark.pavadinimas ASC, md.id ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new AtlikejasListVM
				{
					Id = Convert.ToInt32(item["id"]),
					Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    Zanras = Convert.ToString(item["zanras"]),
                    Kontaktai = Convert.ToString(item["kontaktai"]),
                    Lytis = Convert.ToString(item["Lytis"])
				});
			}

			return result;
		}

		public static List<Atlikejas> ListForMarke(int lytisID)
		{
			var result = new List<Atlikejas>();

			var query = $@"SELECT * FROM `Atlikejas` WHERE lytis=?lytisID ORDER BY id ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?lytisID", MySqlDbType.Int32).Value = lytisID;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new Atlikejas
				{
                    Id = Convert.ToInt32(item["id"]),
                    Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    Zanras = Convert.ToString(item["zanras"]),
                    Kontaktai = Convert.ToString(item["kontaktai"]),
                    FkLytis = Convert.ToInt32(item["lytis"])
                });
			}

			return result;
		}

		public static AtlikejasEditVM Find(int id)
		{
			var mevm = new AtlikejasEditVM();

			var query = $@"SELECT * FROM `Atlikejas` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				mevm.Model.Id = Convert.ToInt32(item["id"]);
				mevm.Model.Vardas = Convert.ToString(item["vardas"]);
                mevm.Model.Pavarde = Convert.ToString(item["pavarde"]);
                mevm.Model.Zanras = Convert.ToString(item["zanras"]);
                mevm.Model.Kontaktai = Convert.ToString(item["kontaktai"]);
                mevm.Model.FkLytis = Convert.ToInt32(item["lytis"]);
			}

			return mevm;
		}

		public static AtlikejasListVM FindForDeletion(int id)
		{
			var mlvm = new AtlikejasListVM();

			var query =
				$@"SELECT
					md.id,
					md.vardas,
                    md.pavarde,
                    md.zanras,
                    md.kontaktai,
					mark.pavadinimas AS lytis
				FROM
					`atlikejas` md
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
                mlvm.Zanras = Convert.ToString(item["zanras"]);
                mlvm.Kontaktai = Convert.ToString(item["kontaktai"]);
                mlvm.Lytis = Convert.ToString(item["lytis"]);
			}

			return mlvm;
		}

		public static void Update(AtlikejasEditVM modelisEvm)
		{
			var query =
				$@"UPDATE `Atlikejas` SET
                    vardas = ?vardas,
                    pavarde = ?pavarde,
                    zanras = ?zanras,
                    kontaktai = ?kontaktai,
                    lytis = ?fkLytis
                WHERE
                    id = ?id";
				

			Sql.Update(query, args => {
				args.Add("?vardas", MySqlDbType.VarChar).Value = modelisEvm.Model.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = modelisEvm.Model.Pavarde;
                args.Add("?zanras", MySqlDbType.VarChar).Value = modelisEvm.Model.Zanras;
                args.Add("?kontaktai", MySqlDbType.VarChar).Value = modelisEvm.Model.Kontaktai;
                args.Add("?fkLytis", MySqlDbType.Int32).Value = modelisEvm.Model.FkLytis;
                args.Add("?id", MySqlDbType.Int32).Value = modelisEvm.Model.Id;
            });
		}

		public static void Insert(AtlikejasEditVM modelisEvm)
		{
			var query =
				$@"INSERT INTO `Atlikejas`
				(
					vardas,
                    pavarde,
                    zanras,
                    kontaktai,
                    lytis
                )
				VALUES(
                    ?vardas,
                    ?pavarde,
                    ?zanras,
                    ?kontaktai,
                    ?lytis
                )";

			Sql.Insert(query, args => {
                args.Add("?vardas", MySqlDbType.VarChar).Value = modelisEvm.Model.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = modelisEvm.Model.Pavarde;
                args.Add("?zanras", MySqlDbType.VarChar).Value = modelisEvm.Model.Zanras;
                args.Add("?kontaktai", MySqlDbType.VarChar).Value = modelisEvm.Model.Kontaktai;
                args.Add("?lytis", MySqlDbType.Int32).Value = modelisEvm.Model.FkLytis;
                });
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `Atlikejas` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}