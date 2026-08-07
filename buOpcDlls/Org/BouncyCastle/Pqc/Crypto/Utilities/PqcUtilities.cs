// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Utilities.PqcUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Pqc.Crypto.Bike;
using Org.BouncyCastle.Pqc.Crypto.Cmce;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using Org.BouncyCastle.Pqc.Crypto.Hqc;
using Org.BouncyCastle.Pqc.Crypto.Picnic;
using Org.BouncyCastle.Pqc.Crypto.Saber;
using Org.BouncyCastle.Pqc.Crypto.Sike;
using Org.BouncyCastle.Pqc.Crypto.SphincsPlus;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Utilities;

internal class PqcUtilities
{
  private static readonly Dictionary<CmceParameters, DerObjectIdentifier> mcElieceOids = new Dictionary<CmceParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, CmceParameters> mcElieceParams = new Dictionary<DerObjectIdentifier, CmceParameters>();
  private static readonly Dictionary<SaberParameters, DerObjectIdentifier> saberOids = new Dictionary<SaberParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, SaberParameters> saberParams = new Dictionary<DerObjectIdentifier, SaberParameters>();
  private static readonly Dictionary<PicnicParameters, DerObjectIdentifier> picnicOids = new Dictionary<PicnicParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, PicnicParameters> picnicParams = new Dictionary<DerObjectIdentifier, PicnicParameters>();
  private static readonly Dictionary<SikeParameters, DerObjectIdentifier> sikeOids = new Dictionary<SikeParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, SikeParameters> sikeParams = new Dictionary<DerObjectIdentifier, SikeParameters>();
  private static readonly Dictionary<KyberParameters, DerObjectIdentifier> kyberOids = new Dictionary<KyberParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, KyberParameters> kyberParams = new Dictionary<DerObjectIdentifier, KyberParameters>();
  private static readonly Dictionary<DilithiumParameters, DerObjectIdentifier> dilithiumOids = new Dictionary<DilithiumParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, DilithiumParameters> dilithiumParams = new Dictionary<DerObjectIdentifier, DilithiumParameters>();
  private static readonly Dictionary<FalconParameters, DerObjectIdentifier> falconOids = new Dictionary<FalconParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, FalconParameters> falconParams = new Dictionary<DerObjectIdentifier, FalconParameters>();
  private static readonly Dictionary<BikeParameters, DerObjectIdentifier> bikeOids = new Dictionary<BikeParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, BikeParameters> bikeParams = new Dictionary<DerObjectIdentifier, BikeParameters>();
  private static readonly Dictionary<HqcParameters, DerObjectIdentifier> hqcOids = new Dictionary<HqcParameters, DerObjectIdentifier>();
  private static readonly Dictionary<DerObjectIdentifier, HqcParameters> hqcParams = new Dictionary<DerObjectIdentifier, HqcParameters>();

