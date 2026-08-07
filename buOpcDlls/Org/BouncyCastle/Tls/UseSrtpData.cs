// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.UseSrtpData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class UseSrtpData
{
  private readonly int[] m_protectionProfiles;
  private readonly byte[] m_mki;

  public UseSrtpData(int[] protectionProfiles, byte[] mki)
  {
    if (TlsUtilities.IsNullOrEmpty<int>(protectionProfiles) || protectionProfiles.Length >= 32768 /*0x8000*/)
      throw new ArgumentException("must have length from 1 to (2^15 - 1)", nameof (protectionProfiles));
    if (mki == null)
      mki = TlsUtilities.EmptyBytes;
    else if (mki.Length > (int) byte.MaxValue)
      throw new ArgumentException("cannot be longer than 255 bytes", nameof (mki));
    this.m_protectionProfiles = protectionProfiles;
    this.m_mki = mki;
  }

  public int[] ProtectionProfiles => this.m_protectionProfiles;

  public byte[] Mki => this.m_mki;
}
