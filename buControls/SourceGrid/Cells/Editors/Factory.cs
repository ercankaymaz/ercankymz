// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Editors.Factory
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;

#nullable disable
namespace SourceGrid.Cells.Editors;

public static class Factory
{
  public static EditorBase Create(Type p_Type)
  {
    TypeConverter converter = TypeDescriptor.GetConverter(p_Type);
    ICollection p_StandardValues = (ICollection) null;
    bool p_StandardValueExclusive = false;
    if (converter != null)
    {
      p_StandardValues = converter.GetStandardValues();
      p_StandardValueExclusive = (p_StandardValues == null ? 0 : (p_StandardValues.Count > 0 ? 1 : 0)) != 0 && converter.GetStandardValuesExclusive();
    }
    return TypeDescriptor.GetEditor(p_Type, typeof (UITypeEditor)) == null ? (p_StandardValues == null ? ((converter == null ? 0 : (converter.CanConvertFrom(typeof (string)) ? 1 : 0)) == 0 ? (EditorBase) null : (EditorBase) new TextBox(p_Type)) : (EditorBase) new ComboBox(p_Type, p_StandardValues, p_StandardValueExclusive)) : (EditorBase) new TextBoxUITypeEditor(p_Type);
  }

  public static EditorBase Create(
    Type p_Type,
    object p_DefaultValue,
    bool p_bAllowNull,
    ICollection p_StandardValues,
    bool p_bStandardValueExclusive,
    TypeConverter p_TypeConverter,
    UITypeEditor p_UITypeEditor)
  {
    EditorBase editorBase;
    if (p_UITypeEditor == null)
      editorBase = p_StandardValues == null ? ((p_TypeConverter == null ? 0 : (p_TypeConverter.CanConvertFrom(typeof (string)) ? 1 : 0)) == 0 ? (EditorBase) null : (EditorBase) new TextBox(p_Type)) : (EditorBase) new ComboBox(p_Type);
    else
      editorBase = (EditorBase) new TextBoxUITypeEditor(p_Type)
      {
        Control = {
          UITypeEditor = p_UITypeEditor
        }
      };
    if (editorBase != null)
    {
      editorBase.DefaultValue = p_DefaultValue;
      editorBase.AllowNull = p_bAllowNull;
      editorBase.StandardValues = p_StandardValues;
      editorBase.StandardValuesExclusive = p_bStandardValueExclusive;
      editorBase.TypeConverter = p_TypeConverter;
    }
    return editorBase;
  }
}
