using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Helpers;
using September2020.Pages;

namespace September2020
{

    [TestFixture]
    [Parallelizable]
    class TMTest : CommonDriver
    {

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

       

    }
}
