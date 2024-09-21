namespace NUnitExamples;

public class Class1
{

}
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using NUnit.Framework;
    using System.Threading;
    using System.Collections.Generic;
     
    namespace ParallelLTSelenium
    {
        [TestFixture("Chrome", "72.0", "Windows 10")]
        [TestFixture("Firefox", "66.0", "Windows 10")]
        [Parallelizable(ParallelScope.All)]
        public class ParallelLTTests
        {
            ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
            private String browser;
            private String version;
            private String os;
     
            public ParallelLTTests(String browser, String version, String os)
            {
                this.browser = browser;
                this.version = version;
                this.os = os;
            }
     
            [SetUp]
            public void Init()
            {
                String username = "himanshu.sheth";
                String accesskey = "fbI6kxucn5iRzwt5GWYiNvaPb4Olu9R8lwBsXWTSaIOebXn4x9";
                String gridURL = "@hub.lambdatest.com/wd/hub";
     
                DesiredCapabilities capabilities = new DesiredCapabilities();
     
                capabilities.SetCapability("user", username);
                capabilities.SetCapability("accessKey", accesskey);
                capabilities.SetCapability("browserName", browser);
                capabilities.SetCapability("version", version);
                capabilities.SetCapability("platform", os);
     
                driver.Value = new RemoteWebDriver(new Uri("https://" + username + ":" + accesskey + gridURL), capabilities, TimeSpan.FromSeconds(600));
     
                System.Threading.Thread.Sleep(2000);
            }
     
            [Test]
            public void Google_Test()
            {
                {
                    driver.Value.Url = "https://www.google.com";
     
                    IWebElement element = driver.Value.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input"));
     
                    element.SendKeys("LambdaTest");
     
                    /* Submit the Search */
                    element.Submit();
     
                    /* Perform wait to check the output */
                    System.Threading.Thread.Sleep(2000);
                }
            }
     
            [TearDown]
            public void Cleanup()
            {
                bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
                try
                {
                    // Logs the result to Lambdatest
                    ((IJavaScriptExecutor)driver.Value).ExecuteScript("lambda-status=" + (passed ? "passed" : "failed"));
                }
                finally
                {
                    // Terminates the remote webdriver session
                    driver.Value.Quit();
                }
            }
        }
    }