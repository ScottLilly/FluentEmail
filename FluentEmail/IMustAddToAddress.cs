using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace FluentEmail
{
    public interface IMustAddToAddress
    {
        ICanAddToCcBccOrSubject To(string emailAddress);
        ICanAddToCcBccOrSubject To(IEnumerable<string> emailAddresses);
        ICanAddToCcBccOrSubject To(string emailAddress, string displayName);
        ICanAddToCcBccOrSubject To(string emailAddress, string displayName, Encoding encodingType);
        ICanAddToCcBccOrSubject To(MailAddress emailAddress);
        ICanAddToCcBccOrSubject To(IEnumerable<MailAddress> emailAddresses);
    }
}
