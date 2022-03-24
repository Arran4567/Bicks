using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Models
{
    public class ClientGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
#nullable enable
        [Display(Name = "Price Per Kg")]
        [Column(TypeName = "Decimal(18, 2)")]
        public decimal? PricePerKgOverride { get; set; }
        [Display(Name = "Price Per Unit")]
        [Column(TypeName = "Decimal(18, 2)")]
        public decimal? PricePerUnitOverride { get; set; }
#nullable disable
    }
}
