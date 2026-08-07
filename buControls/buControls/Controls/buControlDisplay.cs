// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlDisplay
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class48))]
public class buControlDisplay : buSerilization
{
  private Control control_0 = (Control) null;
  public Color OldColor = Color.LightGray;
  private Color color_0 = Color.LightGray;
  private Color color_1 = Color.DarkOrange;
  private Color color_2 = Color.Gray;
  private Color color_3 = Color.Black;
  private GradientMode gradientMode_0 = GradientMode.Solid;
  private buControlLineerGradient buControlLineerGradient_0 = (buControlLineerGradient) null;
  private buControlPathGradient buControlPathGradient_0 = (buControlPathGradient) null;
  private buControlInterpolatedGradient buControlInterpolatedGradient_0 = (buControlInterpolatedGradient) null;
  private buControlBorder buControlBorder_0 = (buControlBorder) null;
  private buControlFont buControlFont_0 = (buControlFont) null;
  private buControlSeparator buControlSeparator_0 = (buControlSeparator) null;

  public buControlDisplay()
  {
    this.buControlLineerGradient_0 = new buControlLineerGradient();
    this.buControlLineerGradient_0.Changed += new EventHandler(this.DisplayChanged);
    this.buControlPathGradient_0 = new buControlPathGradient();
    this.buControlPathGradient_0.Changed += new EventHandler(this.DisplayChanged);
    this.buControlInterpolatedGradient_0 = new buControlInterpolatedGradient();
    this.buControlInterpolatedGradient_0.Changed += new EventHandler(this.DisplayChanged);
    this.buControlSeparator_0 = new buControlSeparator();
    this.buControlSeparator_0.Changed += new EventHandler(this.DisplayChanged);
    this.buControlBorder_0 = new buControlBorder();
    this.buControlBorder_0.Changed += new EventHandler(this.DisplayChanged);
    this.buControlFont_0 = new buControlFont();
    this.buControlFont_0.Changed += new EventHandler(this.DisplayChanged);
  }

  public buControlDisplay(buControlDisplay display)
  {
    this.BackColor = display.BackColor;
    this.SelectionColor = display.SelectionColor;
    this.TitleForeColor = display.TitleForeColor;
    this.DisableColor = display.DisableColor;
    this.GradientType = display.GradientType;
    this.Fonts = new buControlFont(display.Fonts);
    this.Fonts.Changed += new EventHandler(this.DisplayChanged);
    this.Border = new buControlBorder(display.Border);
    this.Border.Changed += new EventHandler(this.DisplayChanged);
    this.LineerGradient = new buControlLineerGradient(display.LineerGradient);
    this.LineerGradient.Changed += new EventHandler(this.DisplayChanged);
    this.PathGradient = new buControlPathGradient(display.PathGradient);
    this.PathGradient.Changed += new EventHandler(this.DisplayChanged);
    this.PathInterpolatedGradient = new buControlInterpolatedGradient(display.PathInterpolatedGradient);
    this.PathInterpolatedGradient.Changed += new EventHandler(this.DisplayChanged);
    this.Separator = new buControlSeparator(display.Separator);
    this.Separator.Changed += new EventHandler(this.DisplayChanged);
    this.Parent = display.Parent;
  }

  public static buControlDisplay Copy(
    buControlDisplay Source,
    buControlDisplay Target,
    bool FontsAlignment = true)
  {
    buControlDisplay.Copy(Source, ref Target, 1.0, FontsAlignment);
    return Target;
  }

  public static buControlDisplay Copy(
    buControlDisplay Source,
    buControlDisplay Target,
    double ToneChange,
    bool FontsAlignment = true)
  {
    buControlDisplay.Copy(Source, ref Target, ToneChange, FontsAlignment);
    return Target;
  }

