// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonWriterException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Runtime.Serialization;

#nullable disable
namespace Newtonsoft.Json;

[NullableContext(1)]
[Nullable(0)]
[Serializable]
public class JsonWriterException : JsonException
{
  [field: Nullable(2)]
  [Nullable(2)]
  public string Path { [NullableContext(2)] get; }

  public JsonWriterException()
  {
  }

  public JsonWriterException(string message)
    : base(message)
  {
  }

  public JsonWriterException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  public JsonWriterException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }

  public JsonWriterException(string message, string path, [Nullable(2)] Exception innerException)
    : base(message, innerException)
  {
    this.Path = path;
  }

  internal static JsonWriterException Create(JsonWriter writer, string message, [Nullable(2)] Exception ex)
  {
    return JsonWriterException.Create(writer.ContainerPath, message, ex);
  }

  internal static JsonWriterException Create(string path, string message, [Nullable(2)] Exception ex)
  {
    message = JsonPosition.FormatMessage((IJsonLineInfo) null, path, message);
    return new JsonWriterException(message, path, ex);
  }
}
