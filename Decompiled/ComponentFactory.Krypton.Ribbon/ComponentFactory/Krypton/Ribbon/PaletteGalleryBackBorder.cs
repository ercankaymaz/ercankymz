#define DEBUG
using System.Diagnostics;
using System.Drawing;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class PaletteGalleryBackBorder : IPaletteBack, IPaletteBorder
{
	private PaletteGalleryState _state;

	public PaletteGalleryBackBorder(PaletteGalleryState state)
	{
		Debug.Assert(state != null);
		_state = state;
	}

	public void SetState(PaletteGalleryState state)
	{
		Debug.Assert(state != null);
		_state = state;
	}

	public InheritBool GetBackDraw(PaletteState state)
	{
		return InheritBool.True;
	}

	public PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		return PaletteGraphicsHint.AntiAlias;
	}

	public Color GetBackColor1(PaletteState state)
	{
		return _state.RibbonGalleryBack.GetRibbonBackColor1(state);
	}

	public Color GetBackColor2(PaletteState state)
	{
		return _state.RibbonGalleryBack.GetRibbonBackColor2(state);
	}

	public PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		return PaletteColorStyle.Solid;
	}

	public PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public float GetBackColorAngle(PaletteState state)
	{
		return 0f;
	}

	public Image GetBackImage(PaletteState state)
	{
		return null;
	}

	public PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		return PaletteImageStyle.Stretch;
	}

	public PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public InheritBool GetBorderDraw(PaletteState state)
	{
		return InheritBool.True;
	}

	public PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
	{
		return PaletteDrawBorders.TopBottomLeft;
	}

	public PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
	{
		return PaletteGraphicsHint.AntiAlias;
	}

	public Color GetBorderColor1(PaletteState state)
	{
		return _state.RibbonGalleryBorder.GetRibbonBackColor1(state);
	}

	public Color GetBorderColor2(PaletteState state)
	{
		return _state.RibbonGalleryBorder.GetRibbonBackColor2(state);
	}

	public PaletteColorStyle GetBorderColorStyle(PaletteState state)
	{
		return PaletteColorStyle.Solid;
	}

	public PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}

	public float GetBorderColorAngle(PaletteState state)
	{
		return 0f;
	}

	public int GetBorderWidth(PaletteState state)
	{
		return 1;
	}

	public int GetBorderRounding(PaletteState state)
	{
		return 0;
	}

	public Image GetBorderImage(PaletteState state)
	{
		return null;
	}

	public PaletteImageStyle GetBorderImageStyle(PaletteState state)
	{
		return PaletteImageStyle.Stretch;
	}

	public PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
	{
		return PaletteRectangleAlign.Local;
	}
}
