namespace Ribbonizer.Ribbon
{
    public interface IRibbonViewWithChildren<in TChildView>
    {
        void AddItem(TChildView item);
    }
}