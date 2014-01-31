﻿namespace FakeItEasy
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The default bootstrapper.    
    /// </summary>
    public class DefaultBootstrapper : IBootstrapper
    {
        /// <summary>
        /// Provides a list of assemblies to scan for extension points.
        /// </summary>
        /// <returns>A list of assemblies to scan for extension points.</returns>
        public virtual IEnumerable<string> GetAssemblyFilenamesToScanForExtensions()
        {
            return Directory.GetFiles(Environment.CurrentDirectory, "*.dll");
        }
    }
}
