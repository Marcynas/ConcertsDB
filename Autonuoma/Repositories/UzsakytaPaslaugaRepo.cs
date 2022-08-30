using System.Data;
using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to 'UzsakytosPaslaugos' entity.
	/// </summary>
	public class UzsakytaPaslaugaRepo
	{
		public static List<SutartisEditVM.UzsakytaPaslaugaM> List(int sutartisId)
		{
			var paslaugos = new List<SutartisEditVM.UzsakytaPaslaugaM>();

			var query =
				$@"SELECT *
				FROM `{Config.TblPrefix}uzsakytos_paslaugos`
				WHERE fk_sutartis = ?sutartisId
				ORDER BY fk_paslauga ASC, fk_kaina_galioja_nuo ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?sutartisId", MySqlDbType.Int32).Value = sutartisId;
				});

			var inListId = 0;

			foreach( DataRow item in dt )
			{
				paslaugos.Add(new SutartisEditVM.UzsakytaPaslaugaM
				{
					InListId = inListId,

					Paslauga =
						//we use JSON here to make serialization/deserializaton of composite key more convenient
						JsonConvert.SerializeObject(new {
							FkPaslauga = Convert.ToInt32(item["fk_paslauga"]),
							GaliojaNuo = Convert.ToDateTime(item["fk_kaina_galioja_nuo"])
						}),

					Kiekis = Convert.ToInt32(item["kiekis"]),
					Kaina = Convert.ToDecimal(item["kaina"])
				});

				//advance in list ID for next entry
				inListId += 1;
			}

			return paslaugos;
		}

		public static void Insert(int sutartisId, SutartisEditVM.UzsakytaPaslaugaM up)
		{
			//deserialize 'Paslauga' foreign keys from 'UzsakytaPaslauga' view model key
			var fks =
				JsonConvert.DeserializeAnonymousType(
					up.Paslauga,
					//this creates object of correct shape that is filled in by the JSON deserializer
					new {
						FkPaslauga = 1,
						GaliojaNuo = DateTime.Now
					}
				);

			//
			var query =
				$@"INSERT INTO `{Config.TblPrefix}uzsakytos_paslaugos`
					(
						fk_sutartis,
						fk_kaina_galioja_nuo,
						fk_paslauga,
						kiekis,
						kaina
					)
					VALUES(
						?fk_sutartis,
						?galioja_nuo,
						?fk_paslauga,
						?kiekis,
						?kaina
					)";

			Sql.Insert(query, args => {
				args.Add("?fk_sutartis", MySqlDbType.Int32).Value = sutartisId;
				args.Add("?galioja_nuo", MySqlDbType.Date).Value = fks.GaliojaNuo;
				args.Add("?fk_paslauga", MySqlDbType.Int32).Value = fks.FkPaslauga;
				args.Add("?kaina", MySqlDbType.Decimal).Value = up.Kaina;
				args.Add("?kiekis", MySqlDbType.Int32).Value = up.Kiekis;
			});
		}

		public static void DeleteForSutartis(int sutartis)
		{
			var query =
				$@"DELETE FROM a
				USING `{Config.TblPrefix}uzsakytos_paslaugos` as a
				WHERE a.fk_sutartis=?fkid";

			Sql.Delete(query, args => {
				args.Add("?fkid", MySqlDbType.Int32).Value = sutartis;
			});
		}
	}
}