using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest;

    public class WindowsAuthentication
    {
         [Test]
    public void URLAuthentication(){
        IWebDriver driver=new ChromeDriver();
        driver.Url="https://admin:admin@the-internet.herokuapp.com";
        driver.FindElement(By.LinkText("Basic Auth")).Click();
    }

    [Test]
    public void Test2()  {
         IWebDriver driver=new ChromeDriver();
        driver.Url="https://the-internet.herokuapp.com";
        driver.FindElement(By.LinkText("Basic Auth")).Click();

        IWebElement element;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement navList = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("navlist"));
            });

       // Runtime.getRuntime().exec("D:\\Study\\Selenium\\AutoIt_UploadDoc.exe");
    }
    }
