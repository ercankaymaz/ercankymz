using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

[DefaultProperty("Items")]
[DefaultEvent("SelectedIndexChanged")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class buListBox : ListBox
{
	private Font font_0 = new Font("Microsoft Sans Serif", 10f);

	private Color color_0 = Color.Black;

	private buControlDisplay buControlDisplay_0 = new buControlDisplay();

	private buControlGeometry buControlGeometry_0 = new buControlGeometry();

	private buControlTheme buControlTheme_0 = new buControlTheme();

	private Image image_0;

	private ThemeType themeType_0 = ThemeType.Standart;

	private string string_0;

	private ControlStyle controlStyle_0 = ControlStyle.None;

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

	public buListBox()
	{
		Class76.smethod_439();
		Display.Parent = this;
		Theme.Parent = this;
		DrawMode = DrawMode.OwnerDrawVariable;
		ItemHeight = 25;
		base.BorderStyle = BorderStyle.None;
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	public static buListBox CopyVisual(buListBox refList, buListBox copyList)
	{
		copyList.Display = buControlDisplay.Copy(refList.Display, copyList.Display);
		copyList.Geometry.Space = refList.Geometry.Space;
		copyList.Geometry.ArcDiameter = refList.Geometry.ArcDiameter;
		copyList.Geometry.ShapeMode = refList.Geometry.ShapeMode;
		return copyList;
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
					e.Graphics.FillRectangle(new SolidBrush(Display.BackColor), e.Bounds);
					if (Display.Border.Visible)
					{
						if (e.Index == 0)
						{
							e.Graphics.DrawLine(new Pen(Display.Border.Color, Display.Border.Thickness), new Point(e.Bounds.X, e.Bounds.Y), new Point(e.Bounds.Width, e.Bounds.Y));
						}
						e.Graphics.DrawLine(new Pen(Display.Border.Color, Display.Border.Thickness), new Point(e.Bounds.X, e.Bounds.Y), new Point(e.Bounds.X, e.Bounds.Y + ItemHeight));
						e.Graphics.DrawLine(new Pen(Display.Border.Color, Display.Border.Thickness), new Point(e.Bounds.Width - 1, e.Bounds.Y), new Point(e.Bounds.Width - 1, e.Bounds.Y + ItemHeight));
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
			_ = Text;
			RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RectangleF rectangleF2 = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			Graphics Grph = e.Graphics;
			if (Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(Theme.Type, ref Vars);
				Geometry = new buControlGeometry(Vars.Geometry);
				Display = new buControlDisplay(Vars.Display);
				Display.Parent = this;
			}
			ControlGeometry.drawGeometry(base.ClientRectangle, Geometry, Display, RoundRectangleType.RoundRectAll, ref Grph);
			if (((base.Width > 0) & (base.Height > 0)) && base.Items.Count > 0)
			{
				for (int i = 0; i <= base.Items.Count - 1; i++)
				{
					Rectangle itemRectangle = GetItemRectangle(i);
					if (e.ClipRectangle.IntersectsWith(itemRectangle))
					{
						if ((SelectionMode != SelectionMode.One || SelectedIndex != i) && (SelectionMode != SelectionMode.MultiSimple || !base.SelectedIndices.Contains(i)) && (SelectionMode != SelectionMode.MultiExtended || !base.SelectedIndices.Contains(i)))
						{
							OnDrawItem(new DrawItemEventArgs(e.Graphics, Display.Fonts.Font, itemRectangle, i, DrawItemState.Default, Display.Fonts.ForeColor, Display.BackColor));
						}
						else
						{
							OnDrawItem(new DrawItemEventArgs(e.Graphics, Display.Fonts.Font, itemRectangle, i, DrawItemState.Selected, Display.Fonts.ForeColor, Display.BackColor));
						}
					}
				}
			}
			themeType_0 = Theme.Type;
			base.OnPaint(e);
		}
		catch (Exception)
		{
		}
	}
}
