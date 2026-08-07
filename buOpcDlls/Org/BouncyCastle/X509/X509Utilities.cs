// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509Utilities
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
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.X509;

internal static class X509Utilities
{
  private static readonly Dictionary<string, DerObjectIdentifier> m_algorithms = new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<string, Asn1Encodable> m_exParams = new Dictionary<string, Asn1Encodable>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly HashSet<DerObjectIdentifier> m_noParams = new HashSet<DerObjectIdentifier>();

  static X509Utilities()
  {
    X509Utilities.m_algorithms.Add("MD2WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    X509Utilities.m_algorithms.Add("MD2WITHRSA", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    X509Utilities.m_algorithms.Add("MD5WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    X509Utilities.m_algorithms.Add("MD5WITHRSA", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA-512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    X509Utilities.m_algorithms.Add("SHA512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA-512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    X509Utilities.m_algorithms.Add("SHA1WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA224WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA256WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA384WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("SHA512WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    X509Utilities.m_algorithms.Add("RIPEMD160WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    X509Utilities.m_algorithms.Add("RIPEMD160WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    X509Utilities.m_algorithms.Add("RIPEMD128WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    X509Utilities.m_algorithms.Add("RIPEMD128WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    X509Utilities.m_algorithms.Add("RIPEMD256WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    X509Utilities.m_algorithms.Add("RIPEMD256WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    X509Utilities.m_algorithms.Add("SHA1WITHDSA", X9ObjectIdentifiers.IdDsaWithSha1);
    X509Utilities.m_algorithms.Add("DSAWITHSHA1", X9ObjectIdentifiers.IdDsaWithSha1);
    X509Utilities.m_algorithms.Add("SHA224WITHDSA", NistObjectIdentifiers.DsaWithSha224);
    X509Utilities.m_algorithms.Add("SHA256WITHDSA", NistObjectIdentifiers.DsaWithSha256);
    X509Utilities.m_algorithms.Add("SHA384WITHDSA", NistObjectIdentifiers.DsaWithSha384);
    X509Utilities.m_algorithms.Add("SHA512WITHDSA", NistObjectIdentifiers.DsaWithSha512);
    X509Utilities.m_algorithms.Add("SHA1WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha1);
    X509Utilities.m_algorithms.Add("ECDSAWITHSHA1", X9ObjectIdentifiers.ECDsaWithSha1);
    X509Utilities.m_algorithms.Add("SHA224WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha224);
    X509Utilities.m_algorithms.Add("SHA256WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha256);
    X509Utilities.m_algorithms.Add("SHA384WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha384);
    X509Utilities.m_algorithms.Add("SHA512WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha512);
    X509Utilities.m_algorithms.Add("GOST3411WITHGOST3410", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    X509Utilities.m_algorithms.Add("GOST3411WITHGOST3410-94", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    X509Utilities.m_algorithms.Add("GOST3411WITHECGOST3410", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    X509Utilities.m_algorithms.Add("GOST3411WITHECGOST3410-2001", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    X509Utilities.m_algorithms.Add("GOST3411WITHGOST3410-2001", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    X509Utilities.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha1);
    X509Utilities.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha224);
    X509Utilities.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha256);
    X509Utilities.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha384);
    X509Utilities.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha512);
    X509Utilities.m_noParams.Add(X9ObjectIdentifiers.IdDsaWithSha1);
    X509Utilities.m_noParams.Add(OiwObjectIdentifiers.DsaWithSha1);
    X509Utilities.m_noParams.Add(NistObjectIdentifiers.DsaWithSha224);
    X509Utilities.m_noParams.Add(NistObjectIdentifiers.DsaWithSha256);
    X509Utilities.m_noParams.Add(NistObjectIdentifiers.DsaWithSha384);
    X509Utilities.m_noParams.Add(NistObjectIdentifiers.DsaWithSha512);
    X509Utilities.m_noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    X509Utilities.m_noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    AlgorithmIdentifier hashAlgId1 = new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA1WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId1, 20));
    AlgorithmIdentifier hashAlgId2 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha224, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA224WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId2, 28));
    AlgorithmIdentifier hashAlgId3 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA256WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId3, 32 /*0x20*/));
    AlgorithmIdentifier hashAlgId4 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha384, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA384WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId4, 48 /*0x30*/));
    AlgorithmIdentifier hashAlgId5 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha512, (Asn1Encodable) DerNull.Instance);
    X509Utilities.m_exParams.Add("SHA512WITHRSAANDMGF1", (Asn1Encodable) X509Utilities.CreatePssParams(hashAlgId5, 64 /*0x40*/));
  }

  internal static TResult CalculateResult<TResult>(
    IStreamCalculator<TResult> streamCalculator,
    Asn1Encodable asn1Encodable)
  {
    using (Stream stream = streamCalculator.Stream)
      asn1Encodable.EncodeTo(stream, "DER");
    return streamCalculator.GetResult();
  }

  private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
  {
    return new RsassaPssParameters(hashAlgId, new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) hashAlgId), new DerInteger(saltSize), new DerInteger(1));
  }

  internal static DerBitString CollectDerBitString(IBlockResult result)
  {
    return new DerBitString(result.Collect());
  }

  internal static DerObjectIdentifier GetAlgorithmOid(string algorithmName)
  {
    DerObjectIdentifier objectIdentifier;
    return X509Utilities.m_algorithms.TryGetValue(algorithmName, out objectIdentifier) ? objectIdentifier : new DerObjectIdentifier(algorithmName);
  }

  internal static AlgorithmIdentifier GetSigAlgID(DerObjectIdentifier sigOid, string algorithmName)
  {
    if (X509Utilities.m_noParams.Contains(sigOid))
      return new AlgorithmIdentifier(sigOid);
    Asn1Encodable parameters;
    return X509Utilities.m_exParams.TryGetValue(algorithmName, out parameters) ? new AlgorithmIdentifier(sigOid, parameters) : new AlgorithmIdentifier(sigOid, (Asn1Encodable) DerNull.Instance);
  }

  internal static IEnumerable<string> GetAlgNames()
  {
    return CollectionUtilities.Proxy<string>((IEnumerable<string>) X509Utilities.m_algorithms.Keys);
  }

  internal static DerBitString GenerateBitString(
    IStreamCalculator<IBlockResult> streamCalculator,
    Asn1Encodable asn1Encodable)
  {
    return X509Utilities.CollectDerBitString(X509Utilities.CalculateResult<IBlockResult>(streamCalculator, asn1Encodable));
  }

  internal static DerBitString GenerateMac(IMacFactory macFactory, Asn1Encodable asn1Encodable)
  {
    return X509Utilities.GenerateBitString(macFactory.CreateCalculator(), asn1Encodable);
  }

  internal static DerBitString GenerateSignature(
    ISignatureFactory signatureFactory,
    Asn1Encodable asn1Encodable)
  {
    return X509Utilities.GenerateBitString(signatureFactory.CreateCalculator(), asn1Encodable);
  }

  internal static bool VerifySignature(
    IVerifierFactory verifierFactory,
    Asn1Encodable asn1Encodable,
    DerBitString signature)
  {
    return X509Utilities.CalculateResult<IVerifier>(verifierFactory.CreateCalculator(), asn1Encodable).IsVerified(signature.GetOctets());
  }

  internal static Asn1TaggedObject TrimExtensions(int tagNo, X509Extensions exts)
  {
    Asn1Sequence instance1 = Asn1Sequence.GetInstance((object) exts.ToAsn1Object());
    Asn1EncodableVector elementVector = new Asn1EncodableVector();
    foreach (object obj in instance1)
    {
      Asn1Sequence instance2 = Asn1Sequence.GetInstance(obj);
      if (!X509Extensions.AltSignatureValue.Equals((object) instance2[0]))
        elementVector.Add((Asn1Encodable) instance2);
    }
    return (Asn1TaggedObject) new DerTaggedObject(true, tagNo, (Asn1Encodable) new DerSequence(elementVector));
  }
}
