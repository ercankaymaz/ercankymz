// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsEd25519Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsEd25519Signer(BcTlsCrypto crypto, Ed25519PrivateKeyParameters privateKey) : 
  BcTlsSigner(crypto, (AsymmetricKeyParameter) privateKey)
{
  public override TlsStreamSigner GetStreamSigner(SignatureAndHashAlgorithm algorithm)
  {
    if (algorithm == null || SignatureScheme.From(algorithm) != 2055)
      throw new InvalidOperationException("Invalid algorithm: " + algorithm?.ToString());
    Ed25519Signer ed25519Signer = new Ed25519Signer();
    ed25519Signer.Init(true, (ICipherParameters) this.m_privateKey);
    return (TlsStreamSigner) new BcTlsStreamSigner((ISigner) ed25519Signer);
  }
}
