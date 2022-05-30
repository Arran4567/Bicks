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
        private ClientRepository clientRepository;
        private GenericRepository<InvoiceItem> invoiceItemRepository;
        private GenericRepository<ProductOption> productOptionRepository;
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

        public ClientRepository ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new ClientRepository(_context);
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
        public GenericRepository<ProductOption> ProductOptionRepository
        {
            get
            {
                if (productOptionRepository == null)
                {
                    productOptionRepository = new GenericRepository<ProductOption>(_context);
                }
                return productOptionRepository;
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

        public bool isClient(int id)
        {
            bool isClient = false;
            if(ClientRepository.GetByID(id) != null)
            {
                isClient = true;
            }
            return isClient;
        }

        public Sale CreateNewSaleFromViewModel(SaleViewModel saleViewModel)
        {
            List<InvoiceItem> allItems = saleViewModel.RecommendedItems != null ? saleViewModel.InvoiceItems.Concat(saleViewModel.RecommendedItems).ToList() : saleViewModel.InvoiceItems;
            if(allItems.Count == 0)
            {
                return null;
            }
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (InvoiceItem invoiceItem in allItems)
            {
                if (invoiceItem.NumCases != 0)
                    invoiceItems.Add(new InvoiceItem
                    {
                        Product = ProductRepository.GetByID(invoiceItem.Product.ID),
                        NumCases = invoiceItem.NumCases
                    });
            }
            return new Sale
            {
                SaleDateTime = DateTime.Now,
                SaleInvoiceItems = invoiceItems,
                Client = ClientRepository.GetByID(saleViewModel.Client.ID)
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
                        NumCases = invoiceItem.NumCases
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
            List<ProductOption> productOptions = ClientRepository.
                GetProductOptions(id).
                Where(cpo => cpo.NumTimesPurchased > 0).
                Take(12).ToList();
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach(ProductOption cpo in productOptions)
            {
                InvoiceItem invoiceItem = new InvoiceItem
                {
                    Product = cpo.Product
                };
                invoiceItems.Add(invoiceItem);
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
