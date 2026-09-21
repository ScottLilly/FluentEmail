using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.IO;
using System.Net.Mime;

namespace FluentEmail
{
    public class FluentMailMessage : IMustAddFromAddress, IMustAddToAddress,
        ICanAddToCcBccOrSubject, IMustAddBody, ICanAddAttachmentOrBuild
    {
        private readonly MailMessage _mailMessage = new MailMessage();
        private readonly HashSet<string> _attachmentFileNames =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        // Private constructor
        private FluentMailMessage(bool isHtml, MailPriority priority = MailPriority.Normal)
        {
            _mailMessage.IsBodyHtml = isHtml;
            _mailMessage.Priority = priority;
        }

        // Instantiating functions

        public static IMustAddFromAddress CreateMailMessage(MailPriority priority = MailPriority.Normal)
        {
            return new FluentMailMessage(false, priority);
        }

        public static IMustAddFromAddress CreateHtmlMailMessage(MailPriority priority = MailPriority.Normal)
        {
            return new FluentMailMessage(true, priority);
        }

        // Chaining functions

        public IMustAddToAddress From(string emailAddress)
        {
            _mailMessage.From = new MailAddress(emailAddress);

            return this;
        }

        public IMustAddToAddress From(string emailAddress, string displayName)
        {
            _mailMessage.From = new MailAddress(emailAddress, displayName);

            return this;
        }

        public IMustAddToAddress From(string emailAddress, string displayName, Encoding encodingType)
        {
            _mailMessage.From = new MailAddress(emailAddress, displayName, encodingType);

            return this;
        }

        public IMustAddToAddress From(MailAddress emailAddress)
        {
            _mailMessage.From = emailAddress;

            return this;
        }

        public ICanAddToCcBccOrSubject To(string emailAddress)
        {
            return AddIfNew(_mailMessage.To, new MailAddress(emailAddress));
        }

        public ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddresses)
        {
            return AddIfNew(_mailMessage.To, emailAddresses.Select(e => new MailAddress(e)));
        }

        public ICanAddToCcBccOrSubject To(string emailAddress, string displayName)
        {
            return AddIfNew(_mailMessage.To, new MailAddress(emailAddress, displayName));
        }

