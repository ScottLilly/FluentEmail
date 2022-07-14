using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Xunit;

namespace Test.FluentEmail
{
    public class TestFluentEmailBuilder
    {
        [Fact]
        public void Test_Instantiate_StringEmailAddresses()
        {
            var mailMessage = 
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .To("zxc@test.com")
                    .To(new List<string>
                    {
                        "mnb@test.com", 
                        "qwe@test.com", // Duplicate, so should not be added
                        "rty@test.com"
                    })
                    .Subject("test")
                    .Body("This is the email body")
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename1.txt"))
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename2.txt"))
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename3.txt"))
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal(4, mailMessage.To.Count);
        }

        [Fact]
        public void Test_Instantiate_StringStringEmailAddresses()
        {
            var mailMessage = 
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From")
                    .To("qwe@test.com", "Sue Qwe")
                    .To("zxc@test.com", "Mike Zxc")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal("John From", mailMessage.From.DisplayName);
        }

        [Fact]
        public void Test_Instantiate_StringStringEncodingEmailAddresses()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From", Encoding.UTF8)
                    .To("qwe@test.com", "Sue Qwe")
                    .To("zxc@test.com", "Mike Zxc")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal("John From", mailMessage.From.DisplayName);
            // TODO: Pass in UTF-16 name and encoding, and verify
        }

        [Fact]
        public void Test_Instantiate_MailAddressEmailAddresses()
        {
            var mailMessage = 
                FluentMailMessage
                    .CreateMailMessage()
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .To(new List<MailAddress>
                    {
                        new MailAddress("mnb@test.com"),
                        new MailAddress("qwe@test.com"), // Duplicate, so should not be added
                        new MailAddress("rty@test.com")
                    })
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.Equal(4, mailMessage.To.Count);
        }

