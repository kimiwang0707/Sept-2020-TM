using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace September2020.Pages
{
    class CompanyPage
    {

        // *** Create  company record ***
        public void CreateCompany(IWebDriver driver)
        {

            //Click Create New
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

            //Input name
            Thread.Sleep(1500);
            IWebElement Name = driver.FindElement(By.Id("Name"));
            Name.SendKeys("Super Star Company");

            // Click Edit to input contact
            driver.FindElement(By.Id("EditContactButton")).Click();
            Thread.Sleep(1500);

            // Input contact
            IWebElement iframe = driver.FindElement(By.ClassName("k-content-frame"));
            driver.SwitchTo().Frame(iframe);

            driver.FindElement(By.Id("FirstName")).SendKeys("Taylor");
            driver.FindElement(By.Id("LastName")).SendKeys("Swift");
            driver.FindElement(By.Id("PreferedName")).SendKeys("Taytay");
            driver.FindElement(By.Id("Phone")).SendKeys("911");
            driver.FindElement(By.Id("Mobile")).SendKeys("110");
            driver.FindElement(By.Id("email")).SendKeys("taylorswift@gmail.com");
            driver.FindElement(By.Id("autocomplete")).SendKeys("test address");
            driver.FindElement(By.Id("Street")).SendKeys("Taiping Street");
            driver.FindElement(By.Id("City")).SendKeys("Auckland");
            driver.FindElement(By.Id("Postcode")).SendKeys("1055");
            driver.FindElement(By.Id("Country")).SendKeys("New Zealand");
            Thread.Sleep(2000);

            // Click Save Company to create new record
            driver.FindElement(By.Id("submitButton")).Click();
            Thread.Sleep(2000);

            // Return default content
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);

            // Save button
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(2000);
            //Scroll to bottom


            // Go to last page
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[4]/a[4]/span")).Click();
            Thread.Sleep(1500);

            // validate if the company record is added to the list
            IWebElement lastItem = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastItem.Text == "Super Star Company")
            {
                Console.WriteLine("Create company successfully");
            }
            else {
                Console.WriteLine("Fail to create company!");
            }
        }



        // *** Edit company record ***
        public void EditCompany(IWebDriver driver)
        {
            // Click the 1st row item to edit
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[1]")).Click();

            // Input new data
            Thread.Sleep(1500);
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys("Donald Trump");

            // Click Save Company
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(1500);

            // Validate if the item was updated
            IWebElement FirstRowName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]"));
            if (FirstRowName.Text == "Donald Trump")
            {
                Console.WriteLine("Edit company successfully");
            }
            else
            {
                Console.WriteLine("Fail to edit company!");
            }
        }



        // *** Delete company record ***
        public void DeleteCompany(IWebDriver driver)
        {
            try
            {
                // Validate the alert window with cancel operation
                // Record the 1st row item
                Thread.Sleep(2000);
                IWebElement FirstItemName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                // Click the 1st item to delete
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[2]")).Click();
                Thread.Sleep(1000);

                // Click Cancel
                driver.SwitchTo().Alert().Dismiss();
                Thread.Sleep(1500);

                IWebElement deleteItem = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]"));
                if (deleteItem.Text == FirstItemName.Text)
                {
                    Console.WriteLine("Cancel delete company successfully");
                }
                else
                {
                    Console.WriteLine("Fail to cancel delete company!");
                }

                // Validate the alert window with OK to delete

                // Recond second row data
                Thread.Sleep(1500);
                IWebElement SecondItemName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[2]/td[1]"));

                // click delete again
                driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[3]/a[2]")).Click();
                Thread.Sleep(500);

                // click OK to delete
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(2000);

                // Validate if the second row change to first row
                IWebElement FirstItemName1 = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[1]/td[1]"));

                if (FirstItemName1.Text == SecondItemName.Text)
                {
                    Console.WriteLine("Delete company successfully");
                }
                else
                {
                    Console.WriteLine("Fail to delete company!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("System failure to delete company!"); 
            }

        }


    }
}
