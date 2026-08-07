// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransportChannelFeatures
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum TransportChannelFeatures
{
  None = 0,
  Open = 1,
  BeginOpen = 2,
  Reconnect = 4,
  BeginReconnect = 8,
  BeginClose = 16, // 0x00000010
  BeginSendRequest = 32, // 0x00000020
  ReverseConnect = 64, // 0x00000040
  SendRequestAsync = 128, // 0x00000080
}
