namespace RibbonizerSample.Contacts
{
    using System;

    using Ribbonizer.Ribbon.Groups;

    public class ContactsRibbonGroupDefinition : IRibbonGroupDefinition
    {
        public Type ParentType
        {
            get { return typeof(ContactsRibbonTabDefinition); }
        }

        public int SortIndex
        {
            get { return 0; }
        }

        public string Caption
        {
            get { return "Contacts"; }
        }
    }
}