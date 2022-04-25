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
            IWebElement actualTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            //Option 1
            Assert.That(actualCode.Text == "IndustryConnect", "Actual code and Expected code do not match");
            Assert.That(actualTypeCode.Text == "T", "Actual Type code and Expected Type code do not match");
            Assert.That(actualDescription.Text == "industry connect", "Actual Description and Expected Description do not match");
            Assert.That(actualPrice.Text == "$12.00", "Actual Price and Expected Price do not match");

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
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            //  Wait.WaitToBeVisible(driver, "XPATH", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            //click to go to last page
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();
            IWebElement findRecordCreated= driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (findRecordCreated.Text == "IndustryConnect")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited cant find");
            }
          

            //Type Edit Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys("Editedindustry");

            //Type Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys("edited industry connect program");

            //Type Price per unit
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTag.Click();
           
            priceTextbox.Clear();
            priceTag.Click();

            priceTextbox.SendKeys("700");

            //save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            //  Wait.WaitToBeVisible(driver, "XPATH", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            //click to go to last page
            IWebElement lastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton1.Click();


            Thread.Sleep(1000);

            // check if record is created in the table and has expected value
            IWebElement createdCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement createdTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement createdPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            //Option 1
            Assert.That(createdCode.Text == "Editedindustry", "Actual code and Expected code do not match");
            Assert.That(createdTypeCode.Text == "T", "Actual Type code and Expected Type code do not match");
            Assert.That(createdDescription.Text == "edited industry connect program", "Actual Description and Expected Description do not match");
            Assert.That(createdPrice.Text == "$700.00", "Actual Price and Expected Price do not match");
        }

        public void DeleteTM(IWebDriver driver)
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            //  Wait.WaitToBeVisible(driver, "XPATH", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", 2);
            //click to go to last page
            IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (findEditedRecord.Text == "Editedindustry")
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(1000);
                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                Assert.Fail("Record to be deleted cant find");
            }
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            IWebElement lastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton1.Click();
            Thread.Sleep(1000);
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            //Option 1
            Assert.That(editedCode.Text != "Editedindustry", "Actual code and Expected code do not match");
          //  Assert.That(editedTypeCode.Text != "T", "Actual Type code and Expected Type code do not match");
            Assert.That(editedDescription.Text != "edited industry connect program", "Actual Description and Expected Description do not match");
            Assert.That(editedPrice.Text != "$700.00", "Actual Price and Expected Price do not match");
        }




    }
}

