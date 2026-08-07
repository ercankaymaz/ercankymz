// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.DateTimePicker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class DateTimePicker : EditorControlBase
{
  public DateTimePicker()
    : base(typeof (DateTime))
  {
  }

  protected override System.Windows.Forms.Control CreateControl()
  {
    return (System.Windows.Forms.Control) new System.Windows.Forms.DateTimePicker()
    {
      Format = DateTimePickerFormat.Short,
      ShowCheckBox = this.AllowNull
    };
  }

  protected override void OnChanged(EventArgs e)
  {
    base.OnChanged(e);
    if (this.Control == null)
      return;
    this.Control.ShowCheckBox = this.AllowNull;
  }

  public System.Windows.Forms.DateTimePicker Control => (System.Windows.Forms.DateTimePicker) base.Control;

  protected override void OnStartingEdit(CellContext cellContext, System.Windows.Forms.Control editorControl)
  {
    base.OnStartingEdit(cellContext, editorControl);
    editorControl.Font = cellContext.Cell.View.Font;
  }

  public override void SetEditValue(object editValue)
  {
    if (editValue is DateTime dateTime)
    {
      this.Control.Value = dateTime;
    }
    else
    {
      if (editValue != null)
        throw new SourceGridException("Invalid edit value, expected DateTime");
      this.Control.Checked = false;
    }
  }

  public override object GetEditedValue()
  {
    return !this.Control.Checked ? (object) null : (object) this.Control.Value;
  }

  protected override void OnSendCharToEditor(char key)
  {
  }
}
