using ElectronicLibrary.Domain.Core.Library;
using ElectronicLibrary.Domain.Interfaces;
using ElectronicLibrary.Services.Interfaces;
using ElectronicLibrary.Services.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectronicLibraryWebApp.Jobs
{
    public class ExpiredNotificationJob : IJob
    {
        private IBookingRepository<Booking> _repository;
        private IEmailService _emailService;
        public ExpiredNotificationJob(
            IBookingRepository<Booking> repository,
            IEmailService emailService
            )
        {
            _repository = repository;
            _emailService = emailService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            IEnumerable<BookingNotification> notifications = await _repository.GetExpiredUserEmailsAsync();
            foreach (var notification in notifications)
            {
                string _message = $"Hello, you took a book {notification.Book} in {notification.BookingDate} in our library, please return it";
                string _subject = $"Library notification about book {notification.Book}";
                await _emailService.SendAsync(notification.Email, _subject, _message);
                await _repository.SetBookingAsNotifiedAsync(notification.BookingId);
            }
        }
    }
}
