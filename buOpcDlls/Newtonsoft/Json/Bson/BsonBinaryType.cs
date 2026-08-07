// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Bson.BsonBinaryType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Newtonsoft.Json.Bson;

internal enum BsonBinaryType : byte
{
  Binary = 0,
  Function = 1,
  [Obsolete("This type has been deprecated in the BSON specification. Use Binary instead.")] BinaryOld = 2,
  [Obsolete("This type has been deprecated in the BSON specification. Use Uuid instead.")] UuidOld = 3,
  Uuid = 4,
  Md5 = 5,
  UserDefined = 128, // 0x80
}
