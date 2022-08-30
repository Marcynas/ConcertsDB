using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
    /// View model for editing data of 'Sutartis' entity.
    /// </summary>
	public class SutartisEditVM
	{
		/// <summary>
        /// Entity data.
        /// </summary>
        public class SutartisM
        {
			[DisplayName("Nr")]
			public int Nr { get; set; }

			[DisplayName("Data")]
			[DataType(DataType.Date)]
			[Required]
			public DateTime SutartiesData { get; set; }
			
			[DisplayName("Nuomos data ir laikas")]
			[DataType(DataType.DateTime)]
			[Required]
			public DateTime NuomosDataLaikas { get; set; }

			[DisplayName("Planuojama grąžinti")]
			[DataType(DataType.DateTime)]
			[Required]	
			public DateTime PlanuojamaGrDataLaikas { get; set; }

			[DisplayName("Grąžinta")]
			[DataType(DataType.DateTime)]		
			public DateTime? FaktineGrDataLaikas { get; set; }

			[DisplayName("Rida paimant")]
			[Required]
			public int PradineRida { get; set; }

			[DisplayName("Rida grąžinus")]
			public int? GalineRida { get; set; }

			[DisplayName("Nuomos kaina")]
			[Required]
			public decimal Kaina { get; set; }

			[DisplayName("Degalų kiekis paimant")]
			[Required]
			public int DegaluKiekisPaimant { get; set; }

			[DisplayName("Degalų kiekis gražinus")]
			public int? DegaluKiekisGrazinant { get; set; }

			[DisplayName("Būsena")]
			[Required]
			public int Busena { get; set; }

			[DisplayName("Klientas")]
			[Required]
			public string FkKlientas { get; set; }

			[DisplayName("Darbuotojas")]
			[Required]
			public string FkDarbuotojas { get; set; }

			[DisplayName("Automobilis")]
			[Required]
			public int FkAutomobilis { get; set; }

			[DisplayName("Gražinimo vieta")]
			[Required]
			public int FkGrazinimoVieta { get; set; }

			[DisplayName("Paėmimo vieta")]
			[Required]
			public int FkPaemimoVieta { get; set; }
        }

		/// <summary>
        /// Representation of 'UzsakytaPaslauga' entity in 'Sutartis' edit form.
        /// </summary>
		public class UzsakytaPaslaugaM
		{
			/// <summary>
            /// ID of the record in the form. Is used when adding and removing records.
            /// </summary>
            public int InListId { get; set; }

            [DisplayName("Paslauga")]
			[Required]
            public string Paslauga { get; set; }

			[DisplayName("Kiekis")]
			[Required]
			[Range(1, int.MaxValue)]
			public int Kiekis { get; set; }

			[DisplayName("Kaina")]
			[Required]
			public decimal Kaina { get; set; }
        }

		/// <summary>
        /// Select lists for making drop downs for choosing values of entity fields.
        /// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Klientai { get; set; }

			public IList<SelectListItem> Darbuotojai { get; set; }

			public IList<SelectListItem> Busenos { get; set; }

			public IList<SelectListItem> Automobiliai { get; set; }

			public IList<SelectListItem> Vietos { get; set; }


        	public IList<SelectListItem> Paslaugos {get;set;}
		}


		/// <summary>
        /// Entity view.
        /// </summary>
        public SutartisM Sutartis { get; set; } = new SutartisM();

		/// <summary>
        /// Views of related 'UzsakytosPaslaugos' records.
        /// </summary>
        public IList<UzsakytaPaslaugaM> UzsakytosPaslaugos { get; set;  } = new List<UzsakytaPaslaugaM>();

		/// <summary>
        /// Lists for drop down controls.
        /// </summary>
        public ListsM Lists { get; set; } = new ListsM();
	}
}