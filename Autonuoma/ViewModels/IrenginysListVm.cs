using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
	/// <summary>
	/// Model of 'Irenginys' entity used in lists.
	/// </summary>
	public class IrenginysListVM
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pavadinimas")]
        public string Pavadinimas { get; set; }

        [DisplayName("Turimas Kiekis")]
        public int TurimasKiekis { get; set; }

        [DisplayName("Irenginio tipas")]
        public string IrenginioTipas { get; set; }
    }
}