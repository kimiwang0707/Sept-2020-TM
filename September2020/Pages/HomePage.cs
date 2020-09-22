using System;
using OpenQA.Selenium;

namespace September2020.Pages
{
    public class HomePage
    {
        public void NavigateToTM(IWebDriver driver)
        {
            // Click Administration
            IWebElement Administrator = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            Administrator.Click();

            // Click Time&Material in dropdown menu
            IWebElement TimeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TimeMaterial.Click();
 
            
        }
    }
}
