using System.Collections.Generic;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms;

public static class RibbonPopupManager
{
	public enum DismissReason
	{
		ItemClicked,
		AppClicked,
		NewPopup,
		AppFocusChanged,
		EscapePressed
	}

	private static readonly List<RibbonPopup> pops;

	internal static RibbonPopup LastPopup
	{
		get
		{
			if (pops.Count > 0)
			{
				return pops[pops.Count - 1];
			}
			return null;
		}
	}

	internal static int PopupCount => pops.Count;

	public static event EventHandler PopupRegistered;

	public static event EventHandler PopupUnRegistered;

	static RibbonPopupManager()
	{
		pops = new List<RibbonPopup>();
	}

	internal static void Register(RibbonPopup p)
	{
		if (!pops.Contains(p))
		{
			pops.Add(p);
			RibbonPopupManager.PopupRegistered(p, EventArgs.Empty);
		}
	}

	internal static void Unregister(RibbonPopup p)
	{
		if (pops.Contains(p))
		{
			pops.Remove(p);
			RibbonPopupManager.PopupUnRegistered(p, EventArgs.Empty);
		}
	}

	internal static bool FeedHookClick(MouseEventArgs e)
	{
		if (WinApi.GetCursorPos(out var lpPoint))
		{
			foreach (RibbonPopup pop in pops)
			{
				if (pop.WrappedDropDown.Bounds.Contains(lpPoint.x, lpPoint.y))
				{
					return true;
				}
			}
		}
		Dismiss(DismissReason.AppClicked);
		return false;
	}

	internal static bool FeedMouseWheel(MouseEventArgs e)
	{
		RibbonDropDown ribbonDropDown = LastPopup as RibbonDropDown;
		if (ribbonDropDown != null)
		{
			foreach (RibbonItem item in ribbonDropDown.Items)
			{
				if (ribbonDropDown.RectangleToScreen(item.Bounds).Contains(e.Location) && item is IScrollableRibbonItem scrollableRibbonItem)
				{
					if (e.Delta < 0)
					{
						scrollableRibbonItem.ScrollDown();
					}
					else
					{
						scrollableRibbonItem.ScrollUp();
					}
					return true;
				}
			}
		}
		if (ribbonDropDown != null)
		{
			if (e.Delta < 0)
			{
				ribbonDropDown.ScrollDown();
			}
			else
			{
				ribbonDropDown.ScrollUp();
			}
			return true;
		}
		return false;
	}

	public static void DismissChildren(RibbonPopup parent, DismissReason reason)
	{
		int num = pops.IndexOf(parent);
		if (num >= 0)
		{
			Dismiss(num + 1, reason);
		}
	}

	public static void Dismiss(DismissReason reason)
	{
		Dismiss(0, reason);
	}

	public static void Dismiss(RibbonPopup startPopup, DismissReason reason)
	{
		int num = pops.IndexOf(startPopup);
		if (num >= 0)
		{
			Dismiss(num, reason);
		}
	}

	private static void Dismiss(int startPopup, DismissReason reason)
	{
		for (int num = pops.Count - 1; num >= startPopup; num--)
		{
			pops[num].Close();
		}
	}
}
