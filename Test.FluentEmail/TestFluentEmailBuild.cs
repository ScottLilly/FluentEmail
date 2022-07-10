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
                    .AddAttachment("filename1.txt")
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
                    .AddAttachment("filename1.txt")
                    .AddAttachment("filename2.txt")
                    .AddAttachment("filename3.txt")
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