// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcSsl3Hmac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal class BcSsl3Hmac : TlsHmac, TlsMac
{
  private const byte IPAD_BYTE = 54;
  private const byte OPAD_BYTE = 92;
  private static readonly byte[] IPAD = BcSsl3Hmac.GenPad((byte) 54, 48 /*0x30*/);
  private static readonly byte[] OPAD = BcSsl3Hmac.GenPad((byte) 92, 48 /*0x30*/);
  private readonly IDigest m_digest;
  private readonly int m_padLength;
  private byte[] m_secret;

  internal BcSsl3Hmac(IDigest digest)
  {
    this.m_digest = digest;
    if (digest.GetDigestSize() == 20)
      this.m_padLength = 40;
    else
      this.m_padLength = 48 /*0x30*/;
  }

  public virtual void SetKey(byte[] key, int keyOff, int keyLen)
  {
    this.m_secret = TlsUtilities.CopyOfRangeExact(key, keyOff, keyOff + keyLen);
    this.Reset();
  }

  public virtual void Update(byte[] input, int inOff, int len)
  {
    this.m_digest.BlockUpdate(input, inOff, len);
  }

  public virtual byte[] CalculateMac()
  {
    byte[] output = new byte[this.m_digest.GetDigestSize()];
    this.DoFinal(output, 0);
    return output;
  }

  public virtual void CalculateMac(byte[] output, int outOff) => this.DoFinal(output, outOff);

  public virtual int InternalBlockSize => this.m_digest.GetByteLength();

  public virtual int MacLength => this.m_digest.GetDigestSize();

  public virtual void Reset()
  {
    this.m_digest.Reset();
    this.m_digest.BlockUpdate(this.m_secret, 0, this.m_secret.Length);
    this.m_digest.BlockUpdate(BcSsl3Hmac.IPAD, 0, this.m_padLength);
  }

  private void DoFinal(byte[] output, int outOff)
  {
    byte[] numArray = new byte[this.m_digest.GetDigestSize()];
    this.m_digest.DoFinal(numArray, 0);
    this.m_digest.BlockUpdate(this.m_secret, 0, this.m_secret.Length);
    this.m_digest.BlockUpdate(BcSsl3Hmac.OPAD, 0, this.m_padLength);
    this.m_digest.BlockUpdate(numArray, 0, numArray.Length);
    this.m_digest.DoFinal(output, outOff);
    this.Reset();
  }

  private static byte[] GenPad(byte b, int count)
  {
    byte[] buf = new byte[count];
    Arrays.Fill(buf, b);
    return buf;
  }
}
