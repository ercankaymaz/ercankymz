// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.TextBoxUITypeEditor
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using System.ComponentModel;
using System.Drawing.Design;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxUITypeEditor(System.Type p_Type) : TextBoxButton(p_Type)
{
  protected override System.Windows.Forms.Control CreateControl()
  {
    DevAge.Windows.Forms.TextBoxUITypeEditor control = new DevAge.Windows.Forms.TextBoxUITypeEditor();
    control.BorderStyle = DevAge.Drawing.BorderStyle.None;
    control.Validator = (IValidator) this;
    object editor = TypeDescriptor.GetEditor(this.ValueType, typeof (UITypeEditor));
    UITypeEditor uiTypeEditor = (UITypeEditor) null;
    if (control != null)
      uiTypeEditor = (UITypeEditor) editor;
    control.UITypeEditor = uiTypeEditor;
    return (System.Windows.Forms.Control) control;
  }

  public DevAge.Windows.Forms.TextBoxUITypeEditor Control => (DevAge.Windows.Forms.TextBoxUITypeEditor) base.Control;
}
