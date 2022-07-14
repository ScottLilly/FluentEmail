using System.Net.Mail;
using FluentEmail;
using Xunit;

namespace Test.FluentEmail
{
    public class Test_InstantiatingMethods
    {
        [Fact]
        public void Test_CreateMailMessage()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.False(mailMessage.IsBodyHtml);
        }

        [Fact]
        public void Test_CreateHtmlMailMessage()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.True(mailMessage.IsBodyHtml);
        }
    }
}
