// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HeartbeatExtension
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class HeartbeatExtension
{
  private readonly short m_mode;

  public HeartbeatExtension(short mode)
  {
    this.m_mode = HeartbeatMode.IsValid(mode) ? mode : throw new ArgumentException("not a valid HeartbeatMode value", nameof (mode));
  }

  public short Mode => this.m_mode;

  public void Encode(Stream output) => TlsUtilities.WriteUint8(this.m_mode, output);

  public static HeartbeatExtension Parse(Stream input)
  {
    int num = (int) TlsUtilities.ReadUint8(input);
    return HeartbeatMode.IsValid((short) num) ? new HeartbeatExtension((short) num) : throw new TlsFatalAlert((short) 47);
  }
}
