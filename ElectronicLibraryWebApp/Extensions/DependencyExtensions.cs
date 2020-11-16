using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Infrastructure.Data;
using ElectronicLibrary.Infrastructure.Data.Repositories;
using ElectronicLibraryWebApp.Helpers;
using ElectronicLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ElectronicLibrary.Infrastructure.Business;
using Microsoft.EntityFrameworkCore;
using ElectronicLibrary.Services;

namespace ElectronicLibraryWebApp.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ElectricLibrary;Trusted_Connection=True;MultipleActiveResultSets=true");
            });
            services.AddTransient<UserManager<User>>();
            services.AddTransient<SignInManager<User>>();
            services.AddTransient<RoleManager<IdentityRole>>();

            services.AddTransient<JWTHelper>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<LibraryContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IImageService, ImageService>();
            
            services.AddTransient<IBookRepository<Book>, BookRepository>();
            services.AddTransient<IBookingRepository<Booking>, BookingRepository>();
            services.AddTransient<ICommentRepository<Comment>, CommentsRepository>();
            services.AddTransient<IRepository<Author>, AuthorRepository>();
            services.AddTransient<IRepository<Genre>, GenreRepository>();

            services.AddTransient<IBookingManager, BookingManager>();
            services.AddTransient<IBookManager, BookManager>();

        }
    }
}
