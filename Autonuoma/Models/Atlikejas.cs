using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Atlikejas' entity.
	/// </summary>
	public class Atlikejas
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Vardas")]
		public string Vardas { get; set; }

        [DisplayName("Pavarde")]
		public string Pavarde { get; set; }

        [DisplayName("Zanras")]
		public string Zanras { get; set; }

        [DisplayName("Kontaktai")]
		public string Kontaktai { get; set; }

		//Markė
		[DisplayName("Lytis")]
		public int FkLytis { get; set; }
	}
}