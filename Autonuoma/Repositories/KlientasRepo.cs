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
	/// <summary>
	/// Database operations related to 'Klientas' entity.
	/// </summary>
	public class KlientasRepo
	{
		public static List<Klientas> List()
		{
			var klientai = new List<Klientas>();

			var query = $@"SELECT * FROM `{Config.TblPrefix}klientai` ORDER BY asmens_kodas ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				klientai.Add(new Klientas
				{
					AsmensKodas = Convert.ToString(item["asmens_kodas"]),
					Vardas = Convert.ToString(item["vardas"]),
					Pavarde = Convert.ToString(item["pavarde"]),
					GimimoData = Convert.ToDateTime(item["gimimo_data"]),
					Telefonas = Convert.ToString(item["telefonas"]),
					Epastas = Convert.ToString(item["epastas"])
				});
			}

			return klientai;
		}

		public static Klientas Find(string asmkodas)
		{
			var query = $@"SELECT * FROM `{Config.TblPrefix}klientai` WHERE asmens_kodas=?asmkodas";

			var dt =
				Sql.Query(query, args => {
					args.Add("?asmkodas", MySqlDbType.VarChar).Value = asmkodas;
				});

			if( dt.Count > 0 )
			{
				var klientas = new Klientas();

				foreach( DataRow item in dt )
				{
					klientas.AsmensKodas = Convert.ToString(item["asmens_kodas"]);
					klientas.Vardas = Convert.ToString(item["vardas"]);
					klientas.Pavarde = Convert.ToString(item["pavarde"]);
					klientas.GimimoData = Convert.ToDateTime(item["gimimo_data"]);
					klientas.Telefonas = Convert.ToString(item["telefonas"]);
					klientas.Epastas = Convert.ToString(item["epastas"]);
				}

				return klientas;
			}

			return null;
		}

		public static void Insert(Klientas klientas)
		{
			var query =
				$@"INSERT INTO `{Config.TblPrefix}klientai`
				(
					asmens_kodas,
					vardas,
					pavarde,
					gimimo_data,
					telefonas,
					epastas
				)
				VALUES(
					?asmkod,
					?vardas,
					?pavarde,
					?gimdata,
					?tel,
					?email
				)";

			Sql.Insert(query, args => {
				args.Add("?asmkod", MySqlDbType.VarChar).Value = klientas.AsmensKodas;
				args.Add("?vardas", MySqlDbType.VarChar).Value = klientas.Vardas;
				args.Add("?pavarde", MySqlDbType.VarChar).Value = klientas.Pavarde;
				args.Add("?gimdata", MySqlDbType.Date).Value = klientas.GimimoData;
				args.Add("?tel", MySqlDbType.VarChar).Value = klientas.Telefonas;
				args.Add("?email", MySqlDbType.VarChar).Value = klientas.Epastas;
			});
		}

		public static void Update(Klientas klientas)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}klientai`
				SET
					vardas=?vardas,
					pavarde=?pavarde,
					gimimo_data=?gimdata,
					telefonas=?tel,
					epastas=?email
				WHERE
					asmens_kodas=?asmkod";

			Sql.Update(query, args => {
				args.Add("?asmkod", MySqlDbType.VarChar).Value = klientas.AsmensKodas;
				args.Add("?vardas", MySqlDbType.VarChar).Value = klientas.Vardas;
				args.Add("?pavarde", MySqlDbType.VarChar).Value = klientas.Pavarde;
				args.Add("?gimdata", MySqlDbType.Date).Value = klientas.GimimoData;
				args.Add("?tel", MySqlDbType.VarChar).Value = klientas.Telefonas;
				args.Add("?email", MySqlDbType.VarChar).Value = klientas.Epastas;
			});
		}

		public static void Delete(string id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}klientai` WHERE asmens_kodas=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});
		}
	}
}