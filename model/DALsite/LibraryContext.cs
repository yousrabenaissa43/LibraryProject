using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using BLsite; 

namespace DALsite
{
    public class LibraryContext : DbContext
    {
        public DbSet<SpellBook>? SpellBooks { get; set; }
        public DbSet<RecipeBook>? RecipeBooks { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Loan>? Loans { get; set; }
        public DbSet<LibraryMember>? LibraryMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your connection string to the database
            optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BooksDB;Integrated Security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply EnumToStringConverter for the MagicType enum
            modelBuilder.Entity<SpellBook>()
                .Property(b => b.magicType)
                .HasConversion(new EnumToStringConverter<MagicType>());
        }

    }

    }

