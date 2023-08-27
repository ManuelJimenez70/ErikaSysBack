using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IdentityProvaider.Domain.Entities
{
    public class Product
    {
        public int id_product { get; init; }
        public ProductName title { get; set; }
        public Price price { get; set; }
        public Description description { get; set; }
        public ImageProduct image { get; set; }
        public Stock stock { get; set; }
        public CreationDate creationDate { get; set; }
        public State state { get; set; }
        public IList<Action_Product> action_products { get; set; }


        public Product()
        {
            creationDate = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }

        public Product(int id_product)
        {
            this.id_product = id_product;
            
        }

        public void setTitle(ProductName title)
        {
            this.title = title;
        }

        public void setDescription(Description description)
        {
            this.description = description;
        }

        public void setImage(ImageProduct image)
        {
            this.image = image;
        }
        public void setPrice(Price price)
        {
            this.price = price;
        }
        public void setStock(Stock stock) 
        {
            this.stock = stock;
        }
        public void setState(State state) 
        { 
            this.state = state;
        }
    }
}
