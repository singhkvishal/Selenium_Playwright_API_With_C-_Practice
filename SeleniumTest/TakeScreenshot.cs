
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using System.IO;

namespace SeleniumTest
{
    public class TakeScreenshot
    {
     IWebDriver driver;

    [SetUp]
    public void BeforeSuite() {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://stackoverflow.com/");
    }

    [Test]
    public void TakeScreenShotWithPNGFormat(){
        string path = Directory.GetCurrentDirectory().Split("SeleniumTest")[0];
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Screenshot TakeScreenShot= ((ITakesScreenshot)driver).GetScreenshot();
        TakeScreenShot.SaveAsFile(path +"ScreenShotPng."+ ImageFormat.Png);
    }
    
    [Test]
    public void TakeScreenShotWithJpegFormat(){
        string path = Directory.GetCurrentDirectory().Split("SeleniumTest")[0];
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Screenshot TakeScreenShot= ((ITakesScreenshot)driver).GetScreenshot();
        TakeScreenShot.SaveAsFile(path +"ScreenShotJpeg."+ ImageFormat.Jpeg);
    }

    [Test]
    public void TakeElementScreenShot(){
        string path = Directory.GetCurrentDirectory().Split("SeleniumTest")[0];
        Thread.Sleep(TimeSpan.FromSeconds(5));
        IWebElement screen=driver.FindElement(By.XPath("//div[@class='overflow-hidden mln8 mrn8']"));
        Screenshot TakeScreenShot= ((ITakesScreenshot)screen).GetScreenshot();
        TakeScreenShot.SaveAsFile(path +"ElementScreen."+ ImageFormat.Jpeg);
    }



/*
    @[BeforeTest]
    public void LaunchURL() {
        driver.get("http://www.google.com");
    }

    @BeforeClass
    public void TestClass() {
        System.out.println("TestClass");
    }

    @BeforeMethod
    public void TestMethod() {
        System.out.println("TestMethod");
    }

    @BeforeGroups
    public void TestGroup() {
        System.out.println("TestGroup");
    }
*/

    [TearDown]
    public void End() {
        driver.Close();
    }
    }
}