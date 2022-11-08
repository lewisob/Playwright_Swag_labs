using Microsoft.Playwright;

namespace Playwright_POC.Pages.Checkout;

public class COStepOnePage : BasePage
{
    public ILocator ShoppingCartLnk;
    public ILocator FirstNameTxt;
    public ILocator LastNameTxt;
    public ILocator ZipCodeTxt;
    public ILocator ContinueBtn;

    public COStepOnePage(IPage page) : base(page)
    {
        ShoppingCartLnk = page.Locator("id=shopping_cart_container");
        FirstNameTxt = page.Locator("id=first-name");
        LastNameTxt = page.Locator("id=last-name");
        ZipCodeTxt = page.Locator("id=postal-code");
        ContinueBtn = page.Locator("id=continue");
    }

    public async Task SubmitCustomerInformation(string fName, string lName, string postCode)
    {
        await FirstNameTxt.TypeAsync(fName);
        await LastNameTxt.TypeAsync(lName);
        await ZipCodeTxt.TypeAsync(postCode);
        await ContinueBtn.ClickAsync();
    }
}