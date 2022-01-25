using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Bicks.Models;

namespace Bicks.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Cases in Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Please ensure stock doesn't fall below 0.")]
        public int CasesInStock { get; set; }
        [Required]
        [Display(Name = "Price Per Kg")]
        [Column(TypeName = "Decimal(18, 2)")]
        public decimal PricePerKg { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory SubCategory { get; set; }
    }
}
