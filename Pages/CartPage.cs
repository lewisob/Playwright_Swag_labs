using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class CartPage: BasePage {
    public ILocator CheckoutBtn;
    public ILocator RemoveBtn;
    private static string s_checkoutBtn => "id=checkout";
    private static string s_removeBtn => "\"Remove\"";

    public CartPage(IPage page) : base(page) {
        CheckoutBtn = page.Locator("id=checkout");
        RemoveBtn = page.Locator("\"Remove\"");
    }

    public async Task Checkout() {
        await CheckoutBtn.ClickAsync();
    }
}