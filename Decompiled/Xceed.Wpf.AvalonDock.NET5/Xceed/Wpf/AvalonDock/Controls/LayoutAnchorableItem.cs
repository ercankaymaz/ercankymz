using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Xceed.Wpf.AvalonDock.Commands;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorableItem : LayoutItem
{
	private LayoutAnchorable _anchorable;

	private ICommand _defaultHideCommand;

	private ICommand _defaultAutoHideCommand;

	private ICommand _defaultDockCommand;

	private ReentrantFlag _visibilityReentrantFlag = new ReentrantFlag();

	public static readonly DependencyProperty HideCommandProperty = DependencyProperty.Register("HideCommand", typeof(ICommand), typeof(LayoutAnchorableItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnHideCommandChanged), new CoerceValueCallback(CoerceHideCommandValue)));

	public static readonly DependencyProperty AutoHideCommandProperty = DependencyProperty.Register("AutoHideCommand", typeof(ICommand), typeof(LayoutAnchorableItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnAutoHideCommandChanged), new CoerceValueCallback(CoerceAutoHideCommandValue)));

	public static readonly DependencyProperty DockCommandProperty = DependencyProperty.Register("DockCommand", typeof(ICommand), typeof(LayoutAnchorableItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDockCommandChanged), new CoerceValueCallback(CoerceDockCommandValue)));

	public static readonly DependencyProperty CanHideProperty = DependencyProperty.Register("CanHide", typeof(bool), typeof(LayoutAnchorableItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnCanHideChanged)));

	public ICommand HideCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(HideCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideCommandProperty, (object)value);
		}
	}

	public ICommand AutoHideCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AutoHideCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoHideCommandProperty, (object)value);
		}
	}

	public ICommand DockCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DockCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DockCommandProperty, (object)value);
		}
	}

	public bool CanHide
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanHideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanHideProperty, (object)value);
		}
	}

	internal LayoutAnchorableItem()
	{
	}

	private static void OnHideCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutAnchorableItem)(object)d).OnHideCommandChanged(e);
	}

	protected virtual void OnHideCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceHideCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteHideCommand(object parameter)
	{
		if (base.LayoutElement == null)
		{
			return false;
		}
		return _anchorable.CanHide;
	}

	private void ExecuteHideCommand(object parameter)
	{
		if (_anchorable != null && _anchorable.Root != null && _anchorable.Root.Manager != null)
		{
			_anchorable.Root.Manager._ExecuteHideCommand(_anchorable);
		}
	}

	private static void OnAutoHideCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutAnchorableItem)(object)d).OnAutoHideCommandChanged(e);
	}

	protected virtual void OnAutoHideCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceAutoHideCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteAutoHideCommand(object parameter)
	{
		if (base.LayoutElement == null)
		{
			return false;
		}
		if (base.LayoutElement.FindParent<LayoutAnchorableFloatingWindow>() != null)
		{
			return false;
		}
		return _anchorable.CanAutoHide;
	}

	private void ExecuteAutoHideCommand(object parameter)
	{
		if (_anchorable != null && _anchorable.Root != null && _anchorable.Root.Manager != null)
		{
			_anchorable.Root.Manager._ExecuteAutoHideCommand(_anchorable);
		}
	}

	private static void OnDockCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutAnchorableItem)(object)d).OnDockCommandChanged(e);
	}

	protected virtual void OnDockCommandChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	private static object CoerceDockCommandValue(DependencyObject d, object value)
	{
		return value;
	}

	private bool CanExecuteDockCommand(object parameter)
	{
		if (base.LayoutElement == null)
		{
			return false;
		}
		return base.LayoutElement.FindParent<LayoutAnchorableFloatingWindow>() != null;
	}

	private void ExecuteDockCommand(object parameter)
	{
		base.LayoutElement.Root.Manager._ExecuteDockCommand(_anchorable);
	}

	private static void OnCanHideChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutAnchorableItem)(object)d).OnCanHideChanged(e);
	}

	protected virtual void OnCanHideChanged(DependencyPropertyChangedEventArgs e)
	{
		if (_anchorable != null)
		{
			_anchorable.CanHide = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}
	}

	internal override void Attach(LayoutContent model)
	{
		_anchorable = model as LayoutAnchorable;
		_anchorable.IsVisibleChanged += _anchorable_IsVisibleChanged;
		if (_anchorable.CanClose)
		{
			_anchorable.SetCanCloseInternal(canClose: true);
		}
		base.Attach(model);
	}

	internal override void Detach()
	{
		_anchorable.IsVisibleChanged -= _anchorable_IsVisibleChanged;
		_anchorable = null;
		base.Detach();
	}

	protected override bool CanExecuteDockAsDocumentCommand()
	{
		bool flag = base.CanExecuteDockAsDocumentCommand();
		if (flag && _anchorable != null)
		{
			return _anchorable.CanDockAsTabbedDocument;
		}
		return flag;
	}

	protected override void Close()
	{
		if (_anchorable.Root != null && _anchorable.Root.Manager != null)
		{
			_anchorable.Root.Manager._ExecuteCloseCommand(_anchorable);
		}
	}

	protected override void InitDefaultCommands()
	{
		_defaultHideCommand = new RelayCommand(delegate(object p)
		{
			ExecuteHideCommand(p);
		}, (object p) => CanExecuteHideCommand(p));
		_defaultAutoHideCommand = new RelayCommand(delegate(object p)
		{
			ExecuteAutoHideCommand(p);
		}, (object p) => CanExecuteAutoHideCommand(p));
		_defaultDockCommand = new RelayCommand(delegate(object p)
		{
			ExecuteDockCommand(p);
		}, (object p) => CanExecuteDockCommand(p));
		base.InitDefaultCommands();
	}

	protected override void ClearDefaultCommands()
	{
		_defaultHideCommand = null;
		_defaultAutoHideCommand = null;
		_defaultDockCommand = null;
		base.ClearDefaultCommands();
	}

	protected override void ClearDefaultBindings()
	{
		if (HideCommand == _defaultHideCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, HideCommandProperty);
			HideCommand = null;
		}
		if (AutoHideCommand == _defaultAutoHideCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, AutoHideCommandProperty);
			AutoHideCommand = null;
		}
		if (DockCommand == _defaultDockCommand)
		{
			BindingOperations.ClearBinding((DependencyObject)(object)this, DockCommandProperty);
			DockCommand = null;
		}
		base.ClearDefaultBindings();
	}

	protected override void SetDefaultBindings()
	{
		if (HideCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(HideCommandProperty, (object)_defaultHideCommand);
		}
		if (AutoHideCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(AutoHideCommandProperty, (object)_defaultAutoHideCommand);
		}
		if (DockCommand == null)
		{
			((DependencyObject)this).SetCurrentValue(DockCommandProperty, (object)_defaultDockCommand);
		}
		((DependencyObject)this).SetCurrentValue(UIElement.VisibilityProperty, (object)((!_anchorable.IsVisible) ? Visibility.Hidden : Visibility.Visible));
		base.SetDefaultBindings();
	}

	protected override void OnVisibilityChanged()
	{
		if (_anchorable != null && _anchorable.Root != null && _visibilityReentrantFlag.CanEnter)
		{
			using (_visibilityReentrantFlag.Enter())
			{
				if (base.Visibility == Visibility.Hidden)
				{
					_anchorable.Hide(cancelable: false);
				}
				else if (base.Visibility == Visibility.Visible)
				{
					_anchorable.Show();
				}
			}
		}
		base.OnVisibilityChanged();
	}

	private void _anchorable_IsVisibleChanged(object sender, EventArgs e)
	{
		if (_anchorable == null || _anchorable.Root == null || !_visibilityReentrantFlag.CanEnter)
		{
			return;
		}
		using (_visibilityReentrantFlag.Enter())
		{
			if (_anchorable.IsVisible)
			{
				base.Visibility = Visibility.Visible;
			}
			else
			{
				base.Visibility = Visibility.Hidden;
			}
		}
	}
}
