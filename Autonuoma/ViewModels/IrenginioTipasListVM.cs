using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Irenginio_tipas' entity used in lists.
	/// </summary>
	public class IrenginioTipasListVM
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		public string Pavadinimas { get; set; }	

		[DisplayName("Tipas")]
		public string Tipas { get; set; }		

	}
}