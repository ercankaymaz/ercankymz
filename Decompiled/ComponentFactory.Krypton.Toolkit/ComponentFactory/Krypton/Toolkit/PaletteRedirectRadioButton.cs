#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectRadioButton : PaletteRedirect
{
	private RadioButtonImages _images;

	public PaletteRedirectRadioButton(RadioButtonImages images)
		: this(null, images)
	{
	}

	public PaletteRedirectRadioButton(IPalette target, RadioButtonImages images)
		: base(target)
	{
		Debug.Assert(images != null);
		_images = images;
	}

	public override Image GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed)
	{
		Image image = null;
		image = (checkState ? ((!enabled) ? _images.CheckedDisabled : (pressed ? _images.CheckedPressed : ((!tracking) ? _images.CheckedNormal : _images.CheckedTracking))) : ((!enabled) ? _images.UncheckedDisabled : (pressed ? _images.UncheckedPressed : ((!tracking) ? _images.UncheckedNormal : _images.UncheckedTracking))));
		if (image == null)
		{
			image = _images.Common;
		}
		if (image == null)
		{
			image = Target.GetRadioButtonImage(enabled, checkState, tracking, pressed);
		}
		return image;
	}
}
