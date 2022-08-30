using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Paslauga' entity.
	/// </summary>
	public class Paslauga
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		[Required]
		public string Pavadinimas { get; set; }

		[DisplayName("Aprašymas")]
		public string Aprasymas { get; set; }
	}
}