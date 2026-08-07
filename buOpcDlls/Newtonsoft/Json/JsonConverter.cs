// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json;

[NullableContext(1)]
[Nullable(0)]
public abstract class JsonConverter
{
  public abstract void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer);

  [return: Nullable(2)]
  public abstract object ReadJson(
    JsonReader reader,
    Type objectType,
    [Nullable(2)] object existingValue,
    JsonSerializer serializer);

  public abstract bool CanConvert(Type objectType);

  public virtual bool CanRead => true;

  public virtual bool CanWrite => true;
}
