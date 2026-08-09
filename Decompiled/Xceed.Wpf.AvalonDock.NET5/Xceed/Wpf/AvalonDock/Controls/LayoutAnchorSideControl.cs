using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorSideControl : Control, ILayoutControl
{
	private LayoutAnchorSide _model;

	private ObservableCollection<LayoutAnchorGroupControl> _childViews = new ObservableCollection<LayoutAnchorGroupControl>();

	private static readonly DependencyPropertyKey IsLeftSidePropertyKey;

	public static readonly DependencyProperty IsLeftSideProperty;

	private static readonly DependencyPropertyKey IsTopSidePropertyKey;

	public static readonly DependencyProperty IsTopSideProperty;

	private static readonly DependencyPropertyKey IsRightSidePropertyKey;

	public static readonly DependencyProperty IsRightSideProperty;

	private static readonly DependencyPropertyKey IsBottomSidePropertyKey;

	public static readonly DependencyProperty IsBottomSideProperty;

	public ILayoutElement Model => _model;

	public ObservableCollection<LayoutAnchorGroupControl> Children => _childViews;

	public bool IsLeftSide => (bool)((DependencyObject)this).GetValue(IsLeftSideProperty);

	public bool IsTopSide => (bool)((DependencyObject)this).GetValue(IsTopSideProperty);

	public bool IsRightSide => (bool)((DependencyObject)this).GetValue(IsRightSideProperty);

	public bool IsBottomSide => (bool)((DependencyObject)this).GetValue(IsBottomSideProperty);

	static LayoutAnchorSideControl()
	{
		IsLeftSidePropertyKey = DependencyProperty.RegisterReadOnly("IsLeftSide", typeof(bool), typeof(LayoutAnchorSideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsLeftSideProperty = IsLeftSidePropertyKey.DependencyProperty;
		IsTopSidePropertyKey = DependencyProperty.RegisterReadOnly("IsTopSide", typeof(bool), typeof(LayoutAnchorSideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsTopSideProperty = IsTopSidePropertyKey.DependencyProperty;
		IsRightSidePropertyKey = DependencyProperty.RegisterReadOnly("IsRightSide", typeof(bool), typeof(LayoutAnchorSideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsRightSideProperty = IsRightSidePropertyKey.DependencyProperty;
		IsBottomSidePropertyKey = DependencyProperty.RegisterReadOnly("IsBottomSide", typeof(bool), typeof(LayoutAnchorSideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsBottomSideProperty = IsBottomSidePropertyKey.DependencyProperty;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutAnchorSideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutAnchorSideControl)));
	}

	internal LayoutAnchorSideControl(LayoutAnchorSide model)
	{
		if (model == null)
		{
			throw new ArgumentNullException("model");
		}
		_model = model;
		CreateChildrenViews();
		_model.Children.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			OnModelChildrenCollectionChanged(e);
		};
		UpdateSide();
	}

	protected void SetIsLeftSide(bool value)
	{
		((DependencyObject)this).SetValue(IsLeftSidePropertyKey, (object)value);
	}

	protected void SetIsTopSide(bool value)
	{
		((DependencyObject)this).SetValue(IsTopSidePropertyKey, (object)value);
	}

	protected void SetIsRightSide(bool value)
	{
		((DependencyObject)this).SetValue(IsRightSidePropertyKey, (object)value);
	}

	protected void SetIsBottomSide(bool value)
	{
		((DependencyObject)this).SetValue(IsBottomSidePropertyKey, (object)value);
	}

	private void CreateChildrenViews()
	{
		DockingManager manager = _model.Root.Manager;
		foreach (LayoutAnchorGroup child in _model.Children)
		{
			_childViews.Add(manager.CreateUIElementForModel(child) as LayoutAnchorGroupControl);
		}
	}

	private void OnModelChildrenCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null && (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace))
		{
			foreach (object childModel in e.OldItems)
			{
				_childViews.Remove(_childViews.First((LayoutAnchorGroupControl cv) => cv.Model == childModel));
			}
		}
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			_childViews.Clear();
		}
		if (e.NewItems == null || (e.Action != NotifyCollectionChangedAction.Add && e.Action != NotifyCollectionChangedAction.Replace))
		{
			return;
		}
		DockingManager manager = _model.Root.Manager;
		int newStartingIndex = e.NewStartingIndex;
		foreach (LayoutAnchorGroup newItem in e.NewItems)
		{
			_childViews.Insert(newStartingIndex++, manager.CreateUIElementForModel(newItem) as LayoutAnchorGroupControl);
		}
	}

	private void UpdateSide()
	{
		switch (_model.Side)
		{
		case AnchorSide.Left:
			SetIsLeftSide(value: true);
			break;
		case AnchorSide.Top:
			SetIsTopSide(value: true);
			break;
		case AnchorSide.Right:
			SetIsRightSide(value: true);
			break;
		case AnchorSide.Bottom:
			SetIsBottomSide(value: true);
			break;
		}
	}
}
