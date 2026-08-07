// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonReaderException
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
public class JsonReaderException : JsonException
{
  public int LineNumber { get; }

  public int LinePosition { get; }

  [field: Nullable(2)]
  [Nullable(2)]
  public string Path { [NullableContext(2)] get; }

  public JsonReaderException()
  {
  }

  public JsonReaderException(string message)
    : base(message)
  {
  }

  public JsonReaderException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  public JsonReaderException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }

  public JsonReaderException(
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

  internal static JsonReaderException Create(JsonReader reader, string message)
  {
    return JsonReaderException.Create(reader, message, (Exception) null);
  }

  internal static JsonReaderException Create(JsonReader reader, string message, [Nullable(2)] Exception ex)
  {
    return JsonReaderException.Create(reader as IJsonLineInfo, reader.Path, message, ex);
  }

  internal static JsonReaderException Create(
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
    return new JsonReaderException(message, path, lineNumber, linePosition, ex);
  }
}
