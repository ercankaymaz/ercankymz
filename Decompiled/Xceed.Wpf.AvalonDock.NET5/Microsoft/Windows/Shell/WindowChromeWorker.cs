using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Standard;

namespace Microsoft.Windows.Shell;

internal class WindowChromeWorker : DependencyObject
{
	private delegate void _Action();

	private const Standard.SWP _SwpFlags = Standard.SWP.DRAWFRAME | Standard.SWP.NOACTIVATE | Standard.SWP.NOMOVE | Standard.SWP.NOOWNERZORDER | Standard.SWP.NOSIZE | Standard.SWP.NOZORDER;

	private readonly List<KeyValuePair<Standard.WM, Standard.MessageHandler>> _messageTable;

	private Window _window;

	private IntPtr _hwnd;

	private HwndSource _hwndSource;

	private bool _isHooked;

	private bool _isFixedUp;

	private bool _isUserResizing;

	private bool _hasUserMovedWindow;

	private Point _windowPosAtStartOfUserMove;

	private int _blackGlassFixupAttemptCount;

	private WindowChrome _chromeInfo;

	private WindowState _lastRoundingState;

	private WindowState _lastMenuState;

	private bool _isGlassEnabled;

	public static readonly DependencyProperty WindowChromeWorkerProperty = DependencyProperty.RegisterAttached("WindowChromeWorker", typeof(WindowChromeWorker), typeof(WindowChromeWorker), new PropertyMetadata((object)null, new PropertyChangedCallback(_OnChromeWorkerChanged)));

	private static readonly Standard.HT[,] _HitTestBorders = new Standard.HT[3, 3]
	{
		{
			Standard.HT.TOPLEFT,
			Standard.HT.TOP,
			Standard.HT.TOPRIGHT
		},
		{
			Standard.HT.LEFT,
			Standard.HT.CLIENT,
			Standard.HT.RIGHT
		},
		{
			Standard.HT.BOTTOMLEFT,
			Standard.HT.BOTTOM,
			Standard.HT.BOTTOMRIGHT
		}
	};

