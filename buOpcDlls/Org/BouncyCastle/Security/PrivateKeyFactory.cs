// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.PrivateKeyFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cryptlib;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.Gnu;
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
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class PrivateKeyFactory
{
  public static AsymmetricKeyParameter CreateKey(byte[] privateKeyInfoData)
  {
    return PrivateKeyFactory.CreateKey(PrivateKeyInfo.GetInstance((object) Asn1Object.FromByteArray(privateKeyInfoData)));
  }

  public static AsymmetricKeyParameter CreateKey(Stream inStr)
  {
    return PrivateKeyFactory.CreateKey(PrivateKeyInfo.GetInstance((object) Asn1Object.FromStream(inStr)));
  }

  public static AsymmetricKeyParameter CreateKey(PrivateKeyInfo keyInfo)
  {
    AlgorithmIdentifier privateKeyAlgorithm = keyInfo.PrivateKeyAlgorithm;
    DerObjectIdentifier algorithm = privateKeyAlgorithm.Algorithm;
    if (!algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.RsaEncryption) && !algorithm.Equals((Asn1Object) X509ObjectIdentifiers.IdEARsa) && !algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsassaPss) && !algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsaesOaep))
    {
      if (algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.DhKeyAgreement))
      {
        DHParameter dhParameter = new DHParameter(Asn1Sequence.GetInstance((object) privateKeyAlgorithm.Parameters.ToAsn1Object()));
        DerInteger privateKey = (DerInteger) keyInfo.ParsePrivateKey();
        BigInteger l = dhParameter.L;
        int intValue = l == null ? 0 : l.IntValue;
        DHParameters parameters = new DHParameters(dhParameter.P, dhParameter.G, (BigInteger) null, intValue);
        return (AsymmetricKeyParameter) new DHPrivateKeyParameters(privateKey.Value, parameters, algorithm);
      }
      if (algorithm.Equals((Asn1Object) OiwObjectIdentifiers.ElGamalAlgorithm))
      {
        ElGamalParameter elGamalParameter = new ElGamalParameter(Asn1Sequence.GetInstance((object) privateKeyAlgorithm.Parameters.ToAsn1Object()));
        return (AsymmetricKeyParameter) new ElGamalPrivateKeyParameters(((DerInteger) keyInfo.ParsePrivateKey()).Value, new ElGamalParameters(elGamalParameter.P, elGamalParameter.G));
      }
      if (algorithm.Equals((Asn1Object) X9ObjectIdentifiers.IdDsa))
      {
        DerInteger privateKey = (DerInteger) keyInfo.ParsePrivateKey();
        Asn1Encodable parameters1 = privateKeyAlgorithm.Parameters;
        DsaParameters parameters2 = (DsaParameters) null;
        if (parameters1 != null)
        {
          DsaParameter instance = DsaParameter.GetInstance((object) parameters1.ToAsn1Object());
          parameters2 = new DsaParameters(instance.P, instance.Q, instance.G);
        }
        return (AsymmetricKeyParameter) new DsaPrivateKeyParameters(privateKey.Value, parameters2);
      }
      if (algorithm.Equals((Asn1Object) X9ObjectIdentifiers.IdECPublicKey))
      {
        X962Parameters instance = X962Parameters.GetInstance((object) privateKeyAlgorithm.Parameters.ToAsn1Object());
        X9ECParameters x9EcParameters = !instance.IsNamedCurve ? new X9ECParameters((Asn1Sequence) instance.Parameters) : ECKeyPairGenerator.FindECCurveByOid((DerObjectIdentifier) instance.Parameters);
        BigInteger key = ECPrivateKeyStructure.GetInstance((object) keyInfo.ParsePrivateKey()).GetKey();
        if (instance.IsNamedCurve)
          return (AsymmetricKeyParameter) new ECPrivateKeyParameters("EC", key, (DerObjectIdentifier) instance.Parameters);
        ECDomainParameters parameters = new ECDomainParameters(x9EcParameters.Curve, x9EcParameters.G, x9EcParameters.N, x9EcParameters.H, x9EcParameters.GetSeed());
        return (AsymmetricKeyParameter) new ECPrivateKeyParameters(key, parameters);
      }
      if (!algorithm.Equals((Asn1Object) CryptoProObjectIdentifiers.GostR3410x2001) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256))
      {
        if (algorithm.Equals((Asn1Object) CryptoProObjectIdentifiers.GostR3410x94))
        {
          Gost3410PublicKeyAlgParameters instance = Gost3410PublicKeyAlgParameters.GetInstance((object) privateKeyAlgorithm.Parameters);
          Asn1Object privateKey = keyInfo.ParsePrivateKey();
          return (AsymmetricKeyParameter) new Gost3410PrivateKeyParameters(!(privateKey is DerInteger) ? new BigInteger(1, Arrays.Reverse(Asn1OctetString.GetInstance((object) privateKey).GetOctets())) : DerInteger.GetInstance((object) privateKey).PositiveValue, instance.PublicKeyParamSet);
        }
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_X25519) || algorithm.Equals((Asn1Object) CryptlibObjectIdentifiers.curvey25519))
          return (AsymmetricKeyParameter) new X25519PrivateKeyParameters(PrivateKeyFactory.GetRawKey(keyInfo));
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_X448))
          return (AsymmetricKeyParameter) new X448PrivateKeyParameters(PrivateKeyFactory.GetRawKey(keyInfo));
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_Ed25519) || algorithm.Equals((Asn1Object) GnuObjectIdentifiers.Ed25519))
          return (AsymmetricKeyParameter) new Ed25519PrivateKeyParameters(PrivateKeyFactory.GetRawKey(keyInfo));
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_Ed448))
          return (AsymmetricKeyParameter) new Ed448PrivateKeyParameters(PrivateKeyFactory.GetRawKey(keyInfo));
        if (!algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_agreement_gost_3410_12_256) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_agreement_gost_3410_12_512))
          throw new SecurityUtilityException("algorithm identifier in private key not recognised");
        Gost3410PublicKeyAlgParameters instance1 = Gost3410PublicKeyAlgParameters.GetInstance((object) keyInfo.PrivateKeyAlgorithm.Parameters);
        Asn1Object asn1Object = keyInfo.PrivateKeyAlgorithm.Parameters.ToAsn1Object();
        ECGost3410Parameters dp;
        BigInteger d;
        if (asn1Object is Asn1Sequence && (Asn1Sequence.GetInstance((object) asn1Object).Count == 2 || Asn1Sequence.GetInstance((object) asn1Object).Count == 3))
        {
          X9ECParameters byOid = ECGost3410NamedCurves.GetByOid(instance1.PublicKeyParamSet);
          dp = new ECGost3410Parameters(new ECNamedDomainParameters(instance1.PublicKeyParamSet, byOid), instance1.PublicKeyParamSet, instance1.DigestParamSet, instance1.EncryptionParamSet);
          Asn1OctetString privateKeyData = keyInfo.PrivateKeyData;
          if (privateKeyData.GetOctets().Length != 32 /*0x20*/ && privateKeyData.GetOctets().Length != 64 /*0x40*/)
          {
            Asn1Encodable privateKey = (Asn1Encodable) keyInfo.ParsePrivateKey();
            d = !(privateKey is DerInteger) ? new BigInteger(1, Arrays.Reverse(Asn1OctetString.GetInstance((object) privateKey).GetOctets())) : DerInteger.GetInstance((object) privateKey).PositiveValue;
          }
          else
            d = new BigInteger(1, Arrays.Reverse(privateKeyData.GetOctets()));
        }
        else
        {
          X962Parameters instance2 = X962Parameters.GetInstance((object) keyInfo.PrivateKeyAlgorithm.Parameters);
          if (instance2.IsNamedCurve)
          {
            DerObjectIdentifier instance3 = DerObjectIdentifier.GetInstance((object) instance2.Parameters);
            dp = new ECGost3410Parameters(new ECNamedDomainParameters(instance3, ECKeyPairGenerator.FindECCurveByOid(instance3)), instance1.PublicKeyParamSet, instance1.DigestParamSet, instance1.EncryptionParamSet);
          }
          else if (instance2.IsImplicitlyCA)
          {
            dp = (ECGost3410Parameters) null;
          }
          else
          {
            X9ECParameters instance4 = X9ECParameters.GetInstance((object) instance2.Parameters);
            dp = new ECGost3410Parameters(new ECNamedDomainParameters(algorithm, instance4), instance1.PublicKeyParamSet, instance1.DigestParamSet, instance1.EncryptionParamSet);
          }
          Asn1Encodable privateKey = (Asn1Encodable) keyInfo.ParsePrivateKey();
          d = !(privateKey is DerInteger) ? ECPrivateKeyStructure.GetInstance((object) privateKey).GetKey() : DerInteger.GetInstance((object) privateKey).Value;
        }
        return (AsymmetricKeyParameter) new ECPrivateKeyParameters(d, (ECDomainParameters) new ECGost3410Parameters((ECNamedDomainParameters) dp, instance1.PublicKeyParamSet, instance1.DigestParamSet, instance1.EncryptionParamSet));
      }
      Asn1Object asn1Object1 = privateKeyAlgorithm.Parameters.ToAsn1Object();
      Gost3410PublicKeyAlgParameters instance5 = Gost3410PublicKeyAlgParameters.GetInstance((object) asn1Object1);
      ECGost3410Parameters dp1;
      BigInteger d1;
      if (asn1Object1 is Asn1Sequence asn1Sequence && (asn1Sequence.Count == 2 || asn1Sequence.Count == 3))
      {
        dp1 = new ECGost3410Parameters(new ECNamedDomainParameters(instance5.PublicKeyParamSet, ECGost3410NamedCurves.GetByOid(instance5.PublicKeyParamSet) ?? throw new ArgumentException("Unrecognized curve OID for GostR3410x2001 private key")), instance5.PublicKeyParamSet, instance5.DigestParamSet, instance5.EncryptionParamSet);
        Asn1OctetString privateKeyData = keyInfo.PrivateKeyData;
        if (privateKeyData.GetOctets().Length != 32 /*0x20*/ && privateKeyData.GetOctets().Length != 64 /*0x40*/)
        {
          Asn1Object privateKey = keyInfo.ParsePrivateKey();
          d1 = !(privateKey is DerInteger derInteger) ? new BigInteger(1, Arrays.Reverse(Asn1OctetString.GetInstance((object) privateKey).GetOctets())) : derInteger.PositiveValue;
        }
        else
          d1 = new BigInteger(1, Arrays.Reverse(privateKeyData.GetOctets()));
      }
      else
      {
        X962Parameters instance6 = X962Parameters.GetInstance((object) asn1Object1);
        if (instance6.IsNamedCurve)
        {
          DerObjectIdentifier instance7 = DerObjectIdentifier.GetInstance((object) instance6.Parameters);
          dp1 = new ECGost3410Parameters(new ECNamedDomainParameters(instance7, ECNamedCurveTable.GetByOid(instance7) ?? throw new ArgumentException("Unrecognized curve OID for GostR3410x2001 private key")), instance5.PublicKeyParamSet, instance5.DigestParamSet, instance5.EncryptionParamSet);
        }
        else if (instance6.IsImplicitlyCA)
        {
          dp1 = (ECGost3410Parameters) null;
        }
        else
        {
          X9ECParameters instance8 = X9ECParameters.GetInstance((object) instance6.Parameters);
          dp1 = new ECGost3410Parameters(new ECNamedDomainParameters(algorithm, instance8), instance5.PublicKeyParamSet, instance5.DigestParamSet, instance5.EncryptionParamSet);
        }
        Asn1Object privateKey = keyInfo.ParsePrivateKey();
        d1 = !(privateKey is DerInteger derInteger) ? ECPrivateKeyStructure.GetInstance((object) privateKey).GetKey() : derInteger.Value;
      }
      return (AsymmetricKeyParameter) new ECPrivateKeyParameters(d1, (ECDomainParameters) new ECGost3410Parameters((ECNamedDomainParameters) dp1, instance5.PublicKeyParamSet, instance5.DigestParamSet, instance5.EncryptionParamSet));
    }
    RsaPrivateKeyStructure instance9 = RsaPrivateKeyStructure.GetInstance((object) keyInfo.ParsePrivateKey());
    return (AsymmetricKeyParameter) new RsaPrivateCrtKeyParameters(instance9.Modulus, instance9.PublicExponent, instance9.PrivateExponent, instance9.Prime1, instance9.Prime2, instance9.Exponent1, instance9.Exponent2, instance9.Coefficient);
  }

  private static byte[] GetRawKey(PrivateKeyInfo keyInfo)
  {
    return Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
  }

  public static AsymmetricKeyParameter DecryptKey(
    char[] passPhrase,
    EncryptedPrivateKeyInfo encInfo)
  {
    return PrivateKeyFactory.CreateKey(PrivateKeyInfoFactory.CreatePrivateKeyInfo(passPhrase, encInfo));
  }

  public static AsymmetricKeyParameter DecryptKey(
    char[] passPhrase,
    byte[] encryptedPrivateKeyInfoData)
  {
    return PrivateKeyFactory.DecryptKey(passPhrase, Asn1Object.FromByteArray(encryptedPrivateKeyInfoData));
  }

  public static AsymmetricKeyParameter DecryptKey(
    char[] passPhrase,
    Stream encryptedPrivateKeyInfoStream)
  {
    return PrivateKeyFactory.DecryptKey(passPhrase, Asn1Object.FromStream(encryptedPrivateKeyInfoStream));
  }

  private static AsymmetricKeyParameter DecryptKey(char[] passPhrase, Asn1Object asn1Object)
  {
    return PrivateKeyFactory.DecryptKey(passPhrase, EncryptedPrivateKeyInfo.GetInstance((object) asn1Object));
  }

  public static byte[] EncryptKey(
    DerObjectIdentifier algorithm,
    char[] passPhrase,
    byte[] salt,
    int iterationCount,
    AsymmetricKeyParameter key)
  {
    return EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(algorithm, passPhrase, salt, iterationCount, key).GetEncoded();
  }

  public static byte[] EncryptKey(
    string algorithm,
    char[] passPhrase,
    byte[] salt,
    int iterationCount,
    AsymmetricKeyParameter key)
  {
    return EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(algorithm, passPhrase, salt, iterationCount, key).GetEncoded();
  }
}
