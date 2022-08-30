using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// View model for editing data of 'Paslauga' entity.
	/// </summary>
	public class PaslaugaEditVM
	{
		/// <summary>
		/// Entity data.
		/// </summary>
		public Paslauga Paslauga { get; set; }

		/// <summary>
		/// View models of related 'PaslaugosKaina' entities
		/// </summary>
		public List<PaslaugosKainaVM> Kainos { get; set; } = new List<PaslaugosKainaVM>();
	}
}