using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorablePaneGroupControl : LayoutGridControl<ILayoutAnchorablePane>, ILayoutControl
{
	private LayoutAnchorablePaneGroup _model;

	internal LayoutAnchorablePaneGroupControl(LayoutAnchorablePaneGroup model)
		: base((LayoutPositionableGroup<ILayoutAnchorablePane>)model, model.Orientation)
	{
		_model = model;
	}

	protected override void OnFixChildrenDockLengths()
	{
		if (_model.Orientation == Orientation.Horizontal)
		{
			for (int i = 0; i < _model.Children.Count; i++)
			{
				ILayoutPositionableElement layoutPositionableElement = _model.Children[i] as ILayoutPositionableElement;
				if (!layoutPositionableElement.DockWidth.IsStar)
				{
					layoutPositionableElement.DockWidth = new GridLength(1.0, GridUnitType.Star);
				}
			}
			return;
		}
		for (int j = 0; j < _model.Children.Count; j++)
		{
			ILayoutPositionableElement layoutPositionableElement2 = _model.Children[j] as ILayoutPositionableElement;
			if (!layoutPositionableElement2.DockHeight.IsStar)
			{
				layoutPositionableElement2.DockHeight = new GridLength(1.0, GridUnitType.Star);
			}
		}
	}
}
