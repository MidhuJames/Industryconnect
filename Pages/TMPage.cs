using industryconnect.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace industryconnect.Pages
{
    internal class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Create new record

            IWebElement recordButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            recordButton.Click();

            // Create Material option

            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typecodeDropdown.Click();

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            materialOption.Click();

            //Type Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("IndustryConnect");

            //Type Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("industry connect");

            //Type Price per unit
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            //save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
             Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
          //  Wait.WaitToBeVisible(driver, "XPATH", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            //click to go to last page
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();
            
         
            Thread.Sleep(1000);

            // check if record is created in the table and has expected value
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //Option 1
            Assert.That(actualCode.Text == "IndustryConnect", "Actual code and Expected code do not match");

            //Option 2
          //  if (actualCode.Text == "IndustryConnect")
           // {
            //   Assert.Pass("Material Record created Successfully: Test Passed");

           // }
           // else
           // {
            //   Assert.Fail("Material Record created Failed: Test Failed");
           //  }

        }

        public void EditTM(IWebDriver driver)
        {

        }

        public void DeleteTM(IWebDriver driver)
        {

        }
    }
}
