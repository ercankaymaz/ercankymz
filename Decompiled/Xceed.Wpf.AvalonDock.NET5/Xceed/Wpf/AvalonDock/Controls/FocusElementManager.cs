using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal static class FocusElementManager
{
	private static List<DockingManager> _managers = new List<DockingManager>();

	private static FullWeakDictionary<ILayoutElement, IInputElement> _modelFocusedElement = new FullWeakDictionary<ILayoutElement, IInputElement>();

	private static WeakDictionary<ILayoutElement, IntPtr> _modelFocusedWindowHandle = new WeakDictionary<ILayoutElement, IntPtr>();

	private static WeakReference _lastFocusedElement;

	private static WindowHookHandler _windowHandler = null;

	private static DispatcherOperation _setFocusAsyncOperation;

	private static WeakReference _lastFocusedElementBeforeEnterMenuMode = null;

	internal static void SetupFocusManagement(DockingManager manager)
	{
		if (_managers.Count == 0)
		{
			_windowHandler = new WindowHookHandler();
			_windowHandler.FocusChanged += WindowFocusChanging;
			_windowHandler.Attach();
			if (Application.Current != null)
			{
				Dispatcher dispatcher = ((DispatcherObject)Application.Current).Dispatcher;
				if (dispatcher != null)
				{
					if (dispatcher.CheckAccess())
					{
						Application.Current.Exit += Current_Exit;
					}
					else
					{
						FieldInfo field = typeof(Dispatcher).GetField("_disableProcessingCount", BindingFlags.Instance | BindingFlags.NonPublic);
						if (field != null)
						{
							object value = field.GetValue(dispatcher);
							if (value != null && value is int)
							{
								Action action = delegate
								{
									Application.Current.Exit += Current_Exit;
								};
								if ((int)value == 0)
								{
									dispatcher.Invoke((DispatcherPriority)9, (Delegate)action);
								}
								else
								{
									dispatcher.BeginInvoke((DispatcherPriority)9, (Delegate)action);
								}
							}
						}
					}
				}
			}
		}
		manager.PreviewGotKeyboardFocus += manager_PreviewGotKeyboardFocus;
		_managers.Add(manager);
	}

	internal static void FinalizeFocusManagement(DockingManager manager)
	{
		manager.PreviewGotKeyboardFocus -= manager_PreviewGotKeyboardFocus;
		_managers.Remove(manager);
		if (_managers.Count == 0 && _windowHandler != null)
		{
			_windowHandler.FocusChanged -= WindowFocusChanging;
			_windowHandler.Detach();
			_windowHandler = null;
		}
	}

	internal static IInputElement GetLastFocusedElement(ILayoutElement model)
	{
		if (_modelFocusedElement.GetValue(model, out var value))
		{
			return value;
		}
		return null;
	}

	internal static IntPtr GetLastWindowHandle(ILayoutElement model)
	{
		if (_modelFocusedWindowHandle.GetValue(model, out var value))
		{
			return value;
		}
		return IntPtr.Zero;
	}

	internal static void SetFocusOnLastElement(ILayoutElement model)
	{
		bool flag = false;
		if (_modelFocusedElement.GetValue(model, out var value))
		{
			flag = value == Keyboard.Focus(value);
		}
		if (_modelFocusedWindowHandle.GetValue(model, out var value2))
		{
			flag = IntPtr.Zero != Win32Helper.SetFocus(value2);
		}
		if (flag)
		{
			_lastFocusedElement = new WeakReference(model);
		}
	}

	private static void Current_Exit(object sender, ExitEventArgs e)
	{
		Application.Current.Exit -= Current_Exit;
		if (_windowHandler != null)
		{
			_windowHandler.FocusChanged -= WindowFocusChanging;
			_windowHandler.Detach();
			_windowHandler = null;
		}
	}

	private static void manager_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
	{
		if (!(e.NewFocus is Visual visual) || visual is LayoutAnchorableTabItem || visual is LayoutDocumentTabItem)
		{
			return;
		}
		LayoutAnchorableControl layoutAnchorableControl = ((DependencyObject)(object)visual).FindVisualAncestor<LayoutAnchorableControl>();
		if (layoutAnchorableControl != null)
		{
			_modelFocusedElement[layoutAnchorableControl.Model] = e.NewFocus;
			return;
		}
		LayoutDocumentControl layoutDocumentControl = ((DependencyObject)(object)visual).FindVisualAncestor<LayoutDocumentControl>();
		if (layoutDocumentControl != null)
		{
			_modelFocusedElement[layoutDocumentControl.Model] = e.NewFocus;
		}
	}

	private static void WindowFocusChanging(object sender, FocusChangeEventArgs e)
	{
		foreach (DockingManager manager in _managers)
		{
			HwndHost hwndHost = ((DependencyObject)(object)manager).FindLogicalChildren<HwndHost>().FirstOrDefault((HwndHost hw) => Win32Helper.IsChild(hw.Handle, e.GotFocusWinHandle));
			if (hwndHost == null)
			{
				continue;
			}
			LayoutAnchorableControl layoutAnchorableControl = ((DependencyObject)(object)hwndHost).FindVisualAncestor<LayoutAnchorableControl>();
			if (layoutAnchorableControl != null)
			{
				_modelFocusedWindowHandle[layoutAnchorableControl.Model] = e.GotFocusWinHandle;
				if (layoutAnchorableControl.Model != null)
				{
					layoutAnchorableControl.Model.IsActive = true;
				}
				continue;
			}
			LayoutDocumentControl layoutDocumentControl = ((DependencyObject)(object)hwndHost).FindVisualAncestor<LayoutDocumentControl>();
			if (layoutDocumentControl != null)
			{
				_modelFocusedWindowHandle[layoutDocumentControl.Model] = e.GotFocusWinHandle;
				if (layoutDocumentControl.Model != null)
				{
					layoutDocumentControl.Model.IsActive = true;
				}
			}
		}
	}

	private static void WindowActivating(object sender, WindowActivateEventArgs e)
	{
		if (Keyboard.FocusedElement != null || _lastFocusedElement == null || !_lastFocusedElement.IsAlive)
		{
			return;
		}
		ILayoutElement elementToSetFocus = _lastFocusedElement.Target as ILayoutElement;
		if (elementToSetFocus == null)
		{
			return;
		}
		DockingManager manager = elementToSetFocus.Root.Manager;
		if (manager == null || !manager.GetParentWindowHandle(out var hwnd) || e.HwndActivating != hwnd)
		{
			return;
		}
		_setFocusAsyncOperation = Dispatcher.CurrentDispatcher.BeginInvoke((Delegate)(Action)delegate
		{
			try
			{
				SetFocusOnLastElement(elementToSetFocus);
			}
			finally
			{
				_setFocusAsyncOperation = null;
			}
		}, (DispatcherPriority)5, Array.Empty<object>());
	}

	private static void InputManager_EnterMenuMode(object sender, EventArgs e)
	{
		if (Keyboard.FocusedElement != null)
		{
			IInputElement focusedElement = Keyboard.FocusedElement;
			if (((DependencyObject)((focusedElement is DependencyObject) ? focusedElement : null)).FindLogicalAncestor<DockingManager>() == null)
			{
				_lastFocusedElementBeforeEnterMenuMode = null;
			}
			else
			{
				_lastFocusedElementBeforeEnterMenuMode = new WeakReference(Keyboard.FocusedElement);
			}
		}
	}

	private static void InputManager_LeaveMenuMode(object sender, EventArgs e)
	{
		if (_lastFocusedElementBeforeEnterMenuMode != null && _lastFocusedElementBeforeEnterMenuMode.IsAlive)
		{
			UIElement valueOrDefault = _lastFocusedElementBeforeEnterMenuMode.GetValueOrDefault<UIElement>();
			if (valueOrDefault != null)
			{
				Keyboard.Focus(valueOrDefault);
			}
		}
	}
}
