// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonException
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
public class JsonException : Exception
{
  public JsonException()
  {
  }

  public JsonException(string message)
    : base(message)
  {
  }

  public JsonException(string message, [Nullable(2)] Exception innerException)
    : base(message, innerException)
  {
  }

  public JsonException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }

  internal static JsonException Create(IJsonLineInfo lineInfo, string path, string message)
  {
    message = JsonPosition.FormatMessage(lineInfo, path, message);
    return new JsonException(message);
  }
}
