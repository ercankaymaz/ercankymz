// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.DefaultValueHandling
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Newtonsoft.Json;

[Flags]
public enum DefaultValueHandling
{
  Include = 0,
  Ignore = 1,
  Populate = 2,
  IgnoreAndPopulate = Populate | Ignore, // 0x00000003
}
