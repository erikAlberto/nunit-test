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
            Assert.AreEqual(driver.FindElement(By.CssSelector(".btn-secondary")).GetAttribute("href"), "https://bit.ly/CrediseguroWhats");
        }

        [Test]
        public void Test2()
        {
            driver.FindElement(By.CssSelector("a.menu-trigger")).Click();
            driver.FindElement(By.CssSelector("#menu > div > a:nth-child(4)")).Click();
            Assert.AreEqual(driver.FindElement(By.CssSelector("#content a")).GetDomAttribute("href"), "https://check.com.bo/");

        }

        [Test]
        public void Test3()
        {
            driver.FindElement(By.CssSelector("#navbarNav > ul > li:nth-child(3) > a")).Click();
            driver.FindElement(By.Id("Ext")).Click();
            IWebElement dropdown = driver.FindElement(By.Id("Ext"));
            IReadOnlyCollection<IWebElement> dropdownOptions = dropdown.FindElements(By.TagName("option"));

            Assert.AreEqual(dropdownOptions.Count, 12);

        }

        [Test]
        public void TestSelectFromDropdown()
        {
            driver.FindElement(By.CssSelector("#navbarNav > ul > li:nth-child(3) > a")).Click();
            driver.FindElement(By.Id("Ext")).Click();
            IWebElement dropdown = driver.FindElement(By.Id("Ext"));
            IReadOnlyCollection<IWebElement> dropdownOptions = dropdown.FindElements(By.TagName("option"));
            foreach (IWebElement option in dropdownOptions)
            {
                if (option.Text.Equals("PO"))
                {
                    option.Click();
                }
            }
            string selectedOption = "";
            foreach (IWebElement item in dropdownOptions)
            {
                if (item.Selected)
                {
                    selectedOption = item.Text;
                }
            }
            Assert.That(selectedOption, Is.EqualTo("PO"));

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}