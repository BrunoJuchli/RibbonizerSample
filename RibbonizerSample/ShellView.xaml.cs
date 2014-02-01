using System.Windows;

namespace RibbonizerSample
{
    using System.Windows.Controls.Ribbon;

    using Caliburn.Micro;

    using Ribbonizer.Ribbon;
    using Ribbonizer.Wrappers.Microsoft;

    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            IRibbonView ribbonView = IoC.Get<IMicrosoftRibbonViewWrapperFactory>().CreateRibbonWrapper(this.Ribbon);

            IoC.Get<IRibbonProviderInitialization>().Initialize(ribbonView);
        }
    }
}
