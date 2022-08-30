using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Models{
    /// <summary>
    /// Model for 'Miestas' entity.
    /// </summary>
    public class Miestas{
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }
    }
}