using System.Net.Mail;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class DeliveryNotificationMethodTests
    {
        [TestMethod]
        public void Test_DeliveryNotificationOptions_SingleOption()
        {
            var mailMessage =
                StartMessage()
                    .DeliveryNotificationOptions(DeliveryNotificationOptions.OnFailure)
                    .Build();

            Assert.AreEqual(DeliveryNotificationOptions.OnFailure,
                mailMessage.DeliveryNotificationOptions);
        }

        [TestMethod]
        public void Test_DeliveryNotificationOptions_CombinedOptions()
        {
            var mailMessage =
                StartMessage()
                    .DeliveryNotificationOptions(
                        DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.Delay)
                    .Build();

            Assert.AreEqual(
                DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.Delay,
                mailMessage.DeliveryNotificationOptions);
        }

        [TestMethod]
        public void Test_DeliveryNotificationOptions_CalledTwice_LastCallWins()
        {
            var mailMessage =
                StartMessage()
                    .DeliveryNotificationOptions(DeliveryNotificationOptions.OnFailure)
                    .DeliveryNotificationOptions(DeliveryNotificationOptions.Never)
                    .Build();

            Assert.AreEqual(DeliveryNotificationOptions.Never,
                mailMessage.DeliveryNotificationOptions);
        }

        [TestMethod]
        public void Test_DeliveryNotificationOptions_NotCalled_IsNone()
        {
            var mailMessage = StartMessage().Build();

            Assert.AreEqual(DeliveryNotificationOptions.None,
                mailMessage.DeliveryNotificationOptions);
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
