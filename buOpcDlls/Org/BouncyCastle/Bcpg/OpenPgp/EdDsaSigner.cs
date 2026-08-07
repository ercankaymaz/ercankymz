// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.EdDsaSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

internal sealed class EdDsaSigner : ISigner
{
  private readonly ISigner m_signer;
  private readonly IDigest m_digest;

  internal EdDsaSigner(ISigner signer, IDigest digest)
  {
    this.m_signer = signer;
    this.m_digest = digest;
  }

  public string AlgorithmName => this.m_signer.AlgorithmName;

  public void Init(bool forSigning, ICipherParameters cipherParameters)
  {
    this.m_signer.Init(forSigning, cipherParameters);
    this.m_digest.Reset();
  }

  public void Update(byte b) => this.m_digest.Update(b);

  public void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.m_digest.BlockUpdate(input, inOff, inLen);
  }

  public int GetMaxSignatureSize() => this.m_signer.GetMaxSignatureSize();

  public byte[] GenerateSignature()
  {
    this.FinalizeDigest();
    return this.m_signer.GenerateSignature();
  }

  public bool VerifySignature(byte[] signature)
  {
    this.FinalizeDigest();
    return this.m_signer.VerifySignature(signature);
  }

  public void Reset()
  {
    this.m_signer.Reset();
    this.m_digest.Reset();
  }

  private void FinalizeDigest()
  {
    byte[] input = DigestUtilities.DoFinal(this.m_digest);
    this.m_signer.BlockUpdate(input, 0, input.Length);
  }
}
