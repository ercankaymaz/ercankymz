#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectDropDownButton : PaletteRedirect
{
	private DropDownButtonImages _images;

	public PaletteRedirectDropDownButton(DropDownButtonImages images)
		: this(null, images)
	{
	}

	public PaletteRedirectDropDownButton(IPalette target, DropDownButtonImages images)
		: base(target)
	{
		Debug.Assert(images != null);
		_images = images;
	}

	public override Image GetDropDownButtonImage(PaletteState state)
	{
		Image image = null;
		switch (state)
		{
		case PaletteState.Disabled:
			image = _images.Disabled;
			break;
		case PaletteState.Normal:
			image = _images.Normal;
			break;
		case PaletteState.Tracking:
			image = _images.Tracking;
			break;
		case PaletteState.Pressed:
			image = _images.Pressed;
			break;
		}
		if (image == null)
		{
			image = _images.Common;
		}
		if (image == null)
		{
			image = Target.GetDropDownButtonImage(state);
		}
		return image;
	}
}
