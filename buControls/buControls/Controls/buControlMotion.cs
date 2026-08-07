// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlMotion
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns20;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class53))]
public class buControlMotion
{
  private double double_0 = 0.0;
  private string string_0 = "";
  private string string_1 = "";
  private string string_2 = "";
  private int int_0 = -1;
  public Control Parent = (Control) null;

  public buControlMotion()
  {
  }

  public buControlMotion(double val, string address, string aux)
  {
    this.Value = val;
    this.Address = address;
    this.Aux = aux;
  }

  public buControlMotion(buControlMotion separator)
  {
    this.Value = separator.Value;
    this.Address = separator.Address;
    this.Aux = separator.Aux;
    this.Note = separator.Note;
    this.AxisIndex = separator.AxisIndex;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(0.0)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double Value
  {
    get => this.double_0;
    set
    {
      this.double_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(-1)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int AxisIndex
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
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Address
  {
    get => this.string_0;
    set
    {
      this.string_0 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Aux
  {
    get => this.string_1;
    set
    {
      this.string_1 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string Note
  {
    get => this.string_2;
    set
    {
      this.string_2 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  public override string ToString() => $"{this.Address.ToString()} , Val :{this.Value.ToString()}";
}
