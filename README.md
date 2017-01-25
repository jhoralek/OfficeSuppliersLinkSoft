# OfficeSuppliersLinkSoft

Very simple web application where HR department can store office suppliers details

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system

### Prerequisites

For smooth launch OfficeSuppliersLinkSoft application you need to this software installed

```
* [Microsoft Visual Studio 2015] (https://www.microsoft.com/en-us/download/details.aspx?id=48146/) - .NET development environment
* [Microsoft MSSQL Express 2016 or higher] (https://www.microsoft.com/en-sa/sql-server/sql-server-downloads/) - SQL engine
```

### Installing

Here is step by step series of examples that tell you how to get environment running

Download in command line from github to your favorit directory

```
git clone https://github.com/jhoralek/OfficeSuppliersLinkSoft.git
```

Go to your directory with OfficeWuppliersLinkSoft project and open

```
OfficeSuppliersLinkSoft.sln
```

or open solution in Visual Studio.

Open **Properties** of solution and change from Single startup project to **Multiple startup projects**. Here change Action **OfficeSuppliersLinkSoft.Web** from None to **Start**

You need to set **connection string** to the database in 

**Web.config** in **OfficeSuppliersLinkSoft.Web** and
**App.config** in **OfficeSuppliersLinkSoft.Data**

```
<add name="OfficeSuppliersEntities" connectionString="Data Source=YOURS_DATABASE_ENGINE;Initial Catalog=OfficeSupplier;Integrated Security=SSPI;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient"/>
```

Connection string in App.config is used for Code First database generation and Data Seeds initialization
Web.config connection string is used for app itself

**Start it**

## Technology and Practices used

* Technology
  * ASP.NET MVC 5 Razor
  * Entity Framework 6

* Patterns
  * [Repository pattern] (https://msdn.microsoft.com/en-us/library/ff649690.aspx/)
  * [Unit Of Work] (https://www.codeproject.com/Articles/581487/Unit-of-Work-Design-Pattern/)
  
* Extensions
  * [AutoMapper] (http://automapper.org/) - mapping Models to ViewModels
  * [AutoFac] (https://autofac.org/) - for Dependency Injection
  * [FluentMvcTest] (https://github.com/TestStack/TestStack.FluentMVCTesting/) - Unit testing
  * [Bootstrap] (http://getbootstrap.com/) - Web layout


## Testing

I used only unit test as a suffitient solution. I chose FluentMvcTesting framework which provides a small an reliable interface for creating type-safe test againts MVC controllers

[FluentMvcTesting] (https://github.com/TestStack/TestStack.FluentMVCTesting/) - small fluent ASP.Net MVC testing framework

I used it for my first time. It can be extended with usual Asserts as require


```csharp
  [TestMethod]
  public void Index()
  {
      _controller.WithCallTo(g => g.Index())
          .ShouldRenderDefaultView()
          .WithModel<IEnumerable<Group>>(g => g.Count() > 0);
  }
   ```     
   
 ## Versioning
   
I use [Git] (https://git-scm.com/) for versioning

## Authors

* **Jiří Horálek**

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
