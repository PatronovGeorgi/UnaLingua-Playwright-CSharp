
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace UnaLingua.Tests.Helpers
{
    public class TestBase : PageTest
    {
        protected string BaseUrl => "https://www.unalingua.de";
        protected string XtrfUrl => "https://unalingua.s.xtrf.eu/customers/index.html#/sign-in";

        [SetUp]
        public async Task SetUp()
        {
            await Page.SetViewportSizeAsync(1920, 1080);
        }
    }
}