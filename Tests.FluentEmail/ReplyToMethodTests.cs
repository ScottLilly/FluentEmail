using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class ReplyToMethodTests : CopyRecipientMethodTests
    {
        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress) =>
            message.ReplyTo(emailAddress);

        protected override ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<string> emailAddresses) =>
            message.ReplyTo(emailAddresses);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName) =>
            message.ReplyTo(emailAddress, displayName);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, string emailAddress, string displayName, Encoding encodingType) =>
            message.ReplyTo(emailAddress, displayName, encodingType);

        protected override ICanAddToCcBccOrSubject AddRecipient(
            ICanAddToCcBccOrSubject message, MailAddress emailAddress) =>
            message.ReplyTo(emailAddress);

        protected override ICanAddToCcBccOrSubject AddRecipients(
            ICanAddToCcBccOrSubject message, IEnumerable<MailAddress> emailAddresses) =>
            message.ReplyTo(emailAddresses);

        protected override MailAddressCollection RecipientsOf(MailMessage mailMessage) =>
            mailMessage.ReplyToList;
    }
}
