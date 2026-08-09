using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.AvalonDock.Controls;

public class AnchorablePaneTabPanel : Panel
{
	public AnchorablePaneTabPanel()
	{
		base.FlowDirection = FlowDirection.LeftToRight;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 0.0;
		IEnumerable<UIElement> enumerable = from UIElement ch in base.Children
			where ch.Visibility != Visibility.Collapsed
			select ch;
		foreach (FrameworkElement item in enumerable)
		{
			item.Measure(new Size(double.PositiveInfinity, ((Size)(ref availableSize)).Height));
			double num3 = num;
			Size desiredSize = item.DesiredSize;
			num = num3 + ((Size)(ref desiredSize)).Width;
			double val = num2;
			desiredSize = item.DesiredSize;
			num2 = Math.Max(val, ((Size)(ref desiredSize)).Height);
		}
		if (num > ((Size)(ref availableSize)).Width)
		{
			double num4 = ((Size)(ref availableSize)).Width / (double)enumerable.Count();
			foreach (FrameworkElement item2 in enumerable)
			{
				item2.Measure(new Size(num4, ((Size)(ref availableSize)).Height));
			}
		}
		return new Size(Math.Min(((Size)(ref availableSize)).Width, num), num2);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		IEnumerable<UIElement> enumerable = from UIElement ch in base.Children
			where ch.Visibility != Visibility.Collapsed
			select ch;
		double width = ((Size)(ref finalSize)).Width;
		double num = enumerable.Sum(delegate(UIElement ch)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			Size desiredSize2 = ch.DesiredSize;
			return ((Size)(ref desiredSize2)).Width;
		});
		double num2 = 0.0;
		if (width > num)
		{
			foreach (FrameworkElement item in enumerable)
			{
				Size desiredSize = item.DesiredSize;
				double width2 = ((Size)(ref desiredSize)).Width;
				item.Arrange(new Rect(num2, 0.0, width2, ((Size)(ref finalSize)).Height));
				num2 += width2;
			}
		}
		else
		{
			double num3 = width / (double)enumerable.Count();
			foreach (FrameworkElement item2 in enumerable)
			{
				item2.Arrange(new Rect(num2, 0.0, num3, ((Size)(ref finalSize)).Height));
				num2 += num3;
			}
		}
		return finalSize;
	}
}
