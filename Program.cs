using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace industryconnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Open Chrome browser
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); //to maximize the screen

            // Launch Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // Identify user textbox and valid user name
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // Identify user textbox and valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // Click on Login Button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            //Check if user is login successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if(helloHari.Text=="Hello hari!")
            {
                Console.WriteLine("Logged in Successfully: Test Passed");

            }
            else
            {
                Console.WriteLine("Login Failed: Test Failed");
            }

        }
    }
}
