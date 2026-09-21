using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class FromMethodTests
    {
        [TestMethod]
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

            Assert.IsNotNull(mailMessage.From);
            Assert.AreEqual("from@test.com", mailMessage.From.Address);
        }

        [TestMethod]
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

            Assert.IsNotNull(mailMessage.From);
            Assert.AreEqual("from@test.com", mailMessage.From.Address);
            Assert.AreEqual("John From", mailMessage.From.DisplayName);
        }

        [TestMethod]
        public void Test_From_StringStringEncoding()
        {
            // The accented characters are the point of the test: they are what forces the
            // display name to be encoded rather than written as-is.
            const string DISPLAY_NAME = "José Müller";

            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", DISPLAY_NAME, Encoding.Unicode)
                    .To("qwe@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.IsNotNull(mailMessage.From);
            Assert.AreEqual("from@test.com", mailMessage.From.Address);
            Assert.AreEqual(DISPLAY_NAME, mailMessage.From.DisplayName);

            // MailAddress does not expose the encoding it was constructed with, so the only
            // way to prove the encoding was passed through is to look at the written message.
            // UTF-16 is deliberately not the default: without the encoding argument this same
            // display name is written as "=?utf-8?", so the assertion would fail.
            StringAssert.Contains(WriteMessage(mailMessage), "=?utf-16?");
        }

        [TestMethod]
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

            Assert.IsNotNull(mailMessage.From);
            Assert.AreEqual("from@test.com", mailMessage.From.Address);
            Assert.AreEqual("John From", mailMessage.From.DisplayName);
        }

        // Writes the message to a throwaway pickup directory and returns its raw text,
        // headers included, which is the only public way to see how a MailAddress encoded
        // its display name.
        private static string WriteMessage(MailMessage mailMessage)
        {
            string pickupDirectory =
                Path.Combine(Path.GetTempPath(),
                    "Tests.FluentEmail." + Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(pickupDirectory);

            try
            {
                using var client =
                    new SmtpClient
                    {
                        DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                        PickupDirectoryLocation = pickupDirectory
                    };

                client.Send(mailMessage);

                return File.ReadAllText(Directory.GetFiles(pickupDirectory).Single());
            }
            finally
            {
                Directory.Delete(pickupDirectory, true);
            }
        }
    }
}
