// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlFocus
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns11;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class61))]
public class buControlFocus
{
  private bool bool_0 = false;
  private Color color_0 = Color.LightBlue;
  public Control Parent = (Control) null;

  public buControlFocus()
  {
  }

  public buControlFocus(buControlFocus control)
  {
    this.Enable = control.Enable;
    this.FocusColor = control.FocusColor;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(false)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public bool Enable
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

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(typeof (Color), "LightBlue")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public Color FocusColor
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

  public override string ToString() => $"{this.Enable.ToString()} , {this.FocusColor.ToString()}";
}
