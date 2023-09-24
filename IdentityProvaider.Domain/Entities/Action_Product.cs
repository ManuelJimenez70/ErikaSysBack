using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Action_Product
    {
        public int id_user { get; set; }
        public User? user { get; private set; }
        public int id_product { get; set; }
        public Product? product { get; private set; }
        public int id_action { get; set; }
        public Action? action { get; private set; }
        public int id_module { get; set; }
        public Module? module { get; private set; }
        public CreationDate creationDate { get; private set; }
        public State state { get; private set; }
        public Quantity quantity { get; private set; }

        public Action_Product()
        {
            creationDate = CreationDate.create(DateTime.Now);
            state = State.create("QUEUE");
        }
        public Action_Product(int id_user, int id_product, int id_action, int id_module)
        {
            this.id_user = id_user;
            this.id_product = id_product;
            this.id_action = id_action;
            this.id_module = id_module;
            creationDate = CreationDate.create(DateTime.Now);
            state = State.create("QUEUE");
        }

        public void setProduct(Product product)
        {
            this.product = product;
        }

        public void setUser(User user)
        {
            this.user = user;
        }

        public void setQuantity(Quantity quantity)
        {
            this.quantity = quantity;
        }

        public void setAction(Action action)
        {
            this.action = action;
        }

        public void setModule(Module module)
        {
            this.module = module;
        }

        public void setCreationDate(CreationDate creationDate)
        {
            this.creationDate = creationDate;
        }

        public void setState(State state)
        {
            this.state = state;
        }
    }
}
