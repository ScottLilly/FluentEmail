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
		private readonly HashSet<string> _attachmentFileNames = new HashSet<string>();

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

		#region From methods

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

		#endregion

		#region To methods

		public ICanAddToCcBccOrSubject To(string emailAddress)
        {
            var existingAddress =
                _mailMessage.To
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

            if (existingAddress == null)
            {
				_mailMessage.To.Add(new MailAddress(emailAddress));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddresses)
		{
            foreach (string emailAddress in emailAddresses)
            {
                var existingAddress =
                    _mailMessage.To
                        .FirstOrDefault(e => e.Address.Matches(emailAddress));

                if (existingAddress == null)
                {
                    _mailMessage.To.Add(new MailAddress(emailAddress));
                }
            }

			return this;
		}

		public ICanAddToCcBccOrSubject To(string emailAddress, string displayName)
		{
            var existingAddress =
                _mailMessage.To
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

			if (existingAddress == null)
            {
                _mailMessage.To.Add(new MailAddress(emailAddress, displayName));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType)
		{
            var existingAddress =
                _mailMessage.To
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

            if (existingAddress == null)
            {
                _mailMessage.To.Add(new MailAddress(emailAddress, displayName, encodingType));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject To(MailAddress emailAddress)
		{
            var existingAddress =
                _mailMessage.To
                    .FirstOrDefault(e => e.Address.Matches(emailAddress.Address));

            if (existingAddress == null)
            {
                _mailMessage.To.Add(emailAddress);
            }

			return this;
		}

		public ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddresses)
		{
            foreach (var emailAddress in emailAddresses)
            {
                var existingAddress =
                    _mailMessage.To
                        .FirstOrDefault(e => e.Address.Matches(emailAddress.Address));

                if (existingAddress == null)
                {
                    _mailMessage.To.Add(emailAddress);
                }
            }

			return this;
		}

		#endregion

		#region CC methods

		public ICanAddToCcBccOrSubject CC(string emailAddress)
		{
            var existingAddress =
                _mailMessage.CC
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));
			
            if (existingAddress == null)
            {
                _mailMessage.CC.Add(new MailAddress(emailAddress));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject CC(IEnumerable<string> emailAddresses)
		{
            foreach (string emailAddress in emailAddresses)
            {
                var existingAddress =
                    _mailMessage.CC
                        .FirstOrDefault(e => e.Address.Matches(emailAddress));

                if (existingAddress == null)
                {
                    _mailMessage.CC.Add(new MailAddress(emailAddress));
                }
            }

			return this;
		}

		public ICanAddToCcBccOrSubject CC(string emailAddress, string displayName)
		{
            var existingAddress =
                _mailMessage.CC
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

            if (existingAddress == null)
            {
                _mailMessage.CC.Add(new MailAddress(emailAddress, displayName));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject CC(string emailAddress, string displayName, Encoding encodingType)
		{
            var existingAddress =
                _mailMessage.CC
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

            if (existingAddress == null)
            {
                _mailMessage.CC.Add(new MailAddress(emailAddress, displayName, encodingType));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject CC(MailAddress emailAddress)
		{
            var existingAddress =
                _mailMessage.CC
                    .FirstOrDefault(e => e.Address.Matches(emailAddress.Address));

            if (existingAddress == null)
            {
                _mailMessage.CC.Add(emailAddress);
            }

			return this;
		}

		public ICanAddToCcBccOrSubject CC(IEnumerable<MailAddress> emailAddresses)
		{
            foreach (MailAddress emailAddress in emailAddresses)
            {
                var existingAddress =
                    _mailMessage.CC
                        .FirstOrDefault(e => e.Address.Matches(emailAddress.Address));

                if (existingAddress == null)
                {
                    _mailMessage.CC.Add(emailAddress);
                }
            }

			return this;
		}

		#endregion

		#region BCC methods

		public ICanAddToCcBccOrSubject BCC(string emailAddress)
		{
            var existingAddress =
                _mailMessage.Bcc
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

            if (existingAddress == null)
            {
                _mailMessage.Bcc.Add(new MailAddress(emailAddress));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject BCC(IEnumerable<string> emailAddresses)
		{
            foreach (var emailAddress in emailAddresses)
            {
                var existingAddress =
                    _mailMessage.Bcc
                        .FirstOrDefault(e => e.Address.Matches(emailAddress));

                if (existingAddress == null)
                {
                    _mailMessage.Bcc.Add(new MailAddress(emailAddress));
                }
            }

			return this;
		}

		public ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName)
		{
            var existingAddress =
                _mailMessage.Bcc
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

            if (existingAddress == null)
            {
                _mailMessage.Bcc.Add(new MailAddress(emailAddress, displayName));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName, Encoding encodingType)
		{
            var existingAddress =
                _mailMessage.Bcc
                    .FirstOrDefault(e => e.Address.Matches(emailAddress));

            if (existingAddress == null)
            {
                _mailMessage.Bcc.Add(new MailAddress(emailAddress, displayName, encodingType));
            }

			return this;
		}

		public ICanAddToCcBccOrSubject BCC(MailAddress emailAddress)
		{
            var existingAddress =
                _mailMessage.Bcc
                    .FirstOrDefault(e => e.Address.Matches(emailAddress.Address));

            if (existingAddress == null)
            {
                _mailMessage.Bcc.Add(emailAddress);
            }

			return this;
		}

		public ICanAddToCcBccOrSubject BCC(IEnumerable<MailAddress> emailAddresses)
		{
            foreach (var emailAddress in emailAddresses)
            {
                var existingAddress =
                    _mailMessage.Bcc
                        .FirstOrDefault(e => e.Address.Matches(emailAddress.Address));

                if (existingAddress == null)
                {
                    _mailMessage.Bcc.Add(emailAddress);
                }
            }

			return this;
		}

		#endregion

		#region Subject methods

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

		#endregion

		#region Body methods

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

		#endregion

		#region Attachments

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

		#endregion

		// Executing function(s)

		#region Build

		public MailMessage Build()
        {
            return _mailMessage;
        }

		#endregion

		// Supporting function(s)

		#region Private method(s)

		private void AddAttachmentIfNew(string filename)
		{
			if (_attachmentFileNames.Add(filename.ToLower()))
			{
				_mailMessage.Attachments.Add(new Attachment(filename));
			}
		}

		private void AddAttachmentIfNew(string filename, string mimeType)
		{
			if (_attachmentFileNames.Add(filename.ToLower()))
			{
				_mailMessage.Attachments.Add(new Attachment(filename, mimeType));
			}
		}

		private void AddAttachmentIfNew(string filename, ContentType contentType)
		{
			if (_attachmentFileNames.Add(filename.ToLower()))
			{
				_mailMessage.Attachments.Add(new Attachment(filename, contentType));
			}
		}

		#endregion
	}

	// Interfaces
	public interface IMustAddFromAddress
	{
		IMustAddToAddress From(string emailAddress);
		IMustAddToAddress From(string emailAddress, string displayName);
		IMustAddToAddress From(string emailAddress, string displayName, Encoding encodingType);
		IMustAddToAddress From(MailAddress emailAddress);
	}

	public interface IMustAddToAddress
	{
		ICanAddToCcBccOrSubject To(string emailAddress);
		ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddresses);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject To(MailAddress emailAddress);
		ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddresses);
	}

	public interface ICanAddToCcBccOrSubject
	{
		ICanAddToCcBccOrSubject To(string emailAddress);
		ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddresses);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject To(MailAddress emailAddress);
		ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddresses);
		ICanAddToCcBccOrSubject CC(string emailAddress);
		ICanAddToCcBccOrSubject CC(IEnumerable<string> emailAddresses);
		ICanAddToCcBccOrSubject CC(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject CC(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject CC(MailAddress emailAddress);
		ICanAddToCcBccOrSubject CC(IEnumerable<MailAddress> emailAddresses);
		ICanAddToCcBccOrSubject BCC(string emailAddress);
		ICanAddToCcBccOrSubject BCC(IEnumerable<string> emailAddresses);
		ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject BCC(MailAddress emailAddress);
		ICanAddToCcBccOrSubject BCC(IEnumerable<MailAddress> emailAddresses);
		IMustAddBody Subject(string subject);
		IMustAddBody Subject(string subject, Encoding encodingType);
	}

	public interface IMustAddBody
	{
		ICanAddAttachmentOrBuild Body(string body);
		ICanAddAttachmentOrBuild Body(string body, Encoding encodingType);
	}

	public interface ICanAddAttachmentOrBuild
	{
		ICanAddAttachmentOrBuild AddAttachment(string filename);
		ICanAddAttachmentOrBuild AddAttachment(string filename, string mimeType);
		ICanAddAttachmentOrBuild AddAttachment(string filename, ContentType contentType);
		ICanAddAttachmentOrBuild AddAttachment(Stream stream, string name);
		ICanAddAttachmentOrBuild AddAttachment(Stream stream, string name, string mimeType);
		ICanAddAttachmentOrBuild AddAttachment(Stream stream, ContentType contentType);
		ICanAddAttachmentOrBuild AddAttachments(IEnumerable<string> filenames);
		MailMessage Build();
	}

}
