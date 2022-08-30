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
	/// Database operations related to 'Darbuotojas' entity.
	/// </summary>
	public class DarbuotojasRepo
	{
		public static List<Darbuotojas> List()
		{
			var darbuotojai = new List<Darbuotojas>();
			
			string query = $@"SELECT * FROM `{Config.TblPrefix}darbuotojai` ORDER BY tabelio_nr ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				darbuotojai.Add(new Darbuotojas
				{
					Tabelis = Convert.ToString(item["tabelio_nr"]),
					Vardas = Convert.ToString(item["vardas"]),
					Pavarde = Convert.ToString(item["pavarde"])
				});
			}

			return darbuotojai;
		}

		public static Darbuotojas Find(string tabnr)
		{
			var query = $@"SELECT * FROM `{Config.TblPrefix}darbuotojai` WHERE tabelio_nr=?tab";

			var dt = 
				Sql.Query(query, args => {
					args.Add("?tab", MySqlDbType.VarChar).Value = tabnr;
				});

			if( dt.Count > 0 )
			{
				var darbuotojas = new Darbuotojas();

				foreach( DataRow item in dt )
				{
					darbuotojas.Tabelis = Convert.ToString(item["tabelio_nr"]);
					darbuotojas.Vardas = Convert.ToString(item["vardas"]);
					darbuotojas.Pavarde = Convert.ToString(item["pavarde"]);
				}

				return darbuotojas;
			}

			return null;
		}

		public static void Update(Darbuotojas darb)
		{						
			var query = 
				$@"UPDATE `{Config.TblPrefix}darbuotojai`
				SET 
					vardas=?vardas, 
					pavarde=?pavarde 
				WHERE 
					tabelio_nr=?tab";

			Sql.Update(query, args => {
				args.Add("?vardas", MySqlDbType.VarChar).Value = darb.Vardas;
				args.Add("?pavarde", MySqlDbType.VarChar).Value = darb.Pavarde;
				args.Add("?tab", MySqlDbType.VarChar).Value = darb.Tabelis;
			});				
		}

		public static void Insert(Darbuotojas darb)
		{							
			var query = 
				$@"INSERT INTO `{Config.TblPrefix}darbuotojai`
				(
					tabelio_nr,
					vardas,
					pavarde
				)
				VALUES(
					?tabelio_nr,
					?vardas,
					?pavarde
				)";

			Sql.Insert(query, args => {
				args.Add("?vardas", MySqlDbType.VarChar).Value = darb.Vardas;
				args.Add("?pavarde", MySqlDbType.VarChar).Value = darb.Pavarde;
				args.Add("?tabelio_nr", MySqlDbType.VarChar).Value = darb.Tabelis;
			});				
		}

		public static void Delete(string id)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}darbuotojai` WHERE tabelio_nr=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.VarChar).Value = id;
			});			
		}
	}
}