using System;
using System.Threading;
using OpenQA.Selenium;

namespace September2020.Pages
{
    class TMPage
    {

        //***Test Create Time Record***

        public void CreateTM(IWebDriver driver)
        {
            //GitHub Test!
            // Define an action for waiting the browser syncronization
            void wait()
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }

            // Click Create New
            IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNew.Click();
            wait();

            // Click Time in dropdown menu
            IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            TypeCode.Click();
            IWebElement Time = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            Time.Click();
            wait();

            // Write valid value in Code
            driver.FindElement(By.Id("Code")).SendKeys("12:30");

            // Write valid value in Description
            driver.FindElement(By.Id("Description")).SendKeys("You have assignment due.");

            //(*) Write valid value in Price per unit 
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("100");

            // Click Save 
            IWebElement Save = driver.FindElement(By.Id("SaveButton"));
            Save.Click();
            Thread.Sleep(2000);

            // Validate if the time record is added to the list
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();
            Thread.Sleep(1500);

            IWebElement expectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement expectedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (expectedCode.Text == "12:30" && expectedDescription.Text == "You have assignment due.")
            {
                Console.WriteLine("Time was added successfully!");
            }
            else
            {
                Console.WriteLine("Failure to add time record!");
            }
        }



        //***Test Edit Time Record***

        public void EditTM(IWebDriver driver)
        {
            // wait syncroniztion
            Thread.Sleep(1500);

            // Choose one item to click edit
            IWebElement Edit1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]"));
            Edit1.Click();
            Thread.Sleep(1500);

            // Modify the info
            driver.FindElement(By.Id("Code")).Clear();
            driver.FindElement(By.Id("Code")).SendKeys("Eskimo 12:20");
            driver.FindElement(By.Id("Description")).Clear();
            driver.FindElement(By.Id("Description")).SendKeys("Eskimo is coming on Sept!");

            // Click Save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(2000);

            // Validate if the value is changed
            IWebElement UpdatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

            if (UpdatedCode.Text == "Eskimo 12:20")
            {
                Console.WriteLine("Edit succesfully!");
            }
            else
            {
                Console.WriteLine("Failure to Edit!");
            }

        }



        //***Test Delete Time Record***

        public void DeleteTM(IWebDriver driver)
        {
            // Click one item to Delete
            Thread.Sleep(1500);
            var CodeDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]")).Text;
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();

            // Click Cancel to cancel Delete.
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Dismiss();

            // Validate if the record has been deleted
            Thread.Sleep(500);
            IWebElement ExpectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

            if (ExpectedCode.Text == CodeDelete)
            {
                Console.WriteLine("Delete was cancelled successfully!");
            }
            else
            {
                Console.WriteLine("Alert message test failed!");
            }



            // Click OK to confirm to delete

            // Check the next record below the target delete item
            Thread.Sleep(1000);
            var CodeDeleteNext = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[2]/td[1]")).Text;

            // Click Delete to delete the 1st record
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            Thread.Sleep(500);
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);

            // Validate if ther record has been deleted
            IWebElement ExpectedFirstRowCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
            if (ExpectedFirstRowCode.Text == CodeDeleteNext)
            {
                Console.WriteLine("Delete successfully!");
            }
            else {
                Console.WriteLine("Fail to Delete!");
            }
           

        }








    }
}
