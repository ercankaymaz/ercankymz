// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonConverter`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json;

[NullableContext(1)]
[Nullable(0)]
public abstract class JsonConverter<[Nullable(2)] T> : JsonConverter
{
  public sealed override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    if ((value != null ? (value is T ? 1 : 0) : (ReflectionUtils.IsNullable(typeof (T)) ? 1 : 0)) == 0)
      throw new JsonSerializationException("Converter cannot write specified value to JSON. {0} is required.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (T)));
    this.WriteJson(writer, (T) value, serializer);
  }

  public abstract void WriteJson(JsonWriter writer, [Nullable(2)] T value, JsonSerializer serializer);

  [return: Nullable(2)]
  public sealed override object ReadJson(
    JsonReader reader,
    Type objectType,
    [Nullable(2)] object existingValue,
    JsonSerializer serializer)
  {
    bool flag;
    if (!(flag = existingValue == null) && !(existingValue is T))
      throw new JsonSerializationException("Converter cannot read JSON with the specified existing value. {0} is required.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) typeof (T)));
    return (object) this.ReadJson(reader, objectType, flag ? default (T) : (T) existingValue, !flag, serializer);
  }

  [return: Nullable(2)]
  public abstract T ReadJson(
    JsonReader reader,
    Type objectType,
    [Nullable(2)] T existingValue,
    bool hasExistingValue,
    JsonSerializer serializer);

  public sealed override bool CanConvert(Type objectType)
  {
    return typeof (T).IsAssignableFrom(objectType);
  }
}
