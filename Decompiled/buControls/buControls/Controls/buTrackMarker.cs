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
public class buTrackMarker : buCaptionBaseControl
{
	public delegate void ValueChangedEventHandler(object sender, double Val);

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_0;

	private ThemeType themeType_0 = ThemeType.Standart;

	private RectangleF rectangleF_0 = default(RectangleF);

	private rectDraw rectDraw_0 = new rectDraw();

	private rectDraw rectDraw_1 = new rectDraw();

	private rectDraw rectDraw_2 = new rectDraw();

	private bool bool_0;

	private RectangleF rectangleF_1 = default(RectangleF);

	private buControlTrack buControlTrack_0 = new buControlTrack();

	private float float_0;

	private double double_0 = 0.0;

	private double double_1 = 100.0;

	private double double_2 = 0.0;

	private double double_3 = 10.0;

	private int int_3 = 40;

	private bool bool_1 = true;

	private string string_1 = "";

	private buControlDisplay buControlDisplay_1 = new buControlDisplay();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay CenterDisplay
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
		}
	}

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
	public double MinimumValue
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value >= double_1)
			{
				value = double_1;
			}
			if (double_2 < value)
			{
				double_2 = value;
			}
			double_0 = value;
			Invalidate();
		}
	}

	[DefaultValue(100)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double MaximumValue
	{
		get
		{
			return double_1;
		}
		set
		{
			if (value <= double_0)
			{
				value = double_0;
			}
			if (double_2 > value)
			{
				double_2 = value;
			}
			double_1 = value;
			Invalidate();
		}
	}

	[DefaultValue(0)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double Value
	{
		get
		{
			return double_2;
		}
		set
		{
			if (double_2 == value)
			{
				return;
			}
			if (!(value < double_0))
			{
				if (!(value > double_1))
				{
					double_2 = value;
				}
				else
				{
					double_2 = double_1;
				}
			}
			else
			{
				double_2 = double_0;
			}
			Invalidate();
			if (valueChangedEventHandler_0 != null)
			{
				valueChangedEventHandler_0(this, double_2);
			}
		}
	}

	[DefaultValue(10)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public double CenterHeight
	{
		get
		{
			return double_3;
		}
		set
		{
			if (value <= 0.0)
			{
				value = 2.0;
			}
			double_3 = value;
			Invalidate();
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
			return int_3;
		}
		set
		{
			int_3 = value;
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

	public buTrackMarker()
	{
		Class76.smethod_571();
		TextAlign = ContentAlignment.MiddleCenter;
		base.ImageAlign = ContentAlignment.MiddleLeft;
		CenterDisplay.Parent = this;
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
			Value = double_0 + (double)(int)Math.Round((double_1 - double_0) * ((double)((float)e.X - rectangleF_0.X) / (double)rectangleF_0.Width));
		}
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Left)
		{
			float_0 = (int)Math.Round((double_2 - double_0) / (double_1 - double_0) * (double)rectangleF_0.Width);
			rectangleF_1 = new RectangleF(float_0, 0f, 10f, 20f);
			if (bool_1 & ((float)e.X > rectangleF_0.X - 2f) & ((float)e.X <= rectangleF_0.Width + rectangleF_0.X + 4f))
			{
				bool_0 = true;
				Value = double_0 + (double)(int)Math.Round((double_1 - double_0) * ((double)((float)e.X - rectangleF_0.X) / (double)rectangleF_0.Width));
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
			float num = rectangleF_0.X + 0f;
			float num2 = rectangleF_0.Width + rectangleF_0.X - 0f;
			try
			{
				float num3 = Convert.ToSingle((double)(num2 - num) / (MaximumValue - MinimumValue));
				float_0 = Convert.ToSingle((double)rectangleF_0.X + (Value - MinimumValue) * (double)num3 - (double)((float)Track.DrawerWidth / 2f));
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
			rectDraw_2.rect.X = base.ClientRectangle.X;
			rectDraw_2.rect.Y = (float)base.ClientRectangle.Height / 2f - (float)CenterHeight / 2f;
			rectDraw_2.rect.Width = base.ClientRectangle.Width;
			rectDraw_2.rect.Height = (float)CenterHeight;
			ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
			ControlGeometry.drawGeometry(rectDraw_2.rect, base.Geometry, CenterDisplay, RoundRectangleType.RoundRectAll, ref Grph);
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
			int num4 = (int)Math.Round((Value - MinimumValue) / (MaximumValue - MinimumValue) * (double)(rectangleF_0.Width - 3f));
			RectangleF rectangleF = new RectangleF(base.Geometry.Space + rectangleF_0.Left + 1f, 2f + base.Geometry.Space + rectangleF_0.Top, num4 - 1, (float)base.Height - rectangleF_0.Top - base.Geometry.Space * 2f - 4f);
			if (num4 <= 1)
			{
			}
			if ((rectangleF_1.Width > 0f) & (rectangleF_1.Height > 0f))
			{
				ControlGeometry.drawGeometry(rectangleF_1, base.Geometry, Track.DrawerDisplay, RoundRectangleType.RoundRectAll, ref Grph);
			}
			if (!Track.ShowPersentage)
			{
			}
			DrawImage(e.Graphics, base.Image, new Rectangle((int)rectDraw_0.rect.X, (int)rectDraw_0.rect.Y, (int)rectDraw_0.rect.Width, (int)rectDraw_0.rect.Height), base.ImageAlign);
		}
		themeType_0 = base.Theme.Type;
		base.OnPaint(e);
	}
}
