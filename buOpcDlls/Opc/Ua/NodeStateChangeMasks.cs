// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeStateChangeMasks
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum NodeStateChangeMasks
{
  None = 0,
  Children = 1,
  References = 2,
  Value = 4,
  NonValue = 8,
  Deleted = 16, // 0x00000010
}
