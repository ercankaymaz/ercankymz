// Decompiled with JetBrains decompiler
// Type: ns11.Class56
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buControls.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

#nullable disable
namespace ns11;

internal sealed class Class56 : ExpandableObjectConverter
{
  virtual object TypeConverter.ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    string str1 = ((buControlInterpolatedGradient) value).FirstColor.ToString();
    KnownColor knownColor;
    if (((buControlInterpolatedGradient) value).FirstColor.IsKnownColor)
    {
      knownColor = ((buControlInterpolatedGradient) value).FirstColor.ToKnownColor();
      str1 = knownColor.ToString();
    }
    string str2 = ((buControlInterpolatedGradient) value).SecondColor.ToString();
    if (((buControlInterpolatedGradient) value).SecondColor.IsKnownColor)
    {
      knownColor = ((buControlInterpolatedGradient) value).SecondColor.ToKnownColor();
      str2 = knownColor.ToString();
    }
    string str3 = ((buControlInterpolatedGradient) value).ThirdColor.ToString();
    if (((buControlInterpolatedGradient) value).ThirdColor.IsKnownColor)
    {
      knownColor = ((buControlInterpolatedGradient) value).ThirdColor.ToKnownColor();
      str3 = knownColor.ToString();
    }
    string str4 = ((buControlInterpolatedGradient) value).FourthColor.ToString();
    if (((buControlInterpolatedGradient) value).FourthColor.IsKnownColor)
    {
      knownColor = ((buControlInterpolatedGradient) value).FourthColor.ToKnownColor();
      str4 = knownColor.ToString();
    }
    object obj;
    if (destinationType == typeof (string))
    {
      obj = (object) $"{str1} , {str2} ,  , {str3} , {str4} , {((buControlInterpolatedGradient) value).ColorCount.ToString()}";
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
