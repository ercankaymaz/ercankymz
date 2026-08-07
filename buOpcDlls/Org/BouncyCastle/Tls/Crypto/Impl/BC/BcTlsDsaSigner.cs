// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsDsaSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsDsaSigner(BcTlsCrypto crypto, DsaPrivateKeyParameters privateKey) : BcTlsDssSigner(crypto, (AsymmetricKeyParameter) privateKey)
{
  protected override IDsa CreateDsaImpl(int cryptoHashAlgorithm)
  {
    return (IDsa) new DsaSigner((IDsaKCalculator) new HMacDsaKCalculator(this.m_crypto.CreateDigest(cryptoHashAlgorithm)));
  }

  protected override short SignatureAlgorithm => 2;
}
