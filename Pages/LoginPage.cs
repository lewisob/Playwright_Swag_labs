using Microsoft.Playwright;

namespace Playwright_POC.Pages;

public class LoginPage: BasePage {
    private static string s_usernameTxt => "id=user-name";
    private static string s_passwordTxt => "id=password";
    private static string s_loginBtn => "id=login-button";
    private static string s_errorLbl => "data-test=\"error\"]";

    private static string s_url => "https://playwright.dev";

    public LoginPage(IPage page) : base(page) { }

    public async Task GotoAsync() {
        await Page.GotoAsync(s_url);
    }

    public async Task SubmitLoginDetails(string username, string password) {
        await Page.FillAsync(s_usernameTxt, username);
        await Page.FillAsync(s_passwordTxt, password);
    }
}