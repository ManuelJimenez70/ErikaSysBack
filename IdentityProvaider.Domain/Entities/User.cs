using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IdentityProvaider.Domain.Entities
{
    public class User
    {
        public int id_user { get; init; }

        public Email email { get; private set; }
        public UserName name { get; private set; }
        public UserLastName lastName { get; private set; }
        public UserTypeDocument typeDocument { get; private set; }
        public UserIdentification identification { get; private set; }
        public CreationDate creationDate { get; private set; }
        public State  state { get; private set; }
        public Direction direction { get; private set; }

        public IList<Rol_User> rol_Users { get; set; }
        public IList<Action_Product> action_users { get; set; }

        public static object Claims { get; set; }

        public User()
        {
            creationDate = CreationDate.create(DateTime.Now);
            state = State.create("Activo");
        }

        public User(int id_user)
        {
            this.id_user = id_user;
            state = State.create("Activo");
        }

        public void setEmail(Email email)
        {            
            this.email = email;
        }

        public void setName(UserName name)
        {
            this.name = name;
        }
        public void setLastName(UserLastName lastName)
        {
            this.lastName = lastName;
        }

        public void setTypeDocument(UserTypeDocument typeDocument)
        {
            this.typeDocument = typeDocument;
        }

        public void setIdentification(UserIdentification identification)
        {
            this.identification = identification;
        }

        public void setDirection(Direction direction)
        {
            this.direction = direction;
        }
        public void setState(State state)
        {
            this.state = state;
        }

    }
}
