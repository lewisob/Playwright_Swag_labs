using Microsoft.Playwright.NUnit;
using Playwright_POC.Pages;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class LoginTests : PageTest
{
    [Test]
    public async Task LogInAsValidUser()
    {
        LoginPage loginPage = new LoginPage(Page);
        ProductsPage productsPage = new ProductsPage(Page);

        await loginPage.GotoAsync();
        await loginPage.SubmitLoginDetails("standard_user", "secret_sauce");

        await Expect(productsPage.Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
        await Expect(productsPage.TitleLbl).ToHaveTextAsync("Products");
        await Expect(productsPage.ShoppingCartLnk).ToBeVisibleAsync();
    }

    [Test]
    public async Task AttemptToLoginWithInvalidCredentials() {
        LoginPage loginPage = new LoginPage(Page);
        ProductsPage productsPage = new ProductsPage(Page);

        await loginPage.GotoAsync();
        await loginPage.SubmitLoginDetails("user_xyz", "secret_sauce");

        await Expect(loginPage.Page).ToHaveURLAsync("https://www.saucedemo.com/");
        await Expect(loginPage.ErrorLbl).ToHaveTextAsync("Epic sadface: Username and password do not match any user in this service");
        await Expect(productsPage.ShoppingCartLnk).Not.ToBeVisibleAsync();
    }

    [Test]
    public async Task AttemptToLoginWithLockedUser() {
        LoginPage loginPage = new LoginPage(Page);
        ProductsPage productsPage = new ProductsPage(Page);

        await loginPage.GotoAsync();
        await loginPage.SubmitLoginDetails("locked_out_user", "secret_sauce");

        await Expect(loginPage.Page).ToHaveURLAsync("https://www.saucedemo.com/");
        await Expect(loginPage.ErrorLbl).ToHaveTextAsync("Epic sadface: Sorry, this user has been locked out.");
        await Expect(productsPage.ShoppingCartLnk).Not.ToBeVisibleAsync();
    }
}