// Decompiled with JetBrains decompiler
// Type: buControls.Components.buClock
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

#nullable disable
namespace buControls.Components;

[ToolboxItem(true)]
[DefaultProperty("ClockFaceColor")]
public class buClock : Control
{
  private readonly Timer timer_0;
  private bool bool_0;

  [Category("Appearance")]
  public Color ClockFaceColor { get; set; } = Color.FromArgb(30, 30, 35);

  [Category("Appearance")]
  public Color OuterRingColor { get; set; } = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 90);

  [Category("Appearance")]
  public Color TickColor { get; set; } = Color.WhiteSmoke;

  [Category("Appearance")]
  public Color HourHandColor { get; set; } = Color.White;

  [Category("Appearance")]
  public Color MinuteHandColor { get; set; } = Color.Gainsboro;

  [Category("Appearance")]
  public Color SecondHandColor { get; set; } = Color.OrangeRed;

  [Category("Appearance")]
  public Color DigitalTimeColor { get; set; } = Color.DeepSkyBlue;

  [Category("Appearance")]
  public Color CenterColor { get; set; } = Color.White;

  [Category("Appearance")]
  public Font DigitalFont { get; set; } = new Font("Segoe UI", 10f, FontStyle.Bold);

  [Category("Appearance")]
  [DefaultValue(45)]
  public int DigitalTimeHeight { get; set; } = 45;

  [Category("Behavior")]
  public bool Running => this.bool_0;

  [Category("Behavior")]
  public bool ShowDigitalTime { get; set; } = true;

  [Category("Behavior")]
  public bool ShowSecondHand { get; set; } = true;

  [Category("Behavior")]
  public bool ShowGlow { get; set; } = true;

  [Category("Behavior")]
  public bool ShowNumbers { get; set; } = false;

  [Category("Appearance")]
  public float OuterRingThickness { get; set; } = 6f;

  [Category("Appearance")]
  public float HourHandThickness { get; set; } = 6f;

  [Category("Appearance")]
  public float MinuteHandThickness { get; set; } = 4f;

  [Category("Appearance")]
  public float SecondHandThickness { get; set; } = 2f;

  public buClock()
  {
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    this.DoubleBuffered = true;
    this.BackColor = Color.Transparent;
    this.Size = new Size(280, 280);
    this.timer_0 = new Timer();
    this.timer_0.Interval = 20;
    this.timer_0.Tick += (EventHandler) ((sender, e) => this.Invalidate());
  }

  public void Start()
  {
    if (this.bool_0)
      return;
    this.timer_0.Start();
    this.bool_0 = true;
  }

  public void Stop()
  {
    if (!this.bool_0)
      return;
    this.timer_0.Stop();
    this.bool_0 = false;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.timer_0?.Dispose();
    base.Dispose(disposing);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    Graphics graphics = e.Graphics;
    graphics.SmoothingMode = SmoothingMode.AntiAlias;
    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
    graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
    int val2 = this.Height - (this.ShowDigitalTime ? this.DigitalTimeHeight : 0);
    int num1 = Math.Min(this.Width, val2) / 2 - 15;
    int num2 = this.ShowDigitalTime ? -5 : 0;
    Point point_0 = new Point(this.Width / 2, val2 / 2 + num2);
    Rectangle rectangle_0 = new Rectangle(point_0.X - num1, point_0.Y - num1, num1 * 2, num1 * 2);
    Class39.smethod_134(graphics, this, rectangle_0);
    Class39.smethod_527(num1, this, graphics, point_0);
    if (this.ShowNumbers)
      this.method_0(graphics, point_0, num1);
    Class39.smethod_452(this, graphics, point_0, num1);
    Class39.smethod_736(point_0, graphics, this);
    if (!this.ShowDigitalTime)
      return;
    Class39.smethod_6(this, graphics);
  }

  private void method_0(Graphics graphics_0, Point point_0, int int_1)
  {
    using (Brush brush = (Brush) new SolidBrush(this.TickColor))
    {
      for (int index = 1; index <= 12; ++index)
      {
        double num1 = (double) (index * 30) * Math.PI / 180.0;
        int num2 = point_0.X + (int) (Math.Sin(num1) * (double) (int_1 - 40));
        int num3 = point_0.Y - (int) (Math.Cos(num1) * (double) (int_1 - 40));
        string str = index.ToString();
        SizeF sizeF = graphics_0.MeasureString(str, this.Font);
        graphics_0.DrawString(str, this.Font, brush, (float) num2 - sizeF.Width / 2f, (float) num3 - sizeF.Height / 2f);
      }
    }
  }
}
