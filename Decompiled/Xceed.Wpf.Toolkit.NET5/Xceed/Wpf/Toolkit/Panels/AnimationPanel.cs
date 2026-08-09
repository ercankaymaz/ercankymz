using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace Xceed.Wpf.Toolkit.Panels;

public abstract class AnimationPanel : PanelBase
{
	private sealed class ChildState
	{
		private enum CacheBits
		{
			IsAnimating = 1,
			HasEnterCompleted = 2,
			HasExitBegun = 4,
			HasExitCompleted = 8
		}

		public AnimationType Type;

		public DateTime BeginTimeStamp;

		public IterativeAnimator Animator;

		public Rect CurrentPlacement;

		public Rect TargetPlacement;

		public AnimationRate AnimationRate;

		public object PlacementArgs;

		private BitVector32 _cacheBits = new BitVector32(0);

		public bool HasEnterCompleted
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

		public bool HasExitBegun
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

		public bool HasExitCompleted
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

		public bool IsAnimating
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

		public ChildState(Rect currentRect)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			CurrentPlacement = currentRect;
			TargetPlacement = currentRect;
			BeginTimeStamp = DateTime.Now;
		}
	}

	internal enum AnimationType
	{
		Enter,
		Exit,
		Layout,
		Switch,
		Template
	}

	private enum CacheBits
	{
		IsActiveLayout = 1,
		IsSwitchInProgress = 2,
		EndSwitchOnAnimationCompleted = 0x10,
		IsRemovingInternalChild = 0x20,
		HasLoaded = 0x40,
		HasArranged = 0x80
	}

	private static readonly DependencyPropertyKey ChildStatePropertyKey = DependencyProperty.RegisterAttachedReadOnly("ChildState", typeof(ChildState), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	public static readonly DependencyProperty DefaultAnimationRateProperty = DependencyProperty.Register("DefaultAnimationRate", typeof(AnimationRate), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(AnimationRate)1.0), new ValidateValueCallback(ValidateDefaultAnimationRate));

	public static readonly DependencyProperty DefaultAnimatorProperty = DependencyProperty.Register("DefaultAnimator", typeof(IterativeAnimator), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Animators.Linear), new ValidateValueCallback(ValidateDefaultAnimator));

	public static readonly DependencyProperty EnterAnimationRateProperty = DependencyProperty.Register("EnterAnimationRate", typeof(AnimationRate), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty EnterAnimatorProperty = DependencyProperty.Register("EnterAnimator", typeof(IterativeAnimator), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty EnterFromProperty = DependencyProperty.RegisterAttached("EnterFrom", typeof(Rect?), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.Inherits));

	public static readonly DependencyProperty ExitAnimationRateProperty = DependencyProperty.Register("ExitAnimationRate", typeof(AnimationRate), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty ExitAnimatorProperty = DependencyProperty.Register("ExitAnimator", typeof(IterativeAnimator), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty ExitToProperty = DependencyProperty.RegisterAttached("ExitTo", typeof(Rect?), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.Inherits));

	public static readonly DependencyProperty LayoutAnimationRateProperty = DependencyProperty.Register("LayoutAnimationRate", typeof(AnimationRate), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty LayoutAnimatorProperty = DependencyProperty.Register("LayoutAnimator", typeof(IterativeAnimator), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	public static readonly DependencyProperty SwitchAnimationRateProperty = DependencyProperty.Register("SwitchAnimationRate", typeof(AnimationRate), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty SwitchAnimatorProperty = DependencyProperty.Register("SwitchAnimator", typeof(IterativeAnimator), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	private static readonly DependencyPropertyKey SwitchParentPropertyKey = DependencyProperty.RegisterReadOnly("SwitchParent", typeof(SwitchPanel), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSwitchParentChanged)));

	public static readonly DependencyProperty SwitchParentProperty = SwitchParentPropertyKey.DependencyProperty;

	public static readonly DependencyProperty SwitchTemplateProperty = DependencyProperty.Register("SwitchTemplate", typeof(DataTemplate), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSwitchTemplateChanged)));

	public static readonly DependencyProperty TemplateAnimationRateProperty = DependencyProperty.Register("TemplateAnimationRate", typeof(AnimationRate), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnimationRate.Default));

	public static readonly DependencyProperty TemplateAnimatorProperty = DependencyProperty.Register("TemplateAnimator", typeof(IterativeAnimator), typeof(AnimationPanel), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)IterativeAnimator.Default));

	private Vector _physicalScrollOffset;

	private int _animatingChildCount;

	public static readonly RoutedEvent AnimationBegunEvent = EventManager.RegisterRoutedEvent("AnimationBegun", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AnimationPanel));

	public static readonly RoutedEvent AnimationCompletedEvent = EventManager.RegisterRoutedEvent("AnimationCompleted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AnimationPanel));

	public static readonly RoutedEvent ChildEnteredEvent = EventManager.RegisterRoutedEvent("ChildEntered", RoutingStrategy.Bubble, typeof(ChildEnteredEventHandler), typeof(AnimationPanel));

	public static readonly RoutedEvent ChildEnteringEvent = EventManager.RegisterRoutedEvent("ChildEntering", RoutingStrategy.Bubble, typeof(ChildEnteringEventHandler), typeof(AnimationPanel));

	public static readonly RoutedEvent ChildExitedEvent = EventManager.RegisterRoutedEvent("ChildExited", RoutingStrategy.Bubble, typeof(ChildExitedEventHandler), typeof(AnimationPanel));

	public static readonly RoutedEvent ChildExitingEvent = EventManager.RegisterRoutedEvent("ChildExiting", RoutingStrategy.Bubble, typeof(ChildExitingEventHandler), typeof(AnimationPanel));

	public static readonly RoutedEvent SwitchLayoutActivatedEvent = EventManager.RegisterRoutedEvent("SwitchLayoutActivated", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(AnimationPanel));

	public static readonly RoutedEvent SwitchLayoutDeactivatedEvent = EventManager.RegisterRoutedEvent("SwitchLayoutDeactivated", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(AnimationPanel));

	private UIElementCollection _currentChildren;

	private readonly Collection<FrameworkElement> _animatingGrandchildren = new Collection<FrameworkElement>();

	private SwitchPanel _switchParent;

	private List<UIElement> _exitingChildren;

	private BitVector32 _cacheBits = new BitVector32(1);

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

	public SwitchPanel SwitchParent => (SwitchPanel)((DependencyObject)this).GetValue(SwitchParentProperty);

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

	public new Size DesiredSize
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			if (_switchParent == null)
			{
				return base.DesiredSize;
			}
			return _switchParent.DesiredSize;
		}
	}

	public new Size RenderSize
	{
		get
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			if (_switchParent == null)
			{
				return base.RenderSize;
			}
			return _switchParent.RenderSize;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			base.RenderSize = value;
		}
	}

	public bool IsActiveLayout
	{
		get
		{
			return _cacheBits[1];
		}
		private set
		{
			_cacheBits[1] = value;
		}
	}

	protected internal new UIElementCollection InternalChildren
	{
		get
		{
			if (_switchParent != null)
			{
				return _switchParent.ChildrenInternal;
			}
			return base.InternalChildren;
		}
	}

	protected override int VisualChildrenCount
	{
		get
		{
			if (!HasLoaded)
			{
				return base.VisualChildrenCount;
			}
			return InternalChildren.Count + ExitingChildren.Count;
		}
	}

	protected PanelBase ChildrensParent
	{
		get
		{
			if (_switchParent == null)
			{
				return this;
			}
			return _switchParent;
		}
	}

	internal int VisualChildrenCountInternal => VisualChildrenCount;

	internal Vector PhysicalScrollOffset
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _physicalScrollOffset;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_physicalScrollOffset = value;
		}
	}

	internal bool IsRemovingInternalChild
	{
		get
		{
			return _cacheBits[32];
		}
		private set
		{
			_cacheBits[32] = value;
		}
	}

	private int AnimatingChildCount
	{
		get
		{
			return _animatingChildCount;
		}
		set
		{
			if (_animatingChildCount == 0 && value > 0)
			{
				CompositionTarget.Rendering += OnRendering;
				RaiseAnimationBegunEvent();
			}
			if (_animatingChildCount != 0 && value == 0)
			{
				if (EndSwitchOnAnimationCompleted && _switchParent != null)
				{
					EndSwitchOnAnimationCompleted = false;
					_switchParent.EndLayoutSwitch();
				}
				CompositionTarget.Rendering -= OnRendering;
				RaiseAnimationCompletedEvent();
			}
			_animatingChildCount = value;
		}
	}

	private bool EndSwitchOnAnimationCompleted
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

	private bool HasArranged
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

	protected bool HasLoaded
	{
		get
		{
			if (_switchParent != null)
			{
				return _switchParent.HasLoaded;
			}
			return _cacheBits[64];
		}
		private set
		{
			_cacheBits[64] = value;
		}
	}

	private bool IsSwitchInProgress
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

	private ItemsControl ItemsOwner => ItemsControl.GetItemsOwner((DependencyObject)(object)((_switchParent == null) ? ((PanelBase)this) : ((PanelBase)_switchParent)));

	private List<UIElement> ExitingChildren
	{
		get
		{
			if (_switchParent != null)
			{
				return _switchParent.ExitingChildren;
			}
			if (_exitingChildren == null)
			{
				_exitingChildren = new List<UIElement>();
			}
			return _exitingChildren;
		}
	}

	public event RoutedEventHandler AnimationBegun
	{
		add
		{
			AddHandler(AnimationBegunEvent, value);
		}
		remove
		{
			RemoveHandler(AnimationBegunEvent, value);
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

	public event ChildEnteredEventHandler ChildEntered
	{
		add
		{
			AddHandler(ChildEnteredEvent, value);
		}
		remove
		{
			RemoveHandler(ChildEnteredEvent, value);
		}
	}

	public event ChildEnteringEventHandler ChildEntering
	{
		add
		{
			AddHandler(ChildEnteringEvent, value);
		}
		remove
		{
			RemoveHandler(ChildEnteringEvent, value);
		}
	}

	public event ChildExitedEventHandler ChildExited
	{
		add
		{
			AddHandler(ChildExitedEvent, value);
		}
		remove
		{
			RemoveHandler(ChildExitedEvent, value);
		}
	}

	public event ChildExitingEventHandler ChildExiting
	{
		add
		{
			AddHandler(ChildExitingEvent, value);
		}
		remove
		{
			RemoveHandler(ChildExitingEvent, value);
		}
	}

	public event RoutedEventHandler SwitchLayoutActivated
	{
		add
		{
			AddHandler(SwitchLayoutActivatedEvent, value);
		}
		remove
		{
			RemoveHandler(SwitchLayoutActivatedEvent, value);
		}
	}

	public event RoutedEventHandler SwitchLayoutDeactivated
	{
		add
		{
			AddHandler(SwitchLayoutDeactivatedEvent, value);
		}
		remove
		{
			RemoveHandler(SwitchLayoutDeactivatedEvent, value);
		}
	}

	public AnimationPanel()
	{
		base.Loaded += OnLoaded;
	}

	private static ChildState GetChildState(DependencyObject d)
	{
		return (ChildState)d.GetValue(ChildStatePropertyKey.DependencyProperty);
	}

	private static void SetChildState(DependencyObject d, ChildState value)
	{
		d.SetValue(ChildStatePropertyKey, (object)value);
	}

	private static bool ValidateDefaultAnimationRate(object value)
	{
		if ((AnimationRate)value == AnimationRate.Default)
		{
			throw new ArgumentException(ErrorMessages.GetMessage("DefaultAnimationRateAnimationRateDefault"));
		}
		return true;
	}

	private static bool ValidateDefaultAnimator(object value)
	{
		if (value == IterativeAnimator.Default)
		{
			throw new ArgumentException(ErrorMessages.GetMessage("DefaultAnimatorIterativeAnimationDefault"));
		}
		return true;
	}

	public static Rect? GetEnterFrom(DependencyObject d)
	{
		return (Rect?)d.GetValue(EnterFromProperty);
	}

	public static void SetEnterFrom(DependencyObject d, Rect? value)
	{
		d.SetValue(EnterFromProperty, (object)value);
	}

	public static Rect? GetExitTo(DependencyObject d)
	{
		return (Rect?)d.GetValue(ExitToProperty);
	}

	public static void SetExitTo(DependencyObject d, Rect? value)
	{
		d.SetValue(ExitToProperty, (object)value);
	}

	protected internal void SetSwitchParent(SwitchPanel value)
	{
		((DependencyObject)this).SetValue(SwitchParentPropertyKey, (object)value);
	}

	private static void OnSwitchParentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((AnimationPanel)(object)d).OnSwitchParentChanged(e);
	}

	protected virtual void OnSwitchParentChanged(DependencyPropertyChangedEventArgs e)
	{
		_switchParent = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as SwitchPanel;
	}

	private static void OnSwitchTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((AnimationPanel)(object)d).OnSwitchTemplateChanged(e);
	}

	protected virtual void OnSwitchTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
		if (_switchParent != null && _switchParent.ActiveLayout == this)
		{
			_switchParent.UpdateSwitchTemplate();
		}
	}

	protected RoutedEventArgs RaiseAnimationBegunEvent()
	{
		return RaiseAnimationBegunEvent((_switchParent != null) ? ((PanelBase)_switchParent) : ((PanelBase)this));
	}

	private static RoutedEventArgs RaiseAnimationBegunEvent(UIElement target)
	{
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = AnimationBegunEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected RoutedEventArgs RaiseAnimationCompletedEvent()
	{
		return RaiseAnimationCompletedEvent((_switchParent != null) ? ((PanelBase)_switchParent) : ((PanelBase)this));
	}

	private static RoutedEventArgs RaiseAnimationCompletedEvent(UIElement target)
	{
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = AnimationCompletedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected ChildEnteredEventArgs RaiseChildEnteredEvent(UIElement child, Rect arrangeRect)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return RaiseChildEnteredEvent(this, child, arrangeRect);
	}

	internal static ChildEnteredEventArgs RaiseChildEnteredEvent(UIElement target, UIElement child, Rect arrangeRect)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (target == null)
		{
			return null;
		}
		ChildEnteredEventArgs e = new ChildEnteredEventArgs(child, arrangeRect);
		e.RoutedEvent = ChildEnteredEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected ChildEnteringEventArgs RaiseChildEnteringEvent(UIElement child, Rect? EnterFrom, Rect ArrangeRect)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return RaiseChildEnteringEvent(this, child, EnterFrom, ArrangeRect);
	}

	private static ChildEnteringEventArgs RaiseChildEnteringEvent(UIElement target, UIElement child, Rect? EnterFrom, Rect ArrangeRect)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (target == null)
		{
			return null;
		}
		ChildEnteringEventArgs e = new ChildEnteringEventArgs(child, EnterFrom, ArrangeRect);
		e.RoutedEvent = ChildEnteringEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected ChildExitedEventArgs RaiseChildExitedEvent(UIElement child)
	{
		return RaiseChildExitedEvent(this, child);
	}

	private static ChildExitedEventArgs RaiseChildExitedEvent(UIElement target, UIElement child)
	{
		if (target == null)
		{
			return null;
		}
		ChildExitedEventArgs e = new ChildExitedEventArgs(child);
		e.RoutedEvent = ChildExitedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected ChildExitingEventArgs RaiseChildExitingEvent(UIElement child, Rect? exitTo, Rect arrangeRect)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return RaiseChildExitingEvent(this, child, exitTo, arrangeRect);
	}

	private static ChildExitingEventArgs RaiseChildExitingEvent(UIElement target, UIElement child, Rect? exitTo, Rect arrangeRect)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (target == null)
		{
			return null;
		}
		ChildExitingEventArgs e = new ChildExitingEventArgs(child, exitTo, arrangeRect);
		e.RoutedEvent = ChildExitingEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected RoutedEventArgs RaiseSwitchLayoutActivatedEvent()
	{
		return RaiseSwitchLayoutActivatedEvent(this);
	}

	internal static RoutedEventArgs RaiseSwitchLayoutActivatedEvent(UIElement target)
	{
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = SwitchLayoutActivatedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	protected RoutedEventArgs RaiseSwitchLayoutDeactivatedEvent()
	{
		return RaiseSwitchLayoutDeactivatedEvent(this);
	}

	internal static RoutedEventArgs RaiseSwitchLayoutDeactivatedEvent(UIElement target)
	{
		if (target == null)
		{
			return null;
		}
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = SwitchLayoutDeactivatedEvent;
		RoutedEventHelper.RaiseEvent((DependencyObject)(object)target, e);
		return e;
	}

	public new void InvalidateArrange()
	{
		if (_switchParent == null)
		{
			base.InvalidateArrange();
		}
		else
		{
			_switchParent.InvalidateArrange();
		}
	}

	public new void InvalidateMeasure()
	{
		if (_switchParent == null)
		{
			base.InvalidateMeasure();
		}
		else
		{
			_switchParent.InvalidateMeasure();
		}
	}

	public new void InvalidateVisual()
	{
		if (_switchParent == null)
		{
			base.InvalidateVisual();
		}
		else
		{
			_switchParent.InvalidateVisual();
		}
	}

	internal void ActivateLayout()
	{
		HasArranged = false;
		IsActiveLayout = true;
		OnSwitchLayoutActivated();
		RaiseSwitchLayoutActivatedEvent();
	}

	internal void BeginChildExit(UIElement child)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		ChildState childState = GetChildState((DependencyObject)(object)child);
		if (childState == null)
		{
			return;
		}
		childState.Type = AnimationType.Exit;
		childState.HasExitBegun = true;
		ExitingChildren.Add(child);
		if (_switchParent != null)
		{
			_switchParent.AddVisualChildInternal(child);
		}
		else
		{
			AddVisualChild(child);
		}
		ChildExitingEventArgs e = RaiseChildExitingEvent(child, child, GetExitTo((DependencyObject)(object)child), childState.CurrentPlacement);
		childState.Animator = GetEffectiveAnimator(AnimationType.Exit);
		if (childState.Animator != null)
		{
			childState.TargetPlacement = (e.ExitTo.HasValue ? e.ExitTo.Value : Rect.Empty);
			childState.BeginTimeStamp = DateTime.Now;
			if (childState.IsAnimating)
			{
				AnimatingChildCount--;
			}
			ArrangeChild(child, childState.TargetPlacement);
		}
		else
		{
			EndChildExit(child, childState);
		}
	}

	internal void BeginGrandchildAnimation(FrameworkElement grandchild, Rect currentRect, Rect placementRect)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		bool isDone = true;
		ChildState childState = new ChildState(currentRect);
		SetChildState((DependencyObject)(object)grandchild, childState);
		childState.Type = AnimationType.Switch;
		childState.BeginTimeStamp = DateTime.Now;
		childState.TargetPlacement = placementRect;
		childState.Animator = GetEffectiveAnimator(AnimationType.Template);
		if (childState.Animator != null && !((Rect)(ref childState.TargetPlacement)).IsEmpty)
		{
			AnimationRate animationRate = GetEffectiveAnimationRate(AnimationType.Template);
			childState.CurrentPlacement = childState.Animator.GetInitialChildPlacement(grandchild, childState.CurrentPlacement, childState.TargetPlacement, this, ref animationRate, out var placementArgs, out isDone);
			childState.AnimationRate = animationRate;
			childState.PlacementArgs = placementArgs;
		}
		childState.IsAnimating = !isDone;
		grandchild.Arrange(childState.IsAnimating ? childState.CurrentPlacement : childState.TargetPlacement);
		if (childState.IsAnimating)
		{
			_animatingGrandchildren.Add(grandchild);
			AnimatingChildCount++;
		}
		else
		{
			childState.CurrentPlacement = childState.TargetPlacement;
		}
	}

	internal void DeactivateLayout()
	{
		IsActiveLayout = false;
		AnimatingChildCount = 0;
		OnSwitchLayoutDeactivated();
		RaiseSwitchLayoutDeactivatedEvent();
	}

	internal static UIElement FindAncestorChildOfAnimationPanel(DependencyObject element, out AnimationPanel panel)
	{
		panel = null;
		if (element == null)
		{
			return null;
		}
		DependencyObject parent = VisualTreeHelper.GetParent(element);
		if (parent == null)
		{
			return null;
		}
		if (parent is AnimationPanel || parent is SwitchPanel)
		{
			panel = ((parent is SwitchPanel) ? (parent as SwitchPanel)._currentLayoutPanel : (parent as AnimationPanel));
			return element as UIElement;
		}
		return FindAncestorChildOfAnimationPanel(parent, out panel);
	}

	internal Dictionary<string, Rect> GetNewLocationsBasedOnTargetPlacement(SwitchPresenter presenter, UIElement parent)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		ChildState childState = GetChildState((DependencyObject)(object)parent);
		bool flag = childState.CurrentPlacement != childState.TargetPlacement && childState.IsAnimating;
		if (flag)
		{
			parent.Arrange(childState.TargetPlacement);
		}
		Dictionary<string, Rect> dictionary = new Dictionary<string, Rect>();
		foreach (KeyValuePair<string, FrameworkElement> knownID in presenter._knownIDs)
		{
			Size renderSize = knownID.Value.RenderSize;
			Point[] array = (Point[])(object)new Point[2]
			{
				default(Point),
				new Point(((Size)(ref renderSize)).Width, ((Size)(ref renderSize)).Height)
			};
			Matrix matrix = (knownID.Value.TransformToAncestor(VisualTreeHelper.GetParent((DependencyObject)(object)knownID.Value) as Visual) as MatrixTransform).Matrix;
			((Matrix)(ref matrix)).Transform(array);
			dictionary[knownID.Key] = new Rect(array[0], array[1]);
		}
		if (flag)
		{
			parent.Arrange(childState.CurrentPlacement);
		}
		return dictionary;
	}

	internal Visual GetVisualChildInternal(int index)
	{
		return GetVisualChild(index);
	}

	internal void OnNotifyVisualChildAddedInternal(UIElement child)
	{
		OnNotifyVisualChildAdded(child);
	}

	internal void OnNotifyVisualChildRemovedInternal(UIElement child)
	{
		OnNotifyVisualChildRemoved(child);
	}

	internal Size MeasureChildrenCore(UIElementCollection children, Size constraint)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		_currentChildren = children;
		return MeasureChildrenOverride(_currentChildren, constraint);
	}

	internal Size ArrangeChildrenCore(UIElementCollection children, Size finalSize)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		if (_currentChildren != children)
		{
			_currentChildren = children;
		}
		AnimatingChildCount = 0;
		_animatingGrandchildren.Clear();
		Size result;
		try
		{
			if (!HasArranged && _switchParent != null)
			{
				IsSwitchInProgress = true;
				_switchParent.BeginLayoutSwitch();
			}
			result = ArrangeChildrenOverride(_currentChildren, finalSize);
			if (ExitingChildren.Count > 0)
			{
				AnimatingChildCount += ExitingChildren.Count;
				UpdateExitingChildren();
			}
			if (IsSwitchInProgress)
			{
				if (AnimatingChildCount == 0)
				{
					_switchParent.EndLayoutSwitch();
				}
				else
				{
					EndSwitchOnAnimationCompleted = true;
				}
			}
		}
		finally
		{
			HasArranged = true;
			IsSwitchInProgress = false;
		}
		return result;
	}

	internal void OnSwitchParentVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		OnVisualChildrenChanged(visualAdded, visualRemoved);
	}

	protected sealed override Size MeasureOverride(Size constraint)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return MeasureChildrenCore(InternalChildren, constraint);
	}

	protected abstract Size MeasureChildrenOverride(UIElementCollection children, Size constraint);

	protected sealed override Size ArrangeOverride(Size finalSize)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return ArrangeChildrenCore(_currentChildren, finalSize);
	}

	protected abstract Size ArrangeChildrenOverride(UIElementCollection children, Size finalSize);

	protected void ArrangeChild(UIElement child, Rect placementRect)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (!((Rect)(ref placementRect)).IsEmpty)
		{
			Vector physicalScrollOffset = PhysicalScrollOffset;
			if (((Vector)(ref physicalScrollOffset)).Length > 0.0)
			{
				((Rect)(ref placementRect)).Offset(-PhysicalScrollOffset);
			}
		}
		if (HasLoaded)
		{
			if (BeginChildAnimation(child, placementRect))
			{
				AnimatingChildCount++;
			}
		}
		else
		{
			child.Arrange(placementRect);
		}
	}

	protected new void AddVisualChild(Visual child)
	{
		if (_switchParent == null)
		{
			base.AddVisualChild(child);
		}
		else
		{
			_switchParent.AddVisualChildInternal(child);
		}
	}

	protected override Visual GetVisualChild(int index)
	{
		if (index < 0)
		{
			throw new IndexOutOfRangeException();
		}
		if (index >= InternalChildren.Count)
		{
			int num = index - InternalChildren.Count;
			if (num < 0 || num >= ExitingChildren.Count)
			{
				throw new IndexOutOfRangeException();
			}
			return ExitingChildren[num];
		}
		if (_switchParent != null)
		{
			return _switchParent.GetVisualChildInternal(index);
		}
		return base.GetVisualChild(index);
	}

	protected virtual void OnNotifyVisualChildAdded(UIElement child)
	{
	}

	protected virtual void OnNotifyVisualChildRemoved(UIElement child)
	{
	}

	protected virtual void OnSwitchLayoutActivated()
	{
	}

	protected virtual void OnSwitchLayoutDeactivated()
	{
	}

	protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		if (!IsRemovingInternalChild && visualRemoved is UIElement && visualRemoved != null)
		{
			IsRemovingInternalChild = true;
			try
			{
				BeginChildExit(visualRemoved as UIElement);
			}
			finally
			{
				IsRemovingInternalChild = false;
			}
		}
		if (_switchParent == null)
		{
			if (visualAdded is UIElement)
			{
				OnNotifyVisualChildAdded(visualAdded as UIElement);
			}
			else if (visualRemoved is UIElement)
			{
				OnNotifyVisualChildRemoved(visualRemoved as UIElement);
			}
			base.OnVisualChildrenChanged(visualAdded, visualRemoved);
		}
		else
		{
			_switchParent.OnVisualChildrenChangedInternal(visualAdded, visualRemoved);
		}
	}

	protected new void RemoveVisualChild(Visual child)
	{
		if (_switchParent == null)
		{
			base.RemoveVisualChild(child);
		}
		else
		{
			_switchParent.RemoveVisualChildInternal(child);
		}
	}

	protected int FindChildFromVisual(Visual vis)
	{
		int result = -1;
		DependencyObject val = (DependencyObject)(object)vis;
		DependencyObject val2 = null;
		do
		{
			val2 = val;
			val = VisualTreeHelper.GetParent(val2);
		}
		while (val != null && (object)val != ChildrensParent);
		if ((object)val == ChildrensParent)
		{
			result = ChildrensParent.Children.IndexOf((UIElement)(object)val2);
		}
		return result;
	}

	private bool BeginChildAnimation(UIElement child, Rect placementRect)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		bool newStateCreated;
		ChildState childState = EnsureChildState(child, placementRect, out newStateCreated);
		if (childState.HasEnterCompleted)
		{
			if (childState.Type != AnimationType.Exit)
			{
				childState.BeginTimeStamp = DateTime.Now;
				childState.Type = (IsSwitchInProgress ? AnimationType.Switch : AnimationType.Layout);
				childState.TargetPlacement = placementRect;
			}
		}
		else
		{
			childState.BeginTimeStamp = DateTime.Now;
			childState.TargetPlacement = placementRect;
		}
		if (!childState.HasExitCompleted)
		{
			bool isDone = true;
			if (childState.Type != AnimationType.Enter)
			{
				childState.Animator = GetEffectiveAnimator(childState.Type);
			}
			if (childState.Animator != null && !((Rect)(ref childState.TargetPlacement)).IsEmpty)
			{
				AnimationRate animationRate = GetEffectiveAnimationRate(childState.Type);
				childState.CurrentPlacement = childState.Animator.GetInitialChildPlacement(child, childState.CurrentPlacement, childState.TargetPlacement, this, ref animationRate, out var placementArgs, out isDone);
				childState.AnimationRate = animationRate;
				childState.PlacementArgs = placementArgs;
			}
			childState.IsAnimating = !isDone;
			if (!childState.IsAnimating)
			{
				childState.CurrentPlacement = childState.TargetPlacement;
			}
		}
		if (!childState.IsAnimating)
		{
			UpdateTrueArrange(child, childState);
		}
		return childState.IsAnimating;
	}

	private void BeginChildEnter(UIElement child, ChildState state)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		state.Type = AnimationType.Enter;
		ChildEnteringEventArgs e = RaiseChildEnteringEvent(child, child, GetEnterFrom((DependencyObject)(object)child), state.CurrentPlacement);
		state.Animator = GetEffectiveAnimator(AnimationType.Enter);
		if (state.Animator != null && e.EnterFrom.HasValue)
		{
			state.CurrentPlacement = e.EnterFrom.Value;
			state.BeginTimeStamp = DateTime.Now;
		}
	}

	private void EndChildEnter(UIElement child, ChildState state)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		state.HasEnterCompleted = true;
		RaiseChildEnteredEvent(child, child, state.TargetPlacement);
	}

	private void EndChildExit(UIElement child, ChildState state)
	{
		state.HasExitCompleted = true;
		RaiseChildExitedEvent(child, child);
		if (ExitingChildren.Contains(child))
		{
			IsRemovingInternalChild = true;
			try
			{
				if (_switchParent != null)
				{
					_switchParent.RemoveVisualChildInternal(child);
				}
				else
				{
					RemoveVisualChild(child);
				}
			}
			finally
			{
				IsRemovingInternalChild = false;
			}
			ExitingChildren.Remove(child);
		}
		((DependencyObject)child).ClearValue(ChildStatePropertyKey);
	}

	private ChildState EnsureChildState(UIElement child, Rect placementRect, out bool newStateCreated)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		newStateCreated = false;
		ChildState childState = GetChildState((DependencyObject)(object)child);
		if (childState == null)
		{
			childState = new ChildState(placementRect);
			SetChildState((DependencyObject)(object)child, childState);
			BeginChildEnter(child, childState);
			newStateCreated = true;
		}
		return childState;
	}

	internal AnimationRate GetEffectiveAnimationRate(AnimationType animationType)
	{
		AnimationRate result = ((_switchParent == null) ? DefaultAnimationRate : _switchParent.DefaultAnimationRate);
		switch (animationType)
		{
		case AnimationType.Enter:
			if (EnterAnimationRate != AnimationRate.Default)
			{
				result = EnterAnimationRate;
			}
			else if (_switchParent != null && _switchParent.EnterAnimationRate != AnimationRate.Default)
			{
				result = _switchParent.EnterAnimationRate;
			}
			break;
		case AnimationType.Exit:
			if (ExitAnimationRate != AnimationRate.Default)
			{
				result = ExitAnimationRate;
			}
			else if (_switchParent != null && _switchParent.ExitAnimationRate != AnimationRate.Default)
			{
				result = _switchParent.ExitAnimationRate;
			}
			break;
		case AnimationType.Layout:
			if (LayoutAnimationRate != AnimationRate.Default)
			{
				result = LayoutAnimationRate;
			}
			else if (_switchParent != null && _switchParent.LayoutAnimationRate != AnimationRate.Default)
			{
				result = _switchParent.LayoutAnimationRate;
			}
			break;
		case AnimationType.Switch:
			if (SwitchAnimationRate != AnimationRate.Default)
			{
				result = SwitchAnimationRate;
			}
			else if (_switchParent != null && _switchParent.SwitchAnimationRate != AnimationRate.Default)
			{
				result = _switchParent.SwitchAnimationRate;
			}
			break;
		case AnimationType.Template:
			if (TemplateAnimationRate != AnimationRate.Default)
			{
				result = TemplateAnimationRate;
			}
			else if (_switchParent != null && _switchParent.TemplateAnimationRate != AnimationRate.Default)
			{
				result = _switchParent.TemplateAnimationRate;
			}
			break;
		}
		return result;
	}

	private IterativeAnimator GetEffectiveAnimator(AnimationType animationType)
	{
		IterativeAnimator result = ((_switchParent == null) ? DefaultAnimator : _switchParent.DefaultAnimator);
		switch (animationType)
		{
		case AnimationType.Enter:
			if (EnterAnimator != IterativeAnimator.Default || (_switchParent != null && _switchParent.EnterAnimator != IterativeAnimator.Default))
			{
				result = ((EnterAnimator == IterativeAnimator.Default) ? _switchParent.EnterAnimator : EnterAnimator);
			}
			break;
		case AnimationType.Exit:
			if (ExitAnimator != IterativeAnimator.Default || (_switchParent != null && _switchParent.ExitAnimator != IterativeAnimator.Default))
			{
				result = ((ExitAnimator == IterativeAnimator.Default) ? _switchParent.ExitAnimator : ExitAnimator);
			}
			break;
		case AnimationType.Layout:
			if (LayoutAnimator != IterativeAnimator.Default || (_switchParent != null && _switchParent.LayoutAnimator != IterativeAnimator.Default))
			{
				result = ((LayoutAnimator == IterativeAnimator.Default) ? _switchParent.LayoutAnimator : LayoutAnimator);
			}
			break;
		case AnimationType.Switch:
			if (_switchParent != null && !_switchParent.AreLayoutSwitchesAnimated)
			{
				result = null;
			}
			else if (SwitchAnimator != IterativeAnimator.Default || _switchParent.SwitchAnimator != IterativeAnimator.Default)
			{
				result = ((SwitchAnimator == IterativeAnimator.Default) ? _switchParent.SwitchAnimator : SwitchAnimator);
			}
			break;
		case AnimationType.Template:
			if (TemplateAnimator != IterativeAnimator.Default || (_switchParent != null && _switchParent.TemplateAnimator != IterativeAnimator.Default))
			{
				result = ((TemplateAnimator == IterativeAnimator.Default) ? _switchParent.TemplateAnimator : TemplateAnimator);
			}
			break;
		}
		return result;
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		HasLoaded = true;
		InvalidateArrange();
	}

	private void OnRendering(object sender, EventArgs e)
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		if (!IsActiveLayout)
		{
			return;
		}
		if (_currentChildren != null)
		{
			foreach (UIElement currentChild in _currentChildren)
			{
				if (currentChild == null)
				{
					continue;
				}
				ChildState childState = GetChildState((DependencyObject)(object)currentChild);
				if (childState == null)
				{
					continue;
				}
				TimeSpan currentTime = DateTime.Now.Subtract(childState.BeginTimeStamp);
				if (childState.IsAnimating)
				{
					childState.CurrentPlacement = childState.Animator.GetNextChildPlacement(currentChild, currentTime, childState.CurrentPlacement, childState.TargetPlacement, this, childState.AnimationRate, ref childState.PlacementArgs, out var isDone);
					childState.IsAnimating = !isDone;
					UpdateTrueArrange(currentChild, childState);
					if (!childState.IsAnimating)
					{
						AnimatingChildCount--;
					}
				}
			}
		}
		foreach (FrameworkElement animatingGrandchild in _animatingGrandchildren)
		{
			ChildState childState2 = GetChildState((DependencyObject)(object)animatingGrandchild);
			if (childState2 != null && childState2.IsAnimating)
			{
				TimeSpan currentTime2 = DateTime.Now.Subtract(childState2.BeginTimeStamp);
				childState2.CurrentPlacement = childState2.Animator.GetNextChildPlacement(animatingGrandchild, currentTime2, childState2.CurrentPlacement, childState2.TargetPlacement, this, childState2.AnimationRate, ref childState2.PlacementArgs, out var isDone2);
				childState2.IsAnimating = !isDone2;
				Rect finalRect = (childState2.IsAnimating ? childState2.CurrentPlacement : childState2.TargetPlacement);
				animatingGrandchild.Arrange(finalRect);
				if (!childState2.IsAnimating)
				{
					AnimatingChildCount--;
				}
			}
		}
		UpdateExitingChildren();
		if (AnimatingChildCount == 0)
		{
			_animatingGrandchildren.Clear();
		}
	}

	private void UpdateExitingChildren()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		if (ExitingChildren.Count <= 0)
		{
			return;
		}
		foreach (UIElement item in new List<UIElement>(ExitingChildren))
		{
			if (item == null)
			{
				continue;
			}
			ChildState childState = GetChildState((DependencyObject)(object)item);
			if (childState == null)
			{
				continue;
			}
			TimeSpan currentTime = DateTime.Now.Subtract(childState.BeginTimeStamp);
			if (childState.IsAnimating)
			{
				childState.CurrentPlacement = childState.Animator.GetNextChildPlacement(item, currentTime, childState.CurrentPlacement, childState.TargetPlacement, this, childState.AnimationRate, ref childState.PlacementArgs, out var isDone);
				childState.IsAnimating = !isDone;
				UpdateTrueArrange(item, childState);
				if (!childState.IsAnimating)
				{
					AnimatingChildCount--;
				}
			}
		}
	}

	private void UpdateTrueArrange(UIElement child, ChildState state)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (!((Rect)(ref state.TargetPlacement)).IsEmpty)
		{
			child.Arrange((state.IsAnimating && state.Animator != null) ? state.CurrentPlacement : state.TargetPlacement);
		}
		if (!state.IsAnimating && !state.HasEnterCompleted)
		{
			EndChildEnter(child, state);
		}
		if (!state.IsAnimating && state.HasExitBegun)
		{
			EndChildExit(child, state);
		}
	}
}
