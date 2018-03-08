using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SedolTests.Ui.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[name='sedolInput']")]
        private IWebElement SedolTextInput;

        [FindsBy(How = How.XPath, Using = "//*[@id='div1']/p[1]/input")]
        private IWebElement ValidSedolCheckBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='div1']/p[2]/input")]
        private IWebElement UserDefinedCheckBox;

        [FindsBy(How = How.CssSelector, Using = "input#submitSedol")]
        private IWebElement SubmitButton;

        public void ValidateSedol(string sedolInput, bool isValidSedol, bool isUserDefined) {
            SedolTextInput.Clear();
            SedolTextInput.SendKeys(sedolInput);
            if (isValidSedol && !ValidSedolCheckBox.Selected) 
            {
                ValidSedolCheckBox.Click();       
            }
            if (isUserDefined && !UserDefinedCheckBox.Selected)
            {
                UserDefinedCheckBox.Click();
            }
            SubmitButton.Click();
        }

        public string GetValidationMessage() {
            try
            {
                // field is not present if no validation message should be returned
                return driver.FindElement(By.CssSelector("div.loader")).Text;
            } catch(NoSuchElementException) 
            {
                return "";    
            }
        }
    }
}
