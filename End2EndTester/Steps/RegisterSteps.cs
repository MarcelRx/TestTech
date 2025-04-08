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
    
}