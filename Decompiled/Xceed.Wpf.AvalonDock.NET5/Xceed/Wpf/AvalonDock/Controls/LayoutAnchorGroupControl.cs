using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorGroupControl : Control, ILayoutControl
{
	private ObservableCollection<LayoutAnchorControl> _childViews = new ObservableCollection<LayoutAnchorControl>();

	private LayoutAnchorGroup _model;

	public ObservableCollection<LayoutAnchorControl> Children => _childViews;

	public ILayoutElement Model => _model;

	static LayoutAnchorGroupControl()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutAnchorGroupControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutAnchorGroupControl)));
	}

	internal LayoutAnchorGroupControl(LayoutAnchorGroup model)
	{
		_model = model;
		CreateChildrenViews();
		_model.Children.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			OnModelChildrenCollectionChanged(e);
		};
	}

	private void CreateChildrenViews()
	{
		DockingManager manager = _model.Root.Manager;
		foreach (LayoutAnchorable child in _model.Children)
		{
			LayoutAnchorControl layoutAnchorControl = new LayoutAnchorControl(child);
			layoutAnchorControl.SetBinding(Control.TemplateProperty, new Binding(DockingManager.AnchorTemplateProperty.Name)
			{
				Source = manager
			});
			_childViews.Add(layoutAnchorControl);
		}
	}

	private void OnModelChildrenCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace) && e.OldItems != null)
		{
			foreach (object childModel in e.OldItems)
			{
				_childViews.Remove(_childViews.First((LayoutAnchorControl cv) => cv.Model == childModel));
			}
		}
		if (e.Action == NotifyCollectionChangedAction.Reset)
		{
			_childViews.Clear();
		}
		if ((e.Action != NotifyCollectionChangedAction.Add && e.Action != NotifyCollectionChangedAction.Replace) || e.NewItems == null)
		{
			return;
		}
		DockingManager manager = _model.Root.Manager;
		int newStartingIndex = e.NewStartingIndex;
		foreach (LayoutAnchorable newItem in e.NewItems)
		{
			LayoutAnchorControl layoutAnchorControl = new LayoutAnchorControl(newItem);
			layoutAnchorControl.SetBinding(Control.TemplateProperty, new Binding(DockingManager.AnchorTemplateProperty.Name)
			{
				Source = manager
			});
			_childViews.Insert(newStartingIndex++, layoutAnchorControl);
		}
	}
}
