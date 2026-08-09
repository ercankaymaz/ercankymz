using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

[TemplatePart(Name = "PART_VerticalScrollBar", Type = typeof(ScrollBar))]
[TemplatePart(Name = "PART_HorizontalScrollBar", Type = typeof(ScrollBar))]
public sealed class Zoombox : ContentControl
{
	private sealed class ViewFinderSelectionConverter : IValueConverter
	{
		private readonly Zoombox _zoombox;

		public ViewFinderSelectionConverter(Zoombox zoombox)
		{
			_zoombox = zoombox;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			Rect val = (Rect)value;
			if (((Rect)(ref val)).IsEmpty)
			{
				return val;
			}
			double num = _zoombox._viewFinderDisplay.Scale * _zoombox._viewboxFactor;
			Rect val2 = default(Rect);
			((Rect)(ref val2))._002Ector(((Rect)(ref val)).Left * num, ((Rect)(ref val)).Top * num, ((Rect)(ref val)).Width * num, ((Rect)(ref val)).Height * num);
			Rect contentBounds = _zoombox._viewFinderDisplay.ContentBounds;
			double left = ((Rect)(ref contentBounds)).Left;
			contentBounds = _zoombox._viewFinderDisplay.ContentBounds;
			((Rect)(ref val2)).Offset(left, ((Rect)(ref contentBounds)).Top);
			return val2;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}

	internal sealed class DragAdorner : Adorner
	{
		public static readonly DependencyProperty BrushProperty = DependencyProperty.Register("Brush", typeof(Brush), typeof(DragAdorner), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent, FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty PenProperty = DependencyProperty.Register("Pen", typeof(Pen), typeof(DragAdorner), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Pen(new SolidColorBrush(Color.FromArgb(127, 63, 63, 63)), 2.0), FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty RectProperty = DependencyProperty.Register("Rect", typeof(Rect), typeof(DragAdorner), (PropertyMetadata)(object)new FrameworkPropertyMetadata(Rect.Empty, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnRectChanged)));

		private Point _cachedPosition;

		private Size _cachedSize;

		public Brush Brush
		{
			get
			{
				return (Brush)((DependencyObject)this).GetValue(BrushProperty);
			}
			set
			{
				((DependencyObject)this).SetValue(BrushProperty, (object)value);
			}
		}

		public Pen Pen
		{
			get
			{
				return (Pen)((DependencyObject)this).GetValue(PenProperty);
			}
			set
			{
				((DependencyObject)this).SetValue(PenProperty, (object)value);
			}
		}

		public Rect Rect
		{
			get
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				return (Rect)((DependencyObject)this).GetValue(RectProperty);
			}
			set
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				((DependencyObject)this).SetValue(RectProperty, (object)value);
			}
		}

		public Point LastPosition => _cachedPosition;

		public Size LastSize => _cachedSize;

		public DragAdorner(UIElement adornedElement)
			: base(adornedElement)
		{
			base.ClipToBounds = true;
		}

