using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    /// <summary>
    /// The CC and BCC overloads do the same work against a different collection, so both are
    /// exercised by the tests here. A derived class supplies the overload to call and the
    /// collection the addresses are expected to land in.
    /// </summary>
    public abstract class CopyRecipientMethodTests
    {
        protected abstract ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress);

        protected abstract ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<string> emailAddresses);

        protected abstract ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName);

        protected abstract ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName, Encoding encodingType);

        protected abstract ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, MailAddress emailAddress);

        protected abstract ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<MailAddress> emailAddresses);

        /// <summary>
        /// The collection under test: <see cref="MailMessage.CC"/> or <see cref="MailMessage.Bcc"/>.
        /// </summary>
        protected abstract MailAddressCollection RecipientsOf(MailMessage mailMessage);

        [TestMethod]
        public void Test_Recipient_String()
        {
            var message = StartMessage();

            message = AddRecipient(message, "qwe@test.com");
            message = AddRecipient(message, "zxc@test.com");

            var recipients = RecipientsOf(Build(message));

            Assert.AreEqual(2, recipients.Count);
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_Recipient_IEnumerableString()
        {
            var message = StartMessage();

            message = AddRecipients(message, new List<string>
            {
                "qwe@test.com",
                "qwe@test.com", // Duplicate, so should not be added
                "zxc@test.com"
            });

            var recipients = RecipientsOf(Build(message));

            Assert.AreEqual(2, recipients.Count);
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_Recipient_StringString()
        {
            var message = StartMessage();

            message = AddRecipient(message, "qwe@test.com", "Qwe Test");
            message = AddRecipient(message, "zxc@test.com", "Zxc Test");
            message = AddRecipient(message, "zxc@test.com", "Zxc Test"); // Duplicate, should not add

            var recipients = RecipientsOf(Build(message));

            Assert.AreEqual(2, recipients.Count);
            Assert.IsTrue(recipients.ToList().Exists(m => m.DisplayName.Equals("Qwe Test")));
            Assert.IsTrue(recipients.ToList().Exists(m => m.DisplayName.Equals("Zxc Test")));
        }

        [TestMethod]
        public void Test_Recipient_StringStringEncoding()
        {
            var message = StartMessage();

            message = AddRecipient(message, "qwe@test.com", "Qwe Test", Encoding.UTF8);
            message = AddRecipient(message, "zxc@test.com", "Zxc Test", Encoding.UTF8);
            message = AddRecipient(message, "zxc@test.com", "Zxc Test", Encoding.UTF8); // Duplicate, should not add

            var recipients = RecipientsOf(Build(message));

            Assert.AreEqual(2, recipients.Count);
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_Recipient_MailAddress()
        {
            var message = StartMessage();

            message = AddRecipient(message, new MailAddress("qwe@test.com", "Qwe Test"));
            message = AddRecipient(message, new MailAddress("zxc@test.com", "Zxc Test"));

            var recipients = RecipientsOf(Build(message));

            Assert.AreEqual(2, recipients.Count);
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_Recipient_IEnumerableMailAddress()
        {
            var message = StartMessage();

            message = AddRecipients(message, new List<MailAddress>
            {
                new MailAddress("qwe@test.com"),
                new MailAddress("qwe@test.com"), // Duplicate, so should not be added
                new MailAddress("zxc@test.com")
            });

            var recipients = RecipientsOf(Build(message));

            Assert.AreEqual(2, recipients.Count);
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.IsTrue(recipients.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [TestMethod]
        public void Test_Recipient_DifferingOnlyInCase_IsTreatedAsDuplicate()
        {
            var message = StartMessage();

            message = AddRecipient(message, "qwe@test.com");
            message = AddRecipient(message, "QWE@Test.com");

            Assert.AreEqual(1, RecipientsOf(Build(message)).Count);
        }

        [TestMethod]
        public void Test_Recipient_SameAddressWithDisplayName_IsTreatedAsDuplicate()
        {
            var message = StartMessage();

            message = AddRecipient(message, "qwe@test.com");
            message = AddRecipient(message, "Qwe Test <qwe@test.com>");

            Assert.AreEqual(1, RecipientsOf(Build(message)).Count);
        }

        private static ICanAddToCcBccOrSubject StartMessage()
        {
            return FluentMailMessage
                .CreateMailMessage()
                .From("from@test.com")
                .To("asd@test.com");
        }

        private static MailMessage Build(ICanAddToCcBccOrSubject message)
        {
            return message
                .Subject("test")
                .Body("This is the email body")
                .Build();
        }
    }
}
