#define DEBUG
using System;
using System.Diagnostics;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecMdiChildMin : ButtonSpecMdiChildFixed
{
	private KryptonRibbon _ribbon;

	public ButtonSpecMdiChildMin(KryptonRibbon ribbon)
		: base(PaletteButtonSpecStyle.PendantMin)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public override bool GetVisible(IPalette palette)
	{
		if (base.MdiChild == null || !CommonHelper.IsFormMaximized(base.MdiChild))
		{
			return false;
		}
		FormBorderStyle formBorderStyle = base.MdiChild.FormBorderStyle;
		FormBorderStyle formBorderStyle2 = formBorderStyle;
		if ((uint)(formBorderStyle2 - 5) <= 1u)
		{
			return false;
		}
		if (!base.MdiChild.ControlBox)
		{
			return false;
		}
		if (!base.MdiChild.MinimizeBox && !base.MdiChild.MaximizeBox)
		{
			return false;
		}
		return true;
	}

	public override ButtonEnabled GetEnabled(IPalette palette)
	{
		if (base.MdiChild == null)
		{
			return ButtonEnabled.False;
		}
		if (!base.MdiChild.MinimizeBox)
		{
			return ButtonEnabled.False;
		}
		return ButtonEnabled.True;
	}

	public override ButtonCheckState GetChecked(IPalette palette)
	{
		return ButtonCheckState.NotCheckButton;
	}

	protected override void OnClick(EventArgs e)
	{
		if (GetViewEnabled() && !_ribbon.InDesignMode)
		{
			base.MdiChild.WindowState = FormWindowState.Minimized;
			base.OnClick(e);
		}
	}
}
