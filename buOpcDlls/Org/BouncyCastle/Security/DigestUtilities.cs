// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.DigestUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.UA;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class DigestUtilities
{
  private static readonly IDictionary<string, string> Aliases = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, DerObjectIdentifier> Oids = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static DigestUtilities()
  {
    Enums.GetArbitraryValue<DigestUtilities.DigestAlgorithm>().ToString();
    DigestUtilities.Aliases[PkcsObjectIdentifiers.MD2.Id] = "MD2";
    DigestUtilities.Aliases[PkcsObjectIdentifiers.MD4.Id] = "MD4";
    DigestUtilities.Aliases[PkcsObjectIdentifiers.MD5.Id] = "MD5";
    DigestUtilities.Aliases["SHA1"] = "SHA-1";
    DigestUtilities.Aliases[OiwObjectIdentifiers.IdSha1.Id] = "SHA-1";
    DigestUtilities.Aliases[PkcsObjectIdentifiers.IdHmacWithSha1.Id] = "SHA-1";
    DigestUtilities.Aliases[MiscObjectIdentifiers.HMAC_SHA1.Id] = "SHA-1";
    DigestUtilities.Aliases["SHA224"] = "SHA-224";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha224.Id] = "SHA-224";
    DigestUtilities.Aliases[PkcsObjectIdentifiers.IdHmacWithSha224.Id] = "SHA-224";
    DigestUtilities.Aliases["SHA256"] = "SHA-256";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha256.Id] = "SHA-256";
    DigestUtilities.Aliases[PkcsObjectIdentifiers.IdHmacWithSha256.Id] = "SHA-256";
    DigestUtilities.Aliases["SHA384"] = "SHA-384";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha384.Id] = "SHA-384";
    DigestUtilities.Aliases[PkcsObjectIdentifiers.IdHmacWithSha384.Id] = "SHA-384";
    DigestUtilities.Aliases["SHA512"] = "SHA-512";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha512.Id] = "SHA-512";
    DigestUtilities.Aliases[PkcsObjectIdentifiers.IdHmacWithSha512.Id] = "SHA-512";
    DigestUtilities.Aliases["SHA512/224"] = "SHA-512/224";
    DigestUtilities.Aliases["SHA512(224)"] = "SHA-512/224";
    DigestUtilities.Aliases["SHA-512(224)"] = "SHA-512/224";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha512_224.Id] = "SHA-512/224";
    DigestUtilities.Aliases["SHA512/256"] = "SHA-512/256";
    DigestUtilities.Aliases["SHA512(256)"] = "SHA-512/256";
    DigestUtilities.Aliases["SHA-512(256)"] = "SHA-512/256";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha512_256.Id] = "SHA-512/256";
    DigestUtilities.Aliases["RIPEMD-128"] = "RIPEMD128";
    DigestUtilities.Aliases[TeleTrusTObjectIdentifiers.RipeMD128.Id] = "RIPEMD128";
    DigestUtilities.Aliases["RIPEMD-160"] = "RIPEMD160";
    DigestUtilities.Aliases[TeleTrusTObjectIdentifiers.RipeMD160.Id] = "RIPEMD160";
    DigestUtilities.Aliases["RIPEMD-256"] = "RIPEMD256";
    DigestUtilities.Aliases[TeleTrusTObjectIdentifiers.RipeMD256.Id] = "RIPEMD256";
    DigestUtilities.Aliases["RIPEMD-320"] = "RIPEMD320";
    DigestUtilities.Aliases[CryptoProObjectIdentifiers.GostR3411.Id] = "GOST3411";
    DigestUtilities.Aliases["KECCAK224"] = "KECCAK-224";
    DigestUtilities.Aliases["KECCAK256"] = "KECCAK-256";
    DigestUtilities.Aliases["KECCAK288"] = "KECCAK-288";
    DigestUtilities.Aliases["KECCAK384"] = "KECCAK-384";
    DigestUtilities.Aliases["KECCAK512"] = "KECCAK-512";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha3_224.Id] = "SHA3-224";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdHMacWithSha3_224.Id] = "SHA3-224";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha3_256.Id] = "SHA3-256";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdHMacWithSha3_256.Id] = "SHA3-256";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha3_384.Id] = "SHA3-384";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdHMacWithSha3_384.Id] = "SHA3-384";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdSha3_512.Id] = "SHA3-512";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdHMacWithSha3_512.Id] = "SHA3-512";
    DigestUtilities.Aliases["SHAKE128"] = "SHAKE128-256";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdShake128.Id] = "SHAKE128-256";
    DigestUtilities.Aliases["SHAKE256"] = "SHAKE256-512";
    DigestUtilities.Aliases[NistObjectIdentifiers.IdShake256.Id] = "SHAKE256-512";
    DigestUtilities.Aliases[GMObjectIdentifiers.sm3.Id] = "SM3";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2b160.Id] = "BLAKE2B-160";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2b256.Id] = "BLAKE2B-256";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2b384.Id] = "BLAKE2B-384";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2b512.Id] = "BLAKE2B-512";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2s128.Id] = "BLAKE2S-128";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2s160.Id] = "BLAKE2S-160";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2s224.Id] = "BLAKE2S-224";
    DigestUtilities.Aliases[MiscObjectIdentifiers.id_blake2s256.Id] = "BLAKE2S-256";
    DigestUtilities.Aliases[MiscObjectIdentifiers.blake3_256.Id] = "BLAKE3-256";
    DigestUtilities.Aliases[RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256.Id] = "GOST3411-2012-256";
    DigestUtilities.Aliases[RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512.Id] = "GOST3411-2012-512";
    DigestUtilities.Aliases[UAObjectIdentifiers.dstu7564digest_256.Id] = "DSTU7564-256";
    DigestUtilities.Aliases[UAObjectIdentifiers.dstu7564digest_384.Id] = "DSTU7564-384";
    DigestUtilities.Aliases[UAObjectIdentifiers.dstu7564digest_512.Id] = "DSTU7564-512";
    DigestUtilities.Oids["MD2"] = PkcsObjectIdentifiers.MD2;
    DigestUtilities.Oids["MD4"] = PkcsObjectIdentifiers.MD4;
    DigestUtilities.Oids["MD5"] = PkcsObjectIdentifiers.MD5;
    DigestUtilities.Oids["SHA-1"] = OiwObjectIdentifiers.IdSha1;
    DigestUtilities.Oids["SHA-224"] = NistObjectIdentifiers.IdSha224;
    DigestUtilities.Oids["SHA-256"] = NistObjectIdentifiers.IdSha256;
    DigestUtilities.Oids["SHA-384"] = NistObjectIdentifiers.IdSha384;
    DigestUtilities.Oids["SHA-512"] = NistObjectIdentifiers.IdSha512;
    DigestUtilities.Oids["SHA-512/224"] = NistObjectIdentifiers.IdSha512_224;
    DigestUtilities.Oids["SHA-512/256"] = NistObjectIdentifiers.IdSha512_256;
    DigestUtilities.Oids["SHA3-224"] = NistObjectIdentifiers.IdSha3_224;
    DigestUtilities.Oids["SHA3-256"] = NistObjectIdentifiers.IdSha3_256;
    DigestUtilities.Oids["SHA3-384"] = NistObjectIdentifiers.IdSha3_384;
    DigestUtilities.Oids["SHA3-512"] = NistObjectIdentifiers.IdSha3_512;
    DigestUtilities.Oids["SHAKE128-256"] = NistObjectIdentifiers.IdShake128;
    DigestUtilities.Oids["SHAKE256-512"] = NistObjectIdentifiers.IdShake256;
    DigestUtilities.Oids["RIPEMD128"] = TeleTrusTObjectIdentifiers.RipeMD128;
    DigestUtilities.Oids["RIPEMD160"] = TeleTrusTObjectIdentifiers.RipeMD160;
    DigestUtilities.Oids["RIPEMD256"] = TeleTrusTObjectIdentifiers.RipeMD256;
    DigestUtilities.Oids["GOST3411"] = CryptoProObjectIdentifiers.GostR3411;
    DigestUtilities.Oids["SM3"] = GMObjectIdentifiers.sm3;
    DigestUtilities.Oids["BLAKE2B-160"] = MiscObjectIdentifiers.id_blake2b160;
    DigestUtilities.Oids["BLAKE2B-256"] = MiscObjectIdentifiers.id_blake2b256;
    DigestUtilities.Oids["BLAKE2B-384"] = MiscObjectIdentifiers.id_blake2b384;
    DigestUtilities.Oids["BLAKE2B-512"] = MiscObjectIdentifiers.id_blake2b512;
    DigestUtilities.Oids["BLAKE2S-128"] = MiscObjectIdentifiers.id_blake2s128;
    DigestUtilities.Oids["BLAKE2S-160"] = MiscObjectIdentifiers.id_blake2s160;
    DigestUtilities.Oids["BLAKE2S-224"] = MiscObjectIdentifiers.id_blake2s224;
    DigestUtilities.Oids["BLAKE2S-256"] = MiscObjectIdentifiers.id_blake2s256;
    DigestUtilities.Oids["BLAKE3-256"] = MiscObjectIdentifiers.blake3_256;
    DigestUtilities.Oids["GOST3411-2012-256"] = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256;
    DigestUtilities.Oids["GOST3411-2012-512"] = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512;
    DigestUtilities.Oids["DSTU7564-256"] = UAObjectIdentifiers.dstu7564digest_256;
    DigestUtilities.Oids["DSTU7564-384"] = UAObjectIdentifiers.dstu7564digest_384;
    DigestUtilities.Oids["DSTU7564-512"] = UAObjectIdentifiers.dstu7564digest_512;
  }

  public static DerObjectIdentifier GetObjectIdentifier(string mechanism)
  {
    mechanism = mechanism != null ? CollectionUtilities.GetValueOrKey<string>(DigestUtilities.Aliases, mechanism).ToUpperInvariant() : throw new ArgumentNullException(nameof (mechanism));
    return CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>(DigestUtilities.Oids, mechanism);
  }

  public static IDigest GetDigest(DerObjectIdentifier id) => DigestUtilities.GetDigest(id.Id);

  public static IDigest GetDigest(string algorithm)
  {
    string s = algorithm != null ? CollectionUtilities.GetValueOrKey<string>(DigestUtilities.Aliases, algorithm).ToUpperInvariant() : throw new ArgumentNullException(nameof (algorithm));
    try
    {
      switch (Enums.GetEnumValue<DigestUtilities.DigestAlgorithm>(s))
      {
        case DigestUtilities.DigestAlgorithm.BLAKE2B_160:
          return (IDigest) new Blake2bDigest(160 /*0xA0*/);
        case DigestUtilities.DigestAlgorithm.BLAKE2B_256:
          return (IDigest) new Blake2bDigest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.BLAKE2B_384:
          return (IDigest) new Blake2bDigest(384);
        case DigestUtilities.DigestAlgorithm.BLAKE2B_512:
          return (IDigest) new Blake2bDigest(512 /*0x0200*/);
        case DigestUtilities.DigestAlgorithm.BLAKE2S_128:
          return (IDigest) new Blake2sDigest(128 /*0x80*/);
        case DigestUtilities.DigestAlgorithm.BLAKE2S_160:
          return (IDigest) new Blake2sDigest(160 /*0xA0*/);
        case DigestUtilities.DigestAlgorithm.BLAKE2S_224:
          return (IDigest) new Blake2sDigest(224 /*0xE0*/);
        case DigestUtilities.DigestAlgorithm.BLAKE2S_256:
          return (IDigest) new Blake2sDigest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.BLAKE3_256:
          return (IDigest) new Blake3Digest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.DSTU7564_256:
          return (IDigest) new Dstu7564Digest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.DSTU7564_384:
          return (IDigest) new Dstu7564Digest(384);
        case DigestUtilities.DigestAlgorithm.DSTU7564_512:
          return (IDigest) new Dstu7564Digest(512 /*0x0200*/);
        case DigestUtilities.DigestAlgorithm.GOST3411:
          return (IDigest) new Gost3411Digest();
        case DigestUtilities.DigestAlgorithm.GOST3411_2012_256:
          return (IDigest) new Gost3411_2012_256Digest();
        case DigestUtilities.DigestAlgorithm.GOST3411_2012_512:
          return (IDigest) new Gost3411_2012_512Digest();
        case DigestUtilities.DigestAlgorithm.KECCAK_224:
          return (IDigest) new KeccakDigest(224 /*0xE0*/);
        case DigestUtilities.DigestAlgorithm.KECCAK_256:
          return (IDigest) new KeccakDigest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.KECCAK_288:
          return (IDigest) new KeccakDigest(288);
        case DigestUtilities.DigestAlgorithm.KECCAK_384:
          return (IDigest) new KeccakDigest(384);
        case DigestUtilities.DigestAlgorithm.KECCAK_512:
          return (IDigest) new KeccakDigest(512 /*0x0200*/);
        case DigestUtilities.DigestAlgorithm.MD2:
          return (IDigest) new MD2Digest();
        case DigestUtilities.DigestAlgorithm.MD4:
          return (IDigest) new MD4Digest();
        case DigestUtilities.DigestAlgorithm.MD5:
          return (IDigest) new MD5Digest();
        case DigestUtilities.DigestAlgorithm.NONE:
          return (IDigest) new NullDigest();
        case DigestUtilities.DigestAlgorithm.RIPEMD128:
          return (IDigest) new RipeMD128Digest();
        case DigestUtilities.DigestAlgorithm.RIPEMD160:
          return (IDigest) new RipeMD160Digest();
        case DigestUtilities.DigestAlgorithm.RIPEMD256:
          return (IDigest) new RipeMD256Digest();
        case DigestUtilities.DigestAlgorithm.RIPEMD320:
          return (IDigest) new RipeMD320Digest();
        case DigestUtilities.DigestAlgorithm.SHA_1:
          return (IDigest) new Sha1Digest();
        case DigestUtilities.DigestAlgorithm.SHA_224:
          return (IDigest) new Sha224Digest();
        case DigestUtilities.DigestAlgorithm.SHA_256:
          return (IDigest) new Sha256Digest();
        case DigestUtilities.DigestAlgorithm.SHA_384:
          return (IDigest) new Sha384Digest();
        case DigestUtilities.DigestAlgorithm.SHA_512:
          return (IDigest) new Sha512Digest();
        case DigestUtilities.DigestAlgorithm.SHA_512_224:
          return (IDigest) new Sha512tDigest(224 /*0xE0*/);
        case DigestUtilities.DigestAlgorithm.SHA_512_256:
          return (IDigest) new Sha512tDigest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.SHA3_224:
          return (IDigest) new Sha3Digest(224 /*0xE0*/);
        case DigestUtilities.DigestAlgorithm.SHA3_256:
          return (IDigest) new Sha3Digest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.SHA3_384:
          return (IDigest) new Sha3Digest(384);
        case DigestUtilities.DigestAlgorithm.SHA3_512:
          return (IDigest) new Sha3Digest(512 /*0x0200*/);
        case DigestUtilities.DigestAlgorithm.SHAKE128_256:
          return (IDigest) new ShakeDigest(128 /*0x80*/);
        case DigestUtilities.DigestAlgorithm.SHAKE256_512:
          return (IDigest) new ShakeDigest(256 /*0x0100*/);
        case DigestUtilities.DigestAlgorithm.SM3:
          return (IDigest) new SM3Digest();
        case DigestUtilities.DigestAlgorithm.TIGER:
          return (IDigest) new TigerDigest();
        case DigestUtilities.DigestAlgorithm.WHIRLPOOL:
          return (IDigest) new WhirlpoolDigest();
      }
    }
    catch (ArgumentException ex)
    {
    }
    throw new SecurityUtilityException($"Digest {s} not recognised.");
  }

  public static string GetAlgorithmName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(DigestUtilities.Aliases, oid.Id);
  }

  public static byte[] CalculateDigest(DerObjectIdentifier id, byte[] input)
  {
    return DigestUtilities.CalculateDigest(id.Id, input);
  }

  public static byte[] CalculateDigest(string algorithm, byte[] input)
  {
    return DigestUtilities.DoFinal(DigestUtilities.GetDigest(algorithm), input);
  }

  public static byte[] CalculateDigest(string algorithm, byte[] buf, int off, int len)
  {
    return DigestUtilities.DoFinal(DigestUtilities.GetDigest(algorithm), buf, off, len);
  }

  public static byte[] DoFinal(IDigest digest)
  {
    byte[] output = new byte[digest.GetDigestSize()];
    digest.DoFinal(output, 0);
    return output;
  }

  public static byte[] DoFinal(IDigest digest, byte[] input)
  {
    digest.BlockUpdate(input, 0, input.Length);
    return DigestUtilities.DoFinal(digest);
  }

  public static byte[] DoFinal(IDigest digest, byte[] buf, int off, int len)
  {
    digest.BlockUpdate(buf, off, len);
    return DigestUtilities.DoFinal(digest);
  }

  private enum DigestAlgorithm
  {
    BLAKE2B_160,
    BLAKE2B_256,
    BLAKE2B_384,
    BLAKE2B_512,
    BLAKE2S_128,
    BLAKE2S_160,
    BLAKE2S_224,
    BLAKE2S_256,
    BLAKE3_256,
    DSTU7564_256,
    DSTU7564_384,
    DSTU7564_512,
    GOST3411,
    GOST3411_2012_256,
    GOST3411_2012_512,
    KECCAK_224,
    KECCAK_256,
    KECCAK_288,
    KECCAK_384,
    KECCAK_512,
    MD2,
    MD4,
    MD5,
    NONE,
    RIPEMD128,
    RIPEMD160,
    RIPEMD256,
    RIPEMD320,
    SHA_1,
    SHA_224,
    SHA_256,
    SHA_384,
    SHA_512,
    SHA_512_224,
    SHA_512_256,
    SHA3_224,
    SHA3_256,
    SHA3_384,
    SHA3_512,
    SHAKE128_256,
    SHAKE256_512,
    SM3,
    TIGER,
    WHIRLPOOL,
  }
}
