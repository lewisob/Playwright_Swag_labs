using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class COStepOnePage: BasePage {
    private static string s_firstNameTxt => "id=first-name";
    private static string s_lastNameTxt => "id=last-name";
    private static string s_zipCodeTxt => "id=postal-code";
    private static string s_continueBtn => "id=continue";

    public COStepOnePage(IPage page) : base(page) { }
}