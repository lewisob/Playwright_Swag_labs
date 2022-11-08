using Microsoft.Playwright;

namespace Playwright_POC.Pages.Checkout;

public class COStepTwoPage : BasePage
{
    public ILocator ProductNameLnk;
    public ILocator FinishBtn;

    public COStepTwoPage(IPage page) : base(page)
    {
        ProductNameLnk = page.Locator(".cart_item");
        FinishBtn = page.Locator("id=finish");
    }

    public async Task Continue()
    {
        await FinishBtn.ClickAsync();
    }
}