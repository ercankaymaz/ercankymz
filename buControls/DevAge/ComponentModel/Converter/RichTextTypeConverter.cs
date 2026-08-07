// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Converter.RichTextTypeConverter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Windows.Forms;
using System;
using System.ComponentModel;
using System.Globalization;

#nullable disable
namespace DevAge.ComponentModel.Converter;

public class RichTextTypeConverter : TypeConverter
{
  public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
  {
    return sourceType == typeof (string) || sourceType == typeof (RichText) || sourceType == typeof (int);
  }

  public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
  {
    return destinationType == typeof (RichText) || destinationType == typeof (string);
  }

  public override object ConvertFrom(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value)
  {
    if ((value == null ? 0 : (value.GetType() == typeof (string) ? 1 : (value.GetType() == typeof (int) ? 1 : 0))) != 0)
      return (object) RichTextConversion.StringToRichText(value.ToString());
    return (value == null ? 0 : (value.GetType() == typeof (RichText) ? 1 : 0)) != 0 ? value : throw new ArgumentException("Not supported type");
  }

  public override object ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    if ((!(destinationType == typeof (string)) || value == null ? 0 : (value.GetType() == typeof (RichText) ? 1 : 0)) != 0)
      return (object) RichTextConversion.RichTextToString(value as RichText);
    if ((!(destinationType == typeof (RichText)) ? 0 : (this.IsValid(value) ? 1 : 0)) != 0)
      return (object) new RichText(value as string);
    if ((!(destinationType == typeof (RichText)) || value == null ? 0 : (value.GetType() == typeof (string) ? 1 : 0)) != 0)
      return (object) RichTextConversion.StringToRichText(value as string);
    return (value == null ? 0 : (destinationType == value.GetType() ? 1 : 0)) != 0 ? value : throw new ArgumentException("Not supported type");
  }

  public override bool IsValid(ITypeDescriptorContext context, object value)
  {
    bool flag;
    if ((value == null ? 0 : (value.GetType() == typeof (string) ? 1 : 0)) != 0)
    {
      try
      {
        this.ConvertFrom(context, CultureInfo.CurrentCulture, value);
        flag = true;
      }
      catch (Exception ex)
      {
        flag = false;
      }
    }
    else
      flag = false;
    return flag;
  }
}
