using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvaider.Domain.Entities
{
    public class Action
    {
        public int id_action { get; init; }
        public ActionType type { get; private set; }

        public CreationDate creationDate { get; private set; }
        public Description? description { get; private set; }

        public State state { get; private set; }
        public IList<Action_Product> action_users { get; set; }

        public Action()
        {
            creationDate = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }

        public Action(int id_action)
        {
            creationDate = CreationDate.create(DateTime.Now);
            this.id_action = id_action;
            state = State.create("Activo");
        }

        public void setDescription(Description description)
        {
            this.description = description;
            state = State.create("Activo");
        }

        public void setTypeAction(ActionType type)
        {
            this.type = type;
        }

        public void setState(State state)
        {
            this.state = state;
        }

    }
}
