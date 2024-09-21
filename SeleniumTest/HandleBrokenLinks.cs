using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;


    public class HandleBrokenLinks
    {
        private IWebDriver ? driver;
            [SetUp]
            public void setUp() {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            }

            [Test,Order(0)]
            public void CheckTheLinkIsBroken() {
                String linkSoapUI = driver.FindElement(By.CssSelector("a[href*='brokenlink']")).GetAttribute("href");
                Console.WriteLine(linkSoapUI);
                ;
                if( CheckLinkIsNotBroken(linkSoapUI).GetAwaiter().GetResult()){
                    Console.WriteLine(linkSoapUI +"Linke is not Broken");
                }else{
                    Console.WriteLine(linkSoapUI + "Link is Broken");
                }
            }

            [Test,Order(1)]
            public void CheckAllLinksAreNotBroken(){
                IList<IWebElement> WebLinks = driver.FindElement(By.Id("gf-BIG")).FindElements(By.TagName("a"));
                foreach(IWebElement link in WebLinks)
                {
                    String linkUrl = link.GetAttribute("href");
                    Console.WriteLine(linkUrl);
                     if( CheckLinkIsNotBroken(linkUrl).GetAwaiter().GetResult()){
                            Console.WriteLine(linkUrl+ " Link is Not Broken");
                        }else{
                            Console.WriteLine(linkUrl+ " Link is broken");
                         }
                    }   
            }

            private static async Task<bool> CheckLinkIsNotBroken(String url)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        //Do only Head request to avoid download full file
                        var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

                        if (response.IsSuccessStatusCode) {
                            //Url is available is we have a SuccessStatusCode
                            return true;
                        }
                        return false;
                    }                
                } catch {
                    return false;
                }
            }

            [TearDown]
            public void TearDown(){
                driver.Close();
            }
    }