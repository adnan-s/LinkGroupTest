using FluentAssertions;
using LinkGroup.DemoTests.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V111.Network;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace LinkGroup.DemoTests.StepDefinitions
{
    [Binding]
    internal class SmokeTestStepDefinitions
    {
        private IWebDriver driver;
        public SmokeTestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"I open the home page")]
        public void IOpenTheHomePage()
        {
            // Hooks call
        }
        [Then(@"The page is displayed")]
        public void ThePageIsDisplayed()
        {
            //Step # 1
            string title = "Link Group";
            driver.Url = "https://www.linkgroup.com/";
            string actualTitle = driver.Title;

            // Step # 2
            // Assert
            Assert.That(actualTitle, Is.EqualTo(title));
        }
        [Given(@"I have opened the home page")]
        public void OpenedTheHomepage()
        {
            driver.Url = "https://www.linkgroup.com/";
        }
        // Step # 3
        [Given(@"I have agreed to the cookie policy")]
        public void GivenIHaveAgreedToTheCookiePolicy()
        {
            driver.FindElement(By.XPath("/html/body/div[2]/div/a[2]")).Click();
        }
        // Step #4
        [When(@"I select Contact")]
        public void ISelectContact()
        {
            driver.FindElement(By.XPath("//*[@id=\"nav-main\"]/ul[2]/li[5]/a")).Click();
        }
        // Step #5
        [Then(@"the Contact page is displayed")]
        public void TheContactPageIsDisplayed()
        {
            string header = "Contact";
            string actualHeader = driver.FindElement(By.CssSelector("#page-wrap > div > div.contentHeader > div > h1")).Text;
            Assert.That(actualHeader, Is.EqualTo(header));
        }
        // Step #6
        [Given(@"I have opened the Fund Solutions page")]
        public void OpenedTheFundSollutionsPage()
        {
            driver.Url = "https://www.linkfundsolutions.co.uk/";
        }
        // Step #7
        [When(@"I view Funds")]
        public void viewFunds()
        {
            IWebElement ddlFunds = driver.FindElement(By.XPath("//*[@id=\"navbarDropdown\"]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(ddlFunds).Perform();
        }
        // Step #8
        [Then(@"I can select the investment managers for investors")]
        public void SelectTheInvestment(Table tableVal)
        {
            var investors = tableVal.CreateSet<Investors>();
            int rows = investors.Count();
            string[] InvtManagers ={
                "Investment Managers for UK investors",
                "Investment Managers for Irish investors",
                "Investment Managers for Swiss investors"
            };
            for (int i = rows; i > 0; i--)
            {

                driver.FindElement(By.XPath("//*[@id=\"navItem-funds\"]/div/div/div[2]/div[1]/ul/li[" + i + "]/a")).Click();
                string pageHeader = driver.FindElement(By.CssSelector("#pageHero > div > div > h1")).Text;
                if (pageHeader.Contains("Swiss") && InvtManagers[i - 1].Contains("Swiss"))
                    Assert.AreEqual(pageHeader, InvtManagers[i - 1]);
                else if (pageHeader.Contains("Irish") && InvtManagers[i - 1].Contains("Irish"))
                    Assert.AreEqual(pageHeader, InvtManagers[i - 1]);
                else if (pageHeader.Contains("UK") && InvtManagers[i - 1].Contains("UK"))
                    Assert.AreEqual(pageHeader, InvtManagers[i - 1]);
                else Assert.AreEqual(pageHeader, "***************** Fail *****************");

                IWebElement ddlFunds = driver.FindElement(By.XPath("//*[@id=\"navbarDropdown\"]"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(ddlFunds).Perform();
            }
        }
    }
}
