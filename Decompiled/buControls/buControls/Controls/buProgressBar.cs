using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

public class buProgressBar : buCaptionBaseControl
{
	private ThemeType themeType_0 = ThemeType.Standart;

	private RectangleF rectangleF_0 = default(RectangleF);

	private rectDraw rectDraw_0 = new rectDraw();

	private int int_3;

	private buControlProgressBarLineer buControlProgressBarLineer_0 = new buControlProgressBarLineer();

	private buControlProgressBarCircular buControlProgressBarCircular_0 = new buControlProgressBarCircular();

	private int int_4 = 0;

	private int int_5 = 0;

	private int int_6 = 100;

	private string string_1 = "";

	private ProgressBarType progressBarType_0 = ProgressBarType.Lineer;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlProgressBarCircular ProgressCircular
	{
		get
		{
			return buControlProgressBarCircular_0;
		}
		set
		{
			buControlProgressBarCircular_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlProgressBarLineer ProgressLineer
	{
		get
		{
			return buControlProgressBarLineer_0;
		}
		set
		{
			buControlProgressBarLineer_0 = value;
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
	public int Value
	{
		get
		{
			return int_4;
		}
		set
		{
			if (value > MaximumValue)
			{
				value = MaximumValue;
			}
			if (value < MinimumValue)
			{
				value = MinimumValue;
			}
			int_4 = value;
			Invalidate();
		}
	}

	[DefaultValue(100)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public ProgressBarType ProgressType
	{
		get
		{
			return progressBarType_0;
		}
		set
		{
			progressBarType_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
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
			return int_6;
		}
		set
		{
			if (value < 1)
			{
				value = 1;
			}
			int_6 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
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
			return int_5;
		}
		set
		{
			int_5 = value;
			if (value > int_6)
			{
				int_6 = value;
				if (base.Parent != null)
				{
					base.Parent.Invalidate();
				}
			}
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

	public buProgressBar()
	{
		try
		{
			Class76.smethod_492();
			TextAlign = ContentAlignment.MiddleCenter;
			base.ImageList = null;
			base.ImageAlign = ContentAlignment.MiddleCenter;
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
			ProgressLineer.DoneDisplay.Parent = this;
			ProgressLineer.Parent = this;
			ProgressCircular.Parent = this;
			MaximumValue = 100;
			MinimumValue = 0;
			ProgressLineer.ShowPercentage = true;
			ProgressLineer.DoneDisplay.BackColor = Color.Green;
			ProgressLineer.DoneDisplay.LineerGradient.FirstColor = Color.Green;
			ProgressLineer.DoneDisplay.LineerGradient.SecondColor = Color.LightGreen;
			SetStyle(ControlStyles.Selectable, value: false);
			SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		}
		catch (Exception)
		{
		}
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		Cursor = Cursors.Default;
		Invalidate();
		base.OnMouseMove(e);
	}

	public void Increment(int value)
	{
		int_4 += value;
		Invalidate();
	}

	public void Deincrement(int value)
	{
		int_4 -= value;
		Invalidate();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		try
		{
			string caption = base.Caption.Caption;
			RectangleF rectScale = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			RoundRectangleType roundRectangleType = RoundRectangleType.RoundRectAll;
			RectangleF rectangleF = new RectangleF(base.ClientRectangle.Left, base.ClientRectangle.Top, base.ClientRectangle.Width, base.ClientRectangle.Height);
			_ = (float)base.Caption.Width;
			_ = (float)base.Height;
			_ = base.Geometry.Space;
			Graphics Grph = e.Graphics;
			if (base.Theme.Type != themeType_0)
			{
				buControlThemeVars Vars = new buControlThemeVars();
				buControlTheme.UpdateTheme(base.Theme.Type, ref Vars);
				base.Geometry = new buControlGeometry(Vars.Geometry);
				base.Display = new buControlDisplay(Vars.Display);
				base.Caption.Display = new buControlDisplay(Vars.Caption.Display);
				ProgressLineer.DoneDisplay = new buControlDisplay(Vars.ProgressLineer.DoneDisplay);
				ProgressCircular = new buControlProgressBarCircular(Vars.ProgressCircular);
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
				ProgressLineer.DoneDisplay.Parent = this;
				ProgressLineer.Parent = this;
				ProgressCircular.Parent = this;
			}
			caption = ControlGeometry.LanguageSelect(base.Language, caption);
			if ((base.Width > 0) & (base.Height > 0))
			{
				ControlGeometry.CalcMainArea(base.Width, base.Height, base.Geometry, base.Caption, ref rectDraw_0, ref rectangleF_0);
				if (!base.Enabled)
				{
					base.Display.GradientType = GradientMode.Solid;
					base.Display.BackColor = base.Display.DisableColor;
				}
				ControlGeometry.drawGeometry(base.ClientRectangle, base.Geometry, base.Display, RoundRectangleType.RoundRectAll, ref Grph);
				if (base.Image != null)
				{
					rectDraw_0.rectText = ControlGeometry.GetTextRectangleFromImage(base.Image, base.ImageAlign, rectDraw_0.rectText, base.Geometry, base.ImageBorderOffset);
				}
				if (base.Caption.Visible)
				{
					ControlGeometry.drawGeometry(rectDraw_0.rect, base.Geometry, base.Caption.Display, rectDraw_0.RoundType, ref Grph);
					ControlGeometry.drawString(rectDraw_0.rectText, caption, base.Caption.Display, ref Grph);
				}
				if (ProgressType == ProgressBarType.Lineer)
				{
					if (ProgressLineer.Vertical)
					{
						int_3 = (int)Math.Round((double)(Value - MinimumValue) / (double)(MaximumValue - MinimumValue) * (double)((float)base.Height - rectangleF_0.Top - 3f));
						RectangleF rect = ((!ProgressLineer.VerticalBottomToTop) ? new RectangleF(base.Geometry.Space + rectangleF_0.Left + 1f, 1f + base.Geometry.Space + rectangleF_0.Top, (float)base.Width - rectangleF_0.Left - base.Geometry.Space * 2f - 2f, int_3 - 1) : new RectangleF(base.Geometry.Space + rectangleF_0.Left + 1f, 1f + base.Geometry.Space + rectangleF_0.Top + (float)(base.Height - int_3) - 2f, (float)base.Width - rectangleF_0.Left - base.Geometry.Space * 2f - 2f, int_3 - 1));
						if (int_3 > 1)
						{
							if (!ProgressLineer.ColorScaleFromBoxBounding)
							{
								ControlGeometry.drawGeometry(rect, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, ProgressLineer.DoneDisplay, roundRectangleType, ref Grph);
							}
							else
							{
								ControlGeometry.drawGeometry(rect, rectScale, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, ProgressLineer.DoneDisplay, roundRectangleType, ref Grph);
							}
						}
						if (ProgressLineer.ShowPercentage)
						{
							string text = "%";
							string text2 = "";
							if (UnitCaption.Length > 0)
							{
								text2 = " " + UnitCaption;
								text = "";
							}
							ControlGeometry.drawString(rectangleF_0, text + Value + text2, ProgressLineer.DoneDisplay, ref Grph);
						}
						if (ProgressLineer.DrawText.Length > 0)
						{
							ControlGeometry.drawString(rectangleF_0, ProgressLineer.DrawText, ProgressLineer.DoneDisplay, ref Grph);
						}
					}
					else
					{
						int_3 = (int)Math.Round((double)(Value - MinimumValue) / (double)(MaximumValue - MinimumValue) * (double)((float)base.Width - rectangleF_0.Left - 3f));
						RectangleF rect2 = new RectangleF(base.Geometry.Space + rectangleF_0.Left + 1f, 1f + base.Geometry.Space + rectangleF_0.Top, int_3 - 1, (float)base.Height - rectangleF_0.Top - base.Geometry.Space * 2f - 2f);
						if (int_3 > 1)
						{
							if (!ProgressLineer.ColorScaleFromBoxBounding)
							{
								ControlGeometry.drawGeometry(rect2, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, ProgressLineer.DoneDisplay, roundRectangleType, ref Grph);
							}
							else
							{
								ControlGeometry.drawGeometry(rect2, rectScale, base.Geometry.ArcDiameter, base.Geometry.ShapeMode, ProgressLineer.DoneDisplay, roundRectangleType, ref Grph);
							}
						}
						if (ProgressLineer.ShowPercentage)
						{
							string text3 = "%";
							string text4 = "";
							if (UnitCaption.Length > 0)
							{
								text4 = " " + UnitCaption;
								text3 = "";
							}
							ControlGeometry.drawString(rectangleF_0, text3 + Value + text4, ProgressLineer.DoneDisplay, ref Grph);
						}
						if (ProgressLineer.DrawText.Length > 0)
						{
							ControlGeometry.drawString(rectangleF_0, ProgressLineer.DrawText, ProgressLineer.DoneDisplay, ref Grph);
						}
					}
					DrawImage(e.Graphics, base.Image, new Rectangle((int)rectDraw_0.rect.X, (int)rectDraw_0.rect.Y, (int)rectDraw_0.rect.Width, (int)rectDraw_0.rect.Height), base.ImageAlign);
				}
				if (ProgressType == ProgressBarType.Circular)
				{
					using Bitmap image = new Bitmap(base.Width, base.Height);
					using (Graphics.FromImage(image))
					{
						using (LinearGradientBrush brush = new LinearGradientBrush(base.ClientRectangle, ProgressCircular.ProgressColor1, ProgressCircular.ProgressColor2, LinearGradientMode.ForwardDiagonal))
						{
							using Pen pen = new Pen(brush, ProgressCircular.Thickness);
							switch (ProgressCircular.ProgressShape)
							{
							case CircularProgressShape.Round:
								pen.StartCap = LineCap.Round;
								pen.EndCap = LineCap.Round;
								break;
							case CircularProgressShape.Flat:
								pen.StartCap = LineCap.Flat;
								pen.EndCap = LineCap.Flat;
								break;
							}
							Grph.DrawArc(pen, Convert.ToInt32(ProgressCircular.Thickness / 1f) + ProgressCircular.BorderSpace, (float)(Convert.ToInt32(ProgressCircular.Thickness / 1f) + ProgressCircular.BorderSpace) + rectangleF_0.Top, (float)base.Width - ProgressCircular.Thickness * 2f - (float)(ProgressCircular.BorderSpace * 2) - 1f, (float)base.Height - ProgressCircular.Thickness * 2f - (float)(ProgressCircular.BorderSpace * 2) - 1f - rectangleF_0.Top, -90f, (int)Math.Round(360.0 / (double)MaximumValue * (double)Value));
						}
						using (LinearGradientBrush brush2 = new LinearGradientBrush(base.ClientRectangle, ProgressCircular.CoreColor1, ProgressCircular.CoreColor2, LinearGradientMode.Vertical))
						{
							Grph.FillEllipse(brush2, ProgressCircular.Thickness + (float)ProgressCircular.InnerBorderSpace, ProgressCircular.Thickness + (float)ProgressCircular.InnerBorderSpace + rectangleF_0.Top, (float)base.Width - ProgressCircular.Thickness * 2f - 0f - (float)(ProgressCircular.InnerBorderSpace * 2) - 1f, (float)base.Height - ProgressCircular.Thickness * 2f - 0f - (float)(ProgressCircular.InnerBorderSpace * 2) - 1f - rectangleF_0.Top);
							Grph.DrawEllipse(new Pen(ProgressCircular.CoreBorderColor), ProgressCircular.Thickness + (float)ProgressCircular.InnerBorderSpace - 1f, ProgressCircular.Thickness + (float)ProgressCircular.InnerBorderSpace - 1f + rectangleF_0.Top, (float)base.Width - ProgressCircular.Thickness * 2f - 0f - (float)(ProgressCircular.InnerBorderSpace * 2) - 1f + 2f, (float)base.Height - ProgressCircular.Thickness * 2f - 0f - (float)(ProgressCircular.InnerBorderSpace * 2) - 1f + 2f - rectangleF_0.Top);
						}
						if (ProgressCircular.ShowPercentage)
						{
							double value = 100.0 * (Convert.ToDouble(Value) / Convert.ToDouble(MaximumValue));
							string text5 = "% ";
							string text6 = "";
							if (UnitCaption.Length > 0)
							{
								text6 = " " + UnitCaption;
								text5 = "";
							}
							SizeF sizeF = Grph.MeasureString(text5 + Convert.ToString(Convert.ToInt32(value) + text6), Font);
							Grph.DrawString(text5 + Convert.ToInt32(value) + text6, base.Display.Fonts.Font, new SolidBrush(base.Display.Fonts.ForeColor), Convert.ToInt32((float)(base.Width / 2) - sizeF.Width / 2f), Convert.ToInt32((float)(base.Height / 2) - sizeF.Height / 2f + rectangleF_0.Top / 2f));
						}
					}
				}
			}
			themeType_0 = base.Theme.Type;
			base.OnPaint(e);
		}
		catch (Exception)
		{
		}
	}

	public static buProgressBar CopyVisual(buProgressBar refProgress, buProgressBar copyProgress)
	{
		copyProgress.Display = buControlDisplay.Copy(refProgress.Display, copyProgress.Display);
		copyProgress.ProgressLineer.DoneDisplay = buControlDisplay.Copy(refProgress.ProgressLineer.DoneDisplay, copyProgress.ProgressLineer.DoneDisplay);
		copyProgress.Geometry.Space = refProgress.Geometry.Space;
		copyProgress.Geometry.ArcDiameter = refProgress.Geometry.ArcDiameter;
		copyProgress.Geometry.ShapeMode = refProgress.Geometry.ShapeMode;
		copyProgress.ProgressLineer.ShowPercentage = refProgress.ProgressLineer.ShowPercentage;
		copyProgress.ImageAlign = refProgress.ImageAlign;
		return copyProgress;
	}
}
