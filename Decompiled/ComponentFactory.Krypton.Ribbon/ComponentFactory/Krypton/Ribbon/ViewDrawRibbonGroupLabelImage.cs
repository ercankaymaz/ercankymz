#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupLabelImage : ViewDrawRibbonGroupImageBase
{
	private static readonly Size _smallSize = new Size(16, 16);

	private static readonly Size _largeSize = new Size(32, 32);

	private KryptonRibbonGroupLabel _ribbonLabel;

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
			if (_large)
			{
				return _ribbonLabel.ImageLarge;
			}
			return _ribbonLabel.ImageSmall;
		}
	}

	public ViewDrawRibbonGroupLabelImage(KryptonRibbon ribbon, KryptonRibbonGroupLabel ribbonLabel, bool large)
		: base(ribbon)
	{
		Debug.Assert(ribbonLabel != null);
		_ribbonLabel = ribbonLabel;
		_large = large;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupLabelImage:" + base.Id;
	}
}
