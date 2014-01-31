﻿namespace FakeItEasy
{
    using System.Collections.Generic;
    using Core;
    using IoC;
    using Module = IoC.Module;

    internal class ImportsModule
        : Module
    {
        public override void RegisterDependencies(DictionaryContainer container)
        {
            var bootstrapper = BootstrapperLocator.FindBootstrapper();

            container.RegisterSingleton<TypeCatalogueInstanceProvider>(c =>
                new TypeCatalogueInstanceProvider(c.Resolve<ITypeCatalogue>()));
            container.RegisterSingleton<ITypeCatalogue>(c =>
                new ApplicationDirectoryAssembliesTypeCatalogue(bootstrapper.GetAssemblyFilenamesToScanForExtensions()));

            RegisterEnumerableInstantiatedFromTypeCatalogue<IArgumentValueFormatter>(container);
            RegisterEnumerableInstantiatedFromTypeCatalogue<IDummyDefinition>(container);
            RegisterEnumerableInstantiatedFromTypeCatalogue<IFakeConfigurator>(container);
        }

        private static void RegisterEnumerableInstantiatedFromTypeCatalogue<T>(DictionaryContainer container)
        {
            container.RegisterSingleton<IEnumerable<T>>(c =>
                    c.Resolve<TypeCatalogueInstanceProvider>().InstantiateAllOfType<T>());
        }
    }
}