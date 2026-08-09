using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using MS.Internal.Properties;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Interaction;

internal class AdornerLayer : Panel
{
	private delegate void ProcessZoomCallback();

	private class AdornerCollection : ICollection<UIElement>, IEnumerable<UIElement>, IEnumerable
	{
		private AdornerLayer _adornerLayer;

		public int Count
		{
			get
			{
				int childrenCount = VisualTreeHelper.GetChildrenCount((DependencyObject)(object)_adornerLayer);
				int num = 0;
				for (int i = 0; i < childrenCount; i++)
				{
					if (VisualTreeHelper.GetChild((DependencyObject)(object)_adornerLayer, i) is UIElement)
					{
						num++;
					}
				}
				return num;
			}
		}

		public bool IsReadOnly => false;

		internal AdornerCollection(AdornerLayer adornerLayer)
		{
			_adornerLayer = adornerLayer;
		}

		public void Add(UIElement item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			_adornerLayer.Add(item);
		}

		public void Clear()
		{
			_adornerLayer.Clear();
		}

		public bool Contains(UIElement item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			int childrenCount = VisualTreeHelper.GetChildrenCount((DependencyObject)(object)_adornerLayer);
			for (int i = 0; i < childrenCount; i++)
			{
				if ((object)VisualTreeHelper.GetChild((DependencyObject)(object)_adornerLayer, i) == item)
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(UIElement[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			int childrenCount = VisualTreeHelper.GetChildrenCount((DependencyObject)(object)_adornerLayer);
			for (int i = arrayIndex; i < childrenCount; i++)
			{
				DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)_adornerLayer, i);
				UIElement val = (UIElement)(object)((child is UIElement) ? child : null);
				if (val != null)
				{
					array.SetValue(val, arrayIndex++);
				}
			}
		}

		public bool Remove(UIElement item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return _adornerLayer.Remove(item);
		}

		public IEnumerator<UIElement> GetEnumerator()
		{
			int childCount = VisualTreeHelper.GetChildrenCount((DependencyObject)(object)_adornerLayer);
			for (int idx = 0; idx < childCount; idx++)
			{
				DependencyObject child = VisualTreeHelper.GetChild((DependencyObject)(object)_adornerLayer, idx);
				UIElement a = (UIElement)(object)((child is UIElement) ? child : null);
				if (a != null)
				{
					yield return a;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private AdornerCollection _adornerCollectionWrapper;

	private ViewService _viewService;

	private EditingContext _context;

	private DesignerView _currentDesignerView;

	private List<UIElement> _evaluateLayoutList;

	private bool _needEvaluateLayout;

	private bool _hasRendered;

	private Visibility _savedVisibility;

	private ProcessZoomCallback _processZoomCallback;

	private static Type TransformType = typeof(GeneralTransform);

	internal ICollection<UIElement> Adorners
	{
		get
		{
			if (_adornerCollectionWrapper == null)
			{
				_adornerCollectionWrapper = new AdornerCollection(this);
			}
			return _adornerCollectionWrapper;
		}
	}

	private DesignerView CurrentDesignerView
	{
		get
		{
			return _currentDesignerView;
		}
		set
		{
			if (_currentDesignerView != value)
			{
				if (_currentDesignerView != null)
				{
					_currentDesignerView.ZoomLevelChanged -= OnZoomLevelChanged;
				}
				_currentDesignerView = value;
				if (_currentDesignerView != null)
				{
					_currentDesignerView.ZoomLevelChanged += OnZoomLevelChanged;
				}
			}
		}
	}

	internal AdornerLayer()
	{
		((FrameworkElement)this).InheritanceBehavior = (InheritanceBehavior)2;
		DesignerProperties.SetIsInDesignMode((DependencyObject)(object)this, false);
	}

	private void Add(UIElement adorner)
	{
		if (LogicalTreeHelper.GetParent((DependencyObject)(object)adorner) != null)
		{
			throw new ArgumentException(MS.Internal.Properties.Resources.Error_AdornerHasParent);
		}
		InsertAdornerIntoVisualTree(adorner);
		if (VisualTreeHelper.GetParent((DependencyObject)(object)this) == null)
		{
			return;
		}
		if (_hasRendered)
		{
			if (_evaluateLayoutList == null)
			{
				_evaluateLayoutList = new List<UIElement>();
			}
			_evaluateLayoutList.Add(adorner);
		}
		else
		{
			_needEvaluateLayout = true;
		}
	}

	private void EvaluateLayout()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if ((int)((UIElement)this).Visibility != 2 && _hasRendered)
		{
			if (((Visual)this).VisualChildrenCount <= 0 || CurrentDesignerView == null)
			{
				return;
			}
			List<UIElement> list = null;
			foreach (UIElement internalChild in ((Panel)this).InternalChildren)
			{
				UIElement val = internalChild;
				AdornerLayout layout = AdornerProperties.GetLayout((DependencyObject)(object)val);
				if (!layout.EvaluateLayout(CurrentDesignerView, val))
				{
					if (list == null)
					{
						list = new List<UIElement>();
					}
					list.Add(val);
				}
			}
			if (list == null)
			{
				return;
			}
			{
				foreach (UIElement item in list)
				{
					((Panel)this).InternalChildren.Remove(item);
				}
				return;
			}
		}
		_needEvaluateLayout = true;
	}

	private void InsertAdornerIntoVisualTree(UIElement adorner)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		int num = 0;
		AdornerOrder order = AdornerProperties.GetOrder((DependencyObject)(object)adorner);
		foreach (UIElement internalChild in ((Panel)this).InternalChildren)
		{
			UIElement adorner2 = internalChild;
			AdornerOrder order2 = AdornerProperties.GetOrder((DependencyObject)(object)adorner2);
			if (order.CompareTo(order2) <= 0)
			{
				num++;
				continue;
			}
			break;
		}
		((Panel)this).InternalChildren.Insert(num, adorner);
	}

	internal void OnOrderChanged(UIElement adorner)
	{
		((Panel)this).InternalChildren.Remove(adorner);
		InsertAdornerIntoVisualTree(adorner);
		adorner.InvalidateVisual();
	}

	internal void OnLayoutChanged(UIElement adorner)
	{
		if (VisualTreeHelper.GetParent((DependencyObject)(object)this) != null)
		{
			AdornerProperties.GetLayout((DependencyObject)(object)adorner).EvaluateLayout(CurrentDesignerView, adorner);
			((UIElement)this).InvalidateArrange();
		}
	}

	protected override void OnVisualParentChanged(DependencyObject oldParent)
	{
		CurrentDesignerView = VisualTreeHelper.GetParent((DependencyObject)(object)this) as DesignerView;
		((FrameworkElement)this).OnVisualParentChanged(oldParent);
	}

	protected override Size ArrangeOverride(Size arrangeSize)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		Performance.StartTiming(PerformanceMarks.AdornerArrange);
		if (VisualTreeHelper.GetParent((DependencyObject)(object)this) != null)
		{
			if (_needEvaluateLayout)
			{
				_needEvaluateLayout = false;
				_evaluateLayoutList = null;
				EvaluateLayout();
			}
			else if (_evaluateLayoutList != null)
			{
				List<UIElement> evaluateLayoutList = _evaluateLayoutList;
				_evaluateLayoutList = null;
				DesignerView currentDesignerView = CurrentDesignerView;
				foreach (UIElement item in evaluateLayoutList)
				{
					AdornerProperties.GetLayout((DependencyObject)(object)item).EvaluateLayout(currentDesignerView, item);
				}
			}
			foreach (UIElement internalChild in ((Panel)this).InternalChildren)
			{
				UIElement adorner = internalChild;
				AdornerProperties.GetLayout((DependencyObject)(object)adorner).Arrange(adorner);
			}
		}
		Performance.StopTiming(PerformanceMarks.AdornerArrange);
		return arrangeSize;
	}

	protected override void OnRender(DrawingContext dc)
	{
		((Panel)this).OnRender(dc);
		_hasRendered = true;
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (((DependencyPropertyChangedEventArgs)(ref e)).Property == UIElement.VisibilityProperty && _processZoomCallback != null)
		{
			_savedVisibility = (Visibility)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
		((FrameworkElement)this).OnPropertyChanged(e);
	}

	private void Clear()
	{
		((Panel)this).InternalChildren.Clear();
		_evaluateLayoutList = null;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Performance.StartTiming(PerformanceMarks.AdornerMeasure);
		if (VisualTreeHelper.GetParent((DependencyObject)(object)this) != null)
		{
			foreach (UIElement internalChild in ((Panel)this).InternalChildren)
			{
				UIElement adorner = internalChild;
				AdornerProperties.GetLayout((DependencyObject)(object)adorner).Measure(adorner, constraint);
			}
		}
		Performance.StopTiming(PerformanceMarks.AdornerMeasure);
		return default(Size);
	}

	protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
	{
		((FrameworkElement)this).OnRenderSizeChanged(sizeInfo);
		EvaluateLayout();
	}

	private void OnLayoutUpdated(object sender, EventArgs args)
	{
		EvaluateLayout();
	}

	private void OnViewServiceAvailable(ViewService vs)
	{
		_context.Services.Unsubscribe<ViewService>(OnViewServiceAvailable);
		_viewService = vs;
		_viewService.LayoutUpdated += OnLayoutUpdated;
	}

	private void OnZoomLevelChanged(object sender, EventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (_processZoomCallback == null)
		{
			_savedVisibility = ((UIElement)this).Visibility;
			if (_hasRendered)
			{
				((UIElement)this).Visibility = (Visibility)2;
			}
			_processZoomCallback = ProcessZoom;
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)_processZoomCallback, (DispatcherPriority)4, new object[0]);
		}
	}

