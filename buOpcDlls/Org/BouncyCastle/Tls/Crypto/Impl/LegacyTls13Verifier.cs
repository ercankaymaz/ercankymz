// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.LegacyTls13Verifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public sealed class LegacyTls13Verifier : TlsVerifier
{
  private readonly int m_signatureScheme;
  private readonly Tls13Verifier m_tls13Verifier;

  public LegacyTls13Verifier(int signatureScheme, Tls13Verifier tls13Verifier)
  {
    if (!TlsUtilities.IsValidUint16(signatureScheme))
      throw new ArgumentException(nameof (signatureScheme));
    if (tls13Verifier == null)
      throw new ArgumentNullException(nameof (tls13Verifier));
    this.m_signatureScheme = signatureScheme;
    this.m_tls13Verifier = tls13Verifier;
  }

  public TlsStreamVerifier GetStreamVerifier(DigitallySigned digitallySigned)
  {
    SignatureAndHashAlgorithm algorithm = digitallySigned.Algorithm;
    if (algorithm == null || SignatureScheme.From(algorithm) != this.m_signatureScheme)
      throw new InvalidOperationException("Invalid algorithm: " + algorithm?.ToString());
    return (TlsStreamVerifier) new LegacyTls13Verifier.TlsStreamVerifierImpl(this.m_tls13Verifier, digitallySigned.Signature);
  }

  public bool VerifyRawSignature(DigitallySigned digitallySigned, byte[] hash)
  {
    throw new NotSupportedException();
  }

  private class TlsStreamVerifierImpl : TlsStreamVerifier
  {
    private readonly Tls13Verifier m_tls13Verifier;
    private readonly byte[] m_signature;

    internal TlsStreamVerifierImpl(Tls13Verifier tls13Verifier, byte[] signature)
    {
      this.m_tls13Verifier = tls13Verifier;
      this.m_signature = signature;
    }

    public Stream Stream => this.m_tls13Verifier.Stream;

    public bool IsVerified() => this.m_tls13Verifier.VerifySignature(this.m_signature);
  }
}
