// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.SubscriptionChangeMask
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Client;

[Flags]
[ComVisible(true)]
public enum SubscriptionChangeMask
{
  None = 0,
  Created = 1,
  Deleted = 2,
  Modified = 4,
  ItemsAdded = 8,
  ItemsRemoved = 16, // 0x00000010
  ItemsCreated = 32, // 0x00000020
  ItemsDeleted = 64, // 0x00000040
  ItemsModified = 128, // 0x00000080
  Transferred = 256, // 0x00000100
}
