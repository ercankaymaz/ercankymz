// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsStreamSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsStreamSigner : TlsStreamSigner
{
  private readonly SignerSink m_output;

  internal BcTlsStreamSigner(ISigner signer) => this.m_output = new SignerSink(signer);

  public Stream Stream => (Stream) this.m_output;

  public byte[] GetSignature()
  {
    try
    {
      return this.m_output.Signer.GenerateSignature();
    }
    catch (CryptoException ex)
    {
      throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
    }
  }
}
