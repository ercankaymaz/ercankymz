using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class AnchorablePaneTitle : Control
{
	private bool _isMouseDown;

	public static readonly DependencyProperty ModelProperty;

	private static readonly DependencyPropertyKey LayoutItemPropertyKey;

	public static readonly DependencyProperty LayoutItemProperty;

	public LayoutAnchorable Model
	{
		get
		{
			return (LayoutAnchorable)((DependencyObject)this).GetValue(ModelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ModelProperty, (object)value);
		}
	}

	public LayoutItem LayoutItem => (LayoutItem)((DependencyObject)this).GetValue(LayoutItemProperty);

	static AnchorablePaneTitle()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		ModelProperty = DependencyProperty.Register("Model", typeof(LayoutAnchorable), typeof(AnchorablePaneTitle), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(_OnModelChanged)));
		LayoutItemPropertyKey = DependencyProperty.RegisterReadOnly("LayoutItem", typeof(LayoutItem), typeof(AnchorablePaneTitle), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		LayoutItemProperty = LayoutItemPropertyKey.DependencyProperty;
		UIElement.IsHitTestVisibleProperty.OverrideMetadata(typeof(AnchorablePaneTitle), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		UIElement.FocusableProperty.OverrideMetadata(typeof(AnchorablePaneTitle), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(AnchorablePaneTitle), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(AnchorablePaneTitle)));
	}

	private static void _OnModelChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((AnchorablePaneTitle)(object)sender).OnModelChanged(e);
	}

	protected virtual void OnModelChanged(DependencyPropertyChangedEventArgs e)
	{
		if (Model != null)
		{
			SetLayoutItem(Model.Root.Manager.GetLayoutItemFromModel(Model));
		}
		else
		{
			SetLayoutItem(null);
		}
	}

	protected void SetLayoutItem(LayoutItem value)
	{
		((DependencyObject)this).SetValue(LayoutItemPropertyKey, (object)value);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (e.LeftButton != MouseButtonState.Pressed)
		{
			_isMouseDown = false;
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		base.OnMouseLeave(e);
		if (_isMouseDown && e.LeftButton == MouseButtonState.Pressed)
		{
			LayoutAnchorablePaneControl layoutAnchorablePaneControl = ((DependencyObject)(object)this).FindVisualAncestor<LayoutAnchorablePaneControl>();
			if (layoutAnchorablePaneControl != null)
			{
				LayoutAnchorablePane layoutAnchorablePane = layoutAnchorablePaneControl.Model as LayoutAnchorablePane;
				layoutAnchorablePane.Root.Manager.StartDraggingFloatingWindowForPane(layoutAnchorablePane);
			}
			else
			{
				LayoutAnchorable model = Model;
				model?.Root?.Manager?.StartDraggingFloatingWindowForContent(model);
			}
		}
		_isMouseDown = false;
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		if (e.Handled)
		{
			return;
		}
		bool flag = false;
		LayoutAnchorableFloatingWindow parentFloatingWindow = Model.FindParent<LayoutAnchorableFloatingWindow>();
		if (parentFloatingWindow != null)
		{
			flag = parentFloatingWindow.Descendents().OfType<LayoutAnchorablePane>().Count() == 1;
		}
		if (flag)
		{
			Model.Root.Manager.FloatingWindows.Single((LayoutFloatingWindowControl fwc) => fwc.Model == parentFloatingWindow).AttachDrag(onActivated: false);
		}
		else
		{
			_isMouseDown = true;
		}
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		_isMouseDown = false;
		base.OnMouseLeftButtonUp(e);
		if (Model != null)
		{
			Model.IsActive = true;
		}
	}

	private void OnHide()
	{
		Model.Hide();
	}

	private void OnToggleAutoHide()
	{
		Model.ToggleAutoHide();
	}
}
