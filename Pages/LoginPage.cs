using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class LoginPage: BasePage {
    public ILocator UsernameTxt;
    public ILocator PasswordTxt;
    public ILocator LoginBtn;
    public ILocator ErrorLbl;

    private static string s_url => "https://www.saucedemo.com/";

    public LoginPage(IPage page) : base(page) { 
        UsernameTxt = page.Locator("id=user-name");
        PasswordTxt = page.Locator("id=password");
        LoginBtn = page.Locator("id=login-button");
        ErrorLbl = page.Locator("data-test=\"error\"]");
    }

    public async Task GotoAsync() {
        await Page.GotoAsync(s_url);
    }

    public async Task SubmitLoginDetails(string username, string password) {
        await UsernameTxt.FillAsync(username);
        await PasswordTxt.FillAsync(password);
        await LoginBtn.ClickAsync();
    }
}