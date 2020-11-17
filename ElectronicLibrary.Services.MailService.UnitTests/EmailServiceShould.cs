using System;
using System.Threading.Tasks;
using Xunit;

namespace ElectronicLibrary.Services.MailService.UnitTests
{
    public class EmailServiceShould
    {
        [Theory]
        [InlineData("romanchenko.alek@mail.ru","Test subj", "Some text")]
        public async Task NotThrowException(string email, string subject, string content)
        {
            EmailSender sender = new EmailSender();
            await sender.SendAsync(email, subject, content);
        }
    }
}
