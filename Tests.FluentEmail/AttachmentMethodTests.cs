using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class AttachmentMethodTests
    {
        private readonly string _filename1 =
            Path.Combine(".", "TestFiles", "filename1.txt");
        private readonly string _filename2 =
            Path.Combine(".", "TestFiles", "filename2.txt");
        private readonly ContentType _plainContentType =
            new ContentType(MediaTypeNames.Text.Plain);

        [TestMethod]
        public void Test_AddAttachment_StringDifferingOnlyInCase_IsTreatedAsDuplicate()
        {
            // The upper case spelling is never opened, because the duplicate check happens
            // before the Attachment is constructed. That matters on a case sensitive file
            // system, where a file by that name does not exist.
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(_filename1)
                    .AddAttachment(_filename1.ToUpperInvariant())
                    .Build();

            Assert.AreEqual(1, mailMessage.Attachments.Count);
        }

        [TestMethod]
        public void Test_AddAttachment_String()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(_filename1)
                    .AddAttachment(_filename1) // Duplicate, should not add
                    .AddAttachment(_filename2)
                    .Build();

            Assert.AreEqual(2, mailMessage.Attachments.Count);
        }

        [TestMethod]
        public void Test_AddAttachment_StringString()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(_filename1, "text/html")
                    .AddAttachment(_filename1, "text/html") // Duplicate, should not add
                    .AddAttachment(_filename2, "text/html")
                    .Build();

            Assert.AreEqual(2, mailMessage.Attachments.Count);
        }

        [TestMethod]
        public void Test_AddAttachment_IEnumerableString()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachments(new List<string>
                    {
                        _filename1,
                        _filename1, // Duplicate, should not add
                        _filename2
                    })
                    .Build();

            Assert.AreEqual(2, mailMessage.Attachments.Count);
        }

        [TestMethod]
        public void Test_AddAttachment_StringContentType()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(_filename1, _plainContentType)
                    .AddAttachment(_filename1, _plainContentType) // Duplicate, should not add
                    .Build();

            Assert.AreEqual(1, mailMessage.Attachments.Count);
        }

        [TestMethod]
        public void Test_AddAttachment_StreamName()
        {
            using FileStream fs1 = File.OpenRead(_filename1);
            using FileStream fs2 = File.OpenRead(_filename2);

            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(fs1, _filename1)
                    .AddAttachment(fs2, _filename2)
                    .Build();

            Assert.AreEqual(2, mailMessage.Attachments.Count);
        }

        [TestMethod]
        public void Test_AddAttachment_StreamNameMimeType()
        {
            using FileStream fs1 = File.OpenRead(_filename1);
            using FileStream fs2 = File.OpenRead(_filename2);

            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(fs1, _filename1, "text/html")
                    .AddAttachment(fs2, _filename2, "text/html")
                    .Build();

            Assert.AreEqual(2, mailMessage.Attachments.Count);
        }

        [TestMethod]
        public void Test_AddAttachment_StreamContentType()
        {
            using FileStream fs1 = File.OpenRead(_filename1);
            using FileStream fs2 = File.OpenRead(_filename2);

            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(fs1, _plainContentType)
                    .AddAttachment(fs2, _plainContentType)
                    .Build();

            Assert.AreEqual(2, mailMessage.Attachments.Count);
        }
    }
}
