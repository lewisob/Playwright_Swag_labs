using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class BasePage
{
    public IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }
}
