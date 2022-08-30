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
	/// Database operations for 'Bagazas' entity.
	/// </summary>
	public class BagazasRepo
	{
		public static List<LagaminoTipas> List()
		{
			List<LagaminoTipas> bagazoTipai = new List<LagaminoTipas>();
			
			string sqlquery = @"SELECT a.id, a.name FROM "+Config.TblPrefix+"lagaminai a";
			var dt = Sql.Query(sqlquery);

			foreach( DataRow item in dt )
			{
				bagazoTipai.Add(new LagaminoTipas
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["name"])
				});
			}

			return bagazoTipai;
		}
	}
}