using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Labaa6
{
    [TestFixture]

    class TEST
    {
        IWebDriver webDriver = new ChromeDriver();
        [TestCase]
        public void mainTitle()
        {
            webDriver.Url = "https://sibsutis.ru/";
            Assert.AreEqual("Сибирский государственный университет телекоммуникаций и информатики", webDriver.Title);
        }

        [TestCase]
        public void Displd()
        {
            webDriver.Url = "https://sibsutis.ru/";
            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/div[6]/div/div[1]/a/img"));
            bool status = element.Displayed;
        }

        [TestCase]
        public void Enetr()
        {
            webDriver.Url = "https://sibsutis.ru/";
            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"qqq\"]"));

            search.SendKeys("Щеглов");
            //search.SendKeys(Keys.Return);

            IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/div[2]/div[2]/div[2]/div[3]/form/input[2]"));
            button.Click();

            Assert.AreEqual("https://sibsutis.ru/search/?q=%D0%A9%D0%B5%D0%B3%D0%BB%D0%BE%D0%B2", webDriver.Url);

            IWebElement button1 = webDriver.FindElement(By.XPath("//*[@id=\"system_person_14546\"]"));
            button1.Click();
            Assert.AreEqual("Щеглов Максим Евгеньевич", webDriver.Title);
            webDriver.Close();
        }
    }
}
