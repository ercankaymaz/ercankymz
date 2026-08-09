using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

[DefaultProperty("Items")]
[DefaultEvent("SelectedIndexChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class buComboBox : ComboBox
{
	private Font font_0 = new Font("Microsoft Sans Serif", 10f);

	private Color color_0 = Color.Black;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlGeometry buControlGeometry_0 = new buControlGeometry();

	private buControlLanguage buControlLanguage_0 = new buControlLanguage();

	private buControlCaption buControlCaption_0 = new buControlCaption();

	private buControlSecurity buControlSecurity_0 = new buControlSecurity();

	private buControlCombo buControlCombo_0 = new buControlCombo();

	private buControlTheme buControlTheme_0 = new buControlTheme();

	private Image image_0;

	private string string_0;

	private ControlStyle controlStyle_0 = ControlStyle.None;

	private rectDraw rectDraw_0 = new rectDraw();

	private RectangleF rectangleF_0 = default(RectangleF);

	private ThemeType themeType_0 = ThemeType.Standart;

	private HotkeyPrefix hotkeyPrefix_0 = HotkeyPrefix.None;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlCombo Combo
	{
		get
		{
			return buControlCombo_0;
		}
		set
		{
			buControlCombo_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string AuxInfo
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
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
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlCaption Caption
	{
		get
		{
			return buControlCaption_0;
		}
		set
		{
			buControlCaption_0 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlLanguage Language
	{
		get
		{
			return buControlLanguage_0;
		}
		set
		{
			buControlLanguage_0 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlSecurity Security
	{
		get
		{
			return buControlSecurity_0;
		}
		set
		{
			buControlSecurity_0 = value;
			Invalidate();
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
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
			Invalidate();
		}
	}

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

	[DefaultValue(null)]
	public Image ItemImage
	{
		get
		{
			return image_0;
		}
		set
		{
			image_0 = value;
			Invalidate();
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

	public buComboBox()
	{
		Class76.smethod_317();
		Display.Parent = this;
		Caption.Parent = this;
		Caption.Display.Parent = this;
		Combo.Parent = this;
		Theme.Parent = this;
		base.DrawMode = DrawMode.OwnerDrawFixed;
		base.DropDownStyle = ComboBoxStyle.DropDownList;
		base.ItemHeight = 25;
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		SuspendLayout();
		Update();
		ResumeLayout();
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		base.OnPaintBackground(e);
	}

	protected override void OnDrawItem(DrawItemEventArgs e)
	{
		try
		{
			if (base.Items.Count > 0)
			{
				e.DrawBackground();
				if (Convert.ToInt32(e.State & DrawItemState.Selected) != 1)
				{
					e.Graphics.FillRectangle(new SolidBrush(Combo.DropBoxColor), e.Bounds);
					if (Display.Border.Visible)
					{
						if (e.Index == 0)
						{
							e.Graphics.DrawLine(new Pen(Display.Border.Color, Display.Border.Thickness), new Point(e.Bounds.X, e.Bounds.Y), new Point(e.Bounds.Width, e.Bounds.Y));
						}
						e.Graphics.DrawLine(new Pen(Display.Border.Color, Display.Border.Thickness), new Point(e.Bounds.X, e.Bounds.Y), new Point(e.Bounds.X, e.Bounds.Y + base.ItemHeight));
						e.Graphics.DrawLine(new Pen(Display.Border.Color, Display.Border.Thickness), new Point(e.Bounds.Width - 1, e.Bounds.Y), new Point(e.Bounds.Width - 1, e.Bounds.Y + base.ItemHeight));
					}
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(Display.SelectionColor), e.Bounds);
				}
				using (new SolidBrush(Display.Fonts.ForeColor))
				{
					if (base.Items.Count == 0)
					{
						return;
					}
					e.Graphics.DrawString(GetItemText(base.Items[e.Index]), Display.Fonts.Font, new SolidBrush(Display.Fonts.ForeColor), e.Bounds);
				}
			}
			base.OnDrawItem(e);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		try
		{
			string caption = Caption.Caption;
			RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RectangleF rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RectangleF rectangle = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width - 1, base.ClientRectangle.Height - 1);
			_ = (float)Caption.Width;
			_ = (float)base.Height;
			Graphics Grph = e.Graphics;
			if (Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(Theme.Type, ref Vars);
				Geometry = new buControlGeometry(Vars.Geometry);
				Display = new buControlDisplay(Vars.Display);
				Caption.Display = new buControlDisplay(Vars.Caption.Display);
				Combo = new buControlCombo(Vars.Combo);
				Display.Parent = this;
				Combo.Parent = this;
				Caption.Parent = this;
				Caption.Display.Parent = this;
			}
			caption = ControlGeometry.LanguageSelect(Language, caption);
			ControlGeometry.CalcMainArea(base.Width, base.Height, Geometry, Caption, ref rectDraw_0, ref rectangleF_0);
			ControlGeometry.drawGeometry(base.ClientRectangle, Geometry.ArcDiameter, Geometry.ShapeMode, Display, RoundRectangleType.RoundRectAll, ref Grph);
			GraphicsPath graphicsPath = null;
			graphicsPath = ((Geometry.ShapeMode == ShapeType.Arc) ? ControlGeometry.RoundRect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, Geometry.ArcDiameter) : ControlGeometry.Rectangle(rectangle));
			Grph.SetClip(graphicsPath);
			Grph.FillPath(new SolidBrush(Combo.ValueColor), graphicsPath);
			Grph.ResetClip();
			Grph.DrawPath(new Pen(Display.Border.Color, Display.Border.Thickness), graphicsPath);
			if (!Caption.OnTop)
			{
				rectDraw_0.rect.X = rectDraw_0.rect.X - 1f;
				rectDraw_0.rect.Y = rectDraw_0.rect.Y - 1f;
				rectDraw_0.rect.Width = rectDraw_0.rect.Width + 2f;
				rectDraw_0.rect.Height = rectDraw_0.rect.Height + 2f;
				ControlGeometry.drawGeometry(rectDraw_0.rect, Geometry, Caption.Display, rectDraw_0.RoundType, ref Grph);
				ControlGeometry.drawString(rectDraw_0.rectText, caption, Caption.Display, hotkeyPrefix_0, ref Grph);
			}
			else
			{
				rectDraw_0.rect.X = rectDraw_0.rect.X - 1f;
				rectDraw_0.rect.Y = rectDraw_0.rect.Y - 1f;
				rectDraw_0.rect.Width = rectDraw_0.rect.Width + 1f;
				rectDraw_0.rect.Height = rectDraw_0.rect.Height + 1f;
				ControlGeometry.drawGeometry(rectDraw_0.rect, Geometry, Caption.Display, rectDraw_0.RoundType, ref Grph);
				ControlGeometry.drawString(rectDraw_0.rectText, caption, Caption.Display, hotkeyPrefix_0, ref Grph);
			}
			if (Caption.Visible)
			{
				if (Caption.OnTop)
				{
					rect.X = rectangle.X + 1f;
					rect.Width = rectangle.Width - 2f;
				}
				else
				{
					rect.X = rectDraw_0.rect.X + rectDraw_0.rect.Width + 1f;
					rect.Width = rectangle.Width - 1f - (rectDraw_0.rect.X + rectDraw_0.rect.Width + (float)Combo.ArrowButtonWidth + 1f);
				}
			}
			ControlGeometry.drawString(rect, Text, Display, hotkeyPrefix_0, ref Grph);
			int num = base.Width - Convert.ToInt32((float)Combo.ArrowButtonWidth / 2f);
			Grph.DrawLine(new Pen(Combo.ArrowColor, 2f), new PointF(num - 4, 10f), new PointF(num, 14f));
			Grph.DrawLine(new Pen(Combo.ArrowColor, 2f), new PointF(num, 14f), new PointF(num + 4, 10f));
			Grph.DrawLine(new Pen(Combo.ArrowLineColor), new PointF(base.Width - Combo.ArrowButtonWidth, 0f), new PointF(base.Width - Combo.ArrowButtonWidth, base.Height - 1));
			themeType_0 = Theme.Type;
			base.OnPaint(e);
		}
		catch (Exception)
		{
		}
	}

	public static buComboBox CopyVisual(buComboBox refCombo, buComboBox copyCombo)
	{
		copyCombo.Display = buControlDisplay.Copy(refCombo.Display, copyCombo.Display);
		copyCombo.Caption.Display = buControlDisplay.Copy(refCombo.Caption.Display, copyCombo.Caption.Display);
		copyCombo.Combo.DropBoxColor = refCombo.Combo.DropBoxColor;
		copyCombo.Combo.ArrowColor = refCombo.Combo.ArrowColor;
		copyCombo.Combo.ArrowLineColor = refCombo.Combo.ArrowLineColor;
		copyCombo.Combo.ValueColor = refCombo.Combo.ValueColor;
		copyCombo.Combo.ArrowButtonWidth = refCombo.Combo.ArrowButtonWidth;
		copyCombo.Geometry.Space = refCombo.Geometry.Space;
		copyCombo.Geometry.ArcDiameter = refCombo.Geometry.ArcDiameter;
		copyCombo.Geometry.ShapeMode = refCombo.Geometry.ShapeMode;
		return copyCombo;
	}
}
