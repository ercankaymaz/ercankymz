// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Utilities.PqcPublicKeyFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;
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
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Utilities;

public static class PqcPublicKeyFactory
{
  private static Dictionary<DerObjectIdentifier, PqcPublicKeyFactory.SubjectPublicKeyInfoConverter> Converters = new Dictionary<DerObjectIdentifier, PqcPublicKeyFactory.SubjectPublicKeyInfoConverter>();

  static PqcPublicKeyFactory()
  {
    PqcPublicKeyFactory.Converters[PkcsObjectIdentifiers.IdAlgHssLmsHashsig] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.LmsConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sphincsPlus] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SphincsPlusConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sphincsPlus_shake_256] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SphincsPlusConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sphincsPlus_sha_256] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SphincsPlusConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sphincsPlus_sha_512] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SphincsPlusConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece348864_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece348864f_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece460896_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece460896f_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece6688128_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece6688128f_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece6960119_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece6960119f_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece8192128_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.mceliece8192128f_r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.CmceConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.lightsaberkem128r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.saberkem128r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.firesaberkem128r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.lightsaberkem192r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.saberkem192r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.firesaberkem192r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.lightsaberkem256r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.saberkem256r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.firesaberkem256r3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.ulightsaberkemr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.usaberkemr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.ufiresaberkemr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.lightsaberkem90sr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.saberkem90sr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.firesaberkem90sr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.ulightsaberkem90sr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.usaberkem90sr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.ufiresaberkem90sr3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SaberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnic] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl1fs] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl1ur] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl3fs] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl3ur] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl5fs] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl5ur] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnic3l1] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnic3l3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnic3l5] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl1full] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl3full] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.picnicl5full] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.PicnicConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep434] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep503] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep610] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep751] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep434_compressed] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep503_compressed] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep610_compressed] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.sikep751_compressed] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.SikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.dilithium2] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.DilithiumConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.dilithium3] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.DilithiumConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.dilithium5] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.DilithiumConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.dilithium2_aes] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.DilithiumConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.dilithium3_aes] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.DilithiumConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.dilithium5_aes] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.DilithiumConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.falcon_512] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.FalconConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.falcon_1024] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.FalconConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.kyber512] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.KyberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.kyber512_aes] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.KyberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.kyber768] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.KyberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.kyber768_aes] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.KyberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.kyber1024] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.KyberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.kyber1024_aes] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.KyberConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.bike128] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.BikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.bike192] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.BikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.bike256] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.BikeConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.hqc128] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.HqcConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.hqc192] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.HqcConverter();
    PqcPublicKeyFactory.Converters[BCObjectIdentifiers.hqc256] = (PqcPublicKeyFactory.SubjectPublicKeyInfoConverter) new PqcPublicKeyFactory.HqcConverter();
  }

  public static AsymmetricKeyParameter CreateKey(byte[] keyInfoData)
  {
    return PqcPublicKeyFactory.CreateKey(SubjectPublicKeyInfo.GetInstance((object) Asn1Object.FromByteArray(keyInfoData)));
  }

  public static AsymmetricKeyParameter CreateKey(Stream inStr)
  {
    return PqcPublicKeyFactory.CreateKey(SubjectPublicKeyInfo.GetInstance((object) new Asn1InputStream(inStr).ReadObject()));
  }

  public static AsymmetricKeyParameter CreateKey(SubjectPublicKeyInfo keyInfo)
  {
    return PqcPublicKeyFactory.CreateKey(keyInfo, (object) null);
  }

  public static AsymmetricKeyParameter CreateKey(SubjectPublicKeyInfo keyInfo, object defaultParams)
  {
    AlgorithmIdentifier algorithmId = keyInfo.AlgorithmID;
    return (PqcPublicKeyFactory.Converters[algorithmId.Algorithm] ?? throw new IOException("algorithm identifier in public key not recognised: " + algorithmId.Algorithm?.ToString())).GetPublicKeyParameters(keyInfo, defaultParams);
  }

  private abstract class SubjectPublicKeyInfoConverter
  {
    internal abstract AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams);
  }

  private class LmsConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] numArray = Asn1OctetString.GetInstance((object) keyInfo.ParsePublicKey()).GetOctets();
      if (Pack.BE_To_UInt32(numArray, 0) == 1U)
        return (AsymmetricKeyParameter) LmsPublicKeyParameters.GetInstance((object) Arrays.CopyOfRange(numArray, 4, numArray.Length));
      if (numArray.Length == 64 /*0x40*/)
        numArray = Arrays.CopyOfRange(numArray, 4, numArray.Length);
      return (AsymmetricKeyParameter) HssPublicKeyParameters.GetInstance((object) numArray);
    }
  }

  private class SphincsPlusConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePublicKey()).GetOctets();
      return (AsymmetricKeyParameter) new SphincsPlusPublicKeyParameters(SphincsPlusParameters.GetParams((int) Pack.BE_To_UInt32(octets, 0)), Arrays.CopyOfRange(octets, 4, octets.Length));
    }
  }

  private class CmceConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] t = CmcePublicKey.GetInstance((object) keyInfo.ParsePublicKey()).T;
      return (AsymmetricKeyParameter) new CmcePublicKeyParameters(PqcUtilities.McElieceParamsLookup(keyInfo.AlgorithmID.Algorithm), t);
    }
  }

  private class SaberConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] octets = Asn1OctetString.GetInstance((object) Asn1Sequence.GetInstance((object) keyInfo.ParsePublicKey())[0]).GetOctets();
      return (AsymmetricKeyParameter) new SaberPublicKeyParameters(PqcUtilities.SaberParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
    }
  }

  private class PicnicConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePublicKey()).GetOctets();
      return (AsymmetricKeyParameter) new PicnicPublicKeyParameters(PqcUtilities.PicnicParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
    }
  }

  [Obsolete("Will be removed")]
  private class SikeConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePublicKey()).GetOctets();
      return (AsymmetricKeyParameter) new SikePublicKeyParameters(PqcUtilities.SikeParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
    }
  }

  private class DilithiumConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      DilithiumParameters parameters = PqcUtilities.DilithiumParamsLookup(keyInfo.AlgorithmID.Algorithm);
      try
      {
        Asn1Object publicKey = keyInfo.ParsePublicKey();
        if (publicKey is Asn1Sequence)
        {
          Asn1Sequence instance = Asn1Sequence.GetInstance((object) publicKey);
          return (AsymmetricKeyParameter) new DilithiumPublicKeyParameters(parameters, Asn1OctetString.GetInstance((object) instance[0]).GetOctets(), Asn1OctetString.GetInstance((object) instance[1]).GetOctets());
        }
        byte[] octets = Asn1OctetString.GetInstance((object) publicKey).GetOctets();
        return (AsymmetricKeyParameter) new DilithiumPublicKeyParameters(parameters, octets);
      }
      catch (Exception ex)
      {
        return (AsymmetricKeyParameter) new DilithiumPublicKeyParameters(parameters, keyInfo.PublicKeyData.GetOctets());
      }
    }
  }

  private class KyberConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      KyberParameters parameters = PqcUtilities.KyberParamsLookup(keyInfo.AlgorithmID.Algorithm);
      Asn1Object publicKey = keyInfo.ParsePublicKey();
      if (publicKey is Asn1Sequence)
      {
        Asn1Sequence instance = Asn1Sequence.GetInstance((object) publicKey);
        return (AsymmetricKeyParameter) new KyberPublicKeyParameters(parameters, Asn1OctetString.GetInstance((object) instance[0]).GetOctets(), Asn1OctetString.GetInstance((object) instance[1]).GetOctets());
      }
      byte[] octets = Asn1OctetString.GetInstance((object) publicKey).GetOctets();
      return (AsymmetricKeyParameter) new KyberPublicKeyParameters(parameters, octets);
    }
  }

  private class FalconConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      FalconParameters parameters = PqcUtilities.FalconParamsLookup(keyInfo.AlgorithmID.Algorithm);
      try
      {
        Asn1Object publicKey = keyInfo.ParsePublicKey();
        if (publicKey is Asn1Sequence)
        {
          byte[] octets = Asn1OctetString.GetInstance((object) Asn1Sequence.GetInstance((object) publicKey)[0]).GetOctets();
          return (AsymmetricKeyParameter) new FalconPublicKeyParameters(parameters, octets);
        }
        byte[] octets1 = Asn1OctetString.GetInstance((object) publicKey).GetOctets();
        if ((int) octets1[0] != (int) (byte) parameters.LogN)
          throw new ArgumentException("byte[] enc of Falcon h value not tagged correctly");
        return (AsymmetricKeyParameter) new FalconPublicKeyParameters(parameters, Arrays.CopyOfRange(octets1, 1, octets1.Length));
      }
      catch (Exception ex)
      {
        byte[] octets = keyInfo.PublicKeyData.GetOctets();
        if ((int) octets[0] != (int) (byte) parameters.LogN)
          throw new ArgumentException("byte[] enc of Falcon h value not tagged correctly");
        return (AsymmetricKeyParameter) new FalconPublicKeyParameters(parameters, Arrays.CopyOfRange(octets, 1, octets.Length));
      }
    }
  }

  private class BikeConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePublicKey()).GetOctets();
      return (AsymmetricKeyParameter) new BikePublicKeyParameters(PqcUtilities.BikeParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
    }
  }

  private class HqcConverter : PqcPublicKeyFactory.SubjectPublicKeyInfoConverter
  {
    internal override AsymmetricKeyParameter GetPublicKeyParameters(
      SubjectPublicKeyInfo keyInfo,
      object defaultParams)
    {
      byte[] octets = Asn1OctetString.GetInstance((object) keyInfo.ParsePublicKey()).GetOctets();
      return (AsymmetricKeyParameter) new HqcPublicKeyParameters(PqcUtilities.HqcParamsLookup(keyInfo.AlgorithmID.Algorithm), octets);
    }
  }
}
