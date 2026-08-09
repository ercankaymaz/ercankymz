using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

public class WrapPanel : AnimationPanel
{
	public static readonly DependencyProperty OrientationProperty = StackPanel.OrientationProperty.AddOwner(typeof(WrapPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Orientation.Horizontal, new PropertyChangedCallback(OnOrientationChanged)));

	private Orientation _orientation;

	public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register("ItemWidth", typeof(double), typeof(WrapPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.NaN, new PropertyChangedCallback(OnInvalidateMeasure)), new ValidateValueCallback(IsWidthHeightValid));

	public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register("ItemHeight", typeof(double), typeof(WrapPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)double.NaN, new PropertyChangedCallback(OnInvalidateMeasure)), new ValidateValueCallback(IsWidthHeightValid));

	public static readonly DependencyProperty IsStackReversedProperty = DependencyProperty.Register("IsChildOrderReversed", typeof(bool), typeof(WrapPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnInvalidateMeasure)));

	public Orientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			((DependencyObject)this).SetValue(OrientationProperty, (object)value);
		}
	}

	[TypeConverter(typeof(LengthConverter))]
	public double ItemWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ItemWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemWidthProperty, (object)value);
		}
	}

	[TypeConverter(typeof(LengthConverter))]
	public double ItemHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ItemHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemHeightProperty, (object)value);
		}
	}

	public bool IsChildOrderReversed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsStackReversedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsStackReversedProperty, (object)value);
		}
	}

	private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		WrapPanel obj = (WrapPanel)(object)d;
		obj._orientation = (Orientation)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		obj.InvalidateMeasure();
	}

	protected override Size MeasureChildrenOverride(UIElementCollection children, Size constraint)
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		double val = 0.0;
		double num = 0.0;
		bool flag = Orientation == Orientation.Horizontal;
		double num2 = (flag ? ((Size)(ref constraint)).Width : ((Size)(ref constraint)).Height);
		double itemWidth = ItemWidth;
		double itemHeight = ItemHeight;
		bool flag2 = !double.IsNaN(itemWidth);
		bool flag3 = !double.IsNaN(itemHeight);
		double num3 = 0.0;
		double num4 = 0.0;
		Size availableSize = default(Size);
		((Size)(ref availableSize))._002Ector(flag2 ? itemWidth : ((Size)(ref constraint)).Width, flag3 ? itemHeight : ((Size)(ref constraint)).Height);
		bool isChildOrderReversed = IsChildOrderReversed;
		int num5 = (isChildOrderReversed ? (children.Count - 1) : 0);
		if (!isChildOrderReversed)
		{
			_ = children.Count;
		}
		int num6 = ((!isChildOrderReversed) ? 1 : (-1));
		int num7 = num5;
		for (int i = 0; i < children.Count; i++)
		{
			UIElement uIElement = children[num7];
			uIElement.Measure(availableSize);
			Size desiredSize;
			double num8;
			if (!flag)
			{
				if (!flag3)
				{
					desiredSize = uIElement.DesiredSize;
					num8 = ((Size)(ref desiredSize)).Height;
				}
				else
				{
					num8 = itemHeight;
				}
			}
			else if (!flag2)
			{
				desiredSize = uIElement.DesiredSize;
				num8 = ((Size)(ref desiredSize)).Width;
			}
			else
			{
				num8 = itemWidth;
			}
			double num9 = num8;
			double num10;
			if (!flag)
			{
				if (!flag2)
				{
					desiredSize = uIElement.DesiredSize;
					num10 = ((Size)(ref desiredSize)).Width;
				}
				else
				{
					num10 = itemWidth;
				}
			}
			else if (!flag3)
			{
				desiredSize = uIElement.DesiredSize;
				num10 = ((Size)(ref desiredSize)).Height;
			}
			else
			{
				num10 = itemHeight;
			}
			double num11 = num10;
			if (num3 + num9 > num2)
			{
				val = Math.Max(num3, val);
				num += num4;
				num3 = num9;
				num4 = num11;
				if (num9 > num2)
				{
					val = Math.Max(num9, val);
					num += num11;
					num3 = 0.0;
					num4 = 0.0;
				}
			}
			else
			{
				num3 += num9;
				num4 = Math.Max(num11, num4);
			}
			num7 += num6;
		}
		val = Math.Max(num3, val);
		num += num4;
		if (!flag)
		{
			return new Size(num, val);
		}
		return new Size(val, num);
	}

	protected override Size ArrangeChildrenOverride(UIElementCollection children, Size finalSize)
	{
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		bool flag = Orientation == Orientation.Horizontal;
		double num = (flag ? ((Size)(ref finalSize)).Width : ((Size)(ref finalSize)).Height);
		double itemWidth = ItemWidth;
		double itemHeight = ItemHeight;
		double itemExtent = (flag ? itemWidth : itemHeight);
		bool flag2 = !double.IsNaN(itemWidth);
		bool flag3 = !double.IsNaN(itemHeight);
		bool useItemExtent = (flag ? flag2 : flag3);
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = (IsChildOrderReversed ? (children.Count - 1) : 0);
		if (!IsChildOrderReversed)
		{
			_ = children.Count;
		}
		int num6 = ((!IsChildOrderReversed) ? 1 : (-1));
		Collection<UIElement> collection = new Collection<UIElement>();
		int num7 = num5;
		for (int i = 0; i < children.Count; i++)
		{
			UIElement uIElement = children[num7];
			Size desiredSize;
			double num8;
			if (!flag)
			{
				if (!flag3)
				{
					desiredSize = uIElement.DesiredSize;
					num8 = ((Size)(ref desiredSize)).Height;
				}
				else
				{
					num8 = itemHeight;
				}
			}
			else if (!flag2)
			{
				desiredSize = uIElement.DesiredSize;
				num8 = ((Size)(ref desiredSize)).Width;
			}
			else
			{
				num8 = itemWidth;
			}
			double num9 = num8;
			double num10;
			if (!flag)
			{
				if (!flag2)
				{
					desiredSize = uIElement.DesiredSize;
					num10 = ((Size)(ref desiredSize)).Width;
				}
				else
				{
					num10 = itemWidth;
				}
			}
			else if (!flag3)
			{
				desiredSize = uIElement.DesiredSize;
				num10 = ((Size)(ref desiredSize)).Height;
			}
			else
			{
				num10 = itemHeight;
			}
			double num11 = num10;
			if (num2 + num9 > num)
			{
				ArrangeLineOfChildren(collection, flag, num3, num4, itemExtent, useItemExtent);
				num4 += num3;
				num2 = num9;
				if (num9 > num)
				{
					collection.Add(uIElement);
					ArrangeLineOfChildren(collection, flag, num11, num4, itemExtent, useItemExtent);
					num4 += num11;
					num2 = 0.0;
				}
				collection.Add(uIElement);
			}
			else
			{
				collection.Add(uIElement);
				num2 += num9;
				num3 = Math.Max(num11, num3);
			}
			num7 += num6;
		}
		if (collection.Count > 0)
		{
			ArrangeLineOfChildren(collection, flag, num3, num4, itemExtent, useItemExtent);
		}
		return finalSize;
	}

	private void ArrangeLineOfChildren(Collection<UIElement> children, bool isHorizontal, double lineStack, double lineStackSum, double itemExtent, bool useItemExtent)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		foreach (UIElement child in children)
		{
			Size desiredSize;
			double num2;
			if (!isHorizontal)
			{
				desiredSize = child.DesiredSize;
				num2 = ((Size)(ref desiredSize)).Height;
			}
			else
			{
				desiredSize = child.DesiredSize;
				num2 = ((Size)(ref desiredSize)).Width;
			}
			double num3 = num2;
			double num4 = (useItemExtent ? itemExtent : num3);
			ArrangeChild(child, isHorizontal ? new Rect(num, lineStackSum, num4, lineStack) : new Rect(lineStackSum, num, lineStack, num4));
			num += num4;
		}
		children.Clear();
	}

	private static void OnInvalidateMeasure(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((AnimationPanel)(object)d).InvalidateMeasure();
	}

	private static bool IsWidthHeightValid(object value)
	{
		double num = (double)value;
		if (!DoubleHelper.IsNaN(num))
		{
			if (num >= 0.0)
			{
				return !double.IsPositiveInfinity(num);
			}
			return false;
		}
		return true;
	}
}
