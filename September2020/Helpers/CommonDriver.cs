using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Pages;

namespace September2020.Helpers
{
    public class CommonDriver
    {
        // Then other class can call the element directly
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void LoginTurnUp()
        {
            //Initiate and define webdriver
            driver = new ChromeDriver();

            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }


        [OneTimeTearDown]
        public void TestClosure()
        {
            //close instance of open chrome driver
            driver.Quit();
        }
    }
}
