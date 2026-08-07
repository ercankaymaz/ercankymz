// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.KdfParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class KdfParameters : IDerivationParameters
{
  private readonly byte[] m_iv;
  private readonly byte[] m_shared;

  public KdfParameters(byte[] shared, byte[] iv)
  {
    this.m_shared = shared;
    this.m_iv = iv;
  }

  public byte[] GetSharedSecret() => this.m_shared;

  public byte[] GetIV() => this.m_iv;
}
