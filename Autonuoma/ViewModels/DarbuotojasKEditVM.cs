using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    /// <summary>
    /// Model of 'DarbuotojasK' entity used in creation and editing forms.
    /// </summary>
    public class DarbuotojasKEditVM
    {
        /// <summary>
        /// Entity data
        /// </summary>
        public class ModelM
        {
            //id, dirbanuo, dirbaiki, darbuotojoRole, fk_ASMUOid
            [DisplayName("Id")]
            public int Id { get; set; }

            //dirba nuo
            [DisplayName("Dirba nuo")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Required]
            public System.DateTime DirbaNuo { get; set; }

            //dirba iki
            [DisplayName("Dirba iki")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Required]
            public System.DateTime DirbaIki { get; set; }

            //darbuotojo role
            [DisplayName("Darbuotojo role")]
            [Required]
            public int DarbuotojoRole { get; set; }

            //fk_ASMUOid
            [DisplayName("Fk_ASMUOid")]
            [Required]
            public int FkASMUOid { get; set; }
        }

        /// <summary>
        /// Select lists for making drop downs for choosing values of entity fields.
        /// </summary>
        public class ListsM
        {
            public IList<SelectListItem> Asmuo { get; set; }
            public IList<SelectListItem> Role { get; set; }
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