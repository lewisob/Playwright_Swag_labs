using Microsoft.Playwright.NUnit;
using Playwright_POC.Data;
using Playwright_POC.Pages;
using Playwright_POC.Pages.Checkout;

namespace Playwright_POC.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ShoppingTests : PageTest
{
    LoginPage? loginPage;
    ProductsPage? productsPage;
    CartPage? cartPage;
    COStepOnePage? cOStepOnePage;
    COStepTwoPage? cOStepTwoPage;
    COCompletePage? cOCompletePage;

    [SetUp]
    public async Task Init()
    {
        loginPage = new LoginPage(Page);
        productsPage = new ProductsPage(Page);
        cartPage = new CartPage(Page);
        cOStepOnePage = new COStepOnePage(Page);
        cOStepTwoPage = new COStepTwoPage(Page);
        cOCompletePage = new COCompletePage(Page);

        await loginPage!.GotoAsync();
        await loginPage.SubmitLoginDetails(Constants.VALID_USERNAME, Constants.PASSWORD);
        await productsPage!.AddProductsToCart(3);
    }

    [Test]
    public async Task PurchaseXNumberProducts()
    {
        await cartPage!.Checkout();
        await cOStepOnePage!.SubmitCustomerInformation("Lewis", "Tester", "2000");
        await Expect(cOStepTwoPage!.ProductNameLnk).ToHaveCountAsync(3);
        await cOStepTwoPage.Continue();
        await Expect(cOCompletePage!.PonyExpressImg).ToBeVisibleAsync();
    }

    [Test]
    public async Task RemoveAProductFromCart()
    {
        await cartPage!.RemoveProducts(1);
        await cartPage.Checkout();
        await Expect(cOStepOnePage!.ShoppingCartLnk).ToHaveTextAsync("2");
        await cOStepOnePage.SubmitCustomerInformation("Lewis", "Tester", "2000");
        await Expect(cOStepTwoPage!.ProductNameLnk).ToHaveCountAsync(2);
        await cOStepTwoPage.Continue();
        await Expect(cOCompletePage!.PonyExpressImg).ToBeVisibleAsync();
    }
}