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
    [Parallelizable]
    internal class TM_Tests : CommonDriver
    {
       
       


        
        [Test, Order(1)]
        public void CreateTM_Test()
        {

        //Home page initialization and definition

        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMPage(driver);
        //Create page initilialization and definition

        TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTM(driver);


        }
        [Test, Order(2)]
        public void EditTM_Test()
        {

        //Home page initialization and definition

        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMPage(driver);
        //Edit TM
        TMPage tMPageObj = new TMPage();
            tMPageObj.EditTM(driver, "dummy","dummy1","dummy2");

        }
        [Test, Order(3)]
        public void DeleteTM_Test()
        {

        //Home page initialization and definition

        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMPage(driver);
        //Delete TM
        TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTM(driver);

        }

}
}
