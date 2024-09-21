using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    public class AddBrowserArguments
    {
        [Test]
        [Category("Selenium")]
        public void Test1(){
             //System.setProperty("webdriver.chrome.driver", chromedriverPath);
                ChromeOptions options = new ChromeOptions();
                // options.addArguments("headless");
                options.AddArguments("--start-maximized");
                options.AddArguments("--window-size=1920,1080");
                options.AddArguments("--enable-precise-memory-info");
                options.AddArguments("--disable-popup-blocking");
                options.AddArguments("--disable-default-apps");
                options.AddArguments("test-type=browser");
                options.AddArguments("--incognito");
                options.AddArguments("test-type");
                options.AddArguments("--ignore-certificate-errors");

                // we can set multiple arguments
                //options.addArguments("--start-maximized", "--headless", "--window-size=2560,1440","--ignore-certificate-errors","--disable-extensions","--disable-dev-shm-usage");
                //options.addArguments("--log-level=3");

                options.PageLoadStrategy=PageLoadStrategy.Normal;//PageLoadStrategy.NORMAL/NONE
                //options.setCapability("proxy","Proxy");
                //options.addExtensions(new File("Path to CRX File"));

                WebDriver driver = new ChromeDriver(options);
                //driver.get("https://www.selenium.dev/selenium/web/web-form.html");


                driver.Navigate().GoToUrl("https://example.com/");
            }
    }
}