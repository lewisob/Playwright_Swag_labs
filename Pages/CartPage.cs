using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class CartPage: BasePage {
    private static string s_checkoutBtn => "id=checkout";
    private static string s_removeBtn => "\"Remove\"";

    public CartPage(IPage page) : base(page) { }
}