#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecExpandRibbon : ButtonSpec
{
	private KryptonRibbon _ribbon;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool AllowComponent => false;

	public PaletteButtonSpecStyle ButtonSpecType
	{
		get
		{
			return base.ProtectedType;
		}
		set
		{
			base.ProtectedType = value;
		}
	}

	public ButtonSpecExpandRibbon(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		base.ProtectedType = PaletteButtonSpecStyle.RibbonExpand;
	}

	public override bool GetVisible(IPalette palette)
	{
		return _ribbon.ShowMinimizeButton && _ribbon.MinimizedMode;
	}

	public override ButtonEnabled GetEnabled(IPalette palette)
	{
		return ButtonEnabled.True;
	}

	public override ButtonCheckState GetChecked(IPalette palette)
	{
		return ButtonCheckState.NotCheckButton;
	}

	public override ButtonStyle GetStyle(IPalette palette)
	{
		return ButtonStyle.ButtonSpec;
	}

	protected override void OnClick(EventArgs e)
	{
		if (GetViewEnabled() && !_ribbon.InDesignMode)
		{
			_ribbon.MinimizedMode = false;
		}
	}
}
