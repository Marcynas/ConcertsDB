using System.Data;
using MySql.Data.MySqlClient;

using LateContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.LateContractsReport;
using ContractsReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ContractsReport;
using ServicesReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ServicesReport;
using IslaiduReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.IslaiduReport;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
	/// <summary>
	/// Database operations related to reports.
	/// </summary>
	public class AtaskaitaRepo
	{

		public static List<IslaiduReport.Islaidos> GetIslaidosOrdered(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = new List<IslaiduReport.Islaidos>();

			var query =
				$@"
				SELECT
					kon.pavadinimas,
                    mies.pavadinimas AS miestas,
					SUM(pasi.kaina) AS kaina,
					SUM(pasi.sumoketa) AS sumoketa,
                    COUNT(pasi.fk_KONCERTASid) AS AtlkKiek
				FROM
					`Pasirodymas` pasi,
					`Koncertas` kon
                INNER JOIN Miestas mies ON mies.id = kon.miestas
				WHERE
					kon.id = pasi.fk_KONCERTASid AND
                    kon.pradzia >= IFNULL(?nuo, kon.pradzia)	AND
                    kon.pabaiga <= IFNULL(?iki, kon.pabaiga)
				GROUP BY
					kon.id, kon.pavadinimas 
				ORDER BY `kon`.`pavadinimas` ASC
                
				";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
				});

			foreach (DataRow item in dt)
			{
				result.Add(new IslaiduReport.Islaidos
				{
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					NumatytaSuma = Convert.ToInt32(item["kaina"]),
					Sumoketa = Convert.ToDecimal(item["sumoketa"]),
					Atlikejai = Convert.ToInt32(item["AtlkKiek"]),
					Miestas = Convert.ToString(item["miestas"])
				});
			}

			return result;
		}

		public static IslaiduReport.Report GetTotalIslaidos(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = new IslaiduReport.Report();

			var query =
				$@"SELECT
					SUM(pasi.kaina) AS kaina,
					SUM(pasi.sumoketa) AS sumoketa,
					COUNT(pasi.fk_ATLIKEJASid) as atlikejai
				FROM
					`Pasirodymas` pasi,
					`Koncertas` kon
				WHERE
					kon.id = pasi.fk_KONCERTASid AND
                    kon.pradzia >= IFNULL(?nuo, kon.pradzia)	AND
                    kon.pabaiga <= IFNULL(?iki, kon.pabaiga)";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
				});

			foreach( DataRow item in dt )
			{
				result.BendraSuma = Convert.ToInt32(item["sumoketa"] == System.DBNull.Value ? 0 : item["sumoketa"]);
				result.NoretaIsleisti = Convert.ToInt32(item["kaina"] == System.DBNull.Value ? 0 : item["kaina"]);
				result.BendraiAtlikejai = Convert.ToInt32(item["atlikejai"] == System.DBNull.Value ? 0 : item["atlikejai"]);
			}

			return result;
		}

		public static List<ServicesReport.Paslauga> GetServicesOrdered(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = new List<ServicesReport.Paslauga>();

			var query =
				$@"SELECT
					pasl.id,
					pasl.pavadinimas,
					SUM(up.kiekis) AS kiekis,
					SUM(up.kiekis*up.kaina) AS suma
				FROM
					`{Config.TblPrefix}paslaugos` pasl,
					`{Config.TblPrefix}uzsakytos_paslaugos` up,
					`{Config.TblPrefix}sutartys` sut
				WHERE
					pasl.id = up.fk_paslauga
					AND up.fk_sutartis = sut.nr
					AND sut.sutarties_data >= IFNULL(?nuo, sut.sutarties_data)
					AND sut.sutarties_data <= IFNULL(?iki, sut.sutarties_data)
				GROUP BY
					pasl.id, pasl.pavadinimas
				ORDER BY
					suma DESC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
				});

			foreach (DataRow item in dt)
			{
				result.Add(new ServicesReport.Paslauga
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Kiekis = Convert.ToInt32(item["kiekis"]),
					Suma = Convert.ToDecimal(item["suma"])
				});
			}

			return result;
		}

		public static ServicesReport.Report GetTotalServicesOrdered(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = new ServicesReport.Report();

			var query =
				$@"SELECT
					SUM(up.kiekis) AS kiekis,
					SUM(up.kiekis*up.kaina) AS suma
				FROM
					`{Config.TblPrefix}paslaugos` pasl,
					`{Config.TblPrefix}uzsakytos_paslaugos` up,
					`{Config.TblPrefix}sutartys` sut
				WHERE
					pasl.id = up.fk_paslauga
					AND up.fk_sutartis = sut.nr
					AND sut.sutarties_data >= IFNULL(?nuo, sut.sutarties_data)
					AND sut.sutarties_data <= IFNULL(?iki, sut.sutarties_data)";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
				});

			foreach( DataRow item in dt )
			{
				result.VisoUzsakyta = Convert.ToInt32(item["kiekis"] == System.DBNull.Value ? 0 : item["kiekis"]);
				result.BendraSuma = Convert.ToDecimal(item["suma"] == System.DBNull.Value ? 0 : item["suma"]);
			}

			return result;
		}

		public static List<ContractsReport.Sutartis> GetContracts(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = new List<ContractsReport.Sutartis>();

			var query =
				$@"SELECT
					sut.nr,
					sut.sutarties_data,
					kln.vardas,
					kln.pavarde,
					kln.asmens_kodas,
					sut.kaina,
					IFNULL(SUM(up.kaina*up.kiekis), 0) paslaugu_kaina,
					bs1.bendra_suma,
					bs2.bendra_suma bendra_suma_paslaugu
				FROM
					`{Config.TblPrefix}sutartys` sut
					INNER JOIN `{Config.TblPrefix}klientai` kln ON kln.asmens_kodas = sut.fk_klientas
					LEFT JOIN `{Config.TblPrefix}uzsakytos_paslaugos` up ON up.fk_sutartis = sut.nr
					LEFT JOIN
						(
							SELECT
								kln1.asmens_kodas,
								sum(sut1.kaina) as bendra_suma
							FROM `{Config.TblPrefix}sutartys` sut1, `{Config.TblPrefix}klientai` kln1
							WHERE
								kln1.asmens_kodas=sut1.fk_klientas
								AND sut1.sutarties_data >= IFNULL(?nuo, sut1.sutarties_data)
								AND sut1.sutarties_data <= IFNULL(?iki, sut1.sutarties_data)
								GROUP BY kln1.asmens_kodas
						) AS bs1
						ON bs1.asmens_kodas = kln.asmens_kodas
					LEFT JOIN
						(
							SELECT
								kln2.asmens_kodas,
								IFNULL(SUM(up2.kiekis*up2.kaina), 0) as bendra_suma
							FROM
								`{Config.TblPrefix}sutartys` sut2
								INNER JOIN `{Config.TblPrefix}klientai` kln2 ON kln2.asmens_kodas = sut2.fk_klientas
								LEFT JOIN `{Config.TblPrefix}uzsakytos_paslaugos` up2 ON up2.fk_sutartis = sut2.nr
							WHERE
								sut2.sutarties_data >= IFNULL(?nuo, sut2.sutarties_data)
								AND sut2.sutarties_data <= IFNULL(?iki, sut2.sutarties_data)
							GROUP BY kln2.asmens_kodas
						) AS bs2
						ON bs2.asmens_kodas = kln.asmens_kodas
				WHERE
					sut.sutarties_data >= IFNULL(?nuo, sut.sutarties_data)
					AND sut.sutarties_data <= IFNULL(?iki, sut.sutarties_data)
				GROUP BY 
					sut.nr, kln.asmens_kodas
				ORDER BY 
					kln.pavarde ASC";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new ContractsReport.Sutartis
				{
					Nr = Convert.ToInt32(item["nr"]),
					SutartiesData = Convert.ToDateTime(item["sutarties_data"]),
					AsmensKodas = Convert.ToString(item["asmens_kodas"]),
					Vardas = Convert.ToString(item["vardas"]),
					Pavarde = Convert.ToString(item["pavarde"]),
					Kaina = Convert.ToDecimal(item["kaina"]),
					PaslauguKaina = Convert.ToDecimal(item["paslaugu_kaina"]),
					BendraSuma = Convert.ToDecimal(item["bendra_suma"]),
					BendraSumaPaslaug = Convert.ToDecimal(item["bendra_suma_paslaugu"])
				});
			}

			return result;
		}

		public static List<LateContractsReport.Sutartis> GetLateReturnContracts(DateTime? dateFrom, DateTime? dateTo)
		{
			var result = new List<LateContractsReport.Sutartis>();

			var query =
				$@"SELECT
					sut.nr,
					sut.sutarties_data,
					CONCAT(kln.vardas, ' ',kln.pavarde) as klientas,
					sut.planuojama_grazinimo_data_laikas,
					IF(
						IFNULL(sut.faktine_grazinimo_data_laikas,'0000-00-00') LIKE '0000%',
						'negražinta',
						sut.faktine_grazinimo_data_laikas
					) as grazinimo_data
				FROM `{Config.TblPrefix}sutartys` sut, `{Config.TblPrefix}klientai` kln
				WHERE
					kln.asmens_kodas = sut.fk_klientas
					AND (
						DATEDIFF(sut.faktine_grazinimo_data_laikas, sut.planuojama_grazinimo_data_laikas) >= 1
						OR IFNULL(sut.faktine_grazinimo_data_laikas, '0000-00-00') like '0000%'
						AND DATEDIFF(NOW(), sut.planuojama_grazinimo_data_laikas) >=1
					)
					AND sut.sutarties_data >= IFNULL(?nuo, sut.sutarties_data)
					AND sut.sutarties_data <= IFNULL(?iki, sut.sutarties_data)";

			var dt =
				Sql.Query(query, args => {
					args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
					args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
				});

			foreach( DataRow item in dt )
			{
				result.Add(new LateContractsReport.Sutartis
				{
					Nr = Convert.ToInt32(item["nr"]),
					SutartiesData = Convert.ToDateTime(item["sutarties_data"]),
					Klientas = Convert.ToString(item["klientas"]),
					PlanuojamaGrData = Convert.ToDateTime(item["planuojama_grazinimo_data_laikas"]),
					FaktineGrData = Convert.ToString(item["grazinimo_data"])
				});
			}

			return result;
		}
	}
}