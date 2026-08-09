#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupButtonImage : ViewDrawRibbonGroupImageBase
{
	private static readonly Size _smallSize = new Size(16, 16);

	private static readonly Size _largeSize = new Size(32, 32);

	private KryptonRibbonGroupButton _ribbonButton;

	private bool _large;

	protected override Size DrawSize
	{
		get
		{
			if (_large)
			{
				return _largeSize;
			}
			return _smallSize;
		}
	}

	protected override Image DrawImage
	{
		get
		{
			if (_ribbonButton.KryptonCommand != null)
			{
				if (_large)
				{
					return _ribbonButton.KryptonCommand.ImageLarge;
				}
				return _ribbonButton.KryptonCommand.ImageSmall;
			}
			if (_large)
			{
				return _ribbonButton.ImageLarge;
			}
			return _ribbonButton.ImageSmall;
		}
	}

	public ViewDrawRibbonGroupButtonImage(KryptonRibbon ribbon, KryptonRibbonGroupButton ribbonButton, bool large)
		: base(ribbon)
	{
		Debug.Assert(ribbonButton != null);
		_ribbonButton = ribbonButton;
		_large = large;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupButtonImage:" + base.Id;
	}
}
