#define DEBUG
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class DWM
{
	public static bool IsCompositionEnabled
	{
		get
		{
			if (Environment.OSVersion.Version.Major < 6)
			{
				return false;
			}
			bool enabled = false;
			PI.DwmIsCompositionEnabled(ref enabled);
			return enabled;
		}
	}

	public static void ExtendFrameIntoClientArea(IntPtr hWnd, Padding padding)
	{
		Debug.Assert(condition: true);
		PI.MARGINS pMarInset = new PI.MARGINS
		{
			leftWidth = padding.Left,
			topHeight = padding.Top,
			rightWidth = padding.Right,
			bottomHeight = padding.Bottom
		};
		PI.DwmExtendFrameIntoClientArea(hWnd, ref pMarInset);
	}
}
