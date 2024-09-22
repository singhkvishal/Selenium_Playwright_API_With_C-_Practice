using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    public class OpenNewTab
    {

        [Test]
        public void Test()
        {
            //1. Give me the count of links on the page.
            //2. Count of footer section-

            //System.setProperty("webdriver.chrome.driver", "C:\\work\\chromedriver.exe");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://qaclickacademy.com/practice.php");
            Console.WriteLine(driver.FindElements(By.TagName("a")).Count);
            IWebElement footerdriver = driver.FindElement(By.Id("gf-BIG"));// Limiting webdriver scope
            Console.WriteLine(footerdriver.FindElements(By.TagName("a")).Count);

            //3-
            IWebElement coloumndriver = footerdriver.FindElement(By.XPath("//table/tbody/tr/td[1]/ul"));
            Console.WriteLine(coloumndriver.FindElements(By.TagName("a")).Count);

            //4- click on each link in the coloumn and check if the pages are opening-
            for (int i = 1; i < coloumndriver.FindElements(By.TagName("a")).Count; i++)
            {
                coloumndriver.FindElements(By.TagName("a"))[i].SendKeys(Keys.Control + Keys.Enter);
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }// opens all the tabs

            ReadOnlyCollection<String> handles = driver.WindowHandles;//4
            foreach (string handle in handles)
            {
                Boolean a = driver.SwitchTo().Window(handle).Url.Contains("Main");
                if (a == true)
                {
                    driver.SwitchTo().Window(handle);
                    break;
                }
            }
            driver.Quit();
        }
    }
}