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
        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            // Open Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); //to maximize the screen

            //Login page initialization and definition

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            //Home page initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tMPageObj = new TMPage();
            string newCode = tMPageObj.GetCode(driver);
            string newTypeCode = tMPageObj.GetCode(driver);
            string newDescription = tMPageObj.GetCode(driver);
            string newPrice = tMPageObj.GetCode(driver);

            Assert.That(newCode == "IndustryConnect", "Actual code and Expected code do not match");
            Assert.That(newTypeCode == "T", "Actual Type code and Expected Type code do not match");
            Assert.That(newDescription == "industry connect", "Actual Description and Expected Description do not match");
            Assert.That(newPrice == "$12.00", "Actual Price and Expected Price do not match");

        }
        [When(@"I update '([^']*)' on an existing time and material record")]
        public void WhenIUpdateOnAnExistingTimeAndMaterialRecord(string p0 )
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTM(driver,p0);
        }

        [Then(@"the record should have the updated '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string p0)
        {
            TMPage tMPageObj = new TMPage();
            string newEditedDescription = tMPageObj.GetCode(driver);
            Assert.That(newEditedDescription == p0, "Actual Description and Expected Description do not match");
        }

    }
}
