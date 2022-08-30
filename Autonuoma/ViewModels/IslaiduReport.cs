using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.IslaiduReport
{
    /// <summary>
    /// View model for single job type in a report.
    /// </summary>

    public class Islaidos
    {
        //Roles pavadinimas
        [DisplayName("Pavadinimas")]
        public string Pavadinimas { get; set; }

        //Kiek jiems buvo numatyta sumoketi
        [DisplayName("Numatyta suma")]
        public decimal NumatytaSuma { get; set; }

        //Kiek jiems sumoketa
        [DisplayName("Sumoketa")]
        public decimal Sumoketa { get; set; }

        //Kiek atlikeju
        [DisplayName("Atlikejai")]
        public int Atlikejai { get; set; }

        //miestas
        [DisplayName("Miestas")]
        public string Miestas { get; set; }

    }

    /// <summary>
	/// View model of the whole report.
	/// </summary>
	public class Report
	{
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateFrom { get; set; }

		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTo { get; set; }

		public List<Islaidos> Islaidos { get; set; }

		public int NoretaIsleisti { get; set; }

		public decimal BendraSuma { get; set; }

        public int BendraiAtlikejai { get; set; }
        
	}

}