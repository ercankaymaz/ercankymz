// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Converter.NumberTypeConverter
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

public class NumberTypeConverter : TypeConverter
{
  private TypeConverter typeConverter_0;
  private Type type_0;
  private string string_0 = "G";
  private NumberStyles numberStyles_0 = NumberStyles.Number;

  public NumberTypeConverter(Type p_BaseType) => this.BaseType = p_BaseType;

  public NumberTypeConverter(Type p_BaseType, string p_Format)
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
      this.typeConverter_0 = (!(value != typeof (double)) || !(value != typeof (float)) || !(value != typeof (Decimal)) ? 0 : (value != typeof (int) ? 1 : 0)) == 0 ? TypeDescriptor.GetConverter(value) : throw new ArgumentException("Type not supported", nameof (BaseType));
      this.type_0 = value;
    }
  }

  public string Format
  {
    get => this.string_0;
    set => this.string_0 = value;
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
        obj = (object) NumberTypeConverter.StringToDouble((string) value, this.NumberStyles, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat);
      else if (this.BaseType == typeof (Decimal))
        obj = (object) NumberTypeConverter.StringToDecimal((string) value, this.NumberStyles, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat);
      else if (this.BaseType == typeof (float))
      {
        obj = (object) NumberTypeConverter.StringToFloat((string) value, this.NumberStyles, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat);
      }
      else
      {
        if (!(this.BaseType == typeof (int)))
          throw new ArgumentException("Not supported type");
        obj = (object) NumberTypeConverter.StringToInt((string) value, this.NumberStyles, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat);
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
    return (!(destinationType == typeof (string)) ? 0 : (value != null ? 1 : 0)) == 0 ? this.typeConverter_0.ConvertTo(context, culture, value, destinationType) : (!(this.BaseType == typeof (double)) ? (!(this.BaseType == typeof (Decimal)) ? (!(this.BaseType == typeof (float)) ? (!(this.BaseType == typeof (int)) ? this.typeConverter_0.ConvertTo(context, culture, value, destinationType) : (object) NumberTypeConverter.IntToString((int) value, this.Format, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat)) : (object) NumberTypeConverter.FloatToString((float) value, this.Format, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat)) : (object) NumberTypeConverter.DecimalToString((Decimal) value, this.Format, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat)) : (object) NumberTypeConverter.DoubleToString((double) value, this.Format, (IFormatProvider) Class39.smethod_478(this, culture).NumberFormat));
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

  public static double StringToDouble(
    string p_strVal,
    NumberStyles style,
    IFormatProvider provider)
  {
    return double.Parse(p_strVal, style, provider);
  }

  public static float StringToFloat(string p_strVal, NumberStyles style, IFormatProvider provider)
  {
    return float.Parse(p_strVal, style, provider);
  }

  public static Decimal StringToDecimal(
    string p_strVal,
    NumberStyles style,
    IFormatProvider provider)
  {
    return Decimal.Parse(p_strVal, style, provider);
  }

  public static int StringToInt(string p_strVal, NumberStyles style, IFormatProvider provider)
  {
    return int.Parse(p_strVal, style, provider);
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

  public static string IntToString(int p_Val, string format, IFormatProvider provider)
  {
    return p_Val.ToString(format, provider);
  }
}
