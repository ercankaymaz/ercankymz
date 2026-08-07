// Decompiled with JetBrains decompiler
// Type: ns3.Class54
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

#nullable disable
namespace ns3;

internal sealed class Class54 : ExpandableObjectConverter
{
  virtual object TypeConverter.ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    string str1 = ((buControlLineerGradient) value).FirstColor.ToString();
    KnownColor knownColor;
    if (((buControlLineerGradient) value).FirstColor.IsKnownColor)
    {
      knownColor = ((buControlLineerGradient) value).FirstColor.ToKnownColor();
      str1 = knownColor.ToString();
    }
    string str2 = ((buControlLineerGradient) value).SecondColor.ToString();
    if (((buControlLineerGradient) value).SecondColor.IsKnownColor)
    {
      knownColor = ((buControlLineerGradient) value).SecondColor.ToKnownColor();
      str2 = knownColor.ToString();
    }
    object obj;
    if (destinationType == typeof (string))
    {
      obj = (object) $"{str1} , {str2} , {((buControlLineerGradient) value).GradientAngle.ToString()}";
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
