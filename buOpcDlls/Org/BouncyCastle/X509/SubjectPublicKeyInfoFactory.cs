// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.SubjectPublicKeyInfoFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.X509;

public static class SubjectPublicKeyInfoFactory
{
  public static SubjectPublicKeyInfo CreateSubjectPublicKeyInfo(AsymmetricKeyParameter publicKey)
  {
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    if (publicKey.IsPrivate)
      throw new ArgumentException("Private key passed - public key expected.", nameof (publicKey));
    switch (publicKey)
    {
      case ElGamalPublicKeyParameters _:
        ElGamalPublicKeyParameters publicKeyParameters1 = (ElGamalPublicKeyParameters) publicKey;
        ElGamalParameters parameters1 = publicKeyParameters1.Parameters;
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(OiwObjectIdentifiers.ElGamalAlgorithm, (Asn1Encodable) new ElGamalParameter(parameters1.P, parameters1.G).ToAsn1Object()), (Asn1Encodable) new DerInteger(publicKeyParameters1.Y));
      case DsaPublicKeyParameters _:
        DsaPublicKeyParameters publicKeyParameters2 = (DsaPublicKeyParameters) publicKey;
        DsaParameters parameters2 = publicKeyParameters2.Parameters;
        Asn1Encodable asn1Object = parameters2 == null ? (Asn1Encodable) null : (Asn1Encodable) new DsaParameter(parameters2.P, parameters2.Q, parameters2.G).ToAsn1Object();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(X9ObjectIdentifiers.IdDsa, asn1Object), (Asn1Encodable) new DerInteger(publicKeyParameters2.Y));
      case DHPublicKeyParameters _:
        DHPublicKeyParameters publicKeyParameters3 = (DHPublicKeyParameters) publicKey;
        DHParameters parameters3 = publicKeyParameters3.Parameters;
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(publicKeyParameters3.AlgorithmOid, (Asn1Encodable) new DHParameter(parameters3.P, parameters3.G, parameters3.L).ToAsn1Object()), (Asn1Encodable) new DerInteger(publicKeyParameters3.Y));
      case RsaKeyParameters _:
        RsaKeyParameters rsaKeyParameters = (RsaKeyParameters) publicKey;
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.RsaEncryption, (Asn1Encodable) DerNull.Instance), (Asn1Encodable) new RsaPublicKeyStructure(rsaKeyParameters.Modulus, rsaKeyParameters.Exponent).ToAsn1Object());
      case ECPublicKeyParameters _:
        ECPublicKeyParameters publicKeyParameters4 = (ECPublicKeyParameters) publicKey;
        if (publicKeyParameters4.Parameters is ECGost3410Parameters)
        {
          ECGost3410Parameters parameters4 = (ECGost3410Parameters) publicKeyParameters4.Parameters;
          BigInteger bigInteger1 = publicKeyParameters4.Q.AffineXCoord.ToBigInteger();
          BigInteger bigInteger2 = publicKeyParameters4.Q.AffineYCoord.ToBigInteger();
          int num = bigInteger1.BitLength > 256 /*0x0100*/ ? 1 : 0;
          Gost3410PublicKeyAlgParameters parameters5 = new Gost3410PublicKeyAlgParameters(parameters4.PublicKeyParamSet, parameters4.DigestParamSet, parameters4.EncryptionParamSet);
          int length;
          int offSet;
          DerObjectIdentifier algorithm;
          if (num != 0)
          {
            length = 128 /*0x80*/;
            offSet = 64 /*0x40*/;
            algorithm = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512;
          }
          else
          {
            length = 64 /*0x40*/;
            offSet = 32 /*0x20*/;
            algorithm = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256;
          }
          byte[] numArray = new byte[length];
          SubjectPublicKeyInfoFactory.ExtractBytes(numArray, length / 2, 0, bigInteger1);
          SubjectPublicKeyInfoFactory.ExtractBytes(numArray, length / 2, offSet, bigInteger2);
          return new SubjectPublicKeyInfo(new AlgorithmIdentifier(algorithm, (Asn1Encodable) parameters5), (Asn1Encodable) new DerOctetString(numArray));
        }
        if (publicKeyParameters4.AlgorithmName == "ECGOST3410")
        {
          ECPoint ecPoint = publicKeyParameters4.PublicKeyParamSet != null ? publicKeyParameters4.Q.Normalize() : throw new NotImplementedException("Not a CryptoPro parameter set");
          BigInteger bigInteger3 = ecPoint.AffineXCoord.ToBigInteger();
          BigInteger bigInteger4 = ecPoint.AffineYCoord.ToBigInteger();
          byte[] numArray = new byte[64 /*0x40*/];
          SubjectPublicKeyInfoFactory.ExtractBytes(numArray, 0, bigInteger3);
          SubjectPublicKeyInfoFactory.ExtractBytes(numArray, 32 /*0x20*/, bigInteger4);
          Gost3410PublicKeyAlgParameters keyAlgParameters = new Gost3410PublicKeyAlgParameters(publicKeyParameters4.PublicKeyParamSet, CryptoProObjectIdentifiers.GostR3411x94CryptoProParamSet);
          return new SubjectPublicKeyInfo(new AlgorithmIdentifier(CryptoProObjectIdentifiers.GostR3410x2001, (Asn1Encodable) keyAlgParameters.ToAsn1Object()), (Asn1Encodable) new DerOctetString(numArray));
        }
        X962Parameters x962Parameters;
        if (publicKeyParameters4.PublicKeyParamSet == null)
        {
          ECDomainParameters parameters6 = publicKeyParameters4.Parameters;
          x962Parameters = new X962Parameters(new X9ECParameters(parameters6.Curve, new X9ECPoint(parameters6.G, false), parameters6.N, parameters6.H, parameters6.GetSeed()));
        }
        else
          x962Parameters = new X962Parameters(publicKeyParameters4.PublicKeyParamSet);
        byte[] encoded = publicKeyParameters4.Q.GetEncoded(false);
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(X9ObjectIdentifiers.IdECPublicKey, (Asn1Encodable) x962Parameters.ToAsn1Object()), encoded);
      case Gost3410PublicKeyParameters _:
        Gost3410PublicKeyParameters publicKeyParameters5 = (Gost3410PublicKeyParameters) publicKey;
        byte[] numArray1 = publicKeyParameters5.PublicKeyParamSet != null ? publicKeyParameters5.Y.ToByteArrayUnsigned() : throw new NotImplementedException("Not a CryptoPro parameter set");
        byte[] contents = new byte[numArray1.Length];
        for (int index = 0; index != contents.Length; ++index)
          contents[index] = numArray1[numArray1.Length - 1 - index];
        Gost3410PublicKeyAlgParameters keyAlgParameters1 = new Gost3410PublicKeyAlgParameters(publicKeyParameters5.PublicKeyParamSet, CryptoProObjectIdentifiers.GostR3411x94CryptoProParamSet);
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(CryptoProObjectIdentifiers.GostR3410x94, (Asn1Encodable) keyAlgParameters1.ToAsn1Object()), (Asn1Encodable) new DerOctetString(contents));
      case X448PublicKeyParameters _:
        X448PublicKeyParameters publicKeyParameters6 = (X448PublicKeyParameters) publicKey;
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_X448), publicKeyParameters6.GetEncoded());
      case X25519PublicKeyParameters _:
        X25519PublicKeyParameters publicKeyParameters7 = (X25519PublicKeyParameters) publicKey;
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_X25519), publicKeyParameters7.GetEncoded());
      case Ed448PublicKeyParameters _:
        Ed448PublicKeyParameters publicKeyParameters8 = (Ed448PublicKeyParameters) publicKey;
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_Ed448), publicKeyParameters8.GetEncoded());
      case Ed25519PublicKeyParameters _:
        Ed25519PublicKeyParameters publicKeyParameters9 = (Ed25519PublicKeyParameters) publicKey;
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(EdECObjectIdentifiers.id_Ed25519), publicKeyParameters9.GetEncoded());
      default:
        throw new ArgumentException("Class provided no convertible: " + Platform.GetTypeName((object) publicKey));
    }
  }

  private static void ExtractBytes(byte[] encKey, int offset, BigInteger bI)
  {
    byte[] byteArray = bI.ToByteArray();
    int num = (bI.BitLength + 7) / 8;
    for (int index = 0; index < num; ++index)
      encKey[offset + index] = byteArray[byteArray.Length - 1 - index];
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
