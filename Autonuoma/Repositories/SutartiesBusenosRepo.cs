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
	/// Database operations related to 'SutartiesBusena' entity.
	/// </summary>
	public class SutartiesBusenosRepo
	{
		public static List<SutartiesBusena> List()
		{
			var busenos = new List<SutartiesBusena>();
			
			var query = $@"SELECT * FROM `{Config.TblPrefix}sutarties_busenos` ORDER BY id ASC";
			var dt = Sql.Query(query);

			foreach( DataRow item in dt )
			{
				busenos.Add(new SutartiesBusena
				{
					Id = Convert.ToInt32(item["id"]),
					Name = Convert.ToString(item["name"])
				});
			}
			return busenos;
		}
	}
}