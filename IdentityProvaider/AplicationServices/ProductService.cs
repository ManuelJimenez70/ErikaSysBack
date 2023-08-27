using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace IdentityProvaider.API.AplicationServices
{
    public class ProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateProduct(CreateProductCommand createProduct)
        {
            var product = new Product();
            DateTime creationDate = DateTime.Now;
            product.setTitle(ProductName.create(createProduct.title));
            product.setDescription(Description.create(createProduct.description));
            product.setImage(ImageProduct.create(createProduct.image));
            product.setPrice(Price.create(createProduct.price));
            product.setStock(Stock.create(createProduct.stock));
            await repository.AddProduct(product);   
        }

        public async Task<List<Product>> GetProductsByNum(int numI, int numF)
        {
            return await repository.GetProductsByNum(numI, numF);
        }

    }
}