        [Fact]
        public void Test_Instantiate_StringEmailAddresses_WithDupes()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .To("qwe@test.com")
                    .To("zxc@test.com")
                    .CC("lkj@test.com")
                    .CC("jhg@test.com")
                    .CC("jhg@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename1.txt"))
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename2.txt"))
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename3.txt"))
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal(2, mailMessage.To.Count);
            Assert.Equal(2, mailMessage.CC.Count);
        }

        [Fact]
        public void Test_Instantiate_StringStringEmailAddresses_WithDupes()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From")
                    .To("qwe@test.com", "Sue Qwe")
                    .To("qwe@test.com", "Sue Qwe")
                    .To("zxc@test.com", "Mike Zxc")
                    .CC("lkj@test.com", "asd name")
                    .CC("jhg@test.com", "zxc name")
                    .CC("jhg@test.com", "Test Name")
                    .BCC("lkj456@test.com", "asd456 name")
                    .BCC("jhg456@test.com", "zxc456 name")
                    .BCC("jhg456@test.com", "Test456 Name")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal("John From", mailMessage.From.DisplayName);
            Assert.Equal(2, mailMessage.To.Count);
            Assert.Equal(2, mailMessage.CC.Count);
            Assert.Equal(2, mailMessage.Bcc.Count);
            Assert.Equal("test", mailMessage.Subject);
            Assert.Equal("This is the email body", mailMessage.Body);
        }

        [Fact]
        public void Test_Instantiate_StringStringEncodingEmailAddresses_WithDupes()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From", Encoding.UTF8)
                    .To("qwe@test.com", "Sue Qwe")
                    .To("qwe@test.com", "Sue Qwe")
                    .To("zxc@test.com", "Mike Zxc")
                    .Subject("test", Encoding.UTF8)
                    .Body("This is the email body", Encoding.UTF8)
                    .AddAttachment(Path.Combine(".", "TestFiles", "test.txt"))
                    .AddAttachment(Path.Combine(".", "TestFiles", "test2.txt"))
                    .AddAttachment(Path.Combine(".", "TestFiles", "test2.txt"))
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.NotNull(mailMessage.From);
            Assert.Equal("from@test.com", mailMessage.From.Address);
            Assert.Equal("John From", mailMessage.From.DisplayName);
            Assert.Equal(2, mailMessage.To.Count);
            Assert.Equal("test", mailMessage.Subject);
            Assert.Equal(Encoding.UTF8, mailMessage.SubjectEncoding);
            Assert.Equal("This is the email body", mailMessage.Body);
            Assert.Equal(Encoding.UTF8, mailMessage.BodyEncoding);
            Assert.Equal(2, mailMessage.Attachments.Count);
            // TODO: Pass in UTF-16 name and encoding, and verify
        }

        [Fact]
        public void Test_Instantiate_MailAddressEmailAddresses_WithDupes()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com", "asd name"))
                    .To("ghj@test.com", "George H Jones", Encoding.UTF8)
                    .CC(new MailAddress("qwe123@test.com", "Sue123 Qwe"))
                    .CC(new MailAddress("qwe123@test.com", "Sue123 Qwe"))
                    .CC(new MailAddress("zxc123@test.com", "asd123 name"))
                    .Subject("test")
                    .Body("This is the email body")
                    .AddAttachments( new List<string>
                    {
                        Path.Combine(".", "TestFiles", "test.txt"),
                        Path.Combine(".", "TestFiles", "test2.txt"),
                        Path.Combine(".", "TestFiles", "test2.txt")
                    })
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.Equal(3, mailMessage.To.Count);
            Assert.Equal(2, mailMessage.Attachments.Count);
        }

        [Fact]
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
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename1.txt"),
                        "text/html")
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename1.txt"),
                        "text/html")
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename2.txt"),
                        "text/html")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.Equal(2, mailMessage.Attachments.Count);
        }

        [Fact]
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
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename1.txt"), 
                        new ContentType(MediaTypeNames.Text.Plain))
                    .AddAttachment(Path.Combine(".", "TestFiles", "filename1.txt"),
                        new ContentType(MediaTypeNames.Text.Plain))
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.Single(mailMessage.Attachments);
        }

        [Fact]
        public void Test_Priority()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.Normal, mailMessage.Priority);
        }

        [Fact]
        public void Test_AddAttachment_StreamName()
        {
            using FileStream fs1 = 
                File.OpenRead(Path.Combine(".", "TestFiles", "filename1.txt"));
            using FileStream fs2 =
                File.OpenRead(Path.Combine(".", "TestFiles", "filename2.txt"));

            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(fs1, "filename1.txt")
                    .AddAttachment(fs2, "filename2.txt")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.Equal(2, mailMessage.Attachments.Count);
        }

        [Fact]
        public void Test_AddAttachment_StreamNameMimeType()
        {
            using FileStream fs1 =
                File.OpenRead(Path.Combine(".", "TestFiles", "filename1.txt"));
            using FileStream fs2 =
                File.OpenRead(Path.Combine(".", "TestFiles", "filename2.txt"));

            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(fs1, "filename1.txt", "text/html")
                    .AddAttachment(fs2, "filename2.txt", "text/html")
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.Equal(2, mailMessage.Attachments.Count);
        }

        [Fact]
        public void Test_AddAttachment_StreamContentType()
        {
            using FileStream fs1 =
                File.OpenRead(Path.Combine(".", "TestFiles", "filename1.txt"));
            using FileStream fs2 =
                File.OpenRead(Path.Combine(".", "TestFiles", "filename2.txt"));

            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(fs1, new ContentType(MediaTypeNames.Text.Plain))
                    .AddAttachment(fs2, new ContentType(MediaTypeNames.Text.Plain))
                    .Build();

            Assert.NotNull(mailMessage);
            Assert.IsType<MailMessage>(mailMessage);
            Assert.Equal(2, mailMessage.Attachments.Count);
        }

        [Fact]
        public void Test_PriorityHigh()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage(MailPriority.High)
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.High, mailMessage.Priority);
        }

        [Fact]
        public void Test_PriorityLow()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage(MailPriority.Low)
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.Low, mailMessage.Priority);
        }
    }
}