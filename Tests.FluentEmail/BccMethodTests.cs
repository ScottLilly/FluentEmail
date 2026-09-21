using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class BccMethodTests : CopyRecipientMethodTests
    {
        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress) =>
            message.BCC(emailAddress);

        protected override ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<string> emailAddresses) =>
            message.BCC(emailAddresses);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName) =>
            message.BCC(emailAddress, displayName);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName, Encoding encodingType) =>
            message.BCC(emailAddress, displayName, encodingType);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, MailAddress emailAddress) =>
            message.BCC(emailAddress);

        protected override ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<MailAddress> emailAddresses) =>
            message.BCC(emailAddresses);

        protected override MailAddressCollection RecipientsOf(MailMessage mailMessage) =>
            mailMessage.Bcc;
    }
}
