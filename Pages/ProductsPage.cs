using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class ProductsPage: BasePage {
    public ILocator ShoppingCartLnk;
    public ILocator TitleLbl;
    public ILocator AddToCartBtn;

    public ProductsPage(IPage page) : base(page) { 
        ShoppingCartLnk = page.Locator("id=shopping_cart_container");
        TitleLbl = page.Locator(".title");
        AddToCartBtn = page.Locator("\"Add to cart\"");
    }

    public async Task AddProductsToCart(int numProducts) {
        for (int i = 0; i < numProducts; i++) {
            await AddToCartBtn.Nth(i).ClickAsync();
        }

        await ShoppingCartLnk.ClickAsync();
    }
}