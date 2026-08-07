// Decompiled with JetBrains decompiler
// Type: buControls.UserControls.AxisCoordinates
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.UserControls;

public class AxisCoordinates : UserControl
{
  private Color color_0 = Color.LightGray;
  private Color color_1 = Color.Black;
  private Color color_2 = Color.YellowGreen;
  private Color color_3 = Color.Black;
  private Color color_4 = Color.Black;
  private Color color_5 = Color.LimeGreen;
  private Color color_6 = Color.Red;
  private Color color_7 = Color.Black;
  private bool bool_0 = false;
  private bool bool_1 = false;
  private bool bool_2 = false;
  private int int_0 = 8;
  private string string_0 = "0.00";
  private string string_1 = "0.00";
  private string string_2 = "X";
  private int int_1 = 0;
  private int int_2 = 30;
  private IContainer icontainer_0 = (IContainer) null;
  public buLedControl coord_x;
  public buLabel lbl_x;
  public buCheckBox chk_xenable;
  public buCheckBox chk_xhome;
  public buLedControl coord_offsetx;

  [Description("Axis Caption")]
  [Browsable(true)]
  [DefaultValue("X")]
  [Category("Appearance")]
  public string AxisCaption
  {
    get => this.string_2;
    set
    {
      if (value == this.string_2)
        return;
      this.string_2 = value;
      this.lbl_x.Text = value;
      this.Invalidate();
    }
  }

  [Description("Axis Width")]
  [Browsable(true)]
  [DefaultValue(30)]
  [Category("Appearance")]
  public int AxisCaptionWidth
  {
    get => this.int_2;
    set
    {
      if (value == this.int_2)
        return;
      this.int_2 = value;
      this.lbl_x.Width = value;
      this.method_0((object) null, (EventArgs) null);
      this.Invalidate();
    }
  }

  [Description("Axis Index")]
  [Browsable(true)]
  [DefaultValue(0)]
  [Category("Appearance")]
  public int AxisIndex
  {
    get => this.int_1;
    set
    {
      if (value == this.int_1)
        return;
      this.int_1 = value;
      this.Invalidate();
    }
  }

  [Description("Axis Value")]
  [Browsable(true)]
  [DefaultValue("0.00")]
  [Category("Appearance")]
  public string AxisValue
  {
    get => this.string_0;
    set
    {
      if (value == this.string_0)
        return;
      this.string_0 = value;
      this.coord_x.Text = value;
      this.Invalidate();
    }
  }

  [Description("Axis Offseted Value")]
  [Browsable(true)]
  [DefaultValue("0.00")]
  [Category("Appearance")]
  public string AxisOffsetedValue
  {
    get => this.string_1;
    set
    {
      if (value == this.string_1)
        return;
      this.string_1 = value;
      this.coord_offsetx.Text = value;
      this.Invalidate();
    }
  }

  [Description("Axis Value")]
  [Browsable(true)]
  [DefaultValue(8)]
  [Category("Appearance")]
  public int AxisDecimalCount
  {
    get => this.int_0;
    set
    {
      if (value == this.int_0)
        return;
      this.int_0 = value;
      this.coord_x.TotalCharCount = value;
      this.Invalidate();
    }
  }

