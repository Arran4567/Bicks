using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bicks.Models;
using Bicks.Areas.Sales.ViewModels;
using Newtonsoft.Json;
using Rotativa.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace Bicks.Data.DAL
{
    public class SalesRepository : GenericRepository<Sale>
    {
        public SalesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public SalesInvoiceViewModel GenerateInvoice(Sale sale)
        {
            decimal total = decimal.Zero;
            foreach (InvoiceItem item in sale.SaleInvoiceItems)
            {
                switch (item.Product.PricingMethod)
                {
                    case (int)Enums.PricingMethod.PricePerKg:
                        total += item.Product.PricePerKg * item.TotalWeight;
                        break;
                    case (int)Enums.PricingMethod.PricePerUnit:
                        total += item.Product.PricePerUnit * item.NumCases;
                        break;
                }
            }
            SalesInvoiceViewModel salesInvoiceViewModel = new SalesInvoiceViewModel
            {
                InvoiceNo = sale.ID,
                Date = DateTime.Now,
                Client = sale.Client,
                DeliverTo = sale.Client.AddressLine1,
                InvoiceItems = sale.SaleInvoiceItems,
                Total = total
            };
            return salesInvoiceViewModel;
        }
    }
}
