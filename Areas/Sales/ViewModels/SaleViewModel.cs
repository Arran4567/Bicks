using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bicks.Models;

namespace Bicks.Areas.Sales.ViewModels
{
    public class SaleViewModel
    {
        public Sale Sale{ get; set; }
        public virtual List<InvoiceItem> InvoiceItems { get; set; }
        public virtual List<InvoiceItem> RecommendedItems { get; set; }
        public virtual Client Client { get; set; }
    }
}
