using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
	/// <summary>
	/// Model of 'Darbuotojas' entity.
	/// </summary>
	public class DarbuotojasK
	{
		//id, dirbanuo, dirbaiki, darbuotojoRole, fk_ASMUOid
        [DisplayName("Id")]
        public int Id { get; set; }

        //dirba nuo
        [DisplayName("Dirba nuo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DirbaNuo { get; set; }

        //dirba iki
        [DisplayName("Dirba iki")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DirbaIki { get; set; }

        //darbuotojo role
        [DisplayName("Darbuotojo role")]
        public string DarbuotojoRole { get; set; }

        //fk_ASMUOid
        [DisplayName("Fk_ASMUOid")]
        public int FkASMUOid { get; set; }

	}
}