  public static void Copy(
    buControlDisplay Source,
    ref buControlDisplay Target,
    double ToneChange,
    bool FontsAlignment = true)
  {
    if (ToneChange == 1.0)
    {
      Target.BackColor = Source.BackColor;
      Target.SelectionColor = Source.SelectionColor;
      Target.TitleForeColor = Source.TitleForeColor;
      Target.DisableColor = Source.DisableColor;
      Target.LineerGradient.FirstColor = Source.LineerGradient.FirstColor;
      Target.LineerGradient.SecondColor = Source.LineerGradient.SecondColor;
      Target.PathGradient.CenterColor = Source.PathGradient.CenterColor;
      Target.PathGradient.SurroundColor = Source.PathGradient.SurroundColor;
      Target.PathInterpolatedGradient.FirstColor = Source.PathInterpolatedGradient.FirstColor;
      Target.PathInterpolatedGradient.SecondColor = Source.PathInterpolatedGradient.SecondColor;
      Target.PathInterpolatedGradient.ThirdColor = Source.PathInterpolatedGradient.ThirdColor;
      Target.PathInterpolatedGradient.FourthColor = Source.PathInterpolatedGradient.FourthColor;
      Target.Separator.Color = Source.Separator.Color;
      Target.Border.Color = Source.Border.Color;
      Target.Fonts.ForeColor = Source.Fonts.ForeColor;
    }
    else
    {
      Target.BackColor = buImage.ColorToneChange(Source.BackColor, ToneChange);
      Target.SelectionColor = buImage.ColorToneChange(Source.SelectionColor, ToneChange);
      Target.TitleForeColor = buImage.ColorToneChange(Source.TitleForeColor, ToneChange);
      Target.DisableColor = buImage.ColorToneChange(Source.DisableColor, ToneChange);
      Target.LineerGradient.FirstColor = buImage.ColorToneChange(Source.LineerGradient.FirstColor, ToneChange);
      Target.LineerGradient.SecondColor = buImage.ColorToneChange(Source.LineerGradient.SecondColor, ToneChange);
      Target.PathGradient.CenterColor = buImage.ColorToneChange(Source.PathGradient.CenterColor, ToneChange);
      Target.PathGradient.SurroundColor = buImage.ColorToneChange(Source.PathGradient.SurroundColor, ToneChange);
      Target.PathInterpolatedGradient.FirstColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.FirstColor, ToneChange);
      Target.PathInterpolatedGradient.SecondColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.SecondColor, ToneChange);
      Target.PathInterpolatedGradient.ThirdColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.ThirdColor, ToneChange);
      Target.PathInterpolatedGradient.FourthColor = buImage.ColorToneChange(Source.PathInterpolatedGradient.FourthColor, ToneChange);
      Target.Separator.Color = buImage.ColorToneChange(Source.Separator.Color, ToneChange);
      Target.Border.Color = buImage.ColorToneChange(Source.Border.Color, ToneChange);
      Target.Fonts.ForeColor = buImage.ColorToneChange(Source.Fonts.ForeColor, ToneChange);
    }
    Target.GradientType = Source.GradientType;
    Target.LineerGradient.GradientAngle = Source.LineerGradient.GradientAngle;
    Target.PathInterpolatedGradient.ColorCount = Source.PathInterpolatedGradient.ColorCount;
    Target.Border.Thickness = Source.Border.Thickness;
    Target.Border.Visible = Source.Border.Visible;
    Target.Separator.Thickness = Source.Separator.Thickness;
    Target.Separator.Visible = Source.Separator.Visible;
    Target.Fonts.Font = new Font(Source.Fonts.Font.Name, Source.Fonts.Font.Size, Source.Fonts.Font.Style);
    if (!FontsAlignment)
      return;
    Target.Fonts.Alignment = Source.Fonts.Alignment;
  }

  public event EventHandler Changed;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(false)]
  public Control Parent
  {
    get => this.control_0;
    set
    {
      this.control_0 = value;
      if (this.Parent == null)
        return;
      this.Border.Parent = this.Parent;
      this.Separator.Parent = this.Parent;
      this.LineerGradient.Parent = this.Parent;
      this.PathGradient.Parent = this.Parent;
      this.PathInterpolatedGradient.Parent = this.Parent;
      this.Fonts.Parent = this.Parent;
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlSeparator Separator
  {
    get => this.buControlSeparator_0;
    set
    {
      this.buControlSeparator_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlBorder Border
  {
    get => this.buControlBorder_0;
    set
    {
      this.buControlBorder_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlFont Fonts
  {
    get => this.buControlFont_0;
    set
    {
      this.buControlFont_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlLineerGradient LineerGradient
  {
    get => this.buControlLineerGradient_0;
    set
    {
      this.buControlLineerGradient_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlPathGradient PathGradient
  {
    get => this.buControlPathGradient_0;
    set
    {
      this.buControlPathGradient_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlInterpolatedGradient PathInterpolatedGradient
  {
    get => this.buControlInterpolatedGradient_0;
    set
    {
      this.buControlInterpolatedGradient_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(GradientMode.Solid)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public GradientMode GradientType
  {
    get => this.gradientMode_0;
    set
    {
      this.gradientMode_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color BackColor
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color DisableColor
  {
    get => this.color_2;
    set
    {
      this.color_2 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "DarkOrange")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color SelectionColor
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Black")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color TitleForeColor
  {
    get => this.color_3;
    set
    {
      this.color_3 = value;
      this.OnChanged();
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  protected void DisplayChanged(object sender, EventArgs e) => this.OnChanged();

  protected void OnChanged()
  {
    // ISSUE: reference to a compiler-generated field
    if (this.eventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler0 = this.eventHandler_0;
    if (eventHandler0 == null)
      return;
    eventHandler0((object) this, EventArgs.Empty);
  }

  public override string ToString() => this.GradientType.ToString();
}
