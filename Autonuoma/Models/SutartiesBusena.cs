using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'SutartiesBusena' entity.
	/// </summary>
	public class SutartiesBusena
	{
		public int Id { get; set; }
		
		public string Name { get; set; }
	}
}