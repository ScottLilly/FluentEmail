using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using FluentEmail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.FluentEmail
{
    [TestClass]
    public class AlternateViewMethodTests
    {
        [TestMethod]
        public void Test_AddAlternateView_AlternateView()
        {
            var view = AlternateView.CreateAlternateViewFromString(
                "<p>Hello</p>", new ContentType(MediaTypeNames.Text.Html));

            var mailMessage = StartMessage().AddAlternateView(view).Build();

            Assert.AreEqual(1, mailMessage.AlternateViews.Count);
            Assert.AreSame(view, mailMessage.AlternateViews[0]);
        }

        [TestMethod]
        public void Test_AddAlternateView_StringContentType()
        {
            var mailMessage =
                StartMessage()
                    .AddAlternateView("<p>Hello</p>", new ContentType(MediaTypeNames.Text.Html))
                    .Build();

            Assert.AreEqual(1, mailMessage.AlternateViews.Count);
            Assert.AreEqual(MediaTypeNames.Text.Html,
                mailMessage.AlternateViews[0].ContentType.MediaType);
        }

        [TestMethod]
        public void Test_AddAlternateView_StringEncodingMediaType()
        {
            var mailMessage =
                StartMessage()
                    .AddAlternateView("<p>Hello</p>", Encoding.UTF8, MediaTypeNames.Text.Html)
                    .Build();

            Assert.AreEqual(1, mailMessage.AlternateViews.Count);
            Assert.AreEqual(MediaTypeNames.Text.Html,
                mailMessage.AlternateViews[0].ContentType.MediaType);
            Assert.AreEqual(Encoding.UTF8.WebName,
                mailMessage.AlternateViews[0].ContentType.CharSet);
        }

        [TestMethod]
        public void Test_AddAlternateViews_IEnumerableAlternateView()
        {
            var views = new List<AlternateView>
            {
                AlternateView.CreateAlternateViewFromString(
                    "<p>Hello</p>", new ContentType(MediaTypeNames.Text.Html)),
                AlternateView.CreateAlternateViewFromString(
                    "Hello", new ContentType(MediaTypeNames.Text.Plain))
            };

            var mailMessage = StartMessage().AddAlternateViews(views).Build();

            Assert.AreEqual(2, mailMessage.AlternateViews.Count);
        }

        [TestMethod]
        public void Test_AddAlternateView_SameContentTwice_IsNotTreatedAsDuplicate()
        {
            // Alternate views have no key to de-duplicate on, and each owns a stream that would
            // be leaked if it were dropped. Both are kept, the same way Stream attachments are.
            var mailMessage =
                StartMessage()
                    .AddAlternateView("<p>Hello</p>", new ContentType(MediaTypeNames.Text.Html))
                    .AddAlternateView("<p>Hello</p>", new ContentType(MediaTypeNames.Text.Html))
                    .Build();

            Assert.AreEqual(2, mailMessage.AlternateViews.Count);
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
