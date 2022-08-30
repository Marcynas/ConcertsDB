using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.KoncertuReport
{

    /// <summary>
    /// View model for single pasirodymas in a report.
    /// </summary>

    public class pasirodymas
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pasirodymo Pavadinimas")]
        public string Pavadinimas { get; set; }

        //kaina
        [DisplayName("Kaina")]
        public decimal Kaina { get; set; }

        //sumoketa
        [DisplayName("Sumoketa")]
        public decimal Sumoketa { get; set; }

        //atlikejo vardas
        [DisplayName("Atlikejo vardas")]
        public string AtlikejoVardas { get; set; }

        //atlikejo pavarde
        [DisplayName("Atlikejo pavarde")]
        public string AtlikejoPavarde { get; set; }

        //koncerto pavadinimas
        [DisplayName("Koncerto pavadinimas")]
        public string KoncertoPavadinimas { get; set; }

        //koncerto pradžia
        [DisplayName("Koncerto pradžia")]
        public DateTime? KoncertoPradzia { get; set; }

        //koncerto pabaiga
        [DisplayName("Koncerto pabaiga")]
        public DateTime? KoncertoPabaiga { get; set; }

    }




}