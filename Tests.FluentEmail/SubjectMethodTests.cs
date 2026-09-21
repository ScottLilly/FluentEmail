using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class SubjectMethodTests
    {
        [TestMethod]
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

            Assert.AreEqual("Hello", mailMessage.Subject);
        }

        [TestMethod]
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

            Assert.AreEqual("Hello", mailMessage.Subject);
            Assert.AreEqual(Encoding.UTF8, mailMessage.SubjectEncoding);
        }
    }
}
