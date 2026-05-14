using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class InValidLoginStepDefinitions
    {
        ChromeDriver chromeDriver = new ChromeDriver();
        [Given("open browser window go to url and click on make appointment button")]
        public void GivenOpenBrowserWindowGoToUrlAndClickOnMakeAppointmentButton()
        {
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");
            chromeDriver.FindElement(By.Id("btn-make-appointment")).Click();
        }

        [Given("enter invalid username and password")]
        public void GivenEnterInvalidUsernameAndPassword()
        {
            chromeDriver.FindElement(By.Id("txt-username")).SendKeys("John");
            chromeDriver.FindElement(By.Id("txt-password")).SendKeys("NotAPassword");
        }
        [When("click login button")]
        public void WhenClickLoginButton()
        {
            chromeDriver.FindElement(By.Id("btn-login")).Click();
        }

        [Then("Login failed... Please ensure the username and password are valid.")]
        public void ThenLoginFailed_PleaseEnsureTheUsernameAndPasswordAreValid_()
        {
            string expectedText = "Login failed! Please ensure the username and password are valid.";
            string actualText = chromeDriver.FindElement(By.XPath("//p[@class='lead text-danger']")).Text;
            Assert.AreEqual(expectedText, actualText);
        }

    }
}
