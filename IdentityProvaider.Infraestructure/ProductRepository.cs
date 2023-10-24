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

        public async Task UpdateProduct(Product product)
        {
            db.Update(product);
            db.SaveChanges();
        }

        public async Task<List<Product>> GetProductsByNum(int numI, int numF, State state)
        {
            var products = db.Products.Where(r => r.state.value.ToLower() == state.value.ToLower()).Skip(numI).Take((numF - numI)).ToList();
            return products;
        }

        public async Task<List<Product>> GetProductsByModule(int numI, int numF, State? state, ModuleIdString id_module)
        {
            var products = state!=null? db.Products.Where(r => r.state.value.ToLower() == state.value.ToLower() && r.id_module.value == null || r.id_module.value == id_module.value).Skip(numI).Take((numF - numI)).ToList():
                db.Products.Where(r => r.id_module.value == id_module.value  || r.id_module.value == null).Skip(numI).Take((numF - numI)).ToList();
            return products;
        }
    }
}
