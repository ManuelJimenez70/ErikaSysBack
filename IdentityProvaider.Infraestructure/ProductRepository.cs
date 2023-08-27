using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IdentityProvaider.Infraestructure
{
    public class ProductRepository: IProductRepository
    {
        DatabaseContext db;

        public ProductRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task AddProduct(Product product)
        {
            await db.AddAsync(product);
            await db.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(ProductId Id)
        {
            return await db.Products.FindAsync((int)Id);
        }

        public async Task<List<Product>> GetProductsByNum(int numI, int numF)
        {
            var products = db.Products.Skip(numI).Take((numF - numI)).ToList();
            return products;
        }
    }
}