  static PqcUtilities()
  {
    PqcUtilities.mcElieceOids[CmceParameters.mceliece348864r3] = BCObjectIdentifiers.mceliece348864_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece348864fr3] = BCObjectIdentifiers.mceliece348864f_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece460896r3] = BCObjectIdentifiers.mceliece460896_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece460896fr3] = BCObjectIdentifiers.mceliece460896f_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece6688128r3] = BCObjectIdentifiers.mceliece6688128_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece6688128fr3] = BCObjectIdentifiers.mceliece6688128f_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece6960119r3] = BCObjectIdentifiers.mceliece6960119_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece6960119fr3] = BCObjectIdentifiers.mceliece6960119f_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece8192128r3] = BCObjectIdentifiers.mceliece8192128_r3;
    PqcUtilities.mcElieceOids[CmceParameters.mceliece8192128fr3] = BCObjectIdentifiers.mceliece8192128f_r3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece348864_r3] = CmceParameters.mceliece348864r3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece348864f_r3] = CmceParameters.mceliece348864fr3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece460896_r3] = CmceParameters.mceliece460896r3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece460896f_r3] = CmceParameters.mceliece460896fr3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece6688128_r3] = CmceParameters.mceliece6688128r3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece6688128f_r3] = CmceParameters.mceliece6688128fr3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece6960119_r3] = CmceParameters.mceliece6960119r3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece6960119f_r3] = CmceParameters.mceliece6960119fr3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece8192128_r3] = CmceParameters.mceliece8192128r3;
    PqcUtilities.mcElieceParams[BCObjectIdentifiers.mceliece8192128f_r3] = CmceParameters.mceliece8192128fr3;
    PqcUtilities.saberOids[SaberParameters.lightsaberkem128r3] = BCObjectIdentifiers.lightsaberkem128r3;
    PqcUtilities.saberOids[SaberParameters.saberkem128r3] = BCObjectIdentifiers.saberkem128r3;
    PqcUtilities.saberOids[SaberParameters.firesaberkem128r3] = BCObjectIdentifiers.firesaberkem128r3;
    PqcUtilities.saberOids[SaberParameters.lightsaberkem192r3] = BCObjectIdentifiers.lightsaberkem192r3;
    PqcUtilities.saberOids[SaberParameters.saberkem192r3] = BCObjectIdentifiers.saberkem192r3;
    PqcUtilities.saberOids[SaberParameters.firesaberkem192r3] = BCObjectIdentifiers.firesaberkem192r3;
    PqcUtilities.saberOids[SaberParameters.lightsaberkem256r3] = BCObjectIdentifiers.lightsaberkem256r3;
    PqcUtilities.saberOids[SaberParameters.saberkem256r3] = BCObjectIdentifiers.saberkem256r3;
    PqcUtilities.saberOids[SaberParameters.firesaberkem256r3] = BCObjectIdentifiers.firesaberkem256r3;
    PqcUtilities.saberOids[SaberParameters.ulightsaberkemr3] = BCObjectIdentifiers.ulightsaberkemr3;
    PqcUtilities.saberOids[SaberParameters.usaberkemr3] = BCObjectIdentifiers.usaberkemr3;
    PqcUtilities.saberOids[SaberParameters.ufiresaberkemr3] = BCObjectIdentifiers.ufiresaberkemr3;
    PqcUtilities.saberOids[SaberParameters.lightsaberkem90sr3] = BCObjectIdentifiers.lightsaberkem90sr3;
    PqcUtilities.saberOids[SaberParameters.saberkem90sr3] = BCObjectIdentifiers.saberkem90sr3;
    PqcUtilities.saberOids[SaberParameters.firesaberkem90sr3] = BCObjectIdentifiers.firesaberkem90sr3;
    PqcUtilities.saberOids[SaberParameters.ulightsaberkem90sr3] = BCObjectIdentifiers.ulightsaberkem90sr3;
    PqcUtilities.saberOids[SaberParameters.usaberkem90sr3] = BCObjectIdentifiers.usaberkem90sr3;
    PqcUtilities.saberOids[SaberParameters.ufiresaberkem90sr3] = BCObjectIdentifiers.ufiresaberkem90sr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.lightsaberkem128r3] = SaberParameters.lightsaberkem128r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.saberkem128r3] = SaberParameters.saberkem128r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.firesaberkem128r3] = SaberParameters.firesaberkem128r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.lightsaberkem192r3] = SaberParameters.lightsaberkem192r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.saberkem192r3] = SaberParameters.saberkem192r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.firesaberkem192r3] = SaberParameters.firesaberkem192r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.lightsaberkem256r3] = SaberParameters.lightsaberkem256r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.saberkem256r3] = SaberParameters.saberkem256r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.firesaberkem256r3] = SaberParameters.firesaberkem256r3;
    PqcUtilities.saberParams[BCObjectIdentifiers.ulightsaberkemr3] = SaberParameters.ulightsaberkemr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.usaberkemr3] = SaberParameters.usaberkemr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.ufiresaberkemr3] = SaberParameters.ufiresaberkemr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.lightsaberkem90sr3] = SaberParameters.lightsaberkem90sr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.saberkem90sr3] = SaberParameters.saberkem90sr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.firesaberkem90sr3] = SaberParameters.firesaberkem90sr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.ulightsaberkem90sr3] = SaberParameters.ulightsaberkem90sr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.usaberkem90sr3] = SaberParameters.usaberkem90sr3;
    PqcUtilities.saberParams[BCObjectIdentifiers.ufiresaberkem90sr3] = SaberParameters.ufiresaberkem90sr3;
    PqcUtilities.picnicOids[PicnicParameters.picnicl1fs] = BCObjectIdentifiers.picnicl1fs;
    PqcUtilities.picnicOids[PicnicParameters.picnicl1ur] = BCObjectIdentifiers.picnicl1ur;
    PqcUtilities.picnicOids[PicnicParameters.picnicl3fs] = BCObjectIdentifiers.picnicl3fs;
    PqcUtilities.picnicOids[PicnicParameters.picnicl3ur] = BCObjectIdentifiers.picnicl3ur;
    PqcUtilities.picnicOids[PicnicParameters.picnicl5fs] = BCObjectIdentifiers.picnicl5fs;
    PqcUtilities.picnicOids[PicnicParameters.picnicl5ur] = BCObjectIdentifiers.picnicl5ur;
    PqcUtilities.picnicOids[PicnicParameters.picnic3l1] = BCObjectIdentifiers.picnic3l1;
    PqcUtilities.picnicOids[PicnicParameters.picnic3l3] = BCObjectIdentifiers.picnic3l3;
    PqcUtilities.picnicOids[PicnicParameters.picnic3l5] = BCObjectIdentifiers.picnic3l5;
    PqcUtilities.picnicOids[PicnicParameters.picnicl1full] = BCObjectIdentifiers.picnicl1full;
    PqcUtilities.picnicOids[PicnicParameters.picnicl3full] = BCObjectIdentifiers.picnicl3full;
    PqcUtilities.picnicOids[PicnicParameters.picnicl5full] = BCObjectIdentifiers.picnicl5full;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl1fs] = PicnicParameters.picnicl1fs;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl1ur] = PicnicParameters.picnicl1ur;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl3fs] = PicnicParameters.picnicl3fs;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl3ur] = PicnicParameters.picnicl3ur;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl5fs] = PicnicParameters.picnicl5fs;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl5ur] = PicnicParameters.picnicl5ur;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnic3l1] = PicnicParameters.picnic3l1;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnic3l3] = PicnicParameters.picnic3l3;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnic3l5] = PicnicParameters.picnic3l5;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl1full] = PicnicParameters.picnicl1full;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl3full] = PicnicParameters.picnicl3full;
    PqcUtilities.picnicParams[BCObjectIdentifiers.picnicl5full] = PicnicParameters.picnicl5full;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep434] = SikeParameters.sikep434;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep503] = SikeParameters.sikep503;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep610] = SikeParameters.sikep610;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep751] = SikeParameters.sikep751;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep434_compressed] = SikeParameters.sikep434_compressed;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep503_compressed] = SikeParameters.sikep503_compressed;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep610_compressed] = SikeParameters.sikep610_compressed;
    PqcUtilities.sikeParams[BCObjectIdentifiers.sikep751_compressed] = SikeParameters.sikep751_compressed;
    PqcUtilities.sikeOids[SikeParameters.sikep434] = BCObjectIdentifiers.sikep434;
    PqcUtilities.sikeOids[SikeParameters.sikep503] = BCObjectIdentifiers.sikep503;
    PqcUtilities.sikeOids[SikeParameters.sikep610] = BCObjectIdentifiers.sikep610;
    PqcUtilities.sikeOids[SikeParameters.sikep751] = BCObjectIdentifiers.sikep751;
    PqcUtilities.sikeOids[SikeParameters.sikep434_compressed] = BCObjectIdentifiers.sikep434_compressed;
    PqcUtilities.sikeOids[SikeParameters.sikep503_compressed] = BCObjectIdentifiers.sikep503_compressed;
    PqcUtilities.sikeOids[SikeParameters.sikep610_compressed] = BCObjectIdentifiers.sikep610_compressed;
    PqcUtilities.sikeOids[SikeParameters.sikep751_compressed] = BCObjectIdentifiers.sikep751_compressed;
    PqcUtilities.kyberOids[KyberParameters.kyber512] = BCObjectIdentifiers.kyber512;
    PqcUtilities.kyberOids[KyberParameters.kyber768] = BCObjectIdentifiers.kyber768;
    PqcUtilities.kyberOids[KyberParameters.kyber1024] = BCObjectIdentifiers.kyber1024;
    PqcUtilities.kyberOids[KyberParameters.kyber512_aes] = BCObjectIdentifiers.kyber512_aes;
    PqcUtilities.kyberOids[KyberParameters.kyber768_aes] = BCObjectIdentifiers.kyber768_aes;
    PqcUtilities.kyberOids[KyberParameters.kyber1024_aes] = BCObjectIdentifiers.kyber1024_aes;
    PqcUtilities.kyberParams[BCObjectIdentifiers.kyber512] = KyberParameters.kyber512;
    PqcUtilities.kyberParams[BCObjectIdentifiers.kyber768] = KyberParameters.kyber768;
    PqcUtilities.kyberParams[BCObjectIdentifiers.kyber1024] = KyberParameters.kyber1024;
    PqcUtilities.kyberParams[BCObjectIdentifiers.kyber512_aes] = KyberParameters.kyber512_aes;
    PqcUtilities.kyberParams[BCObjectIdentifiers.kyber768_aes] = KyberParameters.kyber768_aes;
    PqcUtilities.kyberParams[BCObjectIdentifiers.kyber1024_aes] = KyberParameters.kyber1024_aes;
    PqcUtilities.falconOids[FalconParameters.falcon_512] = BCObjectIdentifiers.falcon_512;
    PqcUtilities.falconOids[FalconParameters.falcon_1024] = BCObjectIdentifiers.falcon_1024;
    PqcUtilities.falconParams[BCObjectIdentifiers.falcon_512] = FalconParameters.falcon_512;
    PqcUtilities.falconParams[BCObjectIdentifiers.falcon_1024] = FalconParameters.falcon_1024;
    PqcUtilities.dilithiumOids[DilithiumParameters.Dilithium2] = BCObjectIdentifiers.dilithium2;
    PqcUtilities.dilithiumOids[DilithiumParameters.Dilithium3] = BCObjectIdentifiers.dilithium3;
    PqcUtilities.dilithiumOids[DilithiumParameters.Dilithium5] = BCObjectIdentifiers.dilithium5;
    PqcUtilities.dilithiumOids[DilithiumParameters.Dilithium2Aes] = BCObjectIdentifiers.dilithium2_aes;
    PqcUtilities.dilithiumOids[DilithiumParameters.Dilithium3Aes] = BCObjectIdentifiers.dilithium3_aes;
    PqcUtilities.dilithiumOids[DilithiumParameters.Dilithium5Aes] = BCObjectIdentifiers.dilithium5_aes;
    PqcUtilities.dilithiumParams[BCObjectIdentifiers.dilithium2] = DilithiumParameters.Dilithium2;
    PqcUtilities.dilithiumParams[BCObjectIdentifiers.dilithium3] = DilithiumParameters.Dilithium3;
    PqcUtilities.dilithiumParams[BCObjectIdentifiers.dilithium5] = DilithiumParameters.Dilithium5;
    PqcUtilities.dilithiumParams[BCObjectIdentifiers.dilithium2_aes] = DilithiumParameters.Dilithium2Aes;
    PqcUtilities.dilithiumParams[BCObjectIdentifiers.dilithium3_aes] = DilithiumParameters.Dilithium3Aes;
    PqcUtilities.dilithiumParams[BCObjectIdentifiers.dilithium5_aes] = DilithiumParameters.Dilithium5Aes;
    PqcUtilities.bikeParams[BCObjectIdentifiers.bike128] = BikeParameters.bike128;
    PqcUtilities.bikeParams[BCObjectIdentifiers.bike192] = BikeParameters.bike192;
    PqcUtilities.bikeParams[BCObjectIdentifiers.bike256] = BikeParameters.bike256;
    PqcUtilities.bikeOids[BikeParameters.bike128] = BCObjectIdentifiers.bike128;
    PqcUtilities.bikeOids[BikeParameters.bike192] = BCObjectIdentifiers.bike192;
    PqcUtilities.bikeOids[BikeParameters.bike256] = BCObjectIdentifiers.bike256;
    PqcUtilities.hqcParams[BCObjectIdentifiers.hqc128] = HqcParameters.hqc128;
    PqcUtilities.hqcParams[BCObjectIdentifiers.hqc192] = HqcParameters.hqc192;
    PqcUtilities.hqcParams[BCObjectIdentifiers.hqc256] = HqcParameters.hqc256;
    PqcUtilities.hqcOids[HqcParameters.hqc128] = BCObjectIdentifiers.hqc128;
    PqcUtilities.hqcOids[HqcParameters.hqc192] = BCObjectIdentifiers.hqc192;
    PqcUtilities.hqcOids[HqcParameters.hqc256] = BCObjectIdentifiers.hqc256;
  }

  internal static DerObjectIdentifier McElieceOidLookup(CmceParameters parameters)
  {
    return PqcUtilities.mcElieceOids[parameters];
  }

  internal static CmceParameters McElieceParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.mcElieceParams[oid];
  }

  internal static DerObjectIdentifier SaberOidLookup(SaberParameters parameters)
  {
    return PqcUtilities.saberOids[parameters];
  }

  internal static SaberParameters SaberParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.saberParams[oid];
  }

  internal static KyberParameters KyberParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.kyberParams[oid];
  }

  internal static DerObjectIdentifier KyberOidLookup(KyberParameters parameters)
  {
    return PqcUtilities.kyberOids[parameters];
  }

  internal static FalconParameters FalconParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.falconParams[oid];
  }

  internal static DerObjectIdentifier FalconOidLookup(FalconParameters parameters)
  {
    return PqcUtilities.falconOids[parameters];
  }

  internal static DilithiumParameters DilithiumParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.dilithiumParams[oid];
  }

  internal static DerObjectIdentifier DilithiumOidLookup(DilithiumParameters parameters)
  {
    return PqcUtilities.dilithiumOids[parameters];
  }

  internal static DerObjectIdentifier SphincsPlusOidLookup(SphincsPlusParameters parameters)
  {
    int id = SphincsPlusParameters.GetID(parameters);
    if ((id & 131072 /*0x020000*/) == 131072 /*0x020000*/)
      return BCObjectIdentifiers.sphincsPlus_shake_256;
    return (id & 5) != 5 && (id & 6) != 6 ? BCObjectIdentifiers.sphincsPlus_sha_256 : BCObjectIdentifiers.sphincsPlus_sha_512;
  }

  internal static DerObjectIdentifier PicnicOidLookup(PicnicParameters parameters)
  {
    return PqcUtilities.picnicOids[parameters];
  }

  internal static PicnicParameters PicnicParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.picnicParams[oid];
  }

  internal static DerObjectIdentifier SikeOidLookup(SikeParameters parameters)
  {
    return PqcUtilities.sikeOids[parameters];
  }

  internal static SikeParameters SikeParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.sikeParams[oid];
  }

  internal static DerObjectIdentifier BikeOidLookup(BikeParameters parameters)
  {
    return PqcUtilities.bikeOids[parameters];
  }

  internal static BikeParameters BikeParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.bikeParams[oid];
  }

  internal static DerObjectIdentifier HqcOidLookup(HqcParameters parameters)
  {
    return PqcUtilities.hqcOids[parameters];
  }

  internal static HqcParameters HqcParamsLookup(DerObjectIdentifier oid)
  {
    return PqcUtilities.hqcParams[oid];
  }
}
