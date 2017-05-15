using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smac.Model.Models
{
    public class SiteMod_Type
    {
        [Key]
        public int Modtype_ID { get; set; }
        [Required, MaxLength(50)]
        public string Modtype_Code { get; set; }
        [Required, MaxLength(256)]
        public string Modtype_Name { get; set; }
        
        public string Modtype_Desc { get; set; }

    }
}
