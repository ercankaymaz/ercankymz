// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DefaultTlsCredentialedSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Tls.Crypto.Impl;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class DefaultTlsCredentialedSigner : TlsCredentialedSigner, TlsCredentials
{
  protected readonly TlsCryptoParameters m_cryptoParams;
  protected readonly Certificate m_certificate;
  protected readonly SignatureAndHashAlgorithm m_signatureAndHashAlgorithm;
  protected readonly TlsSigner m_signer;

  public DefaultTlsCredentialedSigner(
    TlsCryptoParameters cryptoParams,
    TlsSigner signer,
    Certificate certificate,
    SignatureAndHashAlgorithm signatureAndHashAlgorithm)
  {
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    if (certificate.IsEmpty)
      throw new ArgumentException("cannot be empty", nameof (certificate));
    if (signer == null)
      throw new ArgumentNullException(nameof (signer));
    this.m_cryptoParams = cryptoParams;
    this.m_certificate = certificate;
    this.m_signatureAndHashAlgorithm = signatureAndHashAlgorithm;
    this.m_signer = signer;
  }

  public virtual Certificate Certificate => this.m_certificate;

  public virtual byte[] GenerateRawSignature(byte[] hash)
  {
    return this.m_signer.GenerateRawSignature(this.GetEffectiveAlgorithm(), hash);
  }

  public virtual SignatureAndHashAlgorithm SignatureAndHashAlgorithm
  {
    get => this.m_signatureAndHashAlgorithm;
  }

  public virtual TlsStreamSigner GetStreamSigner()
  {
    return this.m_signer.GetStreamSigner(this.GetEffectiveAlgorithm());
  }

  protected virtual SignatureAndHashAlgorithm GetEffectiveAlgorithm()
  {
    SignatureAndHashAlgorithm effectiveAlgorithm = (SignatureAndHashAlgorithm) null;
    if (TlsImplUtilities.IsTlsV12(this.m_cryptoParams))
    {
      effectiveAlgorithm = this.SignatureAndHashAlgorithm;
      if (effectiveAlgorithm == null)
        throw new InvalidOperationException("'signatureAndHashAlgorithm' cannot be null for (D)TLS 1.2+");
    }
    return effectiveAlgorithm;
  }
}
