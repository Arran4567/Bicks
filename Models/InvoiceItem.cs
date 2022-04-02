using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Models
{
    public class InvoiceItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Product")]
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [Display(Name = "Number of cases")]
        public int NumCases { get; set; }
        [NotMapped]
        [Display(Name = "Item Weights")]
        [Column(TypeName = "Decimal(18, 2)")]
        public List<decimal> ItemWeights { 
            get 
            {
                if(SerializedItemWeights != null)
                {
                    return JsonConvert.DeserializeObject<List<decimal>>(SerializedItemWeights);
                }
                return new List<decimal>();
            } 
            set 
            {
                SerializedItemWeights = JsonConvert.SerializeObject(SerializedItemWeights);
            } 
        }
        [Column("ItemWeights")]
        public string SerializedItemWeights { get; set; }
        [Required]
        [Display(Name = "Total Weight")]
        [Column(TypeName = "Decimal(18, 2)")]
        public decimal TotalWeight {
            get
            {
                return ItemWeights.Sum();
            }
        }
    }
}
