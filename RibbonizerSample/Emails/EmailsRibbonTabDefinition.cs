namespace RibbonizerSample.Emails
{
    using System;

    using Ribbonizer.Ribbon.Tabs;

    public class EmailsRibbonTabDefinition : IRibbonTabDefinition
    {
        public string Header
        {
            get { return "E-Mails"; }
        }

        public Type ShowOnActivationOfViewModelType
        {
            get { return typeof(EmailsViewModel); }
        }
    }
}