using industryconnect.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace industryconnect.Utilities
{
    internal class CommonDriver
    {
        public static IWebDriver driver;
        [OneTimeSetUp]
        public void LoginFunction()
        {
            // Open Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); //to maximize the screen

            //Login page initialization and definition

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }
            [OneTimeTearDown]
            public void closeTestRun()
            {
                driver.Quit();

            }



    }
}
