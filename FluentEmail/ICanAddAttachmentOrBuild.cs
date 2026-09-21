using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace FluentEmail
{
    public interface ICanAddAttachmentOrBuild
    {
        ICanAddAttachmentOrBuild AddAttachment(string filename);
        ICanAddAttachmentOrBuild AddAttachment(string filename, string mimeType);
        ICanAddAttachmentOrBuild AddAttachment(string filename, ContentType contentType);
        ICanAddAttachmentOrBuild AddAttachment(Stream stream, string name);
        ICanAddAttachmentOrBuild AddAttachment(Stream stream, string name, string mimeType);
        ICanAddAttachmentOrBuild AddAttachment(Stream stream, ContentType contentType);
        ICanAddAttachmentOrBuild AddAttachments(IEnumerable<string> filenames);
        ICanAddAttachmentOrBuild AddAlternateView(AlternateView alternateView);
        ICanAddAttachmentOrBuild AddAlternateView(string content, ContentType contentType);
        ICanAddAttachmentOrBuild AddAlternateView(string content, Encoding contentEncoding, string mediaType);
        ICanAddAttachmentOrBuild AddAlternateViews(IEnumerable<AlternateView> alternateViews);
        ICanAddAttachmentOrBuild AddHeader(string name, string value);
        ICanAddAttachmentOrBuild AddHeaders(IEnumerable<KeyValuePair<string, string>> headers);
        ICanAddAttachmentOrBuild DeliveryNotificationOptions(DeliveryNotificationOptions options);
        MailMessage Build();
    }
}
