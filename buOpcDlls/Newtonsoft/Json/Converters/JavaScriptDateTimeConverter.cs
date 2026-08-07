// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.JavaScriptDateTimeConverter
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
public class JavaScriptDateTimeConverter : DateTimeConverterBase
{
  public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    long javaScriptTicks;
    switch (value)
    {
      case DateTime dateTime:
        javaScriptTicks = DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTime.ToUniversalTime());
        break;
      case DateTimeOffset dateTimeOffset:
        javaScriptTicks = DateTimeUtils.ConvertDateTimeToJavaScriptTicks(dateTimeOffset.ToUniversalTime().UtcDateTime);
        break;
      default:
        throw new JsonSerializationException("Expected date object value.");
    }
    writer.WriteStartConstructor("Date");
    writer.WriteValue(javaScriptTicks);
    writer.WriteEndConstructor();
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
      if (!ReflectionUtils.IsNullable(objectType))
        throw JsonSerializationException.Create(reader, "Cannot convert null value to {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) objectType));
      return (object) null;
    }
    if (reader.TokenType != JsonToken.StartConstructor || !string.Equals(reader.Value?.ToString(), "Date", StringComparison.Ordinal))
      throw JsonSerializationException.Create(reader, "Unexpected token or value when parsing date. Token: {0}, Value: {1}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType, reader.Value));
    DateTime dateTime;
    string errorMessage;
    if (!JavaScriptUtils.TryGetDateFromConstructorJson(reader, out dateTime, out errorMessage))
      throw JsonSerializationException.Create(reader, errorMessage);
    return (ReflectionUtils.IsNullableType(objectType) ? Nullable.GetUnderlyingType(objectType) : objectType) == typeof (DateTimeOffset) ? (object) new DateTimeOffset(dateTime) : (object) dateTime;
  }
}
