
using Smac.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smac.Model.Models
{
    public class Menu : Auditable
    {
        [Key]
        public int ID { get; set; }
        [Required, Display(Name = "Mã Menu")]
        public string Menu_Code { get; set; }
        [Required, Display(Name ="Tên Menu")]
        public string Menu_Name { get; set; }
    }
}
