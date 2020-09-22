using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace September2020.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            //Lauch browser and enter the URL
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");


            //Maximize web browser (This step bases on actual situation)
            driver.Manage().Window.Maximize();

            // Identify username textbox and enter username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            // Identify password textbox and enter password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            // Identify login button and click login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            // Validate if the user is logged in succesfully
            IWebElement hellohari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (hellohari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in successfully. The test passed!");

            }
            else {

                Console.WriteLine("Fail to login. Test failed!");
            }

        }
    }
}
