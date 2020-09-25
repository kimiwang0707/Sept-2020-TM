using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace September2020.Helpers
{
    class Wait
    {
        
        public static void WaitForElement(IWebDriver driver, string key, string value)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                if (key == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(value)));
                }
                if (key == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(value)));
                }
                if (key == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(value)));
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Fail to wait for the element", ex.Message);
            }
        }



        // Can set waiting time in this constructor
        public static void WaitForElementVisibility(IWebDriver driver, string key, string value, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));

                if (key == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(value)));
                }

                if (key == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(value)));
                }

                if (key == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(value)));
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Element failed to be visible.", ex.Message);
            }

        }


    }
}
