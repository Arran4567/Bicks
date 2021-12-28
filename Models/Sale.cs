using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Invoice #")]
        [DisplayFormat(DataFormatString ="{0:000000}", ApplyFormatInEditMode = true)]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Time Of Sale")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime SaleDateTime { get; set; }
        [ForeignKey("SaleId")]
        [Display(Name = "Invoice Items")]
        public virtual List<InvoiceItem> SaleInvoiceItems { get; set; }
        [ForeignKey("ClientId")]
        [Display(Name = "Client")]
        public virtual Client Client { get; set; }

    }
}
