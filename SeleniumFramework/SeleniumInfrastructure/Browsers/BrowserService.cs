﻿using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;
using SeleniumFramework.SeleniumInfrastructure.Logging;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal class BrowserService : IBrowserService
    {
        private readonly Settings _settings;

        public BrowserService(Settings settings)
        {
            _settings = settings;
        }

        public Browser GetBrowser(Browser.BrowserType browserType)
        {
            IWebDriver driver;

            driver = SelectDriver(browserType);

            if (_settings.UseLogging)
            {
                ILoggingService loggingService = new LoggingService();             
                driver = loggingService.EnableLoggingForDriver(driver);
            }
      
            var browserSettingsService = new BrowserSettingsService();
            browserSettingsService.SetBrowserSettings(driver, _settings);

            return new Browser(driver);
        }

        
        private IWebDriver SelectDriver(Browser.BrowserType browserType)
        {
            IWebDriver driver;
            IDriverService driverService;
            if (_settings.UseRemoteBrowser)
            {
                driverService = new RemoteDriverService();
            }
            else
            {
                driverService = new DriverService();
            }
           
            switch (browserType)
            {
                default:
                    driver = driverService.GetDriver(browserType.ToString());
                    break;
                case Browser.BrowserType.ReadFromSettings:
                    driver = driverService.GetDriver(_settings.Browser);
                    break;
            }
            return driver;
        }
    }
}