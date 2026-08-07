// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.PrivateKeyInfoFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public static class PrivateKeyInfoFactory
{
  public static PrivateKeyInfo CreatePrivateKeyInfo(AsymmetricKeyParameter privateKey)
  {
    return PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey, (Asn1Set) null);
  }

  public static PrivateKeyInfo CreatePrivateKeyInfo(
    AsymmetricKeyParameter privateKey,
    Asn1Set attributes)
  {
    if (privateKey == null)
      throw new ArgumentNullException(nameof (privateKey));
    if (!privateKey.IsPrivate)
      throw new ArgumentException("Public key passed - private key expected", nameof (privateKey));
    switch (privateKey)
    {
      case ElGamalPrivateKeyParameters _:
        ElGamalPrivateKeyParameters privateKeyParameters1 = (ElGamalPrivateKeyParameters) privateKey;
        ElGamalParameters parameters1 = privateKeyParameters1.Parameters;
        return new PrivateKeyInfo(new AlgorithmIdentifier(OiwObjectIdentifiers.ElGamalAlgorithm, (Asn1Encodable) new ElGamalParameter(parameters1.P, parameters1.G).ToAsn1Object()), (Asn1Encodable) new DerInteger(privateKeyParameters1.X), attributes);
      case DsaPrivateKeyParameters _:
        DsaPrivateKeyParameters privateKeyParameters2 = (DsaPrivateKeyParameters) privateKey;
        DsaParameters parameters2 = privateKeyParameters2.Parameters;
        return new PrivateKeyInfo(new AlgorithmIdentifier(X9ObjectIdentifiers.IdDsa, (Asn1Encodable) new DsaParameter(parameters2.P, parameters2.Q, parameters2.G).ToAsn1Object()), (Asn1Encodable) new DerInteger(privateKeyParameters2.X), attributes);
      case DHPrivateKeyParameters _:
        DHPrivateKeyParameters privateKeyParameters3 = (DHPrivateKeyParameters) privateKey;
        DHParameter dhParameter = new DHParameter(privateKeyParameters3.Parameters.P, privateKeyParameters3.Parameters.G, privateKeyParameters3.Parameters.L);
        return new PrivateKeyInfo(new AlgorithmIdentifier(privateKeyParameters3.AlgorithmOid, (Asn1Encodable) dhParameter.ToAsn1Object()), (Asn1Encodable) new DerInteger(privateKeyParameters3.X), attributes);
      case RsaKeyParameters _:
        AlgorithmIdentifier privateKeyAlgorithm1 = new AlgorithmIdentifier(PkcsObjectIdentifiers.RsaEncryption, (Asn1Encodable) DerNull.Instance);
        RsaPrivateKeyStructure privateKeyStructure;
        if (privateKey is RsaPrivateCrtKeyParameters)
        {
          RsaPrivateCrtKeyParameters crtKeyParameters = (RsaPrivateCrtKeyParameters) privateKey;
          privateKeyStructure = new RsaPrivateKeyStructure(crtKeyParameters.Modulus, crtKeyParameters.PublicExponent, crtKeyParameters.Exponent, crtKeyParameters.P, crtKeyParameters.Q, crtKeyParameters.DP, crtKeyParameters.DQ, crtKeyParameters.QInv);
        }
        else
        {
          RsaKeyParameters rsaKeyParameters = (RsaKeyParameters) privateKey;
          privateKeyStructure = new RsaPrivateKeyStructure(rsaKeyParameters.Modulus, BigInteger.Zero, rsaKeyParameters.Exponent, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero, BigInteger.Zero);
        }
        Asn1Object asn1Object = privateKeyStructure.ToAsn1Object();
        Asn1Set attributes1 = attributes;
        return new PrivateKeyInfo(privateKeyAlgorithm1, (Asn1Encodable) asn1Object, attributes1);
      case ECPrivateKeyParameters _:
        ECPrivateKeyParameters privKey = (ECPrivateKeyParameters) privateKey;
        DerBitString publicKey = new DerBitString(ECKeyPairGenerator.GetCorrespondingPublicKey(privKey).Q.GetEncoded(false));
        ECDomainParameters parameters3 = privKey.Parameters;
        if (parameters3 is ECGost3410Parameters)
        {
          ECGost3410Parameters gost3410Parameters = (ECGost3410Parameters) parameters3;
          Gost3410PublicKeyAlgParameters parameters4 = new Gost3410PublicKeyAlgParameters(gost3410Parameters.PublicKeyParamSet, gost3410Parameters.DigestParamSet, gost3410Parameters.EncryptionParamSet);
          int num = privKey.D.BitLength > 256 /*0x0100*/ ? 1 : 0;
          DerObjectIdentifier algorithm = num != 0 ? RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512 : RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256;
          int size = num != 0 ? 64 /*0x40*/ : 32 /*0x20*/;
          byte[] numArray = new byte[size];
          PrivateKeyInfoFactory.ExtractBytes(numArray, size, 0, privKey.D);
          return new PrivateKeyInfo(new AlgorithmIdentifier(algorithm, (Asn1Encodable) parameters4), (Asn1Encodable) new DerOctetString(numArray));
        }
        int bitLength = parameters3.N.BitLength;
        AlgorithmIdentifier privateKeyAlgorithm2;
        ECPrivateKeyStructure privateKey1;
        if (privKey.AlgorithmName == "ECGOST3410")
        {
          if (privKey.PublicKeyParamSet == null)
            throw new NotImplementedException("Not a CryptoPro parameter set");
          Gost3410PublicKeyAlgParameters parameters5 = new Gost3410PublicKeyAlgParameters(privKey.PublicKeyParamSet, CryptoProObjectIdentifiers.GostR3411x94CryptoProParamSet);
          privateKeyAlgorithm2 = new AlgorithmIdentifier(CryptoProObjectIdentifiers.GostR3410x2001, (Asn1Encodable) parameters5);
          privateKey1 = new ECPrivateKeyStructure(bitLength, privKey.D, publicKey, (Asn1Encodable) null);
        }
        else
        {
          X962Parameters parameters6 = privKey.PublicKeyParamSet != null ? new X962Parameters(privKey.PublicKeyParamSet) : new X962Parameters(new X9ECParameters(parameters3.Curve, new X9ECPoint(parameters3.G, false), parameters3.N, parameters3.H, parameters3.GetSeed()));
          privateKey1 = new ECPrivateKeyStructure(bitLength, privKey.D, publicKey, (Asn1Encodable) parameters6);
          privateKeyAlgorithm2 = new AlgorithmIdentifier(X9ObjectIdentifiers.IdECPublicKey, (Asn1Encodable) parameters6);
        }
        return new PrivateKeyInfo(privateKeyAlgorithm2, (Asn1Encodable) privateKey1, attributes);
      case Gost3410PrivateKeyParameters _:
        Gost3410PrivateKeyParameters privateKeyParameters4 = (Gost3410PrivateKeyParameters) privateKey;
        byte[] numArray1 = privateKeyParameters4.PublicKeyParamSet != null ? privateKeyParameters4.X.ToByteArrayUnsigned() : throw new NotImplementedException("Not a CryptoPro parameter set");
        byte[] contents = new byte[numArray1.Length];
        for (int index = 0; index != contents.Length; ++index)
          contents[index] = numArray1[numArray1.Length - 1 - index];
        Gost3410PublicKeyAlgParameters keyAlgParameters = new Gost3410PublicKeyAlgParameters(privateKeyParameters4.PublicKeyParamSet, CryptoProObjectIdentifiers.GostR3411x94CryptoProParamSet, (DerObjectIdentifier) null);
        return new PrivateKeyInfo(new AlgorithmIdentifier(CryptoProObjectIdentifiers.GostR3410x94, (Asn1Encodable) keyAlgParameters.ToAsn1Object()), (Asn1Encodable) new DerOctetString(contents), attributes);
      case X448PrivateKeyParameters _:
        X448PrivateKeyParameters privateKeyParameters5 = (X448PrivateKeyParameters) privateKey;
        return new PrivateKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_X448), (Asn1Encodable) new DerOctetString(privateKeyParameters5.GetEncoded()), attributes, privateKeyParameters5.GeneratePublicKey().GetEncoded());
      case X25519PrivateKeyParameters _:
        X25519PrivateKeyParameters privateKeyParameters6 = (X25519PrivateKeyParameters) privateKey;
        return new PrivateKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_X25519), (Asn1Encodable) new DerOctetString(privateKeyParameters6.GetEncoded()), attributes, privateKeyParameters6.GeneratePublicKey().GetEncoded());
      case Ed448PrivateKeyParameters _:
        Ed448PrivateKeyParameters privateKeyParameters7 = (Ed448PrivateKeyParameters) privateKey;
        return new PrivateKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_Ed448), (Asn1Encodable) new DerOctetString(privateKeyParameters7.GetEncoded()), attributes, privateKeyParameters7.GeneratePublicKey().GetEncoded());
      case Ed25519PrivateKeyParameters _:
        Ed25519PrivateKeyParameters privateKeyParameters8 = (Ed25519PrivateKeyParameters) privateKey;
        return new PrivateKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_Ed25519), (Asn1Encodable) new DerOctetString(privateKeyParameters8.GetEncoded()), attributes, privateKeyParameters8.GeneratePublicKey().GetEncoded());
      default:
        throw new ArgumentException("Class provided is not convertible: " + Platform.GetTypeName((object) privateKey));
    }
  }

  public static PrivateKeyInfo CreatePrivateKeyInfo(
    char[] passPhrase,
    EncryptedPrivateKeyInfo encInfo)
  {
    return PrivateKeyInfoFactory.CreatePrivateKeyInfo(passPhrase, false, encInfo);
  }

  public static PrivateKeyInfo CreatePrivateKeyInfo(
    char[] passPhrase,
    bool wrongPkcs12Zero,
    EncryptedPrivateKeyInfo encInfo)
  {
    AlgorithmIdentifier encryptionAlgorithm = encInfo.EncryptionAlgorithm;
    if (!(PbeUtilities.CreateEngine(encryptionAlgorithm) is IBufferedCipher engine))
      throw new Exception("Unknown encryption algorithm: " + encryptionAlgorithm.Algorithm?.ToString());
    engine.Init(false, PbeUtilities.GenerateCipherParameters(encryptionAlgorithm, passPhrase, wrongPkcs12Zero));
    return PrivateKeyInfo.GetInstance((object) engine.DoFinal(encInfo.GetEncryptedData()));
  }

  private static void ExtractBytes(byte[] encKey, int size, int offSet, BigInteger bI)
  {
    byte[] sourceArray = bI.ToByteArray();
    if (sourceArray.Length < size)
    {
      byte[] destinationArray = new byte[size];
      Array.Copy((Array) sourceArray, 0, (Array) destinationArray, destinationArray.Length - sourceArray.Length, sourceArray.Length);
      sourceArray = destinationArray;
    }
    for (int index = 0; index != size; ++index)
      encKey[offSet + index] = sourceArray[sourceArray.Length - 1 - index];
  }
}
