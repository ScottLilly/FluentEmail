using System.Net.Mail;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class InstantiatingTests
    {
        [TestMethod]
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

            Assert.IsNotNull(mailMessage);
            Assert.IsInstanceOfType<MailMessage>(mailMessage);
            Assert.IsFalse(mailMessage.IsBodyHtml);
        }

        [TestMethod]
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

            Assert.IsNotNull(mailMessage);
            Assert.IsInstanceOfType<MailMessage>(mailMessage);
            Assert.IsTrue(mailMessage.IsBodyHtml);
        }

        [TestMethod]
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

            Assert.AreEqual(MailPriority.Normal, mailMessage.Priority);
        }

        [TestMethod]
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

            Assert.AreEqual(MailPriority.Low, mailMessage.Priority);
        }

        [TestMethod]
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

            Assert.AreEqual(MailPriority.Normal, mailMessage.Priority);
        }

        [TestMethod]
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

            Assert.AreEqual(MailPriority.High, mailMessage.Priority);
        }
    }
}
