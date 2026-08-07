// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.DilithiumSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public class DilithiumSigner : IMessageSigner
{
  private DilithiumPrivateKeyParameters privKey;
  private DilithiumPublicKeyParameters pubKey;
  private SecureRandom random;

  public void Init(bool forSigning, ICipherParameters param)
  {
    if (forSigning)
    {
      if (param is ParametersWithRandom parametersWithRandom)
      {
        this.privKey = (DilithiumPrivateKeyParameters) parametersWithRandom.Parameters;
        this.random = parametersWithRandom.Random;
      }
      else
      {
        this.privKey = (DilithiumPrivateKeyParameters) param;
        this.random = (SecureRandom) null;
      }
    }
    else
    {
      this.pubKey = (DilithiumPublicKeyParameters) param;
      this.random = (SecureRandom) null;
    }
  }

  public byte[] GenerateSignature(byte[] message)
  {
    DilithiumEngine engine = this.privKey.Parameters.GetEngine(this.random);
    byte[] sig = new byte[engine.CryptoBytes];
    engine.Sign(sig, sig.Length, message, message.Length, this.privKey.rho, this.privKey.k, this.privKey.tr, this.privKey.t0, this.privKey.s1, this.privKey.s2);
    return sig;
  }

  public bool VerifySignature(byte[] message, byte[] signature)
  {
    return this.pubKey.Parameters.GetEngine(this.random).SignOpen(message, signature, signature.Length, this.pubKey.rho, this.pubKey.t1);
  }
}
