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
    public class DarbuotojasKRepo
	{
        public static List<DarbuotojasKListVM> List()
        {
            var result = new List<DarbuotojasKListVM>();

            var query =
                $@"SELECT
					md.id,
					md.dirbaNuo,
                    md.dirbaIki,
                    mad.pavadinimas AS Role,
					mark.vardas AS vardas,
                    mark.pavarde AS pavarde
				FROM
					`DARBUOTOJAS` md
				LEFT JOIN `ASMUO` 
                    mark ON mark.id=md.fk_ASMUOid
                LEFT JOIN `Role`
                    mad ON mad.id=md.Darbuotojo_role
				ORDER BY mark.vardas ASC, md.id ASC";

            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                result.Add(new DarbuotojasKListVM
                {
                    Id = Convert.ToInt32(item["id"]),
                    DirbaNuo = Convert.ToDateTime(item["dirbaNuo"]),
                    DirbaIki = Convert.ToDateTime(item["dirbaIki"]),
                    DarbuotojoRole = Convert.ToString(item["Role"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    FkASMUOid = Convert.ToString(item["vardas"])
                });
            }

            return result;
        }

        public static List<DarbuotojasK> ListForAsmuo(int asmuoId)
        {
            var result = new List<DarbuotojasK>();

            var query = $@"SELECT * FROM `Darbuotojas` WHERE fk_ASMUOid=?asmuoId ORDER BY id ASC";

            var dt =
                Sql.Query(query, args => {
                    args.Add("?asmuoId", MySqlDbType.Int32).Value = asmuoId;
                });

            foreach (DataRow item in dt)
            {
                result.Add(new DarbuotojasK
                {
                    Id = Convert.ToInt32(item["id"]),
                    DirbaNuo = Convert.ToDateTime(item["dirbaNuo"]),
                    DirbaIki = Convert.ToDateTime(item["dirbaIki"]),
                    FkASMUOid = Convert.ToInt32(item["fk_ASMUOid"])
                });
            }

            return result;
        }

        public static DarbuotojasKEditVM Find(int id)
		{
			var mevm = new DarbuotojasKEditVM();

            var query = $@"SELECT * FROM `Darbuotojas` WHERE id=?id";

            var dt = Sql.Query(query, args => {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });

            foreach (DataRow item in dt)
            {
                mevm.Model.Id = Convert.ToInt32(item["id"]);
                mevm.Model.DirbaNuo = Convert.ToDateTime(item["dirbaNuo"]);
                mevm.Model.DirbaIki = Convert.ToDateTime(item["dirbaIki"]);
                mevm.Model.DarbuotojoRole = Convert.ToInt32(item["Darbuotojo_role"]);
                mevm.Model.FkASMUOid = Convert.ToInt32(item["fk_ASMUOid"]);

            }

            return mevm;
		}

        public static DarbuotojasKListVM FindForDeletion(int id)
		{
            var mlvm = new DarbuotojasKListVM();

            var query =
				$@"SELECT
					md.id,
					md.dirbaNuo,
                    md.dirbaIki,
					mark.vardas AS vardas
				FROM
					`DARBUOTOJAS` md
					LEFT JOIN `ASMUO` mark ON mark.id=md.fk_ASMUOid
				WHERE
					md.id = ?id";
            
            var dt = Sql.Query(query, args => {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });

            foreach (DataRow item in dt)
            {
                mlvm.Id = Convert.ToInt32(item["id"]);
                mlvm.DirbaNuo = Convert.ToDateTime(item["dirbaNuo"]);
                mlvm.DirbaIki = Convert.ToDateTime(item["dirbaIki"]);
                mlvm.FkASMUOid = Convert.ToString(item["vardas"]);
            }

            return mlvm;

        }

        public static void Update(DarbuotojasKEditVM darbuotojasEvm)
        {
            var query = $@"UPDATE `Darbuotojas` 
            SET
                dirbaNuo = ?dirbaNuo,
                dirbaIki = ?dirbaIki,
                Darbuotojo_role = ?Darbuotojo_role,
                fk_ASMUOid = ?fk_ASMUOid
            WHERE
                id = ?id";

            Sql.Update(query, args => {
                args.Add("?dirbaNuo", MySqlDbType.Date).Value = darbuotojasEvm.Model.DirbaNuo;
                args.Add("?dirbaIki", MySqlDbType.Date).Value = darbuotojasEvm.Model.DirbaIki;
                args.Add("?Darbuotojo_role", MySqlDbType.Int32).Value = darbuotojasEvm.Model.DarbuotojoRole;
                args.Add("?fk_ASMUOid", MySqlDbType.Int32).Value = darbuotojasEvm.Model.FkASMUOid;
                args.Add("?id", MySqlDbType.Int32).Value = darbuotojasEvm.Model.Id;
            });
        }

        public static void Insert(DarbuotojasKEditVM darbuotojasEvm)
		{
			var query =
				$@"INSERT INTO `darbuotojas` (
                dirbaNuo,
                dirbaIki,
                Darbuotojo_role,
                fk_ASMUOid
                
                ) VALUES (
                
                ?dirbaNuo,
                ?dirbaIki,
                ?Darbuotojo_role,
                ?fk_ASMUOid
                
                )";

            Sql.Insert(query, args => {
                args.Add("?dirbaNuo", MySqlDbType.Date).Value = darbuotojasEvm.Model.DirbaNuo;
                args.Add("?dirbaIki", MySqlDbType.Date).Value = darbuotojasEvm.Model.DirbaIki;
                args.Add("?Darbuotojo_role", MySqlDbType.Int32).Value = darbuotojasEvm.Model.DarbuotojoRole;
                args.Add("?fk_ASMUOid", MySqlDbType.Int32).Value = darbuotojasEvm.Model.FkASMUOid;
            });
		}

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `Darbuotojas` WHERE id=?id";

            Sql.Delete(query, args => {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}