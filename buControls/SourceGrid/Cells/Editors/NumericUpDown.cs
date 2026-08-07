// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.NumericUpDown
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class NumericUpDown : EditorControlBase
{
  public NumericUpDown()
    : base(typeof (Decimal))
  {
  }

  public NumericUpDown(System.Type p_CellType, Decimal p_Maximum, Decimal p_Minimum, Decimal p_Increment)
    : base(p_CellType)
  {
    if ((p_CellType == (System.Type) null || p_CellType == typeof (int) || p_CellType == typeof (long) ? 1 : (p_CellType == typeof (Decimal) ? 1 : 0)) == 0)
      throw new SourceGridException("Invalid CellType expected long, int or decimal");
    this.Control.Maximum = p_Maximum;
    this.Control.Minimum = p_Minimum;
    this.Control.Increment = p_Increment;
  }

  protected override System.Windows.Forms.Control CreateControl()
  {
    System.Windows.Forms.NumericUpDown control = new System.Windows.Forms.NumericUpDown();
    control.BorderStyle = BorderStyle.None;
    return (System.Windows.Forms.Control) control;
  }

  public System.Windows.Forms.NumericUpDown Control => (System.Windows.Forms.NumericUpDown) base.Control;

  public override void SetEditValue(object editValue)
  {
    switch (editValue)
    {
      case Decimal num2:
label_5:
        Decimal num1 = this.Control.Value;
        this.Control.Value = num2;
        break;
      case long num3:
        num2 = (Decimal) num3;
        goto label_5;
      case int num4:
        num2 = (Decimal) num4;
        goto label_5;
      case null:
        num2 = this.Control.Minimum;
        goto label_5;
      default:
        throw new SourceGridException("Invalid value, expected Decimal, Int or Long");
    }
  }

  public override object GetEditedValue()
  {
    if (this.ValueType == (System.Type) null)
      return (object) this.Control.Value;
    if (this.ValueType == typeof (Decimal))
      return (object) this.Control.Value;
    if (this.ValueType == typeof (int))
      return (object) (int) this.Control.Value;
    if (this.ValueType == typeof (long))
      return (object) (long) this.Control.Value;
    throw new SourceGridException("Invalid type of the cell expected decimal, long or int");
  }

  protected override void OnSendCharToEditor(char key)
  {
  }
}
