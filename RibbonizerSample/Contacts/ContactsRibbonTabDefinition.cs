namespace RibbonizerSample.Contacts
{
    using System;

    using Ribbonizer.Ribbon.Tabs;

    public class ContactsRibbonTabDefinition : IRibbonTabDefinition
    {
        public string Header
        {
            get { return "Contacts"; }
        }

        public Type ShowOnActivationOfViewModelType
        {
            get { return typeof(ContactListViewModel); }
        }
    }
}