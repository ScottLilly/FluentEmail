using System.Net.Mail;
using System.Text;
using FluentEmail;
using Xunit;

namespace Test.FluentEmail
{
    public class Test_FromMethods
    {
        [Fact]
        public void Test_From_String()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
        }

        [Fact]
        public void Test_From_StringString()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From")
                    .To("qwe@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal("John From", mailMessage.From.DisplayName);
        }

        [Fact]
        public void Test_From_StringStringEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From", Encoding.UTF8)
                    .To("qwe@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal("John From", mailMessage.From.DisplayName);
            // TODO: Pass in UTF-16 name and encoding, and verify
        }

        [Fact]
        public void Test_From_MailAddress()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From(new MailAddress("from@test.com", "John From"))
                    .To("qwe@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal("John From", mailMessage.From.DisplayName);
        }
    }
}
