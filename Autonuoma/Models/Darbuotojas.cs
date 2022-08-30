using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Darbuotojas' entity.
	/// </summary>
	public class Darbuotojas
	{
		[DisplayName("Tabelio Nr.")]
		[MaxLength(10)]
		[Required]
		public string Tabelis { get; set; }

		[DisplayName("Vardas")]
		[MaxLength(20)]
		[Required]
		public string Vardas { get; set; }

		[DisplayName("Pavardė")]
		[MaxLength(20)]
		[Required]
		public string Pavarde { get; set; }
	}
}