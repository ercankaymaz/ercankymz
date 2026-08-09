using System;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

public class ZoomboxViewFinderDisplay : FrameworkElement
{
	public static readonly DependencyProperty BackgroundProperty;

	private static readonly DependencyPropertyKey ContentBoundsPropertyKey;

	public static readonly DependencyProperty ContentBoundsProperty;

	public static readonly DependencyProperty ShadowBrushProperty;

	public static readonly DependencyProperty ViewportBrushProperty;

	public static readonly DependencyProperty ViewportPenProperty;

	public static readonly DependencyProperty ViewportRectProperty;

	private static readonly DependencyPropertyKey VisualBrushPropertyKey;

	public static readonly DependencyProperty VisualBrushProperty;

	private Size _availableSize = Size.Empty;

	private double _scale = 1.0;

	public Brush Background
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundProperty, (object)value);
		}
	}

	internal Rect ContentBounds
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Rect)((DependencyObject)this).GetValue(ContentBoundsProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(ContentBoundsPropertyKey, (object)value);
		}
	}

	public Brush ShadowBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ShadowBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowBrushProperty, (object)value);
		}
	}

	public Brush ViewportBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ViewportBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewportBrushProperty, (object)value);
		}
	}

	public Pen ViewportPen
	{
		get
		{
			return (Pen)((DependencyObject)this).GetValue(ViewportPenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewportPenProperty, (object)value);
		}
	}

	public Rect ViewportRect
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Rect)((DependencyObject)this).GetValue(ViewportRectProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(ViewportRectProperty, (object)value);
		}
	}

	internal VisualBrush VisualBrush
	{
		get
		{
			return (VisualBrush)((DependencyObject)this).GetValue(VisualBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisualBrushPropertyKey, (object)value);
		}
	}

	internal Size AvailableSize => _availableSize;

	internal double Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = value;
		}
	}

	static ZoomboxViewFinderDisplay()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new SolidColorBrush(Color.FromArgb(192, byte.MaxValue, byte.MaxValue, byte.MaxValue)), FrameworkPropertyMetadataOptions.AffectsRender));
		ContentBoundsPropertyKey = DependencyProperty.RegisterReadOnly("ContentBounds", typeof(Rect), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Rect.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
		ContentBoundsProperty = ContentBoundsPropertyKey.DependencyProperty;
		ShadowBrushProperty = DependencyProperty.Register("ShadowBrush", typeof(Brush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new SolidColorBrush(Color.FromArgb(128, byte.MaxValue, byte.MaxValue, byte.MaxValue)), FrameworkPropertyMetadataOptions.AffectsRender));
		ViewportBrushProperty = DependencyProperty.Register("ViewportBrush", typeof(Brush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent, FrameworkPropertyMetadataOptions.AffectsRender));
		ViewportPenProperty = DependencyProperty.Register("ViewportPen", typeof(Pen), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Pen(new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)), 1.0), FrameworkPropertyMetadataOptions.AffectsRender));
		ViewportRectProperty = DependencyProperty.Register("ViewportRect", typeof(Rect), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Rect.Empty, FrameworkPropertyMetadataOptions.AffectsRender));
		VisualBrushPropertyKey = DependencyProperty.RegisterReadOnly("VisualBrush", typeof(VisualBrush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		VisualBrushProperty = VisualBrushPropertyKey.DependencyProperty;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ZoomboxViewFinderDisplay)));
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return base.DesiredSize;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		_availableSize = availableSize;
		Rect contentBounds = ContentBounds;
		double num;
		if (!DoubleHelper.IsNaN(((Rect)(ref contentBounds)).Width))
		{
			contentBounds = ContentBounds;
			num = Math.Max(0.0, ((Rect)(ref contentBounds)).Width);
		}
		else
		{
			num = 0.0;
		}
		double num2 = num;
		contentBounds = ContentBounds;
		double num3;
		if (!DoubleHelper.IsNaN(((Rect)(ref contentBounds)).Height))
		{
			contentBounds = ContentBounds;
			num3 = Math.Max(0.0, ((Rect)(ref contentBounds)).Height);
		}
		else
		{
			num3 = 0.0;
		}
		double num4 = num3;
		Size result = default(Size);
		((Size)(ref result))._002Ector(num2, num4);
		if (((Size)(ref result)).Width > ((Size)(ref availableSize)).Width || ((Size)(ref result)).Height > ((Size)(ref availableSize)).Height)
		{
			double num5 = ((Size)(ref availableSize)).Width / ((Size)(ref result)).Width;
			double num6 = ((Size)(ref availableSize)).Height / ((Size)(ref result)).Height;
			double num7 = ((num5 < num6) ? num5 : num6);
			((Size)(ref result))._002Ector(((Size)(ref result)).Width * num7, ((Size)(ref result)).Height * num7);
		}
		return result;
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		base.OnRender(dc);
		dc.DrawRectangle(Background, null, ContentBounds);
		dc.DrawRectangle(VisualBrush, null, ContentBounds);
		Rect viewportRect = ViewportRect;
		if (((Rect)(ref viewportRect)).IntersectsWith(new Rect(base.RenderSize)))
		{
			Point val = new Point(0.0, 0.0);
			Size renderSize = base.RenderSize;
			double width = ((Size)(ref renderSize)).Width;
			viewportRect = ViewportRect;
			Rect rectangle = default(Rect);
			((Rect)(ref rectangle))._002Ector(val, new Size(width, Math.Max(0.0, ((Rect)(ref viewportRect)).Top)));
			viewportRect = ViewportRect;
			Point val2 = new Point(0.0, ((Rect)(ref viewportRect)).Top);
			viewportRect = ViewportRect;
			double num = Math.Max(0.0, ((Rect)(ref viewportRect)).Left);
			viewportRect = ViewportRect;
			Rect rectangle2 = default(Rect);
			((Rect)(ref rectangle2))._002Ector(val2, new Size(num, ((Rect)(ref viewportRect)).Height));
			viewportRect = ViewportRect;
			double right = ((Rect)(ref viewportRect)).Right;
			viewportRect = ViewportRect;
			Point val3 = new Point(right, ((Rect)(ref viewportRect)).Top);
			renderSize = base.RenderSize;
			double width2 = ((Size)(ref renderSize)).Width;
			viewportRect = ViewportRect;
			double num2 = Math.Max(0.0, width2 - ((Rect)(ref viewportRect)).Right);
			viewportRect = ViewportRect;
			Rect rectangle3 = default(Rect);
			((Rect)(ref rectangle3))._002Ector(val3, new Size(num2, ((Rect)(ref viewportRect)).Height));
			viewportRect = ViewportRect;
			Point val4 = new Point(0.0, ((Rect)(ref viewportRect)).Bottom);
			renderSize = base.RenderSize;
			double width3 = ((Size)(ref renderSize)).Width;
			renderSize = base.RenderSize;
			double height = ((Size)(ref renderSize)).Height;
			viewportRect = ViewportRect;
			Rect rectangle4 = default(Rect);
			((Rect)(ref rectangle4))._002Ector(val4, new Size(width3, Math.Max(0.0, height - ((Rect)(ref viewportRect)).Bottom)));
			dc.DrawRectangle(ShadowBrush, null, rectangle);
			dc.DrawRectangle(ShadowBrush, null, rectangle2);
			dc.DrawRectangle(ShadowBrush, null, rectangle3);
			dc.DrawRectangle(ShadowBrush, null, rectangle4);
			dc.DrawRectangle(ViewportBrush, ViewportPen, ViewportRect);
		}
		else
		{
			dc.DrawRectangle(ShadowBrush, null, new Rect(base.RenderSize));
		}
	}
}
