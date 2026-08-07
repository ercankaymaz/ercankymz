// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Schema.JsonSchemaType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Newtonsoft.Json.Schema;

[Flags]
[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
public enum JsonSchemaType
{
  None = 0,
  String = 1,
  Float = 2,
  Integer = 4,
  Boolean = 8,
  Object = 16, // 0x00000010
  Array = 32, // 0x00000020
  Null = 64, // 0x00000040
  Any = Null | Array | Object | Boolean | Integer | Float | String, // 0x0000007F
}
