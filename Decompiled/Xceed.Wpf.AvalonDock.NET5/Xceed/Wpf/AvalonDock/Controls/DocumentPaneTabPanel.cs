using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class DocumentPaneTabPanel : Panel
{
	public DocumentPaneTabPanel()
	{
		base.FlowDirection = FlowDirection.LeftToRight;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		Size val = default(Size);
		foreach (FrameworkElement child in base.Children)
		{
			child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			double width = ((Size)(ref val)).Width;
			Size desiredSize = child.DesiredSize;
			((Size)(ref val)).Width = width + ((Size)(ref desiredSize)).Width;
			double height = ((Size)(ref val)).Height;
			desiredSize = child.DesiredSize;
			((Size)(ref val)).Height = Math.Max(height, ((Size)(ref desiredSize)).Height);
		}
		return new Size(Math.Min(((Size)(ref val)).Width, ((Size)(ref availableSize)).Width), ((Size)(ref val)).Height);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		IEnumerable<UIElement> enumerable = from UIElement ch in base.Children
			where ch.Visibility != Visibility.Collapsed
			select ch;
		double num = 0.0;
		bool flag = false;
		foreach (TabItem item in enumerable)
		{
			Size result;
			if (!flag)
			{
				double num2 = num;
				result = item.DesiredSize;
				if (!(num2 + ((Size)(ref result)).Width > ((Size)(ref finalSize)).Width))
				{
					item.Visibility = Visibility.Visible;
					double num3 = num;
					Size desiredSize = item.DesiredSize;
					item.Arrange(new Rect(num3, 0.0, ((Size)(ref desiredSize)).Width, ((Size)(ref finalSize)).Height));
					num += item.ActualWidth + item.Margin.Left + item.Margin.Right;
					continue;
				}
			}
			if (item.Content is LayoutContent { IsSelected: not false } layoutContent && !item.IsVisible)
			{
				ILayoutContainer parent = layoutContent.Parent;
				ILayoutContentSelector layoutContentSelector = layoutContent.Parent as ILayoutContentSelector;
				ILayoutPane layoutPane = layoutContent.Parent as ILayoutPane;
				int num4 = layoutContentSelector.IndexOf(layoutContent);
				if (num4 > 0 && parent.ChildrenCount > 1)
				{
					layoutPane.MoveChild(num4, 0);
					layoutContentSelector.SelectedContentIndex = 0;
					result = ArrangeOverride(finalSize);
					return result;
				}
			}
			item.Visibility = Visibility.Hidden;
			flag = true;
		}
		return finalSize;
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		base.OnMouseLeave(e);
	}
}
