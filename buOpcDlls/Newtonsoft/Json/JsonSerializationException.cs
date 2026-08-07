// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonSerializationException
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
public class JsonSerializationException : JsonException
{
  public int LineNumber { get; }

  public int LinePosition { get; }

  [field: Nullable(2)]
  [Nullable(2)]
  public string Path { [NullableContext(2)] get; }

  public JsonSerializationException()
  {
  }

  public JsonSerializationException(string message)
    : base(message)
  {
  }

  public JsonSerializationException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  public JsonSerializationException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }

  public JsonSerializationException(
    string message,
    string path,
    int lineNumber,
    int linePosition,
    [Nullable(2)] Exception innerException)
    : base(message, innerException)
  {
    this.Path = path;
    this.LineNumber = lineNumber;
    this.LinePosition = linePosition;
  }

  internal static JsonSerializationException Create(JsonReader reader, string message)
  {
    return JsonSerializationException.Create(reader, message, (Exception) null);
  }

  internal static JsonSerializationException Create(
    JsonReader reader,
    string message,
    [Nullable(2)] Exception ex)
  {
    return JsonSerializationException.Create(reader as IJsonLineInfo, reader.Path, message, ex);
  }

  internal static JsonSerializationException Create(
    [Nullable(2)] IJsonLineInfo lineInfo,
    string path,
    string message,
    [Nullable(2)] Exception ex)
  {
    message = JsonPosition.FormatMessage(lineInfo, path, message);
    int lineNumber;
    int linePosition;
    if (lineInfo != null && lineInfo.HasLineInfo())
    {
      lineNumber = lineInfo.LineNumber;
      linePosition = lineInfo.LinePosition;
    }
    else
    {
      lineNumber = 0;
      linePosition = 0;
    }
    return new JsonSerializationException(message, path, lineNumber, linePosition, ex);
  }
}
