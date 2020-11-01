﻿using ElectronicLibrary.Domain.Core;
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
        public DbSet<Comment> Comments { get; set; }
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
       
            //modelBuilder.Entity<Book>().HasOne(e => e.Genre).WithMany(b=>b.Books);
            modelBuilder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles").HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins").HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens").HasKey(e => e.UserId);

            modelBuilder.Entity<Genre>().HasKey(e => e.Id);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                 new IdentityRole
                 {
                     Name = "Moderator",
                     NormalizedName = "MODERATOR"
                 }
                );
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Programming"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Sci-fi"
                },
                new Genre
                {
                    Id = 3,
                    Name = "Detective"
                }
                );
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Firstname = "Jeffrey",
                    Lastname = "Richter"
                },
                new Author
                {
                    Id = 2,
                    Firstname = "Vicktor Marie",
                    Lastname = "Hugo"
                },
                new Author
                {
                    Id = 3,
                    Firstname = "Artur Konan",
                    Lastname = "Doyle"
                }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                Id = 1,
                AuthorId = 1,
                GenreId = 1,
                Name = ".NET via CLR",
                PublishYear = new DateTime(2016, 1, 1),
                TotalAmount = 3
                },
                new Book
                {
                    Id = 2,
                    AuthorId = 3,
                    GenreId = 3,
                    Name = "Sherlock Holms",
                    PublishYear = new DateTime(1860, 1, 1),
                    TotalAmount = 2
                },
                new Book
                {
                    Id = 3,
                    AuthorId = 2,
                    GenreId = 3,
                    Name = "Outcasts",
                    PublishYear = new DateTime(1860, 1, 1),
                    TotalAmount = 1
                }
                );

        }
        private Status GetStatus(string status)
        {
            return Enum.TryParse<Status>(status, out Status _status) ? _status : Status.Booking;
        }
    }  
}
