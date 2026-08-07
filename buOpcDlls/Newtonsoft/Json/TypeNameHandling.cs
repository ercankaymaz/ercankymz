// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.TypeNameHandling
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Newtonsoft.Json;

[Flags]
public enum TypeNameHandling
{
  None = 0,
  Objects = 1,
  Arrays = 2,
  All = Arrays | Objects, // 0x00000003
  Auto = 4,
}
