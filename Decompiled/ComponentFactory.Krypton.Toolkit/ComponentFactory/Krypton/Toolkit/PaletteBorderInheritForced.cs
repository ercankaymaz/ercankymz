#define DEBUG
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBorderInheritForced : PaletteBorderInherit
{
	private IPaletteBorder _inherit;

	private PaletteDrawBorders _maxBorderEdges;

	private PaletteDrawBorders _forceBorderEdges;

	private PaletteGraphicsHint _forceGraphicsHint;

	private bool _forceBorders;

	private bool _borderIgnoreNormal;

	public PaletteDrawBorders MaxBorderEdges
	{
		get
		{
			return _maxBorderEdges;
		}
		set
		{
			_maxBorderEdges = value;
		}
	}

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

	public PaletteBorderInheritForced(IPaletteBorder inherit)
	{
		_inherit = inherit;
		_maxBorderEdges = PaletteDrawBorders.All;
		_forceGraphicsHint = PaletteGraphicsHint.Inherit;
		_borderIgnoreNormal = false;
	}

	public void SetInherit(IPaletteBorder paletteBorder)
	{
		Debug.Assert(paletteBorder != null);
		_inherit = paletteBorder;
	}

	public void ForceBorderEdges(PaletteDrawBorders forceBorderEdges)
	{
		_forceBorderEdges = forceBorderEdges;
		_forceBorders = true;
	}

	public override InheritBool GetBorderDraw(PaletteState state)
	{
		return _inherit.GetBorderDraw(state);
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
	{
		if (_forceBorders)
		{
			return _forceBorderEdges;
		}
		if (_maxBorderEdges == PaletteDrawBorders.None || (_borderIgnoreNormal && state == PaletteState.Normal))
		{
			return PaletteDrawBorders.None;
		}
		PaletteDrawBorders borderDrawBorders = _inherit.GetBorderDrawBorders(state);
		return borderDrawBorders & _maxBorderEdges;
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
	{
		if (_forceGraphicsHint != PaletteGraphicsHint.Inherit)
		{
			return _forceGraphicsHint;
		}
		return _inherit.GetBorderGraphicsHint(state);
	}

	public override Color GetBorderColor1(PaletteState state)
	{
		return _inherit.GetBorderColor1(state);
	}

	public override Color GetBorderColor2(PaletteState state)
	{
		return _inherit.GetBorderColor2(state);
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteState state)
	{
		return _inherit.GetBorderColorStyle(state);
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
	{
		return _inherit.GetBorderColorAlign(state);
	}

	public override float GetBorderColorAngle(PaletteState state)
	{
		return _inherit.GetBorderColorAngle(state);
	}

	public override int GetBorderWidth(PaletteState state)
	{
		return _inherit.GetBorderWidth(state);
	}

	public override int GetBorderRounding(PaletteState state)
	{
		return _inherit.GetBorderRounding(state);
	}

	public override Image GetBorderImage(PaletteState state)
	{
		return _inherit.GetBorderImage(state);
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteState state)
	{
		return _inherit.GetBorderImageStyle(state);
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
	{
		return _inherit.GetBorderImageAlign(state);
	}
}
