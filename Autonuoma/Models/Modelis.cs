using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Modelis' entity.
	/// </summary>
	public class Modelis
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		public string Pavadinimas { get; set; }

		//Markė
		[DisplayName("Markė")]
		public int FkMarke { get; set; }
	}
}