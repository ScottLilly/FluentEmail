using System.Text;
using FluentEmail;
using Xunit;

namespace Test.FluentEmail
{
    public class Test_BodyMethods
    {
        [Fact]
        public void Test_Body_String()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal("This is the email body", mailMessage.Body);
        }

        [Fact]
        public void Test_Body_StringEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body", Encoding.UTF8)
                    .Build();

            Assert.Equal("This is the email body", mailMessage.Body);
            Assert.Equal(Encoding.UTF8, mailMessage.BodyEncoding);
        }
    }
}
