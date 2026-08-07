// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataValueEncodingBits
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Opc.Ua;

[Flags]
internal enum DataValueEncodingBits
{
  Value = 1,
  StatusCode = 2,
  SourceTimestamp = 4,
  ServerTimestamp = 8,
  SourcePicoseconds = 16, // 0x00000010
  ServerPicoseconds = 32, // 0x00000020
}
