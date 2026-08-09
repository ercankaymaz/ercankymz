#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonContextDouble : IPaletteRibbonBack, IPaletteRibbonText
{
	private KryptonRibbon _ribbon;

	private KryptonRibbonTab _ribbonTab;

	private PaletteRibbonDoubleInheritOverride _inherit;

	private bool _lightBackground;

	public KryptonRibbonTab RibbonTab
	{
		get
		{
			return _ribbonTab;
		}
		set
		{
			_ribbonTab = value;
		}
	}

	public bool LightBackground
	{
		get
		{
			return _lightBackground;
		}
		set
		{
			_lightBackground = value;
		}
	}

	public PaletteRibbonContextDouble(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_lightBackground = false;
	}

	public void SetInherit(PaletteRibbonDoubleInheritOverride inherit)
	{
		_inherit = inherit;
	}

	public PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteState state)
	{
		return _inherit.GetRibbonBackColorStyle(state);
	}

	public Color GetRibbonBackColor1(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor1(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor2(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor2(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor3(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor3(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor4(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor4(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonBackColor5(PaletteState state)
	{
		Color color = _inherit.GetRibbonBackColor5(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		return color;
	}

	public Color GetRibbonTextColor(PaletteState state)
	{
		Color color = _inherit.GetRibbonTextColor(state);
		if (color == Color.Empty)
		{
			color = CheckForContextColor(state);
		}
		else if (state == PaletteState.Normal && LightBackground)
		{
			return Color.FromArgb(Math.Min(color.R, (byte)60), Math.Min(color.G, (byte)60), Math.Min(color.B, (byte)60));
		}
		return color;
	}

	private Color CheckForContextColor(PaletteState state)
	{
		if (_ribbonTab != null && !string.IsNullOrEmpty(_ribbonTab.ContextName))
		{
			KryptonRibbonContext kryptonRibbonContext = _ribbon.RibbonContexts[_ribbonTab.ContextName];
			if (kryptonRibbonContext != null)
			{
				return kryptonRibbonContext.ContextColor;
			}
		}
		return Color.Empty;
	}
}
