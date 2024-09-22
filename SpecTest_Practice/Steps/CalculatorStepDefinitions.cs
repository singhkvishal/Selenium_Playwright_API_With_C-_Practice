using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Drawing.Imaging;

namespace SpecTest_Practice.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
       
       // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

       private readonly ScenarioContext _scenarioContext;
        IWebDriver driver ;
       public CalculatorStepDefinitions(ScenarioContext scenarioContext)
       {
           _scenarioContext = scenarioContext;
       }

       [Given("Launch the Browser")]
       public void LaunchBrowser()
       {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/");
            driver.Manage().Window.Maximize();

            Assert.That(driver.Title,Is.EqualTo("Selenium"));
       }

       [Given("Click On webdriver Document")]
       public void ClickOnSeleniumDocument()
       {
            Thread.Sleep(TimeSpan.FromSeconds(5));
          driver.FindElement(By.XPath("//a[@href='/documentation/webdriver/']")).Click();
          Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        
       [When("Captue Screen Shot")]
       public void CaptureScreenShot()
       {
           string path = Directory.GetCurrentDirectory().Split("SpecTest_Practice")[0];
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Screenshot TakeScreenShot= ((ITakesScreenshot)driver).GetScreenshot();
        TakeScreenShot.SaveAsFile(path +"ScreenShotJpeg."+  ImageFormat.Jpeg);
       }

       [Then("Close the Browser")]
       public void CloseTheBrowser()
       {
           //TODO: implement assert (verification) logic
             driver.Quit();
          // _scenarioContext.Pending();
       }
    }
}
