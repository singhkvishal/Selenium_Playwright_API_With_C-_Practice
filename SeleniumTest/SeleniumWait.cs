using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest;

    public class SeleniumWait
    {
         IWebDriver driver = null;
        [Test]
        public void Fails()
        {
            try{
                driver=new ChromeDriver();
                driver.Url="https://www.selenium.dev/selenium/web/dynamic.html";
                driver.FindElement(By.Id("adder")).Click();
            }catch(NoSuchElementException e){
                Console.WriteLine(e.Message);
            }
            driver.Quit();
            /*
            Assert.ThrowsException<NoSuchElementException>(
                () => driver.FindElement(By.Id("box0"))
            );*/
        }

        [Test]
        public void Sleep()
        {
            driver=new ChromeDriver();
            driver.Url="https://www.selenium.dev/selenium/web/dynamic.html";
            driver.FindElement(By.Id("adder")).Click();

            Thread.Sleep(1000);

            IWebElement added = driver.FindElement(By.Id("box0"));
            ClassicAssert.AreEqual("redbox", added.GetDomAttribute("class"));
            driver.Quit();
        }

        [Test]
        public void Implicit()
        {
            driver=new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            
            driver.Url = "https://www.selenium.dev/selenium/web/dynamic.html";
            driver.FindElement(By.Id("adder")).Click();

            IWebElement added = driver.FindElement(By.Id("box0"));

            ClassicAssert.AreEqual("redbox", added.GetDomAttribute("class"));
            driver.Quit();
        }

        [Test]
        public void Explicit()
        {
            driver=new ChromeDriver();
            driver.Url = "https://www.selenium.dev/selenium/web/dynamic.html";
            IWebElement revealed = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(d => revealed.Displayed);

            revealed.SendKeys("Displayed");
            ClassicAssert.AreEqual("Displayed", revealed.GetDomProperty("value"));
        }

        [Test]
        public void ExplicitOptions()//Or Fluant Wait
        {
            driver=new ChromeDriver();
            driver.Url = "https://www.selenium.dev/selenium/web/dynamic.html";
            IWebElement revealed = driver.FindElement(By.Id("revealed"));
            driver.FindElement(By.Id("reveal")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2))
            {
                PollingInterval = TimeSpan.FromMilliseconds(300),
            };
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(d => {
                revealed.SendKeys("Displayed");
                return true;
            });

            ClassicAssert.AreEqual("input", revealed.TagName);
            driver.Quit();
        }
    }    
