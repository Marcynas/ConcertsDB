using MySql.Data.MySqlClient;
using System.Data;

using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
    /// Database operations related to 'Sutartis' entity.
    /// </summary>
	public class SutartisRepo
	{
		public static List<SutartisListVM> List()
		{
			var result = new List<SutartisListVM>();
			
			var query = 
				$@"SELECT 
					s.nr, 
					s.sutarties_data as data, 
					CONCAT(d.vardas,' ', d.pavarde) as darbuotojas, 
					CONCAT(n.vardas,' ',n.pavarde) as nuomininkas, 
					b.name as busena
				FROM 
					`{Config.TblPrefix}sutartys` s
					LEFT JOIN `{Config.TblPrefix}darbuotojai` d ON s.fk_darbuotojas=d.tabelio_nr
					LEFT JOIN `{Config.TblPrefix}klientai` n ON s.fk_klientas=n.asmens_kodas
					LEFT JOIN `{Config.TblPrefix}sutarties_busenos` b ON s.busena=b.id				
				ORDER BY s.nr DESC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				result.Add(new SutartisListVM {
					Nr = Convert.ToInt32(item["nr"]),
					Darbuotojas = Convert.ToString(item["darbuotojas"]),
					Nuomininkas = Convert.ToString(item["nuomininkas"]),
					Data = Convert.ToDateTime(item["data"]),
					Busena = Convert.ToString(item["busena"])
				});
			}

			return result;
		}

		public static SutartisEditVM Find(int nr)
		{
			var result = new SutartisEditVM();
			
			string qlquery = $@"SELECT * FROM `{Config.TblPrefix}sutartys` WHERE nr=?nr";
			var dt = 
				Sql.Query(qlquery, args => {
                    args.Add("?nr", MySqlDbType.Int32).Value = nr;
                });

			var sut = result.Sutartis;

			foreach( DataRow item in dt )
			{
				sut.Nr = Convert.ToInt32(item["nr"]);
				sut.SutartiesData = Convert.ToDateTime(item["sutarties_data"]);
				sut.NuomosDataLaikas = Convert.ToDateTime(item["nuomos_data_laikas"]);
				sut.PlanuojamaGrDataLaikas = Convert.ToDateTime(item["planuojama_grazinimo_data_laikas"]);
				sut.FaktineGrDataLaikas = Sql.AllowNull(item["faktine_grazinimo_data_laikas"], it => (DateTime?)Convert.ToDateTime(it));
				sut.PradineRida = Convert.ToInt32(item["pradine_rida"]);
				sut.GalineRida = Sql.AllowNull(item["galine_rida"], it => (int?)Convert.ToInt32(it));
				sut.Kaina = Convert.ToDecimal(item["kaina"]);
				sut.DegaluKiekisPaimant = Convert.ToInt32(item["degalu_kiekis_paimant"]);
				sut.DegaluKiekisGrazinant = Sql.AllowNull(item["dagalu_kiekis_grazinus"], it => (int?)Convert.ToInt32(it));
				sut.Busena = Convert.ToInt32(item["busena"]);
				sut.FkKlientas = Convert.ToString(item["fk_klientas"]);
				sut.FkDarbuotojas = Convert.ToString(item["fk_darbuotojas"]);
				sut.FkAutomobilis = Convert.ToInt32(item["fk_automobilis"]);
				sut.FkGrazinimoVieta = Convert.ToInt32(item["fk_grazinimo_vieta"]);
				sut.FkPaemimoVieta = Convert.ToInt32(item["fk_paemimo_vieta"]);
			}

			return result;
		}

		public static void Update(SutartisEditVM evm)
		{
            var query = 
				$@"UPDATE `{Config.TblPrefix}sutartys`
				SET
					`sutarties_data` = ?sutdata,
					`nuomos_data_laikas` = ?nuomdata,
					`planuojama_grazinimo_data_laikas` = ?plgrlaikas,
					`faktine_grazinimo_data_laikas` = ?fkgrlaikas,
					`pradine_rida` = ?prrida,
					`galine_rida` = ?glrida,
					`kaina` = ?kaina,
					`degalu_kiekis_paimant` = ?dkiekispa,
					`dagalu_kiekis_grazinus` = ?dkiekisgr,
					`busena` = ?busena,
					`fk_klientas` = ?klientas,
					`fk_darbuotojas` = ?darbuotojas,
					`fk_automobilis` = ?automobilis,
					`fk_grazinimo_vieta` = ?grvieta,
					`fk_paemimo_vieta` = ?pavieta
				WHERE nr=?nr";

            Sql.Update(query, args => {
				args.Add("?sutdata", MySqlDbType.Date).Value = evm.Sutartis.SutartiesData;
				args.Add("?nuomdata", MySqlDbType.DateTime).Value = evm.Sutartis.NuomosDataLaikas;
				args.Add("?plgrlaikas", MySqlDbType.DateTime).Value = evm.Sutartis.PlanuojamaGrDataLaikas;
				args.Add("?fkgrlaikas", MySqlDbType.DateTime).Value = evm.Sutartis.FaktineGrDataLaikas;
				args.Add("?prrida", MySqlDbType.Int32).Value = evm.Sutartis.PradineRida;
				args.Add("?glrida", MySqlDbType.Int32).Value = evm.Sutartis.GalineRida;
				args.Add("?kaina", MySqlDbType.Decimal).Value = evm.Sutartis.Kaina;
				args.Add("?dkiekispa", MySqlDbType.Int32).Value = evm.Sutartis.DegaluKiekisPaimant;
				args.Add("?dkiekisgr", MySqlDbType.Int32).Value = evm.Sutartis.DegaluKiekisGrazinant;
				args.Add("?busena", MySqlDbType.Int32).Value = evm.Sutartis.Busena;
				args.Add("?darbuotojas", MySqlDbType.VarChar).Value = evm.Sutartis.FkDarbuotojas;
				args.Add("?klientas", MySqlDbType.VarChar).Value = evm.Sutartis.FkKlientas;
				args.Add("?automobilis", MySqlDbType.Int32).Value = evm.Sutartis.FkAutomobilis;
				args.Add("?grvieta", MySqlDbType.Int32).Value = evm.Sutartis.FkGrazinimoVieta;
				args.Add("?pavieta", MySqlDbType.Int32).Value = evm.Sutartis.FkPaemimoVieta;

                args.Add("?nr", MySqlDbType.Int32).Value = evm.Sutartis.Nr;
            });
		}

		public static int Insert(SutartisEditVM evm)
		{			
			var query = 
				$@"INSERT INTO `{Config.TblPrefix}sutartys` 
				(
					`sutarties_data`,
					`nuomos_data_laikas`,
					`planuojama_grazinimo_data_laikas`,
					`faktine_grazinimo_data_laikas`,
					`pradine_rida`,
					`galine_rida`,
					`kaina`,
					`degalu_kiekis_paimant`,
					`dagalu_kiekis_grazinus`,
					`busena`,
					`fk_klientas`,
					`fk_darbuotojas`,
					`fk_automobilis`,
					`fk_grazinimo_vieta`,
					`fk_paemimo_vieta`
				)
				VALUES(
					?sutdata,
					?nuomdata,
					?plgrlaikas,
					?fkgrlaikas,
					?prrida,
					?glrida,
					?kaina,
					?dkiekispa,
					?dkiekisgr,
					?busena,
					?klientas,
					?darbuotojas,
					?automobilis,
					?grvieta,
					?pavieta
				)";

			var nr = 
				Sql.Insert(query, args => {
					args.Add("?sutdata", MySqlDbType.Date).Value = evm.Sutartis.SutartiesData;
					args.Add("?nuomdata", MySqlDbType.DateTime).Value = evm.Sutartis.NuomosDataLaikas;
					args.Add("?plgrlaikas", MySqlDbType.DateTime).Value = evm.Sutartis.PlanuojamaGrDataLaikas;
					args.Add("?fkgrlaikas", MySqlDbType.DateTime).Value = evm.Sutartis.FaktineGrDataLaikas;
					args.Add("?prrida", MySqlDbType.Int32).Value = evm.Sutartis.PradineRida;
					args.Add("?glrida", MySqlDbType.Int32).Value = evm.Sutartis.GalineRida;
					args.Add("?kaina", MySqlDbType.Decimal).Value = evm.Sutartis.Kaina;
					args.Add("?dkiekispa", MySqlDbType.Int32).Value = evm.Sutartis.DegaluKiekisPaimant;
					args.Add("?dkiekisgr", MySqlDbType.Int32).Value = evm.Sutartis.DegaluKiekisGrazinant;
					args.Add("?busena", MySqlDbType.Int32).Value = evm.Sutartis.Busena;
					args.Add("?darbuotojas", MySqlDbType.VarChar).Value = evm.Sutartis.FkDarbuotojas;
					args.Add("?klientas", MySqlDbType.VarChar).Value = evm.Sutartis.FkKlientas;
					args.Add("?automobilis", MySqlDbType.Int32).Value = evm.Sutartis.FkAutomobilis;
					args.Add("?grvieta", MySqlDbType.Int32).Value = evm.Sutartis.FkGrazinimoVieta;
					args.Add("?pavieta", MySqlDbType.Int32).Value = evm.Sutartis.FkPaemimoVieta;
				});

			return (int)nr;
		}

		public static void Delete(int nr)
		{			
			var query = $@"DELETE FROM `{Config.TblPrefix}sutartys` where nr=?nr";
			Sql.Delete(query, args => {
				args.Add("?nr", MySqlDbType.Int32).Value = nr;
			});
		}
	}
}