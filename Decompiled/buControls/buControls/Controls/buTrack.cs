using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

[DefaultProperty("Display")]
[DefaultEvent("ValueChanged")]
public class buTrack : buCaptionBaseControl
{
	public delegate void ValueChangedEventHandler(object sender, double Val);

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_0;

	private ThemeType themeType_0 = ThemeType.Standart;

	private RectangleF rectangleF_0 = default(RectangleF);

	private rectDraw rectDraw_0 = new rectDraw();

	private rectDraw rectDraw_1 = new rectDraw();

	private bool bool_0;

	private RectangleF rectangleF_1 = default(RectangleF);

	private buControlTrack buControlTrack_0 = new buControlTrack();

	private float float_0;

	private int int_3 = 0;

	private int int_4 = 100;

	private int int_5 = 0;

	private int int_6 = 40;

	private bool bool_1 = true;

	private string string_1 = "";

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlTrack Track
	{
		get
		{
			return buControlTrack_0;
		}
		set
		{
			buControlTrack_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DefaultValue(0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int MinimumValue
	{
		get
		{
			return int_3;
		}
		set
		{
			if (value >= int_4)
			{
				value = int_4;
			}
			if (int_5 < value)
			{
				int_5 = value;
			}
			int_3 = value;
			Invalidate();
		}
	}

	[DefaultValue(100)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int MaximumValue
	{
		get
		{
			return int_4;
		}
		set
		{
			if (value <= int_3)
			{
				value = int_3;
			}
			if (int_5 > value)
			{
				int_5 = value;
			}
			int_4 = value;
			Invalidate();
		}
	}

	[DefaultValue(0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int Value
	{
		get
		{
			return int_5;
		}
		set
		{
			if (int_5 == value)
			{
				return;
			}
			if (value >= int_3)
			{
				if (value <= int_4)
				{
					int_5 = value;
				}
				else
				{
					int_5 = int_4;
				}
			}
			else
			{
				int_5 = int_3;
			}
			Invalidate();
			if (valueChangedEventHandler_0 != null)
			{
				valueChangedEventHandler_0(this, int_5);
			}
		}
	}

	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool MouseControlEnable
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			Invalidate();
		}
	}

	[DefaultValue("")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string UnitCaption
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
			Invalidate();
		}
	}

	[DefaultValue(40)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int CaptionSeperatorValue
	{
		get
		{
			return int_6;
		}
		set
		{
			int_6 = value;
			Invalidate();
		}
	}

	public event ValueChangedEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while ((object)valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	public buTrack()
	{
		Class76.smethod_179();
		TextAlign = ContentAlignment.MiddleCenter;
		base.ImageAlign = ContentAlignment.MiddleLeft;
		base.Display.Parent = this;
		base.Geometry.Parent = this;
		base.Language.Parent = this;
		base.Caption.Parent = this;
		base.Caption.Display.Parent = this;
		base.Unit.Parent = this;
		base.Unit.Display.Parent = this;
		base.Theme.Parent = this;
		base.Aux.Parent = this;
		base.CheckTick.Parent = this;
		base.CheckTick.TickDisplay.Parent = this;
		base.CheckTick.ColorModeDisplay.Parent = this;
		base.FocusControl.Parent = this;
		base.CheckTick.Visible = false;
		base.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
		Track.Parent = this;
		Track.DoneDisplay.Parent = this;
		Track.DrawerDisplay.Parent = this;
		Track.ValueDisplay.Parent = this;
		buControlTrack_0.DrawerDisplay.BackColor = Color.DimGray;
		buControlTrack_0.DoneDisplay.BackColor = Color.Green;
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Cursor = Cursors.Default;
		base.OnMouseMove(e);
		if (bool_0 && (float)e.X > rectangleF_0.X - 2f && (float)e.X < rectangleF_0.X + rectangleF_0.Width + 4f)
		{
			Value = int_3 + (int)Math.Round((double)(int_4 - int_3) * ((double)((float)e.X - rectangleF_0.X) / (double)rectangleF_0.Width));
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Left)
		{
			float_0 = (int)Math.Round((double)(int_5 - int_3) / (double)(int_4 - int_3) * (double)rectangleF_0.Width);
			rectangleF_1 = new RectangleF(float_0, 0f, 10f, 20f);
			if (bool_1 & ((float)e.X > rectangleF_0.X - 2f) & ((float)e.X <= rectangleF_0.Width + rectangleF_0.X + 4f))
			{
				bool_0 = true;
				Value = int_3 + (int)Math.Round((double)(int_4 - int_3) * ((double)((float)e.X - rectangleF_0.X) / (double)rectangleF_0.Width));
			}
		}
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		bool_0 = false;
	}

	public void PropertiesValueChanged()
	{
		Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		if (base.Height < 8)
		{
			base.Height = 8;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		string caption = base.Caption.Caption;
		RoundRectangleType roundRectangleType = RoundRectangleType.RoundRectAll;
		Graphics Grph = e.Graphics;
		if (base.Theme.Type != themeType_0)
		{
			buControlThemeVars Vars = new buControlThemeVars();
			buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
			base.Geometry = new buControlGeometry(Vars.Geometry);
			base.Display = new buControlDisplay(Vars.Display);
			base.Caption.Display = new buControlDisplay(Vars.Caption.Display);
			Track.DrawerDisplay = new buControlDisplay(Vars.DisplayDrawer);
			Track.DoneDisplay = new buControlDisplay(Vars.DisplayDoneValue);
			Track.ValueDisplay = new buControlDisplay(Vars.DisplayValue);
			base.Display.Parent = this;
			base.Geometry.Parent = this;
			base.Language.Parent = this;
			base.Caption.Parent = this;
			base.Caption.Display.Parent = this;
			base.CheckTick.Parent = this;
			base.CheckTick.TickDisplay.Parent = this;
			base.CheckTick.ColorModeDisplay.Parent = this;
			base.Unit.Parent = this;
			base.Unit.Display.Parent = this;
			Track.Parent = this;
			Track.DoneDisplay.Parent = this;
			Track.DrawerDisplay.Parent = this;
			Track.ValueDisplay.Parent = this;
			base.Theme.Parent = this;
			base.Aux.Parent = this;
			base.FocusControl.Parent = this;
		}
		caption = ControlGeometry.LanguageSelect(base.Language, caption);
		if ((base.Width > 0) & (base.Height > 0))
		{
			if (!Track.ValueShow)
			{
				ControlGeometry.CalcMainArea(base.Width, base.Height, base.Geometry, base.Caption, ref rectDraw_0, ref rectangleF_0);
			}
			else
			{
				ControlGeometry.CalcMainArea(base.Width, base.Height, base.Geometry, base.Caption, Track.ValueWidth, ref rectDraw_0, ref rectDraw_1, ref rectangleF_0);
			}
			if (base.Image != null)
			{
				rectDraw_0.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw_0.rectText, base.Geometry, base.ImageBorderOffset);
			}
			float num = rectangleF_0.X + 2f;
			float num2 = rectangleF_0.Width + rectangleF_0.X - 2f;
			try
			{
				float num3 = (num2 - num) / (float)(MaximumValue - MinimumValue);
				float_0 = rectangleF_0.X + (float)Value * num3 - (float)Track.DrawerWidth / 2f;
			}
			catch (Exception)
			{
			}
			rectangleF_1 = new RectangleF(float_0, rectangleF_0.Y, Track.DrawerWidth, rectangleF_0.Height);
			if (!base.Enabled)
			{
				base.Display.GradientType = GradientMode.Solid;
				base.Display.BackColor = base.Display.DisableColor;
			}
			ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
			if (base.Caption.Visible)
			{
				ControlGeometry.drawGeometry(rectDraw_0.rect, base.Geometry, base.Caption.Display, rectDraw_0.RoundType, ref Grph);
				ControlGeometry.drawString(rectDraw_0.rectText, caption.ToString(), base.Caption.Display, ref Grph);
			}
			if (Track.ValueShow)
			{
				ControlGeometry.drawGeometry(rectDraw_1.rect, base.Geometry, Track.ValueDisplay, rectDraw_1.RoundType, ref Grph);
				ControlGeometry.drawString(rectDraw_1.rect, Value.ToString(), Track.ValueDisplay, ref Grph);
			}
			int num4 = (int)Math.Round((double)(Value - MinimumValue) / (double)(MaximumValue - MinimumValue) * (double)(rectangleF_0.Width - 3f));
			RectangleF rect = new RectangleF(base.Geometry.Space + rectangleF_0.Left + 1f, 2f + base.Geometry.Space + rectangleF_0.Top, num4 - 1, (float)base.Height - rectangleF_0.Top - base.Geometry.Space * 2f - 4f);
			if (num4 > 1)
			{
				ControlGeometry.drawGeometry(rect, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, Track.DoneDisplay, roundRectangleType, ref Grph);
			}
			if ((rectangleF_1.Width > 0f) & (rectangleF_1.Height > 0f))
			{
				if (!Track.DrawerRectangle)
				{
					ControlGeometry.drawGeometry(rectangleF_1, base.Geometry, Track.DrawerDisplay, RoundRectangleType.RoundRectAll, ref Grph);
				}
				else
				{
					ControlGeometry.drawGeometry(rectangleF_1, base.Geometry, Track.DrawerDisplay, RoundRectangleType.RoundRectNone, ref Grph);
				}
			}
			if (Track.ShowPersentage)
			{
				string text = Track.PersentageChar;
				string text2 = "";
				if (UnitCaption.Length > 0)
				{
					text2 = " " + UnitCaption;
					text = "";
				}
				if (Value >= CaptionSeperatorValue)
				{
					ControlGeometry.drawString(rect, text + Value + text2, Track.DoneDisplay, ref Grph);
				}
				else
				{
					ControlGeometry.drawString(rectangleF_0, text + Value + text2, Track.DoneDisplay, ref Grph);
				}
			}
			DrawImage(e.Graphics, base.Image, new Rectangle((int)rectDraw_0.rect.X, (int)rectDraw_0.rect.Y, (int)rectDraw_0.rect.Width, (int)rectDraw_0.rect.Height), base.ImageAlign);
		}
		themeType_0 = base.Theme.Type;
		base.OnPaint(e);
	}

	public static buTrack CopyVisual(buTrack refTrack, buTrack copyTrack)
	{
		copyTrack.Display = buControlDisplay.Copy(refTrack.Display, copyTrack.Display);
		copyTrack.Caption.Display = buControlDisplay.Copy(refTrack.Caption.Display, copyTrack.Caption.Display);
		copyTrack.Track.DoneDisplay = buControlDisplay.Copy(refTrack.Track.DoneDisplay, copyTrack.Track.DoneDisplay);
		copyTrack.Track.DrawerDisplay = buControlDisplay.Copy(refTrack.Track.DrawerDisplay, copyTrack.Track.DrawerDisplay);
		copyTrack.Geometry.Space = refTrack.Geometry.Space;
		copyTrack.Geometry.ArcDiameter = refTrack.Geometry.ArcDiameter;
		copyTrack.Geometry.ShapeMode = refTrack.Geometry.ShapeMode;
		copyTrack.Track.ShowPersentage = refTrack.Track.ShowPersentage;
		copyTrack.Track.DrawerWidth = refTrack.Track.DrawerWidth;
		copyTrack.ImageAlign = refTrack.ImageAlign;
		return copyTrack;
	}
}