		private static void OnRectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			DragAdorner dragAdorner = (DragAdorner)(object)d;
			Rect val = (Rect)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			if (!((Rect)(ref val)).IsEmpty)
			{
				Rect val2 = (Rect)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
				dragAdorner._cachedPosition = ((Rect)(ref val2)).TopLeft;
				val2 = (Rect)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
				dragAdorner._cachedSize = ((Rect)(ref val2)).Size;
			}
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			drawingContext.DrawRectangle(Brush, Pen, Rect);
		}
	}

	private enum CacheBits
	{
		IsUpdatingView = 1,
		IsUpdatingViewport = 2,
		IsDraggingViewport = 4,
		IsResizingViewport = 8,
		IsMonitoringInput = 0x10,
		IsContentWrapped = 0x20,
		HasArrangedContentPresenter = 0x40,
		HasRenderedFirstView = 0x80,
		RefocusViewOnFirstRender = 0x100,
		HasUIPermission = 0x200
	}

	private enum ResizeEdge
	{
		None,
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight,
		Left,
		Top,
		Right,
		Bottom
	}

	private const string PART_VerticalScrollBar = "PART_VerticalScrollBar";

	private const string PART_HorizontalScrollBar = "PART_HorizontalScrollBar";

	private bool _isUpdatingVisualTree;

	private bool _isUsingDefaultViewFinder;

	public static readonly DependencyProperty AnimationAccelerationRatioProperty;

	public static readonly DependencyProperty AnimationDecelerationRatioProperty;

	public static readonly DependencyProperty AnimationDurationProperty;

	private static readonly DependencyPropertyKey AreDragModifiersActivePropertyKey;

	public static readonly DependencyProperty AreDragModifiersActiveProperty;

	private static readonly DependencyPropertyKey AreRelativeZoomModifiersActivePropertyKey;

	public static readonly DependencyProperty AreRelativeZoomModifiersActiveProperty;

	private static readonly DependencyPropertyKey AreZoomModifiersActivePropertyKey;

	public static readonly DependencyProperty AreZoomModifiersActiveProperty;

	private static readonly DependencyPropertyKey AreZoomToSelectionModifiersActivePropertyKey;

	public static readonly DependencyProperty AreZoomToSelectionModifiersActiveProperty;

	public static readonly DependencyProperty AutoWrapContentWithViewboxProperty;

	private UIElement _trueContent;

	private static readonly DependencyPropertyKey CurrentViewPropertyKey;

	public static readonly DependencyProperty CurrentViewProperty;

	private static readonly DependencyPropertyKey CurrentViewIndexPropertyKey;

	public static readonly DependencyProperty CurrentViewIndexProperty;

	public static readonly DependencyProperty DragModifiersProperty;

	public static readonly DependencyProperty DragOnPreviewProperty;

	private static readonly DependencyPropertyKey EffectiveViewStackModePropertyKey;

	public static readonly DependencyProperty EffectiveViewStackModeProperty;

	private static readonly DependencyPropertyKey HasBackStackPropertyKey;

	public static readonly DependencyProperty HasBackStackProperty;

	private static readonly DependencyPropertyKey HasForwardStackPropertyKey;

	public static readonly DependencyProperty HasForwardStackProperty;

	public static readonly DependencyProperty IsAnimatedProperty;

	private static readonly DependencyPropertyKey IsDraggingContentPropertyKey;

	public static readonly DependencyProperty IsDraggingContentProperty;

	private static readonly DependencyPropertyKey IsSelectingRegionPropertyKey;

	public static readonly DependencyProperty IsSelectingRegionProperty;

	public static readonly DependencyProperty IsUsingScrollBarsProperty;

	public static readonly DependencyProperty MaxScaleProperty;

	public static readonly DependencyProperty MinScaleProperty;

	public static readonly DependencyProperty NavigateOnPreviewProperty;

	public static readonly DependencyProperty PanDistanceProperty;

	public static readonly DependencyProperty PositionProperty;

	public static readonly DependencyProperty RelativeZoomModifiersProperty;

	public static readonly DependencyProperty ScaleProperty;

	private static readonly DependencyPropertyKey ViewFinderPropertyKey;

	public static readonly DependencyProperty ViewFinderProperty;

	public static readonly DependencyProperty ViewFinderVisibilityProperty;

	private static readonly DependencyPropertyKey ViewportPropertyKey;

	public static readonly DependencyProperty ViewportProperty;

	private static readonly DependencyPropertyKey ViewStackCountPropertyKey;

	public static readonly DependencyProperty ViewStackCountProperty;

	public static readonly DependencyProperty ViewStackIndexProperty;

	public static readonly DependencyProperty ViewStackModeProperty;

	public static readonly DependencyProperty ViewStackSourceProperty;

	public static readonly DependencyProperty ZoomModifiersProperty;

	public static readonly DependencyProperty ZoomOnPreviewProperty;

	public static readonly DependencyProperty ZoomOriginProperty;

	public static readonly DependencyProperty ZoomPercentageProperty;

	public static readonly DependencyProperty ZoomOnProperty;

	public static readonly DependencyProperty ZoomToSelectionModifiersProperty;

	public static readonly DependencyProperty KeepContentInBoundsProperty;

	public static readonly RoutedEvent AnimationBeginningEvent;

	public static readonly RoutedEvent AnimationCompletedEvent;

	public static readonly RoutedEvent CurrentViewChangedEvent;

	public static readonly RoutedEvent ViewStackIndexChangedEvent;

	public static RoutedUICommand Back;

	public static RoutedUICommand Center;

	public static RoutedUICommand Fill;

	public static RoutedUICommand Fit;

	public static RoutedUICommand Forward;

	public static RoutedUICommand Home;

	public static RoutedUICommand PanDown;

	public static RoutedUICommand PanLeft;

	public static RoutedUICommand PanRight;

	public static RoutedUICommand PanUp;

	public static RoutedUICommand Refocus;

	public static RoutedUICommand ZoomIn;

	public static RoutedUICommand ZoomOut;

	private static int MOUSE_WHEEL_DELTA;

	private ContentPresenter _contentPresenter;

	private ScrollBar _verticalScrollBar;

	private ScrollBar _horizontalScrollBar;

	private UIElement _content;

	private DragAdorner _dragAdorner;

	private ZoomboxViewStack _viewStack;

	private ZoomboxViewFinderDisplay _viewFinderDisplay;

	private Rect _resizeViewportBounds = Rect.Empty;

	private Point _resizeAnchorPoint = new Point(0.0, 0.0);

	private Point _resizeDraggingPoint = new Point(0.0, 0.0);

	private Point _originPoint = new Point(0.0, 0.0);

	private double _viewboxFactor = 1.0;

	private double _relativeScale = 1.0;

	private Point _relativePosition;

	private Point _basePosition;

	private DateTime _lastStackAddition;

	private int _lastViewIndex = -1;

	private BitVector32 _cacheBits = new BitVector32(0);

	public double AnimationAccelerationRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AnimationAccelerationRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnimationAccelerationRatioProperty, (object)value);
		}
	}

	public double AnimationDecelerationRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AnimationDecelerationRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnimationDecelerationRatioProperty, (object)value);
		}
	}

	public Duration AnimationDuration
	{
		get
		{
			return (Duration)((DependencyObject)this).GetValue(AnimationDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnimationDurationProperty, (object)value);
		}
	}

	public bool AreDragModifiersActive => (bool)((DependencyObject)this).GetValue(AreDragModifiersActiveProperty);

	public bool AreRelativeZoomModifiersActive => (bool)((DependencyObject)this).GetValue(AreRelativeZoomModifiersActiveProperty);

	public bool AreZoomModifiersActive => (bool)((DependencyObject)this).GetValue(AreZoomModifiersActiveProperty);

	public bool AreZoomToSelectionModifiersActive => (bool)((DependencyObject)this).GetValue(AreZoomToSelectionModifiersActiveProperty);

	public bool AutoWrapContentWithViewbox
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoWrapContentWithViewboxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoWrapContentWithViewboxProperty, (object)value);
		}
	}

	public ZoomboxView CurrentView => (ZoomboxView)((DependencyObject)this).GetValue(CurrentViewProperty);

	public int CurrentViewIndex => (int)((DependencyObject)this).GetValue(CurrentViewIndexProperty);

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection DragModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(DragModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragModifiersProperty, (object)value);
		}
	}

	public bool DragOnPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DragOnPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragOnPreviewProperty, (object)value);
		}
	}

	public ZoomboxViewStackMode EffectiveViewStackMode => (ZoomboxViewStackMode)((DependencyObject)this).GetValue(EffectiveViewStackModeProperty);

	public bool HasBackStack => (bool)((DependencyObject)this).GetValue(HasBackStackProperty);

	public bool HasForwardStack => (bool)((DependencyObject)this).GetValue(HasForwardStackProperty);

	public bool IsAnimated
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsAnimatedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsAnimatedProperty, (object)value);
		}
	}

	public bool IsDraggingContent => (bool)((DependencyObject)this).GetValue(IsDraggingContentProperty);

	public bool IsSelectingRegion => (bool)((DependencyObject)this).GetValue(IsSelectingRegionProperty);

	public bool IsUsingScrollBars
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsUsingScrollBarsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsUsingScrollBarsProperty, (object)value);
		}
	}

	public double MaxScale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxScaleProperty, (object)value);
		}
	}

	public double MinScale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinScaleProperty, (object)value);
		}
	}

	public bool NavigateOnPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(NavigateOnPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NavigateOnPreviewProperty, (object)value);
		}
	}

	public double PanDistance
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PanDistanceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PanDistanceProperty, (object)value);
		}
	}

	public Point Position
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Point)((DependencyObject)this).GetValue(PositionProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(PositionProperty, (object)value);
		}
	}

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection RelativeZoomModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(RelativeZoomModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RelativeZoomModifiersProperty, (object)value);
		}
	}

	public double Scale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScaleProperty, (object)value);
		}
	}

	public FrameworkElement ViewFinder
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(ViewFinderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewFinderPropertyKey, (object)value);
		}
	}

	public Rect Viewport => (Rect)((DependencyObject)this).GetValue(ViewportProperty);

	public int ViewStackCount => (int)((DependencyObject)this).GetValue(ViewStackCountProperty);

	public int ViewStackIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ViewStackIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewStackIndexProperty, (object)value);
		}
	}

	public ZoomboxViewStackMode ViewStackMode
	{
		get
		{
			return (ZoomboxViewStackMode)((DependencyObject)this).GetValue(ViewStackModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewStackModeProperty, (object)value);
		}
	}

	[Bindable(true)]
	public IEnumerable ViewStackSource
	{
		get
		{
			if (_viewStack != null)
			{
				return ViewStack.Source;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				((DependencyObject)this).ClearValue(ViewStackSourceProperty);
			}
			else
			{
				((DependencyObject)this).SetValue(ViewStackSourceProperty, (object)value);
			}
		}
	}

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection ZoomModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(ZoomModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomModifiersProperty, (object)value);
		}
	}

	public bool ZoomOnPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ZoomOnPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomOnPreviewProperty, (object)value);
		}
	}

	public Point ZoomOrigin
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Point)((DependencyObject)this).GetValue(ZoomOriginProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(ZoomOriginProperty, (object)value);
		}
	}

	public double ZoomPercentage
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomPercentageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomPercentageProperty, (object)value);
		}
	}

	public ZoomboxZoomOn ZoomOn
	{
		get
		{
			return (ZoomboxZoomOn)((DependencyObject)this).GetValue(ZoomOnProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomOnProperty, (object)value);
		}
	}

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection ZoomToSelectionModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(ZoomToSelectionModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomToSelectionModifiersProperty, (object)value);
		}
	}

	public bool KeepContentInBounds
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(KeepContentInBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KeepContentInBoundsProperty, (object)value);
		}
	}

	public ZoomboxViewStack ViewStack
	{
		get
		{
			if (_viewStack == null && EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
			{
				_viewStack = new ZoomboxViewStack(this);
			}
			return _viewStack;
		}
	}

	internal bool HasArrangedContentPresenter
	{
		get
		{
			return _cacheBits[64];
		}
		set
		{
			_cacheBits[64] = value;
		}
	}

	internal bool IsUpdatingView
	{
		get
		{
			return _cacheBits[1];
		}
		set
		{
			_cacheBits[1] = value;
		}
	}

	private Vector ContentOffset
	{
		get
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			if (IsContentWrapped || _content == null || !(_content is FrameworkElement))
			{
				return new Vector(0.0, 0.0);
			}
			double num = 0.0;
			double num2 = 0.0;
			Rect contentRect = ContentRect;
			Size size = ((Rect)(ref contentRect)).Size;
			Size renderSize;
			switch ((_content as FrameworkElement).HorizontalAlignment)
			{
			case HorizontalAlignment.Center:
			case HorizontalAlignment.Stretch:
				renderSize = base.RenderSize;
				num = (((Size)(ref renderSize)).Width - ((Size)(ref size)).Width) / 2.0;
				break;
			case HorizontalAlignment.Right:
				renderSize = base.RenderSize;
				num = ((Size)(ref renderSize)).Width - ((Size)(ref size)).Width;
				break;
			}
			switch ((_content as FrameworkElement).VerticalAlignment)
			{
			case VerticalAlignment.Center:
			case VerticalAlignment.Stretch:
				renderSize = base.RenderSize;
				num2 = (((Size)(ref renderSize)).Height - ((Size)(ref size)).Height) / 2.0;
				break;
			case VerticalAlignment.Bottom:
				renderSize = base.RenderSize;
				num2 = ((Size)(ref renderSize)).Height - ((Size)(ref size)).Height;
				break;
			}
			return new Vector(num, num2);
		}
	}

	private Rect ContentRect
	{
		get
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			if (_content != null)
			{
				Size renderSize = _content.RenderSize;
				double num = ((Size)(ref renderSize)).Width / _viewboxFactor;
				renderSize = _content.RenderSize;
				return new Rect(new Size(num, ((Size)(ref renderSize)).Height / _viewboxFactor));
			}
			return Rect.Empty;
		}
	}

	private bool HasRenderedFirstView
	{
		get
		{
			return _cacheBits[128];
		}
		set
		{
			_cacheBits[128] = value;
		}
	}

	private bool HasUIPermission => _cacheBits[512];

	private bool IsContentWrapped
	{
		get
		{
			return _cacheBits[32];
		}
		set
		{
			_cacheBits[32] = value;
		}
	}

	private bool IsDraggingViewport
	{
		get
		{
			return _cacheBits[4];
		}
		set
		{
			_cacheBits[4] = value;
		}
	}

	private bool IsMonitoringInput
	{
		get
		{
			return _cacheBits[16];
		}
		set
		{
			_cacheBits[16] = value;
		}
	}

	private bool IsResizingViewport
	{
		get
		{
			return _cacheBits[8];
		}
		set
		{
			_cacheBits[8] = value;
		}
	}

	private bool IsUpdatingViewport
	{
		get
		{
			return _cacheBits[2];
		}
		set
		{
			_cacheBits[2] = value;
		}
	}

	private bool RefocusViewOnFirstRender
	{
		get
		{
			return _cacheBits[256];
		}
		set
		{
			_cacheBits[256] = value;
		}
	}

	private Rect ViewFinderDisplayRect
	{
		get
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			if (_viewFinderDisplay != null)
			{
				Point val = new Point(0.0, 0.0);
				Size renderSize = _viewFinderDisplay.RenderSize;
				double width = ((Size)(ref renderSize)).Width;
				renderSize = _viewFinderDisplay.RenderSize;
				return new Rect(val, new Point(width, ((Size)(ref renderSize)).Height));
			}
			return Rect.Empty;
		}
	}

	public event RoutedEventHandler AnimationBeginning
	{
		add
		{
			AddHandler(AnimationBeginningEvent, value);
		}
		remove
		{
			RemoveHandler(AnimationBeginningEvent, value);
		}
	}

	public event RoutedEventHandler AnimationCompleted
	{
		add
		{
			AddHandler(AnimationCompletedEvent, value);
		}
		remove
		{
			RemoveHandler(AnimationCompletedEvent, value);
		}
	}

	public event ZoomboxViewChangedEventHandler CurrentViewChanged
	{
		add
		{
			AddHandler(CurrentViewChangedEvent, value);
		}
		remove
		{
			RemoveHandler(CurrentViewChangedEvent, value);
		}
	}

	public event EventHandler<ScrollEventArgs> Scroll;

	public event IndexChangedEventHandler ViewStackIndexChanged
	{
		add
		{
			AddHandler(ViewStackIndexChangedEvent, value);
		}
		remove
		{
			RemoveHandler(ViewStackIndexChangedEvent, value);
		}
	}

	static Zoombox()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Expected O, but got Unknown
		//IL_04b2: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0501: Expected O, but got Unknown
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected O, but got Unknown
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_0614: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Expected O, but got Unknown
		//IL_061e: Expected O, but got Unknown
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Expected O, but got Unknown
		//IL_076c: Expected O, but got Unknown
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Expected O, but got Unknown
		//IL_07b2: Expected O, but got Unknown
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e7: Expected O, but got Unknown
		//IL_0877: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		//IL_0951: Expected O, but got Unknown
		//IL_0bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bff: Expected O, but got Unknown
		//IL_0c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Expected O, but got Unknown
		//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c50: Expected O, but got Unknown
		AnimationAccelerationRatioProperty = DependencyProperty.Register("AnimationAccelerationRatio", typeof(double), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0), new ValidateValueCallback(ValidateAccelerationRatio));
		AnimationDecelerationRatioProperty = DependencyProperty.Register("AnimationDecelerationRatio", typeof(double), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0), new ValidateValueCallback(ValidateDecelerationRatio));
		AnimationDurationProperty = DependencyProperty.Register("AnimationDuration", typeof(Duration), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Duration(TimeSpan.FromMilliseconds(300.0))));
		AreDragModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreDragModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		AreDragModifiersActiveProperty = AreDragModifiersActivePropertyKey.DependencyProperty;
		AreRelativeZoomModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreRelativeZoomModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		AreRelativeZoomModifiersActiveProperty = AreRelativeZoomModifiersActivePropertyKey.DependencyProperty;
		AreZoomModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreZoomModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		AreZoomModifiersActiveProperty = AreZoomModifiersActivePropertyKey.DependencyProperty;
		AreZoomToSelectionModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreZoomToSelectionModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		AreZoomToSelectionModifiersActiveProperty = AreZoomToSelectionModifiersActivePropertyKey.DependencyProperty;
		AutoWrapContentWithViewboxProperty = DependencyProperty.Register("AutoWrapContentWithViewbox", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnAutoWrapContentWithViewboxChanged)));
		CurrentViewPropertyKey = DependencyProperty.RegisterReadOnly("CurrentView", typeof(ZoomboxView), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ZoomboxView.Empty, new PropertyChangedCallback(OnCurrentViewChanged)));
		CurrentViewProperty = CurrentViewPropertyKey.DependencyProperty;
		CurrentViewIndexPropertyKey = DependencyProperty.RegisterReadOnly("CurrentViewIndex", typeof(int), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(-1)));
		CurrentViewIndexProperty = CurrentViewIndexPropertyKey.DependencyProperty;
		DragModifiersProperty = DependencyProperty.Register("DragModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)GetDefaultDragModifiers()));
		DragOnPreviewProperty = DependencyProperty.Register("DragOnPreview", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		EffectiveViewStackModePropertyKey = DependencyProperty.RegisterReadOnly("EffectiveViewStackMode", typeof(ZoomboxViewStackMode), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ZoomboxViewStackMode.Auto));
		EffectiveViewStackModeProperty = EffectiveViewStackModePropertyKey.DependencyProperty;
		HasBackStackPropertyKey = DependencyProperty.RegisterReadOnly("HasBackStack", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		HasBackStackProperty = HasBackStackPropertyKey.DependencyProperty;
		HasForwardStackPropertyKey = DependencyProperty.RegisterReadOnly("HasForwardStack", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		HasForwardStackProperty = HasForwardStackPropertyKey.DependencyProperty;
		IsAnimatedProperty = DependencyProperty.Register("IsAnimated", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(true, null, new CoerceValueCallback(CoerceIsAnimatedValue)));
		IsDraggingContentPropertyKey = DependencyProperty.RegisterReadOnly("IsDraggingContent", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsDraggingContentProperty = IsDraggingContentPropertyKey.DependencyProperty;
		IsSelectingRegionPropertyKey = DependencyProperty.RegisterReadOnly("IsSelectingRegion", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsSelectingRegionProperty = IsSelectingRegionPropertyKey.DependencyProperty;
		IsUsingScrollBarsProperty = DependencyProperty.Register("IsUsingScrollBars", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)null));
		MaxScaleProperty = DependencyProperty.Register("MaxScale", typeof(double), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnMaxScaleChanged), new CoerceValueCallback(CoerceMaxScaleValue)));
		MinScaleProperty = DependencyProperty.Register("MinScale", typeof(double), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(0.01, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnMinScaleChanged), new CoerceValueCallback(CoerceMinScaleValue)));
		NavigateOnPreviewProperty = DependencyProperty.Register("NavigateOnPreview", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		PanDistanceProperty = DependencyProperty.Register("PanDistance", typeof(double), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)5.0));
		PositionProperty = DependencyProperty.Register("Position", typeof(Point), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PointHelper.Empty, new PropertyChangedCallback(OnPositionChanged)));
		RelativeZoomModifiersProperty = DependencyProperty.Register("RelativeZoomModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)GetDefaultRelativeZoomModifiers()));
		ScaleProperty = DependencyProperty.Register("Scale", typeof(double), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(double.NaN, new PropertyChangedCallback(OnScaleChanged), new CoerceValueCallback(CoerceScaleValue)));
		ViewFinderPropertyKey = DependencyProperty.RegisterReadOnly("ViewFinder", typeof(FrameworkElement), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnViewFinderChanged)));
		ViewFinderProperty = ViewFinderPropertyKey.DependencyProperty;
		ViewFinderVisibilityProperty = DependencyProperty.RegisterAttached("ViewFinderVisibility", typeof(Visibility), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Visibility.Visible));
		ViewportPropertyKey = DependencyProperty.RegisterReadOnly("Viewport", typeof(Rect), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Rect.Empty, new PropertyChangedCallback(OnViewportChanged)));
		ViewportProperty = ViewportPropertyKey.DependencyProperty;
		ViewStackCountPropertyKey = DependencyProperty.RegisterReadOnly("ViewStackCount", typeof(int), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(-1), new PropertyChangedCallback(OnViewStackCountChanged)));
		ViewStackCountProperty = ViewStackCountPropertyKey.DependencyProperty;
		ViewStackIndexProperty = DependencyProperty.Register("ViewStackIndex", typeof(int), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(-1, new PropertyChangedCallback(OnViewStackIndexChanged), new CoerceValueCallback(CoerceViewStackIndexValue)));
		ViewStackModeProperty = DependencyProperty.Register("ViewStackMode", typeof(ZoomboxViewStackMode), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(ZoomboxViewStackMode.Default, new PropertyChangedCallback(OnViewStackModeChanged), new CoerceValueCallback(CoerceViewStackModeValue)));
		ViewStackSourceProperty = DependencyProperty.Register("ViewStackSource", typeof(IEnumerable), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnViewStackSourceChanged)));
		ZoomModifiersProperty = DependencyProperty.Register("ZoomModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)GetDefaultZoomModifiers()));
		ZoomOnPreviewProperty = DependencyProperty.Register("ZoomOnPreview", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		ZoomOriginProperty = DependencyProperty.Register("ZoomOrigin", typeof(Point), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Point(0.5, 0.5)));
		ZoomPercentageProperty = DependencyProperty.Register("ZoomPercentage", typeof(double), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)5.0));
		ZoomOnProperty = DependencyProperty.Register("ZoomOn", typeof(ZoomboxZoomOn), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ZoomboxZoomOn.Content));
		ZoomToSelectionModifiersProperty = DependencyProperty.Register("ZoomToSelectionModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)GetDefaultZoomToSelectionModifiers()));
		KeepContentInBoundsProperty = DependencyProperty.Register("KeepContentInBounds", typeof(bool), typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnKeepContentInBoundsChanged)));
		AnimationBeginningEvent = EventManager.RegisterRoutedEvent("AnimationBeginning", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Zoombox));
		AnimationCompletedEvent = EventManager.RegisterRoutedEvent("AnimationCompleted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Zoombox));
		CurrentViewChangedEvent = EventManager.RegisterRoutedEvent("CurrentViewChanged", RoutingStrategy.Bubble, typeof(ZoomboxViewChangedEventHandler), typeof(Zoombox));
		ViewStackIndexChangedEvent = EventManager.RegisterRoutedEvent("ViewStackIndexChanged", RoutingStrategy.Bubble, typeof(IndexChangedEventHandler), typeof(Zoombox));
		Back = new RoutedUICommand("Go Back", "GoBack", typeof(Zoombox));
		Center = new RoutedUICommand("Center Content", "Center", typeof(Zoombox));
		Fill = new RoutedUICommand("Fill Bounds with Content", "FillToBounds", typeof(Zoombox));
		Fit = new RoutedUICommand("Fit Content within Bounds", "FitToBounds", typeof(Zoombox));
		Forward = new RoutedUICommand("Go Forward", "GoForward", typeof(Zoombox));
		Home = new RoutedUICommand("Go Home", "GoHome", typeof(Zoombox));
		PanDown = new RoutedUICommand("Pan Down", "PanDown", typeof(Zoombox));
		PanLeft = new RoutedUICommand("Pan Left", "PanLeft", typeof(Zoombox));
		PanRight = new RoutedUICommand("Pan Right", "PanRight", typeof(Zoombox));
		PanUp = new RoutedUICommand("Pan Up", "PanUp", typeof(Zoombox));
		Refocus = new RoutedUICommand("Refocus View", "Refocus", typeof(Zoombox));
		ZoomIn = new RoutedUICommand("Zoom In", "ZoomIn", typeof(Zoombox));
		ZoomOut = new RoutedUICommand("Zoom Out", "ZoomOut", typeof(Zoombox));
		MOUSE_WHEEL_DELTA = 28;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(Zoombox)));
		UIElement.ClipToBoundsProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		UIElement.FocusableProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		Control.HorizontalContentAlignmentProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)HorizontalAlignment.Center, new PropertyChangedCallback(RefocusView)));
		Control.VerticalContentAlignmentProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)VerticalAlignment.Center, new PropertyChangedCallback(RefocusView)));
		ContentControl.ContentProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new CoerceValueCallback(CoerceContentValue)));
	}

	public Zoombox()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_cacheBits[512] = true;
		}
		catch (SecurityException)
		{
		}
		InitCommands();
		base.LayoutUpdated += OnLayoutUpdated;
		AddHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnSizeChanged), handledEventsToo: true);
		((DependencyObject)this).CoerceValue(ViewStackModeProperty);
		base.Loaded += Zoombox_Loaded;
	}

	private static bool ValidateAccelerationRatio(object value)
	{
		double num = (double)value;
		if (num < 0.0 || num > 1.0 || DoubleHelper.IsNaN(num))
		{
			throw new ArgumentException(ErrorMessages.GetMessage("AnimationAccelerationRatioOOR"));
		}
		return true;
	}

	private static bool ValidateDecelerationRatio(object value)
	{
		double num = (double)value;
		if (num < 0.0 || num > 1.0 || DoubleHelper.IsNaN(num))
		{
			throw new ArgumentException(ErrorMessages.GetMessage("AnimationDecelerationRatioOOR"));
		}
		return true;
	}

	private void SetAreDragModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreDragModifiersActivePropertyKey, (object)value);
	}

	private void SetAreRelativeZoomModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreRelativeZoomModifiersActivePropertyKey, (object)value);
	}

	private void SetAreZoomModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreZoomModifiersActivePropertyKey, (object)value);
	}

	private void SetAreZoomToSelectionModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreZoomToSelectionModifiersActivePropertyKey, (object)value);
	}

	private static void OnAutoWrapContentWithViewboxChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		o.CoerceValue(ContentControl.ContentProperty);
	}

	private static object CoerceContentValue(DependencyObject d, object value)
	{
		return ((Zoombox)(object)d).CoerceContentValue(value);
	}

	private object CoerceContentValue(object value)
	{
		if (value != null && !(value is UIElement) && !(bool)((DependencyObject)this).GetValue(DesignerProperties.IsInDesignModeProperty))
		{
			throw new InvalidContentException(ErrorMessages.GetMessage("ZoomboxContentMustBeUIElement"));
		}
		UIElement content = _content;
		if (value != _trueContent || IsContentWrapped != AutoWrapContentWithViewbox)
		{
			if (IsContentWrapped && _content is Viewbox && _content != _trueContent)
			{
				Viewbox viewbox = (Viewbox)_content;
				BindingOperations.ClearAllBindings((DependencyObject)(object)viewbox);
				if (viewbox.Child is FrameworkElement)
				{
					(viewbox.Child as FrameworkElement).RemoveHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnContentSizeChanged));
				}
				viewbox.Child = null;
				RemoveLogicalChild(viewbox);
			}
			if (_viewFinderDisplay != null && _viewFinderDisplay.VisualBrush != null)
			{
				_viewFinderDisplay.VisualBrush.Visual = null;
				_viewFinderDisplay.VisualBrush = null;
			}
			_content = value as UIElement;
			_trueContent = value as UIElement;
			if (_contentPresenter != null && _contentPresenter.Content != null)
			{
				_contentPresenter.Content = null;
			}
			IsContentWrapped = false;
			if (AutoWrapContentWithViewbox)
			{
				Viewbox viewbox2 = new Viewbox();
				AddLogicalChild(viewbox2);
				viewbox2.Child = value as UIElement;
				_content = viewbox2;
				viewbox2.HorizontalAlignment = HorizontalAlignment.Left;
				viewbox2.VerticalAlignment = VerticalAlignment.Top;
				IsContentWrapped = true;
			}
			if (_content is Viewbox && IsContentWrapped && _trueContent is FrameworkElement)
			{
				(_trueContent as FrameworkElement).AddHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnContentSizeChanged), handledEventsToo: true);
			}
			if (_contentPresenter != null)
			{
				_contentPresenter.Content = _content;
			}
			if (_viewFinderDisplay != null)
			{
				CreateVisualBrushForViewFinder(_content);
			}
			UpdateViewFinderDisplayContentBounds();
		}
		if (content != _content && HasArrangedContentPresenter && HasRenderedFirstView)
		{
			HasArrangedContentPresenter = false;
			HasRenderedFirstView = false;
			RefocusViewOnFirstRender = true;
			_contentPresenter.LayoutUpdated += ContentPresenterFirstArranged;
		}
		return _content;
	}

	private void SetCurrentView(ZoomboxView value)
	{
		((DependencyObject)this).SetValue(CurrentViewPropertyKey, (object)value);
	}

	private static void OnCurrentViewChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)o;
		if (!zoombox.IsUpdatingView)
		{
			zoombox.ZoomTo(zoombox.CurrentView);
		}
		zoombox.RaiseEvent(new ZoomboxViewChangedEventArgs(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ZoomboxView, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ZoomboxView, zoombox._lastViewIndex, zoombox.CurrentViewIndex));
	}

	internal void SetCurrentViewIndex(int value)
	{
		((DependencyObject)this).SetValue(CurrentViewIndexPropertyKey, (object)value);
	}

	private static KeyModifierCollection GetDefaultDragModifiers()
	{
		return new KeyModifierCollection
		{
			KeyModifier.Ctrl,
			KeyModifier.Exact
		};
	}

	private void SetEffectiveViewStackMode(ZoomboxViewStackMode value)
	{
		((DependencyObject)this).SetValue(EffectiveViewStackModePropertyKey, (object)value);
	}

	private static object CoerceIsAnimatedValue(DependencyObject d, object value)
	{
		Zoombox obj = (Zoombox)(object)d;
		bool flag = (bool)value;
		if (!obj.IsInitialized)
		{
			flag = false;
		}
		return flag;
	}

	private void SetIsDraggingContent(bool value)
	{
		((DependencyObject)this).SetValue(IsDraggingContentPropertyKey, (object)value);
	}

	private void SetIsSelectingRegion(bool value)
	{
		((DependencyObject)this).SetValue(IsSelectingRegionPropertyKey, (object)value);
	}

	private static void OnMaxScaleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox obj = (Zoombox)(object)o;
		((DependencyObject)obj).CoerceValue(MinScaleProperty);
		((DependencyObject)obj).CoerceValue(ScaleProperty);
	}

	private static object CoerceMaxScaleValue(DependencyObject d, object value)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		double num = (double)value;
		if (num < zoombox.MinScale)
		{
			num = zoombox.MinScale;
		}
		return num;
	}

	private static void OnMinScaleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox obj = (Zoombox)(object)o;
		((DependencyObject)obj).CoerceValue(MinScaleProperty);
		((DependencyObject)obj).CoerceValue(ScaleProperty);
	}

	private static object CoerceMinScaleValue(DependencyObject d, object value)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		double num = (double)value;
		if (num > zoombox.MaxScale)
		{
			num = zoombox.MaxScale;
		}
		return num;
	}

	private static void OnPositionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		Zoombox zoombox = (Zoombox)(object)o;
		if (!zoombox.IsUpdatingViewport)
		{
			Point val = (Point)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			if (zoombox.Scale > 0.0)
			{
				zoombox.ZoomTo(new Point(0.0 - ((Point)(ref val)).X, 0.0 - ((Point)(ref val)).Y));
			}
		}
	}

	private static KeyModifierCollection GetDefaultRelativeZoomModifiers()
	{
		return new KeyModifierCollection
		{
			KeyModifier.Ctrl,
			KeyModifier.Alt,
			KeyModifier.Exact
		};
	}

	private static void OnScaleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)o;
		if (!zoombox.IsUpdatingView)
		{
			double scale = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			zoombox.ZoomTo(scale);
		}
	}

	private static object CoerceScaleValue(DependencyObject d, object value)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		double num = (double)value;
		if (num < zoombox.MinScale)
		{
			num = zoombox.MinScale;
		}
		if (num > zoombox.MaxScale)
		{
			num = zoombox.MaxScale;
		}
		return num;
	}

	private static void OnViewFinderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnViewFinderChanged(e);
	}

	private void OnViewFinderChanged(DependencyPropertyChangedEventArgs e)
	{
		AttachToVisualTree();
		_isUsingDefaultViewFinder = false;
	}

	public static Visibility GetViewFinderVisibility(DependencyObject d)
	{
		return (Visibility)d.GetValue(ViewFinderVisibilityProperty);
	}

	public static void SetViewFinderVisibility(DependencyObject d, Visibility value)
	{
		d.SetValue(ViewFinderVisibilityProperty, (object)value);
	}

	private static void OnViewportChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		Zoombox zoombox = (Zoombox)(object)o;
		Rect viewport = zoombox.Viewport;
		double num = (0.0 - ((Rect)(ref viewport)).Left) * zoombox.Scale / zoombox._viewboxFactor;
		viewport = zoombox.Viewport;
		zoombox.Position = new Point(num, (0.0 - ((Rect)(ref viewport)).Top) * zoombox.Scale / zoombox._viewboxFactor);
	}

	internal void SetViewStackCount(int value)
	{
		((DependencyObject)this).SetValue(ViewStackCountPropertyKey, (object)value);
	}

	private static void OnViewStackCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnViewStackCountChanged(e);
	}

	private void OnViewStackCountChanged(DependencyPropertyChangedEventArgs e)
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
		{
			UpdateStackProperties();
		}
	}

	private static void OnViewStackIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnViewStackIndexChanged(e);
	}

	private void OnViewStackIndexChanged(DependencyPropertyChangedEventArgs e)
	{
		if (EffectiveViewStackMode == ZoomboxViewStackMode.Disabled)
		{
			return;
		}
		if (!IsUpdatingView)
		{
			int viewStackIndex = ViewStackIndex;
			if (viewStackIndex >= 0 && viewStackIndex < ViewStack.Count)
			{
				UpdateView(ViewStack[viewStackIndex], allowAnimation: true, allowStackAddition: false, viewStackIndex);
			}
		}
		UpdateStackProperties();
		RaiseEvent(new IndexChangedEventArgs(ViewStackIndexChangedEvent, (int)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue));
	}

	private static object CoerceViewStackIndexValue(DependencyObject d, object value)
	{
		if ((d as Zoombox).EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
		{
			return value;
		}
		return -1;
	}

	private static void OnViewStackModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnViewStackModeChanged(e);
	}

	private void OnViewStackModeChanged(DependencyPropertyChangedEventArgs e)
	{
		if ((ZoomboxViewStackMode)((DependencyPropertyChangedEventArgs)(ref e)).NewValue == ZoomboxViewStackMode.Disabled && _viewStack != null)
		{
			_viewStack.ClearViewStackSource();
			_viewStack = null;
		}
	}

	private static object CoerceViewStackModeValue(DependencyObject d, object value)
	{
		Zoombox zoombox = d as Zoombox;
		ZoomboxViewStackMode zoomboxViewStackMode = (ZoomboxViewStackMode)value;
		if (zoombox.EffectiveViewStackMode == ZoomboxViewStackMode.Disabled)
		{
			zoombox.SetEffectiveViewStackMode(zoomboxViewStackMode);
		}
		if (zoomboxViewStackMode != ZoomboxViewStackMode.Disabled)
		{
			if (zoomboxViewStackMode == ZoomboxViewStackMode.Default)
			{
				zoomboxViewStackMode = (zoombox.ViewStack.AreViewsFromSource ? ZoomboxViewStackMode.Manual : ZoomboxViewStackMode.Auto);
			}
			if (zoombox.ViewStack.AreViewsFromSource && zoomboxViewStackMode != ZoomboxViewStackMode.Manual)
			{
				throw new InvalidOperationException(ErrorMessages.GetMessage("ViewModeInvalidForSource"));
			}
		}
		zoombox.SetEffectiveViewStackMode(zoomboxViewStackMode);
		return value;
	}

	private static void OnViewStackSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		_ = (IEnumerable)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		IEnumerable viewStackSource = (IEnumerable)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue == null && !BindingOperations.IsDataBound(d, ViewStackSourceProperty))
		{
			if (zoombox.ViewStack != null)
			{
				zoombox.ViewStack.ClearViewStackSource();
			}
		}
		else
		{
			zoombox.ViewStack.SetViewStackSource(viewStackSource);
		}
		((DependencyObject)zoombox).CoerceValue(ViewStackModeProperty);
	}

	private static KeyModifierCollection GetDefaultZoomModifiers()
	{
		return new KeyModifierCollection
		{
			KeyModifier.Shift,
			KeyModifier.Exact
		};
	}

	private static KeyModifierCollection GetDefaultZoomToSelectionModifiers()
	{
		return new KeyModifierCollection
		{
			KeyModifier.Alt,
			KeyModifier.Exact
		};
	}

	private static void OnKeepContentInBoundsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnKeepContentInBoundsChanged(e);
	}

	private void OnKeepContentInBoundsChanged(DependencyPropertyChangedEventArgs e)
	{
		bool isAnimated = IsAnimated;
		IsAnimated = false;
		try
		{
			UpdateView(CurrentView, allowAnimation: false, allowStackAddition: false, ViewStackIndex);
		}
		finally
		{
			IsAnimated = isAnimated;
		}
	}

	private void CanGoBack(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex > 0;
	}

	private void GoBack(object sender, ExecutedRoutedEventArgs e)
	{
		GoBack();
	}

	private void CenterContent(object sender, ExecutedRoutedEventArgs e)
	{
		CenterContent();
	}

	private void FillToBounds(object sender, ExecutedRoutedEventArgs e)
	{
		FillToBounds();
	}

	private void FitToBounds(object sender, ExecutedRoutedEventArgs e)
	{
		FitToBounds();
	}

	private void CanGoForward(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex < ViewStack.Count - 1;
	}

	private void GoForward(object sender, ExecutedRoutedEventArgs e)
	{
		GoForward();
	}

	private void CanGoHome(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStack.Count > 0 && ViewStackIndex != 0;
	}

	private void GoHome(object sender, ExecutedRoutedEventArgs e)
	{
		GoHome();
	}

	private void PanDownExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(((Point)(ref _basePosition)).X, ((Point)(ref _basePosition)).Y + PanDistance);
	}

	private void PanLeftExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(((Point)(ref _basePosition)).X - PanDistance, ((Point)(ref _basePosition)).Y);
	}

	private void PanRightExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(((Point)(ref _basePosition)).X + PanDistance, ((Point)(ref _basePosition)).Y);
	}

	private void PanUpExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(((Point)(ref _basePosition)).X, ((Point)(ref _basePosition)).Y - PanDistance);
	}

	private void CanRefocusView(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode == ZoomboxViewStackMode.Manual && ViewStackIndex >= 0 && ViewStackIndex < ViewStack.Count && CurrentView != ViewStack[ViewStackIndex];
	}

	private void RefocusView(object sender, ExecutedRoutedEventArgs e)
	{
		RefocusView();
	}

	private void ZoomInExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		Zoom(ZoomPercentage / 100.0);
	}

	private void ZoomOutExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		Zoom((0.0 - ZoomPercentage) / 100.0);
	}

	public void CenterContent()
	{
		if (_content != null)
		{
			SetScrollBars();
			ZoomTo(ZoomboxView.Center);
		}
	}

	public void FillToBounds()
	{
		if (_content != null)
		{
			SetScrollBars();
			ZoomTo(ZoomboxView.Fill);
		}
	}

	public void FitToBounds()
	{
		if (_content != null)
		{
			SetScrollBars();
			ZoomTo(ZoomboxView.Fit);
		}
	}

	public void GoBack()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex > 0)
		{
			ViewStackIndex--;
		}
	}

	public void GoForward()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex < ViewStack.Count - 1)
		{
			ViewStackIndex++;
		}
	}

	public void GoHome()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex > 0)
		{
			ViewStackIndex = 0;
		}
	}

	public override void OnApplyTemplate()
	{
		AttachToVisualTree();
		base.OnApplyTemplate();
		SetCurrentView(ZoomboxView.Empty);
		GoHome();
	}

	public void RefocusView()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex >= 0 && ViewStackIndex < ViewStack.Count && CurrentView != ViewStack[ViewStackIndex])
		{
			UpdateView(ViewStack[ViewStackIndex], allowAnimation: true, allowStackAddition: false, ViewStackIndex);
		}
	}

	public void Zoom(double percentage)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			Zoom(percentage, GetZoomRelativePoint());
		}
	}

	public void Zoom(double percentage, Point relativeTo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			double scale = Scale * (1.0 + percentage);
			ZoomTo(scale, relativeTo);
		}
	}

	public void ZoomTo(Point position)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			ZoomTo(new ZoomboxView(new Point(0.0 - ((Point)(ref position)).X, 0.0 - ((Point)(ref position)).Y)));
		}
	}

	public void ZoomTo(Rect region)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			UpdateView(new ZoomboxView(region), allowAnimation: true, allowStackAddition: true);
		}
	}

	public void ZoomTo(double scale)
	{
		if (_content != null)
		{
			ZoomTo(scale, allowStackAddition: true);
		}
	}

	public void ZoomTo(double scale, Point relativeTo)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		ZoomTo(scale, relativeTo, restrictRelativePointToContent: true, allowStackAddition: true);
	}

	public void ZoomTo(ZoomboxView view)
	{
		UpdateView(view, allowAnimation: true, allowStackAddition: true);
	}

	internal void UpdateStackProperties()
	{
		((DependencyObject)this).SetValue(HasBackStackPropertyKey, (object)(ViewStackIndex > 0));
		((DependencyObject)this).SetValue(HasForwardStackPropertyKey, (object)(ViewStack.Count > ViewStackIndex + 1));
		CommandManager.InvalidateRequerySuggested();
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			Size result = base.MeasureOverride(constraint);
			_content.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			return result;
		}
		if (double.IsInfinity(((Size)(ref constraint)).Height))
		{
			((Size)(ref constraint)).Height = 0.0;
		}
		if (double.IsInfinity(((Size)(ref constraint)).Width))
		{
			((Size)(ref constraint)).Width = 0.0;
		}
		return constraint;
	}

	protected override void OnContentChanged(object oldContent, object newContent)
	{
		if (oldContent is FrameworkElement)
		{
			(oldContent as FrameworkElement).RemoveHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnContentSizeChanged));
		}
		else
		{
			RemoveHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnContentSizeChanged));
		}
		if (_content is FrameworkElement)
		{
			(_content as FrameworkElement).AddHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnContentSizeChanged), handledEventsToo: true);
		}
		else
		{
			AddHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnContentSizeChanged), handledEventsToo: true);
		}
		if (_viewFinderDisplay != null && _viewFinderDisplay.VisualBrush != null)
		{
			_viewFinderDisplay.VisualBrush.Visual = _content;
		}
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		MonitorInput();
		base.OnGotKeyboardFocus(e);
	}

	protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		MonitorInput();
		base.OnLostKeyboardFocus(e);
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		((DependencyObject)this).CoerceValue(IsAnimatedProperty);
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		if (HasArrangedContentPresenter && !HasRenderedFirstView)
		{
			HasRenderedFirstView = true;
			if (RefocusViewOnFirstRender)
			{
				RefocusViewOnFirstRender = false;
				bool isAnimated = IsAnimated;
				IsAnimated = false;
				try
				{
					RefocusView();
				}
				finally
				{
					IsAnimated = isAnimated;
				}
			}
		}
		base.OnRender(drawingContext);
	}

	private static void RefocusView(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = o as Zoombox;
		zoombox.UpdateView(zoombox.CurrentView, allowAnimation: true, allowStackAddition: false, zoombox.ViewStackIndex);
	}

	private void AttachToVisualTree()
	{
		if (_isUpdatingVisualTree)
		{
			return;
		}
		_isUpdatingVisualTree = true;
		DetachFromVisualTree();
		_dragAdorner = new DragAdorner(this);
		if (base.Template.Resources.Contains("SelectionBrush"))
		{
			_dragAdorner.Brush = base.Template.Resources["SelectionBrush"] as Brush;
		}
		if (base.Template.Resources.Contains("SelectionPen"))
		{
			_dragAdorner.Pen = base.Template.Resources["SelectionPen"] as Pen;
		}
		if (base.Template.Resources.Contains("InputBindings") && base.Template.Resources["InputBindings"] is InputBindingCollection collection)
		{
			base.InputBindings.AddRange(collection);
		}
		_contentPresenter = VisualTreeHelperEx.FindDescendantByType(this, typeof(ContentPresenter)) as ContentPresenter;
		if (_contentPresenter == null)
		{
			throw new InvalidTemplateException(ErrorMessages.GetMessage("ZoomboxTemplateNeedsContent"));
		}
		_verticalScrollBar = GetTemplateChild("PART_VerticalScrollBar") as ScrollBar;
		if (_verticalScrollBar == null)
		{
			throw new InvalidTemplateException(ErrorMessages.GetMessage("Zoombox vertical scrollBar not found."));
		}
		_verticalScrollBar.Scroll += VerticalScrollBar_Scroll;
		_horizontalScrollBar = GetTemplateChild("PART_HorizontalScrollBar") as ScrollBar;
		if (_horizontalScrollBar == null)
		{
			throw new InvalidTemplateException(ErrorMessages.GetMessage("Zoombox horizontal scrollBar not found."));
		}
		_horizontalScrollBar.Scroll += HorizontalScrollBar_Scroll;
		AdornerLayer adornerLayer = null;
		if (VisualTreeHelperEx.FindDescendantByType(this, typeof(AdornerDecorator)) is AdornerDecorator adornerDecorator)
		{
			adornerLayer = adornerDecorator.AdornerLayer;
		}
		else
		{
			try
			{
				adornerLayer = AdornerLayer.GetAdornerLayer(this);
			}
			catch (Exception)
			{
			}
		}
		adornerLayer?.Add(_dragAdorner);
		VisualTreeHelperEx.FindDescendantWithPropertyValue(this, ButtonBase.IsPressedProperty, true);
		if (((DependencyObject)this).GetValue(ViewFinderPropertyKey.DependencyProperty) == null || _isUsingDefaultViewFinder)
		{
			((DependencyObject)this).SetValue(ViewFinderPropertyKey, (object)(base.Template.FindName("ViewFinder", this) as FrameworkElement));
			SetViewFinderVisibility((DependencyObject)(object)this, Visibility.Collapsed);
			_isUsingDefaultViewFinder = true;
		}
		else
		{
			SetViewFinderVisibility((DependencyObject)(object)this, Visibility.Hidden);
		}
		if (ViewFinder != null)
		{
			_viewFinderDisplay = VisualTreeHelperEx.FindDescendantByType(ViewFinder, typeof(ZoomboxViewFinderDisplay)) as ZoomboxViewFinderDisplay;
		}
		if (ViewFinder != null && _viewFinderDisplay == null)
		{
			throw new InvalidTemplateException(ErrorMessages.GetMessage("ZoomboxHasViewFinderButNotDisplay"));
		}
		if (_viewFinderDisplay != null)
		{
			CreateVisualBrushForViewFinder(_content);
			_viewFinderDisplay.MouseMove += ViewFinderDisplayMouseMove;
			_viewFinderDisplay.MouseLeftButtonDown += ViewFinderDisplayBeginCapture;
			_viewFinderDisplay.MouseLeftButtonUp += ViewFinderDisplayEndCapture;
			Binding binding = new Binding("Viewport");
			binding.Mode = BindingMode.OneWay;
			binding.Converter = new ViewFinderSelectionConverter(this);
			binding.Source = this;
			_viewFinderDisplay.SetBinding(ZoomboxViewFinderDisplay.ViewportRectProperty, binding);
		}
		UpdateViewFinderDisplayContentBounds();
		_contentPresenter.LayoutUpdated += ContentPresenterFirstArranged;
		_isUpdatingVisualTree = false;
	}

	private void CreateVisualBrushForViewFinder(Visual visual)
	{
		_viewFinderDisplay.VisualBrush = new VisualBrush(visual);
		_viewFinderDisplay.VisualBrush.Stretch = Stretch.Uniform;
		_viewFinderDisplay.VisualBrush.AlignmentX = AlignmentX.Left;
		_viewFinderDisplay.VisualBrush.AlignmentY = AlignmentY.Top;
	}

	private void ContentPresenterFirstArranged(object sender, EventArgs e)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		_contentPresenter.LayoutUpdated -= ContentPresenterFirstArranged;
		HasArrangedContentPresenter = true;
		InvalidateVisual();
		bool isAnimated = IsAnimated;
		IsAnimated = false;
		try
		{
			double scale = Scale;
			Point position = Position;
			if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
			{
				bool flag = false;
				if (ViewStack.Count > 0)
				{
					if (ViewStackIndex >= 0)
					{
						if (ViewStackIndex > ViewStack.Count - 1)
						{
							ViewStackIndex = ViewStack.Count - 1;
						}
						else
						{
							UpdateView(ViewStack[ViewStackIndex], allowAnimation: false, allowStackAddition: false, ViewStackIndex);
						}
					}
					else if (EffectiveViewStackMode != ZoomboxViewStackMode.Auto && ViewStackIndex < 0)
					{
						ViewStackIndex = 0;
					}
					if (ViewStackIndex >= 0)
					{
						flag = true;
						if (!DoubleHelper.IsNaN(scale) || !PointHelper.IsEmpty(position))
						{
							UpdateView(new ZoomboxView(scale, position), allowAnimation: false, allowStackAddition: false);
						}
					}
				}
				if (!flag)
				{
					ZoomboxView view = new ZoomboxView(DoubleHelper.IsNaN(Scale) ? 1.0 : Scale, (Point)(PointHelper.IsEmpty(position) ? default(Point) : position));
					if (EffectiveViewStackMode == ZoomboxViewStackMode.Auto)
					{
						ViewStack.PushView(view);
						ViewStackIndex = 0;
					}
					else
					{
						UpdateView(view, allowAnimation: false, allowStackAddition: false);
					}
				}
			}
			else
			{
				ZoomboxView view2 = new ZoomboxView(DoubleHelper.IsNaN(Scale) ? 1.0 : Scale, position);
				UpdateView(view2, allowAnimation: false, allowStackAddition: false);
			}
		}
		finally
		{
			IsAnimated = isAnimated;
		}
		ZoomTo(Scale);
		UpdateViewFinderDisplayContentBounds();
	}

	private void DetachFromVisualTree()
	{
		if (_dragAdorner != null && AdornerLayer.GetAdornerLayer(this) != null)
		{
			AdornerLayer.GetAdornerLayer(this).Remove(_dragAdorner);
		}
		base.InputBindings.Clear();
		if (_contentPresenter != null)
		{
			_contentPresenter.LayoutUpdated -= ContentPresenterFirstArranged;
		}
		if (_verticalScrollBar != null)
		{
			_verticalScrollBar.Scroll -= VerticalScrollBar_Scroll;
		}
		if (_horizontalScrollBar != null)
		{
			_horizontalScrollBar.Scroll -= HorizontalScrollBar_Scroll;
		}
		if (_viewFinderDisplay != null)
		{
			_viewFinderDisplay.MouseMove -= ViewFinderDisplayMouseMove;
			_viewFinderDisplay.MouseLeftButtonDown -= ViewFinderDisplayBeginCapture;
			_viewFinderDisplay.MouseLeftButtonUp -= ViewFinderDisplayEndCapture;
			BindingOperations.ClearBinding((DependencyObject)(object)_viewFinderDisplay, ZoomboxViewFinderDisplay.ViewportRectProperty);
			_viewFinderDisplay = null;
		}
		_contentPresenter = null;
	}

	private void Zoombox_Loaded(object sender, RoutedEventArgs e)
	{
		SetScrollBars();
	}

	private void VerticalScrollBar_Scroll(object sender, ScrollEventArgs e)
	{
		double num = 0.0 - (e.NewValue + ((Point)(ref _relativePosition)).Y);
		if (e.ScrollEventType == ScrollEventType.LargeIncrement)
		{
			num = 0.0 - _verticalScrollBar.ViewportSize;
		}
		else if (e.ScrollEventType == ScrollEventType.LargeDecrement)
		{
			num = _verticalScrollBar.ViewportSize;
		}
		OnDrag(new DragDeltaEventArgs(0.0, num / Scale), end: false);
		this.Scroll?.Invoke(this, e);
	}

	private void HorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
	{
		double num = 0.0 - (e.NewValue + ((Point)(ref _relativePosition)).X);
		if (e.ScrollEventType == ScrollEventType.LargeIncrement)
		{
			num = 0.0 - _horizontalScrollBar.ViewportSize;
		}
		else if (e.ScrollEventType == ScrollEventType.LargeDecrement)
		{
			num = _horizontalScrollBar.ViewportSize;
		}
		OnDrag(new DragDeltaEventArgs(num / Scale, 0.0), end: false);
		this.Scroll?.Invoke(this, e);
	}

	private void DragDisplayViewport(DragDeltaEventArgs e, bool end)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		double scale = _viewFinderDisplay.Scale;
		Rect viewportRect = _viewFinderDisplay.ViewportRect;
		Rect contentBounds = _viewFinderDisplay.ContentBounds;
		if (!((Rect)(ref viewportRect)).Contains(contentBounds))
		{
			double num = e.HorizontalChange;
			double num2 = e.VerticalChange;
			if (((Rect)(ref viewportRect)).Left < ((Rect)(ref contentBounds)).Left)
			{
				num = Math.Max(0.0, num);
			}
			else if (((Rect)(ref viewportRect)).Left + num < ((Rect)(ref contentBounds)).Left)
			{
				num = ((Rect)(ref contentBounds)).Left - ((Rect)(ref viewportRect)).Left;
			}
			if (((Rect)(ref viewportRect)).Right > ((Rect)(ref contentBounds)).Right)
			{
				num = Math.Min(0.0, num);
			}
			else if (((Rect)(ref viewportRect)).Right + num > ((Rect)(ref contentBounds)).Left + ((Rect)(ref contentBounds)).Width)
			{
				num = ((Rect)(ref contentBounds)).Left + ((Rect)(ref contentBounds)).Width - ((Rect)(ref viewportRect)).Right;
			}
			if (((Rect)(ref viewportRect)).Top < ((Rect)(ref contentBounds)).Top)
			{
				num2 = Math.Max(0.0, num2);
			}
			else if (((Rect)(ref viewportRect)).Top + num2 < ((Rect)(ref contentBounds)).Top)
			{
				num2 = ((Rect)(ref contentBounds)).Top - ((Rect)(ref viewportRect)).Top;
			}
			if (((Rect)(ref viewportRect)).Bottom > ((Rect)(ref contentBounds)).Bottom)
			{
				num2 = Math.Min(0.0, num2);
			}
			else if (((Rect)(ref viewportRect)).Bottom + num2 > ((Rect)(ref contentBounds)).Top + ((Rect)(ref contentBounds)).Height)
			{
				num2 = ((Rect)(ref contentBounds)).Top + ((Rect)(ref contentBounds)).Height - ((Rect)(ref viewportRect)).Bottom;
			}
			OnDrag(new DragDeltaEventArgs((0.0 - num) / scale / _viewboxFactor, (0.0 - num2) / scale / _viewboxFactor), end);
			_originPoint += new Vector(num, num2);
		}
	}

	private void InitCommands()
	{
		CommandBinding commandBinding = new CommandBinding(Back, GoBack, CanGoBack);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(Center, CenterContent);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(Fill, FillToBounds);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(Fit, FitToBounds);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(Forward, GoForward, CanGoForward);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(Home, GoHome, CanGoHome);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(PanDown, PanDownExecuted);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(PanLeft, PanLeftExecuted);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(PanRight, PanRightExecuted);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(PanUp, PanUpExecuted);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(Refocus, RefocusView, CanRefocusView);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(ZoomIn, ZoomInExecuted);
		base.CommandBindings.Add(commandBinding);
		commandBinding = new CommandBinding(ZoomOut, ZoomOutExecuted);
		base.CommandBindings.Add(commandBinding);
	}

	private void MonitorInput()
	{
		if (HasUIPermission)
		{
			PreProcessInput();
		}
	}

	private void OnContentSizeChanged(object sender, SizeChangedEventArgs e)
	{
		UpdateViewFinderDisplayContentBounds();
		if (HasArrangedContentPresenter)
		{
			if (HasRenderedFirstView)
			{
				SetScrollBars();
				UpdateView(CurrentView, allowAnimation: true, allowStackAddition: false, CurrentViewIndex);
			}
			else
			{
				RefocusViewOnFirstRender = true;
				InvalidateVisual();
			}
		}
	}

	private void OnDrag(DragDeltaEventArgs e, bool end)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		Point relativePosition = _relativePosition;
		double scale = Scale;
		Point position = relativePosition + ContentOffset * scale + new Vector(e.HorizontalChange * scale, e.VerticalChange * scale);
		if (IsUsingScrollBars)
		{
			((Point)(ref position)).X = Math.Max(Math.Min(((Point)(ref position)).X, 0.0), 0.0 - _horizontalScrollBar.Maximum);
			((Point)(ref position)).Y = Math.Max(Math.Min(((Point)(ref position)).Y, 0.0), 0.0 - _verticalScrollBar.Maximum);
		}
		UpdateView(new ZoomboxView(scale, position), allowAnimation: false, end);
	}

	private void OnLayoutUpdated(object sender, EventArgs e)
	{
		UpdateViewport();
	}

	private void OnSelectRegion(DragDeltaEventArgs e, bool end)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		Size val2;
		if (end)
		{
			_dragAdorner.Rect = Rect.Empty;
			if (_trueContent != null)
			{
				Point val = TranslatePoint(_dragAdorner.LastPosition, _trueContent);
				Point lastPosition = _dragAdorner.LastPosition;
				val2 = _dragAdorner.LastSize;
				double width = ((Size)(ref val2)).Width;
				val2 = _dragAdorner.LastSize;
				Rect region = default(Rect);
				((Rect)(ref region))._002Ector(val, TranslatePoint(lastPosition + new Vector(width, ((Size)(ref val2)).Height), _trueContent));
				ZoomTo(region);
			}
		}
		else
		{
			DragAdorner dragAdorner = _dragAdorner;
			Rect val3 = new Rect(_originPoint, new Vector(e.HorizontalChange, e.VerticalChange));
			Point val4 = new Point(0.0, 0.0);
			val2 = base.RenderSize;
			double width2 = ((Size)(ref val2)).Width;
			val2 = base.RenderSize;
			dragAdorner.Rect = Rect.Intersect(val3, new Rect(val4, new Point(width2, ((Size)(ref val2)).Height)));
		}
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs e)
	{
		if (!HasArrangedContentPresenter)
		{
			return;
		}
		SetScrollBars();
		UpdateViewboxFactor();
		bool isAnimated = IsAnimated;
		IsAnimated = false;
		try
		{
			UpdateView(CurrentView, allowAnimation: false, allowStackAddition: false, ViewStackIndex);
		}
		finally
		{
			IsAnimated = isAnimated;
		}
	}

	private void SetScrollBars()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null && _verticalScrollBar != null && _horizontalScrollBar != null)
		{
			Size val = ((_content is Viewbox) ? ((Viewbox)_content).Child.DesiredSize : base.RenderSize);
			_verticalScrollBar.SmallChange = 10.0;
			_verticalScrollBar.LargeChange = 10.0;
			_verticalScrollBar.Minimum = 0.0;
			ScrollBar verticalScrollBar = _verticalScrollBar;
			Size renderSize = base.RenderSize;
			verticalScrollBar.ViewportSize = ((Size)(ref renderSize)).Height;
			_verticalScrollBar.Maximum = ((Size)(ref val)).Height - _verticalScrollBar.ViewportSize;
			_horizontalScrollBar.SmallChange = 10.0;
			_horizontalScrollBar.LargeChange = 10.0;
			_horizontalScrollBar.Minimum = 0.0;
			ScrollBar horizontalScrollBar = _horizontalScrollBar;
			renderSize = base.RenderSize;
			horizontalScrollBar.ViewportSize = ((Size)(ref renderSize)).Width;
			_horizontalScrollBar.Maximum = ((Size)(ref val)).Width - _horizontalScrollBar.ViewportSize;
		}
	}

	private void PreProcessInput()
	{
		if (base.IsMouseOver || base.IsKeyboardFocusWithin)
		{
			if (!IsMonitoringInput)
			{
				IsMonitoringInput = true;
				InputManager.Current.PreNotifyInput += PreProcessInput;
				UpdateKeyModifierTriggerProperties();
			}
		}
		else if (IsMonitoringInput)
		{
			IsMonitoringInput = false;
			InputManager.Current.PreNotifyInput -= PreProcessInput;
			SetAreDragModifiersActive(value: false);
			SetAreRelativeZoomModifiersActive(value: false);
			SetAreZoomModifiersActive(value: false);
			SetAreZoomToSelectionModifiersActive(value: false);
		}
	}

	private void PreProcessInput(object sender, NotifyInputEventArgs e)
	{
		if (e.StagingItem.Input is KeyEventArgs)
		{
			UpdateKeyModifierTriggerProperties();
		}
	}

	private void ProcessMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		if (ZoomToSelectionModifiers.AreActive)
		{
			SetIsDraggingContent(value: false);
			SetIsSelectingRegion(value: true);
		}
		else if (DragModifiers.AreActive)
		{
			SetIsSelectingRegion(value: false);
			SetIsDraggingContent(value: true);
		}
		else
		{
			SetIsSelectingRegion(value: false);
			SetIsDraggingContent(value: false);
		}
		if (IsSelectingRegion || IsDraggingContent)
		{
			_originPoint = e.GetPosition(this);
			_contentPresenter.CaptureMouse();
			e.Handled = true;
			if (IsDraggingContent)
			{
				OnDrag(new DragDeltaEventArgs(0.0, 0.0), end: false);
			}
			else if (IsSelectingRegion)
			{
				OnSelectRegion(new DragDeltaEventArgs(0.0, 0.0), end: false);
			}
		}
	}

	private void ProcessMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (IsDraggingContent || IsSelectingRegion)
		{
			bool isDraggingContent = IsDraggingContent;
			SetIsDraggingContent(value: false);
			SetIsSelectingRegion(value: false);
			_originPoint = default(Point);
			_contentPresenter.ReleaseMouseCapture();
			e.Handled = true;
			if (isDraggingContent)
			{
				OnDrag(new DragDeltaEventArgs(0.0, 0.0), end: true);
			}
			else
			{
				OnSelectRegion(new DragDeltaEventArgs(0.0, 0.0), end: true);
			}
		}
	}

	private void ProcessMouseMove(MouseEventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && (IsDraggingContent || IsSelectingRegion))
		{
			Point position = e.GetPosition(this);
			e.Handled = true;
			if (IsDraggingContent)
			{
				Vector val = (position - _originPoint) / Scale;
				OnDrag(new DragDeltaEventArgs(((Vector)(ref val)).X, ((Vector)(ref val)).Y), end: false);
				_originPoint = position;
			}
			else if (IsSelectingRegion)
			{
				Vector val2 = position - _originPoint;
				OnSelectRegion(new DragDeltaEventArgs(((Vector)(ref val2)).X, ((Vector)(ref val2)).Y), end: false);
			}
		}
	}

	private void ProcessMouseWheelZoom(MouseWheelEventArgs e)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if (_content == null)
		{
			return;
		}
		bool flag = ZoomModifiers.AreActive;
		bool areActive = RelativeZoomModifiers.AreActive;
		if (flag && areActive)
		{
			flag = false;
		}
		if (flag || areActive)
		{
			e.Handled = true;
			double percentage = (double)(e.Delta / MOUSE_WHEEL_DELTA) * ZoomPercentage / 100.0;
			if (areActive)
			{
				Zoom(percentage, Mouse.GetPosition(_content));
			}
			else
			{
				Zoom(percentage);
			}
		}
	}

	private void ProcessNavigationButton(RoutedEventArgs e)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		if (e is MouseButtonEventArgs)
		{
			MouseButtonEventArgs e2 = e as MouseButtonEventArgs;
			if (e2.ChangedButton == MouseButton.XButton1 || e2.ChangedButton == MouseButton.XButton2)
			{
				if (e2.ChangedButton == MouseButton.XButton2)
				{
					GoForward();
				}
				else
				{
					GoBack();
				}
				e2.Handled = true;
			}
		}
		else
		{
			if (!(e is KeyEventArgs))
			{
				return;
			}
			KeyEventArgs e3 = e as KeyEventArgs;
			if ((int)e3.Key == 2 || (int)e3.Key == 122 || (int)e3.Key == 123)
			{
				if ((int)e3.Key == 123)
				{
					GoForward();
				}
				else
				{
					GoBack();
				}
				e3.Handled = true;
			}
		}
	}

	private void ResizeDisplayViewport(DragDeltaEventArgs e, ResizeEdge relativeTo)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		_ = _viewFinderDisplay.ViewportRect;
		double scale = _viewFinderDisplay.Scale;
		double num = Math.Max(((Rect)(ref _resizeViewportBounds)).Left, Math.Min(((Point)(ref _resizeDraggingPoint)).X + e.HorizontalChange, ((Rect)(ref _resizeViewportBounds)).Right));
		double num2 = Math.Max(((Rect)(ref _resizeViewportBounds)).Top, Math.Min(((Point)(ref _resizeDraggingPoint)).Y + e.VerticalChange, ((Rect)(ref _resizeViewportBounds)).Bottom));
		Point val = default(Point);
		((Point)(ref val))._002Ector(((Point)(ref _resizeAnchorPoint)).X / scale, ((Point)(ref _resizeAnchorPoint)).Y / scale);
		Vector val2 = default(Vector);
		((Vector)(ref val2))._002Ector((num - ((Point)(ref _resizeAnchorPoint)).X) / scale / _viewboxFactor, (num2 - ((Point)(ref _resizeAnchorPoint)).Y) / scale / _viewboxFactor);
		Rect val3 = default(Rect);
		((Rect)(ref val3))._002Ector(val, val2);
		((Rect)(ref val3))._002Ector(_content.TranslatePoint(((Rect)(ref val3)).TopLeft, _contentPresenter), _content.TranslatePoint(((Rect)(ref val3)).BottomRight, _contentPresenter));
		Size renderSize = base.RenderSize;
		double num3 = ((Size)(ref renderSize)).Width / ((Rect)(ref val3)).Width;
		renderSize = base.RenderSize;
		double num4 = ((Size)(ref renderSize)).Height / ((Rect)(ref val3)).Height;
		scale = ((num3 < num4) ? num3 : num4);
		ZoomTo(scale, val, restrictRelativePointToContent: false, allowStackAddition: false);
	}

	private void UpdateKeyModifierTriggerProperties()
	{
		SetAreDragModifiersActive(DragModifiers.AreActive);
		SetAreRelativeZoomModifiersActive(RelativeZoomModifiers.AreActive);
		SetAreZoomModifiersActive(ZoomModifiers.AreActive);
		SetAreZoomToSelectionModifiersActive(ZoomToSelectionModifiers.AreActive);
	}

	private void UpdateView(ZoomboxView view, bool allowAnimation, bool allowStackAddition)
	{
		UpdateView(view, allowAnimation, allowStackAddition, -1);
	}

	private void UpdateView(ZoomboxView view, bool allowAnimation, bool allowStackAddition, int stackIndex)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0855: Unknown result type (might be due to invalid IL or missing references)
		//IL_0856: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_0877: Unknown result type (might be due to invalid IL or missing references)
		//IL_087c: Unknown result type (might be due to invalid IL or missing references)
		if (_contentPresenter == null || _content == null || !HasArrangedContentPresenter)
		{
			return;
		}
		if (view.ViewKind == ZoomboxViewKind.Absolute && PointHelper.IsEmpty(view.Position))
		{
			ZoomTo(view.Scale, allowStackAddition);
		}
		else
		{
			if (IsUpdatingView)
			{
				return;
			}
			IsUpdatingView = true;
			try
			{
				double newRelativeScale = _viewboxFactor;
				Point newRelativePosition = default(Point);
				Rect region = Rect.Empty;
				Rect contentRect;
				switch (view.ViewKind)
				{
				case ZoomboxViewKind.Absolute:
				{
					newRelativeScale = (DoubleHelper.IsNaN(view.Scale) ? _relativeScale : view.Scale);
					Point val4;
					if (!PointHelper.IsEmpty(view.Position))
					{
						Point position = view.Position;
						double x = ((Point)(ref position)).X;
						position = view.Position;
						val4 = new Point(x, ((Point)(ref position)).Y) - ContentOffset * newRelativeScale;
					}
					else
					{
						val4 = _relativePosition;
					}
					newRelativePosition = val4;
					break;
				}
				case ZoomboxViewKind.Region:
					region = view.Region;
					break;
				case ZoomboxViewKind.Center:
				{
					UIElement content = _content;
					contentRect = ContentRect;
					Point val = content.TranslatePoint(((Rect)(ref contentRect)).TopLeft, this);
					UIElement content2 = _content;
					contentRect = ContentRect;
					Rect val2 = default(Rect);
					((Rect)(ref val2))._002Ector(val, content2.TranslatePoint(((Rect)(ref contentRect)).BottomRight, this));
					Rect val3 = val2;
					Size renderSize = base.RenderSize;
					double num = (((Size)(ref renderSize)).Width / _viewboxFactor - ((Rect)(ref val2)).Width) / 2.0;
					renderSize = base.RenderSize;
					region = Rect.Inflate(val3, num, (((Size)(ref renderSize)).Height / _viewboxFactor - ((Rect)(ref val2)).Height) / 2.0);
					((Rect)(ref region))._002Ector(TranslatePoint(((Rect)(ref region)).TopLeft, _content), TranslatePoint(((Rect)(ref region)).BottomRight, _content));
					break;
				}
				case ZoomboxViewKind.Fit:
					region = ContentRect;
					break;
				case ZoomboxViewKind.Fill:
					region = CalculateFillRect();
					break;
				}
				if (view.ViewKind != ZoomboxViewKind.Empty)
				{
					if (!((Rect)(ref region)).IsEmpty)
					{
						CalculatePositionAndScale(region, ref newRelativePosition, ref newRelativeScale);
					}
					else if (view != ZoomboxView.Empty)
					{
						if (newRelativeScale > MaxScale)
						{
							newRelativeScale = MaxScale;
						}
						else if (newRelativeScale < MinScale)
						{
							newRelativeScale = MinScale;
						}
					}
					double fromValue = _relativeScale;
					double x2 = ((Point)(ref _relativePosition)).X;
					double y = ((Point)(ref _relativePosition)).Y;
					ScaleTransform scaleTransform = null;
					TranslateTransform translateTransform = null;
					TransformGroup transformGroup = null;
					if (_contentPresenter.RenderTransform != Transform.Identity)
					{
						transformGroup = _contentPresenter.RenderTransform as TransformGroup;
						scaleTransform = transformGroup.Children[0] as ScaleTransform;
						translateTransform = transformGroup.Children[1] as TranslateTransform;
						fromValue = scaleTransform.ScaleX;
						x2 = translateTransform.X;
						y = translateTransform.Y;
					}
					if (KeepContentInBounds)
					{
						contentRect = ContentRect;
						double num2 = ((Rect)(ref contentRect)).Width * newRelativeScale;
						contentRect = ContentRect;
						Rect val5 = default(Rect);
						((Rect)(ref val5))._002Ector(new Size(num2, ((Rect)(ref contentRect)).Height * newRelativeScale));
						Point val6 = default(Point);
						((Point)(ref val6))._002Ector(0.0 - ((Point)(ref newRelativePosition)).X, 0.0 - ((Point)(ref newRelativePosition)).Y);
						Rect val7 = default(Rect);
						((Rect)(ref val7))._002Ector(val6, _contentPresenter.RenderSize);
						if (DoubleHelper.AreVirtuallyEqual(_relativeScale, newRelativeScale))
						{
							if (IsGreaterThanOrClose(((Rect)(ref val5)).Width, ((Rect)(ref val7)).Width))
							{
								if (((Rect)(ref val5)).Right < ((Rect)(ref val7)).Right)
								{
									((Point)(ref newRelativePosition)).X = 0.0 - (((Rect)(ref val5)).Width - ((Rect)(ref val7)).Width);
								}
								if (((Rect)(ref val5)).Left > ((Rect)(ref val7)).Left)
								{
									((Point)(ref newRelativePosition)).X = 0.0;
								}
							}
							else if (IsGreaterThanOrClose(((Rect)(ref val7)).Width, ((Rect)(ref val5)).Width))
							{
								if (((Rect)(ref val7)).Right < ((Rect)(ref val5)).Right)
								{
									((Point)(ref newRelativePosition)).X = ((Rect)(ref val7)).Width - ((Rect)(ref val5)).Width;
								}
								if (((Rect)(ref val7)).Left > ((Rect)(ref val5)).Left)
								{
									((Point)(ref newRelativePosition)).X = 0.0;
								}
							}
							if (IsGreaterThanOrClose(((Rect)(ref val5)).Height, ((Rect)(ref val7)).Height))
							{
								if (((Rect)(ref val5)).Bottom < ((Rect)(ref val7)).Bottom)
								{
									((Point)(ref newRelativePosition)).Y = 0.0 - (((Rect)(ref val5)).Height - ((Rect)(ref val7)).Height);
								}
								if (((Rect)(ref val5)).Top > ((Rect)(ref val7)).Top)
								{
									((Point)(ref newRelativePosition)).Y = 0.0;
								}
							}
							else if (IsGreaterThanOrClose(((Rect)(ref val7)).Height, ((Rect)(ref val5)).Height))
							{
								if (((Rect)(ref val7)).Bottom < ((Rect)(ref val5)).Bottom)
								{
									((Point)(ref newRelativePosition)).Y = ((Rect)(ref val7)).Height - ((Rect)(ref val5)).Height;
								}
								if (((Rect)(ref val7)).Top > ((Rect)(ref val5)).Top)
								{
									((Point)(ref newRelativePosition)).Y = 0.0;
								}
							}
						}
					}
					scaleTransform = new ScaleTransform(newRelativeScale / _viewboxFactor, newRelativeScale / _viewboxFactor);
					translateTransform = new TranslateTransform(((Point)(ref newRelativePosition)).X, ((Point)(ref newRelativePosition)).Y);
					transformGroup = new TransformGroup();
					transformGroup.Children.Add(scaleTransform);
					transformGroup.Children.Add(translateTransform);
					_contentPresenter.RenderTransform = transformGroup;
					Size val8 = ((_content is Viewbox) ? ((Viewbox)_content).Child.DesiredSize : base.RenderSize);
					Size val9 = default(Size);
					((Size)(ref val9))._002Ector(((Size)(ref val8)).Width * newRelativeScale, ((Size)(ref val8)).Height * newRelativeScale);
					if (allowAnimation && IsAnimated)
					{
						DoubleAnimation doubleAnimation = new DoubleAnimation(fromValue, newRelativeScale / _viewboxFactor, AnimationDuration);
						doubleAnimation.AccelerationRatio = AnimationAccelerationRatio;
						doubleAnimation.DecelerationRatio = AnimationDecelerationRatio;
						DoubleAnimation doubleAnimation2 = new DoubleAnimation(x2, ((Point)(ref newRelativePosition)).X, AnimationDuration);
						doubleAnimation2.AccelerationRatio = AnimationAccelerationRatio;
						doubleAnimation2.DecelerationRatio = AnimationDecelerationRatio;
						DoubleAnimation doubleAnimation3 = new DoubleAnimation(y, ((Point)(ref newRelativePosition)).Y, AnimationDuration);
						doubleAnimation3.AccelerationRatio = AnimationAccelerationRatio;
						doubleAnimation3.DecelerationRatio = AnimationDecelerationRatio;
						doubleAnimation3.CurrentTimeInvalidated += UpdateViewport;
						doubleAnimation3.CurrentStateInvalidated += ZoomAnimationCompleted;
						RaiseEvent(new RoutedEventArgs(AnimationBeginningEvent, this));
						scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, doubleAnimation);
						scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, doubleAnimation);
						translateTransform.BeginAnimation(TranslateTransform.XProperty, doubleAnimation2);
						translateTransform.BeginAnimation(TranslateTransform.YProperty, doubleAnimation3);
						if (IsUsingScrollBars)
						{
							DoubleAnimation doubleAnimation4 = new DoubleAnimation();
							doubleAnimation4.From = _verticalScrollBar.Maximum;
							doubleAnimation4.To = ((Size)(ref val9)).Height - _verticalScrollBar.ViewportSize;
							doubleAnimation4.Duration = AnimationDuration;
							_verticalScrollBar.BeginAnimation(RangeBase.MaximumProperty, doubleAnimation4);
							DoubleAnimation doubleAnimation5 = new DoubleAnimation();
							doubleAnimation5.From = _verticalScrollBar.Value;
							doubleAnimation5.To = 0.0 - ((Point)(ref newRelativePosition)).Y;
							doubleAnimation5.Duration = AnimationDuration;
							doubleAnimation5.Completed += VerticalValueAnimation_Completed;
							_verticalScrollBar.BeginAnimation(RangeBase.ValueProperty, doubleAnimation5);
							DoubleAnimation doubleAnimation6 = new DoubleAnimation();
							doubleAnimation6.From = _horizontalScrollBar.Maximum;
							doubleAnimation6.To = ((Size)(ref val9)).Width - _horizontalScrollBar.ViewportSize;
							doubleAnimation6.Duration = AnimationDuration;
							_horizontalScrollBar.BeginAnimation(RangeBase.MaximumProperty, doubleAnimation6);
							DoubleAnimation doubleAnimation7 = new DoubleAnimation();
							doubleAnimation7.From = _horizontalScrollBar.Value;
							doubleAnimation7.To = 0.0 - ((Point)(ref newRelativePosition)).X;
							doubleAnimation7.Duration = AnimationDuration;
							doubleAnimation7.Completed += HorizontalValueAnimation_Completed;
							_horizontalScrollBar.BeginAnimation(RangeBase.ValueProperty, doubleAnimation7);
						}
					}
					else if (IsUsingScrollBars)
					{
						_verticalScrollBar.Maximum = ((Size)(ref val9)).Height - _verticalScrollBar.ViewportSize;
						_verticalScrollBar.Value = 0.0 - ((Point)(ref newRelativePosition)).Y;
						_horizontalScrollBar.Maximum = ((Size)(ref val9)).Width - _horizontalScrollBar.ViewportSize;
						_horizontalScrollBar.Value = 0.0 - ((Point)(ref newRelativePosition)).X;
					}
					_relativePosition = newRelativePosition;
					_relativeScale = newRelativeScale;
					Scale = newRelativeScale;
					_basePosition = newRelativePosition + ContentOffset * newRelativeScale;
					UpdateViewport();
				}
				if (EffectiveViewStackMode == ZoomboxViewStackMode.Auto && allowStackAddition)
				{
					if (ViewStack.Count > 1 && Math.Abs(DateTime.Now.Ticks - _lastStackAddition.Ticks) < TimeSpan.FromMilliseconds(300.0).Ticks)
					{
						ViewStack.RemoveAt(ViewStack.Count - 1);
						_lastStackAddition = DateTime.Now - TimeSpan.FromMilliseconds(300.0);
					}
					if (ViewStack.Count <= 0 || !(view == ViewStack.SelectedView))
					{
						ViewStack.PushView(view);
						ViewStackIndex++;
						stackIndex = ViewStackIndex;
						_lastStackAddition = DateTime.Now;
					}
				}
				_lastViewIndex = CurrentViewIndex;
				SetCurrentViewIndex(stackIndex);
				SetCurrentView(view);
			}
			finally
			{
				IsUpdatingView = false;
			}
		}
	}

	private bool IsGreaterThanOrClose(double value1, double value2)
	{
		if (!(value1 <= value2))
		{
			return true;
		}
		return DoubleHelper.AreVirtuallyEqual(value1, value2);
	}

	private Rect CalculateFillRect()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		Size renderSize = base.RenderSize;
		double width = ((Size)(ref renderSize)).Width;
		renderSize = base.RenderSize;
		double num = width / ((Size)(ref renderSize)).Height;
		double num2 = 0.0;
		double num3 = 0.0;
		Rect contentRect = ContentRect;
		double num4 = ((Rect)(ref contentRect)).Width;
		contentRect = ContentRect;
		double num5 = ((Rect)(ref contentRect)).Height;
		if (num > num4 / num5)
		{
			num5 = num4 / num;
			contentRect = ContentRect;
			num3 = (((Rect)(ref contentRect)).Height - num5) / 2.0;
		}
		else
		{
			num4 = num5 * num;
			contentRect = ContentRect;
			num2 = (((Rect)(ref contentRect)).Width - num4) / 2.0;
		}
		return new Rect(num2, num3, num4, num5);
	}

	private void CalculatePositionAndScale(Rect region, ref Point newRelativePosition, ref double newRelativeScale)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		if (((Rect)(ref region)).Width == 0.0 || ((Rect)(ref region)).Height == 0.0)
		{
			return;
		}
		Rect contentRect = ContentRect;
		if (((Rect)(ref contentRect)).IntersectsWith(region))
		{
			((Rect)(ref region))._002Ector(_content.TranslatePoint(((Rect)(ref region)).TopLeft, _contentPresenter), _content.TranslatePoint(((Rect)(ref region)).BottomRight, _contentPresenter));
			Size renderSize = base.RenderSize;
			double num = ((Size)(ref renderSize)).Width / ((Rect)(ref region)).Width;
			renderSize = base.RenderSize;
			double num2 = ((Size)(ref renderSize)).Height / ((Rect)(ref region)).Height;
			newRelativeScale = ((num < num2) ? num : num2);
			if (newRelativeScale > MaxScale)
			{
				newRelativeScale = MaxScale;
			}
			else if (newRelativeScale < MinScale)
			{
				newRelativeScale = MinScale;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			switch (base.HorizontalContentAlignment)
			{
			case HorizontalAlignment.Center:
			case HorizontalAlignment.Stretch:
				renderSize = base.RenderSize;
				num3 = (((Size)(ref renderSize)).Width - ((Rect)(ref region)).Width * newRelativeScale) / 2.0;
				break;
			case HorizontalAlignment.Right:
				renderSize = base.RenderSize;
				num3 = ((Size)(ref renderSize)).Width - ((Rect)(ref region)).Width * newRelativeScale;
				break;
			}
			switch (base.VerticalContentAlignment)
			{
			case VerticalAlignment.Center:
			case VerticalAlignment.Stretch:
				renderSize = base.RenderSize;
				num4 = (((Size)(ref renderSize)).Height - ((Rect)(ref region)).Height * newRelativeScale) / 2.0;
				break;
			case VerticalAlignment.Bottom:
				renderSize = base.RenderSize;
				num4 = ((Size)(ref renderSize)).Height - ((Rect)(ref region)).Height * newRelativeScale;
				break;
			}
			Point topLeft = ((Rect)(ref region)).TopLeft;
			double num5 = (0.0 - ((Point)(ref topLeft)).X) * newRelativeScale;
			topLeft = ((Rect)(ref region)).TopLeft;
			newRelativePosition = new Point(num5, (0.0 - ((Point)(ref topLeft)).Y) * newRelativeScale) + new Vector(num3, num4);
		}
	}

	private void UpdateViewFinderDisplayContentBounds()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		if (_content == null || _trueContent == null || _viewFinderDisplay == null)
		{
			return;
		}
		Size availableSize = _viewFinderDisplay.AvailableSize;
		if (!((Size)(ref availableSize)).IsEmpty)
		{
			UpdateViewboxFactor();
			Size renderSize = _content.RenderSize;
			Size availableSize2 = _viewFinderDisplay.AvailableSize;
			if (((Size)(ref availableSize2)).Width > 0.0 && DoubleHelper.AreVirtuallyEqual(((Size)(ref availableSize2)).Height, 0.0))
			{
				((Size)(ref availableSize2))._002Ector(((Size)(ref availableSize2)).Width, ((Size)(ref renderSize)).Height * ((Size)(ref availableSize2)).Width / ((Size)(ref renderSize)).Width);
			}
			else if (((Size)(ref availableSize2)).Height > 0.0 && DoubleHelper.AreVirtuallyEqual(((Size)(ref availableSize2)).Width, 0.0))
			{
				((Size)(ref availableSize2))._002Ector(((Size)(ref renderSize)).Width * ((Size)(ref availableSize2)).Height / ((Size)(ref renderSize)).Height, ((Size)(ref availableSize2)).Width);
			}
			double num = ((Size)(ref availableSize2)).Width / ((Size)(ref renderSize)).Width;
			double num2 = ((Size)(ref availableSize2)).Height / ((Size)(ref renderSize)).Height;
			double num3 = ((num < num2) ? num : num2);
			double num4 = ((Size)(ref renderSize)).Width * num3;
			double num5 = ((Size)(ref renderSize)).Height * num3;
			_viewFinderDisplay.Scale = num3;
			_viewFinderDisplay.ContentBounds = new Rect(new Size(num4, num5));
		}
	}

	private void UpdateViewboxFactor()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null && _trueContent != null)
		{
			Size renderSize = _content.RenderSize;
			double width = ((Size)(ref renderSize)).Width;
			renderSize = _trueContent.RenderSize;
			double width2 = ((Size)(ref renderSize)).Width;
			if (DoubleHelper.AreVirtuallyEqual(width, 0.0) || DoubleHelper.AreVirtuallyEqual(width2, 0.0))
			{
				_viewboxFactor = 1.0;
			}
			else
			{
				_viewboxFactor = width / width2;
			}
		}
	}

	private void UpdateViewport()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (_contentPresenter == null || _trueContent == null)
		{
			return;
		}
		IsUpdatingViewport = true;
		try
		{
			Point val = TranslatePoint(new Point(0.0, 0.0), _trueContent);
			Size renderSize = base.RenderSize;
			double width = ((Size)(ref renderSize)).Width;
			renderSize = base.RenderSize;
			Rect val2 = default(Rect);
			((Rect)(ref val2))._002Ector(val, TranslatePoint(new Point(width, ((Size)(ref renderSize)).Height), _trueContent));
			if (!DoubleHelper.AreVirtuallyEqual(val2, Viewport))
			{
				((DependencyObject)this).SetValue(ViewportPropertyKey, (object)val2);
			}
		}
		finally
		{
			IsUpdatingViewport = false;
		}
	}

	private void UpdateViewport(object sender, EventArgs e)
	{
		UpdateViewport();
	}

	private void ViewFinderDisplayBeginCapture(object sender, MouseButtonEventArgs e)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		if (!(_viewFinderDisplay.Tag is ResizeEdge))
		{
			return;
		}
		if ((ResizeEdge)_viewFinderDisplay.Tag == ResizeEdge.None)
		{
			IsDraggingViewport = true;
		}
		else
		{
			IsResizingViewport = true;
			Vector val = default(Vector);
			Rect viewportRect;
			switch ((ResizeEdge)_viewFinderDisplay.Tag)
			{
			case ResizeEdge.TopLeft:
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = ((Rect)(ref viewportRect)).TopLeft;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = ((Rect)(ref viewportRect)).BottomRight;
				((Vector)(ref val))._002Ector(-1.0, -1.0);
				break;
			case ResizeEdge.TopRight:
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = ((Rect)(ref viewportRect)).TopRight;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = ((Rect)(ref viewportRect)).BottomLeft;
				((Vector)(ref val))._002Ector(1.0, -1.0);
				break;
			case ResizeEdge.BottomLeft:
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = ((Rect)(ref viewportRect)).BottomLeft;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = ((Rect)(ref viewportRect)).TopRight;
				((Vector)(ref val))._002Ector(-1.0, 1.0);
				break;
			case ResizeEdge.BottomRight:
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = ((Rect)(ref viewportRect)).BottomRight;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = ((Rect)(ref viewportRect)).TopLeft;
				((Vector)(ref val))._002Ector(1.0, 1.0);
				break;
			case ResizeEdge.Left:
			{
				viewportRect = _viewFinderDisplay.ViewportRect;
				double left6 = ((Rect)(ref viewportRect)).Left;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double top3 = ((Rect)(ref viewportRect)).Top;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(left6, top3 + ((Rect)(ref viewportRect)).Height / 2.0);
				viewportRect = _viewFinderDisplay.ViewportRect;
				double right2 = ((Rect)(ref viewportRect)).Right;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double top4 = ((Rect)(ref viewportRect)).Top;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(right2, top4 + ((Rect)(ref viewportRect)).Height / 2.0);
				((Vector)(ref val))._002Ector(-1.0, 0.0);
				break;
			}
			case ResizeEdge.Top:
			{
				viewportRect = _viewFinderDisplay.ViewportRect;
				double left4 = ((Rect)(ref viewportRect)).Left;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double num3 = left4 + ((Rect)(ref viewportRect)).Width / 2.0;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(num3, ((Rect)(ref viewportRect)).Top);
				viewportRect = _viewFinderDisplay.ViewportRect;
				double left5 = ((Rect)(ref viewportRect)).Left;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double num4 = left5 + ((Rect)(ref viewportRect)).Width / 2.0;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(num4, ((Rect)(ref viewportRect)).Bottom);
				((Vector)(ref val))._002Ector(0.0, -1.0);
				break;
			}
			case ResizeEdge.Right:
			{
				viewportRect = _viewFinderDisplay.ViewportRect;
				double right = ((Rect)(ref viewportRect)).Right;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double top = ((Rect)(ref viewportRect)).Top;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(right, top + ((Rect)(ref viewportRect)).Height / 2.0);
				viewportRect = _viewFinderDisplay.ViewportRect;
				double left3 = ((Rect)(ref viewportRect)).Left;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double top2 = ((Rect)(ref viewportRect)).Top;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(left3, top2 + ((Rect)(ref viewportRect)).Height / 2.0);
				((Vector)(ref val))._002Ector(1.0, 0.0);
				break;
			}
			case ResizeEdge.Bottom:
			{
				viewportRect = _viewFinderDisplay.ViewportRect;
				double left = ((Rect)(ref viewportRect)).Left;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double num = left + ((Rect)(ref viewportRect)).Width / 2.0;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(num, ((Rect)(ref viewportRect)).Bottom);
				viewportRect = _viewFinderDisplay.ViewportRect;
				double left2 = ((Rect)(ref viewportRect)).Left;
				viewportRect = _viewFinderDisplay.ViewportRect;
				double num2 = left2 + ((Rect)(ref viewportRect)).Width / 2.0;
				viewportRect = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(num2, ((Rect)(ref viewportRect)).Top);
				((Vector)(ref val))._002Ector(0.0, 1.0);
				break;
			}
			}
			_ = _viewFinderDisplay.Scale;
			Rect contentBounds = _viewFinderDisplay.ContentBounds;
			Vector val2 = default(Vector);
			((Vector)(ref val2))._002Ector(((Vector)(ref val)).X * 10000000000.0, ((Vector)(ref val)).Y * 10000000000.0);
			Vector val3 = default(Vector);
			((Vector)(ref val3))._002Ector(((Vector)(ref val)).X * ((Rect)(ref contentBounds)).Width / MaxScale, ((Vector)(ref val)).Y * ((Rect)(ref contentBounds)).Height / MaxScale);
			_resizeViewportBounds = new Rect(_resizeAnchorPoint + val2, _resizeAnchorPoint + val3);
		}
		_originPoint = e.GetPosition(_viewFinderDisplay);
		_viewFinderDisplay.CaptureMouse();
		e.Handled = true;
	}

	private void ViewFinderDisplayEndCapture(object sender, MouseButtonEventArgs e)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (IsDraggingViewport || IsResizingViewport)
		{
			DragDisplayViewport(new DragDeltaEventArgs(0.0, 0.0), end: true);
			IsDraggingViewport = false;
			IsResizingViewport = false;
			_originPoint = default(Point);
			_viewFinderDisplay.ReleaseMouseCapture();
			e.Handled = true;
		}
	}

	private void ViewFinderDisplayMouseMove(object sender, MouseEventArgs e)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		if (e.MouseDevice.LeftButton == MouseButtonState.Pressed && (IsDraggingViewport || IsResizingViewport))
		{
			Vector val = e.GetPosition(_viewFinderDisplay) - _originPoint;
			if (IsDraggingViewport)
			{
				DragDisplayViewport(new DragDeltaEventArgs(((Vector)(ref val)).X, ((Vector)(ref val)).Y), end: false);
			}
			else
			{
				ResizeDisplayViewport(new DragDeltaEventArgs(((Vector)(ref val)).X, ((Vector)(ref val)).Y), (ResizeEdge)_viewFinderDisplay.Tag);
			}
			e.Handled = true;
			return;
		}
		Point position = e.GetPosition(_viewFinderDisplay);
		Rect viewportRect = _viewFinderDisplay.ViewportRect;
		double num = ((((Rect)(ref viewportRect)).Width * ((Rect)(ref viewportRect)).Height > 100.0) ? 5.0 : (Math.Sqrt(((Rect)(ref viewportRect)).Width * ((Rect)(ref viewportRect)).Height) / 2.0));
		if (((Rect)(ref viewportRect)).Contains(position) && !DoubleHelper.AreVirtuallyEqual(Rect.Intersect(viewportRect, _viewFinderDisplay.ContentBounds), _viewFinderDisplay.ContentBounds))
		{
			if (PointHelper.DistanceBetween(position, ((Rect)(ref viewportRect)).TopLeft) < num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.TopLeft;
				_viewFinderDisplay.Cursor = Cursors.SizeNWSE;
			}
			else if (PointHelper.DistanceBetween(position, ((Rect)(ref viewportRect)).BottomRight) < num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.BottomRight;
				_viewFinderDisplay.Cursor = Cursors.SizeNWSE;
			}
			else if (PointHelper.DistanceBetween(position, ((Rect)(ref viewportRect)).TopRight) < num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.TopRight;
				_viewFinderDisplay.Cursor = Cursors.SizeNESW;
			}
			else if (PointHelper.DistanceBetween(position, ((Rect)(ref viewportRect)).BottomLeft) < num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.BottomLeft;
				_viewFinderDisplay.Cursor = Cursors.SizeNESW;
			}
			else if (((Point)(ref position)).X <= ((Rect)(ref viewportRect)).Left + num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.Left;
				_viewFinderDisplay.Cursor = Cursors.SizeWE;
			}
			else if (((Point)(ref position)).Y <= ((Rect)(ref viewportRect)).Top + num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.Top;
				_viewFinderDisplay.Cursor = Cursors.SizeNS;
			}
			else if (((Point)(ref position)).X >= ((Rect)(ref viewportRect)).Right - num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.Right;
				_viewFinderDisplay.Cursor = Cursors.SizeWE;
			}
			else if (((Point)(ref position)).Y >= ((Rect)(ref viewportRect)).Bottom - num)
			{
				_viewFinderDisplay.Tag = ResizeEdge.Bottom;
				_viewFinderDisplay.Cursor = Cursors.SizeNS;
			}
			else
			{
				_viewFinderDisplay.Tag = ResizeEdge.None;
				_viewFinderDisplay.Cursor = Cursors.SizeAll;
			}
		}
		else
		{
			_viewFinderDisplay.Tag = null;
			_viewFinderDisplay.Cursor = Cursors.Arrow;
		}
	}

	private void ZoomAnimationCompleted(object sender, EventArgs e)
	{
		if ((sender as AnimationClock).CurrentState != ClockState.Active)
		{
			(sender as AnimationClock).CurrentStateInvalidated -= ZoomAnimationCompleted;
			(sender as AnimationClock).CurrentTimeInvalidated -= UpdateViewport;
			RaiseEvent(new RoutedEventArgs(AnimationCompletedEvent, this));
		}
	}

	private void VerticalValueAnimation_Completed(object sender, EventArgs e)
	{
		if (_verticalScrollBar.Value == 0.0 - ((Point)(ref _relativePosition)).Y || _verticalScrollBar.Value == _verticalScrollBar.Maximum || _verticalScrollBar.Value == _verticalScrollBar.Minimum)
		{
			double value = _verticalScrollBar.Value;
			_verticalScrollBar.BeginAnimation(RangeBase.ValueProperty, null);
			_verticalScrollBar.Value = value;
		}
	}

	private void HorizontalValueAnimation_Completed(object sender, EventArgs e)
	{
		if (_horizontalScrollBar.Value == 0.0 - ((Point)(ref _relativePosition)).X || _horizontalScrollBar.Value == _horizontalScrollBar.Maximum || _horizontalScrollBar.Value == _horizontalScrollBar.Minimum)
		{
			double value = _horizontalScrollBar.Value;
			_horizontalScrollBar.BeginAnimation(RangeBase.ValueProperty, null);
			_horizontalScrollBar.Value = value;
		}
	}

	private void ZoomTo(double scale, bool allowStackAddition)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			ZoomTo(scale, GetZoomRelativePoint(), restrictRelativePointToContent: true, allowStackAddition);
		}
	}

	private void ZoomTo(double scale, Point relativeTo, bool restrictRelativePointToContent, bool allowStackAddition)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		if (_content == null || double.IsNaN(scale))
		{
			return;
		}
		if (restrictRelativePointToContent)
		{
			Rect val = new Rect(_content.RenderSize);
			if (!((Rect)(ref val)).Contains(relativeTo))
			{
				return;
			}
		}
		if (scale > MaxScale)
		{
			scale = MaxScale;
		}
		else if (scale < MinScale)
		{
			scale = MinScale;
		}
		Point val2 = relativeTo;
		if (HasRenderedFirstView)
		{
			relativeTo = _content.TranslatePoint(relativeTo, this);
			val2 = TranslatePoint(relativeTo, _contentPresenter);
		}
		else if (_contentPresenter != null)
		{
			if (_contentPresenter.RenderTransform == Transform.Identity)
			{
				UpdateView(new ZoomboxView(1.0, new Point(0.0, 0.0)), allowAnimation: false, allowStackAddition: false);
			}
			relativeTo = _contentPresenter.RenderTransform.Transform(relativeTo);
		}
		Point position = new Point(((Point)(ref relativeTo)).X - ((Point)(ref val2)).X * scale / _viewboxFactor, ((Point)(ref relativeTo)).Y - ((Point)(ref val2)).Y * scale / _viewboxFactor) + ContentOffset * scale / _viewboxFactor;
		UpdateView(new ZoomboxView(scale, position), !IsResizingViewport, allowStackAddition);
	}

	private Point GetZoomRelativePoint()
	{
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		Point zoomOrigin;
		Size renderSize;
		Point result = default(Point);
		if (ZoomOn == ZoomboxZoomOn.View)
		{
			Point point = default(Point);
			Rect viewport = Viewport;
			double x = ((Rect)(ref viewport)).X;
			viewport = Viewport;
			double width = ((Rect)(ref viewport)).Width;
			zoomOrigin = ZoomOrigin;
			((Point)(ref point)).X = x + width * ((Point)(ref zoomOrigin)).X;
			viewport = Viewport;
			double y = ((Rect)(ref viewport)).Y;
			viewport = Viewport;
			double height = ((Rect)(ref viewport)).Height;
			zoomOrigin = ZoomOrigin;
			((Point)(ref point)).Y = y + height * ((Point)(ref zoomOrigin)).Y;
			Point val = _trueContent.TranslatePoint(point, _content);
			if (((Point)(ref val)).X < 0.0)
			{
				((Point)(ref val)).X = 0.0;
			}
			else
			{
				double x2 = ((Point)(ref val)).X;
				renderSize = _content.RenderSize;
				if (x2 > ((Size)(ref renderSize)).Width)
				{
					renderSize = _content.RenderSize;
					((Point)(ref val)).X = ((Size)(ref renderSize)).Width;
				}
			}
			if (((Point)(ref val)).Y < 0.0)
			{
				((Point)(ref val)).Y = 0.0;
			}
			else
			{
				double y2 = ((Point)(ref val)).Y;
				renderSize = _content.RenderSize;
				if (y2 > ((Size)(ref renderSize)).Height)
				{
					renderSize = _content.RenderSize;
					((Point)(ref val)).Y = ((Size)(ref renderSize)).Height;
				}
			}
			result = val;
			return result;
		}
		renderSize = _content.RenderSize;
		double width2 = ((Size)(ref renderSize)).Width;
		zoomOrigin = ZoomOrigin;
		double num = width2 * ((Point)(ref zoomOrigin)).X;
		renderSize = _content.RenderSize;
		double height2 = ((Size)(ref renderSize)).Height;
		zoomOrigin = ZoomOrigin;
		((Point)(ref result))._002Ector(num, height2 * ((Point)(ref zoomOrigin)).Y);
		return result;
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		if (NavigateOnPreview && !e.Handled)
		{
			ProcessNavigationButton(e);
		}
		base.OnPreviewKeyDown(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!NavigateOnPreview && !e.Handled)
		{
			ProcessNavigationButton(e);
		}
		base.OnKeyDown(e);
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		if (NavigateOnPreview && !e.Handled)
		{
			ProcessNavigationButton(e);
		}
		base.OnPreviewMouseDown(e);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		if (!NavigateOnPreview && !e.Handled)
		{
			ProcessNavigationButton(e);
		}
		base.OnMouseDown(e);
	}

	protected override void OnMouseEnter(MouseEventArgs e)
	{
		MonitorInput();
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		MonitorInput();
		base.OnMouseLeave(e);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (DragOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonDown(e);
		}
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (!DragOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonDown(e);
		}
		base.OnMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (DragOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonUp(e);
		}
		base.OnPreviewMouseLeftButtonUp(e);
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (!DragOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonUp(e);
		}
		base.OnMouseLeftButtonUp(e);
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		if (DragOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseMove(e);
		}
		base.OnPreviewMouseMove(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!DragOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseMove(e);
		}
		base.OnMouseMove(e);
	}

	protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
	{
		if (ZoomOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseWheelZoom(e);
		}
		base.OnPreviewMouseWheel(e);
	}

	protected override void OnMouseWheel(MouseWheelEventArgs e)
	{
		if (!ZoomOnPreview && !e.Handled && _contentPresenter != null)
		{
			ProcessMouseWheelZoom(e);
		}
		base.OnMouseWheel(e);
	}
}
