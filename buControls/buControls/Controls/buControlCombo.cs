// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlCombo
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns16;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class64))]
public class buControlCombo
{
  public Control Parent;
  private int int_0 = 20;
  private Color color_0 = Color.DimGray;
  private Color color_1 = Color.DimGray;
  private Color color_2 = Color.LightGray;
  private Color color_3 = Color.WhiteSmoke;

  public buControlCombo()
  {
  }

  public buControlCombo(buControlCombo combo)
  {
    this.ValueColor = combo.ValueColor;
    this.DropBoxColor = combo.DropBoxColor;
    this.ArrowButtonWidth = combo.ArrowButtonWidth;
    this.ArrowColor = combo.ArrowColor;
  }

  [DefaultValue(typeof (Color), "WhiteSmoke")]
  public Color ValueColor
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

  [DefaultValue(typeof (Color), "LightGray")]
  public Color DropBoxColor
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

  [DefaultValue(20)]
  public int ArrowButtonWidth
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

  [DefaultValue(typeof (Color), "DimGray")]
  public Color ArrowColor
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

  [DefaultValue(typeof (Color), "DimGray")]
  public Color ArrowLineColor
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

  public override string ToString() => this.ValueColor.ToString();
}
