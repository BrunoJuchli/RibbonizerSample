namespace Ribbonizer.Ribbon.Groups
{
    public interface IRibbonGroupView : IRibbonViewWithChildren<object>
    {
        string Caption { get; set; }
    }
}