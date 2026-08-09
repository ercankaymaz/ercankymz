using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

public class SwitchPresenter : FrameworkElement
{
	private struct DelaySwitchParams
	{
		public DataTemplate Template;

		public bool BeginAnimation;
	}

	public static readonly DependencyProperty DelaySwitchProperty = DependencyProperty.Register("DelaySwitch", typeof(bool), typeof(SwitchPresenter), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty DelayPriorityProperty = DependencyProperty.Register("DelayPriority", typeof(DispatcherPriority), typeof(SwitchPresenter), (PropertyMetadata)(object)new UIPropertyMetadata((object)(DispatcherPriority)4));

	internal static readonly DependencyProperty SwitchParentProperty = DependencyProperty.Register("SwitchParent", typeof(SwitchPanel), typeof(SwitchPresenter), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSwitchParentChanged)));

	internal UIElement _switchRoot;

	internal Dictionary<string, FrameworkElement> _knownIDs = new Dictionary<string, FrameworkElement>();

	private ContentPresenter _contentPresenter = new ContentPresenter();

	private bool _isMeasured;

	private DataTemplate _currentTemplate;

	public bool DelaySwitch
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DelaySwitchProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DelaySwitchProperty, (object)value);
		}
	}

	public DispatcherPriority DelayPriority
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (DispatcherPriority)((DependencyObject)this).GetValue(DelayPriorityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(DelayPriorityProperty, (object)value);
		}
	}

	internal SwitchPanel SwitchParent
	{
		get
		{
			return (SwitchPanel)((DependencyObject)this).GetValue(SwitchParentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SwitchParentProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount => 1;

	public SwitchPresenter()
	{
		AddVisualChild(_contentPresenter);
		base.Loaded += SwitchPresenter_Loaded;
		base.Unloaded += SwitchPresenter_Unloaded;
	}

	private static void OnSwitchParentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((SwitchPresenter)(object)d).OnSwitchParentChanged(e);
	}

	protected virtual void OnSwitchParentChanged(DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as SwitchPanel).UnregisterPresenter(this, (DependencyObject)(object)_switchRoot);
			_switchRoot = null;
			BindingOperations.ClearAllBindings((DependencyObject)(object)_contentPresenter);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			_contentPresenter.SetBinding(ContentPresenter.ContentProperty, new Binding());
			_switchRoot = (((DependencyPropertyChangedEventArgs)(ref e)).NewValue as SwitchPanel).RegisterPresenter(this);
		}
	}

	private static void OnLoaded(object sender, RoutedEventArgs e)
	{
		SwitchPresenter switchPresenter = sender as SwitchPresenter;
		if (switchPresenter._switchRoot == null)
		{
			switchPresenter.SwitchParent = VisualTreeHelperEx.FindAncestorByType((DependencyObject)(object)switchPresenter, typeof(SwitchPanel), specificTypeOnly: false) as SwitchPanel;
		}
	}

	private static void OnUnloaded(object sender, RoutedEventArgs e)
	{
		(sender as SwitchPresenter).SwitchParent = null;
	}

	internal void RegisterID(string id, FrameworkElement element)
	{
		if (element != null)
		{
			_knownIDs[id] = element;
		}
	}

	internal void SwapTheTemplate(DataTemplate template, bool beginAnimation)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (DelaySwitch)
		{
			_currentTemplate = template;
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)new Action<DelaySwitchParams>(OnSwapTemplate), DelayPriority, new object[1]
			{
				new DelaySwitchParams
				{
					Template = template,
					BeginAnimation = beginAnimation
				}
			});
		}
		else
		{
			DoSwapTemplate(template, beginAnimation);
		}
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (!_isMeasured && _switchRoot == null)
		{
			OnLoaded(this, null);
			_isMeasured = true;
		}
		_contentPresenter.Measure(constraint);
		return _contentPresenter.DesiredSize;
	}

	protected override Size ArrangeOverride(Size arrangeBounds)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		_contentPresenter.Arrange(new Rect(arrangeBounds));
		return arrangeBounds;
	}

	protected override Visual GetVisualChild(int index)
	{
		if (index != 0)
		{
			throw new ArgumentOutOfRangeException("index", index, "");
		}
		return _contentPresenter;
	}

	private void OnSwapTemplate(DelaySwitchParams data)
	{
		if (data.Template == _currentTemplate)
		{
			DoSwapTemplate(data.Template, data.BeginAnimation);
			_currentTemplate = null;
		}
	}

	private void DoSwapTemplate(DataTemplate template, bool beginAnimation)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, Rect> knownLocations = null;
		if (beginAnimation && _knownIDs.Count > 0)
		{
			knownLocations = new Dictionary<string, Rect>();
			foreach (KeyValuePair<string, FrameworkElement> knownID in _knownIDs)
			{
				Size renderSize = knownID.Value.RenderSize;
				Matrix matrix = (knownID.Value.TransformToAncestor(SwitchParent) as MatrixTransform).Matrix;
				Point[] array = (Point[])(object)new Point[2]
				{
					default(Point),
					new Point(((Size)(ref renderSize)).Width, ((Size)(ref renderSize)).Height)
				};
				((Matrix)(ref matrix)).Transform(array);
				knownLocations[knownID.Key] = new Rect(array[0], array[1]);
			}
		}
		_knownIDs.Clear();
		_contentPresenter.ContentTemplate = template;
		if (template != null)
		{
			_contentPresenter.ApplyTemplate();
		}
		if (knownLocations == null || _knownIDs.Count <= 0)
		{
			return;
		}
		Dictionary<string, Rect> newLocations = null;
		RoutedEventHandler onLoaded = null;
		onLoaded = delegate(object sender, RoutedEventArgs e)
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			FrameworkElement frameworkElement = sender as FrameworkElement;
			frameworkElement.Loaded -= onLoaded;
			string iD = SwitchTemplate.GetID((DependencyObject)(object)frameworkElement);
			if (knownLocations.ContainsKey(iD))
			{
				if (newLocations == null)
				{
					newLocations = SwitchParent.ActiveLayout.GetNewLocationsBasedOnTargetPlacement(this, _switchRoot);
				}
				if (VisualTreeHelper.GetParent((DependencyObject)(object)frameworkElement) is UIElement descendant)
				{
					Rect val = knownLocations[iD];
					Point[] array2 = (Point[])(object)new Point[2]
					{
						((Rect)(ref val)).TopLeft,
						((Rect)(ref val)).BottomRight
					};
					Matrix matrix2 = (SwitchParent.TransformToDescendant(descendant) as MatrixTransform).Matrix;
					((Matrix)(ref matrix2)).Transform(array2);
					Rect currentRect = default(Rect);
					((Rect)(ref currentRect))._002Ector(array2[0], array2[1]);
					Rect placementRect = newLocations[iD];
					SwitchParent.ActiveLayout.BeginGrandchildAnimation(frameworkElement, currentRect, placementRect);
				}
			}
		};
		foreach (KeyValuePair<string, FrameworkElement> knownID2 in _knownIDs)
		{
			knownID2.Value.Loaded += onLoaded;
		}
	}

	private void SwitchPresenter_Unloaded(object sender, RoutedEventArgs e)
	{
		SwitchParent = null;
	}

	private void SwitchPresenter_Loaded(object sender, RoutedEventArgs e)
	{
		if (_switchRoot == null)
		{
			SwitchParent = VisualTreeHelperEx.FindAncestorByType((DependencyObject)(object)this, typeof(SwitchPanel), specificTypeOnly: false) as SwitchPanel;
		}
	}
}
