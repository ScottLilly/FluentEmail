using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class CcMethodTests : CopyRecipientMethodTests
    {
        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress) =>
            message.CC(emailAddress);

        protected override ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<string> emailAddresses) =>
            message.CC(emailAddresses);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName) =>
            message.CC(emailAddress, displayName);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName, Encoding encodingType) =>
            message.CC(emailAddress, displayName, encodingType);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, MailAddress emailAddress) =>
            message.CC(emailAddress);

        protected override ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<MailAddress> emailAddresses) =>
            message.CC(emailAddresses);

        protected override MailAddressCollection RecipientsOf(MailMessage mailMessage) =>
            mailMessage.CC;
    }
}
