# Application Configuration with App Config File

## What is the App Config File?

The App.config file is a configuration file used in .NET applications to store settings and configurations. It is an XML file that accompanies your application and is typically named `App.config` for desktop applications or `appsettings.json` for newer .NET Core and ASP.NET Core applications.

## Purpose of the App Config File:

The primary purpose of the App.config file is to provide a **centralized location** for configuring parameters that affect the behavior of the application. This includes settings such as database connection strings, API keys, application-level constants, and other configuration values.

### It is the main place to store:
- Connection strings to databases
- Connection details to external services
- Application settings
- Other details on how the application should be run or hosted

### How to add a database connection string to my application?
- First right click on references > Add references 
- Select System.Configuration from Assemblies
- Once added we can start adding custom configurations

<details>

<summary>Simplified example to add a connection string with **Binding**</summary>

```xml
<!-- XAML Example for Data Binding (not a database connection string) -->
<Window x:Class="YourNamespace.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:YourNamespace"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525">

    <Grid>
        <TextBlock Text="{Binding DatabaseConnectionString}" HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Grid>
</Window>
```

**App.config** :
```xml
<configuration>
    <appSettings>
        <add key="DatabaseConnectionString" 
        value="Server=myServer;
        Database=myDatabase;
        User=myUser;
        Password=myPassword;" />
        <add key="LogLevel" value="Debug" />
    </appSettings>
</configuration>
```
</details>

## Example of App.config (XML):

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="DatabaseConnectionString" value="Server=myServer;Database=myDatabase;User=myUser;Password=myPassword;" />
    <add key="LogLevel" value="Debug" />
  </appSettings>
</configuration>
```

In this example, the App.config file contains two key-value pairs within the **<appSettings>** section. These values can be accessed programmatically in the application code.

## Reading Configuration in Code:
In .NET applications, you can access the configuration settings defined in the App.config file using the **ConfigurationManager** class. Here's an example in C#:

```csharp
using System;
using System.Configuration;

class Program
{
    static void Main()
    {
        // Reading values from App.config
        string connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];
        string logLevel = ConfigurationManager.AppSettings["LogLevel"];

        // Use the values in your application logic
        Console.WriteLine($"Database Connection String: {connectionString}");
        Console.WriteLine($"Log Level: {logLevel}");
    }
}
```

## Example of appsettings.json (JSON):
```json
{
  "ConnectionStrings": {
    "Database": "Server=myServer;Database=myDatabase;User=myUser;Password=myPassword;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug"
    }
  }
}
```

In .NET Core and ASP.NET Core applications, **appsettings.json** is commonly used. It follows a JSON format but serves a similar purpose for configuration.

## Reading Configuration in .NET Core:

In .NET Core applications, you can use the **Configuration** class to read values from **appsettings.json**. Here's an example in C#:

```csharp
using Microsoft.Extensions.Configuration;
using System;

class Program
{
    static void Main()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        // Reading values from appsettings.json
        string connectionString = configuration.GetConnectionString("Database");
        string logLevel = configuration["Logging:LogLevel:Default"];

        // Use the values in your application logic
        Console.WriteLine($"Database Connection String: {connectionString}");
        Console.WriteLine($"Log Level: {logLevel}");
    }
}
```

## Conclusion:
The App.config file (or appsettings.json) provides a convenient and flexible way to manage configuration settings in .NET applications. It separates configuration from code, making it easier to update settings without modifying the application's source code.
