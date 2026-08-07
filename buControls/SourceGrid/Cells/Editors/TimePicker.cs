// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.TimePicker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Converter;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TimePicker : DateTimePicker
{
  public TimePicker()
    : this("T", new string[1]{ "T" })
  {
  }

  public TimePicker(string toStringFormat, string[] p_ParseFormats)
  {
    this.TypeConverter = (TypeConverter) new DateTimeTypeConverter(toStringFormat, p_ParseFormats);
  }

  protected override System.Windows.Forms.Control CreateControl()
  {
    return (System.Windows.Forms.Control) new System.Windows.Forms.DateTimePicker()
    {
      Format = DateTimePickerFormat.Time,
      ShowUpDown = true
    };
  }

  public new System.Windows.Forms.DateTimePicker Control => base.Control;
}
