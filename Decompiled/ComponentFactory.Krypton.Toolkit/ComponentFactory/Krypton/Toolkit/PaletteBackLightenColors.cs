using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBackLightenColors : PaletteBackInherit
{
	private IPaletteBack _inherit;

	public IPaletteBack Inherit
	{
		get
		{
			return _inherit;
		}
		set
		{
			_inherit = value;
		}
	}

	public PaletteBackLightenColors(IPaletteBack inherit)
	{
		_inherit = inherit;
	}

	public override InheritBool GetBackDraw(PaletteState state)
	{
		return _inherit.GetBackDraw(state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		return _inherit.GetBackGraphicsHint(state);
	}

	public override Color GetBackColor1(PaletteState state)
	{
		return CommonHelper.MergeColors(_inherit.GetBackColor1(state), 0.4f, Color.White, 0.6f);
	}

	public override Color GetBackColor2(PaletteState state)
	{
		return CommonHelper.MergeColors(_inherit.GetBackColor2(state), 0.4f, Color.White, 0.6f);
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		return _inherit.GetBackColorStyle(state);
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		return _inherit.GetBackColorAlign(state);
	}

	public override float GetBackColorAngle(PaletteState state)
	{
		return _inherit.GetBackColorAngle(state);
	}

	public override Image GetBackImage(PaletteState state)
	{
		return _inherit.GetBackImage(state);
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		return _inherit.GetBackImageStyle(state);
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		return _inherit.GetBackImageAlign(state);
	}
}
