namespace RibbonizerSample.Emails
{
    using System;

    using Ribbonizer;
    using Ribbonizer.Ribbon.Tools.Button;

    public class DeleteEmailRibbonButtonDefinition : IRibbonButtonToolDefinition
    {
        public Type ParentType
        {
            get { return typeof(EmailRibbonGroupDefinition); }
        }

        public int SortIndex
        {
            get { return 1; }
        }

        public string Caption
        {
            get { return "Delete E-Mail"; }
        }

        public string ToolTip
        {
            get { return "Delete E-Mail"; }
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
            get { return typeof(DeleteEmailCommand); }
        }
    }
}