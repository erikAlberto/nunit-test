using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.crediseguro.com.bo");

        }

        [Test]
        public void Test1()
        {
            Assert.Equals(driver.FindElement(By.CssSelector(".btn-secondary")).GetAttribute("href"), "https://bit.ly/CrediseguroWhats");

        }

        [Test]
        public void Test2()
        {
            driver.FindElement(By.CssSelector("a.menu-trigger")).Click();
            driver.FindElement(By.LinkText("/seguros-individuales")).Click();

            Assert.Equals(driver.FindElement(By.CssSelector("#content a")).GetDomAttribute("href"), "https://check.com.bo/");

        }

        [Test]
        public void Test3()
        {
            driver.FindElement(By.LinkText("Verificador/Inicio")).Click();
            driver.FindElement(By.Id("Ext")).Click();
            driver.FindElements(By.Id("Ext"));
        }
    }
}