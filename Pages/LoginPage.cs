using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace industryconnect.Pages
{
    internal class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            // Open Chrome browser
           

            // Launch Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            try
            {
                // Identify user textbox and valid user name
                IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
                usernameTextbox.SendKeys("hari");

                // Identify user textbox and valid password
                IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
                passwordTextbox.SendKeys("123123");

                // Click on Login Button
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                loginButton.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp Portal Login Page didnot launch", ex.Message);
                    throw;
            }
            

            //Check if user is login successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            
        }
    }
}
