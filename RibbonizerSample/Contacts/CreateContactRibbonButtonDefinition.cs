namespace RibbonizerSample.Contacts
{
    using System;

    using Ribbonizer;
    using Ribbonizer.Ribbon.Tools.Button;

    public class CreateContactRibbonButtonDefinition : IRibbonButtonToolDefinition
    {
        public Type ParentType
        {
            get { return typeof(ContactsRibbonGroupDefinition); }
        }

        public int SortIndex
        {
            get { return 0; }
        }

        public string Caption
        {
            get { return "New Contact"; }
        }

        public string ToolTip
        {
            get { return "Create new Contact"; }
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