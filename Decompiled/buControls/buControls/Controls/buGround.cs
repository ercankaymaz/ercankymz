using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

public class buGround : buContainerControl
{
	protected MouseState State;

	private ThemeType themeType_0 = ThemeType.Standart;

	private Point point_0 = new Point(0, 0);

	private bool bool_0 = false;

	public bool HasShown;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	internal bool bool_9;

	internal bool bool_10;

	internal bool bool_11;

	internal bool bool_12;

	internal bool bool_13;

	internal bool bool_14;

	internal bool bool_15;

	internal bool bool_16;

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	private buControlDisplay buControlDisplay_2 = new buControlDisplay();

	private buControlGround buControlGround_0 = new buControlGround();

	private buControlLanguage buControlLanguage_0 = new buControlLanguage();

	private bool bool_17 = true;

	private string string_1;

	private bool bool_18 = true;

	private bool bool_19 = false;

	private bool bool_20;

	private FormStartPosition formStartPosition_0;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string AuxInfo
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
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
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay DisplayTop
	{
		get
		{
			return buControlDisplay_1;
		}
		set
		{
			buControlDisplay_1 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay DisplayBottom
	{
		get
		{
			return buControlDisplay_2;
		}
		set
		{
			buControlDisplay_2 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlGround Ground
	{
		get
		{
			return buControlGround_0;
		}
		set
		{
			buControlGround_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[SettingsBindable(true)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
			Invalidate();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(false)]
	public bool Sizable
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(false)]
	public bool SmartBounds
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	protected bool IsParentForm => bool_19;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(false)]
	protected bool IsParentMdi
	{
		get
		{
			if (base.Parent != null)
			{
				return base.Parent.Parent != null;
			}
			return false;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(false)]
	protected bool ControlMode
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
			Invalidate();
		}
	}

	public FormStartPosition StartPosition
	{
		get
		{
			if (!bool_19 || bool_20)
			{
				return formStartPosition_0;
			}
			return base.ParentForm.StartPosition;
		}
		set
		{
			formStartPosition_0 = value;
			if (bool_19 && !bool_20)
			{
				base.ParentForm.StartPosition = value;
			}
		}
	}

	public buGround()
	{
		try
		{
			Class76.smethod_749();
			TextAlign = ContentAlignment.MiddleCenter;
			base.ImageAlign = ContentAlignment.MiddleLeft;
			Ground.Parent = this;
			base.Display.Parent = this;
			DisplayBottom.Parent = this;
			DisplayTop.Parent = this;
			base.Theme.Parent = this;
			Language.Parent = this;
			DisplayTop.BackColor = Color.Gray;
			DisplayBottom.BackColor = Color.Gray;
			SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
			SetStyle(ControlStyles.UserPaint, value: true);
			BackColor = Color.Transparent;
			DoubleBuffered = true;
		}
		catch (Exception)
		{
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Cursor = Cursors.Default;
		if (bool_0)
		{
			base.ParentForm.Location = new Point(Control.MousePosition.X - point_0.X, Control.MousePosition.Y - point_0.Y);
		}
		int num = Cursor.Position.X;
		int num2 = Cursor.Position.Y;
		Class76.smethod_562(this);
		if (!((Cursor.Position.X > base.ParentForm.Location.X + base.ParentForm.Width - 3) & (Cursor.Position.Y > base.ParentForm.Location.Y + 3) & (Cursor.Position.Y < base.ParentForm.Location.Y + base.ParentForm.Height - 3)))
		{
			if (!((Cursor.Position.X < base.ParentForm.Location.X + 3) & (Cursor.Position.Y > base.ParentForm.Location.Y + 3) & (Cursor.Position.Y < base.ParentForm.Location.Y + base.ParentForm.Height - 3)))
			{
				if (!((Cursor.Position.Y < base.ParentForm.Location.Y + 3) & (Cursor.Position.X > base.ParentForm.Location.X + 3) & (Cursor.Position.X < base.ParentForm.Location.X + base.ParentForm.Width - 3)))
				{
					if (!((Cursor.Position.Y > base.ParentForm.Location.Y + base.ParentForm.Height - 3) & (Cursor.Position.X > base.ParentForm.Location.X + 3) & (Cursor.Position.X < base.ParentForm.Location.X + base.ParentForm.Width - 3)))
					{
						if (!((num >= base.ParentForm.Location.X + base.ParentForm.Width - 3) & (num2 <= base.ParentForm.Location.Y + 3)))
						{
							if (!((num <= base.ParentForm.Location.X + 3) & (num2 <= base.ParentForm.Location.Y + 3)))
							{
								if (!((num >= base.ParentForm.Location.X + base.ParentForm.Width - 3) & (num2 >= base.ParentForm.Location.Y + base.ParentForm.Height - 3)))
								{
									if (!((num <= base.ParentForm.Location.X + 3) & (num2 >= base.ParentForm.Location.Y + base.ParentForm.Height - 3)))
									{
										bool_1 = false;
										bool_2 = false;
										bool_3 = false;
										bool_4 = false;
										bool_5 = false;
										bool_6 = false;
										bool_7 = false;
										bool_8 = false;
										Cursor = Cursors.Default;
									}
									else if (!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized))
									{
										Cursor = Cursors.SizeNESW;
										bool_8 = true;
									}
								}
								else if (!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized))
								{
									Cursor = Cursors.SizeNWSE;
									bool_7 = true;
								}
							}
							else if (!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized))
							{
								Cursor = Cursors.SizeNWSE;
								bool_6 = true;
							}
						}
						else if (!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized))
						{
							Cursor = Cursors.SizeNESW;
							bool_5 = true;
						}
					}
					else if (!(!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized)))
					{
					}
				}
				else if (!(!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized)))
				{
				}
			}
			else if (!(!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized)))
			{
			}
		}
		else if (!(!bool_0 & (base.ParentForm.WindowState != FormWindowState.Maximized) & (base.ParentForm.WindowState != FormWindowState.Minimized)))
		{
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		Class76.smethod_583(this);
		Cursor = Cursors.Default;
		bool_0 = false;
		Invalidate();
		base.OnMouseMove(e);
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		point_0.X = e.X;
		point_0.Y = e.Y;
		Cursor = Cursors.Default;
		if (!((e.Y >= 0) & (e.Y <= Ground.TopHeight)))
		{
			bool_0 = false;
		}
		else
		{
			bool_0 = true;
		}
		if (e.Button == MouseButtons.Left)
		{
			if (!bool_1)
			{
				bool_9 = false;
			}
			else
			{
				bool_9 = true;
			}
			if (!bool_2)
			{
				bool_10 = false;
			}
			else
			{
				bool_10 = true;
			}
			if (!bool_3)
			{
				bool_11 = false;
			}
			else
			{
				bool_11 = true;
			}
			if (!bool_4)
			{
				bool_12 = false;
			}
			else
			{
				bool_12 = true;
			}
			if (!bool_5)
			{
				bool_13 = false;
			}
			else
			{
				bool_13 = true;
			}
			if (!bool_6)
			{
				bool_14 = false;
			}
			else
			{
				bool_14 = true;
			}
			if (!bool_7)
			{
				bool_15 = false;
			}
			else
			{
				bool_15 = true;
			}
			if (!bool_8)
			{
				bool_16 = false;
			}
			else
			{
				bool_16 = true;
			}
		}
		Invalidate();
		base.OnMouseMove(e);
	}

	protected override void OnResize(EventArgs e)
	{
		try
		{
			base.OnResize(e);
			Invalidate();
		}
		catch (Exception)
		{
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		try
		{
			string orjText = Text;
			RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RectangleF rect = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, Ground.TopHeight);
			RectangleF rect2 = new RectangleF(base.ClientRectangle.Left, base.Height - Ground.BottomHeight, base.ClientRectangle.Width, Ground.BottomHeight);
			rectDraw rectDraw2 = new rectDraw(new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, Ground.TopHeight), RoundRectangleType.RoundRectAll);
			Graphics Grph = e.Graphics;
			if (base.Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
				base.Geometry = new buControlGeometry(Vars.Geometry);
				base.Display = new buControlDisplay(Vars.Display);
				DisplayTop = new buControlDisplay(Vars.DisplayGroundTop);
				DisplayBottom = new buControlDisplay(Vars.DisplayGroundButtom);
				Ground = new buControlGround(Vars.Ground);
				base.Display.Parent = this;
				DisplayTop.Parent = this;
				DisplayBottom.Parent = this;
				Ground.Parent = this;
			}
			orjText = ControlGeometry.LanguageSelect(Language, orjText);
			if ((base.Width > 0) & (base.Height > 0))
			{
				if (base.Image != null)
				{
					rectDraw2.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw2.rectText, base.Geometry, base.ImageBorderOffset);
				}
				if (!base.Enabled)
				{
					ControlPaint.DrawStringDisabled(e.Graphics, Text, base.Display.Fonts.Font, base.Display.BackColor, rectDraw2.rect, ControlGeometry.AlignmentToStringFormat(base.Display.Fonts.Alignment));
				}
				else
				{
					ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
					ControlGeometry.drawGeometry(rect, base.Geometry, DisplayTop, RoundRectangleType.RoundRectUp, ref Grph);
					ControlGeometry.drawGeometry(rect2, base.Geometry, DisplayBottom, RoundRectangleType.RoundRectDown, ref Grph);
					ControlGeometry.drawString(rectDraw2.rectText, orjText, DisplayTop, ref Grph);
				}
				DrawImage(e.Graphics, base.Image, new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, Ground.TopHeight), base.ImageAlign);
				themeType_0 = base.Theme.Type;
			}
			base.OnPaint(e);
		}
		catch (Exception)
		{
		}
	}

	public static buGround CopyVisual(buGround refGround, buGround copyGround)
	{
		copyGround.Display = buControlDisplay.Copy(refGround.Display, copyGround.Display);
		copyGround.DisplayTop = buControlDisplay.Copy(refGround.DisplayTop, copyGround.DisplayTop);
		copyGround.DisplayBottom = buControlDisplay.Copy(refGround.DisplayBottom, copyGround.DisplayBottom);
		copyGround.Geometry.Space = refGround.Geometry.Space;
		copyGround.Geometry.ArcDiameter = refGround.Geometry.ArcDiameter;
		copyGround.Geometry.ShapeMode = refGround.Geometry.ShapeMode;
		copyGround.Ground.TopHeight = refGround.Ground.TopHeight;
		copyGround.Ground.BottomHeight = refGround.Ground.BottomHeight;
		copyGround.ImageAlign = refGround.ImageAlign;
		return copyGround;
	}
}
