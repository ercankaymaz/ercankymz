#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectCheckBox : PaletteRedirect
{
	private CheckBoxImages _images;

	public PaletteRedirectCheckBox(CheckBoxImages images)
		: this(null, images)
	{
	}

	public PaletteRedirectCheckBox(IPalette target, CheckBoxImages images)
		: base(target)
	{
		Debug.Assert(images != null);
		_images = images;
	}

	public override Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		Image image = null;
		image = checkState switch
		{
			CheckState.Checked => enabled ? ((!pressed) ? ((!tracking) ? _images.CheckedNormal : _images.CheckedTracking) : _images.CheckedPressed) : _images.CheckedDisabled, 
			CheckState.Indeterminate => enabled ? ((!pressed) ? ((!tracking) ? _images.IndeterminateNormal : _images.IndeterminateTracking) : _images.IndeterminatePressed) : _images.IndeterminateDisabled, 
			_ => enabled ? ((!pressed) ? ((!tracking) ? _images.UncheckedNormal : _images.UncheckedTracking) : _images.UncheckedPressed) : _images.UncheckedDisabled, 
		};
		if (image == null)
		{
			image = _images.Common;
		}
		if (image == null)
		{
			image = Target.GetCheckBoxImage(enabled, checkState, tracking, pressed);
		}
		return image;
	}
}
