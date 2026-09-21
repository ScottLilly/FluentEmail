using System.Net.Mail;
using System.Text;

namespace FluentEmail
{
    public interface IMustAddFromAddress
    {
        IMustAddToAddress From(string emailAddress);
        IMustAddToAddress From(string emailAddress, string displayName);
        IMustAddToAddress From(string emailAddress, string displayName, Encoding encodingType);
        IMustAddToAddress From(MailAddress emailAddress);
    }
}
