using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumTest;

    public class ShadowRoot
    {
         IWebDriver driver = null;

        [SetUp]
        public void LaunchBrowser() {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://selectorshub.com/xpath-practice-page/");
        }

    [Test]
    public void ShadowRootTest() {
        //driver.switchTo().frame("pact");
         IJavaScriptExecutor jse=(IJavaScriptExecutor)driver;
     
        WebElement Element = (WebElement) jse.ExecuteScript("return document.querySelector('#userName').shadowRoot.querySelector('#kils')");

        //1- Using the Selenium
        Element.SendKeys("Vishal");

        //2- using executeScript
        String js="arguments[0].setAttribute('value','Vishal Singh')";
        jse.ExecuteScript(js,jse);
      }
    }