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
	/// Database operations related to 'Aikstele' entity.
	/// </summary>
	public class AikstelesRepo
	{
		public static List<Aikstele> List()
		{
			var aiksteles = new List<Aikstele>();

			var query = $@"SELECT * FROM `{Config.TblPrefix}aiksteles` ORDER BY id ASC";
            var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				aiksteles.Add(new Aikstele
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["pavadinimas"]),
					Adresas = Convert.ToString(item["adresas"]),
					FkMiestas = Convert.ToInt32(item["fk_miestas"])
				});
			}
			return aiksteles;
		}
	}
}