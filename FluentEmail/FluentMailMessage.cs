using System.ComponentModel;
using System.Net.Mail;

namespace FluentEmail
{
	public class FluentMailMessage : IMustAddFromAddress, IMustAddToAddress, ICanAddToAddressOrBuild
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

		public ICanAddToAddressOrBuild To(string emailAddress)
		{
			return this;
		}

		public ICanAddToAddressOrBuild To(string emailAddress, string displayName)
		{
			return this;
		}

		public ICanAddToAddressOrBuild To(MailAddress emailAddress)
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
		ICanAddToAddressOrBuild To(string emailAddress);
		ICanAddToAddressOrBuild To(string emailAddress, string displayName);
		ICanAddToAddressOrBuild To(MailAddress emailAddress);
	}


	public interface ICanAddToAddressOrBuild
	{
		ICanAddToAddressOrBuild To(string emailAddress);
		ICanAddToAddressOrBuild To(string emailAddress, string displayName);
		ICanAddToAddressOrBuild To(MailAddress emailAddress);
		MailMessage Build();
	}

}
