using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{

    public static IConfiguration InitConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json")
            .Build();
        return configuration;
    }

    [Test]
    public async Task Clicking_PrivacyLink_Goes_To_PrivacyPage()
    {
        var config = InitConfiguration();
        await Page.GotoAsync(config["url"]);
        var link = Page.Locator("text=Privacy");
        await link.ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*/Privacy"));
    }
}