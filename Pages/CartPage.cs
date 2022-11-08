using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class CartPage: BasePage {
    public ILocator ShoppingCartLnk;
    public ILocator CheckoutBtn;
    public ILocator RemoveBtn;
    private static string s_checkoutBtn => "id=checkout";
    private static string s_removeBtn => "\"Remove\"";

    public CartPage(IPage page) : base(page) {
        ShoppingCartLnk = page.Locator("id=shopping_cart_container");
        CheckoutBtn = page.Locator("id=checkout");
        RemoveBtn = page.Locator("\"Remove\"");
    }

    public async Task Checkout() {
        await CheckoutBtn.ClickAsync();
    }

    public async Task RemoveProducts(int numProducts) {
        for (int i = 0; i < numProducts; i++) {
            await RemoveBtn.Nth(i).ClickAsync();
        }
    }
}