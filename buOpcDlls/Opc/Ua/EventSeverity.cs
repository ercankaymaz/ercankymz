// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EventSeverity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public enum EventSeverity
{
  Min = 1,
  Low = 100, // 0x00000064
  MediumLow = 300, // 0x0000012C
  Medium = 500, // 0x000001F4
  MediumHigh = 700, // 0x000002BC
  High = 900, // 0x00000384
  Max = 1000, // 0x000003E8
}
