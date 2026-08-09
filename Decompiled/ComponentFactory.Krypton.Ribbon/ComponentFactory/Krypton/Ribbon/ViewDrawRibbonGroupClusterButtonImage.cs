#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupClusterButtonImage : ViewDrawRibbonGroupImageBase
{
	private static readonly Size _smallSize = new Size(16, 16);

	private KryptonRibbonGroupClusterButton _ribbonButton;

	protected override Size DrawSize => _smallSize;

	protected override Image DrawImage
	{
		get
		{
			if (_ribbonButton.KryptonCommand != null)
			{
				return _ribbonButton.KryptonCommand.ImageSmall;
			}
			return _ribbonButton.ImageSmall;
		}
	}

	public ViewDrawRibbonGroupClusterButtonImage(KryptonRibbon ribbon, KryptonRibbonGroupClusterButton ribbonButton)
		: base(ribbon)
	{
		Debug.Assert(ribbonButton != null);
		_ribbonButton = ribbonButton;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupClusterButtonImage:" + base.Id;
	}
}
