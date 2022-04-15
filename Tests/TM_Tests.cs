using industryconnect.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace industryconnect.Tests

{
    internal class TM_Tests
    {
        static void Main(string[] args)
        {
            // Open Chrome browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); //to maximize the screen

            //Login page initialization and definition

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            //Home page initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.GoToHomePage(driver);

            //Create page initilialization and definition

            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);

            //Edit TM
            tMPageObj.EditTM(driver);

            //Delete TM
            tMPageObj.DeleteTM(driver);
        }
    }
}
