using Microsoft.Playwright.NUnit;
using Playwright_POC.Data;
using Playwright_POC.Pages;

namespace Playwright_POC.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTests : PageTest
{
    LoginPage? loginPage;
    ProductsPage? productsPage;

    [SetUp]
    public async Task Init()
    {
        loginPage = new LoginPage(Page);
        productsPage = new ProductsPage(Page);

        await loginPage!.GotoAsync();
    }

    [Test]
    public async Task LogInAsValidUser()
    {
        await loginPage!.SubmitLoginDetails(Constants.VALID_USERNAME, Constants.PASSWORD);

        await Expect(productsPage!.Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
        await Expect(productsPage.TitleLbl).ToHaveTextAsync("Products");
        await Expect(productsPage.ShoppingCartLnk).ToBeVisibleAsync();
    }

    [Test]
    public async Task AttemptToLoginWithInvalidCredentials()
    {
        await loginPage!.SubmitLoginDetails(Constants.INVALID_USERNAME, Constants.PASSWORD);

        await Expect(loginPage.Page).ToHaveURLAsync("https://www.saucedemo.com/");
        await Expect(loginPage.ErrorLbl).ToHaveTextAsync("Epic sadface: Username and password do not match any user in this service");
        await Expect(productsPage!.ShoppingCartLnk).Not.ToBeVisibleAsync();
    }

    [Test]
    public async Task AttemptToLoginWithLockedUser()
    {
        await loginPage!.SubmitLoginDetails(Constants.LOCKED_USERNAME, Constants.PASSWORD);

        await Expect(loginPage.Page).ToHaveURLAsync("https://www.saucedemo.com/");
        await Expect(loginPage.ErrorLbl).ToHaveTextAsync("Epic sadface: Sorry, this user has been locked out.");
        await Expect(productsPage!.ShoppingCartLnk).Not.ToBeVisibleAsync();
    }
}