using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class ToMethodTests
    {
        [TestMethod]
        public void Test_To_String()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .To("zxc@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(2, mailMessage.To.Count);
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_To_IEnumerableString()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To(new List<string>
                    {
                        "qwe@test.com",
                        "qwe@test.com", // Duplicate, so should not be added
                        "zxc@test.com"
                    })
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(2, mailMessage.To.Count);
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_To_StringString()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com", "Qwe Test")
                    .To("zxc@test.com", "Zxc Test")
                    .To("zxc@test.com", "Zxc Test") // Duplicate, should not add
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(2, mailMessage.To.Count);
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.DisplayName.Equals("Qwe Test")));
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.DisplayName.Equals("Zxc Test")));
        }

        [TestMethod]
        public void Test_To_StringStringEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com", "Qwe Test", Encoding.UTF8)
                    .To("zxc@test.com", "Zxc Test", Encoding.UTF8)
                    .To("zxc@test.com", "Zxc Test", Encoding.UTF8) // Duplicate, should not add
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(2, mailMessage.To.Count);
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_To_MailAddress()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To(new MailAddress("qwe@test.com", "Qwe Test"))
                    .To(new MailAddress("zxc@test.com", "Zxc Test"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(2, mailMessage.To.Count);
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_To_IEnumerableMailAddress()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To(new List<MailAddress>
                    {
                        new MailAddress("qwe@test.com"),
                        new MailAddress("qwe@test.com"), // Duplicate, so should not be added
                        new MailAddress("zxc@test.com")
                    })
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(2, mailMessage.To.Count);
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(mailMessage.To.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_To_DifferingOnlyInCase_IsTreatedAsDuplicate()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .To("QWE@Test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(1, mailMessage.To.Count);
        }

        [TestMethod]
        public void Test_To_SameAddressWithDisplayName_IsTreatedAsDuplicate()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .To("Qwe Test <qwe@test.com>")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.AreEqual(1, mailMessage.To.Count);
        }
    }
}
