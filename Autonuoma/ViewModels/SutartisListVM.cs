using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
    /// View model for displaying list oft 'Sutartis' entities.
    /// </summary>
	public class SutartisListVM
	{
		[DisplayName("Nr.")]
		public int Nr { get; set; }


		[DisplayName("Sudarymo data")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Data { get; set; }


		[DisplayName("Darbuotojas")]
		public string Darbuotojas { get; set; }


		[DisplayName("Nuomininkas")]
		public string Nuomininkas { get; set; }


		[DisplayName("Būsena")]
		public string Busena { get; set; }
	}
}