// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buLedControl
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

public class buLedControl : Control, ISupportInitialize
{
  internal GraphicsPath[] graphicsPath_0 = new GraphicsPath[8];
  internal int int_0 = 1;
  internal Color color_0 = Color.Gray;
  internal int int_1 = 5;
  internal int int_2 = 5;
  internal float float_0 = 0.25f;
  internal Color color_1 = Color.DimGray;
  internal Color color_2 = Color.Black;
  internal Color color_3 = Color.DimGray;
  internal float float_1 = 0.2f;
  internal float float_2 = 0.05f;
  internal byte byte_0 = 50;
  internal bool bool_0;
  internal buLedControl.Alignment alignment_0;
  internal bool bool_1;
  internal bool bool_2;
  internal bool bool_3;
  private bool bool_4;
  private bool bool_5;
  private bool bool_6;

  [Browsable(true)]
  [Category("Appearance")]
  [Description("Turn on/off the italic text style.")]
  [DefaultValue(false)]
  public bool UseItalicStyle
  {
    get => this.bool_5;
    set
    {
      if (this.bool_5 == value)
        return;
      this.bool_5 = value;
      this.bool_0 = false;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Description("Turn on/off the smoothing mode.")]
  [Category("Appearance")]
  [Browsable(true)]
  [DefaultValue(false)]
  public bool UseSmoothingMode
  {
    get => this.bool_4;
    set
    {
      if (this.bool_4 == value)
        return;
      this.bool_4 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [DefaultValue(1)]
  [Browsable(true)]
  [Category("Appearance")]
  [Description("Set the border style")]
  public int BorderWidth
  {
    get => this.int_0;
    set
    {
      if (this.int_0 == value)
        return;
      this.int_0 = (value < 0 ? 1 : (value > 5 ? 1 : 0)) == 0 ? value : throw new ArgumentException("This value should be between 0 and 5");
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Description("Set the border color")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "Gray")]
  [Category("Appearance")]
  public Color BorderColor
  {
    get => this.color_0;
    set
    {
      if (value == this.color_0)
        return;
      this.color_0 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Description("Set the opaque value of the highlight")]
  [DefaultValue(50)]
  [Category("Appearance")]
  [Browsable(true)]
  public byte HighlightOpaque
  {
    get => this.byte_0;
    set
    {
      if (value > (byte) 100)
        throw new ArgumentException("This value should be between 0 and 50");
      if ((int) this.byte_0 == (int) value)
        return;
      this.byte_0 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [DefaultValue(false)]
  [Browsable(true)]
  [Category("Appearance")]
  [Description("Set whether to show highlight area on the control")]
  public bool ShowHighlight
  {
    get => this.bool_3;
    set
    {
      if (this.bool_3 == value)
        return;
      this.bool_3 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Description("Set the corner radius for the background rectangle.")]
  [DefaultValue(5)]
  [Category("Appearance")]
  [Browsable(true)]
  public int CornerRadius
  {
    get => this.int_1;
    set
    {
      if ((value < 1 ? 1 : (value > 10 ? 1 : 0)) != 0)
        throw new ArgumentException("This value should be between 1 and 10");
      if (this.int_1 == value)
        return;
      this.int_1 = value;
      if (!this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Description("Set if the background was filled in gradient colors")]
  [DefaultValue(false)]
  [Browsable(true)]
  [Category("Appearance")]
  public bool GradientBackground
  {
    get => this.bool_2;
    set
    {
      if (this.bool_2 == value)
        return;
      this.bool_2 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [Description("Set thr first custom background color")]
  [DefaultValue(typeof (Color), "System.Drawing.Color.Black")]
  [Category("Appearance")]
  public Color BackColor_1
  {
    get => this.color_2;
    set
    {
      this.color_2 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "System.Drawing.Color.DimGray")]
  [Description("Set thr second custom background color")]
  [Browsable(true)]
  [Category("Appearance")]
  public Color BackColor_2
  {
    get => this.color_3;
    set
    {
      this.color_3 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [DefaultValue(false)]
  [Browsable(true)]
  [Category("Appearance")]
  [Description("Set the background bound style")]
  public bool RoundCorner
  {
    get => this.bool_1;
    set
    {
      if (this.bool_1 == value)
        return;
      this.bool_1 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Category("Behavior")]
  [Browsable(true)]
  [DefaultValue(40)]
  [Description("Set segment interval ratio")]
  public int SegmentIntervalRatio
  {
    get => (int) (((double) this.float_2 - 0.00999999977648258) * 1000.0);
    set
    {
      if ((value < 0 ? 1 : (value > 100 ? 1 : 0)) != 0)
        throw new ArgumentException("This value should be between 0 and 100");
      this.float_2 = (float) (0.00999999977648258 + (double) value * 0.001);
      if (this.bool_6)
        return;
      this.bool_0 = false;
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [DefaultValue(typeof (buLedControl.Alignment), "Left")]
  [Category("Appearance")]
  [Description("Set the alignment of the text")]
  public buLedControl.Alignment TextAlignment
  {
    get => this.alignment_0;
    set
    {
      this.alignment_0 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [Category("Behavior")]
  [Description("Set the segment width ratio")]
  [DefaultValue(50)]
  public int SegmentWidthRatio
  {
    get => (int) (((double) this.float_1 - 0.100000001490116) * 500.0);
    set
    {
      if ((value < 0 ? 1 : (value > 100 ? 1 : 0)) != 0)
        throw new ArgumentException("This value should be between 0 and 100");
      this.float_1 = (float) (0.100000001490116 + (double) value * 0.002);
      if (this.bool_6)
        return;
      this.bool_0 = false;
      this.Invalidate();
    }
  }

  [Description("Set the total number of characters to display")]
  [DefaultValue(5)]
  [Category("Behavior")]
  [Browsable(true)]
  public int TotalCharCount
  {
    get => this.int_2;
    set
    {
      this.int_2 = value >= 2 ? value : throw new ArgumentException("This value should be greater than 2.");
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Browsable(true)]
  [DefaultValue(0.25)]
  [Category("Behavior")]
  [Description("Set the bevel rate of each segment")]
  public float BevelRate
  {
    get => this.float_0 * 2f;
    set
    {
      if (((double) value < 0.0 ? 1 : ((double) value > 1.0 ? 1 : 0)) != 0)
        throw new ArgumentException("This value should be between 0.0 and 1");
      this.float_0 = value / 2f;
      if (this.bool_6)
        return;
      this.bool_0 = false;
      this.Invalidate();
    }
  }

  [DefaultValue(typeof (Color), "System.Color.DimGray")]
  [Description("Set the color of background characters")]
  [Browsable(true)]
  [Category("Appearance")]
  public Color FadedColor
  {
    get => this.color_1;
    set
    {
      if (this.color_1 == value)
        return;
      this.color_1 = value;
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Description("Set text of the control")]
  [Category("Appearance")]
  [DefaultValue("LED")]
  [Browsable(true)]
  public override string Text
  {
    get => base.Text;
    set
    {
      base.Text = value.ToUpper();
      if (this.bool_6)
        return;
      this.Invalidate();
    }
  }

  [Browsable(false)]
  public override Image BackgroundImage
  {
    get => base.BackgroundImage;
    set => base.BackgroundImage = (Image) null;
  }

  [Browsable(false)]
  public override ImageLayout BackgroundImageLayout
  {
    get => base.BackgroundImageLayout;
    set
    {
    }
  }

  [Browsable(false)]
  public override Font Font
  {
    get => base.Font;
    set
    {
    }
  }

  public buLedControl()
  {
    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    this.ForeColor = Color.LightGreen;
    this.BackColor = Color.Transparent;
  }

  protected override void Dispose(bool disposing)
  {
    Class39.smethod_471(this);
    base.Dispose(disposing);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    Graphics graphics = e.Graphics;
    float float_0 = 0.0f;
    float float_1 = 0.0f;
    if ((this.ClientRectangle.Height < 20 ? 1 : (this.ClientRectangle.Width < 20 ? 1 : 0)) != 0)
      return;
    Class39.smethod_806(this, graphics);
    Class39.smethod_766(out float_0, out float_1, this);
    Class39.smethod_450(graphics, this, float_0, float_1);
    Class39.smethod_380(this, graphics);
  }

  protected override void OnPaintBackground(PaintEventArgs pevent)
  {
    base.OnPaintBackground(pevent);
  }

  protected override void OnSizeChanged(EventArgs e)
  {
    this.bool_0 = false;
    base.OnSizeChanged(e);
  }

  void ISupportInitialize.BeginInit() => this.bool_6 = true;

  void ISupportInitialize.EndInit()
  {
    this.bool_6 = false;
    this.Invalidate();
  }

  public enum Alignment
  {
    Left,
    Right,
  }
}
