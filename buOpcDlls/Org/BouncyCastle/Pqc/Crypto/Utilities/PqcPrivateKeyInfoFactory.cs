// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Utilities.PqcPrivateKeyInfoFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Asn1;
using Org.BouncyCastle.Pqc.Crypto.Bike;
using Org.BouncyCastle.Pqc.Crypto.Cmce;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using Org.BouncyCastle.Pqc.Crypto.Hqc;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Org.BouncyCastle.Pqc.Crypto.Picnic;
using Org.BouncyCastle.Pqc.Crypto.Saber;
using Org.BouncyCastle.Pqc.Crypto.Sike;
using Org.BouncyCastle.Pqc.Crypto.SphincsPlus;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Utilities;

public static class PqcPrivateKeyInfoFactory
{
  public static PrivateKeyInfo CreatePrivateKeyInfo(AsymmetricKeyParameter privateKey)
  {
    return PqcPrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey, (Asn1Set) null);
  }

  public static PrivateKeyInfo CreatePrivateKeyInfo(
    AsymmetricKeyParameter privateKey,
    Asn1Set attributes)
  {
    switch (privateKey)
    {
      case LmsPrivateKeyParameters privateKeyParameters1:
        byte[] contents1 = Composer.Compose().U32Str(1).Bytes((IEncodable) privateKeyParameters1).Build();
        byte[] publicKey1 = Composer.Compose().U32Str(1).Bytes((IEncodable) privateKeyParameters1.GetPublicKey()).Build();
        return new PrivateKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), (Asn1Encodable) new DerOctetString(contents1), attributes, publicKey1);
      case HssPrivateKeyParameters privateKeyParameters2:
        int l = privateKeyParameters2.L;
        byte[] contents2 = Composer.Compose().U32Str(l).Bytes((IEncodable) privateKeyParameters2).Build();
        byte[] publicKey2 = Composer.Compose().U32Str(l).Bytes((IEncodable) privateKeyParameters2.GetPublicKey().LmsPublicKey).Build();
        return new PrivateKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), (Asn1Encodable) new DerOctetString(contents2), attributes, publicKey2);
      case SphincsPlusPrivateKeyParameters privateKeyParameters3:
        byte[] encoded1 = privateKeyParameters3.GetEncoded();
        byte[] encodedPublicKey = privateKeyParameters3.GetEncodedPublicKey();
        return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.SphincsPlusOidLookup(privateKeyParameters3.Parameters)), (Asn1Encodable) new DerOctetString(encoded1), attributes, encodedPublicKey);
      case CmcePrivateKeyParameters privateKeyParameters4:
        privateKeyParameters4.GetEncoded();
        AlgorithmIdentifier privateKeyAlgorithm1 = new AlgorithmIdentifier(PqcUtilities.McElieceOidLookup(privateKeyParameters4.Parameters));
        CmcePublicKey pubKey = new CmcePublicKey(privateKeyParameters4.ReconstructPublicKey());
        CmcePrivateKey privateKey1 = new CmcePrivateKey(0, privateKeyParameters4.Delta, privateKeyParameters4.C, privateKeyParameters4.G, privateKeyParameters4.Alpha, privateKeyParameters4.S, pubKey);
        Asn1Set attributes1 = attributes;
        return new PrivateKeyInfo(privateKeyAlgorithm1, (Asn1Encodable) privateKey1, attributes1);
      case SaberPrivateKeyParameters privateKeyParameters5:
        byte[] encoded2 = privateKeyParameters5.GetEncoded();
        return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.SaberOidLookup(privateKeyParameters5.Parameters)), (Asn1Encodable) new DerOctetString(encoded2), attributes);
      case PicnicPrivateKeyParameters privateKeyParameters6:
        byte[] encoded3 = privateKeyParameters6.GetEncoded();
        return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.PicnicOidLookup(privateKeyParameters6.Parameters)), (Asn1Encodable) new DerOctetString(encoded3), attributes);
      case SikePrivateKeyParameters privateKeyParameters7:
        byte[] encoded4 = privateKeyParameters7.GetEncoded();
        return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.SikeOidLookup(privateKeyParameters7.Parameters)), (Asn1Encodable) new DerOctetString(encoded4), attributes);
      case FalconPrivateKeyParameters privateKeyParameters8:
        return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.FalconOidLookup(privateKeyParameters8.Parameters)), (Asn1Encodable) new DerSequence(new Asn1EncodableVector(4)
        {
          (Asn1Encodable) new DerInteger(1),
          (Asn1Encodable) new DerOctetString(privateKeyParameters8.GetSpolyLittleF()),
          (Asn1Encodable) new DerOctetString(privateKeyParameters8.GetG()),
          (Asn1Encodable) new DerOctetString(privateKeyParameters8.GetSpolyBigF())
        }), attributes, privateKeyParameters8.GetPublicKey());
      case KyberPrivateKeyParameters privateKeyParameters9:
        Asn1EncodableVector elementVector1 = new Asn1EncodableVector(4);
        elementVector1.Add((Asn1Encodable) new DerInteger(0));
        elementVector1.Add((Asn1Encodable) new DerOctetString(privateKeyParameters9.S));
        elementVector1.Add((Asn1Encodable) new DerOctetString(privateKeyParameters9.Hpk));
        elementVector1.Add((Asn1Encodable) new DerOctetString(privateKeyParameters9.Nonce));
        AlgorithmIdentifier privateKeyAlgorithm2 = new AlgorithmIdentifier(PqcUtilities.KyberOidLookup(privateKeyParameters9.Parameters));
        Asn1EncodableVector elementVector2 = new Asn1EncodableVector(2);
        elementVector2.Add((Asn1Encodable) new DerOctetString(privateKeyParameters9.T));
        elementVector2.Add((Asn1Encodable) new DerOctetString(privateKeyParameters9.Rho));
        DerSequence privateKey2 = new DerSequence(elementVector1);
        Asn1Set attributes2 = attributes;
        byte[] encoded5 = new DerSequence(elementVector2).GetEncoded();
        return new PrivateKeyInfo(privateKeyAlgorithm2, (Asn1Encodable) privateKey2, attributes2, encoded5);
      case DilithiumPrivateKeyParameters privateKeyParameters10:
        Asn1EncodableVector elementVector3 = new Asn1EncodableVector(7);
        elementVector3.Add((Asn1Encodable) new DerInteger(0));
        elementVector3.Add((Asn1Encodable) new DerBitString(privateKeyParameters10.Rho));
        elementVector3.Add((Asn1Encodable) new DerBitString(privateKeyParameters10.K));
        elementVector3.Add((Asn1Encodable) new DerBitString(privateKeyParameters10.Tr));
        elementVector3.Add((Asn1Encodable) new DerBitString(privateKeyParameters10.S1));
        elementVector3.Add((Asn1Encodable) new DerBitString(privateKeyParameters10.S2));
        elementVector3.Add((Asn1Encodable) new DerBitString(privateKeyParameters10.T0));
        AlgorithmIdentifier privateKeyAlgorithm3 = new AlgorithmIdentifier(PqcUtilities.DilithiumOidLookup(privateKeyParameters10.Parameters));
        Asn1EncodableVector elementVector4 = new Asn1EncodableVector(2);
        elementVector4.Add((Asn1Encodable) new DerOctetString(privateKeyParameters10.Rho));
        elementVector4.Add((Asn1Encodable) new DerOctetString(privateKeyParameters10.T1));
        DerSequence privateKey3 = new DerSequence(elementVector3);
        Asn1Set attributes3 = attributes;
        byte[] encoded6 = new DerSequence(elementVector4).GetEncoded();
        return new PrivateKeyInfo(privateKeyAlgorithm3, (Asn1Encodable) privateKey3, attributes3, encoded6);
      case BikePrivateKeyParameters privateKeyParameters11:
        byte[] encoded7 = privateKeyParameters11.GetEncoded();
        return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.BikeOidLookup(privateKeyParameters11.Parameters)), (Asn1Encodable) new DerOctetString(encoded7), attributes);
      case HqcPrivateKeyParameters privateKeyParameters12:
        return new PrivateKeyInfo(new AlgorithmIdentifier(PqcUtilities.HqcOidLookup(privateKeyParameters12.Parameters)), (Asn1Encodable) new DerOctetString(privateKeyParameters12.PrivateKey), attributes);
      default:
        throw new ArgumentException("Class provided is not convertible: " + Platform.GetTypeName((object) privateKey));
    }
  }
}
