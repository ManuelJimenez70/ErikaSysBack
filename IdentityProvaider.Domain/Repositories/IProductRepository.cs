using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProductsByNum(int numI, int numF);
        Task<Product> GetProductById(ProductId Id);

    }
}
