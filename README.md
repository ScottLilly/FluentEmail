# ScottLilly.FluentEmail

FluentEmail is a fluent interface library to help build MailMessage objects.

![Build Status](https://github.com/ScottLilly/FluentEmail/actions/workflows/ci.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/ScottLilly.FluentEmail)](https://www.nuget.org/packages/ScottLilly.FluentEmail/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/ScottLilly.FluentEmail)](https://www.nuget.org/packages/ScottLilly.FluentEmail/)
[![License](https://img.shields.io/github/license/ScottLilly/FluentEmail)](https://github.com/ScottLilly/FluentEmail/LICENSE)

## Instructions

Instructions are available at: https://github.com/ScottLilly/FluentEmail/blob/master/INSTRUCTIONS.md

This package lets you use IntelliSense and method chaining to create a MailMessage object, and enforces "rules of grammar" to ensure the required values are set.

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

## Requirements
- .NET Standard 2.0+

## Contributing
Contributions are welcome. Please submit issues or pull requests to the GitHub repository at: https://github.com/ScottLilly/FluentEmail/issues

## License
This project is licensed under the MIT License. See the [LICENSE file](https://github.com/ScottLilly/FluentEmail/blob/master/LICENSE.txt) for details.

## Contact
For questions or feedback, please [open an issue here on GitHub](https://github.com/ScottLilly/FluentEmail/issues).
