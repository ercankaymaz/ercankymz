using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutPanelControl : LayoutGridControl<ILayoutPanelElement>, ILayoutControl
{
	private LayoutPanel _model;

	internal LayoutPanelControl(LayoutPanel model)
		: base((LayoutPositionableGroup<ILayoutPanelElement>)model, model.Orientation)
	{
		_model = model;
	}

	protected override void OnFixChildrenDockLengths()
	{
	}
}
