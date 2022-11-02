using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class ProductsPage: BasePage {
    private static string s_shoppingCartLnk => "id=shopping_cart_container";
    private static string s_titleLbl => ".title";
    private static string s_addToCartBtn => "\"Add to cart\"";

    private static string s_url => "https://www.saucedemo.com/";

    public ProductsPage(IPage page) : base(page) { }
}