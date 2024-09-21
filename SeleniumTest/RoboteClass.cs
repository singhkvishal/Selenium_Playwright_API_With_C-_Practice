using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Interactions;

namespace SeleniumTest
{
    public class RoboteClass
    {
    [Test]
        public static void  execution()  {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://spreadsheetpage.com/index.php/file/C35/P10/"); // sample url
            Actions action = new Actions(driver);
            action.MoveToLocation(630, 420); // move mouse point to specific location
            Thread.Sleep(1500);        // delay is to make code wait for mentioned milliseconds before executing next step
            /*action.mousePress(InputEvent.BUTTON1_DOWN_MASK); // press left click
            action.mouseRelease(InputEvent.BUTTON1_DOWN_MASK); // release left click
            action.delay(1500);
            action.keyPress(KeyEvent.VK_DOWN); // press keyboard arrow key to select Save radio button
            Thread.Sleep(2000);
            action.keyPress(KeyEvent.VK_ENTER);*/
            // press enter key of keyboard to perform above selected action
        }
        
        [Test]       
        public void Test() {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://spreadsheetpage.com/index.php/file/C35/P10/"); // sample url
            driver.FindElement(By.XPath("//*[@class='retina']")).Click();
            /*MouseHook robot = new MouseHook();  // Robot class throws AWT Exception
            Thread.Sleep(2000); // Thread.sleep throws InterruptedException
            robot.keyPress(Keys.Down);  // press arrow down key of keyboard to navigate and select Save radio button

            Thread.Sleep(2000);  // sleep has only been used to showcase each event separately
            robot.keyPress(KeyEvent.VK_TAB);
            Thread.Sleep(2000);
            robot.keyPress(KeyEvent.VK_TAB);
            Thread.Sleep(2000);
            robot.keyPress(KeyEvent.VK_TAB);
            Thread.Sleep(2000);
            robot.keyPress(KeyEvent.VK_ENTER);*/
            // press enter key of keyboard to perform above selected action
        }
    }
}