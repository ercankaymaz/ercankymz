// Decompiled with JetBrains decompiler
// Type: buControls.Controls.buControlAux
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns15;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Controls;

[TypeConverter(typeof (Class52))]
public class buControlAux
{
  private int int_0 = 0;
  private int int_1 = -1;
  private double double_0 = 0.0;
  private string string_0 = "";
  private string string_1 = "";
  private string string_2 = "";
  private string string_3 = "";
  private string string_4 = "";
  public Control Parent = (Control) null;

  public buControlAux()
  {
  }

  public buControlAux(double valdbl, int valint, string explanation)
  {
    this.ValInt = valint;
    this.ValDouble = valdbl;
    this.Explanation = explanation;
  }

  public buControlAux(double valdbl, int valint, string explanation, string variablename)
  {
    this.ValInt = valint;
    this.ValDouble = valdbl;
    this.Explanation = explanation;
    this.VariableName = variablename;
  }

  public buControlAux(buControlAux separator)
  {
    this.ValInt = separator.ValInt;
    this.ValDouble = separator.ValDouble;
    this.Explanation = separator.Explanation;
    this.VariableName = separator.VariableName;
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(0.0)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public double ValDouble
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
  [DefaultValue(0)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int ValInt
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
  public string Explanation
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
  public string Command
  {
    get => this.string_3;
    set
    {
      this.string_3 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string VariableName
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
  public string AuxInfo
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

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue("")]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public string HelpRefKey
  {
    get => this.string_4;
    set
    {
      this.string_4 = value;
      if (this.Parent == null)
        return;
      this.Parent.Invalidate();
    }
  }

  [EditorBrowsable(EditorBrowsableState.Always)]
  [DefaultValue(-1)]
  [NotifyParentProperty(true)]
  [Browsable(true)]
  public int Index
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

  public override string ToString()
  {
    return $"{this.ValDouble.ToString()} , {this.Explanation.ToString()}";
  }
}
