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
	/// <summary>
	/// Database operations related to 'PaslaugosKaina' entity.
	/// </summary>
	public class PaslaugosKainaRepo
	{
		public static List<PaslaugosKainaVM> LoadForPaslauga(int id)
		{
			var result = new List<PaslaugosKainaVM>();

			var query =
				$@"SELECT
					pk.fk_paslauga,
					pk.galioja_nuo,
					pk.galioja_iki,
					pk.kaina,
					count(up.fk_sutartis) as kiekis
				FROM
					`{Config.TblPrefix}paslaugu_kainos` as pk
					LEFT JOIN `{Config.TblPrefix}uzsakytos_paslaugos` up
						ON up.fk_paslauga=pk.fk_paslauga AND up.fk_kaina_galioja_nuo=pk.galioja_nuo
				WHERE pk.fk_paslauga=?id
				GROUP BY
					pk.fk_paslauga,
					pk.galioja_nuo,
					pk.galioja_iki,
					pk.kaina
				ORDER BY pk.galioja_nuo DESC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			var inListId = 0;

			foreach( DataRow item in dt )
			{
				result.Add(new PaslaugosKainaVM
				{
					InListId = inListId,
					IsReadonly = Convert.ToInt32(item["kiekis"]) > 0,

					FkPaslauga = Convert.ToInt32(item["fk_paslauga"]),
					GaliojaNuo = Convert.ToDateTime(item["galioja_nuo"]),
					GaliojaIki = Sql.AllowNull(item["galioja_iki"], it => (DateTime?)Convert.ToDateTime(it)),
					Kaina = Convert.ToDecimal(item["kaina"])
				});

				inListId += 1;
			}

			return result;
		}

		public static void Delete(int paslaugaId, DateTime galiojaNuo)
		{
			var query = 
				$@"DELETE FROM `{Config.TblPrefix}paslaugu_kainos`
				WHERE 
					fk_paslauga=?paslaugaId AND galioja_nuo=?galiojaNuo";

			Sql.Delete(query, args => {
				args.Add("?paslaugaId", MySqlDbType.Int32).Value = paslaugaId;
				args.Add("?galiojaNuo", MySqlDbType.Date).Value = galiojaNuo;
			});
		}

		public static void Insert(PaslaugosKainaVM PaslaugosKainaVM)
		{
			string query = 
				$@"INSERT INTO `{Config.TblPrefix}paslaugu_kainos`
				(
					fk_paslauga,
					galioja_nuo,
					galioja_iki,
					kaina
				)
				VALUES(
					?fk_paslauga,
					?galioja_nuo,
					?galioja_iki,
					?kaina
				)";

			Sql.Insert(query, args => {
				args.Add("?fk_paslauga", MySqlDbType.Int32).Value = PaslaugosKainaVM.FkPaslauga;
				args.Add("?galioja_nuo", MySqlDbType.Date).Value = PaslaugosKainaVM.GaliojaNuo;
				args.Add("?galioja_iki", MySqlDbType.Date).Value = PaslaugosKainaVM.GaliojaIki;
				args.Add("?kaina", MySqlDbType.Decimal).Value = PaslaugosKainaVM.Kaina;
			});
		}

		public static void Update(PaslaugosKainaVM PaslaugosKainaVM)
		{
			string query = 
				$@"UPDATE `{Config.TblPrefix}paslaugu_kainos`
				SET
					galioja_iki = ?galioja_iki,
					kaina = ?kaina				
				WHERE 
					fk_paslauga = ?fk_paslauga AND galioja_nuo = ?galioja_nuo";

			Sql.Insert(query, args => {
				args.Add("?fk_paslauga", MySqlDbType.Int32).Value = PaslaugosKainaVM.FkPaslauga;
				args.Add("?galioja_nuo", MySqlDbType.Date).Value = PaslaugosKainaVM.GaliojaNuo;
				args.Add("?galioja_iki", MySqlDbType.Date).Value = PaslaugosKainaVM.GaliojaIki;
				args.Add("?kaina", MySqlDbType.Decimal).Value = PaslaugosKainaVM.Kaina;
			});
		}
	}
}