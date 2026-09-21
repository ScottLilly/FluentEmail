using System.Collections.Generic;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class HeaderMethodTests
    {
        [TestMethod]
        public void Test_AddHeader_StringString()
        {
            var mailMessage =
                StartMessage()
                    .AddHeader("X-Campaign", "spring-sale")
                    .Build();

            Assert.AreEqual("spring-sale", mailMessage.Headers["X-Campaign"]);
        }

        [TestMethod]
        public void Test_AddHeaders_IEnumerableKeyValuePair()
        {
            var mailMessage =
                StartMessage()
                    .AddHeaders(new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("X-Campaign", "spring-sale"),
                        new KeyValuePair<string, string>("X-Source", "newsletter")
                    })
                    .Build();

            Assert.AreEqual("spring-sale", mailMessage.Headers["X-Campaign"]);
            Assert.AreEqual("newsletter", mailMessage.Headers["X-Source"]);
        }

        [TestMethod]
        public void Test_AddHeader_RepeatedName_Accumulates()
        {
            // Headers are not de-duplicated. NameValueCollection keeps both values, which is
            // what a header that legitimately repeats needs.
            var mailMessage =
                StartMessage()
                    .AddHeader("X-Campaign", "spring-sale")
                    .AddHeader("X-Campaign", "newsletter")
                    .Build();

            CollectionAssert.AreEqual(
                new[] { "spring-sale", "newsletter" },
                mailMessage.Headers.GetValues("X-Campaign"));
        }

        private static ICanAddAttachmentOrBuild StartMessage()
        {
            return FluentMailMessage
                .CreateMailMessage()
                .From("from@test.com")
                .To("qwe@test.com")
                .Subject("Hello")
                .Body("This is the email body");
        }
    }
}
