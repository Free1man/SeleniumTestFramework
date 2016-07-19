﻿using System;

namespace SeleniumFramework.SeleniumInfrastructure.Config
{
    internal interface ISettings
    {
        bool UseLogging { get; }
        bool UseRemoteBrowser { get; }
        string Browser { get; }
        string Url { get; }
        string TestFolder { get;}
        TimeSpan ImplicitWaitTime { get; }
    }
}