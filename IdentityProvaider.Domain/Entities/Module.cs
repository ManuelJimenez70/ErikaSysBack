using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Module
    {
        public int id_module{ get; init; }
        public ModuleName name { get; private set; }
        public Description? description { get; private set; }
        public IList<Action_Product> action_modules { get; set; }

        public Module()
        {
        }

        public Module(int id_module)
        {
            this.id_module = id_module;
        }

        public void setName(ModuleName name)
        {
            this.name = name;
        }

        public void setDescription(Description description)
        {
            this.description = description;
        }

    }
}
