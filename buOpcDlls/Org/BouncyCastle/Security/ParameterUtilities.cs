// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.ParameterUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Nsri;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class ParameterUtilities
{
  private static readonly IDictionary<string, string> Algorithms = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, int> BasicIVSizes = (IDictionary<string, int>) new Dictionary<string, int>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static ParameterUtilities()
  {
    ParameterUtilities.AddAlgorithm("AES", (object) "AESWRAP");
    ParameterUtilities.AddAlgorithm("AES128", (object) "2.16.840.1.101.3.4.2", (object) NistObjectIdentifiers.IdAes128Cbc, (object) NistObjectIdentifiers.IdAes128Ccm, (object) NistObjectIdentifiers.IdAes128Cfb, (object) NistObjectIdentifiers.IdAes128Ecb, (object) NistObjectIdentifiers.IdAes128Gcm, (object) NistObjectIdentifiers.IdAes128Ofb, (object) NistObjectIdentifiers.IdAes128Wrap);
    ParameterUtilities.AddAlgorithm("AES192", (object) "2.16.840.1.101.3.4.22", (object) NistObjectIdentifiers.IdAes192Cbc, (object) NistObjectIdentifiers.IdAes192Ccm, (object) NistObjectIdentifiers.IdAes192Cfb, (object) NistObjectIdentifiers.IdAes192Ecb, (object) NistObjectIdentifiers.IdAes192Gcm, (object) NistObjectIdentifiers.IdAes192Ofb, (object) NistObjectIdentifiers.IdAes192Wrap);
    ParameterUtilities.AddAlgorithm("AES256", (object) "2.16.840.1.101.3.4.42", (object) NistObjectIdentifiers.IdAes256Cbc, (object) NistObjectIdentifiers.IdAes256Ccm, (object) NistObjectIdentifiers.IdAes256Cfb, (object) NistObjectIdentifiers.IdAes256Ecb, (object) NistObjectIdentifiers.IdAes256Gcm, (object) NistObjectIdentifiers.IdAes256Ofb, (object) NistObjectIdentifiers.IdAes256Wrap);
    ParameterUtilities.AddAlgorithm("ARIA");
    ParameterUtilities.AddAlgorithm("ARIA128", (object) NsriObjectIdentifiers.id_aria128_cbc, (object) NsriObjectIdentifiers.id_aria128_ccm, (object) NsriObjectIdentifiers.id_aria128_cfb, (object) NsriObjectIdentifiers.id_aria128_ctr, (object) NsriObjectIdentifiers.id_aria128_ecb, (object) NsriObjectIdentifiers.id_aria128_gcm, (object) NsriObjectIdentifiers.id_aria128_ocb2, (object) NsriObjectIdentifiers.id_aria128_ofb);
    ParameterUtilities.AddAlgorithm("ARIA192", (object) NsriObjectIdentifiers.id_aria192_cbc, (object) NsriObjectIdentifiers.id_aria192_ccm, (object) NsriObjectIdentifiers.id_aria192_cfb, (object) NsriObjectIdentifiers.id_aria192_ctr, (object) NsriObjectIdentifiers.id_aria192_ecb, (object) NsriObjectIdentifiers.id_aria192_gcm, (object) NsriObjectIdentifiers.id_aria192_ocb2, (object) NsriObjectIdentifiers.id_aria192_ofb);
    ParameterUtilities.AddAlgorithm("ARIA256", (object) NsriObjectIdentifiers.id_aria256_cbc, (object) NsriObjectIdentifiers.id_aria256_ccm, (object) NsriObjectIdentifiers.id_aria256_cfb, (object) NsriObjectIdentifiers.id_aria256_ctr, (object) NsriObjectIdentifiers.id_aria256_ecb, (object) NsriObjectIdentifiers.id_aria256_gcm, (object) NsriObjectIdentifiers.id_aria256_ocb2, (object) NsriObjectIdentifiers.id_aria256_ofb);
    ParameterUtilities.AddAlgorithm("BLOWFISH", (object) "1.3.6.1.4.1.3029.1.2");
    ParameterUtilities.AddAlgorithm("CAMELLIA", (object) "CAMELLIAWRAP");
    ParameterUtilities.AddAlgorithm("CAMELLIA128", (object) NttObjectIdentifiers.IdCamellia128Cbc, (object) NttObjectIdentifiers.IdCamellia128Wrap);
    ParameterUtilities.AddAlgorithm("CAMELLIA192", (object) NttObjectIdentifiers.IdCamellia192Cbc, (object) NttObjectIdentifiers.IdCamellia192Wrap);
    ParameterUtilities.AddAlgorithm("CAMELLIA256", (object) NttObjectIdentifiers.IdCamellia256Cbc, (object) NttObjectIdentifiers.IdCamellia256Wrap);
    ParameterUtilities.AddAlgorithm("CAST5", (object) "1.2.840.113533.7.66.10");
    ParameterUtilities.AddAlgorithm("CAST6");
    ParameterUtilities.AddAlgorithm("CHACHA");
    ParameterUtilities.AddAlgorithm("CHACHA7539", (object) "CHACHA20", (object) "CHACHA20-POLY1305", (object) PkcsObjectIdentifiers.IdAlgAeadChaCha20Poly1305);
    ParameterUtilities.AddAlgorithm("DES", (object) OiwObjectIdentifiers.DesCbc, (object) OiwObjectIdentifiers.DesCfb, (object) OiwObjectIdentifiers.DesEcb, (object) OiwObjectIdentifiers.DesOfb);
    ParameterUtilities.AddAlgorithm("DESEDE", (object) "DESEDEWRAP", (object) "TDEA", (object) OiwObjectIdentifiers.DesEde, (object) PkcsObjectIdentifiers.IdAlgCms3DesWrap);
    ParameterUtilities.AddAlgorithm("DESEDE3", (object) PkcsObjectIdentifiers.DesEde3Cbc);
    ParameterUtilities.AddAlgorithm("GOST28147", (object) "GOST", (object) "GOST-28147", (object) CryptoProObjectIdentifiers.GostR28147Gcfb);
    ParameterUtilities.AddAlgorithm("HC128");
    ParameterUtilities.AddAlgorithm("HC256");
    ParameterUtilities.AddAlgorithm("IDEA", (object) "1.3.6.1.4.1.188.7.1.1.2");
    ParameterUtilities.AddAlgorithm("NOEKEON");
    ParameterUtilities.AddAlgorithm("RC2", (object) PkcsObjectIdentifiers.RC2Cbc, (object) PkcsObjectIdentifiers.IdAlgCmsRC2Wrap);
    ParameterUtilities.AddAlgorithm("RC4", (object) "ARC4", (object) "1.2.840.113549.3.4");
    ParameterUtilities.AddAlgorithm("RC5", (object) "RC5-32");
    ParameterUtilities.AddAlgorithm("RC5-64");
    ParameterUtilities.AddAlgorithm("RC6");
    ParameterUtilities.AddAlgorithm("RIJNDAEL");
    ParameterUtilities.AddAlgorithm("SALSA20");
    ParameterUtilities.AddAlgorithm("SEED", (object) KisaObjectIdentifiers.IdNpkiAppCmsSeedWrap, (object) KisaObjectIdentifiers.IdSeedCbc);
    ParameterUtilities.AddAlgorithm("SERPENT");
    ParameterUtilities.AddAlgorithm("SKIPJACK");
    ParameterUtilities.AddAlgorithm("SM4");
    ParameterUtilities.AddAlgorithm("TEA");
    ParameterUtilities.AddAlgorithm("THREEFISH-256");
    ParameterUtilities.AddAlgorithm("THREEFISH-512");
    ParameterUtilities.AddAlgorithm("THREEFISH-1024");
    ParameterUtilities.AddAlgorithm("TNEPRES");
    ParameterUtilities.AddAlgorithm("TWOFISH");
    ParameterUtilities.AddAlgorithm("VMPC");
    ParameterUtilities.AddAlgorithm("VMPC-KSA3");
    ParameterUtilities.AddAlgorithm("XTEA");
    ParameterUtilities.AddBasicIVSizeEntries(8, "BLOWFISH", "CHACHA", "DES", "DESEDE", "DESEDE3", "SALSA20");
    ParameterUtilities.AddBasicIVSizeEntries(12, "CHACHA7539");
    ParameterUtilities.AddBasicIVSizeEntries(16 /*0x10*/, "AES", "AES128", "AES192", "AES256", "ARIA", "ARIA128", "ARIA192", "ARIA256", "CAMELLIA", "CAMELLIA128", "CAMELLIA192", "CAMELLIA256", "NOEKEON", "SEED", "SM4");
  }

  private static void AddAlgorithm(string canonicalName, params object[] aliases)
  {
    ParameterUtilities.Algorithms[canonicalName] = canonicalName;
    foreach (object alias in aliases)
      ParameterUtilities.Algorithms[alias.ToString()] = canonicalName;
  }

  private static void AddBasicIVSizeEntries(int size, params string[] algorithms)
  {
    foreach (string algorithm in algorithms)
      ParameterUtilities.BasicIVSizes.Add(algorithm, size);
  }

  public static string GetCanonicalAlgorithmName(string algorithm)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(ParameterUtilities.Algorithms, algorithm);
  }

  public static KeyParameter CreateKeyParameter(DerObjectIdentifier algOid, byte[] keyBytes)
  {
    return ParameterUtilities.CreateKeyParameter(algOid.Id, keyBytes, 0, keyBytes.Length);
  }

  public static KeyParameter CreateKeyParameter(string algorithm, byte[] keyBytes)
  {
    return ParameterUtilities.CreateKeyParameter(algorithm, keyBytes, 0, keyBytes.Length);
  }

  public static KeyParameter CreateKeyParameter(
    DerObjectIdentifier algOid,
    byte[] keyBytes,
    int offset,
    int length)
  {
    return ParameterUtilities.CreateKeyParameter(algOid.Id, keyBytes, offset, length);
  }

  public static KeyParameter CreateKeyParameter(
    string algorithm,
    byte[] keyBytes,
    int offset,
    int length)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    switch (ParameterUtilities.GetCanonicalAlgorithmName(algorithm))
    {
      case null:
        throw new SecurityUtilityException($"Algorithm {algorithm} not recognised.");
      case "DES":
        return (KeyParameter) new DesParameters(keyBytes, offset, length);
      case "DESEDE":
      case "DESEDE3":
        return (KeyParameter) new DesEdeParameters(keyBytes, offset, length);
      case "RC2":
        return (KeyParameter) new RC2Parameters(keyBytes, offset, length);
      default:
        return new KeyParameter(keyBytes, offset, length);
    }
  }

  public static ICipherParameters GetCipherParameters(
    DerObjectIdentifier algOid,
    ICipherParameters key,
    Asn1Object asn1Params)
  {
    return ParameterUtilities.GetCipherParameters(algOid.Id, key, asn1Params);
  }

  public static ICipherParameters GetCipherParameters(
    string algorithm,
    ICipherParameters key,
    Asn1Object asn1Params)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (!NistObjectIdentifiers.IdAes128Gcm.Id.Equals(algorithm) && !NistObjectIdentifiers.IdAes192Gcm.Id.Equals(algorithm) && !NistObjectIdentifiers.IdAes256Gcm.Id.Equals(algorithm))
    {
      if (!NistObjectIdentifiers.IdAes128Ccm.Id.Equals(algorithm) && !NistObjectIdentifiers.IdAes192Ccm.Id.Equals(algorithm) && !NistObjectIdentifiers.IdAes256Ccm.Id.Equals(algorithm))
      {
        string canonicalAlgorithmName = ParameterUtilities.GetCanonicalAlgorithmName(algorithm);
        if (canonicalAlgorithmName == null)
          throw new SecurityUtilityException($"Algorithm {algorithm} not recognised.");
        byte[] iv = (byte[]) null;
        try
        {
          if (ParameterUtilities.FindBasicIVSize(canonicalAlgorithmName) == -1)
          {
            switch (canonicalAlgorithmName)
            {
              case "RIJNDAEL":
              case "SKIPJACK":
              case "TWOFISH":
                break;
              case "CAST5":
                iv = Cast5CbcParameters.GetInstance((object) asn1Params).GetIV();
                goto label_14;
              case "IDEA":
                iv = IdeaCbcPar.GetInstance((object) asn1Params).GetIV();
                goto label_14;
              case "RC2":
                iv = RC2CbcParameter.GetInstance((object) asn1Params).GetIV();
                goto label_14;
              default:
                goto label_14;
            }
          }
          iv = ((Asn1OctetString) asn1Params).GetOctets();
        }
        catch (Exception ex)
        {
          throw new ArgumentException("Could not process ASN.1 parameters", ex);
        }
label_14:
        return iv != null ? (ICipherParameters) new ParametersWithIV(key, iv) : throw new SecurityUtilityException($"Algorithm {algorithm} not recognised.");
      }
      if (!(key is KeyParameter key1))
        throw new ArgumentException("key data must be accessible for CCM operation");
      CcmParameters instance = CcmParameters.GetInstance((object) asn1Params);
      return (ICipherParameters) new AeadParameters(key1, instance.IcvLen * 8, instance.GetNonce());
    }
    if (!(key is KeyParameter key2))
      throw new ArgumentException("key data must be accessible for GCM operation");
    GcmParameters instance1 = GcmParameters.GetInstance((object) asn1Params);
    return (ICipherParameters) new AeadParameters(key2, instance1.IcvLen * 8, instance1.GetNonce());
  }

  public static Asn1Encodable GenerateParameters(DerObjectIdentifier algID, SecureRandom random)
  {
    return ParameterUtilities.GenerateParameters(algID.Id, random);
  }

  public static Asn1Encodable GenerateParameters(string algorithm, SecureRandom random)
  {
    string canonicalName = algorithm != null ? ParameterUtilities.GetCanonicalAlgorithmName(algorithm) : throw new ArgumentNullException(nameof (algorithm));
    int ivLength = canonicalName != null ? ParameterUtilities.FindBasicIVSize(canonicalName) : throw new SecurityUtilityException($"Algorithm {algorithm} not recognised.");
    if (ivLength != -1)
      return (Asn1Encodable) ParameterUtilities.CreateIVOctetString(random, ivLength);
    switch (canonicalName)
    {
      case "CAST5":
        return (Asn1Encodable) new Cast5CbcParameters(ParameterUtilities.CreateIV(random, 8), 128 /*0x80*/);
      case "IDEA":
        return (Asn1Encodable) new IdeaCbcPar(ParameterUtilities.CreateIV(random, 8));
      case "RC2":
        return (Asn1Encodable) new RC2CbcParameter(ParameterUtilities.CreateIV(random, 8));
      default:
        throw new SecurityUtilityException($"Algorithm {algorithm} not recognised.");
    }
  }

  public static ICipherParameters WithRandom(ICipherParameters cp, SecureRandom random)
  {
    if (random != null)
      cp = (ICipherParameters) new ParametersWithRandom(cp, random);
    return cp;
  }

  private static Asn1OctetString CreateIVOctetString(SecureRandom random, int ivLength)
  {
    return (Asn1OctetString) new DerOctetString(ParameterUtilities.CreateIV(random, ivLength));
  }

  private static byte[] CreateIV(SecureRandom random, int ivLength)
  {
    return SecureRandom.GetNextBytes(random, ivLength);
  }

  private static int FindBasicIVSize(string canonicalName)
  {
    int num;
    return !ParameterUtilities.BasicIVSizes.TryGetValue(canonicalName, out num) ? -1 : num;
  }
}
