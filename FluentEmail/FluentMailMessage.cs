using System.ComponentModel;
using System.Net.Mail;

namespace FluentEmail
{
	public class FluentMailMessage : IMustAddFromAddress, IMustAddToAddress, ICanAddToCcBccOrSubject, ICanBuild
	{
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

		public IMustAddToAddress From(MailAddress emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(string emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(string emailAddress, string displayName)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject To(MailAddress emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(string emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(string emailAddress, string displayName)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject CC(MailAddress emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(string emailAddress)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName)
		{
			return this;
		}

		public ICanAddToCcBccOrSubject BCC(MailAddress emailAddress)
		{
			return this;
		}

		public ICanBuild Subject(string subject)
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
		IMustAddToAddress From(MailAddress emailAddress);
	}


	public interface IMustAddToAddress
	{
		ICanAddToCcBccOrSubject To(string emailAddress);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject To(MailAddress emailAddress);
	}


	public interface ICanAddToCcBccOrSubject
	{
		ICanAddToCcBccOrSubject To(string emailAddress);
		ICanAddToCcBccOrSubject To(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject To(MailAddress emailAddress);
		ICanAddToCcBccOrSubject CC(string emailAddress);
		ICanAddToCcBccOrSubject CC(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject CC(MailAddress emailAddress);
		ICanAddToCcBccOrSubject BCC(string emailAddress);
		ICanAddToCcBccOrSubject BCC(string emailAddress, string displayName);
		ICanAddToCcBccOrSubject BCC(MailAddress emailAddress);
		ICanBuild Subject(string subject);
	}


	public interface ICanBuild
	{
		MailMessage Build();
	}

}
