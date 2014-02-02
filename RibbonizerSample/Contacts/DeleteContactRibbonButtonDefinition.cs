namespace RibbonizerSample.Contacts
{
    using System;

    using Ribbonizer;
    using Ribbonizer.Ribbon.Tools.Button;

    public class DeleteContactRibbonButtonDefinition : IRibbonButtonToolDefinition
    {
        public Type ParentType
        {
            get { return typeof(ContactsRibbonGroupDefinition); }
        }

        public int SortIndex
        {
            get { return 1; }
        }

        public string Caption
        {
            get { return "Delete Contact"; }
        }

        public string ToolTip
        {
            get { return "Delete Contact"; }
        }

        public Uri LargeImage
        {
            get { return ResourceLoader.BuildUri<CreateContactRibbonButtonDefinition>("CreateContact.png"); }
        }

        public Type WireOnActivationOfViewModelType
        {
            get { return typeof(CreateContactRibbonButtonDefinition); }
        }

        public Type CommandType
        {
            get { return null; }
        }
    }
}