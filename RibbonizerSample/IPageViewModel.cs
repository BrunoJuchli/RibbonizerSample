namespace RibbonizerSample
{
    using System.Windows.Media;

    public interface IPageViewModel
    {
        string Header { get; }

        ImageSource Image { get; }
    }
}