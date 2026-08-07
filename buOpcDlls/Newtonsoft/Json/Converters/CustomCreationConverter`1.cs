// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.CustomCreationConverter`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
public abstract class CustomCreationConverter<[Nullable(2)] T> : JsonConverter
{
  public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    throw new NotSupportedException("CustomCreationConverter should only be used while deserializing.");
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
    T target = this.Create(objectType);
    if ((object) target == null)
      throw new JsonSerializationException("No object created.");
    serializer.Populate(reader, (object) target);
    return (object) target;
  }

  public abstract T Create(Type objectType);

  public override bool CanConvert(Type objectType) => typeof (T).IsAssignableFrom(objectType);

  public override bool CanWrite => false;
}
