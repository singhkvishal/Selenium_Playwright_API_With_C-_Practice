using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumTest;

    public class JavaStream_CheckWebFilterIsWorking
    {
        //https://www.ankursheel.com/blog/transitioning-c-linq-java-streams
         IWebDriver ? driver;
        [Test]
        public void Test(){
         driver = new ChromeDriver();
         driver.Navigate().GoToUrl("https://rahulshettyacademy.com/greenkart/#/offers");
         driver.FindElement(By.Id("search-field")).SendKeys("Rice");
        IList<IWebElement> veggies=driver.FindElements(By.XPath("//tr/td[1]"));
        
        IList<IWebElement> filteredList=veggies.Where(x => x.Text.Contains("Rice")).ToList();
        ClassicAssert.AreEqual(filteredList.Count,filteredList.Count);
    }
}