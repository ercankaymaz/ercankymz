using System.Drawing;

namespace System.Windows.Forms;

public class RibbonToolTipRenderEventArgs : RibbonRenderEventArgs
{
	private Font font = new Font("Arial", 8f);

	public string Text { get; set; }

	public Color Color { get; set; }

	public StringFormat Format { get; set; }

	public FontStyle Style { get; set; }

	public Font Font
	{
		get
		{
			return font;
		}
		set
		{
			font = value;
		}
	}

	public Image TipImage { get; set; }

	public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string text)
		: base(owner, g, clip)
	{
		Text = text;
	}

	public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string Text, Image tipImage)
		: base(owner, g, clip)
	{
		this.Text = Text;
		TipImage = tipImage;
	}

	public RibbonToolTipRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, string Text, Image tipImage, Color color, FontStyle style, StringFormat format, Font font)
		: base(owner, g, clip)
	{
		this.Text = Text;
		Color = Color;
		Style = style;
		Format = format;
		TipImage = tipImage;
		Font = font;
	}
}
