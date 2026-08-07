// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Utilities.JsonTokenUtils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Newtonsoft.Json.Utilities;

internal static class JsonTokenUtils
{
  internal static bool IsEndToken(JsonToken token)
  {
    switch (token)
    {
      case JsonToken.EndObject:
      case JsonToken.EndArray:
      case JsonToken.EndConstructor:
        return true;
      default:
        return false;
    }
  }

  internal static bool IsStartToken(JsonToken token)
  {
    switch (token)
    {
      case JsonToken.StartObject:
      case JsonToken.StartArray:
      case JsonToken.StartConstructor:
        return true;
      default:
        return false;
    }
  }

  internal static bool IsPrimitiveToken(JsonToken token)
  {
    switch (token)
    {
      case JsonToken.Integer:
      case JsonToken.Float:
      case JsonToken.String:
      case JsonToken.Boolean:
      case JsonToken.Null:
      case JsonToken.Undefined:
      case JsonToken.Date:
      case JsonToken.Bytes:
        return true;
      default:
        return false;
    }
  }
}
