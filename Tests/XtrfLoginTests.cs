using NUnit.Framework;
using UnaLingua.Tests.Helpers;
using UnaLingua.Tests.Pages;

namespace UnaLingua.Tests.Tests
{
    [TestFixture]
    public class XtrfLoginTests : TestBase
    {
        private XtrfLoginPage _loginPage;

        [SetUp]
        public async Task TestSetUp()
        {
            _loginPage = new XtrfLoginPage(Page);
            await _loginPage.NavigateAsync();
        }

        [Test]
        public async Task Login_WithValidCredentials_ShouldSucceed()
        {
            await _loginPage.LoginAsync("georgi.patronov@unalingua.de", "QAtest26!");
            await Page.WaitForURLAsync("**/customers/**");
            Assert.That(Page.Url, Does.Contain("customers"));
        }

        [Test]
        public async Task Login_WithInvalidPassword_ShouldShowError()
        {
            await _loginPage.LoginAsync("georgi.patronov@unalingua.de", "wrongpassword");
            var error = await _loginPage.GetErrorMessageAsync();
            Assert.That(error, Does.Contain("invalid"));
        }

        [Test]
        public async Task Login_WithEmptyEmail_ShouldDisableButton()
        {
            var isDisabled = await _loginPage.IsSignInButtonDisabledAsync();
            Assert.That(isDisabled, Is.True);
        }
    }
}
