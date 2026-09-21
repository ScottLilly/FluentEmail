using System.Net.Mime;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class BodyMethodTests
    {
        [TestMethod]
        public void Test_Body_String()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual("This is the email body", mailMessage.Body);
        }

        [TestMethod]
        public void Test_Body_StringEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body", Encoding.UTF8)
                    .Build();

            Assert.AreEqual("This is the email body", mailMessage.Body);
            Assert.AreEqual(Encoding.UTF8, mailMessage.BodyEncoding);
        }

        [TestMethod]
        public void Test_Body_StringTransferEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body", TransferEncoding.Base64)
                    .Build();

            Assert.AreEqual("This is the email body", mailMessage.Body);
            Assert.AreEqual(TransferEncoding.Base64, mailMessage.BodyTransferEncoding);
        }

        [TestMethod]
        public void Test_Body_StringEncodingTransferEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body", Encoding.UTF8, TransferEncoding.QuotedPrintable)
                    .Build();

            Assert.AreEqual("This is the email body", mailMessage.Body);
            Assert.AreEqual(Encoding.UTF8, mailMessage.BodyEncoding);
            Assert.AreEqual(TransferEncoding.QuotedPrintable, mailMessage.BodyTransferEncoding);
        }
    }
}
