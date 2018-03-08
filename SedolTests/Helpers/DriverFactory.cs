using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SedolTests.Helpers
{
    public class DriverFactory
    {
        private DriverFactory(){}

        public static IWebDriver GetDriver() {
            return new ChromeDriver();
        }
    }
}
