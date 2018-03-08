using System;
using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SedolTests.Helpers;
using SedolTests.Models;
using SedolTests.Ui.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SedolTests.StepDefinition
{
    [Binding]
    public class Steps
    {
        private HomePage homePage;
        private IWebDriver driver;

        [BeforeScenario(Order = 0)]
        public void OpenHomePage()
        {
            driver = DriverFactory.GetDriver();
            driver.Url = "http://sedolwebapp20180202014935.azurewebsites.net/";
            homePage = new HomePage(driver);
        }

        [AfterScenario(Order = 0)]
        public void ClearCookies()
        {
            driver.Quit();
        }

        [Given(@"the following sedol values:")]
        public void WhenUserEnterCredentials(Table table)
        {
            var data = table.CreateInstance<SedolData>();
            homePage.ValidateSedol(data.InputString, data.IsValidSedol, data.IsUserDefined);
        }

        [Then(@"the validation message should be '(.*)'")]
        public void ValidateMessage(string expectedValidationMessage)
        {
            homePage = new HomePage(driver);
            var actualValidationMessage = homePage.GetValidationMessage();
            Assert.AreEqual(expectedValidationMessage, actualValidationMessage);
        }
    }
}
