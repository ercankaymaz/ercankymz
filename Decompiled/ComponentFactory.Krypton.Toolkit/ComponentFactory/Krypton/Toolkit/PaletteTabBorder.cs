using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTabBorder : PaletteBorder
{
	[Browsable(false)]
	public override bool IsDefault => base.Draw == InheritBool.Inherit && base.GraphicsHint == PaletteGraphicsHint.Inherit && base.Color1 == Color.Empty && base.Color2 == Color.Empty && base.ColorStyle == PaletteColorStyle.Inherit && base.ColorAlign == PaletteRectangleAlign.Inherit && base.ColorAngle == -1f && base.Width == -1 && base.Image == null && base.ImageStyle == PaletteImageStyle.Inherit && base.ImageAlign == PaletteRectangleAlign.Inherit;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new PaletteDrawBorders DrawBorders
	{
		get
		{
			return base.DrawBorders;
		}
		set
		{
			base.DrawBorders = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new int Rounding
	{
		get
		{
			return base.Rounding;
		}
		set
		{
			base.Rounding = value;
		}
	}

	public PaletteTabBorder(IPaletteBorder inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
	}
}
