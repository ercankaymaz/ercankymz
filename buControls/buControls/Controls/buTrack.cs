// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buTrack
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[DefaultProperty("Display")]
[DefaultEvent("ValueChanged")]
public class buTrack : buCaptionBaseControl
{
  private ThemeType themeType_0 = ThemeType.Standart;
  private RectangleF rectangleF_0 = new RectangleF();
  private rectDraw rectDraw_0 = new rectDraw();
  private rectDraw rectDraw_1 = new rectDraw();
  private bool bool_0;
  private RectangleF rectangleF_1 = new RectangleF();
  private buControlTrack buControlTrack_0 = new buControlTrack();
  private float float_0;
  private int int_3 = 0;
  private int int_4 = 100;
  private int int_5 = 0;
  private int int_6 = 40;
  private bool bool_1 = true;
  private string string_1 = "";

  public event buTrack.ValueChangedEventHandler ValueChanged;

  public buTrack()
  {
    Class39.smethod_179();
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.ImageAlign = ContentAlignment.MiddleLeft;
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
    this.Track.Parent = (Control) this;
    this.Track.DoneDisplay.Parent = (Control) this;
    this.Track.DrawerDisplay.Parent = (Control) this;
    this.Track.ValueDisplay.Parent = (Control) this;
    this.buControlTrack_0.DrawerDisplay.BackColor = Color.DimGray;
    this.buControlTrack_0.DoneDisplay.BackColor = Color.Green;
    this.SetStyle(ControlStyles.Selectable, false);
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlTrack Track
  {
    get => this.buControlTrack_0;
    set
    {
      this.buControlTrack_0 = value;
      if (this.Parent != null)
        this.Parent.Invalidate();
      this.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MinimumValue
  {
    get => this.int_3;
    set
    {
      if (value >= this.int_4)
        value = this.int_4;
      if (this.int_5 < value)
        this.int_5 = value;
      this.int_3 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(100)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int MaximumValue
  {
    get => this.int_4;
    set
    {
      if (value <= this.int_3)
        value = this.int_3;
      if (this.int_5 > value)
        this.int_5 = value;
      this.int_4 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int Value
  {
    get => this.int_5;
    set
    {
      if (this.int_5 == value)
        return;
      this.int_5 = value >= this.int_3 ? (value <= this.int_4 ? value : this.int_4) : this.int_3;
      this.Invalidate();
      if (this.valueChangedEventHandler_0 == null)
        return;
      this.valueChangedEventHandler_0((object) this, (double) this.int_5);
    }
  }

  [DefaultValue(true)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool MouseControlEnable
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      this.Invalidate();
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

  [DefaultValue(40)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int CaptionSeperatorValue
  {
    get => this.int_6;
    set
    {
      this.int_6 = value;
      this.Invalidate();
    }
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    base.OnMouseMove(e);
    if ((!this.bool_0 || (double) e.X <= (double) this.rectangleF_0.X - 2.0 ? 0 : ((double) e.X < (double) this.rectangleF_0.X + (double) this.rectangleF_0.Width + 4.0 ? 1 : 0)) == 0)
      return;
    this.Value = this.int_3 + (int) Math.Round((double) (this.int_4 - this.int_3) * (((double) e.X - (double) this.rectangleF_0.X) / (double) this.rectangleF_0.Width));
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    base.OnMouseDown(e);
    if (e.Button != MouseButtons.Left)
      return;
    this.float_0 = (float) (int) Math.Round((double) (this.int_5 - this.int_3) / (double) (this.int_4 - this.int_3) * (double) this.rectangleF_0.Width);
    this.rectangleF_1 = new RectangleF(this.float_0, 0.0f, 10f, 20f);
    if (!(this.bool_1 & (double) e.X > (double) this.rectangleF_0.X - 2.0 & (double) e.X <= (double) this.rectangleF_0.Width + (double) this.rectangleF_0.X + 4.0))
      return;
    this.bool_0 = true;
    this.Value = this.int_3 + (int) Math.Round((double) (this.int_4 - this.int_3) * (((double) e.X - (double) this.rectangleF_0.X) / (double) this.rectangleF_0.Width));
  }

  protected override void OnMouseUp(MouseEventArgs e)
  {
    base.OnMouseUp(e);
    this.bool_0 = false;
  }

  public void PropertiesValueChanged() => this.Invalidate();

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);
    if (this.Height >= 8)
      return;
    this.Height = 8;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    string caption = this.Caption.Caption;
    RoundRectangleType RoundRectangleType = RoundRectangleType.RoundRectAll;
    Graphics graphics = e.Graphics;
    if (this.Theme.Type != this.themeType_0)
    {
      buControlThemeVars Vars = new buControlThemeVars();
      buControlTheme.UpdateTheme(this.Theme.Type, ref Vars);
      this.Geometry = new buControlGeometry(Vars.Geometry);
      this.Display = new buControlDisplay(Vars.Display);
      this.Caption.Display = new buControlDisplay(Vars.Caption.Display);
      this.Track.DrawerDisplay = new buControlDisplay(Vars.DisplayDrawer);
      this.Track.DoneDisplay = new buControlDisplay(Vars.DisplayDoneValue);
      this.Track.ValueDisplay = new buControlDisplay(Vars.DisplayValue);
      this.Display.Parent = (Control) this;
      this.Geometry.Parent = (Control) this;
      this.Language.Parent = (Control) this;
      this.Caption.Parent = (Control) this;
      this.Caption.Display.Parent = (Control) this;
      this.CheckTick.Parent = (Control) this;
      this.CheckTick.TickDisplay.Parent = (Control) this;
      this.CheckTick.ColorModeDisplay.Parent = (Control) this;
      this.Unit.Parent = (Control) this;
      this.Unit.Display.Parent = (Control) this;
      this.Track.Parent = (Control) this;
      this.Track.DoneDisplay.Parent = (Control) this;
      this.Track.DrawerDisplay.Parent = (Control) this;
      this.Track.ValueDisplay.Parent = (Control) this;
      this.Theme.Parent = (Control) this;
      this.Aux.Parent = (Control) this;
      this.FocusControl.Parent = (Control) this;
    }
    string str1 = ControlGeometry.LanguageSelect(this.Language, caption);
    if (this.Width > 0 & this.Height > 0)
    {
      if (this.Track.ValueShow)
        ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, (float) this.Track.ValueWidth, ref this.rectDraw_0, ref this.rectDraw_1, ref this.rectangleF_0);
      else
        ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, ref this.rectDraw_0, ref this.rectangleF_0);
      if (this.Image != null)
        this.rectDraw_0.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, this.rectDraw_0.rectText, this.Geometry, this.ImageBorderOffset);
      float num1 = this.rectangleF_0.X + 2f;
      float num2 = (float) ((double) this.rectangleF_0.Width + (double) this.rectangleF_0.X - 2.0);
      try
      {
        this.float_0 = (float) ((double) this.rectangleF_0.X + (double) this.Value * (double) ((num2 - num1) / (float) (this.MaximumValue - this.MinimumValue)) - (double) this.Track.DrawerWidth / 2.0);
      }
      catch (Exception ex)
      {
      }
      this.rectangleF_1 = new RectangleF(this.float_0, this.rectangleF_0.Y, (float) this.Track.DrawerWidth, this.rectangleF_0.Height);
      if (!this.Enabled)
      {
        this.Display.GradientType = GradientMode.Solid;
        this.Display.BackColor = this.Display.DisableColor;
      }
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      if (this.Caption.Visible)
      {
        ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.Geometry, this.Caption.Display, this.rectDraw_0.RoundType, ref graphics);
        ControlGeometry.drawString(this.rectDraw_0.rectText, str1.ToString(), this.Caption.Display, ref graphics);
      }
      int num3;
      if (this.Track.ValueShow)
      {
        ControlGeometry.drawGeometry(this.rectDraw_1.rect, this.Geometry, this.Track.ValueDisplay, this.rectDraw_1.RoundType, ref graphics);
        RectangleF rect = this.rectDraw_1.rect;
        num3 = this.Value;
        string Text = num3.ToString();
        buControlDisplay valueDisplay = this.Track.ValueDisplay;
        ref Graphics local = ref graphics;
        ControlGeometry.drawString(rect, Text, valueDisplay, ref local);
      }
      int num4 = (int) Math.Round((double) (this.Value - this.MinimumValue) / (double) (this.MaximumValue - this.MinimumValue) * ((double) this.rectangleF_0.Width - 3.0));
      RectangleF rect1 = new RectangleF((float) ((double) this.Geometry.Space + (double) this.rectangleF_0.Left + 1.0), 2f + this.Geometry.Space + this.rectangleF_0.Top, (float) (num4 - 1), (float) ((double) this.Height - (double) this.rectangleF_0.Top - (double) this.Geometry.Space * 2.0 - 4.0));
      if (num4 > 1)
        ControlGeometry.drawGeometry(rect1, this.Geometry.ArcDiameter, this.Geometry.ShapeMode, this.Track.DoneDisplay, RoundRectangleType, ref graphics);
      if ((double) this.rectangleF_1.Width > 0.0 & (double) this.rectangleF_1.Height > 0.0)
      {
        if (this.Track.DrawerRectangle)
          ControlGeometry.drawGeometry(this.rectangleF_1, this.Geometry, this.Track.DrawerDisplay, RoundRectangleType.RoundRectNone, ref graphics);
        else
          ControlGeometry.drawGeometry(this.rectangleF_1, this.Geometry, this.Track.DrawerDisplay, RoundRectangleType.RoundRectAll, ref graphics);
      }
      if (this.Track.ShowPersentage)
      {
        string str2 = this.Track.PersentageChar;
        string str3 = "";
        if (this.UnitCaption.Length > 0)
        {
          str3 = " " + this.UnitCaption;
          str2 = "";
        }
        if (this.Value < this.CaptionSeperatorValue)
        {
          RectangleF rectangleF0 = this.rectangleF_0;
          string str4 = str2;
          num3 = this.Value;
          string str5 = num3.ToString();
          string str6 = str3;
          string Text = str4 + str5 + str6;
          buControlDisplay doneDisplay = this.Track.DoneDisplay;
          ref Graphics local = ref graphics;
          ControlGeometry.drawString(rectangleF0, Text, doneDisplay, ref local);
        }
        else
        {
          RectangleF rect2 = rect1;
          string str7 = str2;
          num3 = this.Value;
          string str8 = num3.ToString();
          string str9 = str3;
          string Text = str7 + str8 + str9;
          buControlDisplay doneDisplay = this.Track.DoneDisplay;
          ref Graphics local = ref graphics;
          ControlGeometry.drawString(rect2, Text, doneDisplay, ref local);
        }
      }
      this.DrawImage(e.Graphics, this.Image, new Rectangle((int) this.rectDraw_0.rect.X, (int) this.rectDraw_0.rect.Y, (int) this.rectDraw_0.rect.Width, (int) this.rectDraw_0.rect.Height), this.ImageAlign);
    }
    this.themeType_0 = this.Theme.Type;
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

  public delegate void ValueChangedEventHandler(object sender, double Val);
}
