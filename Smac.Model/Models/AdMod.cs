using Smac.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smac.Model.Models
{
    public class AdMod : Auditable
    {
        [Key]
        public long AdMod_ID { get; set; }
        [Required]
        [Display(Name ="Mã module")]
        public string AdModCode { get; set; }
        [Required]
        [Display(Name ="Tên module")]
        public string AdModName { get; set; }
        [Display(Name ="Sự kiện Load")]
        public string AdMod_OnLoad { get; set; }
        [Display(Name = "Ảnh")]
        public string AdMod_Image { get; set; }
        [Display(Name = "Đường dẫn")]
        public string AdMod_Url { get; set; }
        [Display(Name = "Module cha")]
        public long AdMod_Parent { get; set; }
        [Display(Name = "Nhóm Module")]
        public GroupMod AdMod_Group { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
