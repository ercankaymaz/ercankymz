// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsHash : TlsHash
{
  private readonly BcTlsCrypto m_crypto;
  private readonly int m_cryptoHashAlgorithm;
  private readonly IDigest m_digest;

  internal BcTlsHash(BcTlsCrypto crypto, int cryptoHashAlgorithm)
    : this(crypto, cryptoHashAlgorithm, crypto.CreateDigest(cryptoHashAlgorithm))
  {
  }

  private BcTlsHash(BcTlsCrypto crypto, int cryptoHashAlgorithm, IDigest digest)
  {
    this.m_crypto = crypto;
    this.m_cryptoHashAlgorithm = cryptoHashAlgorithm;
    this.m_digest = digest;
  }

  public void Update(byte[] data, int offSet, int length)
  {
    this.m_digest.BlockUpdate(data, offSet, length);
  }

  public byte[] CalculateHash()
  {
    byte[] output = new byte[this.m_digest.GetDigestSize()];
    this.m_digest.DoFinal(output, 0);
    return output;
  }

  public TlsHash CloneHash()
  {
    return (TlsHash) new BcTlsHash(this.m_crypto, this.m_cryptoHashAlgorithm, this.m_crypto.CloneDigest(this.m_cryptoHashAlgorithm, this.m_digest));
  }

  public void Reset() => this.m_digest.Reset();
}
