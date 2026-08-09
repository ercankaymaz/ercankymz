#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawBorderEdge : ViewDrawPanel
{
	private PaletteBorderEdge _palette;

	private PaletteBackInheritForced _borderForced;

	private Orientation _orientation;

	public Orientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public ViewDrawBorderEdge(PaletteBorderEdge palette, Orientation orientation)
		: base(palette)
	{
		Debug.Assert(palette != null);
		_palette = palette;
		Orientation = orientation;
		_borderForced = new PaletteBackInheritForced(palette);
		_borderForced.ForceGraphicsHint = PaletteGraphicsHint.None;
		SetPalettes(_borderForced);
	}

	public override string ToString()
	{
		return "ViewDrawBorderEdge:" + base.Id;
	}

	public void SetPalettes(PaletteBorderEdge palette)
	{
		Debug.Assert(palette != null);
		_palette = palette;
		_borderForced.SetInherit(palette);
		SetPalettes(_borderForced);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Size empty = Size.Empty;
		if (Orientation == Orientation.Horizontal)
		{
			empty.Height = _palette.GetBorderWidth(State);
		}
		else
		{
			empty.Width = _palette.GetBorderWidth(State);
		}
		return empty;
	}
}
