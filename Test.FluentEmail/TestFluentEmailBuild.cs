using System.Net.Mail;
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
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
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
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
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
                    .Build();

            Assert.NotNull(test);
            Assert.IsType<MailMessage>(test);
        }
    }
}