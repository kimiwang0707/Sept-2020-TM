using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Pages;

namespace September2020
{

    [TestFixture]
    class Program
    {
        IWebDriver driver;

        static void Main(string[] args)
        {                
        }

        [SetUp]
        public void LoginTurnUp()
        {
            //Initiate and define webdriver
            driver = new ChromeDriver();

            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }

        [Test]
        public void CreateTMTest()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
        }

        [Test]
        public void EditTMTest()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            TMPage tmObj = new TMPage();
            tmObj.EditTM(driver);
        }

        [Test]
        public void DeleteTMTest()
        {
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            TMPage tmObj = new TMPage();
            tmObj.DeleteTM(driver);
        }

        [TearDown]
        public void TestClosure()
        {
            //close instance of open chrome driver
            driver.Quit();
        }

    }
}
