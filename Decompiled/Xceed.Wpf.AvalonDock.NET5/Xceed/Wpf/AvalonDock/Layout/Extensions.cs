using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Controls;

namespace Xceed.Wpf.AvalonDock.Layout;

public static class Extensions
{
	public static IEnumerable<ILayoutElement> Descendents(this ILayoutElement element)
	{
		if (!(element is ILayoutContainer layoutContainer))
		{
			yield break;
		}
		foreach (ILayoutElement childElement in layoutContainer.Children)
		{
			yield return childElement;
			foreach (ILayoutElement item in childElement.Descendents())
			{
				yield return item;
			}
		}
	}

	public static T FindParent<T>(this ILayoutElement element)
	{
		ILayoutContainer parent = element.Parent;
		while (parent != null && !(parent is T))
		{
			parent = parent.Parent;
		}
		return (T)parent;
	}

	public static ILayoutRoot GetRoot(this ILayoutElement element)
	{
		if (element is ILayoutRoot)
		{
			return element as ILayoutRoot;
		}
		ILayoutContainer parent = element.Parent;
		while (parent != null && !(parent is ILayoutRoot))
		{
			parent = parent.Parent;
		}
		return (ILayoutRoot)parent;
	}

	public static bool ContainsChildOfType<T>(this ILayoutContainer element)
	{
		foreach (ILayoutElement item in element.Descendents())
		{
			if (item is T)
			{
				return true;
			}
		}
		return false;
	}

	public static bool ContainsChildOfType<T, S>(this ILayoutContainer container)
	{
		foreach (ILayoutElement item in container.Descendents())
		{
			if (item is T || item is S)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsOfType<T, S>(this ILayoutContainer container)
	{
		if (!(container is T))
		{
			return container is S;
		}
		return true;
	}

	public static AnchorSide GetSide(this ILayoutElement element)
	{
		if (element.Parent is ILayoutOrientableGroup layoutOrientableGroup)
		{
			LayoutPanel layoutPanel = layoutOrientableGroup as LayoutPanel;
			if (layoutPanel == null)
			{
				layoutPanel = layoutOrientableGroup.FindParent<LayoutPanel>();
			}
			if (layoutPanel != null && layoutPanel.Children.Count > 0)
			{
				int count = layoutPanel.Children.Count;
				int num = -1;
				for (int i = 0; i < count; i++)
				{
					if (layoutPanel.Children[i].Equals(element) || layoutPanel.Children[i].Descendents().Contains(element))
					{
						num = i;
						break;
					}
				}
				if (layoutPanel.Orientation == Orientation.Horizontal)
				{
					if (num < 0)
					{
						return AnchorSide.Right;
					}
					if (count == 1)
					{
						return AnchorSide.Left;
					}
					if (!((double)num < (double)count / 2.0))
					{
						return AnchorSide.Right;
					}
					return AnchorSide.Left;
				}
				if (num < 0)
				{
					return AnchorSide.Bottom;
				}
				if (count == 1)
				{
					return AnchorSide.Top;
				}
				if (!((double)num < (double)count / 2.0))
				{
					return AnchorSide.Bottom;
				}
				return AnchorSide.Top;
			}
		}
		return AnchorSide.Right;
	}

	internal static void KeepInsideNearestMonitor(this ILayoutElementForFloatingWindow paneInsideFloatingWindow)
	{
		Win32Helper.RECT lprc = default(Win32Helper.RECT);
		lprc.Left = (int)paneInsideFloatingWindow.FloatingLeft;
		lprc.Top = (int)paneInsideFloatingWindow.FloatingTop;
		lprc.Bottom = lprc.Top + (int)paneInsideFloatingWindow.FloatingHeight;
		lprc.Right = lprc.Left + (int)paneInsideFloatingWindow.FloatingWidth;
		uint dwFlags = 2u;
		uint dwFlags2 = 0u;
		if (!(Win32Helper.MonitorFromRect(ref lprc, dwFlags2) == IntPtr.Zero))
		{
			return;
		}
		IntPtr intPtr = Win32Helper.MonitorFromRect(ref lprc, dwFlags);
		if (intPtr != IntPtr.Zero)
		{
			Win32Helper.MonitorInfo monitorInfo = new Win32Helper.MonitorInfo();
			monitorInfo.Size = Marshal.SizeOf(monitorInfo);
			Win32Helper.GetMonitorInfo(intPtr, monitorInfo);
			if (paneInsideFloatingWindow.FloatingLeft < (double)monitorInfo.Work.Left)
			{
				paneInsideFloatingWindow.FloatingLeft = monitorInfo.Work.Left + 10;
			}
			if (paneInsideFloatingWindow.FloatingLeft + paneInsideFloatingWindow.FloatingWidth > (double)monitorInfo.Work.Right)
			{
				paneInsideFloatingWindow.FloatingLeft = (double)monitorInfo.Work.Right - (paneInsideFloatingWindow.FloatingWidth + 10.0);
			}
			if (paneInsideFloatingWindow.FloatingTop < (double)monitorInfo.Work.Top)
			{
				paneInsideFloatingWindow.FloatingTop = monitorInfo.Work.Top + 10;
			}
			if (paneInsideFloatingWindow.FloatingTop + paneInsideFloatingWindow.FloatingHeight > (double)monitorInfo.Work.Bottom)
			{
				paneInsideFloatingWindow.FloatingTop = (double)monitorInfo.Work.Bottom - (paneInsideFloatingWindow.FloatingHeight + 10.0);
			}
		}
	}
}
