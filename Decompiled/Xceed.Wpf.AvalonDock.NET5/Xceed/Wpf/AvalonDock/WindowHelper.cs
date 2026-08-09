using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Xceed.Wpf.AvalonDock;

internal static class WindowHelper
{
	public static bool IsAttachedToPresentationSource(this Visual element)
	{
		return PresentationSource.FromVisual(element) != null;
	}

	public static void SetParentToMainWindowOf(this Window window, Visual element)
	{
		Window window2 = Window.GetWindow((DependencyObject)(object)element);
		IntPtr hwnd;
		if (window2 != null)
		{
			window.Owner = window2;
		}
		else if (element.GetParentWindowHandle(out hwnd))
		{
			Win32Helper.SetOwner(new WindowInteropHelper(window).Handle, hwnd);
		}
	}

	public static IntPtr GetParentWindowHandle(this Window window)
	{
		if (window.Owner != null)
		{
			return new WindowInteropHelper(window.Owner).Handle;
		}
		return Win32Helper.GetOwner(new WindowInteropHelper(window).Handle);
	}

	public static bool GetParentWindowHandle(this Visual element, out IntPtr hwnd)
	{
		hwnd = IntPtr.Zero;
		if (!(PresentationSource.FromVisual(element) is HwndSource hwndSource))
		{
			return false;
		}
		hwnd = Win32Helper.GetParent(hwndSource.Handle);
		if (hwnd == IntPtr.Zero)
		{
			hwnd = hwndSource.Handle;
		}
		return true;
	}

	public static void SetParentWindowToNull(this Window window)
	{
		if (window.Owner != null)
		{
			window.Owner = null;
		}
		else
		{
			Win32Helper.SetOwner(new WindowInteropHelper(window).Handle, IntPtr.Zero);
		}
	}
}
