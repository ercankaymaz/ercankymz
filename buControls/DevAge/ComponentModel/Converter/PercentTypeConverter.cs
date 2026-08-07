// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Converter.PercentTypeConverter
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

public class PercentTypeConverter : TypeConverter
{
  private TypeConverter typeConverter_0;
  private Type type_0;
  private string string_0 = "P";
  private bool bool_0 = true;
  private NumberStyles numberStyles_0 = NumberStyles.Number;

  public PercentTypeConverter(Type p_BaseType) => this.BaseType = p_BaseType;

  public PercentTypeConverter(Type p_BaseType, string p_Format)
    : this(p_BaseType)
  {
    this.Format = p_Format;
  }

  public TypeConverter BaseTypeConverter
  {
    get => this.typeConverter_0;
    set => this.typeConverter_0 = value;
  }

  public Type BaseType
  {
    get => this.type_0;
    set
    {
      this.typeConverter_0 = (!(value != typeof (double)) || !(value != typeof (float)) ? 0 : (value != typeof (Decimal) ? 1 : 0)) == 0 ? TypeDescriptor.GetConverter(value) : throw new ArgumentException("Type not supported", nameof (BaseType));
      this.type_0 = value;
    }
  }

  public string Format
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public bool ConsiderAllStringAsPercent
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public NumberStyles NumberStyles
  {
    get => this.numberStyles_0;
    set => this.numberStyles_0 = value;
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
    object obj;
    if ((value == null ? 0 : (value.GetType() == typeof (string) ? 1 : 0)) != 0)
    {
      if (this.BaseType == typeof (double))
        obj = (object) PercentTypeConverter.StringToDouble((string) value, this.NumberStyles, (IFormatProvider) Class39.smethod_22(culture, this).NumberFormat, this.ConsiderAllStringAsPercent);
      else if (this.BaseType == typeof (Decimal))
      {
        obj = (object) PercentTypeConverter.StringToDecimal((string) value, this.NumberStyles, (IFormatProvider) Class39.smethod_22(culture, this).NumberFormat, this.ConsiderAllStringAsPercent);
      }
      else
      {
        if (!(this.BaseType == typeof (float)))
          throw new ArgumentException("Not supported type");
        obj = (object) PercentTypeConverter.StringToFloat((string) value, this.NumberStyles, (IFormatProvider) Class39.smethod_22(culture, this).NumberFormat, this.ConsiderAllStringAsPercent);
      }
    }
    else
      obj = this.typeConverter_0.ConvertFrom(context, culture, value);
    return obj;
  }

  public override object ConvertTo(
    ITypeDescriptorContext context,
    CultureInfo culture,
    object value,
    Type destinationType)
  {
    return (!(destinationType == typeof (string)) ? 0 : (value != null ? 1 : 0)) == 0 ? this.typeConverter_0.ConvertTo(context, culture, value, destinationType) : (!(this.BaseType == typeof (double)) ? (!(this.BaseType == typeof (Decimal)) ? (!(this.BaseType == typeof (float)) ? this.typeConverter_0.ConvertTo(context, culture, value, destinationType) : (object) PercentTypeConverter.FloatToString((float) value, this.Format, (IFormatProvider) Class39.smethod_22(culture, this).NumberFormat)) : (object) PercentTypeConverter.DecimalToString((Decimal) value, this.Format, (IFormatProvider) Class39.smethod_22(culture, this).NumberFormat)) : (object) PercentTypeConverter.DoubleToString((double) value, this.Format, (IFormatProvider) Class39.smethod_22(culture, this).NumberFormat));
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

  public static bool IsPercentString(string p_strVal, IFormatProvider provider)
  {
    NumberFormatInfo numberFormatInfo = provider != null ? (NumberFormatInfo) provider.GetFormat(typeof (NumberFormatInfo)) : CultureInfo.CurrentCulture.NumberFormat;
    return p_strVal.IndexOf(numberFormatInfo.PercentSymbol) != -1;
  }

  public static double StringToDouble(
    string p_strVal,
    NumberStyles style,
    IFormatProvider provider,
    bool p_ConsiderAllStringAsPercent)
  {
    return !PercentTypeConverter.IsPercentString(p_strVal, provider) ? (!p_ConsiderAllStringAsPercent ? double.Parse(p_strVal, style, provider) : double.Parse(p_strVal, style, provider) / 100.0) : double.Parse(p_strVal.Replace("%", ""), style, provider) / 100.0;
  }

  public static float StringToFloat(
    string p_strVal,
    NumberStyles style,
    IFormatProvider provider,
    bool p_ConsiderAllStringAsPercent)
  {
    return !PercentTypeConverter.IsPercentString(p_strVal, provider) ? (!p_ConsiderAllStringAsPercent ? float.Parse(p_strVal, style, provider) : float.Parse(p_strVal, style, provider) / 100f) : float.Parse(p_strVal.Replace("%", ""), style, provider) / 100f;
  }

  public static Decimal StringToDecimal(
    string p_strVal,
    NumberStyles style,
    IFormatProvider provider,
    bool p_ConsiderAllStringAsPercent)
  {
    return !PercentTypeConverter.IsPercentString(p_strVal, provider) ? (!p_ConsiderAllStringAsPercent ? Decimal.Parse(p_strVal, style, provider) : Decimal.Parse(p_strVal, style, provider) / 100.0M) : Decimal.Parse(p_strVal.Replace("%", ""), style, provider) / 100.0M;
  }

  public static string DoubleToString(double p_Val, string format, IFormatProvider provider)
  {
    return p_Val.ToString(format, provider);
  }

  public static string FloatToString(float p_Val, string format, IFormatProvider provider)
  {
    return p_Val.ToString(format, provider);
  }

  public static string DecimalToString(Decimal p_Val, string format, IFormatProvider provider)
  {
    return p_Val.ToString(format, provider);
  }
}
