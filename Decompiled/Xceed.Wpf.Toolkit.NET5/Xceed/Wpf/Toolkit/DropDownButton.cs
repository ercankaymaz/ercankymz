using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_DropDownButton", Type = typeof(ToggleButton))]
[TemplatePart(Name = "PART_ContentPresenter", Type = typeof(ContentPresenter))]
[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
public class DropDownButton : ContentControl, ICommandSource
{
	private const string PART_DropDownButton = "PART_DropDownButton";

	private const string PART_ContentPresenter = "PART_ContentPresenter";

	private const string PART_Popup = "PART_Popup";

	private ContentPresenter _contentPresenter;

	private Popup _popup;

	private ButtonBase _button;

	public static readonly DependencyProperty DropDownContentProperty;

	public static readonly DependencyProperty DropDownContentBackgroundProperty;

	public static readonly DependencyProperty DropDownPositionProperty;

	public static readonly DependencyProperty IsDefaultProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty MaxDropDownHeightProperty;

	public static readonly RoutedEvent ClickEvent;

	public static readonly RoutedEvent OpenedEvent;

	public static readonly RoutedEvent ClosedEvent;

	private EventHandler canExecuteChangedHandler;

	public static readonly DependencyProperty CommandProperty;

	public static readonly DependencyProperty CommandParameterProperty;

	public static readonly DependencyProperty CommandTargetProperty;

	protected ButtonBase Button
	{
		get
		{
			return _button;
		}
		set
		{
			if (_button != null)
			{
				_button.Click -= DropDownButton_Click;
			}
			_button = value;
			if (_button != null)
			{
				_button.Click += DropDownButton_Click;
			}
		}
	}

	public object DropDownContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownContentProperty, value);
		}
	}

	public Brush DropDownContentBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(DropDownContentBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownContentBackgroundProperty, (object)value);
		}
	}

	public PlacementMode DropDownPosition
	{
		get
		{
			return (PlacementMode)((DependencyObject)this).GetValue(DropDownPositionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownPositionProperty, (object)value);
		}
	}

	public bool IsDefault
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDefaultProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDefaultProperty, (object)value);
		}
	}

	public bool IsOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsOpenProperty, (object)value);
		}
	}

	public double MaxDropDownHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxDropDownHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxDropDownHeightProperty, (object)value);
		}
	}

	[TypeConverter(typeof(CommandConverter))]
	public ICommand Command
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public object CommandParameter
	{
		get
		{
			return ((DependencyObject)this).GetValue(CommandParameterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandParameterProperty, value);
		}
	}

	public IInputElement CommandTarget
	{
		get
		{
			return (IInputElement)((DependencyObject)this).GetValue(CommandTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandTargetProperty, (object)value);
		}
	}

	public event RoutedEventHandler Click
	{
		add
		{
			AddHandler(ClickEvent, value);
		}
		remove
		{
			RemoveHandler(ClickEvent, value);
		}
	}

	public event RoutedEventHandler Opened
	{
		add
		{
			AddHandler(OpenedEvent, value);
		}
		remove
		{
			RemoveHandler(OpenedEvent, value);
		}
	}

	public event RoutedEventHandler Closed
	{
		add
		{
			AddHandler(ClosedEvent, value);
		}
		remove
		{
			RemoveHandler(ClosedEvent, value);
		}
	}

	static DropDownButton()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		DropDownContentProperty = DependencyProperty.Register("DropDownContent", typeof(object), typeof(DropDownButton), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnDropDownContentChanged)));
		DropDownContentBackgroundProperty = DependencyProperty.Register("DropDownContentBackground", typeof(Brush), typeof(DropDownButton), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		DropDownPositionProperty = DependencyProperty.Register("DropDownPosition", typeof(PlacementMode), typeof(DropDownButton), (PropertyMetadata)(object)new UIPropertyMetadata((object)PlacementMode.Bottom));
		IsDefaultProperty = DependencyProperty.Register("IsDefault", typeof(bool), typeof(DropDownButton), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsDefaultChanged)));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(DropDownButton), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsOpenChanged)));
		MaxDropDownHeightProperty = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(DropDownButton), (PropertyMetadata)(object)new UIPropertyMetadata(SystemParameters.PrimaryScreenHeight / 2.0, new PropertyChangedCallback(OnMaxDropDownHeightChanged)));
		ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DropDownButton));
		OpenedEvent = EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DropDownButton));
		ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DropDownButton));
		CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(DropDownButton), new PropertyMetadata((object)null, new PropertyChangedCallback(OnCommandChanged)));
		CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(DropDownButton), new PropertyMetadata((PropertyChangedCallback)null));
		CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(DropDownButton), new PropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(DropDownButton)));
		EventManager.RegisterClassHandler(typeof(DropDownButton), AccessKeyManager.AccessKeyPressedEvent, new AccessKeyPressedEventHandler(OnAccessKeyPressed));
	}

	public DropDownButton()
	{
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, OnMouseDownOutsideCapturedElement);
	}

	private static void OnDropDownContentChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DropDownButton dropDownButton)
		{
			dropDownButton.OnDropDownContentChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnDropDownContentChanged(object oldValue, object newValue)
	{
	}

	private static void OnIsDefaultChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DropDownButton dropDownButton)
		{
			dropDownButton.OnIsDefaultChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsDefaultChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			AccessKeyManager.Register("\r", this);
		}
		else
		{
			AccessKeyManager.Unregister("\r", this);
		}
	}

	private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DropDownButton dropDownButton)
		{
			dropDownButton.OnIsOpenChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			RaiseRoutedEvent(OpenedEvent);
		}
		else
		{
			RaiseRoutedEvent(ClosedEvent);
		}
	}

	private static void OnMaxDropDownHeightChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DropDownButton dropDownButton)
		{
			dropDownButton.OnMaxDropDownHeightChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnMaxDropDownHeightChanged(double oldValue, double newValue)
	{
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		Button = GetTemplateChild("PART_DropDownButton") as ToggleButton;
		_contentPresenter = GetTemplateChild("PART_ContentPresenter") as ContentPresenter;
		if (_popup != null)
		{
			_popup.Opened -= Popup_Opened;
		}
		_popup = GetTemplateChild("PART_Popup") as Popup;
		if (_popup != null)
		{
			_popup.Opened += Popup_Opened;
		}
	}

	protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		base.OnIsKeyboardFocusWithinChanged(e);
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			return;
		}
		ContextMenu contextMenu = GetContextMenu((DependencyObject)(object)_popup.Child);
		if (contextMenu == null)
		{
			CloseDropDown(isFocusOnButton: false);
			return;
		}
		RoutedEventHandler handler = null;
		handler = delegate
		{
			contextMenu.Closed -= handler;
			if (!base.IsKeyboardFocusWithin)
			{
				CloseDropDown(isFocusOnButton: false);
			}
		};
		contextMenu.Closed += handler;
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		base.OnGotFocus(e);
		if (Button != null)
		{
			Button.Focus();
		}
	}

	protected override void OnAccessKey(AccessKeyEventArgs e)
	{
		if (e.IsMultiple)
		{
			base.OnAccessKey(e);
		}
		else
		{
			OnClick();
		}
	}

	private ContextMenu GetContextMenu(DependencyObject parent)
	{
		if (parent == null)
		{
			return null;
		}
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
		{
			DependencyObject child = VisualTreeHelper.GetChild(parent, i);
			if (child != null)
			{
				if (child is FrameworkElement { ContextMenu: not null } frameworkElement && frameworkElement.ContextMenu.IsOpen)
				{
					return frameworkElement.ContextMenu;
				}
				ContextMenu contextMenu = GetContextMenu(child);
				if (contextMenu != null)
				{
					return contextMenu;
				}
			}
		}
		return null;
	}

	private static void OnAccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
	{
		if (!e.Handled && e.Scope == null && e.Target == null)
		{
			e.Target = sender as DropDownButton;
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsOpen = true;
				e.Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e))
		{
			CloseDropDown(isFocusOnButton: true);
			e.Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			CloseDropDown(isFocusOnButton: true);
			e.Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		if (_popup != null && !_popup.IsMouseDirectlyOver)
		{
			CloseDropDown(isFocusOnButton: true);
		}
	}

	private void DropDownButton_Click(object sender, RoutedEventArgs e)
	{
		OnClick();
	}

	private void CanExecuteChanged(object sender, EventArgs e)
	{
		CanExecuteChanged();
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		if (_contentPresenter != null)
		{
			_contentPresenter.MoveFocus(new TraversalRequest((FocusNavigationDirection)2));
		}
	}

	private void CanExecuteChanged()
	{
		if (Command != null)
		{
			if (Command is RoutedCommand routedCommand)
			{
				base.IsEnabled = (routedCommand.CanExecute(CommandParameter, CommandTarget) ? true : false);
			}
			else
			{
				base.IsEnabled = (Command.CanExecute(CommandParameter) ? true : false);
			}
		}
	}

	private void CloseDropDown(bool isFocusOnButton)
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		ReleaseMouseCapture();
		if (isFocusOnButton && Button != null)
		{
			Button.Focus();
		}
	}

	protected virtual void OnClick()
	{
		RaiseRoutedEvent(ClickEvent);
		RaiseCommand();
	}

	private void RaiseRoutedEvent(RoutedEvent routedEvent)
	{
		RoutedEventArgs e = new RoutedEventArgs(routedEvent, this);
		RaiseEvent(e);
	}

	private void RaiseCommand()
	{
		if (Command != null)
		{
			if (!(Command is RoutedCommand routedCommand))
			{
				Command.Execute(CommandParameter);
			}
			else
			{
				routedCommand.Execute(CommandParameter, CommandTarget);
			}
		}
	}

	private void UnhookCommand(ICommand oldCommand, ICommand newCommand)
	{
		EventHandler value = CanExecuteChanged;
		oldCommand.CanExecuteChanged -= value;
	}

	private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
	{
		EventHandler eventHandler = CanExecuteChanged;
		canExecuteChangedHandler = eventHandler;
		if (newCommand != null)
		{
			newCommand.CanExecuteChanged += canExecuteChangedHandler;
		}
	}

	private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is DropDownButton dropDownButton)
		{
			dropDownButton.OnCommandChanged((ICommand)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (ICommand)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnCommandChanged(ICommand oldValue, ICommand newValue)
	{
		if (oldValue != null)
		{
			UnhookCommand(oldValue, newValue);
		}
		HookUpCommand(oldValue, newValue);
		CanExecuteChanged();
	}
}
