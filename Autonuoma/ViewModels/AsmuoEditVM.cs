using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Asmuo' entity used in creation and editing forms.
	/// </summary>
	public class AsmuoEditVM
	{
		/// <summary>
		/// Entity data
		/// </summary>
		public class ModelM
		{
			[DisplayName("Id")]
			public int Id { get; set; }

			[DisplayName("Vardas")]
			[MaxLength(20)]
			[Required]
			public string Vardas { get; set; }

            [DisplayName("Pavarde")]
			[MaxLength(20)]
			[Required]
			public string Pavarde { get; set; }

			[DisplayName("Lytis")]
			[Required]
			public int FkLytis { get; set; }
		}

		/// <summary>
		/// Select lists for making drop downs for choosing values of entity fields.
		/// </summary>
		public class ListsM
		{
			public IList<SelectListItem> Asmenys { get; set; }
		}

		/// <summary>
		/// Entity view.
		/// </summary>
		public ModelM Model { get; set; } = new ModelM();

		/// <summary>
		/// Lists for drop down controls.
		/// </summary>
		public ListsM Lists { get; set; } = new ListsM();
	}
}