	private bool _IsWindowDocked
	{
		get
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			if (_window.WindowState != WindowState.Normal)
			{
				return false;
			}
			Standard.RECT rECT = _GetAdjustedWindowRect(new Standard.RECT
			{
				Bottom = 100,
				Right = 100
			});
			Point val = default(Point);
			((Point)(ref val))._002Ector(_window.Left, _window.Top);
			val -= (Vector)Standard.DpiHelper.DevicePixelsToLogical(new Point((double)rECT.Left, (double)rECT.Top));
			Rect restoreBounds = _window.RestoreBounds;
			return ((Rect)(ref restoreBounds)).Location != val;
		}
	}

	public WindowChromeWorker()
	{
		_messageTable = new List<KeyValuePair<Standard.WM, Standard.MessageHandler>>
		{
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.SETTEXT, _HandleSetTextOrIcon),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.SETICON, _HandleSetTextOrIcon),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.NCACTIVATE, _HandleNCActivate),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.NCCALCSIZE, _HandleNCCalcSize),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.NCHITTEST, _HandleNCHitTest),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.NCRBUTTONUP, _HandleNCRButtonUp),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.SIZE, _HandleSize),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.WINDOWPOSCHANGED, _HandleWindowPosChanged),
			new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.DWMCOMPOSITIONCHANGED, _HandleDwmCompositionChanged)
		};
		if (Standard.Utility.IsPresentationFrameworkVersionLessThan4)
		{
			_messageTable.AddRange(new KeyValuePair<Standard.WM, Standard.MessageHandler>[4]
			{
				new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.WININICHANGE, _HandleSettingChange),
				new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.ENTERSIZEMOVE, _HandleEnterSizeMove),
				new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.EXITSIZEMOVE, _HandleExitSizeMove),
				new KeyValuePair<Standard.WM, Standard.MessageHandler>(Standard.WM.MOVE, _HandleMove)
			});
		}
	}

	public void SetWindowChrome(WindowChrome newChrome)
	{
		((DispatcherObject)this).VerifyAccess();
		if (newChrome != _chromeInfo)
		{
			if (_chromeInfo != null)
			{
				_chromeInfo.PropertyChangedThatRequiresRepaint -= _OnChromePropertyChangedThatRequiresRepaint;
			}
			_chromeInfo = newChrome;
			if (_chromeInfo != null)
			{
				_chromeInfo.PropertyChangedThatRequiresRepaint += _OnChromePropertyChangedThatRequiresRepaint;
			}
			_ApplyNewCustomChrome();
		}
	}

	private void _OnChromePropertyChangedThatRequiresRepaint(object sender, EventArgs e)
	{
		_UpdateFrameState(force: true);
	}

	private static void _OnChromeWorkerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Window window = (Window)(object)d;
		((WindowChromeWorker)((DependencyPropertyChangedEventArgs)(ref e)).NewValue)._SetWindow(window);
	}

	private void _SetWindow(Window window)
	{
		_window = window;
		_hwnd = new WindowInteropHelper(_window).Handle;
		if (Standard.Utility.IsPresentationFrameworkVersionLessThan4)
		{
			Standard.Utility.AddDependencyPropertyChangeListener(_window, Control.TemplateProperty, _OnWindowPropertyChangedThatRequiresTemplateFixup);
			Standard.Utility.AddDependencyPropertyChangeListener(_window, FrameworkElement.FlowDirectionProperty, _OnWindowPropertyChangedThatRequiresTemplateFixup);
		}
		_window.Closed += _UnsetWindow;
		if (IntPtr.Zero != _hwnd)
		{
			_hwndSource = HwndSource.FromHwnd(_hwnd);
			_window.ApplyTemplate();
			if (_chromeInfo != null)
			{
				_ApplyNewCustomChrome();
			}
			return;
		}
		_window.SourceInitialized += delegate
		{
			_hwnd = new WindowInteropHelper(_window).Handle;
			_hwndSource = HwndSource.FromHwnd(_hwnd);
			if (_chromeInfo != null)
			{
				_ApplyNewCustomChrome();
			}
		};
	}

	private void _UnsetWindow(object sender, EventArgs e)
	{
		if (Standard.Utility.IsPresentationFrameworkVersionLessThan4)
		{
			Standard.Utility.RemoveDependencyPropertyChangeListener(_window, Control.TemplateProperty, _OnWindowPropertyChangedThatRequiresTemplateFixup);
			Standard.Utility.RemoveDependencyPropertyChangeListener(_window, FrameworkElement.FlowDirectionProperty, _OnWindowPropertyChangedThatRequiresTemplateFixup);
		}
		if (_chromeInfo != null)
		{
			_chromeInfo.PropertyChangedThatRequiresRepaint -= _OnChromePropertyChangedThatRequiresRepaint;
		}
		_RestoreStandardChromeState(isClosing: true);
	}

	public static WindowChromeWorker GetWindowChromeWorker(Window window)
	{
		Standard.Verify.IsNotNull(window, "window");
		return (WindowChromeWorker)((DependencyObject)window).GetValue(WindowChromeWorkerProperty);
	}

	public static void SetWindowChromeWorker(Window window, WindowChromeWorker chrome)
	{
		Standard.Verify.IsNotNull(window, "window");
		((DependencyObject)window).SetValue(WindowChromeWorkerProperty, (object)chrome);
	}

	private void _OnWindowPropertyChangedThatRequiresTemplateFixup(object sender, EventArgs e)
	{
		if (_chromeInfo != null && _hwnd != IntPtr.Zero)
		{
			((DispatcherObject)_window).Dispatcher.BeginInvoke((DispatcherPriority)6, (Delegate)new _Action(_FixupFrameworkIssues));
		}
	}

	private void _ApplyNewCustomChrome()
	{
		if (_hwnd == IntPtr.Zero)
		{
			return;
		}
		if (_chromeInfo == null)
		{
			_RestoreStandardChromeState(isClosing: false);
			return;
		}
		if (!_isHooked)
		{
			_hwndSource.AddHook(_WndProc);
			_isHooked = true;
		}
		_FixupFrameworkIssues();
		_UpdateSystemMenu(_window.WindowState);
		_UpdateFrameState(force: true);
		Standard.NativeMethods.SetWindowPos(_hwnd, IntPtr.Zero, 0, 0, 0, 0, Standard.SWP.DRAWFRAME | Standard.SWP.NOACTIVATE | Standard.SWP.NOMOVE | Standard.SWP.NOOWNERZORDER | Standard.SWP.NOSIZE | Standard.SWP.NOZORDER);
	}

	private void _FixupFrameworkIssues()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		if (!Standard.Utility.IsPresentationFrameworkVersionLessThan4 || _window.Template == null)
		{
			return;
		}
		if (VisualTreeHelper.GetChildrenCount((DependencyObject)(object)_window) == 0)
		{
			((DispatcherObject)_window).Dispatcher.BeginInvoke((DispatcherPriority)6, (Delegate)new _Action(_FixupFrameworkIssues));
			return;
		}
		FrameworkElement frameworkElement = (FrameworkElement)(object)VisualTreeHelper.GetChild((DependencyObject)(object)_window, 0);
		Standard.RECT windowRect = Standard.NativeMethods.GetWindowRect(_hwnd);
		Standard.RECT rECT = _GetAdjustedWindowRect(windowRect);
		Rect val = Standard.DpiHelper.DeviceRectToLogical(new Rect((double)windowRect.Left, (double)windowRect.Top, (double)windowRect.Width, (double)windowRect.Height));
		Rect val2 = Standard.DpiHelper.DeviceRectToLogical(new Rect((double)rECT.Left, (double)rECT.Top, (double)rECT.Width, (double)rECT.Height));
		Thickness thickness = new Thickness(((Rect)(ref val)).Left - ((Rect)(ref val2)).Left, ((Rect)(ref val)).Top - ((Rect)(ref val2)).Top, ((Rect)(ref val2)).Right - ((Rect)(ref val)).Right, ((Rect)(ref val2)).Bottom - ((Rect)(ref val)).Bottom);
		if (frameworkElement != null)
		{
			frameworkElement.Margin = new Thickness(0.0, 0.0, 0.0 - (thickness.Left + thickness.Right), 0.0 - (thickness.Top + thickness.Bottom));
		}
		if (frameworkElement != null)
		{
			if (_window.FlowDirection == FlowDirection.RightToLeft)
			{
				frameworkElement.RenderTransform = new MatrixTransform(1.0, 0.0, 0.0, 1.0, 0.0 - (thickness.Left + thickness.Right), 0.0);
			}
			else
			{
				frameworkElement.RenderTransform = null;
			}
		}
		if (!_isFixedUp)
		{
			_hasUserMovedWindow = false;
			_window.StateChanged += _FixupRestoreBounds;
			_isFixedUp = true;
		}
	}

	private void _FixupWindows7Issues()
	{
		if (_blackGlassFixupAttemptCount <= 5 && Standard.Utility.IsOSWindows7OrNewer && Standard.NativeMethods.DwmIsCompositionEnabled())
		{
			_blackGlassFixupAttemptCount++;
			bool flag = false;
			try
			{
				flag = Standard.NativeMethods.DwmGetCompositionTimingInfo(_hwnd).HasValue;
			}
			catch (Exception)
			{
			}
			if (!flag)
			{
				((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)6, (Delegate)new _Action(_FixupWindows7Issues));
			}
			else
			{
				_blackGlassFixupAttemptCount = 0;
			}
		}
	}

	private void _FixupRestoreBounds(object sender, EventArgs e)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if ((_window.WindowState == WindowState.Maximized || _window.WindowState == WindowState.Minimized) && _hasUserMovedWindow)
		{
			_hasUserMovedWindow = false;
			Standard.WINDOWPLACEMENT windowPlacement = Standard.NativeMethods.GetWindowPlacement(_hwnd);
			Standard.RECT rECT = _GetAdjustedWindowRect(new Standard.RECT
			{
				Bottom = 100,
				Right = 100
			});
			Point val = Standard.DpiHelper.DevicePixelsToLogical(new Point((double)(windowPlacement.rcNormalPosition.Left - rECT.Left), (double)(windowPlacement.rcNormalPosition.Top - rECT.Top)));
			_window.Top = ((Point)(ref val)).Y;
			_window.Left = ((Point)(ref val)).X;
		}
	}

	private Standard.RECT _GetAdjustedWindowRect(Standard.RECT rcWindow)
	{
		Standard.WS dwStyle = (Standard.WS)(int)Standard.NativeMethods.GetWindowLongPtr(_hwnd, Standard.GWL.STYLE);
		Standard.WS_EX dwExStyle = (Standard.WS_EX)(int)Standard.NativeMethods.GetWindowLongPtr(_hwnd, Standard.GWL.EXSTYLE);
		return Standard.NativeMethods.AdjustWindowRectEx(rcWindow, dwStyle, bMenu: false, dwExStyle);
	}

	private IntPtr _WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		foreach (KeyValuePair<Standard.WM, Standard.MessageHandler> item in _messageTable)
		{
			if (item.Key == (Standard.WM)msg)
			{
				return item.Value((Standard.WM)msg, wParam, lParam, out handled);
			}
		}
		return IntPtr.Zero;
	}

	private IntPtr _HandleSetTextOrIcon(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		bool num = _ModifyStyle(Standard.WS.VISIBLE, Standard.WS.OVERLAPPED);
		IntPtr result = Standard.NativeMethods.DefWindowProc(_hwnd, uMsg, wParam, lParam);
		if (num)
		{
			_ModifyStyle(Standard.WS.OVERLAPPED, Standard.WS.VISIBLE);
		}
		handled = true;
		return result;
	}

	private IntPtr _HandleNCActivate(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		IntPtr result = Standard.NativeMethods.DefWindowProc(_hwnd, Standard.WM.NCACTIVATE, wParam, new IntPtr(-1));
		handled = true;
		return result;
	}

	private IntPtr _HandleNCCalcSize(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		handled = true;
		return new IntPtr(768);
	}

	private IntPtr _HandleNCHitTest(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		IntPtr plResult = IntPtr.Zero;
		handled = false;
		if (Standard.Utility.IsOSVistaOrNewer && _chromeInfo.GlassFrameThickness != default(Thickness) && _isGlassEnabled)
		{
			handled = Standard.NativeMethods.DwmDefWindowProc(_hwnd, uMsg, wParam, lParam, out plResult);
		}
		if (IntPtr.Zero == plResult)
		{
			Point val = default(Point);
			((Point)(ref val))._002Ector((double)Standard.Utility.GET_X_LPARAM(lParam), (double)Standard.Utility.GET_Y_LPARAM(lParam));
			Rect deviceRectangle = _GetWindowRect();
			Standard.HT hT = _HitTestNca(Standard.DpiHelper.DeviceRectToLogical(deviceRectangle), Standard.DpiHelper.DevicePixelsToLogical(val));
			if (hT != Standard.HT.CLIENT)
			{
				Point val2 = val;
				((Point)(ref val2)).Offset(0.0 - ((Rect)(ref deviceRectangle)).X, 0.0 - ((Rect)(ref deviceRectangle)).Y);
				val2 = Standard.DpiHelper.DevicePixelsToLogical(val2);
				IInputElement inputElement = _window.InputHitTest(val2);
				if (inputElement != null && WindowChrome.GetIsHitTestVisibleInChrome(inputElement))
				{
					hT = Standard.HT.CLIENT;
				}
			}
			handled = true;
			plResult = new IntPtr((int)hT);
		}
		return plResult;
	}

	private IntPtr _HandleNCRButtonUp(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		if (2 == wParam.ToInt32())
		{
			if (_window.ContextMenu != null)
			{
				_window.ContextMenu.Placement = PlacementMode.MousePoint;
				_window.ContextMenu.IsOpen = true;
			}
			else if (WindowChrome.GetWindowChrome(_window).ShowSystemMenu)
			{
				SystemCommands.ShowSystemMenuPhysicalCoordinates(_window, new Point((double)Standard.Utility.GET_X_LPARAM(lParam), (double)Standard.Utility.GET_Y_LPARAM(lParam)));
			}
		}
		handled = false;
		return IntPtr.Zero;
	}

	private IntPtr _HandleSize(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		WindowState? assumeState = null;
		if (wParam.ToInt32() == 2)
		{
			assumeState = WindowState.Maximized;
		}
		_UpdateSystemMenu(assumeState);
		handled = false;
		return IntPtr.Zero;
	}

	private IntPtr _HandleWindowPosChanged(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		_UpdateSystemMenu(null);
		if (!_isGlassEnabled)
		{
			Standard.WINDOWPOS value = (Standard.WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(Standard.WINDOWPOS));
			_SetRoundingRegion(value);
		}
		handled = false;
		return IntPtr.Zero;
	}

	private IntPtr _HandleDwmCompositionChanged(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		_UpdateFrameState(force: false);
		handled = false;
		return IntPtr.Zero;
	}

	private IntPtr _HandleSettingChange(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		_FixupFrameworkIssues();
		handled = false;
		return IntPtr.Zero;
	}

	private IntPtr _HandleEnterSizeMove(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		_isUserResizing = true;
		if (_window.WindowState != WindowState.Maximized && !_IsWindowDocked)
		{
			_windowPosAtStartOfUserMove = new Point(_window.Left, _window.Top);
		}
		handled = false;
		return IntPtr.Zero;
	}

	private IntPtr _HandleExitSizeMove(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		_isUserResizing = false;
		if (_window.WindowState == WindowState.Maximized)
		{
			_window.Top = ((Point)(ref _windowPosAtStartOfUserMove)).Y;
			_window.Left = ((Point)(ref _windowPosAtStartOfUserMove)).X;
		}
		handled = false;
		return IntPtr.Zero;
	}

	private IntPtr _HandleMove(Standard.WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled)
	{
		if (_isUserResizing)
		{
			_hasUserMovedWindow = true;
		}
		handled = false;
		return IntPtr.Zero;
	}

	private bool _ModifyStyle(Standard.WS removeStyle, Standard.WS addStyle)
	{
		int num = Standard.NativeMethods.GetWindowLongPtr(_hwnd, Standard.GWL.STYLE).ToInt32();
		Standard.WS wS = (Standard.WS)(((uint)num & (uint)(~removeStyle)) | (uint)addStyle);
		if (num == (int)wS)
		{
			return false;
		}
		Standard.NativeMethods.SetWindowLongPtr(_hwnd, Standard.GWL.STYLE, new IntPtr((int)wS));
		return true;
	}

	private WindowState _GetHwndState()
	{
		return Standard.NativeMethods.GetWindowPlacement(_hwnd).showCmd switch
		{
			Standard.SW.SHOWMINIMIZED => WindowState.Minimized, 
			Standard.SW.SHOWMAXIMIZED => WindowState.Maximized, 
			_ => WindowState.Normal, 
		};
	}

	private Rect _GetWindowRect()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		Standard.RECT windowRect = Standard.NativeMethods.GetWindowRect(_hwnd);
		return new Rect((double)windowRect.Left, (double)windowRect.Top, (double)windowRect.Width, (double)windowRect.Height);
	}

	private void _UpdateSystemMenu(WindowState? assumeState)
	{
		WindowState windowState = assumeState ?? _GetHwndState();
		if (!assumeState.HasValue && _lastMenuState == windowState)
		{
			return;
		}
		_lastMenuState = windowState;
		bool flag = _ModifyStyle(Standard.WS.VISIBLE, Standard.WS.OVERLAPPED);
		IntPtr systemMenu = Standard.NativeMethods.GetSystemMenu(_hwnd, bRevert: false);
		if (IntPtr.Zero != systemMenu)
		{
			int value = Standard.NativeMethods.GetWindowLongPtr(_hwnd, Standard.GWL.STYLE).ToInt32();
			bool flag2 = Standard.Utility.IsFlagSet(value, 131072);
			bool flag3 = Standard.Utility.IsFlagSet(value, 65536);
			bool flag4 = Standard.Utility.IsFlagSet(value, 262144);
			switch (windowState)
			{
			case WindowState.Maximized:
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.RESTORE, Standard.MF.ENABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MOVE, Standard.MF.GRAYED | Standard.MF.DISABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.SIZE, Standard.MF.GRAYED | Standard.MF.DISABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MINIMIZE, (!flag2) ? (Standard.MF.GRAYED | Standard.MF.DISABLED) : Standard.MF.ENABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MAXIMIZE, Standard.MF.GRAYED | Standard.MF.DISABLED);
				break;
			case WindowState.Minimized:
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.RESTORE, Standard.MF.ENABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MOVE, Standard.MF.GRAYED | Standard.MF.DISABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.SIZE, Standard.MF.GRAYED | Standard.MF.DISABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MINIMIZE, Standard.MF.GRAYED | Standard.MF.DISABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MAXIMIZE, (!flag3) ? (Standard.MF.GRAYED | Standard.MF.DISABLED) : Standard.MF.ENABLED);
				break;
			default:
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.RESTORE, Standard.MF.GRAYED | Standard.MF.DISABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MOVE, Standard.MF.ENABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.SIZE, (!flag4) ? (Standard.MF.GRAYED | Standard.MF.DISABLED) : Standard.MF.ENABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MINIMIZE, (!flag2) ? (Standard.MF.GRAYED | Standard.MF.DISABLED) : Standard.MF.ENABLED);
				Standard.NativeMethods.EnableMenuItem(systemMenu, Standard.SC.MAXIMIZE, (!flag3) ? (Standard.MF.GRAYED | Standard.MF.DISABLED) : Standard.MF.ENABLED);
				break;
			}
		}
		if (flag)
		{
			_ModifyStyle(Standard.WS.OVERLAPPED, Standard.WS.VISIBLE);
		}
	}

	private void _UpdateFrameState(bool force)
	{
		if (IntPtr.Zero == _hwnd)
		{
			return;
		}
		bool flag = Standard.NativeMethods.DwmIsCompositionEnabled();
		if (force || flag != _isGlassEnabled)
		{
			_isGlassEnabled = flag && _chromeInfo.GlassFrameThickness != default(Thickness);
			if (!_isGlassEnabled)
			{
				_SetRoundingRegion(null);
			}
			else
			{
				_ClearRoundingRegion();
				_ExtendGlassFrame();
				_FixupWindows7Issues();
			}
			Standard.NativeMethods.SetWindowPos(_hwnd, IntPtr.Zero, 0, 0, 0, 0, Standard.SWP.DRAWFRAME | Standard.SWP.NOACTIVATE | Standard.SWP.NOMOVE | Standard.SWP.NOOWNERZORDER | Standard.SWP.NOSIZE | Standard.SWP.NOZORDER);
		}
	}

	private void _ClearRoundingRegion()
	{
		Standard.NativeMethods.SetWindowRgn(_hwnd, IntPtr.Zero, Standard.NativeMethods.IsWindowVisible(_hwnd));
	}

	private void _SetRoundingRegion(Standard.WINDOWPOS? wp)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		if (Standard.NativeMethods.GetWindowPlacement(_hwnd).showCmd == Standard.SW.SHOWMAXIMIZED)
		{
			int num;
			int num2;
			if (wp.HasValue)
			{
				num = wp.Value.x;
				num2 = wp.Value.y;
			}
			else
			{
				Rect val = _GetWindowRect();
				num = (int)((Rect)(ref val)).Left;
				num2 = (int)((Rect)(ref val)).Top;
			}
			Standard.RECT rcWork = Standard.NativeMethods.GetMonitorInfo(Standard.NativeMethods.MonitorFromWindow(_hwnd, 2u)).rcWork;
			rcWork.Offset(-num, -num2);
			IntPtr gdiObject = IntPtr.Zero;
			try
			{
				gdiObject = Standard.NativeMethods.CreateRectRgnIndirect(rcWork);
				Standard.NativeMethods.SetWindowRgn(_hwnd, gdiObject, Standard.NativeMethods.IsWindowVisible(_hwnd));
				gdiObject = IntPtr.Zero;
				return;
			}
			finally
			{
				Standard.Utility.SafeDeleteObject(ref gdiObject);
			}
		}
		Size size = default(Size);
		if (wp.HasValue && !Standard.Utility.IsFlagSet(wp.Value.flags, 1))
		{
			((Size)(ref size))._002Ector((double)wp.Value.cx, (double)wp.Value.cy);
		}
		else
		{
			if (wp.HasValue && _lastRoundingState == _window.WindowState)
			{
				return;
			}
			Rect val2 = _GetWindowRect();
			size = ((Rect)(ref val2)).Size;
		}
		_lastRoundingState = _window.WindowState;
		IntPtr gdiObject2 = IntPtr.Zero;
		try
		{
			double num3 = Math.Min(((Size)(ref size)).Width, ((Size)(ref size)).Height);
			Point val3 = Standard.DpiHelper.LogicalPixelsToDevice(new Point(_chromeInfo.CornerRadius.TopLeft, 0.0));
			double x = ((Point)(ref val3)).X;
			x = Math.Min(x, num3 / 2.0);
			if (_IsUniform(_chromeInfo.CornerRadius))
			{
				gdiObject2 = _CreateRoundRectRgn(new Rect(size), x);
			}
			else
			{
				gdiObject2 = _CreateRoundRectRgn(new Rect(0.0, 0.0, ((Size)(ref size)).Width / 2.0 + x, ((Size)(ref size)).Height / 2.0 + x), x);
				val3 = Standard.DpiHelper.LogicalPixelsToDevice(new Point(_chromeInfo.CornerRadius.TopRight, 0.0));
				double x2 = ((Point)(ref val3)).X;
				x2 = Math.Min(x2, num3 / 2.0);
				Rect region = default(Rect);
				((Rect)(ref region))._002Ector(0.0, 0.0, ((Size)(ref size)).Width / 2.0 + x2, ((Size)(ref size)).Height / 2.0 + x2);
				((Rect)(ref region)).Offset(((Size)(ref size)).Width / 2.0 - x2, 0.0);
				_CreateAndCombineRoundRectRgn(gdiObject2, region, x2);
				val3 = Standard.DpiHelper.LogicalPixelsToDevice(new Point(_chromeInfo.CornerRadius.BottomLeft, 0.0));
				double x3 = ((Point)(ref val3)).X;
				x3 = Math.Min(x3, num3 / 2.0);
				Rect region2 = default(Rect);
				((Rect)(ref region2))._002Ector(0.0, 0.0, ((Size)(ref size)).Width / 2.0 + x3, ((Size)(ref size)).Height / 2.0 + x3);
				((Rect)(ref region2)).Offset(0.0, ((Size)(ref size)).Height / 2.0 - x3);
				_CreateAndCombineRoundRectRgn(gdiObject2, region2, x3);
				val3 = Standard.DpiHelper.LogicalPixelsToDevice(new Point(_chromeInfo.CornerRadius.BottomRight, 0.0));
				double x4 = ((Point)(ref val3)).X;
				x4 = Math.Min(x4, num3 / 2.0);
				Rect region3 = default(Rect);
				((Rect)(ref region3))._002Ector(0.0, 0.0, ((Size)(ref size)).Width / 2.0 + x4, ((Size)(ref size)).Height / 2.0 + x4);
				((Rect)(ref region3)).Offset(((Size)(ref size)).Width / 2.0 - x4, ((Size)(ref size)).Height / 2.0 - x4);
				_CreateAndCombineRoundRectRgn(gdiObject2, region3, x4);
			}
			Standard.NativeMethods.SetWindowRgn(_hwnd, gdiObject2, Standard.NativeMethods.IsWindowVisible(_hwnd));
			gdiObject2 = IntPtr.Zero;
		}
		finally
		{
			Standard.Utility.SafeDeleteObject(ref gdiObject2);
		}
	}

	private static IntPtr _CreateRoundRectRgn(Rect region, double radius)
	{
		if (Standard.DoubleUtilities.AreClose(0.0, radius))
		{
			return Standard.NativeMethods.CreateRectRgn((int)Math.Floor(((Rect)(ref region)).Left), (int)Math.Floor(((Rect)(ref region)).Top), (int)Math.Ceiling(((Rect)(ref region)).Right), (int)Math.Ceiling(((Rect)(ref region)).Bottom));
		}
		return Standard.NativeMethods.CreateRoundRectRgn((int)Math.Floor(((Rect)(ref region)).Left), (int)Math.Floor(((Rect)(ref region)).Top), (int)Math.Ceiling(((Rect)(ref region)).Right) + 1, (int)Math.Ceiling(((Rect)(ref region)).Bottom) + 1, (int)Math.Ceiling(radius), (int)Math.Ceiling(radius));
	}

	private static void _CreateAndCombineRoundRectRgn(IntPtr hrgnSource, Rect region, double radius)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		IntPtr gdiObject = IntPtr.Zero;
		try
		{
			gdiObject = _CreateRoundRectRgn(region, radius);
			if (Standard.NativeMethods.CombineRgn(hrgnSource, hrgnSource, gdiObject, Standard.RGN.OR) == Standard.CombineRgnResult.ERROR)
			{
				throw new InvalidOperationException("Unable to combine two HRGNs.");
			}
		}
		catch
		{
			Standard.Utility.SafeDeleteObject(ref gdiObject);
			throw;
		}
	}

	private static bool _IsUniform(CornerRadius cornerRadius)
	{
		if (!Standard.DoubleUtilities.AreClose(cornerRadius.BottomLeft, cornerRadius.BottomRight))
		{
			return false;
		}
		if (!Standard.DoubleUtilities.AreClose(cornerRadius.TopLeft, cornerRadius.TopRight))
		{
			return false;
		}
		if (!Standard.DoubleUtilities.AreClose(cornerRadius.BottomLeft, cornerRadius.TopRight))
		{
			return false;
		}
		return true;
	}

	private void _ExtendGlassFrame()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		if (Standard.Utility.IsOSVistaOrNewer && !(IntPtr.Zero == _hwnd))
		{
			if (!Standard.NativeMethods.DwmIsCompositionEnabled())
			{
				_hwndSource.CompositionTarget.BackgroundColor = SystemColors.WindowColor;
				return;
			}
			_hwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;
			Point val = Standard.DpiHelper.LogicalPixelsToDevice(new Point(_chromeInfo.GlassFrameThickness.Left, _chromeInfo.GlassFrameThickness.Top));
			Point val2 = Standard.DpiHelper.LogicalPixelsToDevice(new Point(_chromeInfo.GlassFrameThickness.Right, _chromeInfo.GlassFrameThickness.Bottom));
			Standard.MARGINS pMarInset = new Standard.MARGINS
			{
				cxLeftWidth = (int)Math.Ceiling(((Point)(ref val)).X),
				cxRightWidth = (int)Math.Ceiling(((Point)(ref val2)).X),
				cyTopHeight = (int)Math.Ceiling(((Point)(ref val)).Y),
				cyBottomHeight = (int)Math.Ceiling(((Point)(ref val2)).Y)
			};
			Standard.NativeMethods.DwmExtendFrameIntoClientArea(_hwnd, ref pMarInset);
		}
	}

	private Standard.HT _HitTestNca(Rect windowPosition, Point mousePosition)
	{
		int num = 1;
		int num2 = 1;
		bool flag = false;
		if (((Point)(ref mousePosition)).Y >= ((Rect)(ref windowPosition)).Top && ((Point)(ref mousePosition)).Y < ((Rect)(ref windowPosition)).Top + _chromeInfo.ResizeBorderThickness.Top + _chromeInfo.CaptionHeight)
		{
			flag = ((Point)(ref mousePosition)).Y < ((Rect)(ref windowPosition)).Top + _chromeInfo.ResizeBorderThickness.Top;
			num = 0;
		}
		else if (((Point)(ref mousePosition)).Y < ((Rect)(ref windowPosition)).Bottom && ((Point)(ref mousePosition)).Y >= ((Rect)(ref windowPosition)).Bottom - (double)(int)_chromeInfo.ResizeBorderThickness.Bottom)
		{
			num = 2;
		}
		if (((Point)(ref mousePosition)).X >= ((Rect)(ref windowPosition)).Left && ((Point)(ref mousePosition)).X < ((Rect)(ref windowPosition)).Left + (double)(int)_chromeInfo.ResizeBorderThickness.Left)
		{
			num2 = 0;
		}
		else if (((Point)(ref mousePosition)).X < ((Rect)(ref windowPosition)).Right && ((Point)(ref mousePosition)).X >= ((Rect)(ref windowPosition)).Right - _chromeInfo.ResizeBorderThickness.Right)
		{
			num2 = 2;
		}
		if (num == 0 && num2 != 1 && !flag)
		{
			num = 1;
		}
		Standard.HT hT = _HitTestBorders[num, num2];
		if (hT == Standard.HT.TOP && !flag)
		{
			hT = Standard.HT.CAPTION;
		}
		return hT;
	}

	private void _RestoreStandardChromeState(bool isClosing)
	{
		((DispatcherObject)this).VerifyAccess();
		_UnhookCustomChrome();
		if (!isClosing)
		{
			_RestoreFrameworkIssueFixups();
			_RestoreGlassFrame();
			_RestoreHrgn();
			_window.InvalidateMeasure();
		}
	}

	private void _UnhookCustomChrome()
	{
		if (_isHooked)
		{
			_hwndSource.RemoveHook(_WndProc);
			_isHooked = false;
		}
	}

	private void _RestoreFrameworkIssueFixups()
	{
		if (Standard.Utility.IsPresentationFrameworkVersionLessThan4)
		{
			FrameworkElement frameworkElement = (FrameworkElement)(object)VisualTreeHelper.GetChild((DependencyObject)(object)_window, 0);
			if (frameworkElement != null)
			{
				frameworkElement.Margin = default(Thickness);
			}
			_window.StateChanged -= _FixupRestoreBounds;
			_isFixedUp = false;
		}
	}

	private void _RestoreGlassFrame()
	{
		if (Standard.Utility.IsOSVistaOrNewer && !(_hwnd == IntPtr.Zero))
		{
			_hwndSource.CompositionTarget.BackgroundColor = SystemColors.WindowColor;
			if (Standard.NativeMethods.DwmIsCompositionEnabled())
			{
				Standard.MARGINS pMarInset = default(Standard.MARGINS);
				Standard.NativeMethods.DwmExtendFrameIntoClientArea(_hwnd, ref pMarInset);
			}
		}
	}

	private void _RestoreHrgn()
	{
		_ClearRoundingRegion();
		Standard.NativeMethods.SetWindowPos(_hwnd, IntPtr.Zero, 0, 0, 0, 0, Standard.SWP.DRAWFRAME | Standard.SWP.NOACTIVATE | Standard.SWP.NOMOVE | Standard.SWP.NOOWNERZORDER | Standard.SWP.NOSIZE | Standard.SWP.NOZORDER);
	}
}
