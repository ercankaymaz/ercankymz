namespace Xceed.Wpf.AvalonDock.Layout;

internal interface ILayoutInitialContainer
{
	ILayoutContainer InitialContainer { get; set; }

	string InitialContainerId { get; set; }
}
