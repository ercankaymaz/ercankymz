using System.ComponentModel;
using System.Windows.Controls;

namespace Xceed.Wpf.AvalonDock.Layout;

public interface ILayoutOrientableGroup : ILayoutGroup, ILayoutContainer, ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging
{
	Orientation Orientation { get; set; }
}
