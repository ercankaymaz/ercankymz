// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlGeometry
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns15;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class46))]
public class buControlGeometry
{
  private ShapeType shapeType_0 = ShapeType.Rectangle;
  private int int_0 = 10;
  private float float_0 = 1f;
  public Control Parent = (Control) null;

  public buControlGeometry()
  {
  }

  public buControlGeometry(buControlGeometry control)
  {
    this.ArcDiameter = control.ArcDiameter;
    this.ShapeMode = control.ShapeMode;
    this.Space = control.Space;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(1f)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public float Space
  {
    get => this.float_0;
    set
    {
      this.float_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(10)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int ArcDiameter
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
  [DefaultValue(ShapeType.Rectangle)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public ShapeType ShapeMode
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

  public override string ToString() => this.ShapeMode.ToString();
}
