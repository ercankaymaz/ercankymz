// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.Exportable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class Exportable : SignatureSubpacket
{
  private static byte[] BooleanToByteArray(bool val)
  {
    return new byte[1]{ Convert.ToByte(val) };
  }

  public Exportable(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.Exportable, critical, isLongLength, data)
  {
  }

  public Exportable(bool critical, bool isExportable)
    : base(SignatureSubpacketTag.Exportable, critical, false, Exportable.BooleanToByteArray(isExportable))
  {
  }

  public bool IsExportable() => this.data[0] > (byte) 0;
}
