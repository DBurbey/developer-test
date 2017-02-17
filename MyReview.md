
Objective 3 - Review the existing code

When reviewing code you look at the coding pattern that has been implemented and determine whether it has successfully achieved:

- Separation of concerns
- Application of the SOLID principles

This application is an MVC application of which its core design is to separate the code into three areas, the view which holds the HTML and code to populate the HTML, the model class which holds the data transferred into the view and the controller which is responsible for populating the model before transferring it to the view.  The core part of this design is to use a model class to allow one class of code to populate the data and another to generate the HTML.

This application has taken this design another couple of steps to improve the separation of concerns.  Specifically for each controller it uses build classes to build the view model for HTTP Get requests and handler classes to process HTTP Post requests which often include data returned which triggers updates to the database.  

By using MVC and making these additional design changes the code looks to have achieved the first principle of SOLID which is that each class has a single responsibility.  And whilst a number of classes are not based on abstract classes (the build and handler classes) they are built in the controllers which do not contain any functionality which requires unit testing and therefore this is not an issue.

Looking at the code the only possible issue I can see is that the Entity Framework DBContext class is being created using the Simple Injector dependency injector engine and is not being closed using the Dispose method.  This may have an impact with memory consumption increasing.  For further information see:

https://msdn.microsoft.com/en-us/library/jj729737(v=vs.113).aspx

To fix this I would change the ActionResult functions in the controller classes to create an instance of the ApplicationDbContext class rather than letting the SimpleInjector engine create instances of this class and then use the using code which automatically creates a try/finally block and calls dispose in the finally block.  See the change made in the Property controller for the HttpPost version of the ViewRequest function.



