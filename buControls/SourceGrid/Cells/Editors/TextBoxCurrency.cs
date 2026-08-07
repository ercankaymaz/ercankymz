// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.TextBoxCurrency
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Converter;
using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Cells.Editors;

[ToolboxItem(false)]
public class TextBoxCurrency : TextBoxNumeric
{
  public TextBoxCurrency(Type p_Type)
    : base(p_Type)
  {
    this.TypeConverter = (TypeConverter) new CurrencyTypeConverter(p_Type);
  }
}
