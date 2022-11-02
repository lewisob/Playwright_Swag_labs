using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class COStepTwoPage: BasePage {
    private static string s_productNameLnk => ".cart_item";
    private static string s_finishBtn => "id=finish";
    
    public COStepTwoPage(IPage page) : base(page) { }
}