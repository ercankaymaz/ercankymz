using System;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplateVisualState(Name = "OK", GroupName = "MessageBoxButtonsGroup")]
[TemplateVisualState(Name = "OKCancel", GroupName = "MessageBoxButtonsGroup")]
[TemplateVisualState(Name = "YesNo", GroupName = "MessageBoxButtonsGroup")]
[TemplateVisualState(Name = "YesNoCancel", GroupName = "MessageBoxButtonsGroup")]
[TemplatePart(Name = "PART_CancelButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_NoButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_OkButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_YesButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_WindowControl", Type = typeof(WindowControl))]
public class MessageBox : WindowControl
{
	private delegate Window ComputeOwnerWindowCoreDelegate();

	private const string PART_CancelButton = "PART_CancelButton";

	private const string PART_NoButton = "PART_NoButton";

	private const string PART_OkButton = "PART_OkButton";

	private const string PART_YesButton = "PART_YesButton";

	private const string PART_CloseButton = "PART_CloseButton";

	private const string PART_WindowControl = "PART_WindowControl";

	private MessageBoxButton _button;

	private MessageBoxResult _defaultResult;

	private MessageBoxResult _dialogResult;

	private Window _owner;

	private IntPtr _ownerHandle;

	private WindowControl _windowControl;

	public static readonly DependencyProperty ButtonRegionBackgroundProperty;

	public static readonly DependencyProperty CancelButtonContentProperty;

	public static readonly DependencyProperty CancelButtonStyleProperty;

	public static readonly DependencyProperty ImageSourceProperty;

	public static readonly DependencyProperty OkButtonContentProperty;

	public static readonly DependencyProperty OkButtonStyleProperty;

	public static readonly DependencyProperty NoButtonContentProperty;

	public static readonly DependencyProperty NoButtonStyleProperty;

	public static readonly DependencyProperty TextProperty;

	public static readonly DependencyProperty YesButtonContentProperty;

	public static readonly DependencyProperty YesButtonStyleProperty;

	protected Window Container => base.Parent as Window;

