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
	/// Database operations for 'PavaruDeze' entity.
	/// </summary>
	public class PavaruDezeRepo
	{
		public static List<PavaruDeze> List()
		{
			List<PavaruDeze> pavaruDezes = new List<PavaruDeze>();

			string sqlquery = @"SELECT a.id, a.name FROM "+Config.TblPrefix+"pavaru_dezes a";
			var dt = Sql.Query(sqlquery);
			
			foreach( DataRow item in dt )
			{
				pavaruDezes.Add(new PavaruDeze
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["name"])
				});
			}

			return pavaruDezes;
		}
	}
}