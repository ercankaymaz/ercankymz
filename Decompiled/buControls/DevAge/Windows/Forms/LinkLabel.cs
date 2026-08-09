using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
[DefaultEvent("Click")]
public class LinkLabel : UserControl
{
	private System.ComponentModel.Container container_0 = null;

	private System.Drawing.Image image_0;

	private System.Drawing.Image image_1;

	private System.Drawing.Image image_2;

	private DevAge.Drawing.ContentAlignment contentAlignment_0 = DevAge.Drawing.ContentAlignment.MiddleLeft;

	private StringFormat stringFormat_0 = new StringFormat(StringFormat.GenericDefault);

	private bool bool_0 = true;

	private bool bool_1 = false;

	private bool bool_2 = false;

	private int int_0 = 0;

	private double double_0 = 0.0;

	private Color color_0 = Color.Black;

	private Color color_1 = Color.FromKnownColor(KnownColor.Control);

	private bool bool_3 = false;

	[DefaultValue(null)]
	public System.Drawing.Image Image
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	[DefaultValue(null)]
	public System.Drawing.Image MouseOverImage
	{
		get
		{
			return image_1;
		}
		set
		{
			image_1 = value;
		}
	}

	[DefaultValue(null)]
	public System.Drawing.Image DisabledImage
	{
		get
		{
			return image_2;
		}
		set
		{
			image_2 = value;
		}
	}

	[DefaultValue(DevAge.Drawing.ContentAlignment.MiddleLeft)]
	public DevAge.Drawing.ContentAlignment ImageAlignment
	{
		get
		{
			return contentAlignment_0;
		}
		set
		{
			contentAlignment_0 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	public DevAge.Drawing.ContentAlignment TextAlignment
	{
		get
		{
			return DevAge.Drawing.Utilities.StringFormatToContentAlignment(stringFormat_0);
		}
		set
		{
			DevAge.Drawing.Utilities.ApplyContentAlignmentToStringFormat(value, stringFormat_0);
			Invalidate(invalidateChildren: true);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public StringFormat StringFormat
	{
		get
		{
			return stringFormat_0;
		}
		set
		{
			stringFormat_0 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	[DefaultValue(true)]
	public bool AlignTextToImage
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	[DefaultValue(false)]
	public bool ImageStretch
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	[DefaultValue(false)]
	public bool EnableMouseEffect
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[DefaultValue(0)]
	public int BorderWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	[DefaultValue(0)]
	public double BorderRound
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	public Color BorderColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			Invalidate(invalidateChildren: true);
		}
	}

	public new Color BackColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			Invalidate();
		}
	}

	public LinkLabel()
	{
		Class76.smethod_290(this);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		SetStyle(ControlStyles.StandardClick, value: true);
		SetStyle(ControlStyles.StandardDoubleClick, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.UserPaint, value: true);
		base.BackColor = Color.Transparent;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		bool_3 = true;
		Invalidate();
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		bool_3 = false;
		Invalidate();
	}

	protected virtual void DrawBorderAndFill(Graphics graphics)
	{
		int num = BorderWidth;
		double borderRound = BorderRound;
		Color color = BorderColor;
		Color color2 = BackColor;
		if (bool_2 && bool_3 && base.Enabled)
		{
			Color color3 = Color.FromKnownColor(KnownColor.Highlight);
			color2 = Color.FromArgb(75, color3);
			if (num == 0)
			{
				num = 1;
			}
			color = color3;
		}
		RoundedRectangle roundRect = new RoundedRectangle(base.ClientRectangle, borderRound);
		using (SolidBrush brush = new SolidBrush(color2))
		{
			DevAge.Drawing.Utilities.FillRoundedRectangle(graphics, roundRect, brush);
		}
		if (num > 0)
		{
			using (Pen pen = new Pen(color, num))
			{
				DevAge.Drawing.Utilities.DrawRoundedRectangle(graphics, roundRect, pen);
			}
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		if (BorderRound > 0.0)
		{
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		}
		DrawBorderAndFill(e.Graphics);
		bool flag = false;
		System.Drawing.Image value = image_0;
		if (base.Enabled)
		{
			if (bool_3 && image_1 != null)
			{
				value = image_1;
			}
		}
		else if (image_2 == null)
		{
			flag = true;
		}
		else
		{
			value = image_2;
		}
		Rectangle rectangle = base.ClientRectangle;
		if (BorderWidth > 0)
		{
			rectangle = new Rectangle(rectangle.X + BorderWidth, rectangle.Y + BorderWidth, rectangle.Width - BorderWidth * 2, rectangle.Height - BorderWidth * 2);
		}
		DevAge.Drawing.VisualElements.Container container = new DevAge.Drawing.VisualElements.Container();
		TextGDI textGDI = new TextGDI(Text);
		DevAge.Drawing.VisualElements.Image image = new DevAge.Drawing.VisualElements.Image(value);
		image.AnchorArea = new AnchorArea(contentAlignment_0, bool_1);
		image.Enabled = !flag;
		textGDI.AnchorArea = new AnchorArea(DevAge.Drawing.Utilities.StringFormatToContentAlignment(stringFormat_0), stretch: false);
		textGDI.StringFormat = stringFormat_0;
		textGDI.Font = Font;
		textGDI.ForeColor = ForeColor;
		textGDI.Enabled = base.Enabled;
		container.Elements.Add(image);
		container.Elements.Add(textGDI);
		using GraphicsCache graphics = new GraphicsCache(e.Graphics, e.ClipRectangle);
		container.Draw(graphics, rectangle);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		Invalidate(invalidateChildren: true);
	}
}
