using ClassLibraryLabb4;
using Microsoft.EntityFrameworkCore;

namespace API_Labb4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person() { PersonID = 1, Name = "Justin Case", Email = "attorney@law.com", Phone = "0735466834" },
                new Person() { PersonID = 2, Name = "Patrik Skattberg", Email = "patrikskattberg@fakemail.com", Phone = "0761960876"},
                new Person() { PersonID = 3, Name = "Mark Hammil", Email = "thismail@mail.com", Phone = "0737754669"});

            modelBuilder.Entity<Interest>().HasData(
                new Interest() { InterestID = 1, Name = "Dancing", Description = "Move that body" },
                new Interest() { InterestID = 2, Name = "Gaming", Description = "Play games" },
                new Interest() { InterestID = 3, Name = "Fishing", Description = "Hunting while standing still" });

            modelBuilder.Entity<Interest>()
                .HasMany(l => l.Links)
                .WithOne(i => i.Interest)
                .HasForeignKey(i => i.InterestID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Link>().HasData(
                new Link() { LinkID = 1, URL = "https://www.youtube.com/watch?v=aKv54g_v1mo&list=RD71XngoEKuGk&index=8", InterestID = 1 },
                new Link() { LinkID = 2, URL = "https://store.steampowered.com/", InterestID = 2 },
                new Link() { LinkID = 3, URL = "https://en.wikipedia.org/wiki/Fishing", InterestID = 3 });
        }
    }
}
