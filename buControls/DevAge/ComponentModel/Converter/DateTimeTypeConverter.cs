// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Converter.DateTimeTypeConverter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

#nullable disable
namespace DevAge.ComponentModel.Converter;

public class DateTimeTypeConverter : TypeConverter
{
  private TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof (DateTime));
  private DateTimeStyles p_DateTimeStyles = DateTimeStyles.AllowWhiteSpaces;
  private string p_ToStringFormat = "G";
  private string[] p_ParseFormats = (string[]) null;

  public DateTimeTypeConverter()
  {
  }

  public DateTimeTypeConverter(string p_ToStringFormat) => this.p_ToStringFormat = p_ToStringFormat;

  public DateTimeTypeConverter(string p_ToStringFormat, string[] p_ParseFormats)
  {
    this.p_ParseFormats = p_ParseFormats;
    this.p_ToStringFormat = p_ToStringFormat;
  }

  public DateTimeTypeConverter(
    string p_ToStringFormat,
    string[] p_ParseFormats,
    DateTimeStyles p_DateTimeStyles)
  {
    this.p_ParseFormats = p_ParseFormats;
    this.p_ToStringFormat = p_ToStringFormat;
    this.p_DateTimeStyles = p_DateTimeStyles;
  }

  public TypeConverter BaseTypeConverter
  {
    get => this.typeConverter_0;
    set => this.typeConverter_0 = value;
  }

  public DateTimeStyles DateTimeStyles
  {
    get => this.p_DateTimeStyles;
    set => this.p_DateTimeStyles = value;
  }

  public string Format
  {
    get => this.p_ToStringFormat;
    set => this.p_ToStringFormat = value;
  }

  public string[] ParseFormats
  {
    get => this.p_ParseFormats;
    set => this.p_ParseFormats = value;
  }

  public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
  {
    return sourceType == typeof (string) || this.typeConverter_0.CanConvertFrom(context, sourceType);
  }

  public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
  {
    return destinationType == typeof (string) || this.typeConverter_0.CanConvertTo(context, destinationType);
  }

  public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
  {
    return this.typeConverter_0.CreateInstance(context, propertyValues);
  }

  public override object ConvertFrom(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value)
  {
    return (value == null ? 0 : (value.GetType() == typeof (string) ? 1 : 0)) == 0 ? this.typeConverter_0.ConvertFrom(context, culture, value) : (this.p_ParseFormats == null ? (object) DateTime.Parse((string) value, (IFormatProvider) Class39.smethod_661(this, culture).DateTimeFormat, this.p_DateTimeStyles) : (object) DateTime.ParseExact((string) value, this.p_ParseFormats, (IFormatProvider) Class39.smethod_661(this, culture).DateTimeFormat, this.p_DateTimeStyles));
  }

  public override object ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    return (!(destinationType == typeof (string)) ? 0 : (value != null ? 1 : 0)) == 0 ? this.typeConverter_0.ConvertTo(context, culture, value, destinationType) : (object) ((DateTime) value).ToString(this.p_ToStringFormat, (IFormatProvider) Class39.smethod_661(this, culture).DateTimeFormat);
  }

  public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
  {
    return this.typeConverter_0.GetCreateInstanceSupported(context);
  }

  public override PropertyDescriptorCollection GetProperties(
    ITypeDescriptorContext context,
    object value,
    Attribute[] attributes)
  {
    return this.typeConverter_0.GetProperties(context, value, attributes);
  }

  public override bool GetPropertiesSupported(ITypeDescriptorContext context)
  {
    return this.typeConverter_0.GetPropertiesSupported(context);
  }

  public override TypeConverter.StandardValuesCollection GetStandardValues(
    ITypeDescriptorContext context)
  {
    return this.typeConverter_0.GetStandardValues(context);
  }

  public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
  {
    return this.typeConverter_0.GetStandardValuesExclusive(context);
  }

  public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
  {
    return this.typeConverter_0.GetStandardValuesSupported(context);
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
      flag = this.typeConverter_0.IsValid(context, value);
    return flag;
  }
}