        public ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType)
        {
            return AddIfNew(_mailMessage.To, new MailAddress(emailAddress, displayName, encodingType));
        }

        public ICanAddToCcBccOrSubject To(MailAddress emailAddress)
        {
            return AddIfNew(_mailMessage.To, emailAddress);
        }

        public ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddresses)
        {
            return AddIfNew(_mailMessage.To, emailAddresses);
        }

        public ICanAddToCcBccOrSubject CC(string emailAddress)
        {
            return AddIfNew(_mailMessage.CC, new MailAddress(emailAddress));
        }

        public ICanAddToCcBccOrSubject CC(IEnumerable<string> emailAddresses)
        {
            return AddIfNew(_mailMessage.CC, emailAddresses.Select(e => new MailAddress(e)));
        }

        public ICanAddToCcBccOrSubject CC(string emailAddress, string displayName)
        {
            return AddIfNew(_mailMessage.CC, new MailAddress(emailAddress, displayName));
        }

        public ICanAddToCcBccOrSubject CC(string emailAddress, string displayName, Encoding encodingType)
        {
            return AddIfNew(_mailMessage.CC, new MailAddress(emailAddress, displayName, encodingType));
        }

        public ICanAddToCcBccOrSubject CC(MailAddress emailAddress)
        {
            return AddIfNew(_mailMessage.CC, emailAddress);
        }

        public ICanAddToCcBccOrSubject CC(IEnumerable<MailAddress> emailAddresses)
        {
            return AddIfNew(_mailMessage.CC, emailAddresses);
        }

        public ICanAddToCcBccOrSubject BCC(string emailAddress)
        {
            return AddIfNew(_mailMessage.Bcc, new MailAddress(emailAddress));
        }

        public ICanAddToCcBccOrSubject BCC(IEnumerable<string> emailAddresses)
        {
            return AddIfNew(_mailMessage.Bcc, emailAddresses.Select(e => new MailAddress(e)));
        }

        public ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName)
        {
            return AddIfNew(_mailMessage.Bcc, new MailAddress(emailAddress, displayName));
        }

        public ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName, Encoding encodingType)
        {
            return AddIfNew(_mailMessage.Bcc, new MailAddress(emailAddress, displayName, encodingType));
        }

        public ICanAddToCcBccOrSubject BCC(MailAddress emailAddress)
        {
            return AddIfNew(_mailMessage.Bcc, emailAddress);
        }

        public ICanAddToCcBccOrSubject BCC(IEnumerable<MailAddress> emailAddresses)
        {
            return AddIfNew(_mailMessage.Bcc, emailAddresses);
        }

        public ICanAddToCcBccOrSubject ReplyTo(string emailAddress)
        {
            return AddIfNew(_mailMessage.ReplyToList, new MailAddress(emailAddress));
        }

        public ICanAddToCcBccOrSubject ReplyTo(IEnumerable<string> emailAddresses)
        {
            return AddIfNew(_mailMessage.ReplyToList, emailAddresses.Select(e => new MailAddress(e)));
        }

        public ICanAddToCcBccOrSubject ReplyTo(string emailAddress, string displayName)
        {
            return AddIfNew(_mailMessage.ReplyToList, new MailAddress(emailAddress, displayName));
        }

        public ICanAddToCcBccOrSubject ReplyTo(string emailAddress, string displayName, Encoding encodingType)
        {
            return AddIfNew(_mailMessage.ReplyToList, new MailAddress(emailAddress, displayName, encodingType));
        }

        public ICanAddToCcBccOrSubject ReplyTo(MailAddress emailAddress)
        {
            return AddIfNew(_mailMessage.ReplyToList, emailAddress);
        }

        public ICanAddToCcBccOrSubject ReplyTo(IEnumerable<MailAddress> emailAddresses)
        {
            return AddIfNew(_mailMessage.ReplyToList, emailAddresses);
        }

        public IMustAddBody Subject(string subject)
        {
            _mailMessage.Subject = subject;

            return this;
        }

        public IMustAddBody Subject(string subject, Encoding encodingType)
        {
            _mailMessage.Subject = subject;
            _mailMessage.SubjectEncoding = encodingType;

            return this;
        }

        public ICanAddAttachmentOrBuild Body(string body)
        {
            _mailMessage.Body = body;

            return this;
        }

        public ICanAddAttachmentOrBuild Body(string body, Encoding encodingType)
        {
            _mailMessage.Body = body;
            _mailMessage.BodyEncoding = encodingType;

            return this;
        }

        public ICanAddAttachmentOrBuild Body(string body, TransferEncoding transferEncoding)
        {
            _mailMessage.Body = body;
            _mailMessage.BodyTransferEncoding = transferEncoding;

            return this;
        }

        public ICanAddAttachmentOrBuild Body(string body, Encoding encodingType,
            TransferEncoding transferEncoding)
        {
            _mailMessage.Body = body;
            _mailMessage.BodyEncoding = encodingType;
            _mailMessage.BodyTransferEncoding = transferEncoding;

            return this;
        }

        public ICanAddAttachmentOrBuild AddAttachment(string filename)
        {
            AddAttachmentIfNew(filename);

            return this;
        }

        public ICanAddAttachmentOrBuild AddAttachment(string filename,
            string mimeType)
        {
            AddAttachmentIfNew(filename, mimeType);

            return this;
        }

        public ICanAddAttachmentOrBuild AddAttachment(string filename,
            ContentType contentType)
        {
            AddAttachmentIfNew(filename, contentType);

            return this;
        }

        // The three Stream overloads below take ownership of the caller's stream: it is disposed
        // when the built MailMessage is, and not before. That is also why they deliberately skip
        // the duplicate check the filename overloads use. Dropping a stream the caller has
        // already opened would leak it, because only an attachment that is added gets disposed
        // with the MailMessage. An overload that ever declines a stream has to dispose it. See
        // docs/ARCHITECTURE.md.

        public ICanAddAttachmentOrBuild AddAttachment(Stream stream,
            string name)
        {
            _mailMessage.Attachments.Add(new Attachment(stream, name));

            return this;
        }

        public ICanAddAttachmentOrBuild AddAttachment(Stream stream,
            string name, string mimeType)
        {
            _mailMessage.Attachments.Add(new Attachment(stream, name, mimeType));

            return this;
        }

        public ICanAddAttachmentOrBuild AddAttachment(Stream stream,
            ContentType contentType)
        {
            _mailMessage.Attachments.Add(new Attachment(stream, contentType));

            return this;
        }

        public ICanAddAttachmentOrBuild AddAttachments(IEnumerable<string> filenames)
        {
            foreach (var filename in filenames)
            {
                AddAttachmentIfNew(filename);
            }

            return this;
        }

        // An AlternateView owns the stream behind its content, the same way a Stream attachment
        // does, so it is disposed with the built MailMessage rather than here.

        public ICanAddAttachmentOrBuild AddAlternateView(AlternateView alternateView)
        {
            _mailMessage.AlternateViews.Add(alternateView);

            return this;
        }

        public ICanAddAttachmentOrBuild AddAlternateView(string content, ContentType contentType)
        {
            _mailMessage.AlternateViews.Add(
                AlternateView.CreateAlternateViewFromString(content, contentType));

            return this;
        }

        public ICanAddAttachmentOrBuild AddAlternateView(string content, Encoding contentEncoding,
            string mediaType)
        {
            _mailMessage.AlternateViews.Add(
                AlternateView.CreateAlternateViewFromString(content, contentEncoding, mediaType));

            return this;
        }

        public ICanAddAttachmentOrBuild AddAlternateViews(IEnumerable<AlternateView> alternateViews)
        {
            foreach (var alternateView in alternateViews)
            {
                _mailMessage.AlternateViews.Add(alternateView);
            }

            return this;
        }

        // Headers are not de-duplicated. A repeated name accumulates, which is what
        // NameValueCollection does and what headers such as Received need.

        public ICanAddAttachmentOrBuild AddHeader(string name, string value)
        {
            _mailMessage.Headers.Add(name, value);

            return this;
        }

        public ICanAddAttachmentOrBuild AddHeaders(IEnumerable<KeyValuePair<string, string>> headers)
        {
            foreach (var header in headers)
            {
                _mailMessage.Headers.Add(header.Key, header.Value);
            }

            return this;
        }

        public ICanAddAttachmentOrBuild DeliveryNotificationOptions(DeliveryNotificationOptions options)
        {
            _mailMessage.DeliveryNotificationOptions = options;

            return this;
        }

        // Executing function(s)

        public MailMessage Build()
        {
            return _mailMessage;
        }

        // Supporting function(s)

        private ICanAddToCcBccOrSubject AddIfNew(MailAddressCollection collection, MailAddress emailAddress)
        {
            if (!collection.Any(existing => existing.Address.Matches(emailAddress.Address)))
            {
                collection.Add(emailAddress);
            }

            return this;
        }

        private ICanAddToCcBccOrSubject AddIfNew(MailAddressCollection collection,
            IEnumerable<MailAddress> emailAddresses)
        {
            foreach (var emailAddress in emailAddresses)
            {
                AddIfNew(collection, emailAddress);
            }

            return this;
        }

        private void AddAttachmentIfNew(string filename)
        {
            if (_attachmentFileNames.Add(filename))
            {
                _mailMessage.Attachments.Add(new Attachment(filename));
            }
        }

        private void AddAttachmentIfNew(string filename, string mimeType)
        {
            if (_attachmentFileNames.Add(filename))
            {
                _mailMessage.Attachments.Add(new Attachment(filename, mimeType));
            }
        }

        private void AddAttachmentIfNew(string filename, ContentType contentType)
        {
            if (_attachmentFileNames.Add(filename))
            {
                _mailMessage.Attachments.Add(new Attachment(filename, contentType));
            }
        }
    }
}
