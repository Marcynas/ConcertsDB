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
	/// Database operations related to 'Automobilis' entity.
	/// </summary>
	public class AutomobiliaiRepo
	{
		public static List<AutoListVM> List()
		{
			var autombiliai = new List<AutoListVM>();

			var query =
				$@"SELECT
					a.id,
					a.valstybinis_nr,
					b.name AS busena,
					m.pavadinimas AS modelis,
					mm.pavadinimas AS marke
				FROM
					{Config.TblPrefix}automobiliai a
					LEFT JOIN `{Config.TblPrefix}auto_busenos` b ON b.id = a.busena
					LEFT JOIN `{Config.TblPrefix}modeliai` m ON m.id = a.fk_modelis
					LEFT JOIN `{Config.TblPrefix}markes` mm ON mm.id = m.fk_marke
				ORDER BY a.id ASC";

			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				autombiliai.Add(new AutoListVM
				{
					Id = Convert.ToInt32(item["id"]),
					ValstybinisNr = Convert.ToString(item["valstybinis_nr"]),
					Busena = Convert.ToString(item["busena"]),
					Modelis = Convert.ToString(item["modelis"]),
					Marke = Convert.ToString(item["marke"])
				});
			}

			return autombiliai;
		}

		public static AutoEditVM Find(int id)
		{
			var autoEvm = new AutoEditVM();

			var query =  $@"SELECT * FROM `{Config.TblPrefix}automobiliai` WHERE id=?id";

			var dt =
				Sql.Query(query, args => {
					args.Add("?id", MySqlDbType.Int32).Value = id;
				});

			foreach( DataRow item in dt )
			{
				autoEvm.Auto.Id = Convert.ToInt32(item["id"]);
				autoEvm.Auto.ValstybinisNr = Convert.ToString(item["valstybinis_nr"]);
				autoEvm.Auto.PagaminimoData = Convert.ToDateTime(item["pagaminimo_data"]);
				autoEvm.Auto.Rida = Convert.ToInt32(item["rida"]);
				autoEvm.Auto.Radijas = Convert.ToBoolean(item["radijas"]);
				autoEvm.Auto.Grotuvas = Convert.ToBoolean(item["grotuvas"]);
				autoEvm.Auto.Kondicionierius = Convert.ToBoolean(item["kondicionierius"]);
				autoEvm.Auto.VietuSkaicius = Convert.ToInt32(item["vietu_skaicius"]);
				autoEvm.Auto.RegistravimoData = Convert.ToDateTime(item["registravimo_data"]);
				autoEvm.Auto.Verte = Convert.ToDecimal(item["verte"]);
				autoEvm.Auto.PavaruDeze = Convert.ToInt32(item["pavaru_deze"]);
				autoEvm.Auto.DegaluTipas = Convert.ToInt32(item["degalu_tipas"]);
				autoEvm.Auto.Kebulas = Convert.ToInt32(item["kebulas"]);
				autoEvm.Auto.BagazoDydis = Convert.ToInt32(item["bagazo_dydis"]);
				autoEvm.Auto.Busena = Sql.AllowNull(item["busena"], it => (int?)Convert.ToInt32(it));
				autoEvm.Auto.FkModelis = Convert.ToInt32(item["fk_modelis"]);
			}

			return autoEvm;
		}

		public static void Insert(AutoEditVM autoEvm)
		{
			var query = 
				$@"INSERT INTO `{Config.TblPrefix}automobiliai`
				(
					`valstybinis_nr`,
					`pagaminimo_data`,
					`rida`,
					`radijas`,
					`grotuvas`,
					`kondicionierius`,
					`vietu_skaicius`,
					`registravimo_data`,
					`verte`,
					`pavaru_deze`,
					`degalu_tipas`,
					`kebulas`,
					`bagazo_dydis`,
					`busena`,
					`fk_modelis`
				)
				VALUES (
					?vlst_nr,
					?pag_data,
					?rida,
					?radijas,
					?grotuvas,
					?kond,
					?viet_sk,
					?reg_dt,
					?verte,
					?pav_deze,
					?dega_tip,
					?kebulas,
					?bagaz_tip,
					?busena,
					?fk_mod
				)";

			Sql.Insert(query, args => {
				args.Add("?vlst_nr", MySqlDbType.VarChar).Value = autoEvm.Auto.ValstybinisNr;
				args.Add("?pag_data", MySqlDbType.Date).Value = autoEvm.Auto.PagaminimoData?.ToString("yyyy-MM-dd");
				args.Add("?rida", MySqlDbType.Int32).Value = autoEvm.Auto.Rida;
				args.Add("?radijas", MySqlDbType.Int32).Value = (autoEvm.Auto.Radijas ? 1 : 0);
				args.Add("?grotuvas", MySqlDbType.Int32).Value = (autoEvm.Auto.Grotuvas ? 1 : 0);
				args.Add("?kond", MySqlDbType.Int32).Value = (autoEvm.Auto.Kondicionierius ? 1 : 0);
				args.Add("?viet_sk", MySqlDbType.Int32).Value = autoEvm.Auto.VietuSkaicius;
				args.Add("?reg_dt", MySqlDbType.Date).Value = autoEvm.Auto.RegistravimoData?.ToString("yyyy-MM-dd");
				args.Add("?verte", MySqlDbType.Decimal).Value = autoEvm.Auto.Verte;
				args.Add("?pav_deze", MySqlDbType.Int32).Value = autoEvm.Auto.PavaruDeze;
				args.Add("?dega_tip", MySqlDbType.Int32).Value = autoEvm.Auto.DegaluTipas;
				args.Add("?kebulas", MySqlDbType.Int32).Value = autoEvm.Auto.Kebulas;
				args.Add("?bagaz_tip", MySqlDbType.Int32).Value = autoEvm.Auto.BagazoDydis;
				args.Add("?busena", MySqlDbType.Int32).Value = autoEvm.Auto.Busena;
				args.Add("?fk_mod", MySqlDbType.Int32).Value = autoEvm.Auto.FkModelis;
			});
		}

		public static void Update(AutoEditVM autoEvm)
		{
			var query =
				$@"UPDATE `{Config.TblPrefix}automobiliai`
				SET
					`valstybinis_nr` = ?vlst_nr,
					`pagaminimo_data` = ?pag_data,
					`rida` = ?rida,
					`radijas` = ?radijas,
					`grotuvas` = ?grotuvas,
					`kondicionierius` = ?kond,
					`vietu_skaicius` = ?viet_sk,
					`registravimo_data` = ?reg_dt,
					`verte` = ?verte,
					`pavaru_deze` = ?pav_deze,
					`degalu_tipas` = ?dega_tip,
					`kebulas` = ?kebulas,
					`bagazo_dydis` = ?bagaz_tip,
					`busena` = ?busena,
					`fk_modelis` = ?fk_mod
				WHERE
					id=?id";

			Sql.Update(query, args => {
				args.Add("?vlst_nr", MySqlDbType.VarChar).Value = autoEvm.Auto.ValstybinisNr;
				args.Add("?pag_data", MySqlDbType.Date).Value = autoEvm.Auto.PagaminimoData?.ToString("yyyy-MM-dd");
				args.Add("?rida", MySqlDbType.Int32).Value = autoEvm.Auto.Rida;
				args.Add("?radijas", MySqlDbType.Int32).Value = (autoEvm.Auto.Radijas ? 1 : 0);
				args.Add("?grotuvas", MySqlDbType.Int32).Value = (autoEvm.Auto.Grotuvas ? 1 : 0);
				args.Add("?kond", MySqlDbType.Int32).Value = (autoEvm.Auto.Kondicionierius ? 1 : 0);
				args.Add("?viet_sk", MySqlDbType.Int32).Value = autoEvm.Auto.VietuSkaicius;
				args.Add("?reg_dt", MySqlDbType.Date).Value = autoEvm.Auto.RegistravimoData?.ToString("yyyy-MM-dd");
				args.Add("?verte", MySqlDbType.Decimal).Value = autoEvm.Auto.Verte;
				args.Add("?pav_deze", MySqlDbType.Int32).Value = autoEvm.Auto.PavaruDeze;
				args.Add("?dega_tip", MySqlDbType.Int32).Value = autoEvm.Auto.DegaluTipas;
				args.Add("?kebulas", MySqlDbType.Int32).Value = autoEvm.Auto.Kebulas;
				args.Add("?bagaz_tip", MySqlDbType.Int32).Value = autoEvm.Auto.BagazoDydis;
				args.Add("?busena", MySqlDbType.Int32).Value = autoEvm.Auto.Busena;
				args.Add("?fk_mod", MySqlDbType.Int32).Value = autoEvm.Auto.FkModelis;

				args.Add("?id", MySqlDbType.Int32).Value = autoEvm.Auto.Id;
			});
		}

		public static void Delete(int id)
		{
			var query = $@"DELETE FROM `{Config.TblPrefix}automobiliai` WHERE id=?id";
			Sql.Delete(query, args => {
				args.Add("?id", MySqlDbType.Int32).Value = id;
			});
		}
	}
}