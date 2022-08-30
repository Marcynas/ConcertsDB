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
    public class IrenginysRepo
	{
        public static List<IrenginysListVM> List()
        {
            var result = new List<IrenginysListVM>();

            var query =
                $@"SELECT
					md.id,
					mark.pavadinimas,
                    md.turimas_kiekis,
					mark.tipas AS Tipas
				FROM
					`Irenginys` md
					LEFT JOIN `IRENGINIO_TIPAS` mark ON mark.id=md.fk_IRENGINIO_TIPASid
				ORDER BY mark.id ASC, md.id ASC";

            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                result.Add(new IrenginysListVM
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                    TurimasKiekis = Convert.ToInt32(item["turimas_kiekis"]),
                    IrenginioTipas = Convert.ToString(item["tipas"])
                });
            }

            return result;
        }

        public static List<Irenginys> ListForIrenginio_Tipas(int tipasId)
        {
            var result = new List<Irenginys>();

            var query = $@"SELECT * FROM `irenginys` WHERE fk_IRENGINIO_TIPASid=?tipasId ORDER BY id ASC";

            var dt =
                Sql.Query(query, args => {
                    args.Add("?tipasId", MySqlDbType.Int32).Value = tipasId;
                });

            foreach (DataRow item in dt)
            {
                result.Add(new Irenginys
                {
                    Id = Convert.ToInt32(item["id"]),
                    TurimasKiekis = Convert.ToInt32(item["turimas_kiekis"]),
                    FkIrenginioTipas = Convert.ToInt32(item["fk_IRENGINIO_TIPASid"])
                });
            }

            return result;
        }

        public static IrenginysEditVM Find(int id)
		{
			var mevm = new IrenginysEditVM();

            var query = $@"SELECT * FROM `Irenginys` WHERE id=?id";

            var dt = Sql.Query(query, args => {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });

            foreach (DataRow item in dt)
            {
                mevm.Model.Id = Convert.ToInt32(item["id"]);
                mevm.Model.TurimasKiekis = Convert.ToInt32(item["turimas_kiekis"]);
                mevm.Model.FkIrenginioTipas = Convert.ToInt32(item["fk_IRENGINIO_TIPASid"]);
            }

            return mevm;
		}

        public static IrenginysListVM FindForDeletion(int id)
		{
            var mlvm = new IrenginysListVM();

            var query =
				$@"SELECT
					md.id,
					mark.pavadinimas,
                    md.turimas_kiekis,
					mark.tipas AS Tipas
				FROM
					`Irenginys` md
					LEFT JOIN `IRENGINIO_TIPAS` mark ON mark.id=md.fk_IRENGINIO_TIPASid
                WHERE
					md.id = ?id";
            
            var dt = Sql.Query(query, args => {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });

            foreach (DataRow item in dt)
            {
                mlvm.Id = Convert.ToInt32(item["id"]);
                mlvm.Pavadinimas = Convert.ToString(item["pavadinimas"]);
                mlvm.TurimasKiekis = Convert.ToInt32(item["turimas_kiekis"]);
                mlvm.IrenginioTipas = Convert.ToString(item["tipas"]);
            }

            return mlvm;

        }

        public static void Update(IrenginysEditVM irenginysEvm)
        {
            var query = $@"UPDATE `IRENGINYS` SET
                turimas_kiekis=?turimas_kiekis,
                fk_IRENGINIO_TIPASid=?fk_IRENGINIO_TIPASid
                WHERE id=?id";

            Sql.Update(query, args => {
                args.Add("?turimas_kiekis", MySqlDbType.Int32).Value = irenginysEvm.Model.TurimasKiekis;
                args.Add("?fk_IRENGINIO_TIPASid", MySqlDbType.Int32).Value = irenginysEvm.Model.FkIrenginioTipas;
                args.Add("?id", MySqlDbType.Int32).Value = irenginysEvm.Model.Id;
            });
        }

        public static void Insert(IrenginysEditVM irenginysEvm)
		{
			var query =
				$@"INSERT INTO `IRENGINYS` (
                    turimas_kiekis,
                    fk_IRENGINIO_TIPASid
                ) VALUES (
                    ?turimas_kiekis,
                    ?fk_IRENGINIO_TIPASid
                )";

            Sql.Insert(query, args => {
                args.Add("?turimas_kiekis", MySqlDbType.Int32).Value = irenginysEvm.Model.TurimasKiekis;
                args.Add("?fk_IRENGINIO_TIPASid", MySqlDbType.Int32).Value = irenginysEvm.Model.FkIrenginioTipas;
            });
		}

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `IRENGINYS` WHERE id=?id";

            Sql.Delete(query, args => {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}