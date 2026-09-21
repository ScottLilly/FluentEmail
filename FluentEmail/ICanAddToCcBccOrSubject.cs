using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace FluentEmail
{
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
        ICanAddToCcBccOrSubject ReplyTo(string emailAddress);
        ICanAddToCcBccOrSubject ReplyTo(IEnumerable<string> emailAddresses);
        ICanAddToCcBccOrSubject ReplyTo(string emailAddress, string displayName);
        ICanAddToCcBccOrSubject ReplyTo(string emailAddress, string displayName, Encoding encodingType);
        ICanAddToCcBccOrSubject ReplyTo(MailAddress emailAddress);
        ICanAddToCcBccOrSubject ReplyTo(IEnumerable<MailAddress> emailAddresses);
        IMustAddBody Subject(string subject);
        IMustAddBody Subject(string subject, Encoding encodingType);
    }
}
