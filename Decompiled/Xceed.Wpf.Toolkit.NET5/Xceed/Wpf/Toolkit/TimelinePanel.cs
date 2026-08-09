using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class TimelinePanel : Panel, IScrollInfo
{
	private List<DateElement> _visibleElements;

	public static readonly DependencyProperty BeginDateProperty;

	public static readonly DependencyProperty EndDateProperty;

	public static readonly DependencyProperty OverlapBehaviorProperty;

	public static readonly DependencyProperty KeepOriginalOrderForOverlapProperty;

	public static readonly DependencyProperty OrientationProperty;

	public static readonly DependencyProperty UnitTimeSpanProperty;

	public static readonly DependencyProperty UnitSizeProperty;

	public static readonly DependencyProperty DateProperty;

	public static readonly DependencyProperty DateEndProperty;

	private bool _allowHorizontal;

	private bool _allowVertical;

	private Vector _computedOffset = new Vector(0.0, 0.0);

	private Size _extent = new Size(0.0, 0.0);

	private Vector _offset = new Vector(0.0, 0.0);

	private ScrollViewer _scrollOwner;

	private Size _viewport;

	private Size _physicalViewport;

	public DateTime BeginDate
	{
		get
		{
			return (DateTime)((DependencyObject)this).GetValue(BeginDateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BeginDateProperty, (object)value);
		}
	}

	public DateTime EndDate
	{
		get
		{
			return (DateTime)((DependencyObject)this).GetValue(EndDateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndDateProperty, (object)value);
		}
	}

	public OverlapBehavior OverlapBehavior
	{
		get
		{
			return (OverlapBehavior)((DependencyObject)this).GetValue(OverlapBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlapBehaviorProperty, (object)value);
		}
	}

	public bool KeepOriginalOrderForOverlap
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(KeepOriginalOrderForOverlapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KeepOriginalOrderForOverlapProperty, (object)value);
		}
	}

	public Orientation Orientation
	{
		get
		{
			return (Orientation)((DependencyObject)this).GetValue(OrientationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OrientationProperty, (object)value);
		}
	}

	public TimeSpan UnitTimeSpan
	{
		get
		{
			return (TimeSpan)((DependencyObject)this).GetValue(UnitTimeSpanProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnitTimeSpanProperty, (object)value);
		}
	}

	public double UnitSize
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(UnitSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnitSizeProperty, (object)value);
		}
	}

	public List<DateElement> VisibleElements => _visibleElements;

	public bool CanHorizontallyScroll
	{
		get
		{
			return _allowHorizontal;
		}
		set
		{
			_allowHorizontal = value;
		}
	}

	public bool CanVerticallyScroll
	{
		get
		{
			return _allowVertical;
		}
		set
		{
			_allowVertical = value;
		}
	}

	public double ExtentHeight => ((Size)(ref _extent)).Height;

	public double ExtentWidth => ((Size)(ref _extent)).Width;

	public double HorizontalOffset => ((Vector)(ref _offset)).X;

	public ScrollViewer ScrollOwner
	{
		get
		{
			return _scrollOwner;
		}
		set
		{
			if (_scrollOwner != value)
			{
				_scrollOwner = value;
				ResetScrollInfo();
			}
		}
	}

	public double VerticalOffset => ((Vector)(ref _offset)).Y;

	public double ViewportHeight => ((Size)(ref _viewport)).Height;

	public double ViewportWidth => ((Size)(ref _viewport)).Width;

	private bool IsScrolling => _scrollOwner != null;

	public static DateTime GetDate(DependencyObject obj)
	{
		return (DateTime)obj.GetValue(DateProperty);
	}

	public static void SetDate(DependencyObject obj, DateTime value)
	{
		obj.SetValue(DateProperty, (object)value);
	}

	public static DateTime GetDateEnd(DependencyObject obj)
	{
		return (DateTime)obj.GetValue(DateEndProperty);
	}

	public static void SetDateEnd(DependencyObject obj, DateTime value)
	{
		obj.SetValue(DateEndProperty, (object)value);
	}

	static TimelinePanel()
	{
		BeginDateProperty = DependencyProperty.Register("BeginDate", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsMeasure));
		EndDateProperty = DependencyProperty.Register("EndDate", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsMeasure));
		OverlapBehaviorProperty = DependencyProperty.Register("OverlapBehavior", typeof(OverlapBehavior), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)OverlapBehavior.Stack, FrameworkPropertyMetadataOptions.AffectsMeasure));
		KeepOriginalOrderForOverlapProperty = DependencyProperty.Register("KeepOriginalOrderForOverlap", typeof(bool), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.AffectsMeasure));
		OrientationProperty = StackPanel.OrientationProperty.AddOwner(typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));
		UnitTimeSpanProperty = DependencyProperty.Register("UnitTimeSpan", typeof(TimeSpan), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSpan.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure));
		UnitSizeProperty = DependencyProperty.Register("UnitSize", typeof(double), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsMeasure));
		DateProperty = DependencyProperty.RegisterAttached("Date", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsParentMeasure));
		DateEndProperty = DependencyProperty.RegisterAttached("DateEnd", typeof(DateTime), typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsParentMeasure));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelinePanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelinePanel)));
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		DateTime dateTime = DateTime.MaxValue;
		DateTime dateTime2 = DateTime.MinValue;
		foreach (UIElement internalChild in base.InternalChildren)
		{
			DateTime date = GetDate((DependencyObject)(object)internalChild);
			DateTime dateEnd = GetDateEnd((DependencyObject)(object)internalChild);
			if (date < dateTime)
			{
				dateTime = date;
			}
			if (date > dateTime2)
			{
				dateTime2 = date;
			}
			if (dateEnd > dateTime2)
			{
				dateTime2 = dateEnd;
			}
		}
		if (BeginDate == DateTime.MinValue)
		{
			BeginDate = dateTime;
		}
		if (EndDate == DateTime.MinValue)
		{
			EndDate = dateTime2;
		}
		foreach (UIElement internalChild2 in base.InternalChildren)
		{
			DateTime date2 = GetDate((DependencyObject)(object)internalChild2);
			DateTime dateEnd2 = GetDateEnd((DependencyObject)(object)internalChild2);
			Size availableSize2 = availableSize;
			if (dateEnd2 > DateTime.MinValue && dateEnd2 > date2)
			{
				if (Orientation == Orientation.Horizontal)
				{
					if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
					{
						double num = (double)(dateEnd2.Ticks - date2.Ticks) / (double)UnitTimeSpan.Ticks;
						((Size)(ref availableSize2)).Width = num * UnitSize;
					}
					else if (!double.IsPositiveInfinity(((Size)(ref availableSize)).Width))
					{
						((Size)(ref availableSize2)).Width = CalculateTimelineOffset(dateEnd2, ((Size)(ref availableSize)).Width) - CalculateTimelineOffset(date2, ((Size)(ref availableSize)).Width);
					}
				}
				else if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
				{
					double num2 = (double)(dateEnd2.Ticks - date2.Ticks) / (double)UnitTimeSpan.Ticks;
					((Size)(ref availableSize2)).Height = num2 * UnitSize;
				}
				else if (!double.IsPositiveInfinity(((Size)(ref availableSize)).Height))
				{
					((Size)(ref availableSize2)).Height = CalculateTimelineOffset(dateEnd2, ((Size)(ref availableSize)).Height) - CalculateTimelineOffset(date2, ((Size)(ref availableSize)).Height);
				}
			}
			internalChild2.Measure(availableSize2);
		}
		Size availableSize3 = default(Size);
		((Size)(ref availableSize3))._002Ector(((Size)(ref availableSize)).Width, ((Size)(ref availableSize)).Height);
		if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
		{
			double num3 = (double)(EndDate.Ticks - BeginDate.Ticks) / (double)UnitTimeSpan.Ticks;
			if (Orientation == Orientation.Horizontal)
			{
				((Size)(ref availableSize3)).Width = num3 * UnitSize;
			}
			else
			{
				((Size)(ref availableSize3)).Height = num3 * UnitSize;
			}
		}
		Size result = default(Size);
		if ((Orientation == Orientation.Vertical && double.IsPositiveInfinity(((Size)(ref availableSize3)).Height)) || (Orientation == Orientation.Horizontal && double.IsPositiveInfinity(((Size)(ref availableSize3)).Width)))
		{
			_visibleElements = null;
		}
		else
		{
			LayoutItems(base.InternalChildren, availableSize3);
			Rect val = default(Rect);
			foreach (DateElement visibleElement in _visibleElements)
			{
				((Rect)(ref val)).Union(visibleElement.PlacementRectangle);
			}
			Size size;
			if (Orientation == Orientation.Horizontal)
			{
				((Size)(ref result)).Width = ((Size)(ref availableSize3)).Width;
				size = ((Rect)(ref val)).Size;
				((Size)(ref result)).Height = ((Size)(ref size)).Height;
			}
			else
			{
				size = ((Rect)(ref val)).Size;
				((Size)(ref result)).Width = ((Size)(ref size)).Width;
				((Size)(ref result)).Height = ((Size)(ref availableSize3)).Height;
			}
		}
		if (IsScrolling)
		{
			Size viewport = default(Size);
			((Size)(ref viewport))._002Ector(((Size)(ref availableSize)).Width, ((Size)(ref availableSize)).Height);
			Size extent = default(Size);
			((Size)(ref extent))._002Ector(((Size)(ref result)).Width, ((Size)(ref result)).Height);
			Vector offset = default(Vector);
			((Vector)(ref offset))._002Ector(Math.Max(0.0, Math.Min(((Vector)(ref _offset)).X, ((Size)(ref extent)).Width - ((Size)(ref viewport)).Width)), Math.Max(0.0, Math.Min(((Vector)(ref _offset)).Y, ((Size)(ref extent)).Height - ((Size)(ref viewport)).Height)));
			SetScrollingData(viewport, extent, offset);
			((Size)(ref result)).Width = Math.Min(((Size)(ref result)).Width, ((Size)(ref availableSize)).Width);
			((Size)(ref result)).Height = Math.Min(((Size)(ref result)).Height, ((Size)(ref availableSize)).Height);
			_physicalViewport = availableSize;
		}
		return result;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		Rect val = default(Rect);
		if (_visibleElements == null)
		{
			LayoutItems(base.InternalChildren, finalSize);
		}
		Rect finalRect = default(Rect);
		foreach (DateElement visibleElement in _visibleElements)
		{
			if (IsScrolling)
			{
				((Rect)(ref finalRect))._002Ector(((Rect)(ref visibleElement.PlacementRectangle)).Location, ((Rect)(ref visibleElement.PlacementRectangle)).Size);
				((Rect)(ref finalRect)).Offset(-_offset);
				visibleElement.Element.Arrange(finalRect);
			}
			else
			{
				visibleElement.Element.Arrange(visibleElement.PlacementRectangle);
			}
			((Rect)(ref val)).Union(visibleElement.PlacementRectangle);
		}
		Size size;
		Size result = default(Size);
		if (Orientation == Orientation.Horizontal)
		{
			double width = ((Size)(ref finalSize)).Width;
			size = ((Rect)(ref val)).Size;
			((Size)(ref result))._002Ector(width, ((Size)(ref size)).Height);
		}
		else
		{
			size = ((Rect)(ref val)).Size;
			((Size)(ref result))._002Ector(((Size)(ref size)).Width, ((Size)(ref finalSize)).Height);
		}
		return result;
	}

	private void ResetScrollInfo()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		_offset = default(Vector);
		_physicalViewport = (_viewport = (_extent = new Size(0.0, 0.0)));
	}

	private void SetScrollingData(Size viewport, Size extent, Vector offset)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		_offset = offset;
		if (!AreVirtuallyEqual(viewport, _viewport) || !AreVirtuallyEqual(extent, _extent) || !AreVirtuallyEqual(offset, _computedOffset))
		{
			_viewport = viewport;
			_extent = extent;
			_offset = offset;
			OnScrollChange();
		}
	}

	private double ValidateInputOffset(double offset, string parameterName)
	{
		if (double.IsNaN(offset))
		{
			throw new ArgumentOutOfRangeException(parameterName);
		}
		return Math.Max(0.0, offset);
	}

	private void OnScrollChange()
	{
		if (ScrollOwner != null)
		{
			ScrollOwner.InvalidateScrollInfo();
		}
	}

	private double CalculateTimelineOffset(DateTime d, double finalWidth)
	{
		long num = EndDate.Ticks - BeginDate.Ticks;
		long num2 = d.Ticks - BeginDate.Ticks;
		if (UnitTimeSpan != TimeSpan.Zero && UnitSize > 0.0)
		{
			return (double)num2 / (double)UnitTimeSpan.Ticks * UnitSize;
		}
		if (num > 0)
		{
			return (double)num2 / (double)num * finalWidth;
		}
		return 0.0;
	}

	private static int CompareElementsByLeft(DateElement a, DateElement b)
	{
		return ((Rect)(ref a.PlacementRectangle)).Left.CompareTo(((Rect)(ref b.PlacementRectangle)).Left);
	}

	private static int CompareElementsByTop(DateElement a, DateElement b)
	{
		return ((Rect)(ref a.PlacementRectangle)).Top.CompareTo(((Rect)(ref b.PlacementRectangle)).Top);
	}

	private void LayoutItems(UIElementCollection children, Size availableSize)
	{
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
		//IL_089d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0624: Unknown result type (might be due to invalid IL or missing references)
		//IL_0629: Unknown result type (might be due to invalid IL or missing references)
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_097f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		_visibleElements = new List<DateElement>();
		List<DateElement> list = new List<DateElement>();
		int num = 0;
		foreach (UIElement child in children)
		{
			if (child == null)
			{
				continue;
			}
			DateTime date = GetDate((DependencyObject)(object)child);
			DateTime dateEnd = GetDateEnd((DependencyObject)(object)child);
			if (child.Visibility != Visibility.Collapsed)
			{
				if (KeepOriginalOrderForOverlap)
				{
					_visibleElements.Add(new DateElement(child, date, dateEnd, num));
				}
				else
				{
					_visibleElements.Add(new DateElement(child, date, dateEnd));
				}
			}
			num++;
		}
		_visibleElements.Sort();
		foreach (DateElement visibleElement in _visibleElements)
		{
			DateTime date2 = GetDate((DependencyObject)(object)visibleElement.Element);
			DateTime dateEnd2 = GetDateEnd((DependencyObject)(object)visibleElement.Element);
			Size desiredSize;
			if (Orientation == Orientation.Vertical)
			{
				((Rect)(ref visibleElement.PlacementRectangle)).Y = CalculateTimelineOffset(date2, ((Size)(ref availableSize)).Height);
				if (dateEnd2 > DateTime.MinValue && dateEnd2 > date2)
				{
					((Rect)(ref visibleElement.PlacementRectangle)).Height = CalculateTimelineOffset(dateEnd2, ((Size)(ref availableSize)).Height) - CalculateTimelineOffset(date2, ((Size)(ref availableSize)).Height);
				}
				else
				{
					ref Rect placementRectangle = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					((Rect)(ref placementRectangle)).Height = ((Size)(ref desiredSize)).Height;
				}
				switch (OverlapBehavior)
				{
				case OverlapBehavior.None:
				{
					((Rect)(ref visibleElement.PlacementRectangle)).X = 0.0;
					ref Rect placementRectangle15 = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					((Rect)(ref placementRectangle15)).Width = ((Size)(ref desiredSize)).Width;
					break;
				}
				case OverlapBehavior.Hide:
					list.Clear();
					foreach (DateElement visibleElement2 in _visibleElements)
					{
						if (visibleElement == visibleElement2)
						{
							break;
						}
						Rect placementRectangle12 = visibleElement.PlacementRectangle;
						Rect placementRectangle13 = visibleElement2.PlacementRectangle;
						if (((Rect)(ref placementRectangle12)).Top >= ((Rect)(ref placementRectangle13)).Top && ((Rect)(ref placementRectangle12)).Top < ((Rect)(ref placementRectangle13)).Bottom)
						{
							list.Add(visibleElement2);
						}
					}
					if (list.Count > 0)
					{
						((Rect)(ref visibleElement.PlacementRectangle)).X = 0.0;
						((Rect)(ref visibleElement.PlacementRectangle)).Y = 0.0;
						((Rect)(ref visibleElement.PlacementRectangle)).Width = 0.0;
						((Rect)(ref visibleElement.PlacementRectangle)).Height = 0.0;
					}
					else
					{
						((Rect)(ref visibleElement.PlacementRectangle)).X = 0.0;
						ref Rect placementRectangle14 = ref visibleElement.PlacementRectangle;
						desiredSize = visibleElement.Element.DesiredSize;
						((Rect)(ref placementRectangle14)).Width = ((Size)(ref desiredSize)).Width;
					}
					break;
				case OverlapBehavior.Stretch:
				{
					list.Clear();
					foreach (DateElement visibleElement3 in _visibleElements)
					{
						if (visibleElement == visibleElement3)
						{
							break;
						}
						Rect placementRectangle7 = visibleElement.PlacementRectangle;
						Rect placementRectangle8 = visibleElement3.PlacementRectangle;
						if (((Rect)(ref placementRectangle7)).Top >= ((Rect)(ref placementRectangle8)).Top && ((Rect)(ref placementRectangle7)).Top < ((Rect)(ref placementRectangle8)).Bottom)
						{
							list.Add(visibleElement3);
						}
					}
					list.Sort(CompareElementsByLeft);
					double x = 0.0;
					double num2 = ((Size)(ref availableSize)).Width;
					if (list.Count > 0)
					{
						bool flag = false;
						for (int j = 0; j < list.Count; j++)
						{
							Rect placementRectangle9 = list[j].PlacementRectangle;
							if (j == 0 && ((Rect)(ref placementRectangle9)).Left > 0.0)
							{
								x = 0.0;
								num2 = ((Rect)(ref placementRectangle9)).Left;
								flag = true;
								break;
							}
							if (j == list.Count - 1)
							{
								break;
							}
							Rect placementRectangle10 = list[j + 1].PlacementRectangle;
							if (((Rect)(ref placementRectangle10)).Left - ((Rect)(ref placementRectangle9)).Right > 0.0)
							{
								x = ((Rect)(ref placementRectangle9)).Right;
								num2 = ((Rect)(ref placementRectangle10)).Left - ((Rect)(ref placementRectangle9)).Right;
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							num2 = Math.Min(((Size)(ref availableSize)).Width / (double)(list.Count + 1), ((Rect)(ref list[0].PlacementRectangle)).Width);
							x = 0.0;
							foreach (DateElement item in list)
							{
								((Rect)(ref item.PlacementRectangle)).Width = num2;
								((Rect)(ref item.PlacementRectangle)).X = x;
								x += num2;
							}
						}
					}
					((Rect)(ref visibleElement.PlacementRectangle)).X = x;
					if (double.IsPositiveInfinity(num2))
					{
						ref Rect placementRectangle11 = ref visibleElement.PlacementRectangle;
						desiredSize = visibleElement.Element.DesiredSize;
						((Rect)(ref placementRectangle11)).Width = ((Size)(ref desiredSize)).Width;
					}
					else
					{
						((Rect)(ref visibleElement.PlacementRectangle)).Width = num2;
					}
					break;
				}
				case OverlapBehavior.Stack:
				{
					list.Clear();
					foreach (DateElement visibleElement4 in _visibleElements)
					{
						if (visibleElement == visibleElement4)
						{
							break;
						}
						Rect placementRectangle2 = visibleElement.PlacementRectangle;
						Rect placementRectangle3 = visibleElement4.PlacementRectangle;
						if (((Rect)(ref placementRectangle2)).Top >= ((Rect)(ref placementRectangle3)).Top && ((Rect)(ref placementRectangle2)).Top < ((Rect)(ref placementRectangle3)).Bottom)
						{
							list.Add(visibleElement4);
						}
					}
					list.Sort(CompareElementsByLeft);
					double x = 0.0;
					ref Rect placementRectangle4 = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					((Rect)(ref placementRectangle4)).Width = ((Size)(ref desiredSize)).Width;
					for (int i = 0; i < list.Count; i++)
					{
						Rect placementRectangle5 = list[i].PlacementRectangle;
						if (i == 0 && ((Rect)(ref placementRectangle5)).Left >= ((Rect)(ref visibleElement.PlacementRectangle)).Width)
						{
							x = 0.0;
							break;
						}
						if (i == list.Count - 1)
						{
							x = ((Rect)(ref placementRectangle5)).Right;
							break;
						}
						Rect placementRectangle6 = list[i + 1].PlacementRectangle;
						if (((Rect)(ref placementRectangle6)).Left - ((Rect)(ref placementRectangle5)).Right >= ((Rect)(ref visibleElement.PlacementRectangle)).Width)
						{
							x = ((Rect)(ref placementRectangle5)).Right;
							break;
						}
					}
					((Rect)(ref visibleElement.PlacementRectangle)).X = x;
					break;
				}
				}
				continue;
			}
			((Rect)(ref visibleElement.PlacementRectangle)).X = CalculateTimelineOffset(date2, ((Size)(ref availableSize)).Width);
			if (dateEnd2 > DateTime.MinValue && dateEnd2 > date2)
			{
				((Rect)(ref visibleElement.PlacementRectangle)).Width = CalculateTimelineOffset(dateEnd2, ((Size)(ref availableSize)).Width) - CalculateTimelineOffset(date2, ((Size)(ref availableSize)).Width);
			}
			else
			{
				ref Rect placementRectangle16 = ref visibleElement.PlacementRectangle;
				desiredSize = visibleElement.Element.DesiredSize;
				((Rect)(ref placementRectangle16)).Width = ((Size)(ref desiredSize)).Width;
			}
			switch (OverlapBehavior)
			{
			case OverlapBehavior.None:
			{
				((Rect)(ref visibleElement.PlacementRectangle)).Y = 0.0;
				ref Rect placementRectangle30 = ref visibleElement.PlacementRectangle;
				desiredSize = visibleElement.Element.DesiredSize;
				((Rect)(ref placementRectangle30)).Height = ((Size)(ref desiredSize)).Height;
				break;
			}
			case OverlapBehavior.Hide:
				list.Clear();
				foreach (DateElement visibleElement5 in _visibleElements)
				{
					if (visibleElement == visibleElement5)
					{
						break;
					}
					Rect placementRectangle27 = visibleElement.PlacementRectangle;
					Rect placementRectangle28 = visibleElement5.PlacementRectangle;
					if (((Rect)(ref placementRectangle27)).Left >= ((Rect)(ref placementRectangle28)).Left && ((Rect)(ref placementRectangle27)).Left < ((Rect)(ref placementRectangle28)).Right)
					{
						list.Add(visibleElement5);
					}
				}
				if (list.Count > 0)
				{
					((Rect)(ref visibleElement.PlacementRectangle)).X = 0.0;
					((Rect)(ref visibleElement.PlacementRectangle)).Y = 0.0;
					((Rect)(ref visibleElement.PlacementRectangle)).Width = 0.0;
					((Rect)(ref visibleElement.PlacementRectangle)).Height = 0.0;
				}
				else
				{
					((Rect)(ref visibleElement.PlacementRectangle)).Y = 0.0;
					ref Rect placementRectangle29 = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					((Rect)(ref placementRectangle29)).Height = ((Size)(ref desiredSize)).Height;
				}
				break;
			case OverlapBehavior.Stretch:
			{
				list.Clear();
				foreach (DateElement visibleElement6 in _visibleElements)
				{
					if (visibleElement == visibleElement6)
					{
						break;
					}
					Rect placementRectangle22 = visibleElement.PlacementRectangle;
					Rect placementRectangle23 = visibleElement6.PlacementRectangle;
					if (((Rect)(ref placementRectangle22)).Left >= ((Rect)(ref placementRectangle23)).Left && ((Rect)(ref placementRectangle22)).Left < ((Rect)(ref placementRectangle23)).Right)
					{
						list.Add(visibleElement6);
					}
				}
				list.Sort(CompareElementsByTop);
				double y = 0.0;
				double num3 = ((Size)(ref availableSize)).Height;
				if (list.Count > 0)
				{
					bool flag2 = false;
					for (int l = 0; l < list.Count; l++)
					{
						Rect placementRectangle24 = list[l].PlacementRectangle;
						if (l == 0 && ((Rect)(ref placementRectangle24)).Top > 0.0)
						{
							y = 0.0;
							num3 = ((Rect)(ref placementRectangle24)).Top;
							flag2 = true;
							break;
						}
						if (l == list.Count - 1)
						{
							break;
						}
						Rect placementRectangle25 = list[l + 1].PlacementRectangle;
						if (((Rect)(ref placementRectangle25)).Top - ((Rect)(ref placementRectangle24)).Bottom > 0.0)
						{
							y = ((Rect)(ref placementRectangle24)).Bottom;
							num3 = ((Rect)(ref placementRectangle25)).Top - ((Rect)(ref placementRectangle24)).Bottom;
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						num3 = Math.Min(((Size)(ref availableSize)).Height / (double)(list.Count + 1), ((Rect)(ref list[0].PlacementRectangle)).Height);
						y = 0.0;
						foreach (DateElement item2 in list)
						{
							((Rect)(ref item2.PlacementRectangle)).Height = num3;
							((Rect)(ref item2.PlacementRectangle)).Y = y;
							y += num3;
						}
					}
				}
				((Rect)(ref visibleElement.PlacementRectangle)).Y = y;
				if (double.IsPositiveInfinity(num3))
				{
					ref Rect placementRectangle26 = ref visibleElement.PlacementRectangle;
					desiredSize = visibleElement.Element.DesiredSize;
					((Rect)(ref placementRectangle26)).Height = ((Size)(ref desiredSize)).Height;
				}
				else
				{
					((Rect)(ref visibleElement.PlacementRectangle)).Height = num3;
				}
				break;
			}
			case OverlapBehavior.Stack:
			{
				list.Clear();
				foreach (DateElement visibleElement7 in _visibleElements)
				{
					if (visibleElement == visibleElement7)
					{
						break;
					}
					Rect placementRectangle17 = visibleElement.PlacementRectangle;
					Rect placementRectangle18 = visibleElement7.PlacementRectangle;
					if (((Rect)(ref placementRectangle17)).Left >= ((Rect)(ref placementRectangle18)).Left && ((Rect)(ref placementRectangle17)).Left < ((Rect)(ref placementRectangle18)).Right)
					{
						list.Add(visibleElement7);
					}
				}
				list.Sort(CompareElementsByTop);
				double y = 0.0;
				ref Rect placementRectangle19 = ref visibleElement.PlacementRectangle;
				desiredSize = visibleElement.Element.DesiredSize;
				((Rect)(ref placementRectangle19)).Height = ((Size)(ref desiredSize)).Height;
				for (int k = 0; k < list.Count; k++)
				{
					Rect placementRectangle20 = list[k].PlacementRectangle;
					if (k == 0 && ((Rect)(ref placementRectangle20)).Top >= ((Rect)(ref visibleElement.PlacementRectangle)).Height)
					{
						y = 0.0;
						break;
					}
					if (k == list.Count - 1)
					{
						y = ((Rect)(ref placementRectangle20)).Bottom;
						break;
					}
					Rect placementRectangle21 = list[k + 1].PlacementRectangle;
					if (((Rect)(ref placementRectangle21)).Top - ((Rect)(ref placementRectangle20)).Bottom >= ((Rect)(ref visibleElement.PlacementRectangle)).Height)
					{
						y = ((Rect)(ref placementRectangle20)).Bottom;
						break;
					}
				}
				((Rect)(ref visibleElement.PlacementRectangle)).Y = y;
				break;
			}
			}
		}
	}

	private static bool AreVirtuallyEqual(double d1, double d2)
	{
		if (double.IsPositiveInfinity(d1))
		{
			return double.IsPositiveInfinity(d2);
		}
		if (double.IsNegativeInfinity(d1))
		{
			return double.IsNegativeInfinity(d2);
		}
		if (double.IsNaN(d1))
		{
			return double.IsNaN(d2);
		}
		double num = d1 - d2;
		double num2 = (Math.Abs(d1) + Math.Abs(d2) + 10.0) * 1E-15;
		if (0.0 - num2 < num)
		{
			return num2 > num;
		}
		return false;
	}

	private static bool AreVirtuallyEqual(Size s1, Size s2)
	{
		if (AreVirtuallyEqual(((Size)(ref s1)).Width, ((Size)(ref s2)).Width))
		{
			return AreVirtuallyEqual(((Size)(ref s1)).Height, ((Size)(ref s2)).Height);
		}
		return false;
	}

	private static bool AreVirtuallyEqual(Vector v1, Vector v2)
	{
		if (AreVirtuallyEqual(((Vector)(ref v1)).X, ((Vector)(ref v2)).X))
		{
			return AreVirtuallyEqual(((Vector)(ref v1)).Y, ((Vector)(ref v2)).Y);
		}
		return false;
	}

	public void LineDown()
	{
		SetVerticalOffset(VerticalOffset + ((Orientation == Orientation.Vertical) ? 1.0 : 16.0));
	}

	public void LineLeft()
	{
		SetHorizontalOffset(HorizontalOffset - ((Orientation == Orientation.Horizontal) ? 1.0 : 16.0));
	}

	public void LineRight()
	{
		SetHorizontalOffset(HorizontalOffset + ((Orientation == Orientation.Horizontal) ? 1.0 : 16.0));
	}

	public void LineUp()
	{
		SetVerticalOffset(VerticalOffset - ((Orientation == Orientation.Vertical) ? 1.0 : 16.0));
	}

	public Rect MakeVisible(Visual visual, Rect rectangle)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return rectangle;
	}

	public void MouseWheelDown()
	{
		SetVerticalOffset(VerticalOffset + (double)SystemParameters.WheelScrollLines * ((Orientation == Orientation.Vertical) ? 1.0 : 16.0));
	}

	public void MouseWheelLeft()
	{
		SetHorizontalOffset(HorizontalOffset - 3.0 * ((Orientation == Orientation.Horizontal) ? 1.0 : 16.0));
	}

	public void MouseWheelRight()
	{
		SetHorizontalOffset(HorizontalOffset + 3.0 * ((Orientation == Orientation.Horizontal) ? 1.0 : 16.0));
	}

	public void MouseWheelUp()
	{
		SetVerticalOffset(VerticalOffset - (double)SystemParameters.WheelScrollLines * ((Orientation == Orientation.Vertical) ? 1.0 : 16.0));
	}

	public void PageDown()
	{
		SetVerticalOffset(VerticalOffset + ViewportHeight);
	}

	public void PageLeft()
	{
		SetHorizontalOffset(HorizontalOffset - ViewportWidth);
	}

	public void PageRight()
	{
		SetHorizontalOffset(HorizontalOffset + ViewportWidth);
	}

	public void PageUp()
	{
		SetVerticalOffset(VerticalOffset - ViewportHeight);
	}

	public void SetHorizontalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "HorizontalOffset");
		if (!AreVirtuallyEqual(offset, ((Vector)(ref _offset)).X))
		{
			((Vector)(ref _offset)).X = offset;
			InvalidateMeasure();
		}
	}

	public void SetVerticalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "VerticalOffset");
		if (!AreVirtuallyEqual(offset, ((Vector)(ref _offset)).Y))
		{
			((Vector)(ref _offset)).Y = offset;
			InvalidateMeasure();
		}
	}
}
