using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBackColor1 : PaletteBack
{
	[Browsable(false)]
	public new InheritBool Draw
	{
		get
		{
			return base.Draw;
		}
		set
		{
			base.Draw = value;
		}
	}

	[Browsable(false)]
	public new PaletteGraphicsHint GraphicsHint
	{
		get
		{
			return base.GraphicsHint;
		}
		set
		{
			base.GraphicsHint = value;
		}
	}

	[Browsable(false)]
	public new Color Color2
	{
		get
		{
			return base.Color2;
		}
		set
		{
			base.Color2 = value;
		}
	}

	[Browsable(false)]
	public new PaletteColorStyle ColorStyle
	{
		get
		{
			return base.ColorStyle;
		}
		set
		{
			base.ColorStyle = value;
		}
	}

	[Browsable(false)]
	public new PaletteRectangleAlign ColorAlign
	{
		get
		{
			return base.ColorAlign;
		}
		set
		{
			base.ColorAlign = value;
		}
	}

	[Browsable(false)]
	public new float ColorAngle
	{
		get
		{
			return base.ColorAngle;
		}
		set
		{
			base.ColorAngle = value;
		}
	}

	[Browsable(false)]
	public new Image Image
	{
		get
		{
			return base.Image;
		}
		set
		{
			base.Image = value;
		}
	}

	[Browsable(false)]
	public new PaletteImageStyle ImageStyle
	{
		get
		{
			return base.ImageStyle;
		}
		set
		{
			base.ImageStyle = value;
		}
	}

	[Browsable(false)]
	public new PaletteRectangleAlign ImageAlign
	{
		get
		{
			return base.ImageAlign;
		}
		set
		{
			base.ImageAlign = value;
		}
	}

	public PaletteBackColor1(IPaletteBack inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
	}

	public new void PopulateFromBase(PaletteState state)
	{
		base.Color1 = GetBackColor1(state);
	}
}
