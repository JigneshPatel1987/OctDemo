using _087Nov18;
using HostDev.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace HostDev.Specflow
{
    [Binding]
    public class TandMSteps
    {
        [Given(@"Navigate to Time and Material record Page")]
        public void GivenNavigateToTimeAndMaterialRecordPage()
        {
            //Creating instance of chrome driver
            GlobalDriver.driver = new ChromeDriver();

            // IWebDriver driver = new ChromeDriver();
            GlobalDriver.driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");
            ExcelLibHelpers.PopulateInCollection(@"E:\TestData\TestDataForHorseDev.xlsx", "Login");

            // login page :: Identifying and sending valid inputs
            LoginPage loginPage = new LoginPage(GlobalDriver.driver);
            loginPage.LoginSuccess();
        }
        
        [Given(@"I have  to browse Necessory Delete time and material record")]
        public void GivenIHaveToBrowseNecessoryDeleteTimeAndMaterialRecord()
        {
            // Home Page - clicking on adminsitration and time n materials
            HomePage instanceName = new HomePage(GlobalDriver.driver);
            instanceName.clickAdminstration();
            instanceName.clickTimenMaterial();
        }
        
        [Then(@"I should be able to Delete Time and Material")]
        public void ThenIShouldBeAbleToDeleteTimeAndMaterial()
        {
            // Time & Material Page - Click on Delete and Confirm Delete Time and Material value.
            TimeandMaterialPage instanceNameTandM = new TimeandMaterialPage(GlobalDriver.driver);
            instanceNameTandM.deleteTimenMaterial();
            //Closing driver instance
            GlobalDriver.driver.Close();
        }
    }
}
