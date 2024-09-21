using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest;

    public class HandleDroupDowns
    {
    [Test,Order(1)]
    public void Test1() {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://rahulshettyacademy.com/dropdownsPractise/");

        var select = new SelectElement(driver.FindElement(By.Id("ctl00_mainContent_DropDownListCurrency")));

        select.SelectByValue("INR");
        //select.DeselectByIndex(1);
    }

    [Test,Order(2)]
    public void Test2()  {
        WebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://rahulshettyacademy.com/dropdownsPractise/");
        driver.FindElement(By.Id("divpaxinfo")).Click();
        
        Thread.Sleep(TimeSpan.FromSeconds(5));
        Console.WriteLine(driver.FindElement(By.Id("divpaxinfo")).Text);
       

        for (int i = 1; i < 5; i++) {
            driver.FindElement(By.Id("hrefIncAdt")).Click();
        }

        driver.FindElement(By.Id("btnclosepaxoption")).Click();
        ClassicAssert.AreEqual(driver.FindElement(By.Id("divpaxinfo")).Text.ToString(), "5 Adult");
        Console.WriteLine(driver.FindElement(By.Id("divpaxinfo")).Text);
    }

    [Test]
    public void Test3()  {
        WebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
         driver.Navigate().GoToUrl("https://www.makemytrip.com/");
        driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        //driver.findElement(By.xpath("//*[@data-cy='closeModal']")).click();
        IWebElement source = driver.FindElement(By.XPath("//*[@placeholder='From']"));
        source.Click();
        //source.clear();
        source.SendKeys("MUM");
        Thread.Sleep(2000);
        source.SendKeys(Keys.Enter);

        IWebElement destination = driver.FindElement(By.XPath("//input[@id='fromCity']"));
        destination.Click();
        destination.SendKeys("DEL");
        Thread.Sleep(2000);
        destination.SendKeys(Keys.ArrowDown);
        destination.SendKeys(Keys.Enter);
    }
}
