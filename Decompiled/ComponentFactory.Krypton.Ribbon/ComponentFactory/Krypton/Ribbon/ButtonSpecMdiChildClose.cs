#define DEBUG
using System;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecMdiChildClose : ButtonSpecMdiChildFixed
{
	private KryptonRibbon _ribbon;

	public ButtonSpecMdiChildClose(KryptonRibbon ribbon)
		: base(PaletteButtonSpecStyle.PendantClose)
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
		if (!base.MdiChild.ControlBox)
		{
			return false;
		}
		return true;
	}

	public override ButtonEnabled GetEnabled(IPalette palette)
	{
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
			base.MdiChild.Close();
			base.OnClick(e);
		}
	}
}
