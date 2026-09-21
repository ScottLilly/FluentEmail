using System.Net.Mime;
using System.Text;

namespace FluentEmail
{
    public interface IMustAddBody
    {
        ICanAddAttachmentOrBuild Body(string body);
        ICanAddAttachmentOrBuild Body(string body, Encoding encodingType);
        ICanAddAttachmentOrBuild Body(string body, TransferEncoding transferEncoding);
        ICanAddAttachmentOrBuild Body(string body, Encoding encodingType, TransferEncoding transferEncoding);
    }
}
