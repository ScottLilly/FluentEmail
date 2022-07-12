using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Xunit;

namespace Test.FluentEmail
{
    public class TestFluentEmailBuilder
    {
        [Fact]
        public void Test_Instantiate_HtmlMailMessage()
        {
            var test =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .To("zxc@test.com")
                    .CC("lkj@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .AddAttachment(@".\TestFiles\filename1.txt")
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
        }

        [Fact]
        public void Test_Instantiate_StringEmailAddresses()
        {
            var test = 
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .To("zxc@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .AddAttachment(@".\TestFiles\filename1.txt")
                    .AddAttachment(@".\TestFiles\filename2.txt")
                    .AddAttachment(@".\TestFiles\filename3.txt")
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
            Assert.NotNull(test.From);
            Assert.Equal("from@test.com", test.From.Address);
        }

        [Fact]
        public void Test_Instantiate_StringStringEmailAddresses()
        {
            var test = 
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From")
                    .To("qwe@test.com", "Sue Qwe")
                    .To("zxc@test.com", "Mike Zxc")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
            Assert.NotNull(test.From);
            Assert.Equal("from@test.com", test.From.Address);
            Assert.Equal("John From", test.From.DisplayName);
        }

        [Fact]
        public void Test_Instantiate_StringStringEncodingEmailAddresses()
        {
            var test =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com", "John From", Encoding.UTF8)
                    .To("qwe@test.com", "Sue Qwe")
                    .To("zxc@test.com", "Mike Zxc")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
            Assert.NotNull(test.From);
            Assert.Equal("from@test.com", test.From.Address);
            Assert.Equal("John From", test.From.DisplayName);
            // TODO: Pass in UTF-16 name and encoding, and verify
        }

        [Fact]
        public void Test_Instantiate_MailAddressEmailAddresses()
        {
            var test = 
                FluentMailMessage
                    .CreateMailMessage()
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
        }

        [Fact]
        public void Test_Instantiate_StringEmailAddresses_WithDupes()
        {
            var test =
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
                    .AddAttachment(@".\TestFiles\filename1.txt")
                    .AddAttachment(@".\TestFiles\filename2.txt")
                    .AddAttachment(@".\TestFiles\filename3.txt")
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
            Assert.NotNull(test.From);
            Assert.Equal("from@test.com", test.From.Address);
            Assert.Equal(2, test.To.Count);
            Assert.Equal(2, test.CC.Count);
        }

        [Fact]
        public void Test_Instantiate_StringStringEmailAddresses_WithDupes()
        {
            var test =
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

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
            Assert.NotNull(test.From);
            Assert.Equal("from@test.com", test.From.Address);
            Assert.Equal("John From", test.From.DisplayName);
            Assert.Equal(2, test.To.Count);
            Assert.Equal(2, test.CC.Count);
            Assert.Equal(2, test.Bcc.Count);
            Assert.Equal("test", test.Subject);
            Assert.Equal("This is the email body", test.Body);
        }

        [Fact]
        public void Test_Instantiate_StringStringEncodingEmailAddresses_WithDupes()
        {
            var test =
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

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
            Assert.NotNull(test.From);
            Assert.Equal("from@test.com", test.From.Address);
            Assert.Equal("John From", test.From.DisplayName);
            Assert.Equal(2, test.To.Count);
            Assert.Equal("test", test.Subject);
            Assert.Equal(Encoding.UTF8, test.SubjectEncoding);
            Assert.Equal("This is the email body", test.Body);
            Assert.Equal(Encoding.UTF8, test.BodyEncoding);
            Assert.Equal(2, test.Attachments.Count);
            // TODO: Pass in UTF-16 name and encoding, and verify
        }

        [Fact]
        public void Test_Instantiate_MailAddressEmailAddresses_WithDupes()
        {
            var test =
                FluentMailMessage
                    .CreateMailMessage()
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com", "asd name"))
                    .CC(new MailAddress("qwe123@test.com", "Sue123 Qwe"))
                    .CC(new MailAddress("qwe123@test.com", "Sue123 Qwe"))
                    .CC(new MailAddress("zxc123@test.com", "asd123 name"))
                    .Subject("test")
                    .Body("This is the email body")
                    .AddAttachments( new List<string>
                    {
                        @".\TestFiles\test.txt", 
                        @".\TestFiles\test2.txt",
                        @".\TestFiles\test2.txt"
                    })
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
            Assert.Equal(2, test.To.Count);
            Assert.Equal(2, test.Attachments.Count);
        }

        [Fact]
        public void Test_Priority()
        {
            var test =
                FluentMailMessage
                    .CreateMailMessage()
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.Normal, test.Priority);
        }

        [Fact]
        public void Test_PriorityHigh()
        {
            var test =
                FluentMailMessage
                    .CreateMailMessage(MailPriority.High)
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.High, test.Priority);
        }

        [Fact]
        public void Test_PriorityLow()
        {
            var test =
                FluentMailMessage
                    .CreateMailMessage(MailPriority.Low)
                    .From(new MailAddress("from@test.com", "John From"))
                    .To(new MailAddress("qwe@test.com", "Sue Qwe"))
                    .To(new MailAddress("zxc@test.com"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(MailPriority.Low, test.Priority);
        }
    }
}