// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

public class FalconSigner : IMessageSigner
{
  private byte[] encodedkey;
  private FalconNist nist;

  public void Init(bool forSigning, ICipherParameters param)
  {
    SecureRandom random;
    FalconParameters parameters;
    if (forSigning)
    {
      FalconPrivateKeyParameters privateKeyParameters;
      if (param is ParametersWithRandom parametersWithRandom)
      {
        privateKeyParameters = (FalconPrivateKeyParameters) parametersWithRandom.Parameters;
        random = parametersWithRandom.Random;
      }
      else
      {
        privateKeyParameters = (FalconPrivateKeyParameters) param;
        random = CryptoServicesRegistrar.GetSecureRandom();
      }
      this.encodedkey = privateKeyParameters.GetEncoded();
      parameters = privateKeyParameters.Parameters;
    }
    else
    {
      FalconPublicKeyParameters publicKeyParameters = (FalconPublicKeyParameters) param;
      random = (SecureRandom) null;
      this.encodedkey = publicKeyParameters.GetEncoded();
      parameters = publicKeyParameters.Parameters;
    }
    this.nist = new FalconNist(random, (uint) parameters.LogN, (uint) parameters.NonceLength);
  }

  public byte[] GenerateSignature(byte[] message)
  {
    return this.nist.crypto_sign(false, new byte[this.nist.CryptoBytes], message, 0, (uint) message.Length, this.encodedkey, 0);
  }

  public bool VerifySignature(byte[] message, byte[] signature)
  {
    if ((int) signature[0] != (int) (byte) (48U /*0x30*/ + this.nist.LogN))
      return false;
    byte[] numArray1 = new byte[(int) this.nist.NonceLength];
    byte[] numArray2 = new byte[(long) signature.Length - (long) this.nist.NonceLength - 1L];
    Array.Copy((Array) signature, 1L, (Array) numArray1, 0L, (long) this.nist.NonceLength);
    Array.Copy((Array) signature, (long) (this.nist.NonceLength + 1U), (Array) numArray2, 0L, (long) signature.Length - (long) this.nist.NonceLength - 1L);
    return this.nist.crypto_sign_open(false, numArray2, numArray1, message, this.encodedkey, 0) == 0;
  }
}
