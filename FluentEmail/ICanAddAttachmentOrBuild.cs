using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

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
        MailMessage Build();
    }
}
