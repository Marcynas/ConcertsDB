using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Models{
    /// <summary>
    /// Model for 'Lytis' entity.
    /// </summary>
    public class Lytis{
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }
    }
}