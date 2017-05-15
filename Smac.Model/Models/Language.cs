
using Smac.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smac.Model.Models
{
    public class Language : Auditable
    {
        [Key]
        public int lang_ID { get; set; }
        [Required, Display(Name ="Mã")]
        public string lang_Code { get; set; }
        [Required, Display(Name = "Tên ngôn ngữ")]
        public string lang_Name { get; set; }
    }
}
