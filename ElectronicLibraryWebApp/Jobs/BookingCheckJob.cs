using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicLibraryWebApp.Jobs
{
    public class BookingCheckJob : IJob
    {
        private IBookingRepository<Booking> _repository;
        public BookingCheckJob(IBookingRepository<Booking> repository)
        {
            _repository = repository;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await _repository.CheckExpiredBookingsAsync();
        }
    }
}
