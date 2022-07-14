FluentEmail is a fluent interface library to help build MailMessage objects.

It lets you use IntelliSense and method chaining to create a MailMessage object, and enforces "rules of grammar" to ensure the required values are set.

For example, after calling CreateMailMessage() or CreateHtmlMailMessage(), the only function available next (shown via IntelliSense) is the From() function. The From() function cannot be called more than once. After it's called, the library requires you call To() at least once. And so on.

**Sample code using FluentEmail**
```
MailMessage mailMessage =
    FluentMailMessage
        .CreateMailMessage()
        .From("from@test.com")
        .To("qwe@test.com", "Qwe Test")
        .To(new MailMessage("jhg@test.com", "Jhg Test"))
        .CC("lkj@test.com")
        .CC("yui@test.com")
        .Subject("Hello")
        .Body("Please review the attached image")
        .AddAttachment(@"D:\Images\Logo.png", "image/png")
        .Build();
```
