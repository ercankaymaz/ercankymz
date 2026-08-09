using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace buControls.Controls;

public abstract class buContainerControl : ContainerControl
{
	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlGeometry buControlGeometry_0 = new buControlGeometry();

	private buControlTheme buControlTheme_0 = new buControlTheme();

	private Font font_0 = new Font("Microsoft Sans Serif", 10f);

	private Color color_0 = Color.Black;

	internal ContentAlignment contentAlignment_0 = ContentAlignment.MiddleCenter;

	private Image image_0;

	private int int_0 = -1;

	private int int_1 = 5;

	private string string_0 = string.Empty;

	private ImageList imageList_0;

	private ControlStyle controlStyle_0 = ControlStyle.None;

	internal ContentAlignment contentAlignment_1 = ContentAlignment.MiddleCenter;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Display
	{
		get
		{
			return buControlDisplay_0;
		}
		set
		{
			buControlDisplay_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlGeometry Geometry
	{
		get
		{
			return buControlGeometry_0;
		}
		set
		{
			buControlGeometry_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlTheme Theme
	{
		get
		{
			return buControlTheme_0;
		}
		set
		{
			buControlTheme_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DefaultValue(ContentAlignment.MiddleCenter)]
	[Localizable(true)]
	public virtual ContentAlignment TextAlign
	{
		get
		{
			return contentAlignment_0;
		}
		set
		{
			if (Enum.IsDefined(typeof(ContentAlignment), value))
			{
				if (contentAlignment_0 != value)
				{
					contentAlignment_0 = value;
					Display.Fonts.Alignment = contentAlignment_0;
					if (base.Parent != null)
					{
						base.Parent.Invalidate();
					}
					Invalidate();
				}
				return;
			}
			throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for ContentAlignment");
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Font), "Microsoft Sans Serif")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public override Font Font
	{
		get
		{
			return font_0;
		}
		set
		{
			Font font = (base.Font = value);
			font_0 = font;
			Display.Fonts.Font = font_0;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Black")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public override Color ForeColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			Display.Fonts.ForeColor = color_0;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[Localizable(true)]
	public Image Image
	{
		get
		{
			if (image_0 == null)
			{
				if (int_0 < 0 || imageList_0 == null)
				{
					if (string.IsNullOrEmpty(string_0) || imageList_0 == null)
					{
						return null;
					}
					return imageList_0.Images[string_0];
				}
				return imageList_0.Images[int_0];
			}
			return image_0;
		}
		set
		{
			if (image_0 != value)
			{
				image_0 = value;
				int_0 = -1;
				string_0 = string.Empty;
				imageList_0 = null;
				if (AutoSize && base.Parent != null)
				{
					base.Parent.PerformLayout(this, "Image");
				}
				Invalidate();
			}
		}
	}

	[DefaultValue(ContentAlignment.MiddleCenter)]
	[Localizable(true)]
	public ContentAlignment ImageAlign
	{
		get
		{
			return contentAlignment_1;
		}
		set
		{
			if (Enum.IsDefined(typeof(ContentAlignment), value))
			{
				if (contentAlignment_1 != value)
				{
					contentAlignment_1 = value;
					if (base.Parent != null)
					{
						base.Parent.Invalidate();
					}
					Invalidate();
				}
				return;
			}
			throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for ContentAlignment");
		}
	}

	[DefaultValue(-1)]
	[Localizable(true)]
	[TypeConverter(typeof(ImageIndexConverter))]
	[RefreshProperties(RefreshProperties.Repaint)]
	public int ImageIndex
	{
		get
		{
			if (ImageList != null)
			{
				if (int_0 < imageList_0.Images.Count)
				{
					if (base.Parent != null)
					{
						base.Parent.Invalidate();
					}
					return int_0;
				}
				return imageList_0.Images.Count - 1;
			}
			return -1;
		}
		set
		{
			if (value >= -1)
			{
				if (int_0 != value)
				{
					int_0 = value;
					image_0 = null;
					string_0 = string.Empty;
					if (base.Parent != null)
					{
						base.Parent.Invalidate();
					}
					Invalidate();
				}
				return;
			}
			throw new ArgumentException();
		}
	}

	[DefaultValue(5)]
	[Localizable(true)]
	public int ImageBorderOffset
	{
		get
		{
			return int_1;
		}
		set
		{
			if (int_1 != value)
			{
				int_1 = value;
				if (base.Parent != null)
				{
					base.Parent.Invalidate();
				}
				Invalidate();
			}
		}
	}

	[Localizable(true)]
	[DefaultValue("")]
	[RefreshProperties(RefreshProperties.Repaint)]
	[TypeConverter(typeof(ImageKeyConverter))]
	public string ImageKey
	{
		get
		{
			return string_0;
		}
		set
		{
			if (string_0 != value)
			{
				image_0 = null;
				int_0 = -1;
				string_0 = value;
				if (base.Parent != null)
				{
					base.Parent.Invalidate();
				}
				Invalidate();
			}
		}
	}

	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public ImageList ImageList
	{
		get
		{
			return imageList_0;
		}
		set
		{
			if (imageList_0 != value)
			{
				imageList_0 = value;
				if (imageList_0 != null && int_0 != -1)
				{
					Image = null;
				}
				if (base.Parent != null)
				{
					base.Parent.Invalidate();
				}
				Invalidate();
			}
		}
	}

	[DefaultValue(ControlStyle.None)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public ControlStyle ControlStyle
	{
		get
		{
			return controlStyle_0;
		}
		set
		{
			controlStyle_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	protected Rectangle CalcImageRenderBounds(Image image, Rectangle r, ContentAlignment align)
	{
		Rectangle result = r;
		result.Inflate(-2, -2);
		int num = r.X;
		int num2 = r.Y;
		if (align != ContentAlignment.TopCenter && align != ContentAlignment.MiddleCenter && align != ContentAlignment.BottomCenter)
		{
			if (align == ContentAlignment.TopRight || align == ContentAlignment.MiddleRight || align == ContentAlignment.BottomRight)
			{
				num += r.Width - image.Width;
			}
		}
		else
		{
			num += (r.Width - image.Width) / 2;
		}
		if (align != ContentAlignment.BottomCenter && align != ContentAlignment.BottomLeft && align != ContentAlignment.BottomRight)
		{
			if (align == ContentAlignment.MiddleCenter || align == ContentAlignment.MiddleLeft || align == ContentAlignment.MiddleRight)
			{
				num2 += (r.Height - image.Height) / 2;
			}
		}
		else
		{
			num2 += r.Height - image.Height;
		}
		result.X = num;
		result.Y = num2;
		result.Width = image.Width;
		result.Height = image.Height;
		return result;
	}

	protected internal void DrawImage(Graphics g, Image image, Rectangle r, ContentAlignment align)
	{
		if (image != null && g != null)
		{
			Rectangle rectangle = CalcImageRenderBounds(image, r, align);
			if (!base.Enabled)
			{
				ControlPaint.DrawImageDisabled(g, image, rectangle.X, rectangle.Y, BackColor);
			}
			else
			{
				g.DrawImage(image, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
			}
		}
	}
}
