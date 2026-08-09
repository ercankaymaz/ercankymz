using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBorderToPalette : IPaletteBorder
{
	private IPalette _palette;

	private PaletteBorderStyle _style;

	public PaletteBorderStyle BorderStyle
	{
		get
		{
			return _style;
		}
		set
		{
			_style = value;
		}
	}

	public PaletteBorderToPalette(IPalette palette, PaletteBorderStyle style)
	{
		_palette = palette;
		_style = style;
	}

	public InheritBool GetBorderDraw(PaletteState state)
	{
		return _palette.GetBorderDraw(_style, state);
	}

	public PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
	{
		return _palette.GetBorderDrawBorders(_style, state);
	}

	public PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
	{
		return _palette.GetBorderGraphicsHint(_style, state);
	}

	public Color GetBorderColor1(PaletteState state)
	{
		return _palette.GetBorderColor1(_style, state);
	}

	public Color GetBorderColor2(PaletteState state)
	{
		return _palette.GetBorderColor2(_style, state);
	}

	public PaletteColorStyle GetBorderColorStyle(PaletteState state)
	{
		return _palette.GetBorderColorStyle(_style, state);
	}

	public PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
	{
		return _palette.GetBorderColorAlign(_style, state);
	}

	public float GetBorderColorAngle(PaletteState state)
	{
		return _palette.GetBorderColorAngle(_style, state);
	}

	public int GetBorderWidth(PaletteState state)
	{
		return _palette.GetBorderWidth(_style, state);
	}

	public int GetBorderRounding(PaletteState state)
	{
		return _palette.GetBorderRounding(_style, state);
	}

	public Image GetBorderImage(PaletteState state)
	{
		return _palette.GetBorderImage(_style, state);
	}

	public PaletteImageStyle GetBorderImageStyle(PaletteState state)
	{
		return _palette.GetBorderImageStyle(_style, state);
	}

	public PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
	{
		return _palette.GetBorderImageAlign(_style, state);
	}
}
