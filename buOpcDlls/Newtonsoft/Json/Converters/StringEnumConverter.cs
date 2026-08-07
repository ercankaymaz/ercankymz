// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.StringEnumConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
public class StringEnumConverter : JsonConverter
{
  [Obsolete("StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.")]
  public bool CamelCaseText
  {
    get => this.NamingStrategy is CamelCaseNamingStrategy;
    set
    {
      if (value)
      {
        if (this.NamingStrategy is CamelCaseNamingStrategy)
          return;
        this.NamingStrategy = (NamingStrategy) new CamelCaseNamingStrategy();
      }
      else
      {
        if (!(this.NamingStrategy is CamelCaseNamingStrategy))
          return;
        this.NamingStrategy = (NamingStrategy) null;
      }
    }
  }

  [field: Nullable(2)]
  [Nullable(2)]
  public NamingStrategy NamingStrategy { [NullableContext(2)] get; [NullableContext(2)] set; }

  public bool AllowIntegerValues { get; set; } = true;

  public StringEnumConverter()
  {
  }

  [Obsolete("StringEnumConverter(bool) is obsolete. Create a converter with StringEnumConverter(NamingStrategy, bool) instead.")]
  public StringEnumConverter(bool camelCaseText)
  {
    if (!camelCaseText)
      return;
    this.NamingStrategy = (NamingStrategy) new CamelCaseNamingStrategy();
  }

  public StringEnumConverter(NamingStrategy namingStrategy, bool allowIntegerValues = true)
  {
    this.NamingStrategy = namingStrategy;
    this.AllowIntegerValues = allowIntegerValues;
  }

  public StringEnumConverter(Type namingStrategyType)
  {
    ValidationUtils.ArgumentNotNull((object) namingStrategyType, nameof (namingStrategyType));
    this.NamingStrategy = JsonTypeReflector.CreateNamingStrategyInstance(namingStrategyType, (object[]) null);
  }

  public StringEnumConverter(Type namingStrategyType, object[] namingStrategyParameters)
  {
    ValidationUtils.ArgumentNotNull((object) namingStrategyType, nameof (namingStrategyType));
    this.NamingStrategy = JsonTypeReflector.CreateNamingStrategyInstance(namingStrategyType, namingStrategyParameters);
  }

  public StringEnumConverter(
    Type namingStrategyType,
    object[] namingStrategyParameters,
    bool allowIntegerValues)
  {
    ValidationUtils.ArgumentNotNull((object) namingStrategyType, nameof (namingStrategyType));
    this.NamingStrategy = JsonTypeReflector.CreateNamingStrategyInstance(namingStrategyType, namingStrategyParameters);
    this.AllowIntegerValues = allowIntegerValues;
  }

  public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    if (value == null)
    {
      writer.WriteNull();
    }
    else
    {
      Enum @enum = (Enum) value;
      string name;
      if (!EnumUtils.TryToString(@enum.GetType(), value, this.NamingStrategy, out name))
      {
        if (!this.AllowIntegerValues)
          throw JsonSerializationException.Create((IJsonLineInfo) null, writer.ContainerPath, "Integer value {0} is not allowed.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) @enum.ToString("D")), (Exception) null);
        writer.WriteValue(value);
      }
      else
        writer.WriteValue(name);
    }
  }

  [return: Nullable(2)]
  public override object ReadJson(
    JsonReader reader,
    Type objectType,
    [Nullable(2)] object existingValue,
    JsonSerializer serializer)
  {
    if (reader.TokenType == JsonToken.Null)
    {
      if (!ReflectionUtils.IsNullableType(objectType))
        throw JsonSerializationException.Create(reader, "Cannot convert null value to {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) objectType));
      return (object) null;
    }
    bool flag;
    Type type = (flag = ReflectionUtils.IsNullableType(objectType)) ? Nullable.GetUnderlyingType(objectType) : objectType;
    try
    {
      if (reader.TokenType == JsonToken.String)
      {
        string str = reader.Value?.ToString();
        return StringUtils.IsNullOrEmpty(str) & flag ? (object) null : EnumUtils.ParseEnum(type, this.NamingStrategy, str, !this.AllowIntegerValues);
      }
      if (reader.TokenType == JsonToken.Integer)
      {
        if (!this.AllowIntegerValues)
          throw JsonSerializationException.Create(reader, "Integer value {0} is not allowed.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, reader.Value));
        return ConvertUtils.ConvertOrCast(reader.Value, CultureInfo.InvariantCulture, type);
      }
    }
    catch (Exception ex)
    {
      throw JsonSerializationException.Create(reader, "Error converting value {0} to type '{1}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) MiscellaneousUtils.ToString(reader.Value), (object) objectType), ex);
    }
    throw JsonSerializationException.Create(reader, "Unexpected token {0} when parsing enum.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
  }

  public override bool CanConvert(Type objectType)
  {
    return (ReflectionUtils.IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType).IsEnum();
  }
}
