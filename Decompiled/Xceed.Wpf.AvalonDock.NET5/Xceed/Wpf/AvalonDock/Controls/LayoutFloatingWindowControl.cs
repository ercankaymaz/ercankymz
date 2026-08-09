using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;
using Microsoft.Windows.Shell;
using Standard;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;

namespace Xceed.Wpf.AvalonDock.Controls;

public abstract class LayoutFloatingWindowControl : Window, ILayoutControl
{
	private ResourceDictionary currentThemeResourceDictionary;

	private bool _isInternalChange;

	private ILayoutElement _model;

	private bool _attachDrag;

	private HwndSource _hwndSrc;

	private HwndSourceHook _hwndSrcHook;

	private DragService _dragService;

	private bool _internalCloseFlag;

	private bool _isClosing;

	public static readonly DependencyProperty IsContentImmutableProperty;

	private static readonly DependencyPropertyKey IsDraggingPropertyKey;

	public static readonly DependencyProperty IsDraggingProperty;

	public static readonly DependencyProperty IsMaximizedProperty;

	public static readonly DependencyProperty ResizeBorderThicknessProperty;

	public abstract ILayoutElement Model { get; }

	public bool IsContentImmutable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsContentImmutableProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(IsContentImmutableProperty, (object)value);
		}
	}

	public bool IsDragging => (bool)((DependencyObject)this).GetValue(IsDraggingProperty);

	protected bool CloseInitiatedByUser => !_internalCloseFlag;

	internal bool KeepContentVisibleOnClose { get; set; }

	public bool IsMaximized
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMaximizedProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(IsMaximizedProperty, (object)value);
			UpdatePositionAndSizeOfPanes();
		}
	}

	public Thickness ResizeBorderThickness
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(ResizeBorderThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResizeBorderThicknessProperty, (object)value);
		}
	}

	static LayoutFloatingWindowControl()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		IsContentImmutableProperty = DependencyProperty.Register("IsContentImmutable", typeof(bool), typeof(LayoutFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsDraggingPropertyKey = DependencyProperty.RegisterReadOnly("IsDragging", typeof(bool), typeof(LayoutFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(OnIsDraggingChanged)));
		IsDraggingProperty = IsDraggingPropertyKey.DependencyProperty;
		IsMaximizedProperty = DependencyProperty.Register("IsMaximized", typeof(bool), typeof(LayoutFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		ResizeBorderThicknessProperty = DependencyProperty.Register("ResizeBorderThickness", typeof(Thickness), typeof(LayoutFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Thickness(10.0)));
		ContentControl.ContentProperty.OverrideMetadata(typeof(LayoutFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, null, new CoerceValueCallback(CoerceContentValue)));
		Window.AllowsTransparencyProperty.OverrideMetadata(typeof(LayoutFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		Window.ShowInTaskbarProperty.OverrideMetadata(typeof(LayoutFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}

	protected LayoutFloatingWindowControl(ILayoutElement model)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		base.Loaded += OnLoaded;
		base.Unloaded += OnUnloaded;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(LayoutFloatingWindowControl_IsVisibleChanged);
		_model = model;
	}

	protected LayoutFloatingWindowControl(ILayoutElement model, bool isContentImmutable)
		: this(model)
	{
		IsContentImmutable = isContentImmutable;
	}

	protected void SetIsDragging(bool value)
	{
		((DependencyObject)this).SetValue(IsDraggingPropertyKey, (object)value);
	}

	private static void OnIsDraggingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutFloatingWindowControl)(object)d).OnIsDraggingChanged(e);
	}

	protected virtual void OnIsDraggingChanged(DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)
		{
			CaptureMouse();
		}
		else
		{
			ReleaseMouseCapture();
		}
	}

	protected override void OnStateChanged(EventArgs e)
	{
		if (!_isInternalChange)
		{
			if (base.WindowState == WindowState.Maximized)
			{
				UpdateMaximizedState(isMaximized: true);
			}
			else if (IsMaximized)
			{
				base.WindowState = WindowState.Maximized;
			}
		}
		if (base.WindowState == WindowState.Normal)
		{
			UpdatePositionAndSizeOfPanes();
		}
		base.OnStateChanged(e);
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		if (CloseInitiatedByUser && !KeepContentVisibleOnClose && !CanClose())
		{
			e.Cancel = true;
			if (CanHide())
			{
				DoHide();
			}
		}
		base.OnClosing(e);
	}

	protected override void OnClosed(EventArgs e)
	{
		ILayoutRoot layoutRoot = ((Model != null) ? Model.Root : null);
		if (layoutRoot != null)
		{
			if (layoutRoot.Manager != null)
			{
				layoutRoot.Manager.RemoveFloatingWindow(this);
			}
			layoutRoot.CollectGarbage();
		}
		if (base.Content != null && _hwndSrc != null)
		{
			_hwndSrc.RemoveHook(_hwndSrcHook);
			_hwndSrc.Dispose();
			_hwndSrc = null;
		}
		base.OnClosed(e);
		if (!CloseInitiatedByUser)
		{
			layoutRoot?.FloatingWindows.Remove(Model as LayoutFloatingWindow);
		}
		BringFocusOnDockingManager();
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.CommandBindings.Add(new CommandBinding(Microsoft.Windows.Shell.SystemCommands.CloseWindowCommand, delegate(object s, ExecutedRoutedEventArgs args)
		{
			Microsoft.Windows.Shell.SystemCommands.CloseWindow((Window)args.Parameter);
		}));
		base.CommandBindings.Add(new CommandBinding(Microsoft.Windows.Shell.SystemCommands.MaximizeWindowCommand, delegate(object s, ExecutedRoutedEventArgs args)
		{
			Microsoft.Windows.Shell.SystemCommands.MaximizeWindow((Window)args.Parameter);
		}));
		base.CommandBindings.Add(new CommandBinding(Microsoft.Windows.Shell.SystemCommands.MinimizeWindowCommand, delegate(object s, ExecutedRoutedEventArgs args)
		{
			Microsoft.Windows.Shell.SystemCommands.MinimizeWindow((Window)args.Parameter);
		}));
		base.CommandBindings.Add(new CommandBinding(Microsoft.Windows.Shell.SystemCommands.RestoreWindowCommand, delegate(object s, ExecutedRoutedEventArgs args)
		{
			Microsoft.Windows.Shell.SystemCommands.RestoreWindow((Window)args.Parameter);
		}));
		base.OnInitialized(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected I4, but got Unknown
		ILayoutRoot root = Model.Root;
		if (root != null && root.Manager.AllowMovingFloatingWindowWithKeyboard)
		{
			Key key = e.Key;
			switch (key - 23)
			{
			case 0:
				base.Left -= 25.0;
				break;
			case 2:
				base.Left += 25.0;
				break;
			case 1:
				base.Top -= 25.0;
				break;
			case 3:
				base.Top += 25.0;
				break;
			}
		}
		base.OnKeyDown(e);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if ((Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)) && e.IsDown && (int)e.Key == 3 && Model != null && Model.Root != null)
		{
			DockingManager manager = Model.Root.Manager;
			if (manager != null && !manager.IsNavigatorWindowActive)
			{
				manager.ShowNavigatorWindow();
				e.Handled = true;
			}
		}
		base.OnPreviewKeyDown(e);
	}

	internal virtual void UpdateThemeResources(Theme oldTheme = null)
	{
		if (oldTheme != null)
		{
			if (oldTheme is DictionaryTheme)
			{
				if (currentThemeResourceDictionary != null)
				{
					base.Resources.MergedDictionaries.Remove(currentThemeResourceDictionary);
					currentThemeResourceDictionary = null;
				}
			}
			else
			{
				ResourceDictionary resourceDictionary = base.Resources.MergedDictionaries.FirstOrDefault((ResourceDictionary r) => r.Source == oldTheme.GetResourceUri());
				if (resourceDictionary != null)
				{
					base.Resources.MergedDictionaries.Remove(resourceDictionary);
				}
			}
		}
		DockingManager manager = _model.Root.Manager;
		if (manager.Theme != null)
		{
			if (manager.Theme is DictionaryTheme)
			{
				currentThemeResourceDictionary = ((DictionaryTheme)manager.Theme).ThemeResourceDictionary;
				base.Resources.MergedDictionaries.Add(currentThemeResourceDictionary);
			}
			else
			{
				base.Resources.MergedDictionaries.Add(new ResourceDictionary
				{
					Source = manager.Theme.GetResourceUri()
				});
			}
		}
	}

	protected virtual bool CanClose(object parameter = null)
	{
		return false;
	}

	protected virtual bool CanHide(object parameter = null)
	{
		return false;
	}

	protected virtual void DoHide()
	{
	}

	internal void AttachDrag(bool onActivated = true)
	{
		if (onActivated)
		{
			_attachDrag = true;
			base.Activated += OnActivated;
		}
		else
		{
			Win32Helper.SendMessage(new WindowInteropHelper(this).Handle, lParam: new IntPtr(((int)base.Left & 0xFFFF) | ((int)base.Top << 16)), Msg: 161, wParam: new IntPtr(2));
		}
	}

	protected virtual IntPtr FilterMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		handled = false;
		switch (msg)
		{
		case 131:
			if (wParam != IntPtr.Zero)
			{
				handled = true;
				Standard.RECT structure = (Standard.RECT)Marshal.PtrToStructure(lParam, typeof(Standard.RECT));
				structure.Bottom--;
				Marshal.StructureToPtr(structure, lParam, fDeleteOld: false);
			}
			break;
		case 6:
			if (((int)wParam & 0xFFFF) == 0 && lParam == this.GetParentWindowHandle())
			{
				Win32Helper.SetActiveWindow(_hwndSrc.Handle);
				handled = true;
			}
			break;
		case 562:
			UpdatePositionAndSizeOfPanes();
			if (_dragService != null)
			{
				Point dropLocation = this.TransformToDeviceDPI(Win32Helper.GetMousePosition());
				_dragService.Drop(dropLocation, out var dropHandled);
				_dragService = null;
				SetIsDragging(value: false);
				if (dropHandled)
				{
					InternalClose();
				}
			}
			break;
		case 534:
			UpdateDragPosition();
			if (IsMaximized)
			{
				UpdateMaximizedState(isMaximized: false);
			}
			break;
		case 514:
			if (_dragService != null && Mouse.LeftButton == MouseButtonState.Released)
			{
				_dragService.Abort();
				_dragService = null;
				SetIsDragging(value: false);
			}
			break;
		case 274:
		{
			int num = (int)wParam & 0xFFF0;
			if (num == 61488 || num == 61728)
			{
				UpdateMaximizedState(num == 61488);
			}
			break;
		}
		}
		return IntPtr.Zero;
	}

	internal void InternalClose()
	{
		_internalCloseFlag = true;
		if (!_isClosing)
		{
			_isClosing = true;
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
			{
				Close();
			}, (DispatcherPriority)10, Array.Empty<object>());
		}
	}

	internal void BringFocusOnDockingManager()
	{
		if (base.Owner != null)
		{
			base.Owner.Focus();
		}
		else if (Model != null && Model.Root != null && Model.Root.Manager != null)
		{
			(from control in ((DependencyObject)(object)Model.Root.Manager).FindVisualChildren<UIElement>()
				where control.Focusable
				select control).FirstOrDefault()?.Focus();
		}
	}

	internal bool IsClosing()
	{
		return _isClosing;
	}

	private static object CoerceContentValue(DependencyObject sender, object content)
	{
		if (sender is LayoutFloatingWindowControl layoutFloatingWindowControl)
		{
			if (layoutFloatingWindowControl.IsLoaded && layoutFloatingWindowControl.IsContentImmutable)
			{
				return layoutFloatingWindowControl.Content;
			}
			return content;
		}
		return null;
	}

	private void LayoutFloatingWindowControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		_ = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		base.Loaded -= OnLoaded;
		this.SetParentToMainWindowOf(Model.Root.Manager);
		_hwndSrc = PresentationSource.FromDependencyObject((DependencyObject)(object)this) as HwndSource;
		_hwndSrcHook = FilterMessage;
		_hwndSrc.AddHook(_hwndSrcHook);
		bool isMaximized = Model.Descendents().OfType<ILayoutElementForFloatingWindow>().Any((ILayoutElementForFloatingWindow l) => l.IsMaximized);
		UpdateMaximizedState(isMaximized);
	}

	private void OnUnloaded(object sender, RoutedEventArgs e)
	{
		base.Unloaded -= OnUnloaded;
		if (_hwndSrc != null)
		{
			_hwndSrc.RemoveHook(_hwndSrcHook);
			InternalClose();
		}
	}

	private void OnActivated(object sender, EventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		base.Activated -= OnActivated;
		if (_attachDrag && Mouse.LeftButton == MouseButtonState.Pressed)
		{
			IntPtr handle = new WindowInteropHelper(this).Handle;
			Point val = this.PointToScreenDPI(Mouse.GetPosition(this));
			Win32Helper.RECT clientRect = Win32Helper.GetClientRect(handle);
			Win32Helper.RECT windowRect = Win32Helper.GetWindowRect(handle);
			base.Left = ((Point)(ref val)).X - (double)(windowRect.Width - clientRect.Width) / 2.0;
			base.Top = ((Point)(ref val)).Y - (double)(windowRect.Height - clientRect.Height) / 2.0;
			_attachDrag = false;
			Win32Helper.SendMessage(lParam: new IntPtr(((int)((Point)(ref val)).X & 0xFFFF) | ((int)((Point)(ref val)).Y << 16)), hWnd: handle, Msg: 161, wParam: new IntPtr(2));
		}
	}

	private void UpdatePositionAndSizeOfPanes()
	{
		foreach (ILayoutElementForFloatingWindow item in Model.Descendents().OfType<ILayoutElementForFloatingWindow>())
		{
			item.FloatingLeft = base.Left;
			item.FloatingTop = base.Top;
			item.FloatingWidth = base.Width;
			item.FloatingHeight = base.Height;
		}
	}

	private void UpdateMaximizedState(bool isMaximized)
	{
		foreach (ILayoutElementForFloatingWindow item in Model.Descendents().OfType<ILayoutElementForFloatingWindow>())
		{
			item.IsMaximized = isMaximized;
		}
		IsMaximized = isMaximized;
		_isInternalChange = true;
		base.WindowState = (isMaximized ? WindowState.Maximized : WindowState.Normal);
		_isInternalChange = false;
	}

	private void UpdateDragPosition()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (_dragService == null)
		{
			_dragService = new DragService(this);
			SetIsDragging(value: true);
		}
		Point dragPosition = this.TransformToDeviceDPI(Win32Helper.GetMousePosition());
		_dragService.UpdateMouseLocation(dragPosition);
	}
}
