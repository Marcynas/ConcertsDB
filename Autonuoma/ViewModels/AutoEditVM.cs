using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for 'Automobilis' entity in creation and editing forms.
	/// </summary>
	public class AutoEditVM
	{
		/// <summary>
        /// Entity data.
        /// </summary>
		public class AutomobilisM
		{
			[DisplayName("Id")]
			[Required]
			public int Id { get; set; }

			[DisplayName("Valstybinis Nr.")]
			[MaxLength(6)]
			[Required]
			public string ValstybinisNr { get; set; }

			[DisplayName("Pagaminimo data")]
			[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
			[Required]
			public DateTime? PagaminimoData { get; set; }

			[DisplayName("Rida")]
			[Required]
			public int Rida { get; set; }

			[DisplayName("Radijas")]
			[Required]
			public bool Radijas { get; set; }

			[DisplayName("Grotuvas")]
			[Required]
			public bool Grotuvas { get; set; }
			
			[DisplayName("Kondicionierius")]
			[Required]
			public bool Kondicionierius { get; set; }

			[DisplayName("Vietų skaičius")]
			[Required]
			public int VietuSkaicius { get; set; }
			
			[DisplayName("Registravimo data")]
			[Required]
			[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
			public DateTime? RegistravimoData { get; set; }

			[DisplayName("Vertė")]
			[Required]
			[DataType(DataType.Currency)]
			public decimal Verte { get; set; }

			[DisplayName("Pavarų dėžė")]
			[Required]
			public int PavaruDeze { get; set; }

			[DisplayName("Degalų tipas")]
			[Required]
			public int DegaluTipas { get; set; }

			[DisplayName("Kėbulo tipas")]
			[Required]
			public int Kebulas { get; set; }

			[DisplayName("Bagažo dydis")]
			[Required]
			public int BagazoDydis { get; set; }

			[DisplayName("Būsena")]
			public int? Busena { get; set; }

			[DisplayName("Modelis")]
			[Required]
			public int FkModelis { get; set; }
		}

		/// <summary>
        /// Select lists for making drop downs for choosing values of entity fields.
        /// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Modeliai { get; set; }
			public IList<SelectListItem> PavaruDezes { get; set; }
			public IList<SelectListItem> Kebulai { get; set; }
			public IList<SelectListItem> DegaluTipai { get; set; }
			public IList<SelectListItem> Bagazai { get; set; }
			public IList<SelectListItem> Busenos { get; set; }
		}


		/// <summary>
        /// Entity view.
        /// </summary>
		public AutomobilisM Auto { get ; set; } = new AutomobilisM();

		/// <summary>
        /// Lists for drop down controls.
        /// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}