	private void ProcessZoom()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)this).Visibility = _savedVisibility;
		EvaluateLayout();
		((UIElement)this).InvalidateArrange();
		_processZoomCallback = null;
	}

	private bool Remove(UIElement adorner)
	{
		DependencyObject parent = LogicalTreeHelper.GetParent((DependencyObject)(object)adorner);
		if (parent == null)
		{
			return false;
		}
		if ((object)parent != this)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_AdornerNotParentedToThisAdornerLayer));
		}
		((Panel)this).InternalChildren.Remove(adorner);
		if (_evaluateLayoutList != null)
		{
			_evaluateLayoutList.Remove(adorner);
		}
		return true;
	}

	internal void SetContext(EditingContext context)
	{
		if (_context != null)
		{
			if (_viewService == null)
			{
				_context.Services.Unsubscribe<ViewService>(OnViewServiceAvailable);
			}
			else
			{
				_viewService.LayoutUpdated -= OnLayoutUpdated;
				_viewService = null;
			}
		}
		_context = context;
		if (_context != null)
		{
			_viewService = _context.Services.GetService<ViewService>();
			if (_viewService == null)
			{
				_context.Services.Subscribe<ViewService>(OnViewServiceAvailable);
			}
			else
			{
				_viewService.LayoutUpdated += OnLayoutUpdated;
			}
		}
	}
}
