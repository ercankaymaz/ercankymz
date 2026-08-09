using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ContextToContent : RibbonToContent
{
	private Color _overrideTextColor;

	private PaletteTextHint _overrideTextHint;

	public Color OverrideTextColor
	{
		get
		{
			return _overrideTextColor;
		}
		set
		{
			_overrideTextColor = value;
		}
	}

	public PaletteTextHint OverrideTextHint
	{
		get
		{
			return _overrideTextHint;
		}
		set
		{
			_overrideTextHint = value;
		}
	}

	public ContextToContent(PaletteRibbonGeneral ribbonGeneral)
		: base(ribbonGeneral)
	{
		_overrideTextColor = Color.Empty;
		_overrideTextHint = PaletteTextHint.Inherit;
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteState state)
	{
		return PaletteTextTrim.Character;
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		return base.RibbonGeneral.GetRibbonContextTextAlign(state);
	}

	public override Font GetContentShortTextFont(PaletteState state)
	{
		return base.RibbonGeneral.GetRibbonContextTextFont(state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteState state)
	{
		if (_overrideTextHint != PaletteTextHint.Inherit)
		{
			return _overrideTextHint;
		}
		return base.RibbonGeneral.GetRibbonTextHint(state);
	}

	public override Color GetContentShortTextColor1(PaletteState state)
	{
		if (_overrideTextColor != Color.Empty)
		{
			return _overrideTextColor;
		}
		return base.RibbonGeneral.GetRibbonContextTextColor(state);
	}

	public override Color GetContentShortTextColor2(PaletteState state)
	{
		if (_overrideTextColor != Color.Empty)
		{
			return _overrideTextColor;
		}
		return base.RibbonGeneral.GetRibbonContextTextColor(state);
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteState state)
	{
		return PaletteTextTrim.Character;
	}

	public override Font GetContentLongTextFont(PaletteState state)
	{
		return base.RibbonGeneral.GetRibbonContextTextFont(state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteState state)
	{
		if (_overrideTextHint != PaletteTextHint.Inherit)
		{
			return _overrideTextHint;
		}
		return base.RibbonGeneral.GetRibbonTextHint(state);
	}

	public override Color GetContentLongTextColor1(PaletteState state)
	{
		if (_overrideTextColor != Color.Empty)
		{
			return _overrideTextColor;
		}
		return base.RibbonGeneral.GetRibbonContextTextColor(state);
	}

	public override Color GetContentLongTextColor2(PaletteState state)
	{
		if (_overrideTextColor != Color.Empty)
		{
			return _overrideTextColor;
		}
		return base.RibbonGeneral.GetRibbonContextTextColor(state);
	}
}
