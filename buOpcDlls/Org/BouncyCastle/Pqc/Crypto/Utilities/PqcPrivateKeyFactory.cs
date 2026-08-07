// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Utilities.PqcPrivateKeyFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math;
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
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Utilities;

public static class PqcPrivateKeyFactory
{
  public static AsymmetricKeyParameter CreateKey(byte[] privateKeyInfoData)
  {
    return PqcPrivateKeyFactory.CreateKey(PrivateKeyInfo.GetInstance((object) Asn1Object.FromByteArray(privateKeyInfoData)));
  }

  public static AsymmetricKeyParameter CreateKey(Stream inStr)
  {
    return PqcPrivateKeyFactory.CreateKey(PrivateKeyInfo.GetInstance((object) new Asn1InputStream(inStr).ReadObject()));
  }

  public static AsymmetricKeyParameter CreateKey(PrivateKeyInfo keyInfo)
  {
    DerObjectIdentifier algorithm = keyInfo.PrivateKeyAlgorithm.Algorithm;
    if (algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdAlgHssLmsHashsig))
    {
      byte[] octets1 = Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
      DerBitString publicKeyData = keyInfo.PublicKeyData;
      if (Pack.BE_To_UInt32(octets1, 0) == 1U)
      {
        if (publicKeyData == null)
          return (AsymmetricKeyParameter) LmsPrivateKeyParameters.GetInstance((object) Arrays.CopyOfRange(octets1, 4, octets1.Length));
        byte[] octets2 = publicKeyData.GetOctets();
        return (AsymmetricKeyParameter) LmsPrivateKeyParameters.GetInstance(Arrays.CopyOfRange(octets1, 4, octets1.Length), Arrays.CopyOfRange(octets2, 4, octets2.Length));
      }
    }
    if (algorithm.On(BCObjectIdentifiers.pqc_kem_mceliece))
    {
      CmcePrivateKey instance = CmcePrivateKey.GetInstance((object) keyInfo.ParsePrivateKey());
      return (AsymmetricKeyParameter) new CmcePrivateKeyParameters(PqcUtilities.McElieceParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), instance.Delta, instance.C, instance.G, instance.Alpha, instance.S);
    }
    if (algorithm.On(BCObjectIdentifiers.sphincsPlus))
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
      return (AsymmetricKeyParameter) new SphincsPlusPrivateKeyParameters(SphincsPlusParameters.GetParams(BigInteger.ValueOf((long) Pack.BE_To_UInt32(octets, 0)).IntValue), Arrays.CopyOfRange(octets, 4, octets.Length));
    }
    if (algorithm.On(BCObjectIdentifiers.pqc_kem_saber))
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
      return (AsymmetricKeyParameter) new SaberPrivateKeyParameters(PqcUtilities.SaberParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets);
    }
    if (algorithm.On(BCObjectIdentifiers.picnic))
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
      return (AsymmetricKeyParameter) new PicnicPrivateKeyParameters(PqcUtilities.PicnicParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets);
    }
    if (algorithm.On(BCObjectIdentifiers.pqc_kem_sike))
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
      return (AsymmetricKeyParameter) new SikePrivateKeyParameters(PqcUtilities.SikeParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets);
    }
    if (algorithm.On(BCObjectIdentifiers.pqc_kem_bike))
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
      BikeParameters bikeParameters = PqcUtilities.BikeParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
      byte[] h0 = Arrays.CopyOfRange(octets, 0, bikeParameters.RByte);
      byte[] h1 = Arrays.CopyOfRange(octets, bikeParameters.RByte, 2 * bikeParameters.RByte);
      byte[] sigma = Arrays.CopyOfRange(octets, 2 * bikeParameters.RByte, octets.Length);
      return (AsymmetricKeyParameter) new BikePrivateKeyParameters(bikeParameters, h0, h1, sigma);
    }
    if (algorithm.On(BCObjectIdentifiers.pqc_kem_hqc))
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePrivateKey()).GetOctets();
      return (AsymmetricKeyParameter) new HqcPrivateKeyParameters(PqcUtilities.HqcParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm), octets);
    }
    if (!algorithm.Equals((Asn1Object) BCObjectIdentifiers.kyber512) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.kyber512_aes) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.kyber768) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.kyber768_aes) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.kyber1024) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.kyber1024_aes))
    {
      if (!algorithm.Equals((Asn1Object) BCObjectIdentifiers.dilithium2) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.dilithium3) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.dilithium5) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.dilithium2_aes) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.dilithium3_aes) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.dilithium5_aes))
      {
        if (!algorithm.Equals((Asn1Object) BCObjectIdentifiers.falcon_512) && !algorithm.Equals((Asn1Object) BCObjectIdentifiers.falcon_1024))
          throw new Exception("algorithm identifier in private key not recognised");
        Asn1Sequence instance = Asn1Sequence.GetInstance((object) keyInfo.ParsePrivateKey());
        FalconParameters parameters = PqcUtilities.FalconParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
        DerBitString publicKeyData = keyInfo.PublicKeyData;
        int intValue = DerInteger.GetInstance((object) instance[0]).Value.IntValue;
        if (intValue != 1)
          throw new IOException("unknown private key version: " + intValue.ToString());
        return keyInfo.PublicKeyData != null ? (AsymmetricKeyParameter) new FalconPrivateKeyParameters(parameters, Asn1OctetString.GetInstance((object) instance[1]).GetOctets(), Asn1OctetString.GetInstance((object) instance[2]).GetOctets(), Asn1OctetString.GetInstance((object) instance[3]).GetOctets(), publicKeyData.GetOctets()) : (AsymmetricKeyParameter) new FalconPrivateKeyParameters(parameters, Asn1OctetString.GetInstance((object) instance[1]).GetOctets(), Asn1OctetString.GetInstance((object) instance[2]).GetOctets(), Asn1OctetString.GetInstance((object) instance[3]).GetOctets(), (byte[]) null);
      }
      Asn1Sequence instance1 = Asn1Sequence.GetInstance((object) keyInfo.ParsePrivateKey());
      DilithiumParameters parameters1 = PqcUtilities.DilithiumParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
      int intValue1 = DerInteger.GetInstance((object) instance1[0]).Value.IntValue;
      if (intValue1 != 0)
        throw new IOException("unknown private key version: " + intValue1.ToString());
      if (keyInfo.PublicKeyData == null)
        return (AsymmetricKeyParameter) new DilithiumPrivateKeyParameters(parameters1, DerBitString.GetInstance((object) instance1[1]).GetOctets(), DerBitString.GetInstance((object) instance1[2]).GetOctets(), DerBitString.GetInstance((object) instance1[3]).GetOctets(), DerBitString.GetInstance((object) instance1[4]).GetOctets(), DerBitString.GetInstance((object) instance1[5]).GetOctets(), DerBitString.GetInstance((object) instance1[6]).GetOctets(), (byte[]) null);
      Asn1Sequence instance2 = Asn1Sequence.GetInstance((object) keyInfo.PublicKeyData.GetOctets());
      return (AsymmetricKeyParameter) new DilithiumPrivateKeyParameters(parameters1, DerBitString.GetInstance((object) instance1[1]).GetOctets(), DerBitString.GetInstance((object) instance1[2]).GetOctets(), DerBitString.GetInstance((object) instance1[3]).GetOctets(), DerBitString.GetInstance((object) instance1[4]).GetOctets(), DerBitString.GetInstance((object) instance1[5]).GetOctets(), DerBitString.GetInstance((object) instance1[6]).GetOctets(), Asn1OctetString.GetInstance((object) instance2[1]).GetOctets());
    }
    Asn1Sequence instance3 = Asn1Sequence.GetInstance((object) keyInfo.ParsePrivateKey());
    KyberParameters parameters2 = PqcUtilities.KyberParamsLookup(keyInfo.PrivateKeyAlgorithm.Algorithm);
    int intValue2 = DerInteger.GetInstance((object) instance3[0]).Value.IntValue;
    if (intValue2 != 0)
      throw new IOException("unknown private key version: " + intValue2.ToString());
    if (keyInfo.PublicKeyData == null)
      return (AsymmetricKeyParameter) new KyberPrivateKeyParameters(parameters2, Asn1OctetString.GetInstance((object) instance3[1]).GetOctets(), Asn1OctetString.GetInstance((object) instance3[2]).GetOctets(), Asn1OctetString.GetInstance((object) instance3[3]).GetOctets(), (byte[]) null, (byte[]) null);
    Asn1Sequence instance4 = Asn1Sequence.GetInstance((object) keyInfo.PublicKeyData.GetOctets());
    return (AsymmetricKeyParameter) new KyberPrivateKeyParameters(parameters2, Asn1OctetString.GetInstance((object) instance3[1]).GetDerEncoded(), Asn1OctetString.GetInstance((object) instance3[2]).GetOctets(), Asn1OctetString.GetInstance((object) instance3[3]).GetOctets(), Asn1OctetString.GetInstance((object) instance4[0]).GetOctets(), Asn1OctetString.GetInstance((object) instance4[1]).GetOctets());
  }
}
