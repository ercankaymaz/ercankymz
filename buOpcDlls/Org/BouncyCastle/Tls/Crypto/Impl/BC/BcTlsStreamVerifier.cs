// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsStreamVerifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsStreamVerifier : TlsStreamVerifier
{
  private readonly SignerSink m_output;
  private readonly byte[] m_signature;

  internal BcTlsStreamVerifier(ISigner verifier, byte[] signature)
  {
    this.m_output = new SignerSink(verifier);
    this.m_signature = signature;
  }

  public Stream Stream => (Stream) this.m_output;

  public bool IsVerified() => this.m_output.Signer.VerifySignature(this.m_signature);
}
