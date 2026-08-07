// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.PbeUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.BC;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class PbeUtilities
{
  private const string Pkcs5S1 = "Pkcs5S1";
  private const string Pkcs5S2 = "Pkcs5S2";
  private const string Pkcs12 = "Pkcs12";
  private const string OpenSsl = "OpenSsl";
  private static readonly IDictionary<string, string> Algorithms = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, string> AlgorithmType = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, DerObjectIdentifier> Oids = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static PbeUtilities()
  {
    PbeUtilities.Algorithms["PKCS5SCHEME1"] = "Pkcs5scheme1";
    PbeUtilities.Algorithms["PKCS5SCHEME2"] = "Pkcs5scheme2";
    PbeUtilities.Algorithms["PBKDF2"] = "Pkcs5scheme2";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.IdPbeS2.Id] = "Pkcs5scheme2";
    PbeUtilities.Algorithms["PBEWITHMD2ANDDES-CBC"] = "PBEwithMD2andDES-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithMD2AndDesCbc.Id] = "PBEwithMD2andDES-CBC";
    PbeUtilities.Algorithms["PBEWITHMD2ANDRC2-CBC"] = "PBEwithMD2andRC2-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithMD2AndRC2Cbc.Id] = "PBEwithMD2andRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHMD5ANDDES-CBC"] = "PBEwithMD5andDES-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithMD5AndDesCbc.Id] = "PBEwithMD5andDES-CBC";
    PbeUtilities.Algorithms["PBEWITHMD5ANDRC2-CBC"] = "PBEwithMD5andRC2-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithMD5AndRC2Cbc.Id] = "PBEwithMD5andRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1ANDDES"] = "PBEwithSHA-1andDES-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1ANDDES"] = "PBEwithSHA-1andDES-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1ANDDES-CBC"] = "PBEwithSHA-1andDES-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1ANDDES-CBC"] = "PBEwithSHA-1andDES-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithSha1AndDesCbc.Id] = "PBEwithSHA-1andDES-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1ANDRC2"] = "PBEwithSHA-1andRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1ANDRC2"] = "PBEwithSHA-1andRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1ANDRC2-CBC"] = "PBEwithSHA-1andRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1ANDRC2-CBC"] = "PBEwithSHA-1andRC2-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithSha1AndRC2Cbc.Id] = "PBEwithSHA-1andRC2-CBC";
    PbeUtilities.Algorithms["PKCS12"] = nameof (Pkcs12);
    PbeUtilities.Algorithms[BCObjectIdentifiers.bc_pbe_sha1_pkcs12_aes128_cbc.Id] = "PBEwithSHA-1and128bitAES-CBC-BC";
    PbeUtilities.Algorithms[BCObjectIdentifiers.bc_pbe_sha1_pkcs12_aes192_cbc.Id] = "PBEwithSHA-1and192bitAES-CBC-BC";
    PbeUtilities.Algorithms[BCObjectIdentifiers.bc_pbe_sha1_pkcs12_aes256_cbc.Id] = "PBEwithSHA-1and256bitAES-CBC-BC";
    PbeUtilities.Algorithms[BCObjectIdentifiers.bc_pbe_sha256_pkcs12_aes128_cbc.Id] = "PBEwithSHA-256and128bitAES-CBC-BC";
    PbeUtilities.Algorithms[BCObjectIdentifiers.bc_pbe_sha256_pkcs12_aes192_cbc.Id] = "PBEwithSHA-256and192bitAES-CBC-BC";
    PbeUtilities.Algorithms[BCObjectIdentifiers.bc_pbe_sha256_pkcs12_aes256_cbc.Id] = "PBEwithSHA-256and256bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHAAND128BITRC4"] = "PBEwithSHA-1and128bitRC4";
    PbeUtilities.Algorithms["PBEWITHSHA1AND128BITRC4"] = "PBEwithSHA-1and128bitRC4";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND128BITRC4"] = "PBEwithSHA-1and128bitRC4";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd128BitRC4.Id] = "PBEwithSHA-1and128bitRC4";
    PbeUtilities.Algorithms["PBEWITHSHAAND40BITRC4"] = "PBEwithSHA-1and40bitRC4";
    PbeUtilities.Algorithms["PBEWITHSHA1AND40BITRC4"] = "PBEwithSHA-1and40bitRC4";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND40BITRC4"] = "PBEwithSHA-1and40bitRC4";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd40BitRC4.Id] = "PBEwithSHA-1and40bitRC4";
    PbeUtilities.Algorithms["PBEWITHSHAAND3-KEYDESEDE-CBC"] = "PBEwithSHA-1and3-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAAND3-KEYTRIPLEDES-CBC"] = "PBEwithSHA-1and3-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND3-KEYDESEDE-CBC"] = "PBEwithSHA-1and3-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND3-KEYTRIPLEDES-CBC"] = "PBEwithSHA-1and3-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND3-KEYDESEDE-CBC"] = "PBEwithSHA-1and3-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND3-KEYTRIPLEDES-CBC"] = "PBEwithSHA-1and3-keyDESEDE-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd3KeyTripleDesCbc.Id] = "PBEwithSHA-1and3-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAAND2-KEYDESEDE-CBC"] = "PBEwithSHA-1and2-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAAND2-KEYTRIPLEDES-CBC"] = "PBEwithSHA-1and2-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND2-KEYDESEDE-CBC"] = "PBEwithSHA-1and2-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND2-KEYTRIPLEDES-CBC"] = "PBEwithSHA-1and2-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND2-KEYDESEDE-CBC"] = "PBEwithSHA-1and2-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND2-KEYTRIPLEDES-CBC"] = "PBEwithSHA-1and2-keyDESEDE-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd2KeyTripleDesCbc.Id] = "PBEwithSHA-1and2-keyDESEDE-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAAND128BITRC2-CBC"] = "PBEwithSHA-1and128bitRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND128BITRC2-CBC"] = "PBEwithSHA-1and128bitRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND128BITRC2-CBC"] = "PBEwithSHA-1and128bitRC2-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd128BitRC2Cbc.Id] = "PBEwithSHA-1and128bitRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAAND40BITRC2-CBC"] = "PBEwithSHA-1and40bitRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND40BITRC2-CBC"] = "PBEwithSHA-1and40bitRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND40BITRC2-CBC"] = "PBEwithSHA-1and40bitRC2-CBC";
    PbeUtilities.Algorithms[PkcsObjectIdentifiers.PbewithShaAnd40BitRC2Cbc.Id] = "PBEwithSHA-1and40bitRC2-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAAND128BITAES-CBC-BC"] = "PBEwithSHA-1and128bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND128BITAES-CBC-BC"] = "PBEwithSHA-1and128bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND128BITAES-CBC-BC"] = "PBEwithSHA-1and128bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHAAND192BITAES-CBC-BC"] = "PBEwithSHA-1and192bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND192BITAES-CBC-BC"] = "PBEwithSHA-1and192bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND192BITAES-CBC-BC"] = "PBEwithSHA-1and192bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHAAND256BITAES-CBC-BC"] = "PBEwithSHA-1and256bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA1AND256BITAES-CBC-BC"] = "PBEwithSHA-1and256bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA-1AND256BITAES-CBC-BC"] = "PBEwithSHA-1and256bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA256AND128BITAES-CBC-BC"] = "PBEwithSHA-256and128bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA-256AND128BITAES-CBC-BC"] = "PBEwithSHA-256and128bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA256AND192BITAES-CBC-BC"] = "PBEwithSHA-256and192bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA-256AND192BITAES-CBC-BC"] = "PBEwithSHA-256and192bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA256AND256BITAES-CBC-BC"] = "PBEwithSHA-256and256bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHA-256AND256BITAES-CBC-BC"] = "PBEwithSHA-256and256bitAES-CBC-BC";
    PbeUtilities.Algorithms["PBEWITHSHAANDIDEA"] = "PBEwithSHA-1andIDEA-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAANDIDEA-CBC"] = "PBEwithSHA-1andIDEA-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAANDTWOFISH"] = "PBEwithSHA-1andTWOFISH-CBC";
    PbeUtilities.Algorithms["PBEWITHSHAANDTWOFISH-CBC"] = "PBEwithSHA-1andTWOFISH-CBC";
    PbeUtilities.Algorithms["PBEWITHHMACSHA1"] = "PBEwithHmacSHA-1";
    PbeUtilities.Algorithms["PBEWITHHMACSHA-1"] = "PBEwithHmacSHA-1";
    PbeUtilities.Algorithms[OiwObjectIdentifiers.IdSha1.Id] = "PBEwithHmacSHA-1";
    PbeUtilities.Algorithms["PBEWITHHMACSHA224"] = "PBEwithHmacSHA-224";
    PbeUtilities.Algorithms["PBEWITHHMACSHA-224"] = "PBEwithHmacSHA-224";
    PbeUtilities.Algorithms[NistObjectIdentifiers.IdSha224.Id] = "PBEwithHmacSHA-224";
    PbeUtilities.Algorithms["PBEWITHHMACSHA256"] = "PBEwithHmacSHA-256";
    PbeUtilities.Algorithms["PBEWITHHMACSHA-256"] = "PBEwithHmacSHA-256";
    PbeUtilities.Algorithms[NistObjectIdentifiers.IdSha256.Id] = "PBEwithHmacSHA-256";
    PbeUtilities.Algorithms["PBEWITHHMACRIPEMD128"] = "PBEwithHmacRipeMD128";
    PbeUtilities.Algorithms[TeleTrusTObjectIdentifiers.RipeMD128.Id] = "PBEwithHmacRipeMD128";
    PbeUtilities.Algorithms["PBEWITHHMACRIPEMD160"] = "PBEwithHmacRipeMD160";
    PbeUtilities.Algorithms[TeleTrusTObjectIdentifiers.RipeMD160.Id] = "PBEwithHmacRipeMD160";
    PbeUtilities.Algorithms["PBEWITHHMACRIPEMD256"] = "PBEwithHmacRipeMD256";
    PbeUtilities.Algorithms[TeleTrusTObjectIdentifiers.RipeMD256.Id] = "PBEwithHmacRipeMD256";
    PbeUtilities.Algorithms["PBEWITHHMACTIGER"] = "PBEwithHmacTiger";
    PbeUtilities.Algorithms["PBEWITHMD5AND128BITAES-CBC-OPENSSL"] = "PBEwithMD5and128bitAES-CBC-OpenSSL";
    PbeUtilities.Algorithms["PBEWITHMD5AND192BITAES-CBC-OPENSSL"] = "PBEwithMD5and192bitAES-CBC-OpenSSL";
    PbeUtilities.Algorithms["PBEWITHMD5AND256BITAES-CBC-OPENSSL"] = "PBEwithMD5and256bitAES-CBC-OpenSSL";
    PbeUtilities.AlgorithmType["Pkcs5scheme1"] = nameof (Pkcs5S1);
    PbeUtilities.AlgorithmType["Pkcs5scheme2"] = nameof (Pkcs5S2);
    PbeUtilities.AlgorithmType["PBEwithMD2andDES-CBC"] = nameof (Pkcs5S1);
    PbeUtilities.AlgorithmType["PBEwithMD2andRC2-CBC"] = nameof (Pkcs5S1);
    PbeUtilities.AlgorithmType["PBEwithMD5andDES-CBC"] = nameof (Pkcs5S1);
    PbeUtilities.AlgorithmType["PBEwithMD5andRC2-CBC"] = nameof (Pkcs5S1);
    PbeUtilities.AlgorithmType["PBEwithSHA-1andDES-CBC"] = nameof (Pkcs5S1);
    PbeUtilities.AlgorithmType["PBEwithSHA-1andRC2-CBC"] = nameof (Pkcs5S1);
    PbeUtilities.AlgorithmType[nameof (Pkcs12)] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and128bitRC4"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and40bitRC4"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and3-keyDESEDE-CBC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and2-keyDESEDE-CBC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and128bitRC2-CBC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and40bitRC2-CBC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and128bitAES-CBC-BC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and192bitAES-CBC-BC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1and256bitAES-CBC-BC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-256and128bitAES-CBC-BC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-256and192bitAES-CBC-BC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-256and256bitAES-CBC-BC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1andIDEA-CBC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithSHA-1andTWOFISH-CBC"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithHmacSHA-1"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithHmacSHA-224"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithHmacSHA-256"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithHmacRipeMD128"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithHmacRipeMD160"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithHmacRipeMD256"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithHmacTiger"] = nameof (Pkcs12);
    PbeUtilities.AlgorithmType["PBEwithMD5and128bitAES-CBC-OpenSSL"] = nameof (OpenSsl);
    PbeUtilities.AlgorithmType["PBEwithMD5and192bitAES-CBC-OpenSSL"] = nameof (OpenSsl);
    PbeUtilities.AlgorithmType["PBEwithMD5and256bitAES-CBC-OpenSSL"] = nameof (OpenSsl);
    PbeUtilities.Oids["PBEwithMD2andDES-CBC"] = PkcsObjectIdentifiers.PbeWithMD2AndDesCbc;
    PbeUtilities.Oids["PBEwithMD2andRC2-CBC"] = PkcsObjectIdentifiers.PbeWithMD2AndRC2Cbc;
    PbeUtilities.Oids["PBEwithMD5andDES-CBC"] = PkcsObjectIdentifiers.PbeWithMD5AndDesCbc;
    PbeUtilities.Oids["PBEwithMD5andRC2-CBC"] = PkcsObjectIdentifiers.PbeWithMD5AndRC2Cbc;
    PbeUtilities.Oids["PBEwithSHA-1andDES-CBC"] = PkcsObjectIdentifiers.PbeWithSha1AndDesCbc;
    PbeUtilities.Oids["PBEwithSHA-1andRC2-CBC"] = PkcsObjectIdentifiers.PbeWithSha1AndRC2Cbc;
    PbeUtilities.Oids["PBEwithSHA-1and128bitRC4"] = PkcsObjectIdentifiers.PbeWithShaAnd128BitRC4;
    PbeUtilities.Oids["PBEwithSHA-1and40bitRC4"] = PkcsObjectIdentifiers.PbeWithShaAnd40BitRC4;
    PbeUtilities.Oids["PBEwithSHA-1and3-keyDESEDE-CBC"] = PkcsObjectIdentifiers.PbeWithShaAnd3KeyTripleDesCbc;
    PbeUtilities.Oids["PBEwithSHA-1and2-keyDESEDE-CBC"] = PkcsObjectIdentifiers.PbeWithShaAnd2KeyTripleDesCbc;
    PbeUtilities.Oids["PBEwithSHA-1and128bitRC2-CBC"] = PkcsObjectIdentifiers.PbeWithShaAnd128BitRC2Cbc;
    PbeUtilities.Oids["PBEwithSHA-1and40bitRC2-CBC"] = PkcsObjectIdentifiers.PbewithShaAnd40BitRC2Cbc;
    PbeUtilities.Oids["PBEwithHmacSHA-1"] = OiwObjectIdentifiers.IdSha1;
    PbeUtilities.Oids["PBEwithHmacSHA-224"] = NistObjectIdentifiers.IdSha224;
    PbeUtilities.Oids["PBEwithHmacSHA-256"] = NistObjectIdentifiers.IdSha256;
    PbeUtilities.Oids["PBEwithHmacRipeMD128"] = TeleTrusTObjectIdentifiers.RipeMD128;
    PbeUtilities.Oids["PBEwithHmacRipeMD160"] = TeleTrusTObjectIdentifiers.RipeMD160;
    PbeUtilities.Oids["PBEwithHmacRipeMD256"] = TeleTrusTObjectIdentifiers.RipeMD256;
    PbeUtilities.Oids["Pkcs5scheme2"] = PkcsObjectIdentifiers.IdPbeS2;
  }

  private static PbeParametersGenerator MakePbeGenerator(
    string type,
    IDigest digest,
    byte[] key,
    byte[] salt,
    int iterationCount)
  {
    PbeParametersGenerator parametersGenerator;
    switch (type)
    {
      case "Pkcs5S1":
        parametersGenerator = (PbeParametersGenerator) new Pkcs5S1ParametersGenerator(digest);
        break;
      case "Pkcs5S2":
        parametersGenerator = (PbeParametersGenerator) new Pkcs5S2ParametersGenerator(digest);
        break;
      case "Pkcs12":
        parametersGenerator = (PbeParametersGenerator) new Pkcs12ParametersGenerator(digest);
        break;
      case "OpenSsl":
        parametersGenerator = (PbeParametersGenerator) new OpenSslPbeParametersGenerator();
        break;
      default:
        throw new ArgumentException("Unknown PBE type: " + type, nameof (type));
    }
    parametersGenerator.Init(key, salt, iterationCount);
    return parametersGenerator;
  }

  public static DerObjectIdentifier GetObjectIdentifier(string mechanism)
  {
    string k;
    return !PbeUtilities.Algorithms.TryGetValue(mechanism, out k) ? (DerObjectIdentifier) null : CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>(PbeUtilities.Oids, k);
  }

  public static bool IsPkcs12(string algorithm)
  {
    string key;
    string str;
    return PbeUtilities.Algorithms.TryGetValue(algorithm, out key) && PbeUtilities.AlgorithmType.TryGetValue(key, out str) && "Pkcs12".Equals(str);
  }

  public static bool IsPkcs5Scheme1(string algorithm)
  {
    string key;
    string str;
    return PbeUtilities.Algorithms.TryGetValue(algorithm, out key) && PbeUtilities.AlgorithmType.TryGetValue(key, out str) && "Pkcs5S1".Equals(str);
  }

  public static bool IsPkcs5Scheme2(string algorithm)
  {
    string key;
    string str;
    return PbeUtilities.Algorithms.TryGetValue(algorithm, out key) && PbeUtilities.AlgorithmType.TryGetValue(key, out str) && "Pkcs5S2".Equals(str);
  }

  public static bool IsOpenSsl(string algorithm)
  {
    string key;
    string str;
    return PbeUtilities.Algorithms.TryGetValue(algorithm, out key) && PbeUtilities.AlgorithmType.TryGetValue(key, out str) && "OpenSsl".Equals(str);
  }

  public static bool IsPbeAlgorithm(string algorithm)
  {
    string key;
    return PbeUtilities.Algorithms.TryGetValue(algorithm, out key) && PbeUtilities.AlgorithmType.ContainsKey(key);
  }

  public static Asn1Encodable GenerateAlgorithmParameters(
    DerObjectIdentifier algorithmOid,
    byte[] salt,
    int iterationCount)
  {
    return PbeUtilities.GenerateAlgorithmParameters(algorithmOid.Id, salt, iterationCount);
  }

  public static Asn1Encodable GenerateAlgorithmParameters(
    string algorithm,
    byte[] salt,
    int iterationCount)
  {
    if (PbeUtilities.IsPkcs12(algorithm))
      return (Asn1Encodable) new Pkcs12PbeParams(salt, iterationCount);
    return PbeUtilities.IsPkcs5Scheme2(algorithm) ? (Asn1Encodable) new Pbkdf2Params(salt, iterationCount) : (Asn1Encodable) new PbeParameter(salt, iterationCount);
  }

  public static Asn1Encodable GenerateAlgorithmParameters(
    DerObjectIdentifier cipherAlgorithm,
    DerObjectIdentifier hashAlgorithm,
    byte[] salt,
    int iterationCount,
    SecureRandom secureRandom)
  {
    if (!NistObjectIdentifiers.IdAes128Cbc.Equals((Asn1Object) cipherAlgorithm) && !NistObjectIdentifiers.IdAes192Cbc.Equals((Asn1Object) cipherAlgorithm) && !NistObjectIdentifiers.IdAes256Cbc.Equals((Asn1Object) cipherAlgorithm) && !NistObjectIdentifiers.IdAes128Cfb.Equals((Asn1Object) cipherAlgorithm) && !NistObjectIdentifiers.IdAes192Cfb.Equals((Asn1Object) cipherAlgorithm) && !NistObjectIdentifiers.IdAes256Cfb.Equals((Asn1Object) cipherAlgorithm))
      throw new ArgumentException("unknown cipher: " + cipherAlgorithm?.ToString());
    byte[] numArray = new byte[16 /*0x10*/];
    secureRandom.NextBytes(numArray);
    EncryptionScheme encScheme = new EncryptionScheme(cipherAlgorithm, (Asn1Encodable) new DerOctetString(numArray));
    return (Asn1Encodable) new PbeS2Parameters(new KeyDerivationFunc(PkcsObjectIdentifiers.IdPbkdf2, (Asn1Encodable) new Pbkdf2Params(salt, iterationCount, new AlgorithmIdentifier(hashAlgorithm, (Asn1Encodable) DerNull.Instance))), encScheme);
  }

  public static ICipherParameters GenerateCipherParameters(
    DerObjectIdentifier algorithmOid,
    char[] password,
    Asn1Encodable pbeParameters)
  {
    return PbeUtilities.GenerateCipherParameters(algorithmOid.Id, password, false, pbeParameters);
  }

  public static ICipherParameters GenerateCipherParameters(
    DerObjectIdentifier algorithmOid,
    char[] password,
    bool wrongPkcs12Zero,
    Asn1Encodable pbeParameters)
  {
    return PbeUtilities.GenerateCipherParameters(algorithmOid.Id, password, wrongPkcs12Zero, pbeParameters);
  }

  public static ICipherParameters GenerateCipherParameters(
    AlgorithmIdentifier algID,
    char[] password)
  {
    return PbeUtilities.GenerateCipherParameters(algID.Algorithm.Id, password, false, algID.Parameters);
  }

  public static ICipherParameters GenerateCipherParameters(
    AlgorithmIdentifier algID,
    char[] password,
    bool wrongPkcs12Zero)
  {
    return PbeUtilities.GenerateCipherParameters(algID.Algorithm.Id, password, wrongPkcs12Zero, algID.Parameters);
  }

  public static ICipherParameters GenerateCipherParameters(
    string algorithm,
    char[] password,
    Asn1Encodable pbeParameters)
  {
    return PbeUtilities.GenerateCipherParameters(algorithm, password, false, pbeParameters);
  }

  public static ICipherParameters GenerateCipherParameters(
    string algorithm,
    char[] password,
    bool wrongPkcs12Zero,
    Asn1Encodable pbeParameters)
  {
    string valueOrNull = CollectionUtilities.GetValueOrNull<string, string>(PbeUtilities.Algorithms, algorithm);
    byte[] key = (byte[]) null;
    byte[] salt1 = (byte[]) null;
    int iterationCount = 0;
    if (PbeUtilities.IsPkcs12(valueOrNull))
    {
      Pkcs12PbeParams instance = Pkcs12PbeParams.GetInstance((object) pbeParameters);
      salt1 = instance.GetIV();
      iterationCount = instance.Iterations.IntValue;
      key = PbeParametersGenerator.Pkcs12PasswordToBytes(password, wrongPkcs12Zero);
    }
    else if (!PbeUtilities.IsPkcs5Scheme2(valueOrNull))
    {
      PbeParameter instance = PbeParameter.GetInstance((object) pbeParameters);
      salt1 = instance.GetSalt();
      iterationCount = instance.IterationCount.IntValue;
      key = PbeParametersGenerator.Pkcs5PasswordToBytes(password);
    }
    ICipherParameters parameters = (ICipherParameters) null;
    if (PbeUtilities.IsPkcs5Scheme2(valueOrNull))
    {
      PbeS2Parameters instance1 = PbeS2Parameters.GetInstance((object) pbeParameters.ToAsn1Object());
      EncryptionScheme encryptionScheme = instance1.EncryptionScheme;
      DerObjectIdentifier algorithm1 = encryptionScheme.Algorithm;
      Asn1Object asn1Object = encryptionScheme.Parameters.ToAsn1Object();
      Pbkdf2Params instance2 = Pbkdf2Params.GetInstance((object) instance1.KeyDerivationFunc.Parameters.ToAsn1Object());
      IDigest digest = DigestUtilities.GetDigest(instance2.Prf.Algorithm);
      byte[] numArray = !algorithm1.Equals((Asn1Object) PkcsObjectIdentifiers.RC2Cbc) ? Asn1OctetString.GetInstance((object) asn1Object).GetOctets() : RC2CbcParameter.GetInstance((object) asn1Object).GetIV();
      byte[] salt2 = instance2.GetSalt();
      int intValue = instance2.IterationCount.IntValue;
      key = PbeParametersGenerator.Pkcs5PasswordToBytes(password);
      int keySize = instance2.KeyLength != null ? instance2.KeyLength.IntValue * 8 : GeneratorUtilities.GetDefaultKeySize(algorithm1);
      parameters = PbeUtilities.MakePbeGenerator(PbeUtilities.AlgorithmType[valueOrNull], digest, key, salt2, intValue).GenerateDerivedParameters(algorithm1.Id, keySize);
      if (numArray != null && !Arrays.AreEqual(numArray, new byte[numArray.Length]))
        parameters = (ICipherParameters) new ParametersWithIV(parameters, numArray);
    }
    else if (Platform.StartsWith(valueOrNull, "PBEwithSHA-1"))
    {
      PbeParametersGenerator parametersGenerator = PbeUtilities.MakePbeGenerator(PbeUtilities.AlgorithmType[valueOrNull], (IDigest) new Sha1Digest(), key, salt1, iterationCount);
      switch (valueOrNull)
      {
        case "PBEwithSHA-1and128bitAES-CBC-BC":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 128 /*0x80*/, 128 /*0x80*/);
          break;
        case "PBEwithSHA-1and192bitAES-CBC-BC":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 192 /*0xC0*/, 128 /*0x80*/);
          break;
        case "PBEwithSHA-1and256bitAES-CBC-BC":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 256 /*0x0100*/, 128 /*0x80*/);
          break;
        case "PBEwithSHA-1and128bitRC4":
          parameters = parametersGenerator.GenerateDerivedParameters("RC4", 128 /*0x80*/);
          break;
        case "PBEwithSHA-1and40bitRC4":
          parameters = parametersGenerator.GenerateDerivedParameters("RC4", 40);
          break;
        case "PBEwithSHA-1and3-keyDESEDE-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("DESEDE", 192 /*0xC0*/, 64 /*0x40*/);
          break;
        case "PBEwithSHA-1and2-keyDESEDE-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("DESEDE", 128 /*0x80*/, 64 /*0x40*/);
          break;
        case "PBEwithSHA-1and128bitRC2-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("RC2", 128 /*0x80*/, 64 /*0x40*/);
          break;
        case "PBEwithSHA-1and40bitRC2-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("RC2", 40, 64 /*0x40*/);
          break;
        case "PBEwithSHA-1andDES-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("DES", 64 /*0x40*/, 64 /*0x40*/);
          break;
        case "PBEwithSHA-1andRC2-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("RC2", 64 /*0x40*/, 64 /*0x40*/);
          break;
      }
    }
    else if (Platform.StartsWith(valueOrNull, "PBEwithSHA-256"))
    {
      PbeParametersGenerator parametersGenerator = PbeUtilities.MakePbeGenerator(PbeUtilities.AlgorithmType[valueOrNull], (IDigest) new Sha256Digest(), key, salt1, iterationCount);
      switch (valueOrNull)
      {
        case "PBEwithSHA-256and128bitAES-CBC-BC":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 128 /*0x80*/, 128 /*0x80*/);
          break;
        case "PBEwithSHA-256and192bitAES-CBC-BC":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 192 /*0xC0*/, 128 /*0x80*/);
          break;
        case "PBEwithSHA-256and256bitAES-CBC-BC":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 256 /*0x0100*/, 128 /*0x80*/);
          break;
      }
    }
    else if (Platform.StartsWith(valueOrNull, "PBEwithMD5"))
    {
      PbeParametersGenerator parametersGenerator = PbeUtilities.MakePbeGenerator(PbeUtilities.AlgorithmType[valueOrNull], (IDigest) new MD5Digest(), key, salt1, iterationCount);
      switch (valueOrNull)
      {
        case "PBEwithMD5andDES-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("DES", 64 /*0x40*/, 64 /*0x40*/);
          break;
        case "PBEwithMD5andRC2-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("RC2", 64 /*0x40*/, 64 /*0x40*/);
          break;
        case "PBEwithMD5and128bitAES-CBC-OpenSSL":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 128 /*0x80*/, 128 /*0x80*/);
          break;
        case "PBEwithMD5and192bitAES-CBC-OpenSSL":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 192 /*0xC0*/, 128 /*0x80*/);
          break;
        case "PBEwithMD5and256bitAES-CBC-OpenSSL":
          parameters = parametersGenerator.GenerateDerivedParameters("AES", 256 /*0x0100*/, 128 /*0x80*/);
          break;
      }
    }
    else if (Platform.StartsWith(valueOrNull, "PBEwithMD2"))
    {
      PbeParametersGenerator parametersGenerator = PbeUtilities.MakePbeGenerator(PbeUtilities.AlgorithmType[valueOrNull], (IDigest) new MD2Digest(), key, salt1, iterationCount);
      switch (valueOrNull)
      {
        case "PBEwithMD2andDES-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("DES", 64 /*0x40*/, 64 /*0x40*/);
          break;
        case "PBEwithMD2andRC2-CBC":
          parameters = parametersGenerator.GenerateDerivedParameters("RC2", 64 /*0x40*/, 64 /*0x40*/);
          break;
      }
    }
    else if (Platform.StartsWith(valueOrNull, "PBEwithHmac"))
    {
      IDigest digest = DigestUtilities.GetDigest(valueOrNull.Substring("PBEwithHmac".Length));
      parameters = PbeUtilities.MakePbeGenerator(PbeUtilities.AlgorithmType[valueOrNull], digest, key, salt1, iterationCount).GenerateDerivedMacParameters(digest.GetDigestSize() * 8);
    }
    Array.Clear((Array) key, 0, key.Length);
    return PbeUtilities.FixDesParity(valueOrNull, parameters);
  }

  public static object CreateEngine(DerObjectIdentifier algorithmOid)
  {
    return PbeUtilities.CreateEngine(algorithmOid.Id);
  }

  public static object CreateEngine(AlgorithmIdentifier algID)
  {
    string id = algID.Algorithm.Id;
    return PbeUtilities.IsPkcs5Scheme2(id) ? (object) CipherUtilities.GetCipher(PbeS2Parameters.GetInstance((object) algID.Parameters.ToAsn1Object()).EncryptionScheme.Algorithm) : PbeUtilities.CreateEngine(id);
  }

  public static object CreateEngine(string algorithm)
  {
    string valueOrNull = CollectionUtilities.GetValueOrNull<string, string>(PbeUtilities.Algorithms, algorithm);
    if (Platform.StartsWith(valueOrNull, "PBEwithHmac"))
      return (object) MacUtilities.GetMac("HMAC/" + valueOrNull.Substring("PBEwithHmac".Length));
    if (Platform.StartsWith(valueOrNull, "PBEwithMD2") || Platform.StartsWith(valueOrNull, "PBEwithMD5") || Platform.StartsWith(valueOrNull, "PBEwithSHA-1") || Platform.StartsWith(valueOrNull, "PBEwithSHA-256"))
    {
      if (Platform.EndsWith(valueOrNull, "AES-CBC-BC") || Platform.EndsWith(valueOrNull, "AES-CBC-OPENSSL"))
        return (object) CipherUtilities.GetCipher("AES/CBC");
      if (Platform.EndsWith(valueOrNull, "DES-CBC"))
        return (object) CipherUtilities.GetCipher("DES/CBC");
      if (Platform.EndsWith(valueOrNull, "DESEDE-CBC"))
        return (object) CipherUtilities.GetCipher("DESEDE/CBC");
      if (Platform.EndsWith(valueOrNull, "RC2-CBC"))
        return (object) CipherUtilities.GetCipher("RC2/CBC");
      if (Platform.EndsWith(valueOrNull, "RC4"))
        return (object) CipherUtilities.GetCipher("RC4");
    }
    return (object) null;
  }

  public static string GetEncodingName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(PbeUtilities.Algorithms, oid.Id);
  }

  private static ICipherParameters FixDesParity(string mechanism, ICipherParameters parameters)
  {
    if (!Platform.EndsWith(mechanism, "DES-CBC") && !Platform.EndsWith(mechanism, "DESEDE-CBC"))
      return parameters;
    if (parameters is ParametersWithIV)
    {
      ParametersWithIV parametersWithIv = (ParametersWithIV) parameters;
      return (ICipherParameters) new ParametersWithIV(PbeUtilities.FixDesParity(mechanism, parametersWithIv.Parameters), parametersWithIv.GetIV());
    }
    byte[] key = ((KeyParameter) parameters).GetKey();
    DesParameters.SetOddParity(key);
    return (ICipherParameters) new KeyParameter(key);
  }
}
