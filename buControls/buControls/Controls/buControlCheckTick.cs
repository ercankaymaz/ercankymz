// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlCheckTick
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns5;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class59))]
public class buControlCheckTick
{
  private int int_0 = 20;
  private int int_1 = 6;
  private ShapeType shapeType_0 = ShapeType.Arc;
  private bool bool_0 = false;
  private bool bool_1 = true;
  private bool bool_2 = false;
  private buControlDisplay buControlDisplay_0 = new buControlDisplay();
  private buControlDisplay buControlDisplay_1 = new buControlDisplay();
  public Control Parent = (Control) null;
  private bool bool_3 = false;
  private int int_2 = 3;

  public buControlCheckTick()
  {
  }

  public buControlCheckTick(buControlCheckTick check)
  {
    this.BoxSize = check.BoxSize;
    this.ColorModeEnable = check.ColorModeEnable;
    this.RightSide = check.RightSide;
    this.Space = check.Space;
    this.TickDisplay = new buControlDisplay(check.TickDisplay);
    this.ColorModeDisplay = new buControlDisplay(check.ColorModeDisplay);
    this.Visible = check.Visible;
  }

  [DefaultValue(true)]
  public bool Visible
  {
    get => this.bool_1;
    set
    {
      this.bool_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(false)]
  public bool OnlyClickMode
  {
    get => this.bool_2;
    set
    {
      this.bool_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(3)]
  public int Space
  {
    get => this.int_2;
    set
    {
      this.int_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay TickDisplay
  {
    get => this.buControlDisplay_0;
    set
    {
      this.buControlDisplay_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(true)]
  public buControlDisplay ColorModeDisplay
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

  [DefaultValue(20)]
  public int BoxSize
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

  [DefaultValue(6)]
  public int ArcDiameter
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

  [DefaultValue(ShapeType.Arc)]
  public ShapeType Shape
  {
    get => this.shapeType_0;
    set
    {
      this.shapeType_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [DefaultValue(false)]
  public bool RightSide
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

  [DefaultValue(false)]
  public bool ColorModeEnable
  {
    get => this.bool_3;
    set
    {
      this.bool_3 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public override string ToString() => this.Visible.ToString();
}
