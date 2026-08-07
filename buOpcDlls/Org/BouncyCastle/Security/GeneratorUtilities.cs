// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.GeneratorUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.Iana;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Nsri;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class GeneratorUtilities
{
  private static readonly IDictionary<string, string> KgAlgorithms = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, string> KpgAlgorithms = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, int> DefaultKeySizes = (IDictionary<string, int>) new Dictionary<string, int>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static GeneratorUtilities()
  {
    GeneratorUtilities.AddKgAlgorithm("AES", (object) "AESWRAP");
    GeneratorUtilities.AddKgAlgorithm("AES128", (object) "2.16.840.1.101.3.4.2", (object) NistObjectIdentifiers.IdAes128Cbc, (object) NistObjectIdentifiers.IdAes128Ccm, (object) NistObjectIdentifiers.IdAes128Cfb, (object) NistObjectIdentifiers.IdAes128Ecb, (object) NistObjectIdentifiers.IdAes128Gcm, (object) NistObjectIdentifiers.IdAes128Ofb, (object) NistObjectIdentifiers.IdAes128Wrap);
    GeneratorUtilities.AddKgAlgorithm("AES192", (object) "2.16.840.1.101.3.4.22", (object) NistObjectIdentifiers.IdAes192Cbc, (object) NistObjectIdentifiers.IdAes192Ccm, (object) NistObjectIdentifiers.IdAes192Cfb, (object) NistObjectIdentifiers.IdAes192Ecb, (object) NistObjectIdentifiers.IdAes192Gcm, (object) NistObjectIdentifiers.IdAes192Ofb, (object) NistObjectIdentifiers.IdAes192Wrap);
    GeneratorUtilities.AddKgAlgorithm("AES256", (object) "2.16.840.1.101.3.4.42", (object) NistObjectIdentifiers.IdAes256Cbc, (object) NistObjectIdentifiers.IdAes256Ccm, (object) NistObjectIdentifiers.IdAes256Cfb, (object) NistObjectIdentifiers.IdAes256Ecb, (object) NistObjectIdentifiers.IdAes256Gcm, (object) NistObjectIdentifiers.IdAes256Ofb, (object) NistObjectIdentifiers.IdAes256Wrap);
    GeneratorUtilities.AddKgAlgorithm("BLOWFISH", (object) "1.3.6.1.4.1.3029.1.2");
    GeneratorUtilities.AddKgAlgorithm("CAMELLIA", (object) "CAMELLIAWRAP");
    GeneratorUtilities.AddKgAlgorithm("ARIA");
    GeneratorUtilities.AddKgAlgorithm("ARIA128", (object) NsriObjectIdentifiers.id_aria128_cbc, (object) NsriObjectIdentifiers.id_aria128_ccm, (object) NsriObjectIdentifiers.id_aria128_cfb, (object) NsriObjectIdentifiers.id_aria128_ctr, (object) NsriObjectIdentifiers.id_aria128_ecb, (object) NsriObjectIdentifiers.id_aria128_gcm, (object) NsriObjectIdentifiers.id_aria128_ocb2, (object) NsriObjectIdentifiers.id_aria128_ofb);
    GeneratorUtilities.AddKgAlgorithm("ARIA192", (object) NsriObjectIdentifiers.id_aria192_cbc, (object) NsriObjectIdentifiers.id_aria192_ccm, (object) NsriObjectIdentifiers.id_aria192_cfb, (object) NsriObjectIdentifiers.id_aria192_ctr, (object) NsriObjectIdentifiers.id_aria192_ecb, (object) NsriObjectIdentifiers.id_aria192_gcm, (object) NsriObjectIdentifiers.id_aria192_ocb2, (object) NsriObjectIdentifiers.id_aria192_ofb);
    GeneratorUtilities.AddKgAlgorithm("ARIA256", (object) NsriObjectIdentifiers.id_aria256_cbc, (object) NsriObjectIdentifiers.id_aria256_ccm, (object) NsriObjectIdentifiers.id_aria256_cfb, (object) NsriObjectIdentifiers.id_aria256_ctr, (object) NsriObjectIdentifiers.id_aria256_ecb, (object) NsriObjectIdentifiers.id_aria256_gcm, (object) NsriObjectIdentifiers.id_aria256_ocb2, (object) NsriObjectIdentifiers.id_aria256_ofb);
    GeneratorUtilities.AddKgAlgorithm("CAMELLIA128", (object) NttObjectIdentifiers.IdCamellia128Cbc, (object) NttObjectIdentifiers.IdCamellia128Wrap);
    GeneratorUtilities.AddKgAlgorithm("CAMELLIA192", (object) NttObjectIdentifiers.IdCamellia192Cbc, (object) NttObjectIdentifiers.IdCamellia192Wrap);
    GeneratorUtilities.AddKgAlgorithm("CAMELLIA256", (object) NttObjectIdentifiers.IdCamellia256Cbc, (object) NttObjectIdentifiers.IdCamellia256Wrap);
    GeneratorUtilities.AddKgAlgorithm("CAST5", (object) "1.2.840.113533.7.66.10");
    GeneratorUtilities.AddKgAlgorithm("CAST6");
    GeneratorUtilities.AddKgAlgorithm("CHACHA");
    GeneratorUtilities.AddKgAlgorithm("CHACHA7539", (object) "CHACHA20", (object) "CHACHA20-POLY1305", (object) PkcsObjectIdentifiers.IdAlgAeadChaCha20Poly1305);
    GeneratorUtilities.AddKgAlgorithm("DES", (object) OiwObjectIdentifiers.DesCbc, (object) OiwObjectIdentifiers.DesCfb, (object) OiwObjectIdentifiers.DesEcb, (object) OiwObjectIdentifiers.DesOfb);
    GeneratorUtilities.AddKgAlgorithm("DESEDE", (object) "DESEDEWRAP", (object) "TDEA", (object) OiwObjectIdentifiers.DesEde);
    GeneratorUtilities.AddKgAlgorithm("DESEDE3", (object) PkcsObjectIdentifiers.DesEde3Cbc, (object) PkcsObjectIdentifiers.IdAlgCms3DesWrap);
    GeneratorUtilities.AddKgAlgorithm("GOST28147", (object) "GOST", (object) "GOST-28147", (object) CryptoProObjectIdentifiers.GostR28147Gcfb);
    GeneratorUtilities.AddKgAlgorithm("HC128");
    GeneratorUtilities.AddKgAlgorithm("HC256");
    GeneratorUtilities.AddKgAlgorithm("IDEA", (object) "1.3.6.1.4.1.188.7.1.1.2");
    GeneratorUtilities.AddKgAlgorithm("NOEKEON");
    GeneratorUtilities.AddKgAlgorithm("RC2", (object) PkcsObjectIdentifiers.RC2Cbc, (object) PkcsObjectIdentifiers.IdAlgCmsRC2Wrap);
    GeneratorUtilities.AddKgAlgorithm("RC4", (object) "ARC4", (object) "1.2.840.113549.3.4");
    GeneratorUtilities.AddKgAlgorithm("RC5", (object) "RC5-32");
    GeneratorUtilities.AddKgAlgorithm("RC5-64");
    GeneratorUtilities.AddKgAlgorithm("RC6");
    GeneratorUtilities.AddKgAlgorithm("RIJNDAEL");
    GeneratorUtilities.AddKgAlgorithm("SALSA20");
    GeneratorUtilities.AddKgAlgorithm("SEED", (object) KisaObjectIdentifiers.IdNpkiAppCmsSeedWrap, (object) KisaObjectIdentifiers.IdSeedCbc);
    GeneratorUtilities.AddKgAlgorithm("SERPENT");
    GeneratorUtilities.AddKgAlgorithm("SKIPJACK");
    GeneratorUtilities.AddKgAlgorithm("SM4");
    GeneratorUtilities.AddKgAlgorithm("TEA");
    GeneratorUtilities.AddKgAlgorithm("THREEFISH-256");
    GeneratorUtilities.AddKgAlgorithm("THREEFISH-512");
    GeneratorUtilities.AddKgAlgorithm("THREEFISH-1024");
    GeneratorUtilities.AddKgAlgorithm("TNEPRES");
    GeneratorUtilities.AddKgAlgorithm("TWOFISH");
    GeneratorUtilities.AddKgAlgorithm("VMPC");
    GeneratorUtilities.AddKgAlgorithm("VMPC-KSA3");
    GeneratorUtilities.AddKgAlgorithm("XTEA");
    GeneratorUtilities.AddHMacKeyGenerator("MD2");
    GeneratorUtilities.AddHMacKeyGenerator("MD4");
    GeneratorUtilities.AddHMacKeyGenerator("MD5", (object) IanaObjectIdentifiers.HmacMD5);
    GeneratorUtilities.AddHMacKeyGenerator("SHA1", (object) PkcsObjectIdentifiers.IdHmacWithSha1, (object) IanaObjectIdentifiers.HmacSha1);
    GeneratorUtilities.AddHMacKeyGenerator("SHA224", (object) PkcsObjectIdentifiers.IdHmacWithSha224);
    GeneratorUtilities.AddHMacKeyGenerator("SHA256", (object) PkcsObjectIdentifiers.IdHmacWithSha256);
    GeneratorUtilities.AddHMacKeyGenerator("SHA384", (object) PkcsObjectIdentifiers.IdHmacWithSha384);
    GeneratorUtilities.AddHMacKeyGenerator("SHA512", (object) PkcsObjectIdentifiers.IdHmacWithSha512);
    GeneratorUtilities.AddHMacKeyGenerator("SHA512/224");
    GeneratorUtilities.AddHMacKeyGenerator("SHA512/256");
    GeneratorUtilities.AddHMacKeyGenerator("KECCAK224");
    GeneratorUtilities.AddHMacKeyGenerator("KECCAK256");
    GeneratorUtilities.AddHMacKeyGenerator("KECCAK288");
    GeneratorUtilities.AddHMacKeyGenerator("KECCAK384");
    GeneratorUtilities.AddHMacKeyGenerator("KECCAK512");
    GeneratorUtilities.AddHMacKeyGenerator("SHA3-224", (object) NistObjectIdentifiers.IdHMacWithSha3_224);
    GeneratorUtilities.AddHMacKeyGenerator("SHA3-256", (object) NistObjectIdentifiers.IdHMacWithSha3_256);
    GeneratorUtilities.AddHMacKeyGenerator("SHA3-384", (object) NistObjectIdentifiers.IdHMacWithSha3_384);
    GeneratorUtilities.AddHMacKeyGenerator("SHA3-512", (object) NistObjectIdentifiers.IdHMacWithSha3_512);
    GeneratorUtilities.AddHMacKeyGenerator("RIPEMD128");
    GeneratorUtilities.AddHMacKeyGenerator("RIPEMD160", (object) IanaObjectIdentifiers.HmacRipeMD160);
    GeneratorUtilities.AddHMacKeyGenerator("TIGER", (object) IanaObjectIdentifiers.HmacTiger);
    GeneratorUtilities.AddHMacKeyGenerator("GOST3411-2012-256", (object) RosstandartObjectIdentifiers.id_tc26_hmac_gost_3411_12_256);
    GeneratorUtilities.AddHMacKeyGenerator("GOST3411-2012-512", (object) RosstandartObjectIdentifiers.id_tc26_hmac_gost_3411_12_512);
    GeneratorUtilities.AddKpgAlgorithm("DH", (object) "DIFFIEHELLMAN");
    GeneratorUtilities.AddKpgAlgorithm("DSA");
    GeneratorUtilities.AddKpgAlgorithm("EC", (object) X9ObjectIdentifiers.DHSinglePassStdDHSha1KdfScheme);
    GeneratorUtilities.AddKpgAlgorithm("ECDH", (object) "ECIES");
    GeneratorUtilities.AddKpgAlgorithm("ECDHC");
    GeneratorUtilities.AddKpgAlgorithm("ECMQV", (object) X9ObjectIdentifiers.MqvSinglePassSha1KdfScheme);
    GeneratorUtilities.AddKpgAlgorithm("ECDSA");
    GeneratorUtilities.AddKpgAlgorithm("ECGOST3410", (object) "ECGOST-3410", (object) "GOST-3410-2001");
    GeneratorUtilities.AddKpgAlgorithm("ECGOST3410-2012", (object) "GOST-3410-2012");
    GeneratorUtilities.AddKpgAlgorithm("Ed25519", (object) "Ed25519ctx", (object) "Ed25519ph", (object) EdECObjectIdentifiers.id_Ed25519);
    GeneratorUtilities.AddKpgAlgorithm("Ed448", (object) "Ed448ph", (object) EdECObjectIdentifiers.id_Ed448);
    GeneratorUtilities.AddKpgAlgorithm("ELGAMAL");
    GeneratorUtilities.AddKpgAlgorithm("GOST3410", (object) "GOST-3410", (object) "GOST-3410-94");
    GeneratorUtilities.AddKpgAlgorithm("RSA", (object) "1.2.840.113549.1.1.1");
    GeneratorUtilities.AddKpgAlgorithm("RSASSA-PSS");
    GeneratorUtilities.AddKpgAlgorithm("X25519", (object) EdECObjectIdentifiers.id_X25519);
    GeneratorUtilities.AddKpgAlgorithm("X448", (object) EdECObjectIdentifiers.id_X448);
    GeneratorUtilities.AddDefaultKeySizeEntries(64 /*0x40*/, "DES");
    GeneratorUtilities.AddDefaultKeySizeEntries(80 /*0x50*/, "SKIPJACK");
    GeneratorUtilities.AddDefaultKeySizeEntries(128 /*0x80*/, "AES128", "ARIA128", "BLOWFISH", "CAMELLIA128", "CAST5", "CHACHA", "DESEDE", "HC128", "HMACMD2", "HMACMD4", "HMACMD5", "HMACRIPEMD128", "IDEA", "NOEKEON", "RC2", "RC4", "RC5", "SALSA20", "SEED", "SM4", "TEA", "XTEA", "VMPC", "VMPC-KSA3");
    GeneratorUtilities.AddDefaultKeySizeEntries(160 /*0xA0*/, "HMACRIPEMD160", "HMACSHA1");
    GeneratorUtilities.AddDefaultKeySizeEntries(192 /*0xC0*/, "AES", "AES192", "ARIA192", "CAMELLIA192", "DESEDE3", "HMACTIGER", "RIJNDAEL", "SERPENT", "TNEPRES");
    GeneratorUtilities.AddDefaultKeySizeEntries(224 /*0xE0*/, "HMACSHA3-224", "HMACKECCAK224", "HMACSHA224", "HMACSHA512/224");
    GeneratorUtilities.AddDefaultKeySizeEntries(256 /*0x0100*/, "AES256", "ARIA", "ARIA256", "CAMELLIA", "CAMELLIA256", "CAST6", "CHACHA7539", "GOST28147", "HC256", "HMACGOST3411-2012-256", "HMACSHA3-256", "HMACKECCAK256", "HMACSHA256", "HMACSHA512/256", "RC5-64", "RC6", "THREEFISH-256", "TWOFISH");
    GeneratorUtilities.AddDefaultKeySizeEntries(288, "HMACKECCAK288");
    GeneratorUtilities.AddDefaultKeySizeEntries(384, "HMACSHA3-384", "HMACKECCAK384", "HMACSHA384");
    GeneratorUtilities.AddDefaultKeySizeEntries(512 /*0x0200*/, "HMACGOST3411-2012-512", "HMACSHA3-512", "HMACKECCAK512", "HMACSHA512", "THREEFISH-512");
    GeneratorUtilities.AddDefaultKeySizeEntries(1024 /*0x0400*/, "THREEFISH-1024");
  }

  private static void AddDefaultKeySizeEntries(int size, params string[] algorithms)
  {
    foreach (string algorithm in algorithms)
      GeneratorUtilities.DefaultKeySizes.Add(algorithm, size);
  }

  private static void AddKgAlgorithm(string canonicalName, params object[] aliases)
  {
    GeneratorUtilities.KgAlgorithms[canonicalName] = canonicalName;
    foreach (object alias in aliases)
      GeneratorUtilities.KgAlgorithms[alias.ToString()] = canonicalName;
  }

  private static void AddKpgAlgorithm(string canonicalName, params object[] aliases)
  {
    GeneratorUtilities.KpgAlgorithms[canonicalName] = canonicalName;
    foreach (object alias in aliases)
      GeneratorUtilities.KpgAlgorithms[alias.ToString()] = canonicalName;
  }

  private static void AddHMacKeyGenerator(string algorithm, params object[] aliases)
  {
    string key = "HMAC" + algorithm;
    GeneratorUtilities.KgAlgorithms[key] = key;
    GeneratorUtilities.KgAlgorithms["HMAC-" + algorithm] = key;
    GeneratorUtilities.KgAlgorithms["HMAC/" + algorithm] = key;
    foreach (object alias in aliases)
      GeneratorUtilities.KgAlgorithms[alias.ToString()] = key;
  }

  internal static string GetCanonicalKeyGeneratorAlgorithm(string algorithm)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(GeneratorUtilities.KgAlgorithms, algorithm);
  }

  internal static string GetCanonicalKeyPairGeneratorAlgorithm(string algorithm)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(GeneratorUtilities.KpgAlgorithms, algorithm);
  }

  public static CipherKeyGenerator GetKeyGenerator(DerObjectIdentifier oid)
  {
    return GeneratorUtilities.GetKeyGenerator(oid.Id);
  }

  public static CipherKeyGenerator GetKeyGenerator(string algorithm)
  {
    string generatorAlgorithm = GeneratorUtilities.GetCanonicalKeyGeneratorAlgorithm(algorithm);
    int defaultStrength = generatorAlgorithm != null ? GeneratorUtilities.FindDefaultKeySize(generatorAlgorithm) : throw new SecurityUtilityException($"KeyGenerator {algorithm} not recognised.");
    if (defaultStrength == -1)
      throw new SecurityUtilityException($"KeyGenerator {algorithm} ({generatorAlgorithm}) not supported.");
    switch (generatorAlgorithm)
    {
      case "DES":
        return (CipherKeyGenerator) new DesKeyGenerator(defaultStrength);
      case "DESEDE":
      case "DESEDE3":
        return (CipherKeyGenerator) new DesEdeKeyGenerator(defaultStrength);
      default:
        return new CipherKeyGenerator(defaultStrength);
    }
  }

  public static IAsymmetricCipherKeyPairGenerator GetKeyPairGenerator(DerObjectIdentifier oid)
  {
    return GeneratorUtilities.GetKeyPairGenerator(oid.Id);
  }

  public static IAsymmetricCipherKeyPairGenerator GetKeyPairGenerator(string algorithm)
  {
    string generatorAlgorithm = GeneratorUtilities.GetCanonicalKeyPairGeneratorAlgorithm(algorithm);
    switch (generatorAlgorithm)
    {
      case null:
        throw new SecurityUtilityException($"KeyPairGenerator {algorithm} not recognised.");
      case "DH":
        return (IAsymmetricCipherKeyPairGenerator) new DHKeyPairGenerator();
      case "DSA":
        return (IAsymmetricCipherKeyPairGenerator) new DsaKeyPairGenerator();
      default:
        if (Platform.StartsWith(generatorAlgorithm, "EC"))
          return (IAsymmetricCipherKeyPairGenerator) new ECKeyPairGenerator(generatorAlgorithm);
        switch (generatorAlgorithm)
        {
          case "Ed25519":
            return (IAsymmetricCipherKeyPairGenerator) new Ed25519KeyPairGenerator();
          case "Ed448":
            return (IAsymmetricCipherKeyPairGenerator) new Ed448KeyPairGenerator();
          case "ELGAMAL":
            return (IAsymmetricCipherKeyPairGenerator) new ElGamalKeyPairGenerator();
          case "GOST3410":
            return (IAsymmetricCipherKeyPairGenerator) new Gost3410KeyPairGenerator();
          case "RSA":
          case "RSASSA-PSS":
            return (IAsymmetricCipherKeyPairGenerator) new RsaKeyPairGenerator();
          case "X25519":
            return (IAsymmetricCipherKeyPairGenerator) new X25519KeyPairGenerator();
          case "X448":
            return (IAsymmetricCipherKeyPairGenerator) new X448KeyPairGenerator();
          default:
            throw new SecurityUtilityException($"KeyPairGenerator {algorithm} ({generatorAlgorithm}) not supported.");
        }
    }
  }

  internal static int GetDefaultKeySize(DerObjectIdentifier oid)
  {
    return GeneratorUtilities.GetDefaultKeySize(oid.Id);
  }

  internal static int GetDefaultKeySize(string algorithm)
  {
    string generatorAlgorithm = GeneratorUtilities.GetCanonicalKeyGeneratorAlgorithm(algorithm);
    int num = generatorAlgorithm != null ? GeneratorUtilities.FindDefaultKeySize(generatorAlgorithm) : throw new SecurityUtilityException($"KeyGenerator {algorithm} not recognised.");
    return num != -1 ? num : throw new SecurityUtilityException($"KeyGenerator {algorithm} ({generatorAlgorithm}) not supported.");
  }

  private static int FindDefaultKeySize(string canonicalName)
  {
    int num;
    return !GeneratorUtilities.DefaultKeySizes.TryGetValue(canonicalName, out num) ? -1 : num;
  }
}
