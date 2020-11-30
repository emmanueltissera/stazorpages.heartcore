# StazorPages.Heartcore

Creates static HTML pages on the first request to an [ASP.NET Core 5.0](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-5.0) MVC project. A [StazorPages](https://github.com/emmanueltissera/stazorpages) plugin for [Umbraco Heartcore](https://umbraco.com/products/umbraco-heartcore/). Allows you to create a static website with ASP.NET Core 5.0.

## How it works

![Stazor Pages Lifecycle](https://raw.githubusercontent.com/emmanueltissera/stazorpages/master/Assets/Images/stazor-pages-lifecycle.gif "Stazor Pages Lifecycle")

## Prerequisites

* ASP.NET Core 5.0

## NuGet Package

This plugin is available as a NuGet Package at [https://www.nuget.org/packages/StazorPages.Heartcore](https://www.nuget.org/packages/StazorPages.Heartcore).

## Sample sites

A simple site with just one content type implemented using this `StazorPages.Heartcore` plugin can be found at [https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore](https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore). This is the best place to get started.

A more comprehensive site runs on `StazorPages.Heartcore` at [https://lordlamingtonheartcore.azurewebsites.net/](https://lordlamingtonheartcore.azurewebsites.net/). The source code for the fictional Lord Lamington's site can be found at [https://github.com/emmanueltissera/lordlamington.heartcore](https://github.com/emmanueltissera/lordlamington.heartcore).

## Getting Started
To use this `StazorPages.Heartcore` plugin, complete the following steps:

1. Create a new ASP.NET Core Web Application (Model-View-Controller) project with ASP.NET Core 5.0.
2. Add in references to the following NuGet packages using the Package Manager.
```cmd
Install-Package StazorPages -Prerelease
Install-Package StazorPages.Heartcore -Prerelease
```
3. Modify your `appsetting.config` to add configuration to point to your Umbraco Heartcore project. See [this sample appsettings.config file](https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore/blob/master/TwentyFourDaysIn.StazorPages.Heartcore/appsettings.json).
4. Create a model based on your Umbraco Heartcore Document Type.  This model will need to derive from `HeartcorePage` and implement the `IRetrievedContent` interface. The class also needs to be decorated with the `ModelBinde`r attribute with the type of `StazorPages.Routing.RouteDataModelBinder`. The `MapToType()` method can use the `StazorPages.Heartcore.Models.HeartcorePage.MapCommonProperties()` to map fields such as Id, Url, Name and IsVisible. See [this sample Cafe model](https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore/blob/master/TwentyFourDaysIn.StazorPages.Heartcore/Models/Cafe.cs).
5. Add a controller to render out your model.See [this sample controller](https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore/blob/master/TwentyFourDaysIn.StazorPages.Heartcore/Controllers/CafeController.cs)
6. Add a view file to render your model. See [this sample view](https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore/blob/master/TwentyFourDaysIn.StazorPages.Heartcore/Views/Cafe/Index.cshtml).
7. An implementation of `ITypeResolver` is needed so that the StazorPages Middleware could map a `ContentTypeAlias` to a strongly typed model. A [simple implementation can be found here](https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore/blob/master/TwentyFourDaysIn.StazorPages.Heartcore/Resolvers/TypeResolver.cs).
8. Wire up the `Startup.cs` file. In `ConfigureServices()` make a call to `services.AddStazorPagesHeartcore()` and in `Configure()`, call `app.UseStazorPages(env)`. You also need to map an endpoint for StazorPages using `endpoints.MapStazorPages()`. See [this sample Startup.cs file](https://github.com/emmanueltissera/TwentyFourDaysIn.StazorPages.Heartcore/blob/master/TwentyFourDaysIn.StazorPages.Heartcore/Startup.cs).



## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)