using industryconnect.Pages;
using industryconnect.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace industryconnect.Tests

{
    [TestFixture]
    internal class TM_Tests : CommonDriver
    {
       
        [SetUp]
        public void LoginFunction()
        {
            // Open Chrome browser
             driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); //to maximize the screen

            //Login page initialization and definition

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            //Home page initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.GoToHomePage(driver);

        }
        [Test]
        public void CreateTM_Test()
        {
            //Create page initilialization and definition

            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);


        }
        [Test]
        public void EditTM_Test()
        {
            //Edit TM
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTM(driver);

        }
        [Test]
        public void DeleteTM_Test()
        {
            //Delete TM
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTM(driver);

        }
        [TearDown]
        public void closeTestRun()
        {

        }
    }
}
