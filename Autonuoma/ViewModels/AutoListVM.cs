using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for 'Automobilis' entity in list.
	/// </summary>
	public class AutoListVM
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Valstybinis Nr.")]
		public string ValstybinisNr { get; set; }

		[DisplayName("Būsena")]
		public string Busena { get; set; }

		[DisplayName("Modelis")]
		public string Modelis { get; set; }

		[DisplayName("Markė")]
		public string Marke { get; set; }
	}
}