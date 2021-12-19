using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;
using Bicks.Models;
using Bicks.ViewModels;
using Bicks.Data;
using Bicks.Controllers;

namespace Bicks.Services
{
    public class StripeService
    {

        public void GenerateInvoice()
        {
            
        }

        private Stripe.Customer CreateCustomer(string name, string email, string description)
        {
            var options = new CustomerCreateOptions
            {
                Name = name,
                Email = email,
                Description = description,
            };
            var service = new CustomerService();
            Stripe.Customer customer = service.Create(options);
            return customer;
        }

        private void CreateInvoiceItem(string customerId, decimal unitPrice, int quantity, string description)
        {
            long unitAmount = (long)(unitPrice * 100);
            var options = new InvoiceItemCreateOptions
            {
                Customer = customerId,
                UnitAmount = unitAmount,
                Quantity = quantity,
                Description = description,
                Currency = "gbp"
            };
            var service = new InvoiceItemService();
            var invoiceItem = service.Create(options);
        }

        private Invoice CreateInvoice(string customerId)
        {

            var invoiceOptions = new InvoiceCreateOptions
            {
                Customer = customerId,
                AutoAdvance = true,
                CollectionMethod = "send_invoice",
                DaysUntilDue = 0, //Test me
            };
            var invoiceService = new InvoiceService();
            var invoice = invoiceService.Create(invoiceOptions);
            return invoice;
        }

        private void SendInvoice(string invoiceId)
        {
            var service = new InvoiceService();
            service.FinalizeInvoice(invoiceId);
            service.SendInvoice(invoiceId);
        }
    }
}
