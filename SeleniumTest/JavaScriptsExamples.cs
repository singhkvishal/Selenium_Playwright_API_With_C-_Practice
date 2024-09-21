
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;
 
public class JavaScriptsExamples
{
 IWebDriver ? driver1;

    [SetUp]
    public void Setup() {
        driver1 = new ChromeDriver();
        driver1.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
        Thread.Sleep(3000);
    }

    [Test]
    public void ScrollPageAndTable()  {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver1;
        js.ExecuteScript("window.scrollBy(0,500)");
        Thread.Sleep(3000);
        js.ExecuteScript("document.querySelector('.tableFixHead').scrollTop=5000");
        int sum = 0;
        IList<IWebElement> values = driver1.FindElements(By.CssSelector(".tableFixHead td:nth-child(4)"));
    
       
        for (int i = 0; i < values.Count; i++) {
            sum = sum + Int32.Parse(values[i].Text);
        }

        Console.WriteLine(sum);
       String Exp= driver1.FindElement(By.CssSelector(".totalAmount")).Text;
        String ActualValue = driver1.FindElement(By.CssSelector(".totalAmount")).Text.Split(":")[1].Trim();
       ClassicAssert.AreEqual(sum, Int32.Parse(ActualValue));
    }


    [Test]
    public void SumAllAmount() {
       // AtomicInteger totalValue = new AtomicInteger();
       int totalValue=0;
        IList<IWebElement> amounts = driver1.FindElements(By.CssSelector(".tableFixHead td:nth-child(4)"));

        foreach (var item in amounts)
        {
             totalValue=totalValue+ Int32.Parse(item.Text);
        }
     
         Console.WriteLine("Total Amount" + totalValue);

        String expectedValue = driver1.FindElement(By.CssSelector(".totalAmount")).Text;
        ClassicAssert.AreEqual(Int32.Parse(expectedValue.Split(":")[1].Trim()), totalValue);
    }
}
