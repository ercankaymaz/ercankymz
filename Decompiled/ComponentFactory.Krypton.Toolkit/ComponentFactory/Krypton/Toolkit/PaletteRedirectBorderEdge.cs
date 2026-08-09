#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteRedirectBorderEdge : PaletteRedirect
{
	private PaletteBorderEdge _disabled;

	private PaletteBorderEdge _normal;

	public PaletteRedirectBorderEdge(IPalette target)
		: this(target, null, null)
	{
	}

	public PaletteRedirectBorderEdge(IPalette target, PaletteBorderEdge disabled, PaletteBorderEdge normal)
		: base(target)
	{
		_disabled = disabled;
		_normal = normal;
	}

	public virtual void SetRedirectStates(PaletteBorderEdge disabled, PaletteBorderEdge normal)
	{
		_disabled = disabled;
		_normal = normal;
	}

	public virtual void ResetRedirectStates()
	{
		_disabled = null;
		_normal = null;
	}

	public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackDraw(state) ?? Target.GetBorderDraw(style, state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		return Target.GetBorderDrawBorders(style, state);
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackGraphicsHint(state) ?? Target.GetBorderGraphicsHint(style, state);
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColor1(state) ?? Target.GetBorderColor1(style, state);
	}

	public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColor2(state) ?? Target.GetBorderColor2(style, state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColorStyle(state) ?? Target.GetBorderColorStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColorAlign(state) ?? Target.GetBorderColorAlign(style, state);
	}

	public override float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackColorAngle(state) ?? Target.GetBorderColorAngle(style, state);
	}

	public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBorderWidth(state) ?? Target.GetBorderWidth(style, state);
	}

	public override int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		return Target.GetBorderRounding(style, state);
	}

	public override Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		PaletteBorderEdge inherit = GetInherit(state);
		if (inherit != null)
		{
			return inherit.GetBackImage(state);
		}
		return Target.GetBorderImage(style, state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackImageStyle(state) ?? Target.GetBorderImageStyle(style, state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetInherit(state)?.GetBackImageAlign(state) ?? Target.GetBorderImageAlign(style, state);
	}

	private PaletteBorderEdge GetInherit(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return _disabled;
		case PaletteState.Normal:
			return _normal;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}
}
