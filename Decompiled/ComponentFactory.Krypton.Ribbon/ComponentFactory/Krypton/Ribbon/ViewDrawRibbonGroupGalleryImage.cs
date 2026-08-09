#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupGalleryImage : ViewDrawRibbonGroupImageBase
{
	private static readonly Size _largeSize = new Size(32, 32);

	private KryptonRibbonGroupGallery _ribbonGallery;

	protected override Size DrawSize => _largeSize;

	protected override Image DrawImage => _ribbonGallery.ImageLarge;

	public ViewDrawRibbonGroupGalleryImage(KryptonRibbon ribbon, KryptonRibbonGroupGallery ribbonGallery)
		: base(ribbon)
	{
		Debug.Assert(ribbonGallery != null);
		_ribbonGallery = ribbonGallery;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupGalleryImage:" + base.Id;
	}
}
