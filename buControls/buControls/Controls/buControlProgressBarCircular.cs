// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlProgressBarCircular
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns9;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class68))]
public class buControlProgressBarCircular
{
  private Color color_0 = Color.Gray;
  private Color color_1 = Color.Gray;
  private CircularProgressShape circularProgressShape_0 = CircularProgressShape.Flat;
  private float float_0 = 10f;
  private int int_0 = -2;
  private int int_1 = 6;
  private bool bool_0 = true;
  private int int_2 = 20;
  private Color color_2 = Color.LightGray;
  private Color color_3 = Color.LightGray;
  private Color color_4 = Color.Black;
  public Control Parent;

  public buControlProgressBarCircular()
  {
  }

  public buControlProgressBarCircular(buControlProgressBarCircular progress)
  {
    this.BorderSpace = progress.BorderSpace;
    this.CoreBorderColor = progress.CoreBorderColor;
    this.CoreColor1 = progress.CoreColor1;
    this.CoreColor2 = progress.CoreColor2;
    this.InnerBorderSpace = progress.InnerBorderSpace;
    this.ProgressColor1 = progress.ProgressColor1;
    this.ProgressColor2 = progress.ProgressColor2;
    this.ProgressShape = progress.ProgressShape;
    this.ShowPercentage = progress.ShowPercentage;
    this.TextHeight = progress.TextHeight;
    this.Thickness = progress.Thickness;
  }

  public static void Copy(
    buControlProgressBarCircular Source,
    ref buControlProgressBarCircular Target)
  {
    Target.BorderSpace = Source.BorderSpace;
    Target.CoreBorderColor = Source.CoreBorderColor;
    Target.CoreColor1 = Source.CoreColor1;
    Target.CoreColor2 = Source.CoreColor2;
    Target.InnerBorderSpace = Source.InnerBorderSpace;
    Target.ProgressColor1 = Source.ProgressColor1;
    Target.ProgressColor2 = Source.ProgressColor2;
    Target.ProgressShape = Source.ProgressShape;
    Target.ShowPercentage = Source.ShowPercentage;
    Target.TextHeight = Source.TextHeight;
    Target.Thickness = Source.Thickness;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(20)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int TextHeight
  {
    get => this.int_2;
    set
    {
      if (value < 0)
        value = 0;
      this.int_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(10f)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public float Thickness
  {
    get => this.float_0;
    set
    {
      if ((double) value < 1.0)
        value = 1f;
      this.float_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(-2)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int BorderSpace
  {
    get => this.int_0;
    set
    {
      this.int_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(6)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int InnerBorderSpace
  {
    get => this.int_1;
    set
    {
      this.int_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color ProgressColor1
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Gray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color ProgressColor2
  {
    get => this.color_1;
    set
    {
      this.color_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "Black")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color CoreBorderColor
  {
    get => this.color_4;
    set
    {
      this.color_4 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color CoreColor1
  {
    get => this.color_2;
    set
    {
      this.color_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightGray")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color CoreColor2
  {
    get => this.color_3;
    set
    {
      this.color_3 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(CircularProgressShape.Flat)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public CircularProgressShape ProgressShape
  {
    get => this.circularProgressShape_0;
    set
    {
      this.circularProgressShape_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(true)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool ShowPercentage
  {
    get => this.bool_0;
    set
    {
      this.bool_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public override string ToString() => "Circular Progress";
}
