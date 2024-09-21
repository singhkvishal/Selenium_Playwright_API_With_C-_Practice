
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    public class SwitchToNewWindow
    {
        WebDriver driver = null;

    [SetUp]
    public void LaunchBrowser() {
        driver = new ChromeDriver();
        driver.Url="https://www.softwaretestinghelp.com/";
    }

    [Test,Order(0)]
    public void ScrollPage() {
        IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        js.ExecuteScript("window.scrollBy(0,2000)");

    }

    [Test,Order(1)]
    public void demoSwitchToFrame1() {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
       // wait.Until(ExpectedConditions.frameToBeAvailableAndSwitchToIt("intercom-launcher-frame"));

        driver.FindElement(By.ClassName("e2ujk8f2")).Click();
    }

    [Test,Order(2)]
    public void demoSwitchToFrame2() {

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
       // wait.Until(ExpectedConditions.presenceOfElementLocated(By.Name("intercom-launcher-frame")));

        driver.SwitchTo().Frame("intercom-launcher-frame");
        driver.FindElement(By.ClassName("e2ujk8f2")).Click();
    }

    [Test,Order(3)]
    public void TestSwitchToNewBrowser() {
        driver.FindElement(By.Id("OK")).Click();

        driver.Manage().Window.Maximize();

        String originalWindow = driver.CurrentWindowHandle;
        ReadOnlyCollection<String> originalWindow1 = driver.WindowHandles;

        foreach (String windowHandle in driver.WindowHandles) {
            if (!originalWindow.Equals(windowHandle)) {
                driver.SwitchTo().Window(windowHandle);
                break;
            }
        }
    }

    [Test,Order(4)]
    public void SwitchToBackToDefault() {
        WebDriver driver = new ChromeDriver();
        driver.Url="https://www.softwaretestinghelp.com/";

        //Finding all iframe tags on a web page
        IList<IWebElement> elements = driver.FindElements(By.TagName("iframe"));
        int numberOfTags = elements.Count;
        Console.WriteLine("No. of Iframes on this Web Page are: " + numberOfTags);

        // Switch to the frame using the frame id
        Console.WriteLine("Switching to the frame");
        driver.SwitchTo().Frame("aswift_0");

        // Print the frame source code
        Console.WriteLine("Frame Source" + driver.PageSource);

        // Switch back to main web page
        driver.SwitchTo().DefaultContent();

        // driver.quit();
    }

    [Test]
    public void SwitchTo_newWindow() {
    /*
        There is clearly a difference :
        Scenario : When there are multiple frames and some of them are nested.
        iframeMain
        iframeParent
        iframechild
        Assume you are in ifrmaechild :
        When you do driver.switchTo().parentFrame(); : you will go to iframeParent .
        But when you do driver.switchTo().defaultContent(); : you will go to main HTML of page.
        Note that in this case you will not go to iframeMain .
     */
        driver.SwitchTo().NewWindow(WindowType.Window);
        driver.Navigate().GoToUrl("https://www.browserstack.com/");
        Console.WriteLine("Before defaultContent" + driver.Title);
        String Title = driver.SwitchTo().DefaultContent().Title;
        Console.WriteLine("After defaultContent" + Title);

        driver.SwitchTo().ParentFrame();
    }

    [Test]
    public void openNewWindowForTestProjectBlog() {
        ReadOnlyCollection<String> test = driver.WindowHandles;

        IWebDriver newWindow = driver.SwitchTo().NewWindow(WindowType.Window);
        newWindow.Url="https://blog.testproject.io/";
        Console.WriteLine(driver.Title);
    }

    [Test]
    public void SwitchToAlert() {
        driver.SwitchTo().Alert().Accept();
        driver.SwitchTo().Alert().Dismiss();
        String TextValue = driver.SwitchTo().Alert().Text;
    }

    [Test]
    public void SwitchToNewWindow12() {
        driver.SwitchTo().NewWindow(WindowType.Window);
        driver.SwitchTo().NewWindow(WindowType.Tab);
    }

    [Test]
    public void GetWindowHandles_Test() {
        String curHandle = driver.CurrentWindowHandle;
        ReadOnlyCollection<String> AllHandles = driver.WindowHandles;

        foreach (String c in AllHandles) {
            if (!curHandle.Equals(c)) {
                driver.SwitchTo().Window(c);
                break;
            }
        }
    }

    [Test]
    public void SwitchToFrames() {
        driver.SwitchTo().Frame(1);
        driver.SwitchTo().ParentFrame();
        driver.SwitchTo().DefaultContent();
    }
  }
}