using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorControl : Control, ILayoutControl
{
	private LayoutAnchorable _model;

	private DispatcherTimer _openUpTimer;

	private static readonly DependencyPropertyKey SidePropertyKey;

	public static readonly DependencyProperty SideProperty;

	public ILayoutElement Model => _model;

	public AnchorSide Side => (AnchorSide)((DependencyObject)this).GetValue(SideProperty);

	static LayoutAnchorControl()
	{
		SidePropertyKey = DependencyProperty.RegisterReadOnly("Side", typeof(AnchorSide), typeof(LayoutAnchorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AnchorSide.Left));
		SideProperty = SidePropertyKey.DependencyProperty;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutAnchorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutAnchorControl)));
		UIElement.IsHitTestVisibleProperty.AddOwner(typeof(LayoutAnchorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	internal LayoutAnchorControl(LayoutAnchorable model)
	{
		_model = model;
		_model.IsActiveChanged += _model_IsActiveChanged;
		_model.IsSelectedChanged += _model_IsSelectedChanged;
		SetSide(_model.FindParent<LayoutAnchorSide>().Side);
	}

	protected void SetSide(AnchorSide value)
	{
		((DependencyObject)this).SetValue(SidePropertyKey, (object)value);
	}

	private void _model_IsSelectedChanged(object sender, EventArgs e)
	{
		if (!_model.IsAutoHidden)
		{
			_model.IsSelectedChanged -= _model_IsSelectedChanged;
		}
		else if (_model.IsSelected)
		{
			_model.Root.Manager.ShowAutoHideWindow(this);
			_model.IsSelected = false;
		}
	}

	private void _model_IsActiveChanged(object sender, EventArgs e)
	{
		if (!_model.IsAutoHidden)
		{
			_model.IsActiveChanged -= _model_IsActiveChanged;
		}
		else if (_model.IsActive)
		{
			_model.Root.Manager.ShowAutoHideWindow(this);
		}
	}

	private void _openUpTimer_Tick(object sender, EventArgs e)
	{
		_openUpTimer.Tick -= _openUpTimer_Tick;
		_openUpTimer.Stop();
		_openUpTimer = null;
		_model.Root.Manager.ShowAutoHideWindow(this);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		if (!e.Handled)
		{
			_model.Root.Manager.ShowAutoHideWindow(this);
			_model.IsActive = true;
		}
	}

	protected override void OnMouseEnter(MouseEventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		base.OnMouseEnter(e);
		if (!e.Handled)
		{
			_openUpTimer = new DispatcherTimer((DispatcherPriority)2);
			_openUpTimer.Interval = TimeSpan.FromMilliseconds(400.0);
			_openUpTimer.Tick += _openUpTimer_Tick;
			_openUpTimer.Start();
		}
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		if (_openUpTimer != null)
		{
			_openUpTimer.Tick -= _openUpTimer_Tick;
			_openUpTimer.Stop();
			_openUpTimer = null;
		}
		base.OnMouseLeave(e);
	}
}
