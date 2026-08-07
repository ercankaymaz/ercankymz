// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.OcspUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

internal class OcspUtilities
{
  private static readonly Dictionary<string, DerObjectIdentifier> Algorithms = new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<DerObjectIdentifier, string> Oids = new Dictionary<DerObjectIdentifier, string>();
  private static readonly HashSet<DerObjectIdentifier> NoParams = new HashSet<DerObjectIdentifier>();

  static OcspUtilities()
  {
    OcspUtilities.Algorithms.Add("MD2WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    OcspUtilities.Algorithms.Add("MD2WITHRSA", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    OcspUtilities.Algorithms.Add("MD5WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    OcspUtilities.Algorithms.Add("MD5WITHRSA", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA-512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    OcspUtilities.Algorithms.Add("SHA512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    OcspUtilities.Algorithms.Add("SHA-512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    OcspUtilities.Algorithms.Add("SHA512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    OcspUtilities.Algorithms.Add("SHA-512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    OcspUtilities.Algorithms.Add("SHA512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    OcspUtilities.Algorithms.Add("SHA-512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    OcspUtilities.Algorithms.Add("SHA512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    OcspUtilities.Algorithms.Add("SHA-512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    OcspUtilities.Algorithms.Add("RIPEMD160WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    OcspUtilities.Algorithms.Add("RIPEMD160WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    OcspUtilities.Algorithms.Add("RIPEMD128WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    OcspUtilities.Algorithms.Add("RIPEMD128WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    OcspUtilities.Algorithms.Add("RIPEMD256WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    OcspUtilities.Algorithms.Add("RIPEMD256WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    OcspUtilities.Algorithms.Add("SHA1WITHDSA", X9ObjectIdentifiers.IdDsaWithSha1);
    OcspUtilities.Algorithms.Add("DSAWITHSHA1", X9ObjectIdentifiers.IdDsaWithSha1);
    OcspUtilities.Algorithms.Add("SHA224WITHDSA", NistObjectIdentifiers.DsaWithSha224);
    OcspUtilities.Algorithms.Add("SHA256WITHDSA", NistObjectIdentifiers.DsaWithSha256);
    OcspUtilities.Algorithms.Add("SHA1WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha1);
    OcspUtilities.Algorithms.Add("ECDSAWITHSHA1", X9ObjectIdentifiers.ECDsaWithSha1);
    OcspUtilities.Algorithms.Add("SHA224WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha224);
    OcspUtilities.Algorithms.Add("SHA256WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha256);
    OcspUtilities.Algorithms.Add("SHA384WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha384);
    OcspUtilities.Algorithms.Add("SHA512WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha512);
    OcspUtilities.Algorithms.Add("GOST3411WITHGOST3410", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    OcspUtilities.Algorithms.Add("GOST3411WITHGOST3410-94", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.MD2WithRsaEncryption, "MD2WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.MD5WithRsaEncryption, "MD5WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.Sha1WithRsaEncryption, "SHA1WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.Sha224WithRsaEncryption, "SHA224WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.Sha256WithRsaEncryption, "SHA256WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.Sha384WithRsaEncryption, "SHA384WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.Sha512WithRsaEncryption, "SHA512WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.Sha512_224WithRSAEncryption, "SHA512(224)WITHRSA");
    OcspUtilities.Oids.Add(PkcsObjectIdentifiers.Sha512_256WithRSAEncryption, "SHA512(256)WITHRSA");
    OcspUtilities.Oids.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160, "RIPEMD160WITHRSA");
    OcspUtilities.Oids.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128, "RIPEMD128WITHRSA");
    OcspUtilities.Oids.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256, "RIPEMD256WITHRSA");
    OcspUtilities.Oids.Add(X9ObjectIdentifiers.IdDsaWithSha1, "SHA1WITHDSA");
    OcspUtilities.Oids.Add(NistObjectIdentifiers.DsaWithSha224, "SHA224WITHDSA");
    OcspUtilities.Oids.Add(NistObjectIdentifiers.DsaWithSha256, "SHA256WITHDSA");
    OcspUtilities.Oids.Add(X9ObjectIdentifiers.ECDsaWithSha1, "SHA1WITHECDSA");
    OcspUtilities.Oids.Add(X9ObjectIdentifiers.ECDsaWithSha224, "SHA224WITHECDSA");
    OcspUtilities.Oids.Add(X9ObjectIdentifiers.ECDsaWithSha256, "SHA256WITHECDSA");
    OcspUtilities.Oids.Add(X9ObjectIdentifiers.ECDsaWithSha384, "SHA384WITHECDSA");
    OcspUtilities.Oids.Add(X9ObjectIdentifiers.ECDsaWithSha512, "SHA512WITHECDSA");
    OcspUtilities.Oids.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94, "GOST3411WITHGOST3410");
    OcspUtilities.Oids.Add(OiwObjectIdentifiers.MD5WithRsa, "MD5WITHRSA");
    OcspUtilities.Oids.Add(OiwObjectIdentifiers.Sha1WithRsa, "SHA1WITHRSA");
    OcspUtilities.Oids.Add(OiwObjectIdentifiers.DsaWithSha1, "SHA1WITHDSA");
    OcspUtilities.NoParams.Add(X9ObjectIdentifiers.ECDsaWithSha1);
    OcspUtilities.NoParams.Add(X9ObjectIdentifiers.ECDsaWithSha224);
    OcspUtilities.NoParams.Add(X9ObjectIdentifiers.ECDsaWithSha256);
    OcspUtilities.NoParams.Add(X9ObjectIdentifiers.ECDsaWithSha384);
    OcspUtilities.NoParams.Add(X9ObjectIdentifiers.ECDsaWithSha512);
    OcspUtilities.NoParams.Add(X9ObjectIdentifiers.IdDsaWithSha1);
    OcspUtilities.NoParams.Add(OiwObjectIdentifiers.DsaWithSha1);
    OcspUtilities.NoParams.Add(NistObjectIdentifiers.DsaWithSha224);
    OcspUtilities.NoParams.Add(NistObjectIdentifiers.DsaWithSha256);
  }

  internal static DerObjectIdentifier GetAlgorithmOid(string algorithmName)
  {
    DerObjectIdentifier objectIdentifier;
    return OcspUtilities.Algorithms.TryGetValue(algorithmName, out objectIdentifier) ? objectIdentifier : new DerObjectIdentifier(algorithmName);
  }

  internal static string GetAlgorithmName(DerObjectIdentifier oid)
  {
    string str;
    return OcspUtilities.Oids.TryGetValue(oid, out str) ? str : oid.Id;
  }

  internal static AlgorithmIdentifier GetSigAlgID(DerObjectIdentifier sigOid)
  {
    return OcspUtilities.NoParams.Contains(sigOid) ? new AlgorithmIdentifier(sigOid) : new AlgorithmIdentifier(sigOid, (Asn1Encodable) DerNull.Instance);
  }

  internal static IEnumerable<string> AlgNames
  {
    get => CollectionUtilities.Proxy<string>((IEnumerable<string>) OcspUtilities.Algorithms.Keys);
  }
}
