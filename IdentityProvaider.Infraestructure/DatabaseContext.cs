using IdentityProvaider.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Action = IdentityProvaider.Domain.Entities.Action;

namespace IdentityProvaider.Infraestructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<LogUser> Log_Users { get; set; }
        public DbSet<Action_Product> Action_Product { get; set; }

        public DbSet<Rol_User> Rol_User { get; set; }
        public DbSet<Password> SecurityPasswords { get; set; }

        public DbSet<Session> InSession { get; set; }

        public DbSet<Action> Actions { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Check> Checks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        

            modelBuilder.Entity<Room>(o =>
            {
                o.HasKey(x => x.id_room).HasName("id_room");
            });

            modelBuilder.Entity<Room>().OwnsOne(o => o.number, conf =>
            {
                conf.Property(x => x.value).HasColumnName("number");
            });

            modelBuilder.Entity<Room>().OwnsOne(o => o.max_capacity, conf =>
            {
                conf.Property(x => x.value).HasColumnName("max_capacity");
            });

            modelBuilder.Entity<Room>().OwnsOne(o => o.price_per_night, conf =>
            {
                conf.Property(x => x.value).HasColumnName("price_per_night");
            });

            modelBuilder.Entity<Room>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });

            modelBuilder.Entity<Check>(o =>
            {
                o.HasKey(x => x.id_check).HasName("id_check");
            });

            modelBuilder.Entity<Check>().OwnsOne(o => o.id_room, conf =>
            {
                conf.Property(x => x.value).HasColumnName("id_room");
            });

            modelBuilder.Entity<Check>().OwnsOne(o => o.id_reservation, conf =>
            {
                conf.Property(x => x.value).HasColumnName("id_reservation");
            });

            modelBuilder.Entity<Check>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });


            modelBuilder.Entity<Check>().OwnsOne(o => o.checkin_date, conf =>
            {
                conf.Property(x => x.value).HasColumnName("checkin_date");
            });

            modelBuilder.Entity<Check>().OwnsOne(o => o.checkout_date, conf =>
            {
                conf.Property(x => x.value).HasColumnName("checkout_date");
            });

            modelBuilder.Entity<Check>().OwnsOne(o => o.titular_person_id, conf =>
            {
                conf.Property(x => x.value).HasColumnName("titular_person_id");
            });

            modelBuilder.Entity<Check>().OwnsOne(o => o.titular_person_name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("titular_person_name");
            });

            modelBuilder.Entity<Check>().OwnsOne(o => o.num_hosts, conf =>
            {
                conf.Property(x => x.value).HasColumnName("num_hosts");
            });

            modelBuilder.Entity<Inventory>().HasKey(sc => new { sc.id_product, sc.id_room });

            modelBuilder.Entity<Inventory>().Property(o => o.id_room).HasColumnName("id_room");

            modelBuilder.Entity<Inventory>().Property(o => o.id_product).HasColumnName("id_product");

            modelBuilder.Entity<Inventory>()
            .HasOne<Room>(sc => sc.room)
            .WithMany(s => s.room_products)
            .HasForeignKey(sc => sc.id_room);

            modelBuilder.Entity<Inventory>()
                .HasOne<Product>(sc => sc.product)
                .WithMany(s => s.room_products)
                .HasForeignKey(sc => sc.id_product);

            modelBuilder.Entity<Inventory>().OwnsOne(o => o.stock, conf =>
            {
                conf.Property(x => x.value).HasColumnName("stock");
            });

            modelBuilder.Entity<Reservation>(o =>
            {
                o.HasKey(x => x.id_reservation).HasName("id_reservation");
            });

            modelBuilder.Entity<Reservation>().OwnsOne(o => o.id_room, conf =>
            {
                conf.Property(x => x.value).HasColumnName("room_id");
            });

            modelBuilder.Entity<Reservation>().OwnsOne(o => o.reservation_date, conf =>
            {
                conf.Property(x => x.value).HasColumnName("reservation_date");
            });

            modelBuilder.Entity<Reservation>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });

            modelBuilder.Entity<Reservation>().OwnsOne(o => o.titular_person_id, conf =>
            {
                conf.Property(x => x.value).HasColumnName("titular_person_id");
            });

            modelBuilder.Entity<Reservation>().OwnsOne(o => o.titular_person_name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("titular_person_name");
            });

            modelBuilder.Entity<Reservation>().OwnsOne(o => o.creation_date, conf =>
            {
                conf.Property(x => x.value).HasColumnName("creation_date");
            });

            modelBuilder.Entity<Action>(o =>
            {
                o.HasKey(x => x.id_action).HasName("id_action");
            });

            modelBuilder.Entity<Action>().OwnsOne(o => o.type, conf =>
            {
                conf.Property(x => x.value).HasColumnName("type");
            });

            modelBuilder.Entity<Action>().OwnsOne(o => o.creationDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("creation_date");
            });

            modelBuilder.Entity<Action>().OwnsOne(o => o.description, conf =>
            {
                conf.Property(x => x.value).HasColumnName("description");
            });

            modelBuilder.Entity<Action>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });


            modelBuilder.Entity<Module>(o =>
            {
                o.HasKey(x => x.id_module).HasName("id_module");
            });

            modelBuilder.Entity<Module>().OwnsOne(o => o.name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("name");
            });

            modelBuilder.Entity<Module>().OwnsOne(o => o.description, conf =>
            {
                conf.Property(x => x.value).HasColumnName("description");
            });

            modelBuilder.Entity<User>(o =>
            {
                o.HasKey(x => x.id_user).HasName("id_user");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.email, conf =>
            {
                conf.Property(x => x.value).HasColumnName("email");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("name");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.lastName, conf =>
            {
                conf.Property(x => x.value).HasColumnName("last_name");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.typeDocument, conf =>
            {
                conf.Property(x => x.value).HasColumnName("type_document");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.identification, conf =>
            {
                conf.Property(x => x.value).HasColumnName("document_number");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.creationDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("creation_date");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.direction, conf =>
            {
                conf.Property(x => x.value).HasColumnName("address");
            });

            modelBuilder.Entity<User>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });

            modelBuilder.Entity<Product>(o =>
            {
                o.HasKey(x => x.id_product).HasName("id_product");
            });

            modelBuilder.Entity<Product>().OwnsOne(o => o.title, conf =>
            {
                conf.Property(x => x.value).HasColumnName("title");
            });

            modelBuilder.Entity<Product>().OwnsOne(o => o.description, conf =>
            {
                conf.Property(x => x.value).HasColumnName("description");
            });

            modelBuilder.Entity<Product>().OwnsOne(o => o.image, conf =>
            {
                conf.Property(x => x.value).HasColumnName("image");
            });

            modelBuilder.Entity<Product>().OwnsOne(o => o.price, conf =>
            {
                conf.Property(x => x.value).HasColumnName("price");
            });
            modelBuilder.Entity<Product>().OwnsOne(o => o.creationDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("creation_date");
            });
            modelBuilder.Entity<Product>().OwnsOne(o => o.stock, conf =>
            {
                conf.Property(x => x.value).HasColumnName("stock");
            });
            modelBuilder.Entity<Product>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });

            modelBuilder.Entity<Product>().OwnsOne(o => o.id_module, conf =>
            {
                conf.Property(x => x.value).HasColumnName("id_module").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>(o =>
            {
                o.HasKey(x => x.id_log).HasName("id_log");
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.id_edit_user, conf =>
            {
                conf.Property(x => x.value).HasColumnName("id_edit_user");
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.location, conf =>
            {
                conf.Property(x => x.value).HasColumnName("location").IsRequired(false);
            });
            modelBuilder.Entity<LogUser>().OwnsOne(o => o.coordinate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("coordinate").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.email, conf =>
            {
                conf.Property(x => x.value).HasColumnName("email").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("name").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.lastName, conf =>
            {
                conf.Property(x => x.value).HasColumnName("last_name").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.typeDocument, conf =>
            {
                conf.Property(x => x.value).HasColumnName("type_document").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.identification, conf =>
            {
                conf.Property(x => x.value).HasColumnName("document_number").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.direction, conf =>
            {
                conf.Property(x => x.value).HasColumnName("address").IsRequired(false);
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.logDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("log_date");
            });

            modelBuilder.Entity<LogUser>().OwnsOne(o => o.description, conf =>
            {
                conf.Property(x => x.value).HasColumnName("description").IsRequired(false);
            });

            modelBuilder.Entity<Session>(o =>
            {
                o.HasKey(x => x.id_session).HasName("id_session");
            });

            modelBuilder.Entity<Session>().OwnsOne(o => o.id_user, conf =>
            {
                conf.Property(x => x.value).HasColumnName("id_user");
            });

            modelBuilder.Entity<Session>().OwnsOne(o => o.loginDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("loginDate");
            });

            modelBuilder.Entity<Role>(o =>
            {
                o.HasKey(x => x.id_rol).HasName("id_rol");
            });

            modelBuilder.Entity<Role>().OwnsOne(o => o.name, conf =>
            {
                conf.Property(x => x.value).HasColumnName("rol_name");
            });

            modelBuilder.Entity<Role>().OwnsOne(o => o.description, conf =>
            {
                conf.Property(x => x.value).HasColumnName("description");
            });

            modelBuilder.Entity<Rol_User>().HasKey(sc => new { sc.id_user, sc.id_rol });

            modelBuilder.Entity<Rol_User>()
                .HasOne<User>(sc => sc.user)
                .WithMany(s => s.rol_Users)
                .HasForeignKey(sc => sc.id_user);

            modelBuilder.Entity<Rol_User>()
            .Property(o => o.id_user).HasColumnName("id_user");

            modelBuilder.Entity<Rol_User>()
       .Property(o => o.id_rol).HasColumnName("id_rol");

            modelBuilder.Entity<Rol_User>()
                .HasOne<Role>(sc => sc.role)
                .WithMany(s => s.rol_Users)
                .HasForeignKey(sc => sc.id_rol);


            modelBuilder.Entity<Rol_User>().OwnsOne(o => o.creationDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("creation_rol");
            });

            modelBuilder.Entity<Rol_User>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state_rol");
            });

            //Ejemplo Entidad Debil

            modelBuilder.Entity<Action_Product>().HasKey(sc => new { sc.id_user, sc.id_action, sc.id_product, sc.id_module });

            modelBuilder.Entity<Action_Product>().Property(o => o.id_action).HasColumnName("id_action");

            modelBuilder.Entity<Action_Product>().Property(o => o.id_product).HasColumnName("id_product");

            modelBuilder.Entity<Action_Product>().Property(o => o.id_user).HasColumnName("id_user");

            modelBuilder.Entity<Action_Product>().Property(o => o.id_module).HasColumnName("id_module");

            modelBuilder.Entity<Action_Product>().OwnsOne(o => o.creationDate, conf =>
            {
                conf.Property(x => x.value).HasColumnName("creation_date");
            });

            modelBuilder.Entity<Action_Product>().OwnsOne(o => o.state, conf =>
            {
                conf.Property(x => x.value).HasColumnName("state");
            });

            modelBuilder.Entity<Action_Product>().OwnsOne(o => o.quantity, conf =>
            {
                conf.Property(x => x.value).HasColumnName("quantity");
            });

            modelBuilder.Entity<Action_Product>()
                .HasOne<User>(sc => sc.user)
                .WithMany(s => s.action_users)
                .HasForeignKey(sc => sc.id_user);


            modelBuilder.Entity<Action_Product>()
                .HasOne<Action>(sc => sc.action)
                .WithMany(s => s.action_users)
                .HasForeignKey(sc => sc.id_action);

            modelBuilder.Entity<Action_Product>()
                .HasOne<Module>(sc => sc.module)
                .WithMany(s => s.action_modules)
                .HasForeignKey(sc => sc.id_module);

            modelBuilder.Entity<Action_Product>()
                .HasOne<Product>(sc => sc.product)
                .WithMany(s => s.action_products)
                .HasForeignKey(sc => sc.id_product);

            modelBuilder.Entity<Password>(o =>
            {
                o.HasKey(x => x.hash).HasName("hash");
            });
            modelBuilder.Entity<Password>().OwnsOne(o => o.password, conf =>
            {
                conf.Property(x => x.value).HasColumnName("password");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}