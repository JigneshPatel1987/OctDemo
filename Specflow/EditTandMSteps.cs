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
        [Given(@"Time and Material record")]
        public void GivenTimeAndMaterialRecord()
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
        
        [Given(@"I have browse Necessory edit time and material record")]
        public void GivenIHaveBrowseNecessoryEditTimeAndMaterialRecord()
        {
            // Home Page - clicking on adminsitration and time n materials
            HomePage instanceName = new HomePage(GlobalDriver.driver);
            instanceName.clickAdminstration();
            instanceName.clickTimenMaterial();
        }
        
        [Then(@"I should be able to edit Time and Material")]
        public void ThenIShouldBeAbleToEditTimeAndMaterial()
        {
            // Time & Material Page - Click on Edit Button and Edit Time and Material Value.
            TimeandMaterialPage instanceNameTandM = new TimeandMaterialPage(GlobalDriver.driver);
            instanceNameTandM.EditTimenMaterail();
            //Closing driver instance
            GlobalDriver.driver.Close();
        }
    }
}
