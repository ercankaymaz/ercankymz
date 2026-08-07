// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlSecurity
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns19;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class60))]
public class buControlSecurity
{
  private bool bool_0 = false;
  private int int_0 = 0;
  public Control Parent = (Control) null;

  public buControlSecurity()
  {
  }

  public buControlSecurity(buControlSecurity control)
  {
    this.Enable = control.Enable;
    this.Level = control.Level;
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
  [DefaultValue(0)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int Level
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

  public override string ToString() => $"{this.Enable.ToString()} , {this.Level.ToString()}";
}
