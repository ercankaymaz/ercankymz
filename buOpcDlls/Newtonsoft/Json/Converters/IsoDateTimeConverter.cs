// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.IsoDateTimeConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
public class IsoDateTimeConverter : DateTimeConverterBase
{
  private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK";
  private DateTimeStyles _dateTimeStyles = DateTimeStyles.RoundtripKind;
  [Nullable(2)]
  private string _dateTimeFormat;
  [Nullable(2)]
  private CultureInfo _culture;

  public DateTimeStyles DateTimeStyles
  {
    get => this._dateTimeStyles;
    set => this._dateTimeStyles = value;
  }

  [Nullable(2)]
  public string DateTimeFormat
  {
    [NullableContext(2)] get => this._dateTimeFormat ?? string.Empty;
    [NullableContext(2)] set
    {
      this._dateTimeFormat = StringUtils.IsNullOrEmpty(value) ? (string) null : value;
    }
  }

  public CultureInfo Culture
  {
    get => this._culture ?? CultureInfo.CurrentCulture;
    set => this._culture = value;
  }

  public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    string str;
    switch (value)
    {
      case DateTime universalTime1:
        if ((this._dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal || (this._dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
          universalTime1 = universalTime1.ToUniversalTime();
        str = universalTime1.ToString(this._dateTimeFormat ?? "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK", (IFormatProvider) this.Culture);
        break;
      case DateTimeOffset universalTime2:
        if ((this._dateTimeStyles & DateTimeStyles.AdjustToUniversal) == DateTimeStyles.AdjustToUniversal || (this._dateTimeStyles & DateTimeStyles.AssumeUniversal) == DateTimeStyles.AssumeUniversal)
          universalTime2 = universalTime2.ToUniversalTime();
        str = universalTime2.ToString(this._dateTimeFormat ?? "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK", (IFormatProvider) this.Culture);
        break;
      default:
        throw new JsonSerializationException("Unexpected value when converting date. Expected DateTime or DateTimeOffset, got {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) ReflectionUtils.GetObjectType(value)));
    }
    writer.WriteValue(str);
  }

  [return: Nullable(2)]
  public override object ReadJson(
    JsonReader reader,
    Type objectType,
    [Nullable(2)] object existingValue,
    JsonSerializer serializer)
  {
    bool flag = ReflectionUtils.IsNullableType(objectType);
    if (reader.TokenType == JsonToken.Null)
    {
      if (!flag)
        throw JsonSerializationException.Create(reader, "Cannot convert null value to {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) objectType));
      return (object) null;
    }
    Type type = flag ? Nullable.GetUnderlyingType(objectType) : objectType;
    if (reader.TokenType == JsonToken.Date)
      return type == typeof (DateTimeOffset) ? (!(reader.Value is DateTimeOffset) ? (object) new DateTimeOffset((DateTime) reader.Value) : reader.Value) : (reader.Value is DateTimeOffset dateTimeOffset ? (object) dateTimeOffset.DateTime : reader.Value);
    if (reader.TokenType != JsonToken.String)
      throw JsonSerializationException.Create(reader, "Unexpected token parsing date. Expected String, got {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    string str = reader.Value?.ToString();
    if (StringUtils.IsNullOrEmpty(str) & flag)
      return (object) null;
    return type == typeof (DateTimeOffset) ? (!StringUtils.IsNullOrEmpty(this._dateTimeFormat) ? (object) DateTimeOffset.ParseExact(str, this._dateTimeFormat, (IFormatProvider) this.Culture, this._dateTimeStyles) : (object) DateTimeOffset.Parse(str, (IFormatProvider) this.Culture, this._dateTimeStyles)) : (!StringUtils.IsNullOrEmpty(this._dateTimeFormat) ? (object) DateTime.ParseExact(str, this._dateTimeFormat, (IFormatProvider) this.Culture, this._dateTimeStyles) : (object) DateTime.Parse(str, (IFormatProvider) this.Culture, this._dateTimeStyles));
  }
}
