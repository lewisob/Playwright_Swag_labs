using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class COCompletePage: BasePage {
    private static string s_ponyExpressImg => ".pony_express";

    public COCompletePage(IPage page) : base(page) { }
}