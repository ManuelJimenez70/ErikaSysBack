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

        public async Task UpdateProduct(UpdateProductCommand updateProduct)
        {
            ProductId id = ProductId.create(updateProduct.id);
            var product = await repository.GetProductById(id);
            string title = string.IsNullOrEmpty(updateProduct.title) ? product.title.value : updateProduct.title;
            product.setTitle(ProductName.create(title));
            string description = string.IsNullOrEmpty(updateProduct.description) ? product.description.value : updateProduct.description;
            product.setDescription(Description.create(description));
            string image = string.IsNullOrEmpty(updateProduct.image) ? product.image.value : updateProduct.image;
            product.setImage(ImageProduct.create(image));
            int price;
            if (updateProduct.price.HasValue)
            {
                price = updateProduct.price.Value;
                product.setPrice(Price.create(price));
            }
            int stock;
            if (updateProduct.stock.HasValue)
            {
                stock = updateProduct.stock.Value;
                product.setStock(Stock.create(stock));
            }
            string state = string.IsNullOrEmpty(updateProduct.state) ? product.state.value : updateProduct.state;
            product.setState(State.create(state));

            await repository.UpdateProduct(product);
        }

        public async Task<List<Product>> GetProductsByNum(int numI, int numF)
        {
            return await repository.GetProductsByNum(numI, numF);
        }

        public async Task<List<Product>> GetProductsByNum(int numI, int numF, string state)
        {
            return await repository.GetProductsByNum(numI, numF, State.create(state));
        }

        public async Task<Product> GetProductById(int id) 
        {
            return await repository.GetProductById(ProductId.create(id));
        }

    }
}