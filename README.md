## DotNetArchitecture

## Best Practices and Technologies:

* Visual Studio 2017
* Visual Studio Code (step by step below)
* .NET Framework 4.7.1
* .NET Core 2.0
* C# 7.2
* ASP.NET Core 2.0
* Angular 5.2.9
* Typescript 2.7.2
* HTML5
* CSS3
* SASS (Syntactically Awesome Style Sheets)
* DDD (Domain-Driven Design)
* SOLID Principles
* Unit Test
* Unit of Work Pattern
* Repository Pattern
* Dependency Injection (Microsoft.Extensions.DependencyInjection)
* ORM - Object-Relational Mapping - Entity Framework Core 2.0 (Microsoft.EntityFrameworkCore)
* JWT - Json Web Token (Microsoft.IdentityModel.Tokens)
* Memory Caching (Microsoft.Extensions.Caching.Memory)
* Response Caching (Microsoft.AspNetCore.ResponseCaching)
* Object Mapping (AgileMapper)

## Continuous Integration Build Status:

[![Build Status](https://ci.appveyor.com/api/projects/status/x9782f129frchg3n?svg=true)](https://ci.appveyor.com/project/rafaelfgx/dotnetarchitecture)

## Layers:

![Screenshot](Screenshots/1.png)

## Application:

![Screenshot](Screenshots/2.png)

## Repository:

![Screenshot](Screenshots/3.png)

## Unit Test:

![Screenshot](Screenshots/4.png)

## ASP.NET Core + Angular:

![Screenshot](Screenshots/5.png)

## ASP.NET Core Startup:

![Screenshot](Screenshots/6.png)

## ASP.NET Core Controller:

![Screenshot](Screenshots/7.png)

## Angular Guard:

![Screenshot](Screenshots/8.png)

## Angular Error Handler:

![Screenshot](Screenshots/9.png)

## Angular HTTP Interceptor:

![Screenshot](Screenshots/10.png)

## Angular Service with Cache:

![Screenshot](Screenshots/11.png)

## Angular Login Component:

![Screenshot](Screenshots/12.png)

## ASP.NET Core + Angular Initial Loading:

![Screenshot](Screenshots/13.png)

## ASP.NET Core + Entity Framework Core + SQL Server + Angular Performance:

![Screenshot](Screenshots/14.png)

## Run in Visual Studio Code:

**NOTE:** If **Visual Studio 2017** is installed and the **packages** folder exists, go to **step 4**.

1. Install **SDKs** (.NET Core 2.x and .NET Framework 4.7.1):
https://www.microsoft.com/net/download/visual-studio-sdks

2. Download latest **nuget.exe** and copy to **Solution Folder**:
https://www.nuget.org/downloads

3. Open **Command Prompt** in **Solution Folder** and run **nuget restore**.

4. Install **C#** extension in **Visual Studio Code**.

5. Open **Solution Folder** in **Visual Studio Code**.

6. Press **F5**, run and fun!

## Publish and Run in IIS:

1. Install **NET Core 2.0 Windows Hosting**: https://aka.ms/dotnetcore-2-windowshosting.

2. Change the **SQL Server Database Connection String** in the **AppSettings.json** files.

3. Change the **base-href** variable in the **scripts** section in the **ClientApp\package.json** file:
	- "production": "--base-href=/**IIS_APPLICATION_NAME**/"

4. Publish ASP.NET Core Project in the Visual Studio.

5. Copy the published files to **IIS Directory** (inetpub\wwwroot\\**IIS_APPLICATION_NAME**).

6. In the **IIS**, create an **Application Pool** with **.NET CLR Version** = **No Managed Code**.

7. In the **IIS**, **Convert to Application** and use the **Application Pool** created in the previous step.

8. Run and fun!
