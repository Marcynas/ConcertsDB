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
	/// Database operations for 'Kebulas' entity.
	/// </summary>
	public class KebulasRepo
	{
		public static List<KebuloTipas> List()
		{
			List<KebuloTipas> kebuloTipai = new List<KebuloTipas>();

			string sqlquery = @"SELECT a.id, a.name FROM "+Config.TblPrefix+"kebulu_tipai a";
			var dt = Sql.Query(sqlquery);

			foreach( DataRow item in dt )
			{
				kebuloTipai.Add(new KebuloTipas
				{
					Id = Convert.ToInt32(item["id"]),
					Pavadinimas = Convert.ToString(item["name"])
				});
			}

			return kebuloTipai;
		}
	}
}