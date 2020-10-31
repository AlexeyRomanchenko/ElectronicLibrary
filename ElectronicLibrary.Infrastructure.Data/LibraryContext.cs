using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Core.Library;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ElectronicLibrary.Infrastructure.Data
{
    public class LibraryContext: IdentityDbContext<User>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElectricLibrary;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public LibraryContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>(
                b=>b.Property(e=>e.Status)
                .HasConversion(b=>b.ToString(),
                s=>GetStatus(s)));
            modelBuilder.Entity<Book>().HasOne(e => e.Genre).WithMany(b=>b.Books);
            modelBuilder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles").HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins").HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens").HasKey(e => e.UserId);


        }
        private Status GetStatus(string status)
        {
            return Enum.TryParse<Status>(status, out Status _status) ? _status : Status.Booking;
        }
    }  
}
