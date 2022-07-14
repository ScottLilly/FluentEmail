using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using FluentEmail;
using Xunit;

namespace Test.FluentEmail
{
    public class Test_BBCCMethods
    {
        [Fact]
        public void Test_BCC_String()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("asd@test.com")
                    .BCC("qwe@test.com")
                    .BCC("zxc@test.com")
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(2, mailMessage.Bcc.Count);
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [Fact]
        public void Test_BCC_IEnumerableString()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("asd@test.com")
                    .BCC(new List<string>
                    {
                        "qwe@test.com",
                        "qwe@test.com", // Duplicate, so should not be added
                        "zxc@test.com"
                    })
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(2, mailMessage.Bcc.Count);
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [Fact]
        public void Test_BCC_StringString()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("asd@test.com")
                    .BCC("qwe@test.com", "Qwe Test")
                    .BCC("zxc@test.com", "Zxc Test")
                    .BCC("zxc@test.com", "Zxc Test") // Duplicate, should not add
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(2, mailMessage.Bcc.Count);
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.DisplayName.Equals("Qwe Test")));
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.DisplayName.Equals("Zxc Test")));
        }

        [Fact]
        public void Test_BCC_StringStringEncoding()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("asd@test.com")
                    .BCC("qwe@test.com", "Qwe Test", Encoding.UTF8)
                    .BCC("zxc@test.com", "Zxc Test", Encoding.UTF8)
                    .BCC("zxc@test.com", "Zxc Test", Encoding.UTF8) // Duplicate, should not add
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(2, mailMessage.Bcc.Count);
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [Fact]
        public void Test_To_MailAddress()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("asd@test.com")
                    .BCC(new MailAddress("qwe@test.com", "Qwe Test"))
                    .BCC(new MailAddress("zxc@test.com", "Zxc Test"))
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(2, mailMessage.Bcc.Count);
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }

        [Fact]
        public void Test_To_IEnumerableMailAddress()
        {
            var mailMessage =
                FluentMailMessage
                    .CreateMailMessage()
                    .From("from@test.com")
                    .To("asd@test.com")
                    .BCC(new List<MailAddress>
                    {
                        new MailAddress("qwe@test.com"),
                        new MailAddress("qwe@test.com"), // Duplicate, so should not be added
                        new MailAddress("zxc@test.com")
                    })
                    .Subject("test")
                    .Body("This is the email body")
                    .Build();

            Assert.Equal(2, mailMessage.Bcc.Count);
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("qwe@test.com")));
            Assert.True(mailMessage.Bcc.ToList().Exists(m => m.Address.Equals("zxc@test.com")));
        }
    }
}
