using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms;

public class RibbonColorChooser : RibbonButton
{
	private Color _color;

	[Description("Height of the color preview on the large image")]
	[Category("Appearance")]
	[DefaultValue(8)]
	public int ImageColorHeight { get; set; }

	[Description("Height of the color preview on the small image")]
	[Category("Appearance")]
	[DefaultValue(4)]
	public int SmallImageColorHeight { get; set; }

	[Category("Appearance")]
	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			RedrawItem();
			OnColorChanged(EventArgs.Empty);
		}
	}

	public event EventHandler ColorChanged;

	public RibbonColorChooser()
	{
		_color = Color.Transparent;
		ImageColorHeight = 8;
		SmallImageColorHeight = 4;
	}

	private Image CreateColorBmp(Color c)
	{
		Bitmap bitmap = new Bitmap(16, 16);
		using Graphics graphics = Graphics.FromImage(bitmap);
		using (SolidBrush brush = new SolidBrush(c))
		{
			graphics.FillRectangle(brush, new Rectangle(0, 0, 15, 15));
		}
		graphics.DrawRectangle(Pens.DimGray, new Rectangle(0, 0, 15, 15));
		return bitmap;
	}

	protected void OnColorChanged(EventArgs e)
	{
		if (this.ColorChanged != null)
		{
			this.ColorChanged(this, e);
		}
	}

	public override void OnPaint(object sender, RibbonElementPaintEventArgs e)
	{
		base.OnPaint(sender, e);
		Color color = (Color.Equals(Color.Transparent) ? Color.White : Color);
		int num = ((e.Mode == RibbonElementSizeMode.Large) ? ImageColorHeight : SmallImageColorHeight);
		Rectangle rect = Rectangle.FromLTRB(base.ImageBounds.Left, base.ImageBounds.Bottom - num, base.ImageBounds.Right, base.ImageBounds.Bottom);
		SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
		e.Graphics.SmoothingMode = SmoothingMode.None;
		using (SolidBrush brush = new SolidBrush(color))
		{
			e.Graphics.FillRectangle(brush, rect);
		}
		if (Color.Equals(Color.Transparent))
		{
			e.Graphics.DrawRectangle(Pens.DimGray, rect);
		}
		e.Graphics.SmoothingMode = smoothingMode;
	}
}
