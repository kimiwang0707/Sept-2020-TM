using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Pages;

namespace September2020
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Initiate and define webdriver
            IWebDriver driver = new ChromeDriver();

            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);

            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
            tmObj.EditTM(driver);
            tmObj.DeleteTM(driver);            

        }
    }
}
