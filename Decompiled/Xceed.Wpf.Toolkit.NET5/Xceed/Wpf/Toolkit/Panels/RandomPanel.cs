using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.Panels;

public class RandomPanel : AnimationPanel
{
	public static readonly DependencyProperty MinimumWidthProperty = DependencyProperty.Register("MinimumWidth", typeof(double), typeof(RandomPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(10.0, new PropertyChangedCallback(OnMinimumWidthChanged), new CoerceValueCallback(CoerceMinimumWidth)));

	public static readonly DependencyProperty MinimumHeightProperty = DependencyProperty.Register("MinimumHeight", typeof(double), typeof(RandomPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(10.0, new PropertyChangedCallback(OnMinimumHeightChanged), new CoerceValueCallback(CoerceMinimumHeight)));

	public static readonly DependencyProperty MaximumWidthProperty = DependencyProperty.Register("MaximumWidth", typeof(double), typeof(RandomPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(100.0, new PropertyChangedCallback(OnMaximumWidthChanged), new CoerceValueCallback(CoerceMaximumWidth)));

	public static readonly DependencyProperty MaximumHeightProperty = DependencyProperty.Register("MaximumHeight", typeof(double), typeof(RandomPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(100.0, new PropertyChangedCallback(OnMaximumHeightChanged), new CoerceValueCallback(CoerceMaximumHeight)));

	public static readonly DependencyProperty SeedProperty = DependencyProperty.Register("Seed", typeof(int), typeof(RandomPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0, new PropertyChangedCallback(SeedChanged)));

	private static readonly DependencyProperty ActualSizeProperty = DependencyProperty.RegisterAttached("ActualSize", typeof(Size), typeof(RandomPanel), (PropertyMetadata)(object)new UIPropertyMetadata((object)default(Size)));

	private Random _random = new Random();

	public double MinimumWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumWidthProperty, (object)value);
		}
	}

	public double MinimumHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumHeightProperty, (object)value);
		}
	}

	public double MaximumWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumWidthProperty, (object)value);
		}
	}

	public double MaximumHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumHeightProperty, (object)value);
		}
	}

	public int Seed
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SeedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SeedProperty, (object)value);
		}
	}

	private static void OnMinimumWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel obj = (RandomPanel)(object)d;
		((DependencyObject)obj).CoerceValue(MaximumWidthProperty);
		obj.InvalidateMeasure();
	}

	private static object CoerceMinimumWidth(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double maximumWidth = randomPanel.MaximumWidth;
		if (num > maximumWidth)
		{
			return maximumWidth;
		}
		return baseValue;
	}

	private static void OnMinimumHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel obj = (RandomPanel)(object)d;
		((DependencyObject)obj).CoerceValue(MaximumHeightProperty);
		obj.InvalidateMeasure();
	}

	private static object CoerceMinimumHeight(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double maximumHeight = randomPanel.MaximumHeight;
		if (num > maximumHeight)
		{
			return maximumHeight;
		}
		return baseValue;
	}

	private static void OnMaximumWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel obj = (RandomPanel)(object)d;
		((DependencyObject)obj).CoerceValue(MinimumWidthProperty);
		obj.InvalidateMeasure();
	}

	private static object CoerceMaximumWidth(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double minimumWidth = randomPanel.MinimumWidth;
		if (num < minimumWidth)
		{
			return minimumWidth;
		}
		return baseValue;
	}

	private static void OnMaximumHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RandomPanel obj = (RandomPanel)(object)d;
		((DependencyObject)obj).CoerceValue(MinimumHeightProperty);
		obj.InvalidateMeasure();
	}

	private static object CoerceMaximumHeight(DependencyObject d, object baseValue)
	{
		RandomPanel randomPanel = (RandomPanel)(object)d;
		double num = (double)baseValue;
		if (double.IsNaN(num) || double.IsInfinity(num) || num < 0.0)
		{
			return DependencyProperty.UnsetValue;
		}
		double minimumHeight = randomPanel.MinimumHeight;
		if (num < minimumHeight)
		{
			return minimumHeight;
		}
		return baseValue;
	}

	private static void SeedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
	{
		if (obj is RandomPanel)
		{
			RandomPanel obj2 = (RandomPanel)(object)obj;
			obj2._random = new Random((int)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
			obj2.InvalidateArrange();
		}
	}

	private static Size GetActualSize(DependencyObject obj)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return (Size)obj.GetValue(ActualSizeProperty);
	}

	private static void SetActualSize(DependencyObject obj, Size value)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		obj.SetValue(ActualSizeProperty, (object)value);
	}

	protected override Size MeasureChildrenOverride(UIElementCollection children, Size constraint)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		new Size(double.PositiveInfinity, double.PositiveInfinity);
		Size val = default(Size);
		foreach (UIElement child in children)
		{
			if (child != null)
			{
				((Size)(ref val))._002Ector(1.0 * (double)_random.Next(Convert.ToInt32(MinimumWidth), Convert.ToInt32(MaximumWidth)), 1.0 * (double)_random.Next(Convert.ToInt32(MinimumHeight), Convert.ToInt32(MaximumHeight)));
				child.Measure(val);
				SetActualSize((DependencyObject)(object)child, val);
			}
		}
		return default(Size);
	}

	protected override Size ArrangeChildrenOverride(UIElementCollection children, Size finalSize)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		foreach (UIElement child in children)
		{
			if (child != null)
			{
				Size actualSize = GetActualSize((DependencyObject)(object)child);
				double num = _random.Next(0, (int)Math.Max(((Size)(ref finalSize)).Width - ((Size)(ref actualSize)).Width, 0.0));
				double num2 = _random.Next(0, (int)Math.Max(((Size)(ref finalSize)).Height - ((Size)(ref actualSize)).Height, 0.0));
				double num3 = Math.Min(((Size)(ref finalSize)).Width, ((Size)(ref actualSize)).Width);
				double num4 = Math.Min(((Size)(ref finalSize)).Height, ((Size)(ref actualSize)).Height);
				ArrangeChild(child, new Rect(new Point(num, num2), new Size(num3, num4)));
			}
		}
		return finalSize;
	}
}