  [Description("Axis Caption BackColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "LightGray")]
  [Category("Appearance")]
  public Color AxisCaptionBackColor
  {
    get => this.color_0;
    set
    {
      if (value == this.color_0)
        return;
      this.color_0 = value;
      this.lbl_x.Display.BackColor = value;
      this.Invalidate();
    }
  }

  [Description("Axis Caption ForeColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "Black")]
  [Category("Appearance")]
  public Color AxisCaptionForeColor
  {
    get => this.color_1;
    set
    {
      if (value == this.color_1)
        return;
      this.color_1 = value;
      this.lbl_x.Display.Fonts.ForeColor = value;
      this.Invalidate();
    }
  }

  [Description("Axis ForeColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "YellowGreen")]
  [Category("Appearance")]
  public Color AxisForeColor
  {
    get => this.color_2;
    set
    {
      if (value == this.color_2)
        return;
      this.color_2 = value;
      this.coord_x.ForeColor = value;
      this.Invalidate();
    }
  }

  [Description("Axis BackColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "Black")]
  [Category("Appearance")]
  public Color AxisBackColor
  {
    get => this.color_3;
    set
    {
      if (value == this.color_3)
        return;
      this.color_3 = value;
      this.coord_x.BackColor_1 = value;
      this.Invalidate();
    }
  }

  [Description("Axis FadeColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "Black")]
  [Category("Appearance")]
  public Color AxisFadeColor
  {
    get => this.color_4;
    set
    {
      if (value == this.color_4)
        return;
      this.color_4 = value;
      this.coord_x.FadedColor = value;
      this.Invalidate();
    }
  }

  [Description("Axis Status ActiveColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "LimeGreen")]
  [Category("Appearance")]
  public Color AxisStatusActiveColor
  {
    get => this.color_5;
    set
    {
      if (value == this.color_5)
        return;
      this.color_5 = value;
      this.Invalidate();
    }
  }

  [Description("Axis Status PassiveColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "Red")]
  [Category("Appearance")]
  public Color AxisStatusPassiveColor
  {
    get => this.color_6;
    set
    {
      if (value == this.color_6)
        return;
      this.color_6 = value;
      this.Invalidate();
    }
  }

  [Description("Axis Status PassiveColor")]
  [Browsable(true)]
  [DefaultValue(typeof (Color), "Red")]
  [Category("Appearance")]
  public Color AxisStatusForeColor
  {
    get => this.color_7;
    set
    {
      if (value == this.color_7)
        return;
      this.color_7 = value;
      this.chk_xenable.Display.Fonts.ForeColor = value;
      this.chk_xhome.Display.Fonts.ForeColor = value;
      this.Invalidate();
    }
  }

  [Description("Axis Offset Position Show")]
  [Browsable(true)]
  [DefaultValue(false)]
  [Category("Appearance")]
  public bool AxisOffsetPositionShow
  {
    get => this.bool_2;
    set
    {
      if (value == this.bool_2)
        return;
      this.bool_2 = value;
      this.coord_offsetx.Visible = value;
      this.method_0((object) null, (EventArgs) null);
      this.Invalidate();
    }
  }

  [Description("Axis Enable")]
  [Browsable(true)]
  [DefaultValue(false)]
  [Category("Appearance")]
  public bool AxisEnable
  {
    get => this.bool_0;
    set
    {
      if (value == this.bool_0)
        return;
      this.bool_0 = value;
      this.chk_xenable.Check = value;
      if (this.chk_xenable.Check)
      {
        this.chk_xenable.Display.BackColor = this.color_5;
        this.chk_xenable.CheckTick.ColorModeDisplay.BackColor = this.color_5;
      }
      else
      {
        this.chk_xenable.Display.BackColor = this.color_6;
        this.chk_xenable.CheckTick.ColorModeDisplay.BackColor = this.color_6;
      }
      this.Invalidate();
    }
  }

  [Description("Axis Home")]
  [Browsable(true)]
  [DefaultValue(false)]
  [Category("Appearance")]
  public bool AxisHome
  {
    get => this.bool_1;
    set
    {
      if (value == this.bool_1)
        return;
      this.bool_1 = value;
      this.chk_xhome.Check = value;
      if (this.chk_xhome.Check)
      {
        this.chk_xhome.Display.BackColor = this.color_5;
        this.chk_xhome.CheckTick.ColorModeDisplay.BackColor = this.color_5;
      }
      else
      {
        this.chk_xhome.Display.BackColor = this.color_6;
        this.chk_xhome.CheckTick.ColorModeDisplay.BackColor = this.color_6;
      }
      this.Invalidate();
    }
  }

  public AxisCoordinates() => Class39.smethod_784(this);

  internal void method_0(object sender, EventArgs e)
  {
    this.chk_xenable.Height = Convert.ToInt32(this.Height / 2);
    this.chk_xhome.Top = this.chk_xenable.Top + this.chk_xenable.Height;
    this.chk_xhome.Height = Convert.ToInt32(this.Height / 2);
    float num = (float) (this.Width - this.lbl_x.Width - this.chk_xenable.Width - 2);
    if (!this.bool_2)
    {
      this.coord_x.Left = this.lbl_x.Width + 2;
      this.coord_x.Width = Convert.ToInt32(num);
    }
    else
    {
      this.coord_x.Left = this.lbl_x.Width + 2;
      this.coord_x.Width = Convert.ToInt32(num / 2f) - 1;
      this.coord_offsetx.Left = this.coord_x.Left + this.coord_x.Width + 2;
      this.coord_offsetx.Width = Convert.ToInt32(num / 2f) - 2;
    }
  }

  internal void method_1(object sender, EventArgs e) => this.OnDoubleClick(e);

  internal void method_2(object sender, EventArgs e) => this.OnClick(e);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
