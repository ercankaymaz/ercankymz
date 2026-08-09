#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonCompoRightBorder : ViewLeaf
{
	private static readonly int SPACING_GAP = 10;

	private VisualForm _ownerForm;

	private int _width;

	public VisualForm CompOwnerForm
	{
		get
		{
			return _ownerForm;
		}
		set
		{
			_ownerForm = value;
		}
	}

	public override string ToString()
	{
		return "ViewDrawRibbonCompoRightBorder:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size empty = Size.Empty;
		if (_ownerForm != null && _ownerForm.ApplyCustomChrome && _ownerForm.ApplyComposition)
		{
			try
			{
				PI.TITLEBARINFOEX lParam = default(PI.TITLEBARINFOEX);
				lParam.cbSize = (uint)Marshal.SizeOf((object)lParam);
				PI.SendMessage(_ownerForm.Handle, 831, IntPtr.Zero, ref lParam);
				int num = lParam.rcCloseButton.right - lParam.rcCloseButton.left;
				int num2 = lParam.rcHelpButton.right - lParam.rcHelpButton.left;
				int num3 = lParam.rcMinButton.right - lParam.rcMinButton.left;
				int num4 = lParam.rcMaxButton.right - lParam.rcMaxButton.left;
				int width = _ownerForm.ClientSize.Width;
				int right = _ownerForm.RectangleToScreen(_ownerForm.ClientRectangle).Right;
				int num5 = right;
				if (num > 0 && num < width)
				{
					num5 = Math.Min(num5, lParam.rcCloseButton.left);
				}
				if (num2 > 0 && num2 < width)
				{
					num5 = Math.Min(num5, lParam.rcHelpButton.left);
				}
				if (num3 > 0 && num3 < width)
				{
					num5 = Math.Min(num5, lParam.rcMinButton.left);
				}
				if (num4 > 0 && num4 < width)
				{
					num5 = Math.Min(num5, lParam.rcMaxButton.left);
				}
				_width = right - num5 + SPACING_GAP;
				empty.Width = _width;
			}
			catch (ObjectDisposedException)
			{
			}
		}
		return empty;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}
}
