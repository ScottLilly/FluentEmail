using System.Net.Mail;
using FluentEmail;
using Xunit;

namespace Tests.FluentEmail
{
    public class InstantiatingTests
    {
        [Fact]
        public void Test_CreateMailMessage_Default_ReturnsPlainTextMailMessage()
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
        public void Test_CreateHtmlMailMessage_Default_ReturnsHtmlMailMessage()
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

        [Fact]
        public void Test_CreateMailMessage_NoPriority_PriorityIsNormal()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.Normal, mailMessage.Priority);
        }

        [Fact]
        public void Test_CreateMailMessage_PriorityLow_PriorityIsLow()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage(MailPriority.Low)
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.Low, mailMessage.Priority);
        }

        [Fact]
        public void Test_CreateMailMessage_PriorityNormal_PriorityIsNormal()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage(MailPriority.Normal)
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.Normal, mailMessage.Priority);
        }

        [Fact]
        public void Test_CreateMailMessage_PriorityHigh_PriorityIsHigh()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage(MailPriority.High)
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.High, mailMessage.Priority);
        }
    }
}
