using System.Text;

namespace FluentEmail
{
    public interface IMustAddBody
    {
        ICanAddAttachmentOrBuild Body(string body);
        ICanAddAttachmentOrBuild Body(string body, Encoding encodingType);
    }
}
