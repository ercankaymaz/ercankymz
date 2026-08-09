#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectTreeView : PaletteRedirect
{
	private TreeViewImages _plusMinusImages;

	private CheckBoxImages _checkboxImages;

	public PaletteRedirectTreeView(TreeViewImages plusMinusImages, CheckBoxImages checkboxImages)
		: this(null, plusMinusImages, checkboxImages)
	{
	}

	public PaletteRedirectTreeView(IPalette target, TreeViewImages plusMinusImages, CheckBoxImages checkboxImages)
		: base(target)
	{
		Debug.Assert(plusMinusImages != null);
		_plusMinusImages = plusMinusImages;
		_checkboxImages = checkboxImages;
	}

	public override Image GetTreeViewImage(bool expanded)
	{
		Image image = null;
		image = ((!expanded) ? _plusMinusImages.Plus : _plusMinusImages.Minus);
		if (image == null)
		{
			image = Target.GetTreeViewImage(expanded);
		}
		return image;
	}

	public override Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		Image image = null;
		image = checkState switch
		{
			CheckState.Checked => enabled ? ((!pressed) ? ((!tracking) ? _checkboxImages.CheckedNormal : _checkboxImages.CheckedTracking) : _checkboxImages.CheckedPressed) : _checkboxImages.CheckedDisabled, 
			CheckState.Indeterminate => enabled ? ((!pressed) ? ((!tracking) ? _checkboxImages.IndeterminateNormal : _checkboxImages.IndeterminateTracking) : _checkboxImages.IndeterminatePressed) : _checkboxImages.IndeterminateDisabled, 
			_ => enabled ? ((!pressed) ? ((!tracking) ? _checkboxImages.UncheckedNormal : _checkboxImages.UncheckedTracking) : _checkboxImages.UncheckedPressed) : _checkboxImages.UncheckedDisabled, 
		};
		if (image == null)
		{
			image = _checkboxImages.Common;
		}
		if (image == null)
		{
			image = Target.GetCheckBoxImage(enabled, checkState, tracking, pressed);
		}
		return image;
	}
}
