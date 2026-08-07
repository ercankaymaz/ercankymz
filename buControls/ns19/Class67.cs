// Decompiled with JetBrains decompiler
// Type: ns19.Class67
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using System;
using System.ComponentModel;
using System.Globalization;

#nullable disable
namespace ns19;

internal sealed class Class67 : ExpandableObjectConverter
{
  virtual object TypeConverter.ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    string str = ((buControlTab) value).TabPageColor.ToKnownColor().ToString();
    // ISSUE: explicit non-virtual call
    return !(destinationType == typeof (string)) ? __nonvirtual (((TypeConverter) this).ConvertTo(context, culture, value, destinationType)) : (object) str;
  }

  virtual bool TypeConverter.CanConvertTo(ITypeDescriptorContext context, Type destinationType)
  {
    // ISSUE: explicit non-virtual call
    return destinationType == typeof (string) || __nonvirtual (((TypeConverter) this).CanConvertTo(context, destinationType));
  }
}
