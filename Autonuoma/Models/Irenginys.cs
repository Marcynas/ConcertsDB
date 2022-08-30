using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Irenginys' entity.
	/// </summary>
	public class Irenginys
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		public string Pavadinimas { get; set; }

		[DisplayName("Turimas Kiekis")]
		public int TurimasKiekis { get; set; }

        //IrenginioTipas
		[DisplayName("Irenginio tipas")]
		public int FkIrenginioTipas { get; set; }
	}
}