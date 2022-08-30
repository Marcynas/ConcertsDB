using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Aikstele' entity.
	/// </summary>
	public class Aikstele
	{
		public int Id { get; set; }


		public string Pavadinimas { get; set; }


		public string Adresas { get; set; }
		
		
		public int FkMiestas { get; set; }
	}
}