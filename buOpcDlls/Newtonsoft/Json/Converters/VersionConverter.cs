// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.VersionConverter
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
public class VersionConverter : JsonConverter
{
  public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    if (value == null)
    {
      writer.WriteNull();
    }
    else
    {
      if ((object) (value as Version) == null)
        throw new JsonSerializationException("Expected Version object value");
      writer.WriteValue(value.ToString());
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
      return (object) null;
    if (reader.TokenType != JsonToken.String)
      throw JsonSerializationException.Create(reader, "Unexpected token or value when parsing version. Token: {0}, Value: {1}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType, reader.Value));
    try
    {
      return (object) new Version((string) reader.Value);
    }
    catch (Exception ex)
    {
      throw JsonSerializationException.Create(reader, "Error parsing version string: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, reader.Value), ex);
    }
  }

  public override bool CanConvert(Type objectType) => objectType == typeof (Version);
}
