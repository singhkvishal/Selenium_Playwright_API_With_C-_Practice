using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;

public class LaunchBrowser
{

[Test]
[Category("Selenium")]
public void Test1(){
    IWebDriver driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.selenium.dev/");
    driver.Manage().Window.Maximize();

    Assert.That(driver.Title,Is.EqualTo("Selenium"));
    driver.Quit();
    }
}
