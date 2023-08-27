using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using IdentityProvaider.Infraestructure;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Action = IdentityProvaider.Domain.Entities.Action;

namespace IdentityProvaider.API.AplicationServices
{
    public class ProductService
    {
        private readonly IProductRepository repository;


        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> CreateProduct()
        {
            var product = new Product();
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

    public class TempProduct
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        //public Ratingg rating { get; set; }
    }

    public class Ratingg
    {
        public double rate { get; set; }
        public int count { get; set; }
    }
}