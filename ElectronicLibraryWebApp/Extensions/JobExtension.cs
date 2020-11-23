using ElectronicLibraryWebApp.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicLibraryWebApp.Extensions
{
    public static class JobExtension
    {
        public static void AddJobs(this IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                q.SchedulerId = "BookingScheduler";

                q.UseMicrosoftDependencyInjectionScopedJobFactory();

                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });

                q.ScheduleJob<BookingCheckJob>(trigger => trigger
                    .WithIdentity("Combined Configuration Trigger")
                    .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow))
                    .WithDailyTimeIntervalSchedule(x => x.WithInterval(10, IntervalUnit.Second))
                );
                q.ScheduleJob<ExpiredNotificationJob>(trigger => trigger
                   .WithIdentity("Notification users with expired terms")
                   .StartAt(DateBuilder.EvenSecondDate(DateTimeOffset.UtcNow))
                   .WithDailyTimeIntervalSchedule(x => x.WithInterval(50, IntervalUnit.Second))
               );


            });
            services.AddQuartzServer(options =>
            {
                options.WaitForJobsToComplete = true;
            });
        }
    }
}
