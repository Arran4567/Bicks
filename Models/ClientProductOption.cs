using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Models
{
    public class ClientProductOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product")]
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [Required]
        [Display(Name = "Client")]
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        [Required]
        [Display(Name = "Price Per Kg")]
        [Column(TypeName = "Decimal(18, 2)")]
#nullable enable
        public decimal? PricePerKgOverride { get; set; }
#nullable disable
        [Required]
        [Display(Name = "Number of Times Purchased")]
        public int NumTimesPurchased { get; set; }
    }
}
