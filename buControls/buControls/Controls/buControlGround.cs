// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlGround
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns2;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class62))]
public class buControlGround
{
  private int int_0 = 0;
  private int int_1 = 35;
  public Control Parent = (Control) null;

  public buControlGround()
  {
  }

  public buControlGround(buControlGround control)
  {
    this.TopHeight = control.TopHeight;
    this.BottomHeight = control.BottomHeight;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(35)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int TopHeight
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
  [DefaultValue(0)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int BottomHeight
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

  public override string ToString()
  {
    int num = this.TopHeight;
    string str1 = num.ToString();
    num = this.BottomHeight;
    string str2 = num.ToString();
    return $"{str1} , {str2}";
  }
}
