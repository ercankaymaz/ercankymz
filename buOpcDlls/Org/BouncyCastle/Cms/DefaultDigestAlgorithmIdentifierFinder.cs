// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.DefaultDigestAlgorithmIdentifierFinder
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
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class DefaultDigestAlgorithmIdentifierFinder
{
  private static readonly IDictionary<DerObjectIdentifier, DerObjectIdentifier> m_digestOids = (IDictionary<DerObjectIdentifier, DerObjectIdentifier>) new Dictionary<DerObjectIdentifier, DerObjectIdentifier>();
  private static readonly IDictionary<string, DerObjectIdentifier> m_digestNameToOids = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static DefaultDigestAlgorithmIdentifierFinder()
  {
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(OiwObjectIdentifiers.MD4WithRsaEncryption, PkcsObjectIdentifiers.MD4);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(OiwObjectIdentifiers.MD4WithRsa, PkcsObjectIdentifiers.MD4);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(OiwObjectIdentifiers.MD5WithRsa, PkcsObjectIdentifiers.MD5);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(OiwObjectIdentifiers.Sha1WithRsa, OiwObjectIdentifiers.IdSha1);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(OiwObjectIdentifiers.DsaWithSha1, OiwObjectIdentifiers.IdSha1);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.Sha224WithRsaEncryption, NistObjectIdentifiers.IdSha224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.Sha256WithRsaEncryption, NistObjectIdentifiers.IdSha256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.Sha384WithRsaEncryption, NistObjectIdentifiers.IdSha384);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.Sha512WithRsaEncryption, NistObjectIdentifiers.IdSha512);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.Sha512_224WithRSAEncryption, NistObjectIdentifiers.IdSha512_224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.Sha512_256WithRSAEncryption, NistObjectIdentifiers.IdSha512_256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224, NistObjectIdentifiers.IdSha3_224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256, NistObjectIdentifiers.IdSha3_256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384, NistObjectIdentifiers.IdSha3_384);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512, NistObjectIdentifiers.IdSha3_512);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.MD2WithRsaEncryption, PkcsObjectIdentifiers.MD2);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.MD4WithRsaEncryption, PkcsObjectIdentifiers.MD4);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.MD5WithRsaEncryption, PkcsObjectIdentifiers.MD5);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(PkcsObjectIdentifiers.Sha1WithRsaEncryption, OiwObjectIdentifiers.IdSha1);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(X9ObjectIdentifiers.ECDsaWithSha1, OiwObjectIdentifiers.IdSha1);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(X9ObjectIdentifiers.ECDsaWithSha224, NistObjectIdentifiers.IdSha224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(X9ObjectIdentifiers.ECDsaWithSha256, NistObjectIdentifiers.IdSha256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(X9ObjectIdentifiers.ECDsaWithSha384, NistObjectIdentifiers.IdSha384);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(X9ObjectIdentifiers.ECDsaWithSha512, NistObjectIdentifiers.IdSha512);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(X9ObjectIdentifiers.IdDsaWithSha1, OiwObjectIdentifiers.IdSha1);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.DsaWithSha224, NistObjectIdentifiers.IdSha224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.DsaWithSha256, NistObjectIdentifiers.IdSha256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.DsaWithSha384, NistObjectIdentifiers.IdSha384);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(NistObjectIdentifiers.DsaWithSha512, NistObjectIdentifiers.IdSha512);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128, TeleTrusTObjectIdentifiers.RipeMD128);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160, TeleTrusTObjectIdentifiers.RipeMD160);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256, TeleTrusTObjectIdentifiers.RipeMD256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94, CryptoProObjectIdentifiers.GostR3411);
    DefaultDigestAlgorithmIdentifierFinder.m_digestOids.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001, CryptoProObjectIdentifiers.GostR3411);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-1", OiwObjectIdentifiers.IdSha1);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-224", NistObjectIdentifiers.IdSha224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-256", NistObjectIdentifiers.IdSha256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-384", NistObjectIdentifiers.IdSha384);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-512", NistObjectIdentifiers.IdSha512);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-512/224", NistObjectIdentifiers.IdSha512_224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-512(224)", NistObjectIdentifiers.IdSha512_224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-512/256", NistObjectIdentifiers.IdSha512_256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA-512(256)", NistObjectIdentifiers.IdSha512_256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA1", OiwObjectIdentifiers.IdSha1);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA224", NistObjectIdentifiers.IdSha224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA256", NistObjectIdentifiers.IdSha256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA384", NistObjectIdentifiers.IdSha384);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA512", NistObjectIdentifiers.IdSha512);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA512/224", NistObjectIdentifiers.IdSha512_224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA512(224)", NistObjectIdentifiers.IdSha512_224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA512/256", NistObjectIdentifiers.IdSha512_256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA512(256)", NistObjectIdentifiers.IdSha512_256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA3-224", NistObjectIdentifiers.IdSha3_224);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA3-256", NistObjectIdentifiers.IdSha3_256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA3-384", NistObjectIdentifiers.IdSha3_384);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHA3-512", NistObjectIdentifiers.IdSha3_512);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHAKE-128", NistObjectIdentifiers.IdShake128);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("SHAKE-256", NistObjectIdentifiers.IdShake256);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("GOST3411", CryptoProObjectIdentifiers.GostR3411);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("MD2", PkcsObjectIdentifiers.MD2);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("MD4", PkcsObjectIdentifiers.MD4);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("MD5", PkcsObjectIdentifiers.MD5);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("RIPEMD128", TeleTrusTObjectIdentifiers.RipeMD128);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("RIPEMD160", TeleTrusTObjectIdentifiers.RipeMD160);
    DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids.Add("RIPEMD256", TeleTrusTObjectIdentifiers.RipeMD256);
  }

  public AlgorithmIdentifier Find(AlgorithmIdentifier sigAlgId)
  {
    return !sigAlgId.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsassaPss) ? new AlgorithmIdentifier(DefaultDigestAlgorithmIdentifierFinder.m_digestOids[sigAlgId.Algorithm], (Asn1Encodable) DerNull.Instance) : RsassaPssParameters.GetInstance((object) sigAlgId.Parameters).HashAlgorithm;
  }

  public AlgorithmIdentifier Find(string digAlgName)
  {
    return new AlgorithmIdentifier(DefaultDigestAlgorithmIdentifierFinder.m_digestNameToOids[digAlgName], (Asn1Encodable) DerNull.Instance);
  }
}
