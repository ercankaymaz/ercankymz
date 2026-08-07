// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Schema.JsonSchemaException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Newtonsoft.Json.Schema;

[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
[Serializable]
public class JsonSchemaException : JsonException
{
  public int LineNumber { get; }

  public int LinePosition { get; }

  public string Path { get; }

  public JsonSchemaException()
  {
  }

  public JsonSchemaException(string message)
    : base(message)
  {
  }

  public JsonSchemaException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  public JsonSchemaException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }

  internal JsonSchemaException(
    string message,
    Exception innerException,
    string path,
    int lineNumber,
    int linePosition)
    : base(message, innerException)
  {
    this.Path = path;
    this.LineNumber = lineNumber;
    this.LinePosition = linePosition;
  }
}
