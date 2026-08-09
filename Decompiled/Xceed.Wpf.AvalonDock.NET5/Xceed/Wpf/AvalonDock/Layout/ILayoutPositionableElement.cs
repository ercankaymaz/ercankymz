using System.ComponentModel;
using System.Windows;

namespace Xceed.Wpf.AvalonDock.Layout;

internal interface ILayoutPositionableElement : ILayoutElement, INotifyPropertyChanged, INotifyPropertyChanging, ILayoutElementForFloatingWindow
{
	GridLength DockWidth { get; set; }

	GridLength DockHeight { get; set; }

	double DockMinWidth { get; set; }

	double DockMinHeight { get; set; }

	bool AllowDuplicateContent { get; set; }

	bool IsVisible { get; }
}
