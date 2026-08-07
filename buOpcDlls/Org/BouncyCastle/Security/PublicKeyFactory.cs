// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.PublicKeyFactory
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
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class PublicKeyFactory
{
  public static AsymmetricKeyParameter CreateKey(byte[] keyInfoData)
  {
    return PublicKeyFactory.CreateKey(SubjectPublicKeyInfo.GetInstance((object) Asn1Object.FromByteArray(keyInfoData)));
  }

  public static AsymmetricKeyParameter CreateKey(Stream inStr)
  {
    return PublicKeyFactory.CreateKey(SubjectPublicKeyInfo.GetInstance((object) Asn1Object.FromStream(inStr)));
  }

  public static AsymmetricKeyParameter CreateKey(SubjectPublicKeyInfo keyInfo)
  {
    AlgorithmIdentifier algorithmId = keyInfo.AlgorithmID;
    DerObjectIdentifier algorithm = algorithmId.Algorithm;
    if (!algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.RsaEncryption) && !algorithm.Equals((Asn1Object) X509ObjectIdentifiers.IdEARsa) && !algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsassaPss) && !algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsaesOaep))
    {
      if (algorithm.Equals((Asn1Object) X9ObjectIdentifiers.DHPublicNumber))
      {
        Asn1Sequence instance1 = Asn1Sequence.GetInstance((object) algorithmId.Parameters.ToAsn1Object());
        BigInteger y = DHPublicKey.GetInstance((object) keyInfo.ParsePublicKey()).Y.Value;
        if (PublicKeyFactory.IsPkcsDHParam(instance1))
          return (AsymmetricKeyParameter) PublicKeyFactory.ReadPkcsDHParam(algorithm, y, instance1);
        DHDomainParameters instance2 = DHDomainParameters.GetInstance((object) instance1);
        BigInteger p = instance2.P.Value;
        BigInteger g = instance2.G.Value;
        BigInteger q = instance2.Q.Value;
        BigInteger j = (BigInteger) null;
        if (instance2.J != null)
          j = instance2.J.Value;
        DHValidationParameters validation = (DHValidationParameters) null;
        DHValidationParms validationParms = instance2.ValidationParms;
        if (validationParms != null)
          validation = new DHValidationParameters(validationParms.Seed.GetBytes(), validationParms.PgenCounter.Value.IntValue);
        return (AsymmetricKeyParameter) new DHPublicKeyParameters(y, new DHParameters(p, g, q, j, validation));
      }
      if (algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.DhKeyAgreement))
      {
        Asn1Sequence instance = Asn1Sequence.GetInstance((object) algorithmId.Parameters.ToAsn1Object());
        DerInteger publicKey = (DerInteger) keyInfo.ParsePublicKey();
        return (AsymmetricKeyParameter) PublicKeyFactory.ReadPkcsDHParam(algorithm, publicKey.Value, instance);
      }
      if (algorithm.Equals((Asn1Object) OiwObjectIdentifiers.ElGamalAlgorithm))
      {
        ElGamalParameter elGamalParameter = new ElGamalParameter(Asn1Sequence.GetInstance((object) algorithmId.Parameters.ToAsn1Object()));
        return (AsymmetricKeyParameter) new ElGamalPublicKeyParameters(((DerInteger) keyInfo.ParsePublicKey()).Value, new ElGamalParameters(elGamalParameter.P, elGamalParameter.G));
      }
      if (!algorithm.Equals((Asn1Object) X9ObjectIdentifiers.IdDsa) && !algorithm.Equals((Asn1Object) OiwObjectIdentifiers.DsaWithSha1))
      {
        if (algorithm.Equals((Asn1Object) X9ObjectIdentifiers.IdECPublicKey))
        {
          X962Parameters instance = X962Parameters.GetInstance((object) algorithmId.Parameters.ToAsn1Object());
          X9ECParameters x9 = !instance.IsNamedCurve ? new X9ECParameters((Asn1Sequence) instance.Parameters) : ECKeyPairGenerator.FindECCurveByOid((DerObjectIdentifier) instance.Parameters);
          Asn1OctetString s = (Asn1OctetString) new DerOctetString(keyInfo.PublicKeyData.GetBytes());
          ECPoint point = new X9ECPoint(x9.Curve, s).Point;
          if (instance.IsNamedCurve)
            return (AsymmetricKeyParameter) new ECPublicKeyParameters("EC", point, (DerObjectIdentifier) instance.Parameters);
          ECDomainParameters parameters = new ECDomainParameters(x9);
          return (AsymmetricKeyParameter) new ECPublicKeyParameters(point, parameters);
        }
        if (algorithm.Equals((Asn1Object) CryptoProObjectIdentifiers.GostR3410x2001))
        {
          DerObjectIdentifier publicKeyParamSet = Gost3410PublicKeyAlgParameters.GetInstance((object) algorithmId.Parameters).PublicKeyParamSet;
          X9ECParameters byOid = ECGost3410NamedCurves.GetByOid(publicKeyParamSet);
          if (byOid == null)
            return (AsymmetricKeyParameter) null;
          Asn1OctetString publicKey;
          try
          {
            publicKey = (Asn1OctetString) keyInfo.ParsePublicKey();
          }
          catch (IOException ex)
          {
            throw new ArgumentException("error recovering GOST3410_2001 public key", (Exception) ex);
          }
          int num1 = 32 /*0x20*/;
          int num2 = 64 /*0x40*/;
          byte[] octets = publicKey.GetOctets();
          if (octets.Length != 64 /*0x40*/)
            throw new ArgumentException("invalid length for GOST3410_2001 public key");
          byte[] encoded = new byte[1 + num2];
          encoded[0] = (byte) 4;
          for (int index = 1; index <= num1; ++index)
          {
            encoded[index] = octets[num1 - index];
            encoded[index + num1] = octets[num2 - index];
          }
          return (AsymmetricKeyParameter) new ECPublicKeyParameters("ECGOST3410", byOid.Curve.DecodePoint(encoded), publicKeyParamSet);
        }
        if (algorithm.Equals((Asn1Object) CryptoProObjectIdentifiers.GostR3410x94))
        {
          Gost3410PublicKeyAlgParameters instance = Gost3410PublicKeyAlgParameters.GetInstance((object) algorithmId.Parameters);
          Asn1OctetString publicKey;
          try
          {
            publicKey = (Asn1OctetString) keyInfo.ParsePublicKey();
          }
          catch (IOException ex)
          {
            throw new ArgumentException("error recovering GOST3410_94 public key", (Exception) ex);
          }
          return (AsymmetricKeyParameter) new Gost3410PublicKeyParameters(new BigInteger(1, Arrays.Reverse(publicKey.GetOctets())), instance.PublicKeyParamSet);
        }
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_X25519) || algorithm.Equals((Asn1Object) CryptlibObjectIdentifiers.curvey25519))
          return (AsymmetricKeyParameter) new X25519PublicKeyParameters(PublicKeyFactory.GetRawKey(keyInfo));
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_X448))
          return (AsymmetricKeyParameter) new X448PublicKeyParameters(PublicKeyFactory.GetRawKey(keyInfo));
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_Ed25519) || algorithm.Equals((Asn1Object) GnuObjectIdentifiers.Ed25519))
          return (AsymmetricKeyParameter) new Ed25519PublicKeyParameters(PublicKeyFactory.GetRawKey(keyInfo));
        if (algorithm.Equals((Asn1Object) EdECObjectIdentifiers.id_Ed448))
          return (AsymmetricKeyParameter) new Ed448PublicKeyParameters(PublicKeyFactory.GetRawKey(keyInfo));
        if (!algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_agreement_gost_3410_12_256) && !algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_agreement_gost_3410_12_512))
          throw new SecurityUtilityException("algorithm identifier in public key not recognised: " + algorithm?.ToString());
        Gost3410PublicKeyAlgParameters instance3 = Gost3410PublicKeyAlgParameters.GetInstance((object) algorithmId.Parameters);
        DerObjectIdentifier publicKeyParamSet1 = instance3.PublicKeyParamSet;
        ECGost3410Parameters parameters1 = new ECGost3410Parameters(new ECNamedDomainParameters(publicKeyParamSet1, ECGost3410NamedCurves.GetByOid(publicKeyParamSet1)), publicKeyParamSet1, instance3.DigestParamSet, instance3.EncryptionParamSet);
        Asn1OctetString publicKey1;
        try
        {
          publicKey1 = (Asn1OctetString) keyInfo.ParsePublicKey();
        }
        catch (IOException ex)
        {
          throw new ArgumentException("error recovering GOST3410_2012 public key", (Exception) ex);
        }
        int num3 = 32 /*0x20*/;
        if (algorithm.Equals((Asn1Object) RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512))
          num3 = 64 /*0x40*/;
        int num4 = 2 * num3;
        byte[] octets1 = publicKey1.GetOctets();
        if (octets1.Length != num4)
          throw new ArgumentException("invalid length for GOST3410_2012 public key");
        byte[] encoded1 = new byte[1 + num4];
        encoded1[0] = (byte) 4;
        for (int index = 1; index <= num3; ++index)
        {
          encoded1[index] = octets1[num3 - index];
          encoded1[index + num3] = octets1[num4 - index];
        }
        return (AsymmetricKeyParameter) new ECPublicKeyParameters(parameters1.Curve.DecodePoint(encoded1), (ECDomainParameters) parameters1);
      }
      DerInteger publicKey2 = (DerInteger) keyInfo.ParsePublicKey();
      Asn1Encodable parameters2 = algorithmId.Parameters;
      DsaParameters parameters3 = (DsaParameters) null;
      if (parameters2 != null)
      {
        DsaParameter instance = DsaParameter.GetInstance((object) parameters2.ToAsn1Object());
        parameters3 = new DsaParameters(instance.P, instance.Q, instance.G);
      }
      return (AsymmetricKeyParameter) new DsaPublicKeyParameters(publicKey2.Value, parameters3);
    }
    RsaPublicKeyStructure instance4 = RsaPublicKeyStructure.GetInstance((object) keyInfo.ParsePublicKey());
    return (AsymmetricKeyParameter) new RsaKeyParameters(false, instance4.Modulus, instance4.PublicExponent);
  }

  private static byte[] GetRawKey(SubjectPublicKeyInfo keyInfo)
  {
    return keyInfo.PublicKeyData.GetOctets();
  }

  private static bool IsPkcsDHParam(Asn1Sequence seq)
  {
    if (seq.Count == 2)
      return true;
    return seq.Count <= 3 && DerInteger.GetInstance((object) seq[2]).Value.CompareTo(BigInteger.ValueOf((long) DerInteger.GetInstance((object) seq[0]).Value.BitLength)) <= 0;
  }

  private static DHPublicKeyParameters ReadPkcsDHParam(
    DerObjectIdentifier algOid,
    BigInteger y,
    Asn1Sequence seq)
  {
    DHParameter dhParameter = new DHParameter(seq);
    BigInteger l = dhParameter.L;
    int intValue = l == null ? 0 : l.IntValue;
    DHParameters parameters = new DHParameters(dhParameter.P, dhParameter.G, (BigInteger) null, intValue);
    return new DHPublicKeyParameters(y, parameters, algOid);
  }
}
