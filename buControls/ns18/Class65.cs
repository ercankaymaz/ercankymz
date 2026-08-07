// Decompiled with JetBrains decompiler
// Type: ns18.Class65
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using System;
using System.ComponentModel;
using System.Globalization;

#nullable disable
namespace ns18;

internal sealed class Class65 : ExpandableObjectConverter
{
  virtual object TypeConverter.ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    // ISSUE: explicit non-virtual call
    return !(destinationType == typeof (string)) ? __nonvirtual (((TypeConverter) this).ConvertTo(context, culture, value, destinationType)) : (object) $"{((buControlTrack) value).ValueWidth.ToString()} , {((buControlTrack) value).ValueShow.ToString()}";
  }

  virtual bool TypeConverter.CanConvertTo(ITypeDescriptorContext context, Type destinationType)
  {
    // ISSUE: explicit non-virtual call
    return destinationType == typeof (string) || __nonvirtual (((TypeConverter) this).CanConvertTo(context, destinationType));
  }
}
