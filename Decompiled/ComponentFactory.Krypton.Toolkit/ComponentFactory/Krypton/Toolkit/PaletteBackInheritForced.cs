#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBackInheritForced : PaletteBackInherit
{
	private IPaletteBack _inherit;

	private PaletteGraphicsHint _forceGraphicsHint;

	private InheritBool _forceDraw;

	private bool _borderIgnoreNormal;

	public bool BorderIgnoreNormal
	{
		get
		{
			return _borderIgnoreNormal;
		}
		set
		{
			_borderIgnoreNormal = value;
		}
	}

	public PaletteGraphicsHint ForceGraphicsHint
	{
		get
		{
			return _forceGraphicsHint;
		}
		set
		{
			_forceGraphicsHint = value;
		}
	}

	public InheritBool ForceDraw
	{
		get
		{
			return _forceDraw;
		}
		set
		{
			_forceDraw = value;
		}
	}

	public PaletteBackInheritForced(IPaletteBack inherit)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		_borderIgnoreNormal = false;
		_forceGraphicsHint = PaletteGraphicsHint.Inherit;
	}

	public void SetInherit(IPaletteBack paletteBack)
	{
		Debug.Assert(paletteBack != null);
		_inherit = paletteBack;
	}

	public override InheritBool GetBackDraw(PaletteState state)
	{
		if (_forceDraw != InheritBool.Inherit)
		{
			return _forceDraw;
		}
		if (_borderIgnoreNormal && state == PaletteState.Normal)
		{
			return InheritBool.False;
		}
		return _inherit.GetBackDraw(state);
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		if (_forceGraphicsHint != PaletteGraphicsHint.Inherit)
		{
			return _forceGraphicsHint;
		}
		return _inherit.GetBackGraphicsHint(state);
	}

	public override Color GetBackColor1(PaletteState state)
	{
		return _inherit.GetBackColor1(state);
	}

	public override Color GetBackColor2(PaletteState state)
	{
		return _inherit.GetBackColor2(state);
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
