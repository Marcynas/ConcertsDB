using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model for 'DegaluTipas' entity.
	/// </summary>
	public class DegaluTipas
	{
		public int Id { get; set; }

		public string Pavadinimas { get; set; }
	}
}