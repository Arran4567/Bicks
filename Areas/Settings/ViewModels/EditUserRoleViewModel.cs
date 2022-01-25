using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Areas.Settings.ViewModels
{
    public class EditUserRoleViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [DisplayName("Role Name")]
        [Required]
        public string RoleName { get; set; }
    }
}
