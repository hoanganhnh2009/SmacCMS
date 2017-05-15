using Smac.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smac.Model.Models
{
    public class GroupMod : Auditable
    {
        [Key]
        public int Group_ID { get; set; }
        [Required]
        [Display(Name ="Tên nhóm Module")]
        public string Group_Name { get; set; }
    }
}
