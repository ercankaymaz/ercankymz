// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.VisibleStringEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Formats.Asn1;

internal sealed class VisibleStringEncoding : RestrictedAsciiStringEncoding
{
  internal VisibleStringEncoding()
    : base((byte) 32 /*0x20*/, (byte) 126)
  {
  }
}
