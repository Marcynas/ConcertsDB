using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'IrenginioTipas' entity.
	/// </summary>
	public class IrenginioTipas
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		public string Pavadinimas { get; set; }

		[DisplayName("Tipas")]
		public int FkTipas { get; set; }
        
	}
}