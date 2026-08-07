// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Validator.ValidatorTypeConverter
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Utils;
using System;
using System.Collections;
using System.ComponentModel;

#nullable disable
namespace DevAge.ComponentModel.Validator;

[ToolboxItem(false)]
public class ValidatorTypeConverter : ValidatorBase
{
  private TypeConverter typeConverter_0;

  public ValidatorTypeConverter() => this.typeConverter_0 = (TypeConverter) null;

  public ValidatorTypeConverter(Type p_Type)
    : base(p_Type)
  {
  }

  public ValidatorTypeConverter(Type p_Type, TypeConverter p_TypeConverter)
    : base(p_Type)
  {
    this.TypeConverter = p_TypeConverter;
  }

  public override bool IsStringConversionSupported()
  {
    return !typeof (string).IsAssignableFrom(this.ValueType) ? (this.typeConverter_0 == null ? this.AllowStringConversion : this.AllowStringConversion && this.typeConverter_0.CanConvertFrom(typeof (string)) && this.typeConverter_0.CanConvertTo(typeof (string))) : this.AllowStringConversion;
  }

  protected override void OnConvertingObjectToValue(ConvertingObjectEventArgs e)
  {
    base.OnConvertingObjectToValue(e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ApplicationException("Invalid conversion");
    if (e.ConvertingStatus == ConvertingStatus.Completed || e.Value == null)
      return;
    if (e.Value is string)
    {
      string str = (string) e.Value;
      if (this.IsNullString(str))
      {
        e.Value = (object) null;
      }
      else
      {
        if (e.DestinationType.IsAssignableFrom(e.Value.GetType()))
          return;
        if (!this.IsStringConversionSupported())
          throw new ApplicationException("String conversion not supported for this type of Validator.");
        e.Value = this.typeConverter_0.ConvertFromString((ITypeDescriptorContext) EmptyTypeDescriptorContext.Empty, this.CultureInfo, str);
      }
    }
    else
    {
      if (e.DestinationType.IsAssignableFrom(e.Value.GetType()) || this.typeConverter_0 == null)
        return;
      if (this.typeConverter_0 is StringConverter)
        e.Value = (object) SourceGridConvert.To<string>(e.Value);
      else
        e.Value = this.typeConverter_0.ConvertFrom((ITypeDescriptorContext) EmptyTypeDescriptorContext.Empty, this.CultureInfo, e.Value);
    }
  }

  protected override void OnConvertingValueToObject(ConvertingObjectEventArgs e)
  {
    base.OnConvertingValueToObject(e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ApplicationException("Invalid conversion");
    if (e.ConvertingStatus == ConvertingStatus.Completed || e.Value == null || e.DestinationType.IsAssignableFrom(e.Value.GetType()))
      return;
    if ((!(e.DestinationType == typeof (string)) ? 0 : (!this.IsStringConversionSupported() ? 1 : 0)) != 0)
      throw new ApplicationException("String conversion not supported for this type of Validator.");
    if (this.typeConverter_0 == null)
      return;
    e.Value = this.typeConverter_0.ConvertTo((ITypeDescriptorContext) EmptyTypeDescriptorContext.Empty, this.CultureInfo, e.Value, e.DestinationType);
  }

  [System.ComponentModel.DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public TypeConverter TypeConverter
  {
    get => this.typeConverter_0;
    set
    {
      if (this.typeConverter_0 == value)
        return;
      this.typeConverter_0 = value;
      this.method_0();
      this.OnChanged(EventArgs.Empty);
    }
  }

  private void method_0()
  {
    this.StandardValues = (ICollection) null;
    this.StandardValuesExclusive = false;
    if (this.typeConverter_0 == null)
      return;
    this.StandardValues = this.typeConverter_0.GetStandardValues();
    if ((this.StandardValues == null ? 0 : (this.StandardValues.Count > 0 ? 1 : 0)) != 0)
      this.StandardValuesExclusive = this.typeConverter_0.GetStandardValuesExclusive();
    else
      this.StandardValuesExclusive = false;
  }

  protected override void OnLoadingValueType()
  {
    base.OnLoadingValueType();
    if (this.ValueType != (Type) null)
      this.TypeConverter = TypeDescriptor.GetConverter(this.ValueType);
    else
      this.TypeConverter = (TypeConverter) null;
  }
}
