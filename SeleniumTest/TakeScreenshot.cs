
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
namespace SeleniumTest
{
    public class TakeScreenshot
    {
     IWebDriver driver;

    [SetUp]
    public void BeforeSuite() {
        driver = new ChromeDriver();
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
/*
    [Test]
    public void TakePageScreenShot() {
        Screenshot screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
        screenshot.SaveAsFile(System.AppDomain.CurrentDomain.BaseDirectory, System.Drawing.Imaging.ImageFormat.Jpeg);

    }

    [Test]
    public void TakeWebElementScreenShot()  {
        File we = driver.FindElement(By.XPath("/html/body/div[1]/div[2]")).getScreenshotAs(OutputType.FILE);
        FileUtils.copyFile(we, new File(System.getProperty("user.dir") + "\\test.png"));

           
    }

    [Test,Order(0)]
    public void ActionTest1()  {
        driver.Url="https://www.selenium.dev/selenium/web/web-form.html";
        IWebElement webElement = driver.FindElement(By.Name("my-password"));
        File scrFile = webElement.getScreenshotAs(OutputType.FILE);
        File DestFile = new File(System.getProperty("user.dir") + "/test.png");
        FileUtils.copyFile(scrFile, DestFile);
    }
*/
    [TearDown]
    public void End() {
        driver.Close();
    }
    }
}