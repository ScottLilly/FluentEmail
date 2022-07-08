using System.ComponentModel;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace FluentEmail
{
	public class FluentMailMessage : IMustAddFromAddress, IMustAddToAddress, ICanAddToCcBccOrSubject, IMustAddBody, ICanAddAttachmentOrBuild
	{
		// Private constructor
		private FluentMailMessage()
		{
		}

		// Instantiating functions
		public static IMustAddFromAddress CreateMailMessage(MailPriority priority = MailPriority.Normal)
		{
			return new FluentMailMessage();
		}

		public static IMustAddFromAddress CreateHtmlMailMessage(MailPriority priority = MailPriority.Normal)
		{
			return new FluentMailMessage();
		}

		// Chaining functions
		public IMustAddToAddress From(string emailAddress)
		{
			return this;
		}

		public IMustAddToAddress From(string emailAddress, string displayName)
		{
			return this;
		}

		public IMustAddToAddress From(string emailAddress, string displayName, Encoding encodingType)
		{
			return this;
		}

		public IMustAddToAddress From(MailAddress emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(string emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(string emailAddress, string displayName)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(MailAddress emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(string emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(IEnumerable<string> emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(string emailAddress, string displayName)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(string emailAddress, string displayName, Encoding encodingType)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(MailAddress emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(IEnumerable<MailAddress> emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(string emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(IEnumerable<string> emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName, Encoding encodingType)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(MailAddress emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(IEnumerable<MailAddress> emailAddress)
		{
			return this;
		}

		public IMustAddBody Subject(string subject)
		{
			return this;
		}

		public IMustAddBody Subject(string subject, Encoding encodingType)
		{
			return this;
		}

		public ICanAddAttachmentOrBuild Body(string body)
		{
			return this;
		}

		public ICanAddAttachmentOrBuild Body(string body, Encoding encodingType)
		{
			return this;
		}

		public ICanAddAttachmentOrBuild AddAttachment(string filename)
		{
			return this;
		}

		// Executing functions
		public MailMessage Build()
        {
            return new MailMessage();
        }

		// Hide default functions from appearing with IntelliSense
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
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
		ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddress);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject To(MailAddress emailAddress);
		ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddress);
	}

	public interface ICanAddToCcBccOrSubject
	{
		ICanAddToCcBccOrSubject To(string emailAddress);
		ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddress);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject To(MailAddress emailAddress);
		ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddress);
		ICanAddToCcBccOrSubject CC(string emailAddress);
		ICanAddToCcBccOrSubject CC(IEnumerable<string> emailAddress);
		ICanAddToCcBccOrSubject CC(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject CC(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject CC(MailAddress emailAddress);
		ICanAddToCcBccOrSubject CC(IEnumerable<MailAddress> emailAddress);
		ICanAddToCcBccOrSubject BCC(string emailAddress);
		ICanAddToCcBccOrSubject BCC(IEnumerable<string> emailAddress);
		ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName, Encoding encodingType);
		ICanAddToCcBccOrSubject BCC(MailAddress emailAddress);
		ICanAddToCcBccOrSubject BCC(IEnumerable<MailAddress> emailAddress);
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
		MailMessage Build();
	}

}
