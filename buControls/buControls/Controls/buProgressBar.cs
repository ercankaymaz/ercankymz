// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buProgressBar
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

public class buProgressBar : buCaptionBaseControl
{
  private ThemeType themeType_0 = ThemeType.Standart;
  private RectangleF rectangleF_0 = new RectangleF();
  private rectDraw rectDraw_0 = new rectDraw();
  private int int_3;
  private buControlProgressBarLineer buControlProgressBarLineer_0 = new buControlProgressBarLineer();
  private buControlProgressBarCircular buControlProgressBarCircular_0 = new buControlProgressBarCircular();
  private int int_4 = 0;
  private int int_5 = 0;
  private int int_6 = 100;
  private string string_1 = "";
  private ProgressBarType progressBarType_0 = ProgressBarType.Lineer;

  public buProgressBar()
  {
    try
    {
      Class39.smethod_492();
      this.TextAlign = ContentAlignment.MiddleCenter;
      this.ImageList = (ImageList) null;
      this.ImageAlign = ContentAlignment.MiddleCenter;
      this.Display.Parent = (Control) this;
      this.Geometry.Parent = (Control) this;
      this.Language.Parent = (Control) this;
      this.Caption.Parent = (Control) this;
      this.Caption.Display.Parent = (Control) this;
      this.Unit.Parent = (Control) this;
      this.Unit.Display.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      this.Aux.Parent = (Control) this;
      this.CheckTick.Parent = (Control) this;
      this.CheckTick.TickDisplay.Parent = (Control) this;
      this.CheckTick.ColorModeDisplay.Parent = (Control) this;
      this.FocusControl.Parent = (Control) this;
      this.CheckTick.Visible = false;
      this.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
      this.ProgressLineer.DoneDisplay.Parent = (Control) this;
      this.ProgressLineer.Parent = (Control) this;
      this.ProgressCircular.Parent = (Control) this;
      this.MaximumValue = 100;
      this.MinimumValue = 0;
      this.ProgressLineer.ShowPercentage = true;
      this.ProgressLineer.DoneDisplay.BackColor = Color.Green;
      this.ProgressLineer.DoneDisplay.LineerGradient.FirstColor = Color.Green;
      this.ProgressLineer.DoneDisplay.LineerGradient.SecondColor = Color.LightGreen;
      this.SetStyle(ControlStyles.Selectable, false);
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }
    catch (Exception ex)
    {
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlProgressBarCircular ProgressCircular
  {
    get => this.buControlProgressBarCircular_0;
    set
    {
      this.buControlProgressBarCircular_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlProgressBarLineer ProgressLineer
  {
    get => this.buControlProgressBarLineer_0;
    set
    {
      this.buControlProgressBarLineer_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int Value
  {
    get => this.int_4;
    set
    {
      if (value > this.MaximumValue)
        value = this.MaximumValue;
      if (value < this.MinimumValue)
        value = this.MinimumValue;
      this.int_4 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(100)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public ProgressBarType ProgressType
  {
    get => this.progressBarType_0;
    set
    {
      this.progressBarType_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DefaultValue(100)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MaximumValue
  {
    get => this.int_6;
    set
    {
      if (value < 1)
        value = 1;
      this.int_6 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MinimumValue
  {
    get => this.int_5;
    set
    {
      this.int_5 = value;
      if (value <= this.int_6)
        return;
      this.int_6 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue("")]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string UnitCaption
  {
    get => this.string_1;
    set
    {
      this.string_1 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  protected override void OnResize(EventArgs e) => base.OnResize(e);

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    this.Invalidate();
    base.OnMouseMove(e);
  }

  public void Increment(int value)
  {
    this.int_4 += value;
    this.Invalidate();
  }

  public void Deincrement(int value)
  {
    this.int_4 -= value;
    this.Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    try
    {
      string caption = this.Caption.Caption;
      RectangleF rectScale;
      ref RectangleF local1 = ref rectScale;
      Rectangle clientRectangle1 = this.ClientRectangle;
      double left1 = (double) clientRectangle1.Left;
      clientRectangle1 = this.ClientRectangle;
      double top1 = (double) clientRectangle1.Top;
      clientRectangle1 = this.ClientRectangle;
      double width1 = (double) clientRectangle1.Width;
      clientRectangle1 = this.ClientRectangle;
      double height1 = (double) clientRectangle1.Height;
      local1 = new RectangleF((float) left1, (float) top1, (float) width1, (float) height1);
      RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectAll;
      RectangleF rectangleF;
      ref RectangleF local2 = ref rectangleF;
      Rectangle clientRectangle2 = this.ClientRectangle;
      double left2 = (double) clientRectangle2.Left;
      clientRectangle2 = this.ClientRectangle;
      double top2 = (double) clientRectangle2.Top;
      clientRectangle2 = this.ClientRectangle;
      double width2 = (double) clientRectangle2.Width;
      clientRectangle2 = this.ClientRectangle;
      double height2 = (double) clientRectangle2.Height;
      local2 = new RectangleF((float) left2, (float) top2, (float) width2, (float) height2);
      double width3 = (double) this.Caption.Width;
      double height3 = (double) this.Height;
      double space = (double) this.Geometry.Space;
      Graphics graphics1 = e.Graphics;
      if (this.Theme.Type != this.themeType_0)
      {
        buControlThemeVars Vars = new buControlThemeVars();
        buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
        this.Geometry = new buControlGeometry(Vars.Geometry);
        this.Display = new buControlDisplay(Vars.Display);
        this.Caption.Display = new buControlDisplay(Vars.Caption.Display);
        this.ProgressLineer.DoneDisplay = new buControlDisplay(Vars.ProgressLineer.DoneDisplay);
        this.ProgressCircular = new buControlProgressBarCircular(Vars.ProgressCircular);
        this.Display.Parent = (Control) this;
        this.Geometry.Parent = (Control) this;
        this.Language.Parent = (Control) this;
        this.Caption.Parent = (Control) this;
        this.Caption.Display.Parent = (Control) this;
        this.Unit.Parent = (Control) this;
        this.Unit.Display.Parent = (Control) this;
        this.Theme.Parent = (Control) this;
        this.Aux.Parent = (Control) this;
        this.CheckTick.Parent = (Control) this;
        this.CheckTick.TickDisplay.Parent = (Control) this;
        this.CheckTick.ColorModeDisplay.Parent = (Control) this;
        this.FocusControl.Parent = (Control) this;
        this.CheckTick.Visible = false;
        this.CheckTick.TickDisplay.BackColor = Color.WhiteSmoke;
        this.ProgressLineer.DoneDisplay.Parent = (Control) this;
        this.ProgressLineer.Parent = (Control) this;
        this.ProgressCircular.Parent = (Control) this;
      }
      string Text = ControlGeometry.LanguageSelect(this.Language, caption);
      if (this.Width > 0 & this.Height > 0)
      {
        ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, ref this.rectDraw_0, ref this.rectangleF_0);
        if (!this.Enabled)
        {
          this.Display.GradientType = GradientMode.Solid;
          this.Display.BackColor = this.Display.DisableColor;
        }
        ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics1);
        if (this.Image != null)
          this.rectDraw_0.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, this.rectDraw_0.rectText, this.Geometry, this.ImageBorderOffset);
        if (this.Caption.Visible)
        {
          ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.Geometry, this.Caption.Display, this.rectDraw_0.RoundType, ref graphics1);
          ControlGeometry.drawString(this.rectDraw_0.rectText, Text, this.Caption.Display, ref graphics1);
        }
        if (this.ProgressType == ProgressBarType.Lineer)
        {
          if (!this.ProgressLineer.Vertical)
          {
            this.int_3 = (int) Math.Round((double) (this.Value - this.MinimumValue) / (double) (this.MaximumValue - this.MinimumValue) * ((double) this.Width - (double) this.rectangleF_0.Left - 3.0));
            RectangleF rect = new RectangleF((float) ((double) this.Geometry.Space + (double) this.rectangleF_0.Left + 1.0), 1f + this.Geometry.Space + this.rectangleF_0.Top, (float) (this.int_3 - 1), (float) ((double) this.Height - (double) this.rectangleF_0.Top - (double) this.Geometry.Space * 2.0 - 2.0));
            if (this.int_3 > 1)
            {
              if (this.ProgressLineer.ColorScaleFromBoxBounding)
                ControlGeometry.drawGeometry(rect, rectScale, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.ProgressLineer.DoneDisplay, RoundRectangleType, ref graphics1);
              else
                ControlGeometry.drawGeometry(rect, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.ProgressLineer.DoneDisplay, RoundRectangleType, ref graphics1);
            }
            if (this.ProgressLineer.ShowPercentage)
            {
              string str1 = "%";
              string str2 = "";
              if (this.UnitCaption.Length > 0)
              {
                str2 = " " + this.UnitCaption;
                str1 = "";
              }
              ControlGeometry.drawString(this.rectangleF_0, str1 + this.Value.ToString() + str2, this.ProgressLineer.DoneDisplay, ref graphics1);
            }
            if (this.ProgressLineer.DrawText.Length > 0)
              ControlGeometry.drawString(this.rectangleF_0, this.ProgressLineer.DrawText, this.ProgressLineer.DoneDisplay, ref graphics1);
          }
          else
          {
            this.int_3 = (int) Math.Round((double) (this.Value - this.MinimumValue) / (double) (this.MaximumValue - this.MinimumValue) * ((double) this.Height - (double) this.rectangleF_0.Top - 3.0));
            RectangleF rect = this.ProgressLineer.VerticalBottomToTop ? new RectangleF((float) ((double) this.Geometry.Space + (double) this.rectangleF_0.Left + 1.0), (float) (1.0 + (double) this.Geometry.Space + (double) this.rectangleF_0.Top + (double) (this.Height - this.int_3) - 2.0), (float) ((double) this.Width - (double) this.rectangleF_0.Left - (double) this.Geometry.Space * 2.0 - 2.0), (float) (this.int_3 - 1)) : new RectangleF((float) ((double) this.Geometry.Space + (double) this.rectangleF_0.Left + 1.0), 1f + this.Geometry.Space + this.rectangleF_0.Top, (float) ((double) this.Width - (double) this.rectangleF_0.Left - (double) this.Geometry.Space * 2.0 - 2.0), (float) (this.int_3 - 1));
            if (this.int_3 > 1)
            {
              if (this.ProgressLineer.ColorScaleFromBoxBounding)
                ControlGeometry.drawGeometry(rect, rectScale, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.ProgressLineer.DoneDisplay, RoundRectangleType, ref graphics1);
              else
                ControlGeometry.drawGeometry(rect, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.ProgressLineer.DoneDisplay, RoundRectangleType, ref graphics1);
            }
            if (this.ProgressLineer.ShowPercentage)
            {
              string str3 = "%";
              string str4 = "";
              if (this.UnitCaption.Length > 0)
              {
                str4 = " " + this.UnitCaption;
                str3 = "";
              }
              ControlGeometry.drawString(this.rectangleF_0, str3 + this.Value.ToString() + str4, this.ProgressLineer.DoneDisplay, ref graphics1);
            }
            if (this.ProgressLineer.DrawText.Length > 0)
              ControlGeometry.drawString(this.rectangleF_0, this.ProgressLineer.DrawText, this.ProgressLineer.DoneDisplay, ref graphics1);
          }
          this.DrawImage(e.Graphics, this.Image, new Rectangle((int) this.rectDraw_0.rect.X, (int) this.rectDraw_0.rect.Y, (int) this.rectDraw_0.rect.Width, (int) this.rectDraw_0.rect.Height), this.ImageAlign);
        }
        if (this.ProgressType == ProgressBarType.Circular)
        {
          using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
          {
            using (Graphics.FromImage((Image) bitmap))
            {
              using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle, this.ProgressCircular.ProgressColor1, this.ProgressCircular.ProgressColor2, LinearGradientMode.ForwardDiagonal))
              {
                using (Pen pen = new Pen((Brush) linearGradientBrush, this.ProgressCircular.Thickness))
                {
                  switch (this.ProgressCircular.ProgressShape)
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
                  graphics1.DrawArc(pen, (float) (Convert.ToInt32(this.ProgressCircular.Thickness / 1f) + this.ProgressCircular.BorderSpace), (float) (Convert.ToInt32(this.ProgressCircular.Thickness / 1f) + this.ProgressCircular.BorderSpace) + this.rectangleF_0.Top, (float) ((double) this.Width - (double) this.ProgressCircular.Thickness * 2.0 - (double) (this.ProgressCircular.BorderSpace * 2) - 1.0), (float) ((double) this.Height - (double) this.ProgressCircular.Thickness * 2.0 - (double) (this.ProgressCircular.BorderSpace * 2) - 1.0) - this.rectangleF_0.Top, -90f, (float) (int) Math.Round(360.0 / (double) this.MaximumValue * (double) this.Value));
                }
              }
              using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle, this.ProgressCircular.CoreColor1, this.ProgressCircular.CoreColor2, LinearGradientMode.Vertical))
              {
                graphics1.FillEllipse((Brush) linearGradientBrush, this.ProgressCircular.Thickness + (float) this.ProgressCircular.InnerBorderSpace, this.ProgressCircular.Thickness + (float) this.ProgressCircular.InnerBorderSpace + this.rectangleF_0.Top, (float) ((double) this.Width - (double) this.ProgressCircular.Thickness * 2.0 - 0.0 - (double) (this.ProgressCircular.InnerBorderSpace * 2) - 1.0), (float) ((double) this.Height - (double) this.ProgressCircular.Thickness * 2.0 - 0.0 - (double) (this.ProgressCircular.InnerBorderSpace * 2) - 1.0) - this.rectangleF_0.Top);
                graphics1.DrawEllipse(new Pen(this.ProgressCircular.CoreBorderColor), (float) ((double) this.ProgressCircular.Thickness + (double) this.ProgressCircular.InnerBorderSpace - 1.0), (float) ((double) this.ProgressCircular.Thickness + (double) this.ProgressCircular.InnerBorderSpace - 1.0) + this.rectangleF_0.Top, (float) ((double) this.Width - (double) this.ProgressCircular.Thickness * 2.0 - 0.0 - (double) (this.ProgressCircular.InnerBorderSpace * 2) - 1.0 + 2.0), (float) ((double) this.Height - (double) this.ProgressCircular.Thickness * 2.0 - 0.0 - (double) (this.ProgressCircular.InnerBorderSpace * 2) - 1.0 + 2.0) - this.rectangleF_0.Top);
              }
              if (this.ProgressCircular.ShowPercentage)
              {
                double num = 100.0 * (Convert.ToDouble(this.Value) / Convert.ToDouble(this.MaximumValue));
                string str5 = "% ";
                string str6 = "";
                if (this.UnitCaption.Length > 0)
                {
                  str6 = " " + this.UnitCaption;
                  str5 = "";
                }
                Graphics graphics2 = graphics1;
                string str7 = str5;
                int int32_1 = Convert.ToInt32(num);
                string str8 = Convert.ToString(int32_1.ToString() + str6);
                string text = str7 + str8;
                Font font1 = this.Font;
                SizeF sizeF = graphics2.MeasureString(text, font1);
                Graphics graphics3 = graphics1;
                string str9 = str5;
                int32_1 = Convert.ToInt32(num);
                string str10 = int32_1.ToString();
                string str11 = str6;
                string s = str9 + str10 + str11;
                Font font2 = this.Display.Fonts.Font;
                SolidBrush solidBrush = new SolidBrush(this.Display.Fonts.ForeColor);
                double int32_2 = (double) Convert.ToInt32((float) (this.Width / 2) - sizeF.Width / 2f);
                double int32_3 = (double) Convert.ToInt32((float) ((double) (this.Height / 2) - (double) sizeF.Height / 2.0 + (double) this.rectangleF_0.Top / 2.0));
                graphics3.DrawString(s, font2, (Brush) solidBrush, (float) int32_2, (float) int32_3);
              }
            }
          }
        }
      }
      this.themeType_0 = this.Theme.Type;
      base.OnPaint(e);
    }
    catch (Exception ex)
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
