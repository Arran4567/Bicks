using Bicks.Data;
using Bicks.Data.DAL;
using Bicks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa.AspNetCore;
using Bicks.Areas.Sales.ViewModels;

namespace Bicks.Areas.Sales.Data.DAL
{
    public class SalesWorkUnit : IDisposable
    {
        private ApplicationDbContext _context;
        private SalesRepository saleRepository;
        private GenericRepository<Client> clientRepository;
        private GenericRepository<InvoiceItem> invoiceItemRepository;
        private GenericRepository<ClientProductOption> clientProductOptionRepository;
        private ProductRepository productRepository;

        public SalesWorkUnit(ApplicationDbContext context)
        {
            _context = context;
        }

        public SalesRepository SaleRepository
        {
            get
            {
                if (saleRepository == null)
                {
                    saleRepository = new SalesRepository(_context);
                }
                return saleRepository;
            }
        }

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new GenericRepository<Client>(_context);
                }
                return clientRepository;
            }
        }

        public GenericRepository<InvoiceItem> InvoiceItemRepository
        {
            get
            {
                if (invoiceItemRepository == null)
                {
                    invoiceItemRepository = new GenericRepository<InvoiceItem>(_context);
                }
                return invoiceItemRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
                }
                return productRepository;
            }
        }
        public GenericRepository<ClientProductOption> ClientProductOptionRepository
        {
            get
            {
                if (clientProductOptionRepository == null)
                {
                    clientProductOptionRepository = new GenericRepository<ClientProductOption>(_context);
                }
                return clientProductOptionRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void DeleteSale(Sale sale)
        {
            foreach (InvoiceItem invoiceItem in sale.SaleInvoiceItems)
            {
                InvoiceItemRepository.Delete(invoiceItem);
            }
            SaleRepository.Delete(sale);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Sale CreateNewSaleFromViewModel(SaleViewModel saleViewModel)
        {
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (InvoiceItem invoiceItem in saleViewModel.InvoiceItems)
            {
                if (invoiceItem.NumCases != 0 || invoiceItem.TotalWeight != decimal.Zero)
                    invoiceItems.Add(new InvoiceItem
                    {
                        Product = ProductRepository.GetByID(invoiceItem.Product.ID),
                        NumCases = invoiceItem.NumCases,
                        TotalWeight = invoiceItem.TotalWeight
                    });
            }
            return new Sale
            {
                SaleDateTime = DateTime.Now,
                SaleInvoiceItems = invoiceItems,
                Client = ClientRepository.GetByID(saleViewModel.Sale.Client.ID)
            };
        }

        public Sale UpdateExistingSaleFromViewModel(SaleViewModel saleViewModel)
        {
            Sale sale = SaleRepository.GetByID(saleViewModel.Sale.ID);
            sale.Client = ClientRepository.GetByID(saleViewModel.Sale.Client.ID);
            sale.SaleDateTime = DateTime.Now;
            foreach (InvoiceItem invoiceItem in sale.SaleInvoiceItems)
            {
                InvoiceItemRepository.Delete(invoiceItem);
            }
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (InvoiceItem invoiceItem in saleViewModel.InvoiceItems)
            {
                if (invoiceItem.NumCases != decimal.Zero || invoiceItem.TotalWeight != decimal.Zero)
                    invoiceItems.Add(new InvoiceItem
                    {
                        Product = ProductRepository.GetByID(invoiceItem.Product.ID),
                        NumCases = invoiceItem.NumCases,
                        TotalWeight = invoiceItem.TotalWeight
                    });
            }
            sale.SaleInvoiceItems = invoiceItems;
            return sale;
        }

        public SaleViewModel GetViewModelFromSale(Sale sale)
        {
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            List<Product> products = ProductRepository.Get(orderBy: pr => pr.OrderBy(c => c.ID)).ToList();
            Client client = ClientRepository.GetByID(sale.Client.ID);
            foreach (Product product in products)
            {
                InvoiceItem invoiceItem = new InvoiceItem
                {
                    Product = product
                };
                foreach (InvoiceItem item in sale.SaleInvoiceItems)
                {
                    if (item.Product.ID == product.ID)
                    {
                        invoiceItem = item;
                    }
                }
                invoiceItems.Add(invoiceItem);
            }
            SaleViewModel salesViewModel = new SaleViewModel
            {
                Sale = sale,
                InvoiceItems = invoiceItems,
                Client = client,
            };
            return salesViewModel;
        }

        public List<InvoiceItem> GetRecommendedItems(int id)
        {
            List<ClientProductOption> clientProductOptions = ClientProductOptionRepository.
                Get(orderBy: cpor => cpor.OrderByDescending(c => c.NumTimesPurchased)).
                Where(cpo => cpo.Client.ID == id).
                Take(12).ToList();
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach(ClientProductOption cpo in clientProductOptions)
            {
                InvoiceItem invoiceItem = new InvoiceItem
                {
                    Product = new Product
                    {
                        ID = cpo.Product.ID,
                        Name = cpo.Product.Name,
                        CasesInStock = cpo.Product.CasesInStock,
                        PricePerKg = cpo.Product.PricePerKg,
                        SubCategory = new SubCategory
                        {
                            ID = cpo.Product.SubCategory.ID,
                            Name = "Recommended",
                            Category = null,
                        }
                    }
                };
                invoiceItems.Append(invoiceItem);
            }
            return invoiceItems;
        }

        //Example
        //public IEnumerable<Job> GetUnassignedJobs()
        //{
        //     return JobRepository.Get(j => j.JobStatus.ID == (int)Enums.JobStatuses.JobCreated, q => q.OrderBy(j => j.DueWhen));
        //}
    }
}
