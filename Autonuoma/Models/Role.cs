using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model for 'Role' entity.
	/// </summary>
	public class Role
	{
		[DisplayName("Id")]
		public int Id { get; set; }

		[DisplayName("Pavadinimas")]
		[Required]
		public string Pavadinimas { get; set; }
	}
}