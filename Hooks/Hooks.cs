using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LinkGroup.DemoTests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@homePage")]
        public void BeforeScenarioWithHomePage()
        {
            Console.WriteLine("Running inside Tagged HomePage");
        }
        [BeforeScenario("@linkFundSolutions")]
        public void BeforeScenarioWithLinkFundSolutions()
        {
            Console.WriteLine("Running inside LinkFundSolutions");
        }
        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver= new ChromeDriver();
            driver.Manage().Window.Maximize();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            if(driver != null) 
            {
                driver.Quit();
            }
        }
    }
}