using Smac.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smac.Model.Models
{
    public class SiteMod : Auditable
    {
        #region Properties
        [Key]
        public long Mod_ID { get; set; }
        [Required]
        [Display(Name = "Tên module"), MaxLength(512)]
        public string Mod_Name { get; set; }
        [Required, MaxLength(512)]
        public string Mod_Title { get; set; }
        [Display(Name = "Đường dẫn tĩnh")]
        public string Mod_Url { get; set; }
        [Display(Name = "Mã module")]
        public string Mod_Code { get; set; }

        [Display(Name = "Icon"), MaxLength(50)]
        public string Mod_Icon { get; set; }

        [MaxLength(10000)]
        [Display(Name = "Nội dung tĩnh?")]
        public string Mod_isSingleContent { get; set; }

        [Display(Name = "SEO Key")]
        [MaxLength(1024)]
        public string Mod_SEOKey { get; set; }

        [Display(Name = "SEO Description")]
        [MaxLength(1024)]
        public string Mod_SEODescription { get; set; }

        [Display(Name = "SEO Title")]
        [MaxLength(1024)]
        public string Mod_SEOTitle { get; set; }

        [Display(Name = "Nội dung")]
        [MaxLength(1024)]
        public string Mod_Content { get; set; }

        [Display(Name = "Vị trí")]
        public int Mod_Position { get; set; }

        [Display(Name = "Module Cha")]
        public int Mod_Parent { get; set; }

        [Display(Name = "Nhóm Module")]
        public int Mod_Type { get; set; }
        [Display(Name = "Trạng thái")]
        public int Mod_Status { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public int Mod_Lang { get; set; }

        [Display(Name = "Modtype"), Required]
        public SiteMod_Type Modtype_ID { get; set; }
        #endregion
        
    }
}
