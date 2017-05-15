
using Smac.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smac.Model.Models
{
   public class MenuItem : Auditable
    {
        [Key]
        public long MenuItem_ID { get; set; }
        [Required, Display(Name ="Tên hiển thị")]
        public string MenuItem_DisplayName { get; set; }
        [Required, Display(Name = "Thuộc Menu")]
        public Menu Menu { get; set; }

        [Required, Display(Name = "Đường dẫn")]
        public string MenuItem_Url { get; set; }
        [Required, Display(Name = "Cấp")]
        public string MenuItem_Level { get; set; }
        [Required, Display(Name = "Ngôn ngữ")]
        public Language Language { get; set; }
        [Required, Display(Name = "Vị trí")]
        public int Position { get; set; }

    }
}
