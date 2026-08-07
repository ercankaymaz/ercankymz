// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsHmac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsHmac : TlsHmac, TlsMac
{
  private readonly HMac m_hmac;

  internal BcTlsHmac(HMac hmac) => this.m_hmac = hmac;

  public void SetKey(byte[] key, int keyOff, int keyLen)
  {
    this.m_hmac.Init((ICipherParameters) new KeyParameter(key, keyOff, keyLen));
  }

  public void Update(byte[] input, int inOff, int length)
  {
    this.m_hmac.BlockUpdate(input, inOff, length);
  }

  public byte[] CalculateMac()
  {
    byte[] output = new byte[this.m_hmac.GetMacSize()];
    this.m_hmac.DoFinal(output, 0);
    return output;
  }

  public void CalculateMac(byte[] output, int outOff) => this.m_hmac.DoFinal(output, outOff);

  public int InternalBlockSize => this.m_hmac.GetUnderlyingDigest().GetByteLength();

  public int MacLength => this.m_hmac.GetMacSize();

  public void Reset() => this.m_hmac.Reset();
}
