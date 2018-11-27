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
        [Given(@"Create Time and Material")]
        public void GivenCreateTimeAndMaterial()
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
        
        [Given(@"I have logged in to the TurnUp Portal")]
        public void GivenIHaveLoggedInToTheTurnUpPortal()
        {
            // Home Page - clicking on adminsitration and time n materials
            HomePage instanceName = new HomePage(GlobalDriver.driver);
            instanceName.clickAdminstration();
            instanceName.clickTimenMaterial();
        }
        
        [Then(@"I should be able to create Time and Material")]
        public void ThenIShouldBeAbleToCreateTimeAndMaterial()
        {
            TimeandMaterialPage inssatnceNameTandM = new TimeandMaterialPage(GlobalDriver.driver);
            inssatnceNameTandM.Clickcreate();
            //inssatnceNameTandM.Savebutton1();
            ExcelLibHelpers.PopulateInCollection(@"E:\TestData\TestDataForHorseDev.xlsx", "CreateTimeAndMaterials");
            inssatnceNameTandM.CreateTimeAndMaterial();
            //GlobalDriver.driver.Dispose();
            //Closing driver instance
            GlobalDriver.driver.Close();
        }


        [Then(@"I should be able to edit Time and Material")]
        public void ThenIShouldBeAbleToEditTimeAndMaterial()
        {
            // Time & Material Page - Click on Edit Button and Edit Time and Material Value.
            TimeandMaterialPage instanceNameTandM = new TimeandMaterialPage(GlobalDriver.driver);
            ExcelLibHelpers.PopulateInCollection(@"E:\TestData\TestDataForHorseDev.xlsx", "EditTimeAndMaterials");
            instanceNameTandM.EditTimenMaterail();

            //Closing driver instance
            GlobalDriver.driver.Close();
        }

        [Then(@"I should be able to Delete Time and Material")]
        public void ThenIShouldBeAbleToDeleteTimeAndMaterial()
        {
            

            // Time & Material Page - Click on Delete and Confirm Delete Time and Material value.
            TimeandMaterialPage instanceNameTandM = new TimeandMaterialPage(GlobalDriver.driver);
            ExcelLibHelpers.PopulateInCollection(@"E:\TestData\TestDataForHorseDev.xlsx", "DeleteTimeAndMaterials");
            instanceNameTandM.deleteTimenMaterial();

            //Closing driver instance
            GlobalDriver.driver.Close();
        }
    }
}
