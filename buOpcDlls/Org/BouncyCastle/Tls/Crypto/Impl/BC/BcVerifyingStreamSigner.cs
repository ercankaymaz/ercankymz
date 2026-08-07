// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcVerifyingStreamSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcVerifyingStreamSigner : TlsStreamSigner
{
  private readonly ISigner m_signer;
  private readonly ISigner m_verifier;
  private readonly TeeOutputStream m_output;

  internal BcVerifyingStreamSigner(ISigner signer, ISigner verifier)
  {
    Stream output = (Stream) new SignerSink(signer);
    Stream tee = (Stream) new SignerSink(verifier);
    this.m_signer = signer;
    this.m_verifier = verifier;
    this.m_output = new TeeOutputStream(output, tee);
  }

  public Stream Stream => (Stream) this.m_output;

  public byte[] GetSignature()
  {
    try
    {
      byte[] signature = this.m_signer.GenerateSignature();
      if (this.m_verifier.VerifySignature(signature))
        return signature;
    }
    catch (CryptoException ex)
    {
      throw new TlsFatalAlert((short) 80 /*0x50*/, (Exception) ex);
    }
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }
}
