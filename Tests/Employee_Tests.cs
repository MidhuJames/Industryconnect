using industryconnect.Pages;
using industryconnect.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace industryconnect.Tests
{
    [TestFixture]
    [Parallelizable]
    internal class Employee_Tests : CommonDriver
    {

        
        [Test, Order(1)]
        public void CreateEmployee_Test()
        {

            //Home page initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);

            //Create page initilialization and definition

            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.CreateEmployee(driver);


        }
        [Test, Order(2)]
        public void EditEmployee_Test()
        {

            //Home page initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);

            //Edit Employee
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.EditEmployee(driver);

        }
        [Test, Order(3)]
        public void DeleteEmployee_Test()
        {

            //Home page initialization and definition

            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver);

            //Delete Employee
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.DeleteEmployee(driver);

        }
        
    }
}

