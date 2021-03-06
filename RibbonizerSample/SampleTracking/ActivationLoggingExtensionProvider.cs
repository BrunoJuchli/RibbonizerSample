﻿namespace RibbonizerSample.SampleTracking
{
    using System;

    using Ribbonizer.ViewModel.Lifecycle;

    public class ActivationLoggingExtensionProvider : ILifecycleExtensionProvider
    {
        public Type Retrieve(object viewModel)
        {
            return typeof(ActivationLoggingExtension);
        }
    }
}