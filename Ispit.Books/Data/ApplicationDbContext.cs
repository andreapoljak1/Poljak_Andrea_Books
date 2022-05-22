using Ispit.Books.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ispit.Books.Data
{

    // Ručno dodana klasa za ubacivanje prilagođenih svojstava u tablicu AspNetUsers
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Address { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dodatno podešavanje ograničenja između Book i Author
            modelBuilder
                .Entity<Book>()
                .HasOne<Author>(o => o.Author)
                .WithMany(e => e.Books)
                .HasForeignKey(o => o.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dodatno ograničenje između Book i Publisher
            modelBuilder
                .Entity<Book>()
                .HasOne(eu => eu.Publisher)
                .WithMany(e => e.Books)
                .HasForeignKey(o => o.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Ivana",
                    LastName = "Brlić - Mažuranić",
                    DateOfBirth = new DateTime(1874, 4, 18),
                    Description = "Hrvatska književnica koja je u Hrvatskoj i u svijetu priznata kao jedna od najznačajnijih spisateljica za djecu."
                },
                 new Author
                 {
                     Id = 2,
                     FirstName = "Pero",
                     LastName = "Budak",
                     DateOfBirth = new DateTime(1917, 6, 21),
                     Description = "Hrvatski kazališni i filmski glumac, dramatik, komediograf, romanopisac, pjesnik, dječji pisac i prvi direktor kazališta 'Gavella'"
                 },
                  new Author
                  {
                      Id = 3,
                      FirstName = "Slavko",
                      LastName = "Kolar",
                      DateOfBirth = new DateTime(1891, 12, 1),
                      Description = "Hrvatski književnik i filmski scenarist. Najpoznatija djela su mu: Breza (koju je i sam režirao, uz pomoć redatelja Ante Babaje) i Svoga tela gospodar.."
                  },
                   new Author
                   {
                       Id = 4,
                       FirstName = "Grigor",
                       LastName = "Vitez",
                       DateOfBirth = new DateTime(1911, 2, 15),
                       Description = "Smatra se začetnikom moderne hrvatske književnosti za djecu.[5] Autor je brojnih pjesama i priča namijenjenima djeci, te je autor i mnogobrojnih članaka u časopisima. "
                   },
                    new Author
                    {
                        Id = 5,
                        FirstName = "Gustav",
                        LastName = "Krklec",
                        DateOfBirth = new DateTime(1899, 6, 23),
                        Description = "Hrvatski književnik, prevoditelj s ruskog, češkog, slovenskog i njemačkog jezika, prvi predsjednik Društva hrvatskih književnih prevodilaca. Jedan od najvažnijih hrvatskih književnika 20. stoljeća."
                    }
            );
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher
                {
                    Id = 1,
                    Title = "Dječja knjiga d.o.o., Zagreb",
                    Description = "Nakladničkom djelatnošću bavi se od 1998. godine"

                },
                new Publisher
                {
                    Id = 2,
                    Title = "Mozaik knjiga",
                    Description = "Mozaik knjiga je jedna od najvećih nakladničkih kuća u Hrvatskoj koja objavljuje popularnu beletristiku za odrasle, djecu i mlade, ilustrirane enciklopedije, priručnike za odgoj i roditeljstvo, kuharice, poslovne knjige i filozofske tekstove te lektirni program."

                },
                 new Publisher
                 {
                     Id = 3,
                     Title = "Školska knjiga",
                     Description = "Školska knjiga je jedna od najvećih izdavačkih kuća u Hrvatskoj. Sjedište joj je u Zagrebu. Školska knjiga je objavila preko 22 000 naslova u nakladi od 415 mil. primjeraka."

                 }

            );
        }

    }
}