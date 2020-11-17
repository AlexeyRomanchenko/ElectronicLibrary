using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ElectronicLibrary.WebApp.Scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var callback = new TimerCallback(CheckBookingHelper.Check);
            //Timer launches once per hour
            Timer timer = new Timer(callback, null, 0, 3600*1000);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
