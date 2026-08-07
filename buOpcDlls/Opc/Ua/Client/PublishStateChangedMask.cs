// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.PublishStateChangedMask
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[Flags]
[ComVisible(true)]
public enum PublishStateChangedMask
{
  None = 0,
  Stopped = 1,
  Recovered = 2,
  KeepAlive = 4,
  Republish = 8,
  Transferred = 16, // 0x00000010
  Timeout = 32, // 0x00000020
}
