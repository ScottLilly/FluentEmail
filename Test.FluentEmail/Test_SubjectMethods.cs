using System.Text;
using FluentEmail;
using Xunit;

namespace Test.FluentEmail
{
    public class Test_SubjectMethods
    {
        [Fact]
        public void Test_Subject_String()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal("Hello", mailMessage.Subject);
        }

        [Fact]
        public void Test_Subject_StringEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateHtmlMailMessage()
                    .From("from@test.com")
                    .To("qwe@test.com")
                    .Subject("Hello", Encoding.UTF8)
                    .Body("This is the email body")
                    .Build();

            Assert.Equal("Hello", mailMessage.Subject);
            Assert.Equal(Encoding.UTF8, mailMessage.SubjectEncoding);
        }
    }
}
