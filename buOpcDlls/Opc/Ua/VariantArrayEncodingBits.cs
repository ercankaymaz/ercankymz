// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VariantArrayEncodingBits
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Opc.Ua;

[Flags]
internal enum VariantArrayEncodingBits
{
  Array = 128, // 0x00000080
  ArrayDimensions = 64, // 0x00000040
  TypeMask = 63, // 0x0000003F
}
