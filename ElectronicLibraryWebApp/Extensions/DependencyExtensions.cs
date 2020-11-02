using ElectronicLibrary.Domain.Core;
using ElectronicLibrary.Domain.Core.Identity;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Infrastructure.Data;
using ElectronicLibrary.Infrastructure.Data.Repositories;
using ElectronicLibraryWebApp.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicLibraryWebApp.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<LibraryContext>();

            services.AddTransient<UserManager<User>>();
            services.AddTransient<SignInManager<User>>();
            services.AddTransient<JWTHelper>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<LibraryContext>();
            
            services.AddTransient<IBookRepository<Book>, BookRepository>();
        }
    }
}
