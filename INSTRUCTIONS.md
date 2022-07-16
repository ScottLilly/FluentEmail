## Why use a fluent interface?
There are two basic ideas behind the fluent interface.  

First, the developer can use method chaining (calling one method after another) to build the object.  

Second, the functions available/visible through IntelliSense will force the developer to build a properly configured object. This way, the developer is not required to remember all the properties that must have values, or functions that need to be called before the object can be used.  

As you build a MailMessage object with the FluentEmail package, the functions you use and the values you pass into them will be remembered and populated in MailMessage object you get back from the call to Build().  

## How to use FluentEmail  
After including the NuGet package in your project, you can use the FluentEmailMessage class to build a MailMessage object.  

## Starting functions  
Type "FluentEmailMessage", press the "." (period/dot/full stop) key, and you should see the two available functions to start building the MailMessage object: CreateMailMessage() and CreateHtmlMailMessage().  

Both these functions accept an optional MailPriority parameter. If you don't pass in a value, the MailMessage will have its priority set to "normal".  

## Intermediate (chaining) functions
From this point, press the "." again ad you will see the next available function: From().  

This is to ensure every MailMessage object has a From email address. This is required at runtime (when sending out a MailMessage) but is not required at compile time. This is the main reason behind using a fluent interface to build a MailMessage object - to eliminate/reduce runtime errors that wouldn't be caught during compilation.  

After calling the From() function, the only function available next is the To() function. This is to ensure there is at least one destination email address for the MailMessage.  

There are several overloads for the To() function.  

After calling To() the first time, the next available functions are: To(), CC(), BCC(), and Subject(). You can call To(), CC(), and BCC() as many times as you want. Once you have entered all the destination email addresses, you can call Subject().  

After calling Subject(), the only available function is Body().  

After calling Body(), you can call AddAttachment() and AddAttachments() as many times as you want. The Build() function is also available here, but that will end the method chain.

## Ending (finalizing) function
Once all required functions have been called, you can call the Build() function.  

This function returns a MailMessage object, with it properties set based on the previously-called functions and their parameters.  


## Source Code
This is written 100% in C#, .NET Standard 2.0.  

Source code available at: https://github.com/ScottLilly/FluentEmail  

The code is available under the [MIT license](https://github.com/ScottLilly/FluentEmail/blob/master/LICENSE.md).  

This was built using a program I wrote to help build fluent interface that enforce "rules of grammar" (sequence of function calls in the method chain). If you are interested in building interfaces, please contact me at: https://scottlilly.com/contact-scott/

## Support
Please submit bugs and feature requests here: https://github.com/ScottLilly/FluentEmail/issues  

The future feature plan is available here: https://github.com/ScottLilly/FluentEmail/projects/1  
