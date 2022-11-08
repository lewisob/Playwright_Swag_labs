using Microsoft.Playwright;

namespace Playwright_POC.Pages.Checkout;

public class COCompletePage : BasePage
{
    public ILocator PonyExpressImg;

    public COCompletePage(IPage page) : base(page)
    {
        PonyExpressImg = page.Locator(".pony_express");
    }
}