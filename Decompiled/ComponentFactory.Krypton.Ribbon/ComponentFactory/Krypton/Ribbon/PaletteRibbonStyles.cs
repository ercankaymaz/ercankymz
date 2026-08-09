#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonStyles : Storage
{
	private KryptonRibbon _ribbon;

	[Browsable(false)]
	public override bool IsDefault => BackStyle == PaletteBackStyle.PanelClient && GroupButtonStyle == ButtonStyle.ButtonSpec && GroupClusterButtonStyle == ButtonStyle.Cluster && GroupDialogButtonStyle == ButtonStyle.ButtonSpec && GroupCollapsedButtonStyle == ButtonStyle.Alternate && QATButtonStyle == ButtonStyle.ButtonSpec && ScrollerStyle == ButtonStyle.Standalone;

	[Category("Visuals")]
	[Description("Ribbon background style.")]
	[DefaultValue(typeof(PaletteBackStyle), "PanelClient")]
	public PaletteBackStyle BackStyle
	{
		get
		{
			return _ribbon.BackStyle;
		}
		set
		{
			_ribbon.BackStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Ribbon background style when owning window is inactive.")]
	[DefaultValue(typeof(PaletteBackStyle), "PanelRibbonInactive")]
	public PaletteBackStyle BackInactiveStyle
	{
		get
		{
			return _ribbon.BackInactiveStyle;
		}
		set
		{
			_ribbon.BackInactiveStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Syle for buttons inside groups.")]
	[DefaultValue(typeof(ButtonStyle), "ButtonSpec")]
	public ButtonStyle GroupButtonStyle
	{
		get
		{
			return _ribbon.GroupButtonStyle;
		}
		set
		{
			_ribbon.GroupButtonStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Syle for cluster buttons inside groups.")]
	[DefaultValue(typeof(ButtonStyle), "Cluster")]
	public ButtonStyle GroupClusterButtonStyle
	{
		get
		{
			return _ribbon.GroupClusterButtonStyle;
		}
		set
		{
			_ribbon.GroupClusterButtonStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Collapsed group button style.")]
	[DefaultValue(typeof(ButtonStyle), "Alternate")]
	public ButtonStyle GroupCollapsedButtonStyle
	{
		get
		{
			return _ribbon.GroupCollapsedButtonStyle;
		}
		set
		{
			_ribbon.GroupCollapsedButtonStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Dialog box launcher button style inside groups.")]
	[DefaultValue(typeof(ButtonStyle), "ButtonSpec")]
	public ButtonStyle GroupDialogButtonStyle
	{
		get
		{
			return _ribbon.GroupDialogButtonStyle;
		}
		set
		{
			_ribbon.GroupDialogButtonStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Quick access toolbar button style.")]
	[DefaultValue(typeof(ButtonStyle), "ButtonSpec")]
	public ButtonStyle QATButtonStyle
	{
		get
		{
			return _ribbon.QATButtonStyle;
		}
		set
		{
			_ribbon.QATButtonStyle = value;
		}
	}

	[Category("Visuals")]
	[Description("Panel style.")]
	[DefaultValue(typeof(ButtonStyle), "Standalone")]
	public ButtonStyle ScrollerStyle
	{
		get
		{
			return _ribbon.ScrollerStyle;
		}
		set
		{
			_ribbon.ScrollerStyle = value;
		}
	}

	public PaletteRibbonStyles(KryptonRibbon ribbon, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		NeedPaint = needPaint;
	}
}
