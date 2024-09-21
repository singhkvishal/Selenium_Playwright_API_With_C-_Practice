namespace SeleniumTest;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

public class ActionClass
    {
        [Test]
        [Category("Selenium")]
        public void Test1(){
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/practice/text-box.php");
            driver.Manage().Window.Maximize();
            IWebElement webElement= driver.FindElement(By.XPath("//*[@id='fullname']"));
 
            // Actions class
            Actions a = new Actions(driver);

            // moving to an input box and clicking on it
            a.MoveToElement(webElement).Click();

            // key UP and DOWN action for SHIFT
            webElement.SendKeys(Keys.Shift);
                
            webElement.SendKeys("Selenium");
            // .keyUp(Keys.Shift).build().perform();
            Console.WriteLine ("Text entered: " + webElement.GetAttribute("value"));

            driver.Quit();
            }
    }
