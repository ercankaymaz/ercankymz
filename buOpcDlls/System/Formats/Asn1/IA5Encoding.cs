// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.IA5Encoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Formats.Asn1;

internal sealed class IA5Encoding : RestrictedAsciiStringEncoding
{
  internal IA5Encoding()
    : base((byte) 0, (byte) 127 /*0x7F*/)
  {
  }
}
