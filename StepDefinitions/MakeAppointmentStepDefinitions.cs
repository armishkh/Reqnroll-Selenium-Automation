using System;
using Reqnroll;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class MakeAppointmentStepDefinitions
    {
        ChromeDriver chromeDriver = new ChromeDriver();
        [Given("open browser window click on make appointment button")]
        public void GivenOpenBrowserWindowClickOnMakeAppointmentButton()
        {
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Navigate().GoToUrl("https://katalon-demo-cura.herokuapp.com/");
            chromeDriver.FindElement(By.Id("btn-make-appointment")).Click();
        }

        [When("enter valid username and pass")]
        public void WhenEnterValidUsernameAndPass()
        {
            chromeDriver.FindElement(By.Id("txt-username")).SendKeys("John Doe");
            chromeDriver.FindElement(By.Id("txt-password")).SendKeys("ThisIsNotAPassword");
        }

        [When("click on the login button")]
        public void WhenClickOnTheLoginButton()
        {
            chromeDriver.FindElement(By.Id("btn-login")).Click();
            WebDriverWait wait =new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));

            wait.Until(driver =>
                driver.FindElement(By.Id("combo_facility")));
        }

        [When("enter appointment details")]
        public void WhenEnterAppointmentDetails()
        {
            SelectElement facility=new SelectElement(chromeDriver.FindElement(By.Id("combo_facility")));
            facility.SelectByText("Tokyo CURA Healthcare Center");
            chromeDriver.FindElement(By.Id("chk_hospotal_readmission")).Click();
            chromeDriver.FindElement(By.Id("radio_program_medicare")).Click();
            IWebElement visitDate = chromeDriver.FindElement(By.Id("txt_visit_date"));

            visitDate.Clear();
            visitDate.SendKeys("15/05/2026");
            visitDate.SendKeys(Keys.Tab);
            chromeDriver.FindElement(By.Id("txt_comment")).SendKeys("automated by selenium ReqNRoll");
            
        }

        [When("click on book appointment button")]
        public void WhenClickOnBookAppointmentButton()
        {
            chromeDriver.FindElement(By.Id("btn-book-appointment")).Click();
        }

        [Then("appointment booked successfully")]
        public void ThenAppointmentBookedSuccessfully()
        {
            string expectedText = "Appointment Confirmation";
            string actualText = chromeDriver.FindElement(By.XPath("//h2[normalize-space()='Appointment Confirmation']")).Text;

            Assert.AreEqual(expectedText, actualText);
        }

    }
}
