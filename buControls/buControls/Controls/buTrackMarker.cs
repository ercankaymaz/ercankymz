// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buTrackMarker
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
public class buTrackMarker : buCaptionBaseControl
{
  private ThemeType themeType_0 = ThemeType.Standart;
  private RectangleF rectangleF_0 = new RectangleF();
  private rectDraw rectDraw_0 = new rectDraw();
  private rectDraw rectDraw_1 = new rectDraw();
  private rectDraw rectDraw_2 = new rectDraw();
  private bool bool_0;
  private RectangleF rectangleF_1 = new RectangleF();
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

  public event buTrackMarker.ValueChangedEventHandler ValueChanged;

  public buTrackMarker()
  {
    Class39.smethod_571();
    this.TextAlign = ContentAlignment.MiddleCenter;
    this.ImageAlign = ContentAlignment.MiddleLeft;
    this.CenterDisplay.Parent = (Control) this;
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
  public buControlDisplay CenterDisplay
  {
    get => this.buControlDisplay_1;
    set
    {
      this.buControlDisplay_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
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
  public double MinimumValue
  {
    get => this.double_0;
    set
    {
      if (value >= this.double_1)
        value = this.double_1;
      if (this.double_2 < value)
        this.double_2 = value;
      this.double_0 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(100)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double MaximumValue
  {
    get => this.double_1;
    set
    {
      if (value <= this.double_0)
        value = this.double_0;
      if (this.double_2 > value)
        this.double_2 = value;
      this.double_1 = value;
      this.Invalidate();
    }
  }

  [DefaultValue(0)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double Value
  {
    get => this.double_2;
    set
    {
      if (this.double_2 == value)
        return;
      this.double_2 = value >= this.double_0 ? (value <= this.double_1 ? value : this.double_1) : this.double_0;
      this.Invalidate();
      if (this.valueChangedEventHandler_0 == null)
        return;
      this.valueChangedEventHandler_0((object) this, this.double_2);
    }
  }

  [DefaultValue(10)]
  [EditorBrowsable(EditorBrowsableState.Always)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double CenterHeight
  {
    get => this.double_3;
    set
    {
      if (value <= 0.0)
        value = 2.0;
      this.double_3 = value;
      this.Invalidate();
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
    get => this.int_3;
    set
    {
      this.int_3 = value;
      this.Invalidate();
    }
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.Cursor = Cursors.Default;
    base.OnMouseMove(e);
    if ((!this.bool_0 || (double) e.X <= (double) this.rectangleF_0.X - 2.0 ? 0 : ((double) e.X < (double) this.rectangleF_0.X + (double) this.rectangleF_0.Width + 4.0 ? 1 : 0)) == 0)
      return;
    this.Value = this.double_0 + (double) (int) Math.Round((this.double_1 - this.double_0) * (((double) e.X - (double) this.rectangleF_0.X) / (double) this.rectangleF_0.Width));
  }

  protected override void OnMouseDown(MouseEventArgs e)
  {
    base.OnMouseDown(e);
    if (e.Button != MouseButtons.Left)
      return;
    this.float_0 = (float) (int) Math.Round((this.double_2 - this.double_0) / (this.double_1 - this.double_0) * (double) this.rectangleF_0.Width);
    this.rectangleF_1 = new RectangleF(this.float_0, 0.0f, 10f, 20f);
    if (!(this.bool_1 & (double) e.X > (double) this.rectangleF_0.X - 2.0 & (double) e.X <= (double) this.rectangleF_0.Width + (double) this.rectangleF_0.X + 4.0))
      return;
    this.bool_0 = true;
    this.Value = this.double_0 + (double) (int) Math.Round((this.double_1 - this.double_0) * (((double) e.X - (double) this.rectangleF_0.X) / (double) this.rectangleF_0.Width));
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
    string str = ControlGeometry.LanguageSelect(this.Language, caption);
    if (this.Width > 0 & this.Height > 0)
    {
      if (this.Track.ValueShow)
        ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, (float) this.Track.ValueWidth, ref this.rectDraw_0, ref this.rectDraw_1, ref this.rectangleF_0);
      else
        ControlGeometry.CalcMainArea((float) this.Width, (float) this.Height, this.Geometry, this.Caption, ref this.rectDraw_0, ref this.rectangleF_0);
      if (this.Image != null)
        this.rectDraw_0.rectText = ControlGeometry.GetTextRectangleFromImage(this.Image, this.ImageAlign, this.rectDraw_0.rectText, this.Geometry, this.ImageBorderOffset);
      float num1 = this.rectangleF_0.X + 0.0f;
      float num2 = (float) ((double) this.rectangleF_0.Width + (double) this.rectangleF_0.X - 0.0);
      try
      {
        this.float_0 = Convert.ToSingle((double) this.rectangleF_0.X + (this.Value - this.MinimumValue) * (double) Convert.ToSingle(((double) num2 - (double) num1) / (this.MaximumValue - this.MinimumValue)) - (double) this.Track.DrawerWidth / 2.0);
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
      ref RectangleF local1 = ref this.rectDraw_2.rect;
      Rectangle clientRectangle = this.ClientRectangle;
      double x = (double) clientRectangle.X;
      local1.X = (float) x;
      ref RectangleF local2 = ref this.rectDraw_2.rect;
      clientRectangle = this.ClientRectangle;
      double num3 = (double) clientRectangle.Height / 2.0 - this.CenterHeight / 2.0;
      local2.Y = (float) num3;
      ref RectangleF local3 = ref this.rectDraw_2.rect;
      clientRectangle = this.ClientRectangle;
      double width = (double) clientRectangle.Width;
      local3.Width = (float) width;
      this.rectDraw_2.rect.Height = (float) this.CenterHeight;
      ControlGeometry.drawGeometry((RectangleF) this.ClientRectangle, this.Geometry, this.Display, RoundRectangleType.RoundRectAll, ref graphics);
      ControlGeometry.drawGeometry(this.rectDraw_2.rect, this.Geometry, this.CenterDisplay, RoundRectangleType.RoundRectAll, ref graphics);
      if (this.Caption.Visible)
      {
        ControlGeometry.drawGeometry(this.rectDraw_0.rect, this.Geometry, this.Caption.Display, this.rectDraw_0.RoundType, ref graphics);
        ControlGeometry.drawString(this.rectDraw_0.rectText, str.ToString(), this.Caption.Display, ref graphics);
      }
      if (this.Track.ValueShow)
      {
        ControlGeometry.drawGeometry(this.rectDraw_1.rect, this.Geometry, this.Track.ValueDisplay, this.rectDraw_1.RoundType, ref graphics);
        ControlGeometry.drawString(this.rectDraw_1.rect, this.Value.ToString(), this.Track.ValueDisplay, ref graphics);
      }
      int num4 = (int) Math.Round((this.Value - this.MinimumValue) / (this.MaximumValue - this.MinimumValue) * ((double) this.rectangleF_0.Width - 3.0));
      RectangleF rectangleF = new RectangleF((float) ((double) this.Geometry.Space + (double) this.rectangleF_0.Left + 1.0), 2f + this.Geometry.Space + this.rectangleF_0.Top, (float) (num4 - 1), (float) ((double) this.Height - (double) this.rectangleF_0.Top - (double) this.Geometry.Space * 2.0 - 4.0));
      if (num4 > 1)
        ;
      if ((double) this.rectangleF_1.Width > 0.0 & (double) this.rectangleF_1.Height > 0.0)
        ControlGeometry.drawGeometry(this.rectangleF_1, this.Geometry, this.Track.DrawerDisplay, RoundRectangleType.RoundRectAll, ref graphics);
      if (this.Track.ShowPersentage)
        ;
      this.DrawImage(e.Graphics, this.Image, new Rectangle((int) this.rectDraw_0.rect.X, (int) this.rectDraw_0.rect.Y, (int) this.rectDraw_0.rect.Width, (int) this.rectDraw_0.rect.Height), this.ImageAlign);
    }
    this.themeType_0 = this.Theme.Type;
    base.OnPaint(e);
  }

  public delegate void ValueChangedEventHandler(object sender, double Val);
}
