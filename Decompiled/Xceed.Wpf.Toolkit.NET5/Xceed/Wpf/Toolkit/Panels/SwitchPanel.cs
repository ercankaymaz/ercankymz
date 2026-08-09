using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace Xceed.Wpf.Toolkit.Panels;

public class SwitchPanel : PanelBase, IScrollInfo
{
	private enum CacheBits
	{
		HasLoaded = 1
	}

	private static readonly Vector ZeroVector = default(Vector);

	public static readonly DependencyProperty AreLayoutSwitchesAnimatedProperty = DependencyProperty.Register("AreLayoutSwitchesAnimated", typeof(bool), typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	private static readonly DependencyPropertyKey ActiveLayoutPropertyKey = DependencyProperty.RegisterReadOnly("ActiveLayout", typeof(AnimationPanel), typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnActiveLayoutChanged)));

	public static readonly DependencyProperty ActiveLayoutProperty = ActiveLayoutPropertyKey.DependencyProperty;

	public static readonly DependencyProperty ActiveLayoutIndexProperty = DependencyProperty.Register("ActiveLayoutIndex", typeof(int), typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(-1, new PropertyChangedCallback(OnActiveLayoutIndexChanged), new CoerceValueCallback(CoerceActiveLayoutIndexValue)));

	private static readonly DependencyPropertyKey ActiveSwitchTemplatePropertyKey = DependencyProperty.RegisterReadOnly("ActiveSwitchTemplate", typeof(DataTemplate), typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnActiveSwitchTemplateChanged)));

	public static readonly DependencyProperty ActiveSwitchTemplateProperty = ActiveSwitchTemplatePropertyKey.DependencyProperty;

	public static readonly DependencyProperty DefaultAnimationRateProperty = AnimationPanel.DefaultAnimationRateProperty.AddOwner(typeof(SwitchPanel));

	public static readonly DependencyProperty DefaultAnimatorProperty = AnimationPanel.DefaultAnimatorProperty.AddOwner(typeof(SwitchPanel));

	public static readonly DependencyProperty EnterAnimationRateProperty = AnimationPanel.EnterAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty EnterAnimatorProperty = AnimationPanel.EnterAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty ExitAnimationRateProperty = AnimationPanel.ExitAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty ExitAnimatorProperty = AnimationPanel.ExitAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty LayoutAnimationRateProperty = AnimationPanel.LayoutAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty LayoutAnimatorProperty = AnimationPanel.LayoutAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	private static readonly DependencyPropertyKey LayoutsPropertyKey = DependencyProperty.RegisterReadOnly("Layouts", typeof(ObservableCollection<AnimationPanel>), typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(OnLayoutsChanged)));

	public static readonly DependencyProperty LayoutsProperty = LayoutsPropertyKey.DependencyProperty;

	public static readonly DependencyProperty SwitchAnimationRateProperty = AnimationPanel.SwitchAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty SwitchAnimatorProperty = AnimationPanel.SwitchAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty SwitchTemplateProperty = DependencyProperty.Register("SwitchTemplate", typeof(DataTemplate), typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSwitchTemplateChanged)));

	public static readonly DependencyProperty TemplateAnimationRateProperty = AnimationPanel.TemplateAnimationRateProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty TemplateAnimatorProperty = AnimationPanel.TemplateAnimatorProperty.AddOwner(typeof(SwitchPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	private readonly List<UIElement> _exitingChildren = new List<UIElement>();

	public static readonly RoutedEvent ActiveLayoutChangedEvent = EventManager.RegisterRoutedEvent("ActiveLayoutChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SwitchPanel));

	public static readonly RoutedEvent SwitchAnimationBegunEvent = EventManager.RegisterRoutedEvent("SwitchAnimationBegun", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SwitchPanel));

	public static readonly RoutedEvent SwitchAnimationCompletedEvent = EventManager.RegisterRoutedEvent("SwitchAnimationCompleted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SwitchPanel));

	internal AnimationPanel _currentLayoutPanel;

	private readonly AnimationPanel _defaultLayoutCanvas = new WrapPanel();

	private readonly Collection<SwitchPresenter> _presenters = new Collection<SwitchPresenter>();

	private BitVector32 _cacheBits = new BitVector32(0);

	private bool _allowHorizontal;

	private bool _allowVertical;

	private Vector _computedOffset = new Vector(0.0, 0.0);

	private Size _extent = new Size(0.0, 0.0);

	private Vector _offset = new Vector(0.0, 0.0);

	private ScrollViewer _scrollOwner;

	private Size _viewport;

	public bool AreLayoutSwitchesAnimated
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AreLayoutSwitchesAnimatedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AreLayoutSwitchesAnimatedProperty, (object)value);
		}
	}

	public AnimationPanel ActiveLayout => (AnimationPanel)((DependencyObject)this).GetValue(ActiveLayoutProperty);

	public int ActiveLayoutIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ActiveLayoutIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveLayoutIndexProperty, (object)value);
		}
	}

	public DataTemplate ActiveSwitchTemplate => (DataTemplate)((DependencyObject)this).GetValue(ActiveSwitchTemplateProperty);

	public AnimationRate DefaultAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(DefaultAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator DefaultAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(DefaultAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultAnimatorProperty, (object)value);
		}
	}

	public AnimationRate EnterAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(EnterAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnterAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator EnterAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(EnterAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EnterAnimatorProperty, (object)value);
		}
	}

	public AnimationRate ExitAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(ExitAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExitAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator ExitAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(ExitAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExitAnimatorProperty, (object)value);
		}
	}

	public AnimationRate LayoutAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(LayoutAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator LayoutAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(LayoutAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutAnimatorProperty, (object)value);
		}
	}

	public ObservableCollection<AnimationPanel> Layouts => (ObservableCollection<AnimationPanel>)((DependencyObject)this).GetValue(LayoutsProperty);

	public AnimationRate SwitchAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(SwitchAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator SwitchAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(SwitchAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchAnimatorProperty, (object)value);
		}
	}

	public DataTemplate SwitchTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(SwitchTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchTemplateProperty, (object)value);
		}
	}

	public AnimationRate TemplateAnimationRate
	{
		get
		{
			return (AnimationRate)((DependencyObject)this).GetValue(TemplateAnimationRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateAnimationRateProperty, (object)value);
		}
	}

	public IterativeAnimator TemplateAnimator
	{
		get
		{
			return (IterativeAnimator)((DependencyObject)this).GetValue(TemplateAnimatorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemplateAnimatorProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount
	{
		get
		{
			int num = 0;
			if (HasLoaded && _currentLayoutPanel != null)
			{
				return _currentLayoutPanel.VisualChildrenCountInternal;
			}
			return base.VisualChildrenCount;
		}
	}

	internal List<UIElement> ExitingChildren => _exitingChildren;

	internal UIElementCollection ChildrenInternal => base.InternalChildren;

	internal bool HasLoaded
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

	private bool IsScrollingPhysically
	{
		get
		{
			bool result = false;
			if (_scrollOwner != null)
			{
				result = true;
				if (ActiveLayout != null && ActiveLayout is IScrollInfo)
				{
					result = ((IScrollInfo)ActiveLayout).ScrollOwner == null;
				}
			}
			return result;
		}
	}

	public bool CanHorizontallyScroll
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).CanHorizontallyScroll;
			}
			return _allowHorizontal;
		}
		set
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				((IScrollInfo)ActiveLayout).CanHorizontallyScroll = value;
			}
			else
			{
				_allowHorizontal = value;
			}
		}
	}

	public bool CanVerticallyScroll
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).CanVerticallyScroll;
			}
			return _allowVertical;
		}
		set
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				((IScrollInfo)ActiveLayout).CanVerticallyScroll = value;
			}
			else
			{
				_allowVertical = value;
			}
		}
	}

	public double ExtentHeight
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ExtentHeight;
			}
			return ((Size)(ref _extent)).Height;
		}
	}

	public double ExtentWidth
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ExtentWidth;
			}
			return ((Size)(ref _extent)).Width;
		}
	}

	public double HorizontalOffset
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).HorizontalOffset;
			}
			return ((Vector)(ref _offset)).X;
		}
	}

	public ScrollViewer ScrollOwner
	{
		get
		{
			return _scrollOwner;
		}
		set
		{
			foreach (AnimationPanel layout in Layouts)
			{
				if (layout != null && layout is IScrollInfo)
				{
					((IScrollInfo)layout).ScrollOwner = value;
				}
			}
			if (_scrollOwner != value)
			{
				_scrollOwner = value;
				ResetScrollInfo();
			}
		}
	}

	public double VerticalOffset
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).VerticalOffset;
			}
			return ((Vector)(ref _offset)).Y;
		}
	}

	public double ViewportHeight
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ViewportHeight;
			}
			return ((Size)(ref _viewport)).Height;
		}
	}

	public double ViewportWidth
	{
		get
		{
			if (ActiveLayout != null && ActiveLayout is IScrollInfo)
			{
				return ((IScrollInfo)ActiveLayout).ViewportWidth;
			}
			return ((Size)(ref _viewport)).Width;
		}
	}

	public event RoutedEventHandler ActiveLayoutChanged
	{
		add
		{
			AddHandler(ActiveLayoutChangedEvent, value);
		}
		remove
		{
			RemoveHandler(ActiveLayoutChangedEvent, value);
		}
	}

	public event RoutedEventHandler SwitchAnimationBegun
	{
		add
		{
			AddHandler(SwitchAnimationBegunEvent, value);
		}
		remove
		{
			RemoveHandler(SwitchAnimationBegunEvent, value);
		}
	}

	public event RoutedEventHandler SwitchAnimationCompleted
	{
		add
		{
			AddHandler(SwitchAnimationCompletedEvent, value);
		}
		remove
		{
			RemoveHandler(SwitchAnimationCompletedEvent, value);
		}
	}

	public SwitchPanel()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		SetLayouts(new ObservableCollection<AnimationPanel>());
		base.Loaded += OnLoaded;
	}

	protected void SetActiveLayout(AnimationPanel value)
	{
		((DependencyObject)this).SetValue(ActiveLayoutPropertyKey, (object)value);
	}

	private static void OnActiveLayoutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnActiveLayoutChanged(e);
	}

	protected virtual void OnActiveLayoutChanged(DependencyPropertyChangedEventArgs e)
	{
		if (_currentLayoutPanel != null)
		{
			_currentLayoutPanel.DeactivateLayout();
		}
		_currentLayoutPanel = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as AnimationPanel;
		if (_currentLayoutPanel != null)
		{
			if (_currentLayoutPanel is IScrollInfo { ScrollOwner: not null } scrollInfo)
			{
				scrollInfo.ScrollOwner.InvalidateScrollInfo();
			}
			_currentLayoutPanel.ActivateLayout();
		}
		RaiseActiveLayoutChangedEvent();
		((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)9, (Delegate)(ThreadStart)delegate
		{
			UpdateSwitchTemplate();
		});
	}

	private static void OnActiveLayoutIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnActiveLayoutIndexChanged(e);
	}

	protected virtual void OnActiveLayoutIndexChanged(DependencyPropertyChangedEventArgs e)
	{
		SetActiveLayout((Layouts.Count == 0) ? null : Layouts[ActiveLayoutIndex]);
	}

	private static object CoerceActiveLayoutIndexValue(DependencyObject d, object value)
	{
		int count = (d as SwitchPanel).Layouts.Count;
		int num = (int)value;
		if (num < 0 && count > 0)
		{
			num = 0;
		}
		else if (num >= count)
		{
			num = count - 1;
		}
		return num;
	}

	protected void SetActiveSwitchTemplate(DataTemplate value)
	{
		((DependencyObject)this).SetValue(ActiveSwitchTemplatePropertyKey, (object)value);
	}

	private static void OnActiveSwitchTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnActiveSwitchTemplateChanged(e);
	}

	protected virtual void OnActiveSwitchTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
		if (_presenters.Count <= 0)
		{
			return;
		}
		DataTemplate template = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as DataTemplate;
		List<UIElement> list = new List<UIElement>(base.InternalChildren.Count);
		foreach (UIElement internalChild in base.InternalChildren)
		{
			if (internalChild != null)
			{
				list.Add(internalChild);
			}
		}
		foreach (SwitchPresenter presenter in _presenters)
		{
			if (presenter._switchRoot != null && list.Contains(presenter._switchRoot))
			{
				presenter.SwapTheTemplate(template, AreLayoutSwitchesAnimated);
			}
		}
	}

	protected void SetLayouts(ObservableCollection<AnimationPanel> value)
	{
		((DependencyObject)this).SetValue(LayoutsPropertyKey, (object)value);
	}

	private static void OnLayoutsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnLayoutsChanged(e);
	}

	protected virtual void OnLayoutsChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ObservableCollection<AnimationPanel>).CollectionChanged += LayoutsCollectionChanged;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ObservableCollection<AnimationPanel>).CollectionChanged -= LayoutsCollectionChanged;
		}
	}

	private static void OnSwitchTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPanel)(object)d).OnSwitchTemplateChanged(e);
	}

	protected virtual void OnSwitchTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateSwitchTemplate();
	}

	protected RoutedEventArgs RaiseActiveLayoutChangedEvent()
	{
		return RaiseActiveLayoutChangedEvent(this);
	}

	internal static RoutedEventArgs RaiseActiveLayoutChangedEvent(UIElement target)
	{
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = ActiveLayoutChangedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected RoutedEventArgs RaiseSwitchAnimationBegunEvent()
	{
		return RaiseSwitchAnimationBegunEvent(this);
	}

	private static RoutedEventArgs RaiseSwitchAnimationBegunEvent(UIElement target)
	{
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = SwitchAnimationBegunEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected RoutedEventArgs RaiseSwitchAnimationCompletedEvent()
	{
		return RaiseSwitchAnimationCompletedEvent(this);
	}

	private static RoutedEventArgs RaiseSwitchAnimationCompletedEvent(UIElement target)
	{
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = SwitchAnimationCompletedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		Size val = ((Layouts.Count == 0) ? _defaultLayoutCanvas : ActiveLayout).MeasureChildrenCore(base.InternalChildren, availableSize);
		if (IsScrollingPhysically)
		{
			Size viewport = availableSize;
			Size extent = val;
			Vector offset = default(Vector);
			((Vector)(ref offset))._002Ector(Math.Max(0.0, Math.Min(((Vector)(ref _offset)).X, ((Size)(ref extent)).Width - ((Size)(ref viewport)).Width)), Math.Max(0.0, Math.Min(((Vector)(ref _offset)).Y, ((Size)(ref extent)).Height - ((Size)(ref viewport)).Height)));
			SetScrollingData(viewport, extent, offset);
		}
		return val;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		AnimationPanel animationPanel = ((Layouts.Count == 0) ? _defaultLayoutCanvas : ActiveLayout);
		if (IsScrollingPhysically)
		{
			animationPanel.PhysicalScrollOffset = _offset;
		}
		else
		{
			animationPanel.PhysicalScrollOffset = ZeroVector;
		}
		return animationPanel.ArrangeChildrenCore(base.InternalChildren, finalSize);
	}

	protected override Visual GetVisualChild(int index)
	{
		if (HasLoaded && _currentLayoutPanel != null)
		{
			return _currentLayoutPanel.GetVisualChildInternal(index);
		}
		return base.GetVisualChild(index);
	}

	protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		if (visualAdded is UIElement)
		{
			if (_currentLayoutPanel == null || !_currentLayoutPanel.IsRemovingInternalChild)
			{
				foreach (AnimationPanel layout in Layouts)
				{
					layout.OnNotifyVisualChildAddedInternal(visualAdded as UIElement);
				}
			}
		}
		else if (visualRemoved is UIElement)
		{
			foreach (AnimationPanel layout2 in Layouts)
			{
				layout2.OnNotifyVisualChildRemovedInternal(visualRemoved as UIElement);
			}
		}
		if (_currentLayoutPanel != null)
		{
			_currentLayoutPanel.OnSwitchParentVisualChildrenChanged(visualAdded, visualRemoved);
		}
		else
		{
			base.OnVisualChildrenChanged(visualAdded, visualRemoved);
		}
	}

	internal void AddVisualChildInternal(Visual child)
	{
		AddVisualChild(child);
	}

	internal void BeginLayoutSwitch()
	{
		RaiseSwitchAnimationBegunEvent();
	}

	internal void EndLayoutSwitch()
	{
		RaiseSwitchAnimationCompletedEvent();
	}

	internal Visual GetVisualChildInternal(int index)
	{
		return base.GetVisualChild(index);
	}

	internal void OnVisualChildrenChangedInternal(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		base.OnVisualChildrenChanged(visualAdded, visualRemoved);
	}

	internal UIElement RegisterPresenter(SwitchPresenter presenter)
	{
		AnimationPanel panel;
		UIElement uIElement = AnimationPanel.FindAncestorChildOfAnimationPanel((DependencyObject)(object)presenter, out panel);
		if (uIElement != null)
		{
			_presenters.Add(presenter);
			presenter.SwapTheTemplate(ActiveSwitchTemplate, beginAnimation: false);
		}
		return uIElement;
	}

	internal void RemoveVisualChildInternal(Visual child)
	{
		RemoveVisualChild(child);
	}

	internal void UnregisterPresenter(SwitchPresenter presenter, DependencyObject container)
	{
		if (container != null)
		{
			_presenters.Remove(presenter);
			presenter.SwapTheTemplate(null, beginAnimation: false);
		}
	}

	internal void UpdateSwitchTemplate()
	{
		SetActiveSwitchTemplate((ActiveLayout == null || ActiveLayout.SwitchTemplate == null) ? SwitchTemplate : ActiveLayout.SwitchTemplate);
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		HasLoaded = true;
		InvalidateArrange();
	}

	private void LayoutsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action != NotifyCollectionChangedAction.Move)
		{
			if (e.NewItems != null)
			{
				foreach (AnimationPanel newItem in e.NewItems)
				{
					AddLogicalChild(newItem);
					newItem.SetSwitchParent(this);
					if (newItem is IScrollInfo)
					{
						((IScrollInfo)newItem).ScrollOwner = ScrollOwner;
					}
					if (!base.IsLoaded)
					{
						continue;
					}
					foreach (UIElement internalChild in base.InternalChildren)
					{
						if (internalChild != null)
						{
							newItem.OnNotifyVisualChildAddedInternal(internalChild);
						}
					}
				}
			}
			if (e.OldItems != null)
			{
				foreach (AnimationPanel oldItem in e.OldItems)
				{
					if (base.IsLoaded)
					{
						foreach (UIElement internalChild2 in base.InternalChildren)
						{
							if (internalChild2 != null)
							{
								oldItem.OnNotifyVisualChildRemovedInternal(internalChild2);
							}
						}
					}
					RemoveLogicalChild(oldItem);
					oldItem.SetSwitchParent(null);
					if (oldItem is IScrollInfo)
					{
						((IScrollInfo)oldItem).ScrollOwner = null;
					}
				}
			}
		}
		((DependencyObject)this).CoerceValue(ActiveLayoutIndexProperty);
		SetActiveLayout((Layouts.Count == 0) ? null : Layouts[ActiveLayoutIndex]);
	}

	private void ResetScrollInfo()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		_offset = default(Vector);
		_viewport = (_extent = new Size(0.0, 0.0));
	}

	private void OnScrollChange()
	{
		if (ScrollOwner != null)
		{
			ScrollOwner.InvalidateScrollInfo();
		}
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
		if (!DoubleHelper.AreVirtuallyEqual(viewport, _viewport) || !DoubleHelper.AreVirtuallyEqual(extent, _extent) || !DoubleHelper.AreVirtuallyEqual(offset, _computedOffset))
		{
			_viewport = viewport;
			_extent = extent;
			_computedOffset = offset;
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

	private int FindChildFromVisual(Visual vis)
	{
		int result = -1;
		DependencyObject val = (DependencyObject)(object)vis;
		DependencyObject val2 = null;
		do
		{
			val2 = val;
			val = VisualTreeHelper.GetParent(val2);
		}
		while (val != null && (object)val != this);
		if ((object)val == this)
		{
			result = base.Children.IndexOf((UIElement)(object)val2);
		}
		return result;
	}

	public void LineDown()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineDown();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + 1.0);
		}
	}

	public void LineLeft()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineLeft();
		}
		else
		{
			SetHorizontalOffset(VerticalOffset - 1.0);
		}
	}

	public void LineRight()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineRight();
		}
		else
		{
			SetHorizontalOffset(VerticalOffset + 1.0);
		}
	}

	public void LineUp()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).LineUp();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + 1.0);
		}
	}

	public Rect MakeVisible(Visual visual, Rect rectangle)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			return ((IScrollInfo)ActiveLayout).MakeVisible(visual, rectangle);
		}
		if (((Rect)(ref rectangle)).IsEmpty || visual == null || visual == this || !IsAncestorOf((DependencyObject)(object)visual))
		{
			return Rect.Empty;
		}
		rectangle = visual.TransformToAncestor(this).TransformBounds(rectangle);
		if (!IsScrollingPhysically)
		{
			return rectangle;
		}
		if (FindChildFromVisual(visual) == -1)
		{
			throw new ArgumentException("visual");
		}
		Rect itemRect = rectangle;
		((Rect)(ref itemRect)).Offset(_offset);
		if (ScrollHelper.ScrollLeastAmount(new Rect(new Point(((Vector)(ref _offset)).X, ((Vector)(ref _offset)).Y), _viewport), itemRect, out var newPhysOffset))
		{
			SetHorizontalOffset(((Vector)(ref newPhysOffset)).X);
			SetVerticalOffset(((Vector)(ref newPhysOffset)).Y);
		}
		return rectangle;
	}

	public void MouseWheelDown()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelDown();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + (double)SystemParameters.WheelScrollLines);
		}
	}

	public void MouseWheelLeft()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelLeft();
		}
		else
		{
			SetVerticalOffset(VerticalOffset - 3.0);
		}
	}

	public void MouseWheelRight()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelRight();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + 3.0);
		}
	}

	public void MouseWheelUp()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).MouseWheelUp();
		}
		else
		{
			SetVerticalOffset(VerticalOffset - (double)SystemParameters.WheelScrollLines);
		}
	}

	public void PageDown()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageDown();
		}
		else
		{
			SetVerticalOffset(VerticalOffset + ViewportHeight);
		}
	}

	public void PageLeft()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageLeft();
		}
		else
		{
			SetHorizontalOffset(HorizontalOffset - ViewportWidth);
		}
	}

	public void PageRight()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageRight();
		}
		else
		{
			SetHorizontalOffset(HorizontalOffset + ViewportWidth);
		}
	}

	public void PageUp()
	{
		if (ActiveLayout != null && ActiveLayout is IScrollInfo)
		{
			((IScrollInfo)ActiveLayout).PageUp();
		}
		else
		{
			SetVerticalOffset(VerticalOffset - ViewportHeight);
		}
	}

	public void SetHorizontalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "HorizontalOffset");
		offset = Math.Min(offset, ExtentWidth - ViewportWidth);
		if (!DoubleHelper.AreVirtuallyEqual(offset, ((Vector)(ref _offset)).X))
		{
			((Vector)(ref _offset)).X = offset;
			InvalidateMeasure();
		}
	}

	public void SetVerticalOffset(double offset)
	{
		offset = ValidateInputOffset(offset, "VerticalOffset");
		offset = Math.Min(offset, ExtentHeight - ViewportHeight);
		if (!DoubleHelper.AreVirtuallyEqual(offset, ((Vector)(ref _offset)).Y))
		{
			((Vector)(ref _offset)).Y = offset;
			InvalidateMeasure();
		}
	}
}
