// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Utilities.PqcSubjectPublicKeyInfoFactory
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

public static class PqcSubjectPublicKeyInfoFactory
{
  public static SubjectPublicKeyInfo CreateSubjectPublicKeyInfo(AsymmetricKeyParameter publicKey)
  {
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    if (publicKey.IsPrivate)
      throw new ArgumentException("Private key passed - public key expected.", nameof (publicKey));
    switch (publicKey)
    {
      case LmsPublicKeyParameters publicKeyParameters1:
        byte[] contents1 = Composer.Compose().U32Str(1).Bytes((IEncodable) publicKeyParameters1).Build();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), (Asn1Encodable) new DerOctetString(contents1));
      case HssPublicKeyParameters publicKeyParameters2:
        int l = publicKeyParameters2.L;
        byte[] contents2 = Composer.Compose().U32Str(l).Bytes((IEncodable) publicKeyParameters2.LmsPublicKey).Build();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdAlgHssLmsHashsig), (Asn1Encodable) new DerOctetString(contents2));
      case SphincsPlusPublicKeyParameters publicKeyParameters3:
        byte[] encoded1 = publicKeyParameters3.GetEncoded();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.SphincsPlusOidLookup(publicKeyParameters3.Parameters)), (Asn1Encodable) new DerOctetString(encoded1));
      case CmcePublicKeyParameters publicKeyParameters4:
        byte[] encoded2 = publicKeyParameters4.GetEncoded();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.McElieceOidLookup(publicKeyParameters4.Parameters)), (Asn1Encodable) new CmcePublicKey(encoded2));
      case SaberPublicKeyParameters publicKeyParameters5:
        byte[] encoded3 = publicKeyParameters5.GetEncoded();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.SaberOidLookup(publicKeyParameters5.Parameters)), (Asn1Encodable) new DerSequence((Asn1Encodable) new DerOctetString(encoded3)));
      case PicnicPublicKeyParameters publicKeyParameters6:
        byte[] encoded4 = publicKeyParameters6.GetEncoded();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.PicnicOidLookup(publicKeyParameters6.Parameters)), (Asn1Encodable) new DerOctetString(encoded4));
      case SikePublicKeyParameters publicKeyParameters7:
        byte[] encoded5 = publicKeyParameters7.GetEncoded();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.SikeOidLookup(publicKeyParameters7.Parameters)), (Asn1Encodable) new DerOctetString(encoded5));
      case FalconPublicKeyParameters publicKeyParameters8:
        byte[] encoded6 = publicKeyParameters8.GetEncoded();
        byte[] numArray = new byte[encoded6.Length + 1];
        numArray[0] = (byte) publicKeyParameters8.Parameters.LogN;
        Array.Copy((Array) encoded6, 0, (Array) numArray, 1, encoded6.Length);
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.FalconOidLookup(publicKeyParameters8.Parameters)), numArray);
      case KyberPublicKeyParameters publicKeyParameters9:
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.KyberOidLookup(publicKeyParameters9.Parameters)), (Asn1Encodable) new DerSequence(new Asn1EncodableVector(2)
        {
          (Asn1Encodable) new DerOctetString(publicKeyParameters9.T),
          (Asn1Encodable) new DerOctetString(publicKeyParameters9.Rho)
        }));
      case DilithiumPublicKeyParameters publicKeyParameters10:
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.DilithiumOidLookup(publicKeyParameters10.Parameters)), Arrays.Concatenate(publicKeyParameters10.Rho, publicKeyParameters10.T1));
      case BikePublicKeyParameters publicKeyParameters11:
        byte[] encoded7 = publicKeyParameters11.GetEncoded();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.BikeOidLookup(publicKeyParameters11.Parameters)), (Asn1Encodable) new DerOctetString(encoded7));
      case HqcPublicKeyParameters publicKeyParameters12:
        byte[] encoded8 = publicKeyParameters12.GetEncoded();
        return new SubjectPublicKeyInfo(new AlgorithmIdentifier(PqcUtilities.HqcOidLookup(publicKeyParameters12.Parameters)), (Asn1Encodable) new DerOctetString(encoded8));
      default:
        throw new ArgumentException("Class provided no convertible: " + Platform.GetTypeName((object) publicKey));
    }
  }
}
