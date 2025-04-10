namespace End2EndTester.Steps;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class RegisterSteps
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;

    [BeforeScenario]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new() { Headless = false, SlowMo = 0 });
        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }
    
    [AfterScenario]
    public async Task Teardown()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
    
    [Given(@"I am at the formbridge homepage")]
    public async Task GivenIAmAtTheFormbridgeHomepage()
    {
        await _page.GotoAsync("http://localhost:5173/");
    }

    [Given(@"I see the login button")]
    public async Task GivenISeeTheLoginButton ()
    {
        //await _page.WaitForTimeoutAsync(1000);
        var element =await _page.QuerySelectorAsync("[id='cta-button']");
        Assert.NotNull(element);


    }

    [When(@"I am click on the login button")]
    public async Task WhenIAmClickOnTheLoginButton()
    {
        await _page.ClickAsync("[id='cta-button']");
    }

    [Then(@"I should see the login page")]
    public async Task ThenIShouldSeeTheLoginPage()
    {
        await _page.WaitForURLAsync("**/login");
        Assert.Contains("/login", _page.Url);
        
    }
    
    [Given("I am on the login page")]
    public async Task GivenIAmOnTheLoginPage()
    {
        await _page.GotoAsync("http://localhost:5173/login");
    }

    [When(@"I enter ""(.*)"" as the email")]
    public async Task WhenIEnterEmail(string email)
    {
        await _page.FillAsync("input[name='email']", email);
    }

    [When(@"I enter ""(.*)"" as the password")]
    public async Task WhenIEnterPassword(string password)
    {
        await _page.FillAsync("input[name='password']", password);
    }

    [When("I click on the sign in button")] 
    public async Task WhenIClickOnTheSignInButton()
    {
        await _page.ClickAsync("button.login");
    }

    [Then("I should be logged in")]
    public async Task ThenIShouldBeLoggedIn()
    {
        await _page.WaitForSelectorAsync(".user-avatar", new() { Timeout = 1000 });
    }
}