	public Brush ButtonRegionBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ButtonRegionBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonRegionBackgroundProperty, (object)value);
		}
	}

	public object CancelButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(CancelButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonContentProperty, value);
		}
	}

	public Style CancelButtonStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(CancelButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelButtonStyleProperty, (object)value);
		}
	}

	public ImageSource ImageSource
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(ImageSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ImageSourceProperty, (object)value);
		}
	}

	public object OkButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(OkButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OkButtonContentProperty, value);
		}
	}

	public Style OkButtonStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(OkButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OkButtonStyleProperty, (object)value);
		}
	}

	public MessageBoxResult MessageBoxResult => _dialogResult;

	public object NoButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(NoButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoButtonContentProperty, value);
		}
	}

	public Style NoButtonStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(NoButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoButtonStyleProperty, (object)value);
		}
	}

	public string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public object YesButtonContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(YesButtonContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(YesButtonContentProperty, value);
		}
	}

	public Style YesButtonStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(YesButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(YesButtonStyleProperty, (object)value);
		}
	}

	internal override bool AllowPublicIsActiveChange => false;

	public event EventHandler Closed;

	static MessageBox()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		ButtonRegionBackgroundProperty = DependencyProperty.Register("ButtonRegionBackground", typeof(Brush), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		CancelButtonContentProperty = DependencyProperty.Register("CancelButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Cancel"));
		CancelButtonStyleProperty = DependencyProperty.Register("CancelButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(MessageBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)null));
		OkButtonContentProperty = DependencyProperty.Register("OkButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)"OK"));
		OkButtonStyleProperty = DependencyProperty.Register("OkButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		NoButtonContentProperty = DependencyProperty.Register("NoButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)"No"));
		NoButtonStyleProperty = DependencyProperty.Register("NoButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MessageBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)string.Empty));
		YesButtonContentProperty = DependencyProperty.Register("YesButtonContent", typeof(object), typeof(MessageBox), (PropertyMetadata)(object)new UIPropertyMetadata((object)"Yes"));
		YesButtonStyleProperty = DependencyProperty.Register("YesButtonStyle", typeof(Style), typeof(MessageBox), new PropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MessageBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(MessageBox)));
	}

	public MessageBox()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		base.Visibility = Visibility.Collapsed;
		InitHandlers();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(MessageBox_IsVisibleChanged);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_windowControl != null)
		{
			_windowControl.HeaderDragDelta -= delegate(object o, DragDeltaEventArgs e)
			{
				OnHeaderDragDelta(e);
			};
			_windowControl.HeaderIconDoubleClicked -= delegate(object o, MouseButtonEventArgs e)
			{
				OnHeaderIconDoubleClicked(e);
			};
			_windowControl.CloseButtonClicked -= delegate(object o, RoutedEventArgs e)
			{
				OnCloseButtonClicked(e);
			};
		}
		_windowControl = GetTemplateChild("PART_WindowControl") as WindowControl;
		if (_windowControl != null)
		{
			_windowControl.HeaderDragDelta += delegate(object o, DragDeltaEventArgs e)
			{
				OnHeaderDragDelta(e);
			};
			_windowControl.HeaderIconDoubleClicked += delegate(object o, MouseButtonEventArgs e)
			{
				OnHeaderIconDoubleClicked(e);
			};
			_windowControl.CloseButtonClicked += delegate(object o, RoutedEventArgs e)
			{
				OnCloseButtonClicked(e);
			};
		}
		UpdateBlockMouseInputsPanel();
		ChangeVisualState(_button.ToString(), useTransitions: true);
		Button messageBoxButton = GetMessageBoxButton("PART_CloseButton");
		if (messageBoxButton != null)
		{
			messageBoxButton.IsEnabled = !object.Equals(_button, MessageBoxButton.YesNo);
		}
		Button messageBoxButton2 = GetMessageBoxButton("PART_OkButton");
		if (messageBoxButton2 != null)
		{
			messageBoxButton2.IsCancel = object.Equals(_button, MessageBoxButton.OK);
		}
		SetDefaultResult();
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		base.OnPreviewKeyDown(e);
		if (Keyboard.IsKeyDown((Key)120) || Keyboard.IsKeyDown((Key)121))
		{
			e.Handled = true;
		}
	}

	protected override object OnCoerceCloseButtonVisibility(Visibility newValue)
	{
		if (newValue != Visibility.Visible)
		{
			throw new InvalidOperationException("Close button on MessageBox is always Visible.");
		}
		return newValue;
	}

	protected override object OnCoerceWindowStyle(WindowStyle newValue)
	{
		if (newValue != WindowStyle.SingleBorderWindow)
		{
			throw new InvalidOperationException("Window style on MessageBox is not available.");
		}
		return newValue;
	}

	internal override void UpdateBlockMouseInputsPanel()
	{
		if (_windowControl != null)
		{
			_windowControl.IsBlockMouseInputsPanelActive = base.IsBlockMouseInputsPanelActive;
		}
	}

	public static MessageBoxResult Show(string messageText)
	{
		return Show(messageText, string.Empty, MessageBoxButton.OK, null);
	}

	public static MessageBoxResult Show(Window owner, string messageText)
	{
		return Show(owner, messageText, string.Empty, MessageBoxButton.OK, null);
	}

	public static MessageBoxResult Show(string messageText, string caption)
	{
		return Show(messageText, caption, MessageBoxButton.OK, null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption)
	{
		return Show(owner, messageText, caption, null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, Style messageBoxStyle)
	{
		return Show(owner, messageText, caption, MessageBoxButton.OK, messageBoxStyle);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button)
	{
		return Show(messageText, caption, button, null);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, Style messageBoxStyle)
	{
		return ShowCore(null, IntPtr.Zero, messageText, caption, button, MessageBoxImage.None, MessageBoxResult.None, messageBoxStyle);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button)
	{
		return Show(owner, messageText, caption, button, null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, Style messageBoxStyle)
	{
		return ShowCore(owner, IntPtr.Zero, messageText, caption, button, MessageBoxImage.None, MessageBoxResult.None, messageBoxStyle);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
	{
		return Show(messageText, caption, button, icon, null);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, Style messageBoxStyle)
	{
		return ShowCore(null, IntPtr.Zero, messageText, caption, button, icon, MessageBoxResult.None, messageBoxStyle);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
	{
		return Show(owner, messageText, caption, button, icon, null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, Style messageBoxStyle)
	{
		return ShowCore(owner, IntPtr.Zero, messageText, caption, button, icon, MessageBoxResult.None, messageBoxStyle);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		return Show(messageText, caption, button, icon, defaultResult, null);
	}

	public static MessageBoxResult Show(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Style messageBoxStyle)
	{
		return ShowCore(null, IntPtr.Zero, messageText, caption, button, icon, defaultResult, messageBoxStyle);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		return Show(owner, messageText, caption, button, icon, defaultResult, null);
	}

	public static MessageBoxResult Show(Window owner, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Style messageBoxStyle)
	{
		return ShowCore(owner, IntPtr.Zero, messageText, caption, button, icon, defaultResult, messageBoxStyle);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText)
	{
		return Show(ownerWindowHandle, messageText, string.Empty, MessageBoxButton.OK, null);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption)
	{
		return Show(ownerWindowHandle, messageText, caption, null);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption, Style messageBoxStyle)
	{
		return Show(ownerWindowHandle, messageText, caption, MessageBoxButton.OK, messageBoxStyle);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption, MessageBoxButton button)
	{
		return Show(ownerWindowHandle, messageText, caption, button, null);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption, MessageBoxButton button, Style messageBoxStyle)
	{
		return ShowCore(null, ownerWindowHandle, messageText, caption, button, MessageBoxImage.None, MessageBoxResult.None, messageBoxStyle);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
	{
		return Show(ownerWindowHandle, messageText, caption, button, icon, null);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, Style messageBoxStyle)
	{
		return ShowCore(null, ownerWindowHandle, messageText, caption, button, icon, MessageBoxResult.None, messageBoxStyle);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		return Show(ownerWindowHandle, messageText, caption, button, icon, defaultResult, null);
	}

	public static MessageBoxResult Show(IntPtr ownerWindowHandle, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Style messageBoxStyle)
	{
		return ShowCore(null, ownerWindowHandle, messageText, caption, button, icon, defaultResult, messageBoxStyle);
	}

	public void ShowMessageBox()
	{
		if (Container != null || base.Parent == null)
		{
			throw new InvalidOperationException("This method is not intended to be called while displaying a MessageBox outside of a WindowContainer. Use ShowDialog() instead in that case.");
		}
		if (!(base.Parent is WindowContainer))
		{
			throw new InvalidOperationException("The MessageBox instance is not intended to be displayed in a container other than a WindowContainer.");
		}
		_dialogResult = MessageBoxResult.None;
		base.Visibility = Visibility.Visible;
	}

	public void ShowMessageBox(string messageText)
	{
		ShowMessageBoxCore(messageText, string.Empty, MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None);
	}

	public void ShowMessageBox(string messageText, string caption)
	{
		ShowMessageBoxCore(messageText, caption, MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None);
	}

	public void ShowMessageBox(string messageText, string caption, MessageBoxButton button)
	{
		ShowMessageBoxCore(messageText, caption, button, MessageBoxImage.None, MessageBoxResult.None);
	}

	public void ShowMessageBox(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon)
	{
		ShowMessageBoxCore(messageText, caption, button, icon, MessageBoxResult.None);
	}

	public void ShowMessageBox(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		ShowMessageBoxCore(messageText, caption, button, icon, defaultResult);
	}

	public bool? ShowDialog()
	{
		if (base.Parent != null)
		{
			throw new InvalidOperationException("This method is not intended to be called while displaying a Message Box inside a WindowContainer. Use 'ShowMessageBox()' instead.");
		}
		_dialogResult = MessageBoxResult.None;
		base.Visibility = Visibility.Visible;
		CreateContainer();
		return Container.ShowDialog();
	}

	protected void InitializeMessageBox(Window owner, IntPtr ownerHandle, string text, string caption, MessageBoxButton button, MessageBoxImage image, MessageBoxResult defaultResult)
	{
		Text = text;
		base.Caption = caption;
		_button = button;
		_defaultResult = defaultResult;
		_owner = owner;
		_ownerHandle = ownerHandle;
		SetImageSource(image);
	}

	protected void ChangeVisualState(string name, bool useTransitions)
	{
		VisualStateManager.GoToState(this, name, useTransitions);
	}

	private bool IsCurrentWindow(object windowtoTest)
	{
		return object.Equals(_windowControl, windowtoTest);
	}

	private void Close()
	{
		if (Container != null)
		{
			Container.Close();
		}
		else
		{
			OnClose();
		}
	}

	private void SetDefaultResult()
	{
		Button defaultButtonFromDefaultResult = GetDefaultButtonFromDefaultResult();
		if (defaultButtonFromDefaultResult != null)
		{
			defaultButtonFromDefaultResult.IsDefault = true;
			defaultButtonFromDefaultResult.Focus();
		}
	}

	private Button GetDefaultButtonFromDefaultResult()
	{
		Button result = null;
		switch (_defaultResult)
		{
		case MessageBoxResult.Cancel:
			result = GetMessageBoxButton("PART_CancelButton");
			break;
		case MessageBoxResult.No:
			result = GetMessageBoxButton("PART_NoButton");
			break;
		case MessageBoxResult.OK:
			result = GetMessageBoxButton("PART_OkButton");
			break;
		case MessageBoxResult.Yes:
			result = GetMessageBoxButton("PART_YesButton");
			break;
		case MessageBoxResult.None:
			result = GetDefaultButton();
			break;
		}
		return result;
	}

	private Button GetDefaultButton()
	{
		Button result = null;
		switch (_button)
		{
		case MessageBoxButton.OK:
		case MessageBoxButton.OKCancel:
			result = GetMessageBoxButton("PART_OkButton");
			break;
		case MessageBoxButton.YesNoCancel:
		case MessageBoxButton.YesNo:
			result = GetMessageBoxButton("PART_YesButton");
			break;
		}
		return result;
	}

	private Button GetMessageBoxButton(string name)
	{
		return GetTemplateChild(name) as Button;
	}

	private void ShowMessageBoxCore(string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
	{
		InitializeMessageBox(null, IntPtr.Zero, messageText, caption, button, icon, defaultResult);
		ShowMessageBox();
	}

	private void InitHandlers()
	{
		AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Button_Click));
		base.CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, ExecuteCopy));
	}

	private static MessageBoxResult ShowCore(Window owner, IntPtr ownerHandle, string messageText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, Style messageBoxStyle)
	{
		if (BrowserInteropHelper.IsBrowserHosted)
		{
			throw new InvalidOperationException("Static methods for MessageBoxes are not available in XBAP. Use the instance ShowMessageBox methods instead.");
		}
		if (owner != null && ownerHandle != IntPtr.Zero)
		{
			throw new NotSupportedException("The owner of a MessageBox can't be both a Window and a WindowHandle.");
		}
		MessageBox messageBox = new MessageBox();
		messageBox.InitializeMessageBox(owner, ownerHandle, messageText, caption, button, icon, defaultResult);
		if (messageBoxStyle != null)
		{
			messageBox.Style = messageBoxStyle;
		}
		messageBox.ShowDialog();
		return messageBox.MessageBoxResult;
	}

	private static Window ComputeOwnerWindow()
	{
		Window result = null;
		if (Application.Current != null)
		{
			if (((DispatcherObject)Application.Current).Dispatcher.CheckAccess())
			{
				result = ComputeOwnerWindowCore();
			}
			else
			{
				((DispatcherObject)Application.Current).Dispatcher.BeginInvoke((Delegate)(Action)delegate
				{
					result = ComputeOwnerWindowCore();
				}, Array.Empty<object>());
			}
		}
		return result;
	}

	private static Window ComputeOwnerWindowCore()
	{
		Window result = null;
		if (Application.Current != null)
		{
			foreach (Window window in Application.Current.Windows)
			{
				if (window.IsActive)
				{
					result = window;
					break;
				}
			}
		}
		return result;
	}

	private void SetImageSource(MessageBoxImage image)
	{
		string empty = string.Empty;
		switch (image)
		{
		default:
			return;
		case MessageBoxImage.Hand:
			empty = "Error48.png";
			break;
		case MessageBoxImage.Asterisk:
			empty = "Information48.png";
			break;
		case MessageBoxImage.Question:
			empty = "Question48.png";
			break;
		case MessageBoxImage.Exclamation:
			empty = "Warning48.png";
			break;
		}
		ImageSource = new BitmapImage(new Uri($"/Xceed.Wpf.Toolkit;component/MessageBox/Icons/{empty}", UriKind.RelativeOrAbsolute));
	}

	private Window CreateContainer()
	{
		Window window = new Window();
		window.AllowsTransparency = true;
		window.Background = Brushes.Transparent;
		window.Content = this;
		if (_ownerHandle != IntPtr.Zero)
		{
			new WindowInteropHelper(window).Owner = _ownerHandle;
			window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
		}
		else
		{
			window.Owner = _owner ?? ComputeOwnerWindow();
			if (window.Owner != null)
			{
				window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
			}
			else
			{
				window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
			}
		}
		window.ShowInTaskbar = false;
		window.SizeToContent = SizeToContent.WidthAndHeight;
		window.ResizeMode = ResizeMode.NoResize;
		window.WindowStyle = WindowStyle.None;
		window.Closed += OnContainerClosed;
		return window;
	}

	protected virtual void OnHeaderDragDelta(DragDeltaEventArgs e)
	{
		if (!IsCurrentWindow(e.OriginalSource))
		{
			return;
		}
		e.Handled = true;
		DragDeltaEventArgs e2 = new DragDeltaEventArgs(e.HorizontalChange, e.VerticalChange);
		e2.RoutedEvent = WindowControl.HeaderDragDeltaEvent;
		e2.Source = this;
		RaiseEvent(e2);
		if (!e2.Handled)
		{
			if (Container == null)
			{
				double num = 0.0;
				num = ((base.FlowDirection != FlowDirection.RightToLeft) ? (base.Left + e.HorizontalChange) : (base.Left - e.HorizontalChange));
				base.Left = num;
				base.Top += e.VerticalChange;
			}
			else
			{
				double num2 = 0.0;
				num2 = ((base.FlowDirection != FlowDirection.RightToLeft) ? (Container.Left + e.HorizontalChange) : (Container.Left - e.HorizontalChange));
				Container.Left = num2;
				Container.Top += e.VerticalChange;
			}
		}
	}

	protected virtual void OnHeaderIconDoubleClicked(MouseButtonEventArgs e)
	{
		if (IsCurrentWindow(e.OriginalSource))
		{
			e.Handled = true;
			MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
			e2.RoutedEvent = WindowControl.HeaderIconDoubleClickedEvent;
			e2.Source = this;
			RaiseEvent(e2);
			if (!e2.Handled)
			{
				Close();
			}
		}
	}

	protected virtual void OnCloseButtonClicked(RoutedEventArgs e)
	{
		if (IsCurrentWindow(e.OriginalSource))
		{
			e.Handled = true;
			_dialogResult = (object.Equals(_button, MessageBoxButton.OK) ? MessageBoxResult.OK : MessageBoxResult.Cancel);
			RoutedEventArgs e2 = new RoutedEventArgs(WindowControl.CloseButtonClickedEvent, this);
			RaiseEvent(e2);
			if (!e2.Handled)
			{
				Close();
			}
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		if (e.OriginalSource is Button button)
		{
			switch (button.Name)
			{
			case "PART_NoButton":
				_dialogResult = MessageBoxResult.No;
				Close();
				break;
			case "PART_YesButton":
				_dialogResult = MessageBoxResult.Yes;
				Close();
				break;
			case "PART_CancelButton":
				_dialogResult = MessageBoxResult.Cancel;
				Close();
				break;
			case "PART_OkButton":
				_dialogResult = MessageBoxResult.OK;
				Close();
				break;
			}
			e.Handled = true;
		}
	}

	private void OnContainerClosed(object sender, EventArgs e)
	{
		Container.Closed -= OnContainerClosed;
		Container.Content = null;
		OnClose();
	}

	private void OnClose()
	{
		base.Visibility = Visibility.Collapsed;
		OnClosed(EventArgs.Empty);
	}

	private void MessageBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			Action action = delegate
			{
				GetDefaultButtonFromDefaultResult()?.Focus();
			};
			((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)2, (Delegate)action);
		}
	}

	protected virtual void OnClosed(EventArgs e)
	{
		if (this.Closed != null)
		{
			this.Closed(this, e);
		}
	}

	private void ExecuteCopy(object sender, ExecutedRoutedEventArgs e)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("---------------------------");
		stringBuilder.AppendLine();
		stringBuilder.Append(base.Caption);
		stringBuilder.AppendLine();
		stringBuilder.Append("---------------------------");
		stringBuilder.AppendLine();
		stringBuilder.Append(Text);
		stringBuilder.AppendLine();
		stringBuilder.Append("---------------------------");
		stringBuilder.AppendLine();
		switch (_button)
		{
		case MessageBoxButton.OK:
			stringBuilder.Append(OkButtonContent.ToString());
			break;
		case MessageBoxButton.OKCancel:
			stringBuilder.Append(OkButtonContent?.ToString() + "     " + CancelButtonContent);
			break;
		case MessageBoxButton.YesNo:
			stringBuilder.Append(YesButtonContent?.ToString() + "     " + NoButtonContent);
			break;
		case MessageBoxButton.YesNoCancel:
			stringBuilder.Append(YesButtonContent?.ToString() + "     " + NoButtonContent?.ToString() + "     " + CancelButtonContent);
			break;
		}
		stringBuilder.AppendLine();
		stringBuilder.Append("---------------------------");
		try
		{
			Clipboard.SetText(stringBuilder.ToString());
		}
		catch (SecurityException)
		{
			throw new SecurityException();
		}
	}
}
