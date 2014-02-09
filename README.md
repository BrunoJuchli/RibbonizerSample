RibbonizerSample
================

This is a sample WPF MVVM application with a loosely-coupled ribbon.

### Note: Property Changed Notifications

As you will see, most view models do not implement [INotifyPropertyChanged](http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.aspx). The excellent [NotifyPropertyChanged.Fody](https://raw.github.com/Fody/PropertyChanged) is automatically weaving this into the assembly.
