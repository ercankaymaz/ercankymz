// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsContext : IDigest
{
  private readonly byte[] m_c;
  private readonly LMOtsPrivateKey m_privateKey;
  private readonly LMSigParameters m_sigParams;
  private readonly byte[][] m_path;
  private readonly LMOtsPublicKey m_publicKey;
  private readonly object m_signature;
  private LmsSignedPubKey[] m_signedPubKeys;
  private volatile IDigest m_digest;

  public LmsContext(
    LMOtsPrivateKey privateKey,
    LMSigParameters sigParams,
    IDigest digest,
    byte[] C,
    byte[][] path)
  {
    this.m_privateKey = privateKey;
    this.m_sigParams = sigParams;
    this.m_digest = digest;
    this.m_c = C;
    this.m_path = path;
    this.m_publicKey = (LMOtsPublicKey) null;
    this.m_signature = (object) null;
  }

  public LmsContext(LMOtsPublicKey publicKey, object signature, IDigest digest)
  {
    this.m_publicKey = publicKey;
    this.m_signature = signature;
    this.m_digest = digest;
    this.m_c = (byte[]) null;
    this.m_privateKey = (LMOtsPrivateKey) null;
    this.m_sigParams = (LMSigParameters) null;
    this.m_path = (byte[][]) null;
  }

  public byte[] C => this.m_c;

  public byte[] GetQ()
  {
    byte[] output = new byte[LMOts.MAX_HASH + 2];
    this.m_digest.DoFinal(output, 0);
    this.m_digest = (IDigest) null;
    return output;
  }

  internal byte[][] Path => this.m_path;

  internal LMOtsPrivateKey PrivateKey => this.m_privateKey;

  public LMOtsPublicKey PublicKey => this.m_publicKey;

  internal LMSigParameters SigParams => this.m_sigParams;

  public object Signature => this.m_signature;

  internal LmsSignedPubKey[] SignedPubKeys => this.m_signedPubKeys;

  internal LmsContext WithSignedPublicKeys(LmsSignedPubKey[] signedPubKeys)
  {
    this.m_signedPubKeys = signedPubKeys;
    return this;
  }

  public string AlgorithmName => this.m_digest.AlgorithmName;

  public int GetDigestSize() => this.m_digest.GetDigestSize();

  public int GetByteLength() => this.m_digest.GetByteLength();

  public void Update(byte input) => this.m_digest.Update(input);

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    this.m_digest.BlockUpdate(input, inOff, len);
  }

  public int DoFinal(byte[] output, int outOff) => this.m_digest.DoFinal(output, outOff);

  public void Reset() => this.m_digest.Reset();
}
