// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.ECDHWithKdfBasicAgreement
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Agreement.Kdf;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement;

public class ECDHWithKdfBasicAgreement : ECDHBasicAgreement
{
  private readonly string algorithm;
  private readonly IDerivationFunction kdf;

  public ECDHWithKdfBasicAgreement(string algorithm, IDerivationFunction kdf)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (kdf == null)
      throw new ArgumentNullException(nameof (kdf));
    this.algorithm = algorithm;
    this.kdf = kdf;
  }

  public override BigInteger CalculateAgreement(ICipherParameters pubKey)
  {
    BigInteger agreement = base.CalculateAgreement(pubKey);
    int defaultKeySize = GeneratorUtilities.GetDefaultKeySize(this.algorithm);
    this.kdf.Init((IDerivationParameters) new DHKdfParameters(new DerObjectIdentifier(this.algorithm), defaultKeySize, this.BigIntToBytes(agreement)));
    byte[] numArray = new byte[defaultKeySize / 8];
    this.kdf.GenerateBytes(numArray, 0, numArray.Length);
    return new BigInteger(1, numArray);
  }

  private byte[] BigIntToBytes(BigInteger r)
  {
    int byteLength = X9IntegerConverter.GetByteLength(this.privKey.Parameters.Curve);
    return X9IntegerConverter.IntegerToBytes(r, byteLength);
  }
}
