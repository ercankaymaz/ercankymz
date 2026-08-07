// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTls13Verifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTls13Verifier : Tls13Verifier
{
  private readonly SignerSink m_output;

  internal BcTls13Verifier(ISigner verifier)
  {
    this.m_output = verifier != null ? new SignerSink(verifier) : throw new ArgumentNullException(nameof (verifier));
  }

  public Stream Stream => (Stream) this.m_output;

  public bool VerifySignature(byte[] signature) => this.m_output.Signer.VerifySignature(signature);
}
