namespace RibbonizerSample.Emails
{
    using System;

    using Ribbonizer.Ribbon.Groups;

    public class EmailRibbonGroupDefinition : IRibbonGroupDefinition
    {
        public Type ParentType
        {
            get { return typeof(EmailsRibbonTabDefinition); }
        }

        public int SortIndex
        {
            get { return 0; }
        }

        public string Caption
        {
            get { return "E-Mail"; }
        }
    }
}