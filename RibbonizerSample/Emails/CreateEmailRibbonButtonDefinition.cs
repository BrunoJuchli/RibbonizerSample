namespace RibbonizerSample.Emails
{
    using System;

    using Ribbonizer;
    using Ribbonizer.Ribbon.Tools.Button;

    public class CreateEmailRibbonButtonDefinition : IRibbonButtonToolDefinition
    {
        public Type ParentType
        {
            get { return typeof(EmailRibbonGroupDefinition); }
        }

        public int SortIndex
        {
            get { return 0; }
        }

        public string Caption
        {
            get { return "New E-Mail"; }
        }

        public string ToolTip
        {
            get { return "Create new E-Mail"; }
        }

        public Uri LargeImage
        {
            get { return ResourceLoader.BuildUri<CreateEmailRibbonButtonDefinition>("CreateEmail.ico"); }
        }

        public Type WireOnActivationOfViewModelType
        {
            get { return typeof(EmailListViewModel); }
        }

        public Type CommandType
        {
            get { return typeof(CreateEmailCommand); }
        }
    }
}