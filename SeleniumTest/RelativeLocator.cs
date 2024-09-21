
using System.IO.Pipes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    public class RelativeLocator
    {
        public void main(String []arg){
         IWebDriver driver = new ChromeDriver();
        
        driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");

        IWebElement ele1=driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Above(By.Id("my-password")));
        IWebElement ele2=driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Below(By.Id("my-password")));
        IWebElement ele3=driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).LeftOf(By.Id("my-password")));
        IWebElement ele4=driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).RightOf(By.Id("my-password")));
        IWebElement ele5=driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Near(By.Id("my-password")));

    }
}
}