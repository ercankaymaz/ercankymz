// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Validator.IValidator
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.Globalization;

#nullable disable
namespace DevAge.ComponentModel.Validator;

public interface IValidator
{
  bool AllowNull { get; set; }

  string NullString { get; set; }

  string NullDisplayString { get; set; }

  bool IsNullString(string p_str);

  object ObjectToValue(object p_Object);

  object ValueToObject(object p_Value, Type p_ReturnObjectType);

  string ValueToString(object p_Value);

  object StringToValue(string p_str);

  bool IsStringConversionSupported();

  bool AllowStringConversion { get; set; }

  string ValueToDisplayString(object p_Value);

  bool IsValidValue(object p_Value);

  bool IsValidObject(object p_Object);

  bool IsValidObject(object p_Object, out object p_ValueConverted);

  bool IsValidString(string p_strValue);

  bool IsValidString(string p_strValue, out object p_ValueConverted);

  object MinimumValue { get; set; }

  object MaximumValue { get; set; }

  Type ValueType { get; }

  event ConvertingObjectEventHandler ConvertingObjectToValue;

  event ConvertingObjectEventHandler ConvertingValueToObject;

  event ConvertingObjectEventHandler ConvertingValueToDisplayString;

  object DefaultValue { get; set; }

  ICollection StandardValues { get; set; }

  bool StandardValuesExclusive { get; set; }

  bool IsInStandardValues(object p_Value);

  object StandardValueAtIndex(int p_Index);

  int StandardValuesIndexOf(object p_StandardValue);

  CultureInfo CultureInfo { get; set; }

  event EventHandler Changed;
}
