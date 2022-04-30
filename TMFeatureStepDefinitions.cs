using industryconnect.Pages;
using industryconnect.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace industryconnect
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        // Page Object Initilalization
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();

        TMPage tMPageObj = new TMPage();
        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            // Open Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); //to maximize the screen

            //Login page initialization and definition

            
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            //Home page initialization and definition

            
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            tMPageObj.CreateTM(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            
            string newCode = tMPageObj.GetEditedCode(driver);
            string newTypeCode = tMPageObj.GetEditedCode(driver);
            string newDescription = tMPageObj.GetEditedCode(driver);
            string newPrice = tMPageObj.GetEditedCode(driver);

            Assert.That(newCode == "IndustryConnect", "Actual code and Expected code do not match");
            Assert.That(newTypeCode == "T", "Actual Type code and Expected Type code do not match");
            Assert.That(newDescription == "industry connect", "Actual Description and Expected Description do not match");
            Assert.That(newPrice == "$12.00", "Actual Price and Expected Price do not match");

        }
        [When(@"I update '([^']*)', '([^']*)'and '([^']*)' on an existing time and material record")]
        public void WhenIUpdateAndOnAnExistingTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            
            tMPageObj.EditTM(driver,p0,p1,p2);
        }

        [Then(@"the record should have the updated '([^']*)','([^']*)'and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string p0, string p1, string p2)
        {
            
            string newEditedDescription = tMPageObj.getEditedDescription(driver);
            Assert.That(newEditedDescription == p0, "Actual Description and Expected Description do not match");
            string newEditedCode = tMPageObj.getEditedCode(driver);
            Assert.That(newEditedCode == p1, "Actual Code and Expected Code do not match");
            string newEditedPrice = tMPageObj.getEditedPrice(driver);
            Assert.That(newEditedPrice == p2, "Actual Price and Expected Price do not match");
        }

        

       



    }
}
