using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBackToPalette : IPaletteBack
{
	private IPalette _palette;

	private PaletteBackStyle _style;

	public PaletteBackStyle BackStyle
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

	public PaletteBackToPalette(IPalette palette, PaletteBackStyle style)
	{
		_palette = palette;
		_style = style;
	}

	public InheritBool GetBackDraw(PaletteState state)
	{
		return _palette.GetBackDraw(_style, state);
	}

	public PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		return _palette.GetBackGraphicsHint(_style, state);
	}

	public Color GetBackColor1(PaletteState state)
	{
		return _palette.GetBackColor1(_style, state);
	}

	public Color GetBackColor2(PaletteState state)
	{
		return _palette.GetBackColor2(_style, state);
	}

	public PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		return _palette.GetBackColorStyle(_style, state);
	}

	public PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		return _palette.GetBackColorAlign(_style, state);
	}

	public float GetBackColorAngle(PaletteState state)
	{
		return _palette.GetBackColorAngle(_style, state);
	}

	public Image GetBackImage(PaletteState state)
	{
		return _palette.GetBackImage(_style, state);
	}

	public PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		return _palette.GetBackImageStyle(_style, state);
	}

	public PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		return _palette.GetBackImageAlign(_style, state);
	}
}
