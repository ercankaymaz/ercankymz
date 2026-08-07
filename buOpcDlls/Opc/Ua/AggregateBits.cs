// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AggregateBits
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum AggregateBits
{
  Raw = 0,
  Calculated = 1,
  Interpolated = 2,
  DataSourceMask = Interpolated | Calculated, // 0x00000003
  Partial = 4,
  ExtraData = 8,
  MultipleValues = 16, // 0x00000010
}
