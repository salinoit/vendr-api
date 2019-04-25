﻿
using System;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Options.Exntensions
{
    // REVIEW: consider deleting/obsoleting, not used by Configure anymore (in favor of name), left for breaking change)

    /// <summary>
    /// Configures an option instance by using ConfigurationBinder.Bind against an IConfiguration.
    /// </summary>
    /// <typeparam name="TOptions">The type of options to bind.</typeparam>
    public class ConfigureFromConfigurationOptions<TOptions> : ConfigureOptions<TOptions>
        where TOptions : class
    {
        /// <summary>
        /// Constructor that takes the IConfiguration instance to bind against.
        /// </summary>
        /// <param name="config">The IConfiguration instance.</param>
        public ConfigureFromConfigurationOptions(IConfiguration config)
            : base(options => ConfigurationBinder.Bind(config, options))
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
        }
    }
}