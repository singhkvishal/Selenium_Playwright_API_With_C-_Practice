using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;

    public class Locators
    {
     WebDriver driver;

    [SetUp]
    public void SetUp() {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
    }

    [Test]
    public void cssSelector() {
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

        // 1- Class name-> tagename.classname->button.signIn
        driver.FindElement(By.CssSelector("input.form-control")).SendKeys("Test");

        //2-id->tagname#id-> input#inputUsername
        driver.FindElement(By.CssSelector("input#my-check-2")).Click();

        //3- input[paceholder='usrename']
        driver.FindElement(By.CssSelector("input[name='my-password']")).SendKeys("Test");

        //4- nth
        driver.Navigate().GoToUrl("https://rahulshettyacademy.com/locatorspractice/");
        driver.FindElement(By.CssSelector("input[type='text']:nth-child(3)")).SendKeys("Test");
    }

    [Test]
    public void Xpath()  {
        //Xpath -index
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
        driver.FindElement(By.XPath("(//input[@type='text'])[4]")).SendKeys("xpath");

        //full Tag name
        driver.Navigate().GoToUrl("https://rahulshettyacademy.com/locatorspractice/");
        driver.FindElement(By.XPath("//form/input[3]")).SendKeys("234234324");

        //implicit wait - 2 seconds time out
        driver.Navigate().GoToUrl("https://rahulshettyacademy.com/locatorspractice/");
        driver.FindElement(By.Id("inputUsername")).SendKeys("Vishal");
        driver.FindElement(By.Name("inputPassword")).SendKeys("hello123");
        driver.FindElement(By.ClassName("signInBtn")).Click();
        Console.WriteLine(driver.FindElement(By.CssSelector("p.error")).Text);
        driver.FindElement(By.LinkText("Forgot your password?")).Click();
        driver.FindElement(By.XPath("//input[@placeholder='Name']")).SendKeys("John");
        driver.FindElement(By.CssSelector("input[placeholder='Email']")).SendKeys("john@rsa.com");

        // search by Index
        driver.FindElement(By.XPath("//input[@type='text'][2]")).Clear();

        //Search by nth-child
        driver.FindElement(By.CssSelector("input[type='text']:nth-child(3)")).SendKeys("john@gmail.com");
        driver.FindElement(By.XPath("//form/input[3]")).SendKeys("9864353253");

        driver.FindElement(By.CssSelector(".reset-pwd-btn")).Click();
        Console.WriteLine(driver.FindElement(By.CssSelector("form p")).Text);
        driver.FindElement(By.XPath("//div[@class='forgot-pwd-btn-conainer']/button[1]")).Click();
        driver.FindElement(By.CssSelector("#inputUsername")).SendKeys("Vishal");
        driver.FindElement(By.CssSelector("input[type*='pass']")).SendKeys("VishalSingh");
        Thread.Sleep(TimeSpan.FromSeconds(5));
        driver.FindElement(By.Id("chkboxOne")).Click();
        driver.FindElement(By.XPath("//button[contains(@class,'submit')]")).Click();
    }

    [TearDown]
    public void TearDown() {
        driver.Close();
    }
    }
