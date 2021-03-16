using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Apps
{
    public class ProductApplication : IProductApp
    {
        private readonly IProductDomain _productDomain;
        public ProductApplication(IProductDomain productDomain)
        {
            _productDomain = productDomain;
        }
        public async Task AddItem(Product Entity)
        {
            await _productDomain.AddItem(Entity);
        }

        public async Task<List<Product>> AllItems()
        {
            return await _productDomain.AllItems();
        }

        public async Task Delete(Product Entity)
        {
            await _productDomain.Delete(Entity);
        }

        public async Task<Product> GetItemById(long id)
        {
            return await _productDomain.GetItemById(id);
        }

        public async Task UpdateItem(Product Entity)
        {
            await _productDomain.UpdateItem(Entity);
        }
    }
}
