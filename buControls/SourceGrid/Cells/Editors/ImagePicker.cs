// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.ImagePicker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class ImagePicker : EditorControlBase
{
  public static readonly ImagePicker Default = new ImagePicker();

  public ImagePicker()
    : base(typeof (byte[]))
  {
  }

  protected override System.Windows.Forms.Control CreateControl()
  {
    DevAge.Windows.Forms.TextBoxUITypeEditor control = new DevAge.Windows.Forms.TextBoxUITypeEditor();
    control.BorderStyle = DevAge.Drawing.BorderStyle.None;
    control.Validator = (IValidator) new ValidatorTypeConverter(typeof (System.Drawing.Image));
    return (System.Windows.Forms.Control) control;
  }

  public DevAge.Windows.Forms.TextBoxUITypeEditor Control => (DevAge.Windows.Forms.TextBoxUITypeEditor) base.Control;

  public override object GetEditedValue()
  {
    object p_Value = this.Control.Value;
    switch (p_Value)
    {
      case null:
        return (object) null;
      case System.Drawing.Image _:
        return new ValidatorTypeConverter(typeof (System.Drawing.Image)).ValueToObject(p_Value, typeof (byte[]));
      case byte[] _:
        return p_Value;
      default:
        throw new SourceGridException("Invalid edited value, expected byte[] or Image");
    }
  }

  public override void SetEditValue(object editValue)
  {
    this.Control.Value = editValue;
    this.Control.TextBox.SelectAll();
  }

  public override string ValueToDisplayString(object p_Value) => (string) null;

  protected override void OnSendCharToEditor(char key)
  {
  }
}
