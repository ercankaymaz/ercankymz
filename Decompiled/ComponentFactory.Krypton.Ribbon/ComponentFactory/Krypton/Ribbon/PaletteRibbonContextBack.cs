#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class PaletteRibbonContextBack : IPaletteRibbonBack
{
	private KryptonRibbon _ribbon;

	private IPaletteRibbonBack _inherit;

	public PaletteRibbonContextBack(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
	}

	public void SetInherit(IPaletteRibbonBack inherit)
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
		else if (state == PaletteState.ContextNormal || state == PaletteState.ContextTracking || state == PaletteState.ContextPressed)
		{
			Color color2 = CheckForContextColor(state);
			return CommonHelper.MergeColors(color, 0.5f, color2, 0.5f);
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

	private Color CheckForContextColor(PaletteState state)
	{
		if (_ribbon != null)
		{
			KryptonRibbonTab selectedTab = _ribbon.SelectedTab;
			if (!string.IsNullOrEmpty(selectedTab.ContextName))
			{
				KryptonRibbonContext kryptonRibbonContext = _ribbon.RibbonContexts[selectedTab.ContextName];
				if (kryptonRibbonContext != null)
				{
					return kryptonRibbonContext.ContextColor;
				}
			}
		}
		return Color.Empty;
	}
}
