﻿using OpenQA.Selenium;
using SeleniumFramework.SeleniumInfrastructure.Config;

namespace SeleniumFramework.SeleniumInfrastructure.Browsers
{
    internal class BrowserSettingsService
    {
        public void SetBrowserSettings(IWebDriver driver, ISettings settings)
        {
            driver.Manage().Timeouts().ImplicitlyWait(settings.ImplicitWaitTime);

            driver.Url = settings.Url;
        }
    }
}