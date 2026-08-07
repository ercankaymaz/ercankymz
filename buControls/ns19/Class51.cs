// Decompiled with JetBrains decompiler
// Type: ns19.Class51
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using System;
using System.ComponentModel;
using System.Globalization;

#nullable disable
namespace ns19;

internal sealed class Class51 : ExpandableObjectConverter
{
  virtual object TypeConverter.ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    string str = ((buControlSeparator) value).Color.ToString();
    if (((buControlSeparator) value).Color.IsKnownColor)
      str = ((buControlSeparator) value).Color.ToKnownColor().ToString();
    object obj;
    if (destinationType == typeof (string))
    {
      obj = (object) $"{((buControlSeparator) value).Visible.ToString()} , {str} , {((buControlSeparator) value).Thickness.ToString()}";
    }
    else
    {
      // ISSUE: explicit non-virtual call
      obj = __nonvirtual (((TypeConverter) this).ConvertTo(context, culture, value, destinationType));
    }
    return obj;
  }

  virtual bool TypeConverter.CanConvertTo(ITypeDescriptorContext context, Type destinationType)
  {
    // ISSUE: explicit non-virtual call
    return destinationType == typeof (string) || __nonvirtual (((TypeConverter) this).CanConvertTo(context, destinationType));
  }
}
