// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.TagClass
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace System.Formats.Asn1;

[ComVisible(true)]
public enum TagClass
{
  Universal = 0,
  Application = 64, // 0x00000040
  ContextSpecific = 128, // 0x00000080
  Private = 192, // 0x000000C0
}
