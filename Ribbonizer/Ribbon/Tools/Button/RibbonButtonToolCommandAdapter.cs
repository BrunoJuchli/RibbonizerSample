namespace Ribbonizer.Ribbon.Tools.Button
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Caliburn.Micro;

    using PropertyChanged;

    [ImplementPropertyChanged]
    internal class RibbonButtonToolCommandAdapter : IRibbonButtonToolCommandAdapter
    {
        private IRibbonButtonToolCommand adaptedCommand;

        public bool CanExecute { get; private set; }

        public IEnumerable<IResult> Execute()
        {
            if (this.adaptedCommand != null)
            {
                return this.adaptedCommand.Execute();
            }

            return Enumerable.Empty<IResult>();
        }

        public void BindCommand(IRibbonButtonToolCommand command, object viewModel)
        {
            this.adaptedCommand = command;
            command.ExecuteIfInstanceIsOfType<INotifyPropertyChanged>(inpc => inpc.PropertyChanged += this.HandlePropertyChanged);
            viewModel.ExecuteIfInstanceIsOfType<INotifyPropertyChanged>(inpc => inpc.PropertyChanged += this.HandlePropertyChanged);
            this.UpdateCanExecute();
        }

        public void UnbindCommand(object viewModel)
        {
            viewModel.ExecuteIfInstanceIsOfType<INotifyPropertyChanged>(inpc => inpc.PropertyChanged -= this.HandlePropertyChanged);
            this.adaptedCommand.ExecuteIfInstanceIsOfType<INotifyPropertyChanged>(inpc => inpc.PropertyChanged -= this.HandlePropertyChanged);

            this.CanExecute = false;

            this.adaptedCommand = null;
        }

        private void UpdateCanExecute()
        {
            this.CanExecute = this.adaptedCommand.CanExecute;
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.UpdateCanExecute();
        }
    }
}