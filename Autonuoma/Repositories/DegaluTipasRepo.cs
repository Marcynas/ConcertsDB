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
	/// Database operations for 'DegaluTipas' entity.
	/// </summary>
	public class DegaluTipasRepo
	{
		public static List<DegaluTipas> List()
		{
			List<DegaluTipas> degaluTipai = new List<DegaluTipas>();

			string sqlquery = @"SELECT a.id, a.name FROM "+Config.TblPrefix+"degalu_tipai a";
			var dt = Sql.Query(sqlquery);

			foreach( DataRow item in dt )
			{
				degaluTipai.Add(new DegaluTipas
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["name"])
				});
			}

			return degaluTipai;
		}
	}
}