using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public class AdornerPanel : Panel
{
	private class SyntaticSugarPlacementCollection : AdornerPlacementCollection
	{
		private AdornerHorizontalAlignment _hAlign;

		private AdornerVerticalAlignment _vAlign;

		private Thickness _adornerMargin;

		public AdornerHorizontalAlignment HorizontalAlign
		{
			get
			{
				return _hAlign;
			}
			set
			{
				if (_hAlign != value)
				{
					_hAlign = value;
					Clear();
				}
			}
		}

		public AdornerVerticalAlignment VerticalAlign
		{
			get
			{
				return _vAlign;
			}
			set
			{
				if (_vAlign != value)
				{
					_vAlign = value;
					Clear();
				}
			}
		}

		public Thickness Margin
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _adornerMargin;
			}
			set
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				if (_adornerMargin != value)
				{
					_adornerMargin = value;
					Clear();
				}
			}
		}

		internal override void ComputePlacement(AdornerCoordinateSpace space, UIElement adorner, ViewItem adornedElement, Vector zoom, Size finalSize)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			if (base.Items.Count == 0)
			{
				Populate();
			}
			base.ComputePlacement(space, adorner, adornedElement, zoom, finalSize);
		}

		private void Populate()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			Thickness margin = Margin;
			switch (HorizontalAlign)
			{
			case AdornerHorizontalAlignment.Left:
				SizeRelativeToAdornerDesiredWidth(1.0, 0.0);
				PositionRelativeToContentWidth(0.0, ((Thickness)(ref margin)).Left);
				break;
			case AdornerHorizontalAlignment.Center:
				SizeRelativeToAdornerDesiredWidth(1.0, 0.0);
				PositionRelativeToContentWidth(0.5, 0.0);
				PositionRelativeToAdornerWidth(-0.5, ((Thickness)(ref margin)).Left);
				break;
			case AdornerHorizontalAlignment.Right:
				SizeRelativeToAdornerDesiredWidth(1.0, 0.0);
				PositionRelativeToContentWidth(1.0, 0.0 - ((Thickness)(ref margin)).Right);
				break;
			case AdornerHorizontalAlignment.Stretch:
				SizeRelativeToContentWidth(1.0, 0.0 - (((Thickness)(ref margin)).Left + ((Thickness)(ref margin)).Right));
				PositionRelativeToContentWidth(0.0, ((Thickness)(ref margin)).Left);
				break;
			case AdornerHorizontalAlignment.OutsideLeft:
				SizeRelativeToAdornerDesiredWidth(1.0, 0.0);
				PositionRelativeToAdornerWidth(-1.0, 0.0 - ((Thickness)(ref margin)).Left);
				break;
			case AdornerHorizontalAlignment.OutsideRight:
				SizeRelativeToAdornerDesiredWidth(1.0, 0.0);
				PositionRelativeToContentWidth(1.0, 0.0);
				PositionRelativeToAdornerWidth(0.0, ((Thickness)(ref margin)).Right);
				break;
			}
			switch (VerticalAlign)
			{
			case AdornerVerticalAlignment.Top:
				SizeRelativeToAdornerDesiredHeight(1.0, 0.0);
				PositionRelativeToContentHeight(0.0, ((Thickness)(ref margin)).Top);
				break;
			case AdornerVerticalAlignment.Center:
				SizeRelativeToAdornerDesiredHeight(1.0, 0.0);
				PositionRelativeToContentHeight(0.5, 0.0);
				PositionRelativeToAdornerHeight(-0.5, ((Thickness)(ref margin)).Top);
				break;
			case AdornerVerticalAlignment.Bottom:
				SizeRelativeToAdornerDesiredHeight(1.0, 0.0);
				PositionRelativeToContentHeight(1.0, 0.0 - ((Thickness)(ref margin)).Bottom);
				break;
			case AdornerVerticalAlignment.Stretch:
				SizeRelativeToContentHeight(1.0, 0.0 - (((Thickness)(ref margin)).Top + ((Thickness)(ref margin)).Bottom));
				PositionRelativeToContentHeight(0.0, ((Thickness)(ref margin)).Top);
				break;
			case AdornerVerticalAlignment.OutsideTop:
				SizeRelativeToAdornerDesiredHeight(1.0, 0.0);
				PositionRelativeToAdornerHeight(-1.0, 0.0 - ((Thickness)(ref margin)).Top);
				break;
			case AdornerVerticalAlignment.OutsideBottom:
				SizeRelativeToAdornerDesiredHeight(1.0, 0.0);
				PositionRelativeToContentHeight(1.0, 0.0);
				PositionRelativeToAdornerHeight(0.0, ((Thickness)(ref margin)).Bottom);
				break;
			}
		}
	}

	private Rect _offsetRect = default(Rect);

	private bool _isMirroredTransform;

	public static readonly DependencyProperty IsContentFocusableProperty = DependencyProperty.Register("IsContentFocusable", typeof(bool), typeof(AdornerPanel), new PropertyMetadata((object)false));

	public static readonly DependencyProperty ModelProperty = AdornerProperties.ModelProperty.AddOwner(typeof(AdornerPanel));

	public static readonly DependencyProperty OrderProperty = AdornerProperties.OrderProperty.AddOwner(typeof(AdornerPanel));

	public static readonly DependencyProperty PlacementsProperty = DependencyProperty.RegisterAttached("Placements", typeof(AdornerPlacementCollection), typeof(AdornerPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)new AdornerPlacementCollection(), (FrameworkPropertyMetadataOptions)8));

	public static readonly DependencyProperty HorizontalStretchProperty = DependencyProperty.RegisterAttached("HorizontalStretch", typeof(AdornerStretch), typeof(AdornerPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)AdornerStretch.None, (FrameworkPropertyMetadataOptions)4), (ValidateValueCallback)delegate(object target)
	{
		AdornerStretch adornerStretch = (AdornerStretch)target;
		return adornerStretch == AdornerStretch.None || adornerStretch == AdornerStretch.Stretch;
	});

	public static readonly DependencyProperty VerticalStretchProperty = DependencyProperty.RegisterAttached("VerticalStretch", typeof(AdornerStretch), typeof(AdornerPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)AdornerStretch.None, (FrameworkPropertyMetadataOptions)4), (ValidateValueCallback)delegate(object target)
	{
		AdornerStretch adornerStretch = (AdornerStretch)target;
		return adornerStretch == AdornerStretch.None || adornerStretch == AdornerStretch.Stretch;
	});

	public static readonly DependencyProperty AdornerHorizontalAlignmentProperty = DependencyProperty.RegisterAttached("AdornerHorizontalAlignment", typeof(AdornerHorizontalAlignment), typeof(AdornerPanel), (PropertyMetadata)new UIPropertyMetadata((object)AdornerHorizontalAlignment.Left, new PropertyChangedCallback(OnAdornerAlignmentChanged)));

	public static readonly DependencyProperty AdornerVerticalAlignmentProperty = DependencyProperty.RegisterAttached("AdornerVerticalAlignment", typeof(AdornerVerticalAlignment), typeof(AdornerPanel), (PropertyMetadata)new UIPropertyMetadata((object)AdornerVerticalAlignment.Top, new PropertyChangedCallback(OnAdornerAlignmentChanged)));

	public static readonly DependencyProperty AdornerMarginProperty = DependencyProperty.RegisterAttached("AdornerMargin", typeof(Thickness), typeof(AdornerPanel), (PropertyMetadata)new UIPropertyMetadata((object)new Thickness(0.0), new PropertyChangedCallback(OnAdornerAlignmentChanged)));

	private static readonly DependencyProperty SyntaticSugarPlacementsProperty = DependencyProperty.RegisterAttached("SyntaticSugarPlacements", typeof(SyntaticSugarPlacementCollection), typeof(AdornerPanel), (PropertyMetadata)new FrameworkPropertyMetadata((object)new SyntaticSugarPlacementCollection(), (FrameworkPropertyMetadataOptions)8));

	public bool IsContentFocusable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsContentFocusableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsContentFocusableProperty, (object)value);
		}
	}

	protected internal virtual bool UseMirrorTransform => true;

	internal bool IsMirroredTransform
	{
		get
		{
			if (UseMirrorTransform)
			{
				return _isMirroredTransform;
			}
			return false;
		}
		set
		{
			_isMirroredTransform = value;
		}
	}

	public ViewItem View => Model?.View;

	public ModelItem Model
	{
		get
		{
			return AdornerProperties.GetModel((DependencyObject)(object)this);
		}
		set
		{
			AdornerProperties.SetModel((DependencyObject)(object)this, value);
		}
	}

	public AdornerOrder Order
	{
		get
		{
			return AdornerProperties.GetOrder((DependencyObject)(object)this);
		}
		set
		{
			AdornerProperties.SetOrder((DependencyObject)(object)this, value);
		}
	}

	protected internal Rect OffsetRect
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _offsetRect;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_offsetRect = value;
		}
	}

	internal static AdornerPlacementCollection GetCurrentPlacements(UIElement adorner)
	{
		AdornerPlacementCollection placements = GetPlacements(adorner);
		if (placements == null || placements.Count == 0)
		{
			return GetSyntaticSugarPlacements((DependencyObject)(object)adorner);
		}
		return placements;
	}

	public static AdornerPlacementCollection GetPlacements(UIElement adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (AdornerPlacementCollection)((DependencyObject)adorner).GetValue(PlacementsProperty);
	}

	public static void SetPlacements(UIElement adorner, AdornerPlacementCollection value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		((DependencyObject)adorner).SetValue(PlacementsProperty, (object)value);
	}

	public static AdornerStretch GetHorizontalStretch(UIElement adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (AdornerStretch)((DependencyObject)adorner).GetValue(HorizontalStretchProperty);
	}

	public static void SetHorizontalStretch(UIElement adorner, AdornerStretch value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		if (!EnumValidator.IsValid(value))
		{
			throw new ArgumentOutOfRangeException("value");
		}
		((DependencyObject)adorner).SetValue(HorizontalStretchProperty, (object)value);
	}

	public static AdornerStretch GetVerticalStretch(UIElement adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return (AdornerStretch)((DependencyObject)adorner).GetValue(VerticalStretchProperty);
	}

	public static void SetVerticalStretch(UIElement adorner, AdornerStretch value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		if (!EnumValidator.IsValid(value))
		{
			throw new ArgumentOutOfRangeException("value");
		}
		((DependencyObject)adorner).SetValue(VerticalStretchProperty, (object)value);
	}

	public static AdornerHorizontalAlignment GetAdornerHorizontalAlignment(DependencyObject obj)
	{
		return (AdornerHorizontalAlignment)obj.GetValue(AdornerHorizontalAlignmentProperty);
	}

	public static void SetAdornerHorizontalAlignment(DependencyObject obj, AdornerHorizontalAlignment value)
	{
		obj.SetValue(AdornerHorizontalAlignmentProperty, (object)value);
	}

	public static AdornerVerticalAlignment GetAdornerVerticalAlignment(DependencyObject obj)
	{
		return (AdornerVerticalAlignment)obj.GetValue(AdornerVerticalAlignmentProperty);
	}

	public static void SetAdornerVerticalAlignment(DependencyObject obj, AdornerVerticalAlignment value)
	{
		obj.SetValue(AdornerVerticalAlignmentProperty, (object)value);
	}

	public static Thickness GetAdornerMargin(DependencyObject obj)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return (Thickness)obj.GetValue(AdornerMarginProperty);
	}

	public static void SetAdornerMargin(DependencyObject obj, Thickness value)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		obj.SetValue(AdornerMarginProperty, (object)value);
	}

	private static void OnAdornerAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		AdornerHorizontalAlignment horizontalAlign = (AdornerHorizontalAlignment)d.GetValue(AdornerHorizontalAlignmentProperty);
		AdornerVerticalAlignment verticalAlign = (AdornerVerticalAlignment)d.GetValue(AdornerVerticalAlignmentProperty);
		Thickness margin = (Thickness)d.GetValue(AdornerMarginProperty);
		SyntaticSugarPlacementCollection syntaticSugarPlacementCollection = new SyntaticSugarPlacementCollection();
		syntaticSugarPlacementCollection.VerticalAlign = verticalAlign;
		syntaticSugarPlacementCollection.HorizontalAlign = horizontalAlign;
		syntaticSugarPlacementCollection.Margin = margin;
		SetSyntaticSugarPlacements(d, syntaticSugarPlacementCollection);
	}

	private static SyntaticSugarPlacementCollection GetSyntaticSugarPlacements(DependencyObject obj)
	{
		return (SyntaticSugarPlacementCollection)obj.GetValue(SyntaticSugarPlacementsProperty);
	}

	private static void SetSyntaticSugarPlacements(DependencyObject obj, SyntaticSugarPlacementCollection value)
	{
		obj.SetValue(SyntaticSugarPlacementsProperty, (object)value);
	}

	public static Task GetTask(UIElement adorner)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		return AdornerProperties.GetTask((DependencyObject)(object)adorner);
	}

	public static void SetTask(UIElement adorner, Task value)
	{
		if (adorner == null)
		{
			throw new ArgumentNullException("adorner");
		}
		AdornerProperties.SetTask((DependencyObject)(object)adorner, value);
	}

	public static AdornerPanel FromVisual(DependencyObject visual)
	{
		if (visual == null)
		{
			throw new ArgumentNullException("visual");
		}
		AdornerPanel adornerPanel = null;
		for (DependencyObject parent = VisualTreeHelper.GetParent(visual); parent != null; parent = VisualTreeHelper.GetParent(parent))
		{
			adornerPanel = parent as AdornerPanel;
			if (adornerPanel != null)
			{
				break;
			}
		}
		return adornerPanel;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		Size val = default(Size);
		((Size)(ref val))._002Ector(double.PositiveInfinity, double.PositiveInfinity);
		int childrenCount = VisualTreeHelper.GetChildrenCount((DependencyObject)(object)this);
		for (int i = 0; i < childrenCount; i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)this, i);
			UIElement val2 = (UIElement)(object)((child is UIElement) ? child : null);
			if (val2 != null)
			{
				val2.Measure(val);
			}
		}
		return new Size(0.0, 0.0);
	}

	protected override Geometry GetLayoutClip(Size layoutSlotSize)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (((UIElement)this).ClipToBounds)
		{
			return ((FrameworkElement)this).GetLayoutClip(layoutSlotSize);
		}
		return null;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return AdornerProperties.GetLayout((DependencyObject)(object)this).ArrangeChildren((FrameworkElement)(object)this, ((Panel)this).InternalChildren, finalSize);
	}

	protected override void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		((UIElement)this).OnPreviewGotKeyboardFocus(e);
		if (!IsContentFocusable)
		{
			((RoutedEventArgs)e).Handled = true;
		}
	}

	[Conditional("DEBUG")]
	internal static void Trace(string format, params object[] data)
	{
	}
}
