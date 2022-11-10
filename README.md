# Playwright - Swag Labs
A POC for [Playwright](https://playwright.dev/dotnet/) using .NET

This test framework was created to compare against the [Robot Framework POC](https://github.com/lewisob/Robot_Swag_labs). It removes the Robot Framework layer for comparison so we are calling Playwright directly. A [POM](https://www.browserstack.com/guide/page-object-model-in-selenium) approach was taken. It has 2 layers - the tests and the page objects.

### Setup
* [Install .NET](https://dotnet.microsoft.com/en-us/download)
* [Install PowerShell](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell)
* Install NUnit for Playwright - `dotnet add package Microsoft.Playwright.NUnit`
* cd into the project
* Run `dotnet build command`

### How to run tests
```bash
# Run all tests
dotnet test
# Run specific test
dotnet test --filter Name=PurchaseXNumberProducts
# Run test suite
dotnet test --filter Name=LoginTests
```