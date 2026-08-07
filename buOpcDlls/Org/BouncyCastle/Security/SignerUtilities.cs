// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.SignerUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Bsi;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Eac;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class SignerUtilities
{
  private static readonly IDictionary<string, string> AlgorithmMap = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly HashSet<string> NoRandom = new HashSet<string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly IDictionary<string, DerObjectIdentifier> Oids = (IDictionary<string, DerObjectIdentifier>) new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static SignerUtilities()
  {
    SignerUtilities.AlgorithmMap["MD2WITHRSA"] = "MD2withRSA";
    SignerUtilities.AlgorithmMap["MD2WITHRSAENCRYPTION"] = "MD2withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.MD2WithRsaEncryption.Id] = "MD2withRSA";
    SignerUtilities.AlgorithmMap["MD4WITHRSA"] = "MD4withRSA";
    SignerUtilities.AlgorithmMap["MD4WITHRSAENCRYPTION"] = "MD4withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.MD4WithRsaEncryption.Id] = "MD4withRSA";
    SignerUtilities.AlgorithmMap[OiwObjectIdentifiers.MD4WithRsa.Id] = "MD4withRSA";
    SignerUtilities.AlgorithmMap[OiwObjectIdentifiers.MD4WithRsaEncryption.Id] = "MD4withRSA";
    SignerUtilities.AlgorithmMap["MD5WITHRSA"] = "MD5withRSA";
    SignerUtilities.AlgorithmMap["MD5WITHRSAENCRYPTION"] = "MD5withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.MD5WithRsaEncryption.Id] = "MD5withRSA";
    SignerUtilities.AlgorithmMap[OiwObjectIdentifiers.MD5WithRsa.Id] = "MD5withRSA";
    SignerUtilities.AlgorithmMap["SHA1WITHRSA"] = "SHA-1withRSA";
    SignerUtilities.AlgorithmMap["SHA-1WITHRSA"] = "SHA-1withRSA";
    SignerUtilities.AlgorithmMap["SHA1WITHRSAENCRYPTION"] = "SHA-1withRSA";
    SignerUtilities.AlgorithmMap["SHA-1WITHRSAENCRYPTION"] = "SHA-1withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.Sha1WithRsaEncryption.Id] = "SHA-1withRSA";
    SignerUtilities.AlgorithmMap[OiwObjectIdentifiers.Sha1WithRsa.Id] = "SHA-1withRSA";
    SignerUtilities.AlgorithmMap["SHA224WITHRSA"] = "SHA-224withRSA";
    SignerUtilities.AlgorithmMap["SHA-224WITHRSA"] = "SHA-224withRSA";
    SignerUtilities.AlgorithmMap["SHA224WITHRSAENCRYPTION"] = "SHA-224withRSA";
    SignerUtilities.AlgorithmMap["SHA-224WITHRSAENCRYPTION"] = "SHA-224withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.Sha224WithRsaEncryption.Id] = "SHA-224withRSA";
    SignerUtilities.AlgorithmMap["SHA256WITHRSA"] = "SHA-256withRSA";
    SignerUtilities.AlgorithmMap["SHA-256WITHRSA"] = "SHA-256withRSA";
    SignerUtilities.AlgorithmMap["SHA256WITHRSAENCRYPTION"] = "SHA-256withRSA";
    SignerUtilities.AlgorithmMap["SHA-256WITHRSAENCRYPTION"] = "SHA-256withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.Sha256WithRsaEncryption.Id] = "SHA-256withRSA";
    SignerUtilities.AlgorithmMap["SHA384WITHRSA"] = "SHA-384withRSA";
    SignerUtilities.AlgorithmMap["SHA-384WITHRSA"] = "SHA-384withRSA";
    SignerUtilities.AlgorithmMap["SHA384WITHRSAENCRYPTION"] = "SHA-384withRSA";
    SignerUtilities.AlgorithmMap["SHA-384WITHRSAENCRYPTION"] = "SHA-384withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.Sha384WithRsaEncryption.Id] = "SHA-384withRSA";
    SignerUtilities.AlgorithmMap["SHA512WITHRSA"] = "SHA-512withRSA";
    SignerUtilities.AlgorithmMap["SHA-512WITHRSA"] = "SHA-512withRSA";
    SignerUtilities.AlgorithmMap["SHA512WITHRSAENCRYPTION"] = "SHA-512withRSA";
    SignerUtilities.AlgorithmMap["SHA-512WITHRSAENCRYPTION"] = "SHA-512withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.Sha512WithRsaEncryption.Id] = "SHA-512withRSA";
    SignerUtilities.AlgorithmMap["SHA512(224)WITHRSA"] = "SHA-512(224)withRSA";
    SignerUtilities.AlgorithmMap["SHA-512(224)WITHRSA"] = "SHA-512(224)withRSA";
    SignerUtilities.AlgorithmMap["SHA512(224)WITHRSAENCRYPTION"] = "SHA-512(224)withRSA";
    SignerUtilities.AlgorithmMap["SHA-512(224)WITHRSAENCRYPTION"] = "SHA-512(224)withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.Sha512_224WithRSAEncryption.Id] = "SHA-512(224)withRSA";
    SignerUtilities.AlgorithmMap["SHA512(256)WITHRSA"] = "SHA-512(256)withRSA";
    SignerUtilities.AlgorithmMap["SHA-512(256)WITHRSA"] = "SHA-512(256)withRSA";
    SignerUtilities.AlgorithmMap["SHA512(256)WITHRSAENCRYPTION"] = "SHA-512(256)withRSA";
    SignerUtilities.AlgorithmMap["SHA-512(256)WITHRSAENCRYPTION"] = "SHA-512(256)withRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.Sha512_256WithRSAEncryption.Id] = "SHA-512(256)withRSA";
    SignerUtilities.AlgorithmMap["SHA3-224WITHRSA"] = "SHA3-224withRSA";
    SignerUtilities.AlgorithmMap["SHA3-224WITHRSAENCRYPTION"] = "SHA3-224withRSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224.Id] = "SHA3-224withRSA";
    SignerUtilities.AlgorithmMap["SHA3-256WITHRSA"] = "SHA3-256withRSA";
    SignerUtilities.AlgorithmMap["SHA3-256WITHRSAENCRYPTION"] = "SHA3-256withRSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256.Id] = "SHA3-256withRSA";
    SignerUtilities.AlgorithmMap["SHA3-384WITHRSA"] = "SHA3-384withRSA";
    SignerUtilities.AlgorithmMap["SHA3-384WITHRSAENCRYPTION"] = "SHA3-384withRSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384.Id] = "SHA3-384withRSA";
    SignerUtilities.AlgorithmMap["SHA3-512WITHRSA"] = "SHA3-512withRSA";
    SignerUtilities.AlgorithmMap["SHA3-512WITHRSAENCRYPTION"] = "SHA3-512withRSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512.Id] = "SHA3-512withRSA";
    SignerUtilities.AlgorithmMap["PSSWITHRSA"] = "PSSwithRSA";
    SignerUtilities.AlgorithmMap["RSASSA-PSS"] = "PSSwithRSA";
    SignerUtilities.AlgorithmMap[PkcsObjectIdentifiers.IdRsassaPss.Id] = "PSSwithRSA";
    SignerUtilities.AlgorithmMap["RSAPSS"] = "PSSwithRSA";
    SignerUtilities.AlgorithmMap["SHA1WITHRSAANDMGF1"] = "SHA-1withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-1WITHRSAANDMGF1"] = "SHA-1withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA1WITHRSA/PSS"] = "SHA-1withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-1WITHRSA/PSS"] = "SHA-1withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA1WITHRSASSA-PSS"] = "SHA-1withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-1WITHRSASSA-PSS"] = "SHA-1withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA224WITHRSAANDMGF1"] = "SHA-224withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-224WITHRSAANDMGF1"] = "SHA-224withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA224WITHRSA/PSS"] = "SHA-224withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-224WITHRSA/PSS"] = "SHA-224withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA224WITHRSASSA-PSS"] = "SHA-224withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-224WITHRSASSA-PSS"] = "SHA-224withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA256WITHRSAANDMGF1"] = "SHA-256withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-256WITHRSAANDMGF1"] = "SHA-256withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA256WITHRSA/PSS"] = "SHA-256withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-256WITHRSA/PSS"] = "SHA-256withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA256WITHRSASSA-PSS"] = "SHA-256withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-256WITHRSASSA-PSS"] = "SHA-256withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA384WITHRSAANDMGF1"] = "SHA-384withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-384WITHRSAANDMGF1"] = "SHA-384withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA384WITHRSA/PSS"] = "SHA-384withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-384WITHRSA/PSS"] = "SHA-384withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA384WITHRSASSA-PSS"] = "SHA-384withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-384WITHRSASSA-PSS"] = "SHA-384withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA512WITHRSAANDMGF1"] = "SHA-512withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-512WITHRSAANDMGF1"] = "SHA-512withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA512WITHRSA/PSS"] = "SHA-512withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-512WITHRSA/PSS"] = "SHA-512withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA512WITHRSASSA-PSS"] = "SHA-512withRSAandMGF1";
    SignerUtilities.AlgorithmMap["SHA-512WITHRSASSA-PSS"] = "SHA-512withRSAandMGF1";
    SignerUtilities.AlgorithmMap["RIPEMD128WITHRSA"] = "RIPEMD128withRSA";
    SignerUtilities.AlgorithmMap["RIPEMD128WITHRSAENCRYPTION"] = "RIPEMD128withRSA";
    SignerUtilities.AlgorithmMap[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128.Id] = "RIPEMD128withRSA";
    SignerUtilities.AlgorithmMap["RIPEMD160WITHRSA"] = "RIPEMD160withRSA";
    SignerUtilities.AlgorithmMap["RIPEMD160WITHRSAENCRYPTION"] = "RIPEMD160withRSA";
    SignerUtilities.AlgorithmMap[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160.Id] = "RIPEMD160withRSA";
    SignerUtilities.AlgorithmMap["RIPEMD256WITHRSA"] = "RIPEMD256withRSA";
    SignerUtilities.AlgorithmMap["RIPEMD256WITHRSAENCRYPTION"] = "RIPEMD256withRSA";
    SignerUtilities.AlgorithmMap[TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256.Id] = "RIPEMD256withRSA";
    SignerUtilities.AlgorithmMap["NONEWITHRSA"] = "RSA";
    SignerUtilities.AlgorithmMap["RSAWITHNONE"] = "RSA";
    SignerUtilities.AlgorithmMap["RAWRSA"] = "RSA";
    SignerUtilities.AlgorithmMap["RAWRSAPSS"] = "RAWRSASSA-PSS";
    SignerUtilities.AlgorithmMap["NONEWITHRSAPSS"] = "RAWRSASSA-PSS";
    SignerUtilities.AlgorithmMap["NONEWITHRSASSA-PSS"] = "RAWRSASSA-PSS";
    SignerUtilities.AlgorithmMap["NONEWITHDSA"] = "NONEwithDSA";
    SignerUtilities.AlgorithmMap["DSAWITHNONE"] = "NONEwithDSA";
    SignerUtilities.AlgorithmMap["RAWDSA"] = "NONEwithDSA";
    SignerUtilities.AlgorithmMap["DSA"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA1"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA-1"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["SHA/DSA"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["SHA1/DSA"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["SHA-1/DSA"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["SHA1WITHDSA"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["SHA-1WITHDSA"] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap[X9ObjectIdentifiers.IdDsaWithSha1.Id] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap[OiwObjectIdentifiers.DsaWithSha1.Id] = "SHA-1withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA224"] = "SHA-224withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA-224"] = "SHA-224withDSA";
    SignerUtilities.AlgorithmMap["SHA224/DSA"] = "SHA-224withDSA";
    SignerUtilities.AlgorithmMap["SHA-224/DSA"] = "SHA-224withDSA";
    SignerUtilities.AlgorithmMap["SHA224WITHDSA"] = "SHA-224withDSA";
    SignerUtilities.AlgorithmMap["SHA-224WITHDSA"] = "SHA-224withDSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.DsaWithSha224.Id] = "SHA-224withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA256"] = "SHA-256withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA-256"] = "SHA-256withDSA";
    SignerUtilities.AlgorithmMap["SHA256/DSA"] = "SHA-256withDSA";
    SignerUtilities.AlgorithmMap["SHA-256/DSA"] = "SHA-256withDSA";
    SignerUtilities.AlgorithmMap["SHA256WITHDSA"] = "SHA-256withDSA";
    SignerUtilities.AlgorithmMap["SHA-256WITHDSA"] = "SHA-256withDSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.DsaWithSha256.Id] = "SHA-256withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA384"] = "SHA-384withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA-384"] = "SHA-384withDSA";
    SignerUtilities.AlgorithmMap["SHA384/DSA"] = "SHA-384withDSA";
    SignerUtilities.AlgorithmMap["SHA-384/DSA"] = "SHA-384withDSA";
    SignerUtilities.AlgorithmMap["SHA384WITHDSA"] = "SHA-384withDSA";
    SignerUtilities.AlgorithmMap["SHA-384WITHDSA"] = "SHA-384withDSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.DsaWithSha384.Id] = "SHA-384withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA512"] = "SHA-512withDSA";
    SignerUtilities.AlgorithmMap["DSAWITHSHA-512"] = "SHA-512withDSA";
    SignerUtilities.AlgorithmMap["SHA512/DSA"] = "SHA-512withDSA";
    SignerUtilities.AlgorithmMap["SHA-512/DSA"] = "SHA-512withDSA";
    SignerUtilities.AlgorithmMap["SHA512WITHDSA"] = "SHA-512withDSA";
    SignerUtilities.AlgorithmMap["SHA-512WITHDSA"] = "SHA-512withDSA";
    SignerUtilities.AlgorithmMap[NistObjectIdentifiers.DsaWithSha512.Id] = "SHA-512withDSA";
    SignerUtilities.AlgorithmMap["NONEWITHECDSA"] = "NONEwithECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHNONE"] = "NONEwithECDSA";
    SignerUtilities.AlgorithmMap["ECDSA"] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap["SHA1/ECDSA"] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap["SHA-1/ECDSA"] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA1"] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA-1"] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap["SHA1WITHECDSA"] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap["SHA-1WITHECDSA"] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap[X9ObjectIdentifiers.ECDsaWithSha1.Id] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap[TeleTrusTObjectIdentifiers.ECSignWithSha1.Id] = "SHA-1withECDSA";
    SignerUtilities.AlgorithmMap["SHA224/ECDSA"] = "SHA-224withECDSA";
    SignerUtilities.AlgorithmMap["SHA-224/ECDSA"] = "SHA-224withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA224"] = "SHA-224withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA-224"] = "SHA-224withECDSA";
    SignerUtilities.AlgorithmMap["SHA224WITHECDSA"] = "SHA-224withECDSA";
    SignerUtilities.AlgorithmMap["SHA-224WITHECDSA"] = "SHA-224withECDSA";
    SignerUtilities.AlgorithmMap[X9ObjectIdentifiers.ECDsaWithSha224.Id] = "SHA-224withECDSA";
    SignerUtilities.AlgorithmMap["SHA256/ECDSA"] = "SHA-256withECDSA";
    SignerUtilities.AlgorithmMap["SHA-256/ECDSA"] = "SHA-256withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA256"] = "SHA-256withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA-256"] = "SHA-256withECDSA";
    SignerUtilities.AlgorithmMap["SHA256WITHECDSA"] = "SHA-256withECDSA";
    SignerUtilities.AlgorithmMap["SHA-256WITHECDSA"] = "SHA-256withECDSA";
    SignerUtilities.AlgorithmMap[X9ObjectIdentifiers.ECDsaWithSha256.Id] = "SHA-256withECDSA";
    SignerUtilities.AlgorithmMap["SHA384/ECDSA"] = "SHA-384withECDSA";
    SignerUtilities.AlgorithmMap["SHA-384/ECDSA"] = "SHA-384withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA384"] = "SHA-384withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA-384"] = "SHA-384withECDSA";
    SignerUtilities.AlgorithmMap["SHA384WITHECDSA"] = "SHA-384withECDSA";
    SignerUtilities.AlgorithmMap["SHA-384WITHECDSA"] = "SHA-384withECDSA";
    SignerUtilities.AlgorithmMap[X9ObjectIdentifiers.ECDsaWithSha384.Id] = "SHA-384withECDSA";
    SignerUtilities.AlgorithmMap["SHA512/ECDSA"] = "SHA-512withECDSA";
    SignerUtilities.AlgorithmMap["SHA-512/ECDSA"] = "SHA-512withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA512"] = "SHA-512withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHSHA-512"] = "SHA-512withECDSA";
    SignerUtilities.AlgorithmMap["SHA512WITHECDSA"] = "SHA-512withECDSA";
    SignerUtilities.AlgorithmMap["SHA-512WITHECDSA"] = "SHA-512withECDSA";
    SignerUtilities.AlgorithmMap[X9ObjectIdentifiers.ECDsaWithSha512.Id] = "SHA-512withECDSA";
    SignerUtilities.AlgorithmMap["RIPEMD160/ECDSA"] = "RIPEMD160withECDSA";
    SignerUtilities.AlgorithmMap["ECDSAWITHRIPEMD160"] = "RIPEMD160withECDSA";
    SignerUtilities.AlgorithmMap["RIPEMD160WITHECDSA"] = "RIPEMD160withECDSA";
    SignerUtilities.AlgorithmMap[TeleTrusTObjectIdentifiers.ECSignWithRipeMD160.Id] = "RIPEMD160withECDSA";
    SignerUtilities.AlgorithmMap["NONEWITHCVC-ECDSA"] = "NONEwithCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHNONE"] = "NONEwithCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA1/CVC-ECDSA"] = "SHA-1withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-1/CVC-ECDSA"] = "SHA-1withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA1"] = "SHA-1withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA-1"] = "SHA-1withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA1WITHCVC-ECDSA"] = "SHA-1withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-1WITHCVC-ECDSA"] = "SHA-1withCVC-ECDSA";
    SignerUtilities.AlgorithmMap[EacObjectIdentifiers.id_TA_ECDSA_SHA_1.Id] = "SHA-1withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA224/CVC-ECDSA"] = "SHA-224withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-224/CVC-ECDSA"] = "SHA-224withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA224"] = "SHA-224withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA-224"] = "SHA-224withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA224WITHCVC-ECDSA"] = "SHA-224withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-224WITHCVC-ECDSA"] = "SHA-224withCVC-ECDSA";
    SignerUtilities.AlgorithmMap[EacObjectIdentifiers.id_TA_ECDSA_SHA_224.Id] = "SHA-224withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA256/CVC-ECDSA"] = "SHA-256withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-256/CVC-ECDSA"] = "SHA-256withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA256"] = "SHA-256withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA-256"] = "SHA-256withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA256WITHCVC-ECDSA"] = "SHA-256withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-256WITHCVC-ECDSA"] = "SHA-256withCVC-ECDSA";
    SignerUtilities.AlgorithmMap[EacObjectIdentifiers.id_TA_ECDSA_SHA_256.Id] = "SHA-256withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA384/CVC-ECDSA"] = "SHA-384withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-384/CVC-ECDSA"] = "SHA-384withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA384"] = "SHA-384withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA-384"] = "SHA-384withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA384WITHCVC-ECDSA"] = "SHA-384withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-384WITHCVC-ECDSA"] = "SHA-384withCVC-ECDSA";
    SignerUtilities.AlgorithmMap[EacObjectIdentifiers.id_TA_ECDSA_SHA_384.Id] = "SHA-384withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA512/CVC-ECDSA"] = "SHA-512withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-512/CVC-ECDSA"] = "SHA-512withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA512"] = "SHA-512withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["CVC-ECDSAWITHSHA-512"] = "SHA-512withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA512WITHCVC-ECDSA"] = "SHA-512withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-512WITHCVC-ECDSA"] = "SHA-512withCVC-ECDSA";
    SignerUtilities.AlgorithmMap[EacObjectIdentifiers.id_TA_ECDSA_SHA_512.Id] = "SHA-512withCVC-ECDSA";
    SignerUtilities.AlgorithmMap["NONEWITHPLAIN-ECDSA"] = "NONEwithPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHNONE"] = "NONEwithPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA1/PLAIN-ECDSA"] = "SHA-1withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-1/PLAIN-ECDSA"] = "SHA-1withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA1"] = "SHA-1withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA-1"] = "SHA-1withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA1WITHPLAIN-ECDSA"] = "SHA-1withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-1WITHPLAIN-ECDSA"] = "SHA-1withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap[BsiObjectIdentifiers.ecdsa_plain_SHA1.Id] = "SHA-1withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA224/PLAIN-ECDSA"] = "SHA-224withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-224/PLAIN-ECDSA"] = "SHA-224withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA224"] = "SHA-224withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA-224"] = "SHA-224withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA224WITHPLAIN-ECDSA"] = "SHA-224withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-224WITHPLAIN-ECDSA"] = "SHA-224withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap[BsiObjectIdentifiers.ecdsa_plain_SHA224.Id] = "SHA-224withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA256/PLAIN-ECDSA"] = "SHA-256withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-256/PLAIN-ECDSA"] = "SHA-256withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA256"] = "SHA-256withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA-256"] = "SHA-256withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA256WITHPLAIN-ECDSA"] = "SHA-256withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-256WITHPLAIN-ECDSA"] = "SHA-256withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap[BsiObjectIdentifiers.ecdsa_plain_SHA256.Id] = "SHA-256withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA384/PLAIN-ECDSA"] = "SHA-384withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-384/PLAIN-ECDSA"] = "SHA-384withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA384"] = "SHA-384withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA-384"] = "SHA-384withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA384WITHPLAIN-ECDSA"] = "SHA-384withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-384WITHPLAIN-ECDSA"] = "SHA-384withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap[BsiObjectIdentifiers.ecdsa_plain_SHA384.Id] = "SHA-384withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA512/PLAIN-ECDSA"] = "SHA-512withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-512/PLAIN-ECDSA"] = "SHA-512withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA512"] = "SHA-512withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHSHA-512"] = "SHA-512withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA512WITHPLAIN-ECDSA"] = "SHA-512withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA-512WITHPLAIN-ECDSA"] = "SHA-512withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap[BsiObjectIdentifiers.ecdsa_plain_SHA512.Id] = "SHA-512withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["RIPEMD160/PLAIN-ECDSA"] = "RIPEMD160withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["PLAIN-ECDSAWITHRIPEMD160"] = "RIPEMD160withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["RIPEMD160WITHPLAIN-ECDSA"] = "RIPEMD160withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap[BsiObjectIdentifiers.ecdsa_plain_RIPEMD160.Id] = "RIPEMD160withPLAIN-ECDSA";
    SignerUtilities.AlgorithmMap["SHA1WITHECNR"] = "SHA-1withECNR";
    SignerUtilities.AlgorithmMap["SHA-1WITHECNR"] = "SHA-1withECNR";
    SignerUtilities.AlgorithmMap["SHA224WITHECNR"] = "SHA-224withECNR";
    SignerUtilities.AlgorithmMap["SHA-224WITHECNR"] = "SHA-224withECNR";
    SignerUtilities.AlgorithmMap["SHA256WITHECNR"] = "SHA-256withECNR";
    SignerUtilities.AlgorithmMap["SHA-256WITHECNR"] = "SHA-256withECNR";
    SignerUtilities.AlgorithmMap["SHA384WITHECNR"] = "SHA-384withECNR";
    SignerUtilities.AlgorithmMap["SHA-384WITHECNR"] = "SHA-384withECNR";
    SignerUtilities.AlgorithmMap["SHA512WITHECNR"] = "SHA-512withECNR";
    SignerUtilities.AlgorithmMap["SHA-512WITHECNR"] = "SHA-512withECNR";
    SignerUtilities.AlgorithmMap["GOST-3410"] = "GOST3410";
    SignerUtilities.AlgorithmMap["GOST-3410-94"] = "GOST3410";
    SignerUtilities.AlgorithmMap["GOST3411WITHGOST3410"] = "GOST3410";
    SignerUtilities.AlgorithmMap["GOST3411/GOST3410"] = "GOST3410";
    SignerUtilities.AlgorithmMap[CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94.Id] = "GOST3410";
    SignerUtilities.AlgorithmMap["ECGOST-3410"] = "ECGOST3410";
    SignerUtilities.AlgorithmMap["GOST-3410-2001"] = "ECGOST3410";
    SignerUtilities.AlgorithmMap["GOST3411WITHECGOST3410"] = "ECGOST3410";
    SignerUtilities.AlgorithmMap["GOST3411/ECGOST3410"] = "ECGOST3410";
    SignerUtilities.AlgorithmMap[CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001.Id] = "ECGOST3410";
    SignerUtilities.AlgorithmMap["GOST-3410-2012-256"] = "ECGOST3410-2012-256";
    SignerUtilities.AlgorithmMap["GOST3411WITHECGOST3410-2012-256"] = "ECGOST3410-2012-256";
    SignerUtilities.AlgorithmMap["GOST3411-2012-256WITHECGOST3410"] = "ECGOST3410-2012-256";
    SignerUtilities.AlgorithmMap["GOST3411-2012-256WITHECGOST3410-2012-256"] = "ECGOST3410-2012-256";
    SignerUtilities.AlgorithmMap["GOST3411-2012-256/ECGOST3410"] = "ECGOST3410-2012-256";
    SignerUtilities.AlgorithmMap["GOST3411-2012-256/ECGOST3410-2012-256"] = "ECGOST3410-2012-256";
    SignerUtilities.AlgorithmMap[RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256.Id] = "ECGOST3410-2012-256";
    SignerUtilities.AlgorithmMap["GOST-3410-2012-512"] = "ECGOST3410-2012-512";
    SignerUtilities.AlgorithmMap["GOST3411WITHECGOST3410-2012-512"] = "ECGOST3410-2012-512";
    SignerUtilities.AlgorithmMap["GOST3411-2012-512WITHECGOST3410"] = "ECGOST3410-2012-512";
    SignerUtilities.AlgorithmMap["GOST3411-2012-512WITHECGOST3410-2012-512"] = "ECGOST3410-2012-512";
    SignerUtilities.AlgorithmMap["GOST3411-2012-512/ECGOST3410"] = "ECGOST3410-2012-512";
    SignerUtilities.AlgorithmMap["GOST3411-2012-512/ECGOST3410-2012-512"] = "ECGOST3410-2012-512";
    SignerUtilities.AlgorithmMap[RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512.Id] = "ECGOST3410-2012-512";
    SignerUtilities.AlgorithmMap["ED25519"] = "Ed25519";
    SignerUtilities.AlgorithmMap[EdECObjectIdentifiers.id_Ed25519.Id] = "Ed25519";
    SignerUtilities.AlgorithmMap["ED25519CTX"] = "Ed25519ctx";
    SignerUtilities.AlgorithmMap["ED25519PH"] = "Ed25519ph";
    SignerUtilities.AlgorithmMap["ED448"] = "Ed448";
    SignerUtilities.AlgorithmMap[EdECObjectIdentifiers.id_Ed448.Id] = "Ed448";
    SignerUtilities.AlgorithmMap["ED448PH"] = "Ed448ph";
    SignerUtilities.AlgorithmMap["SHA256WITHSM2"] = "SHA256withSM2";
    SignerUtilities.AlgorithmMap[GMObjectIdentifiers.sm2sign_with_sha256.Id] = "SHA256withSM2";
    SignerUtilities.AlgorithmMap["SM3WITHSM2"] = "SM3withSM2";
    SignerUtilities.AlgorithmMap[GMObjectIdentifiers.sm2sign_with_sm3.Id] = "SM3withSM2";
    SignerUtilities.NoRandom.Add("Ed25519");
    SignerUtilities.NoRandom.Add(EdECObjectIdentifiers.id_Ed25519.Id);
    SignerUtilities.NoRandom.Add("Ed25519ctx");
    SignerUtilities.NoRandom.Add("Ed25519ph");
    SignerUtilities.NoRandom.Add("Ed448");
    SignerUtilities.NoRandom.Add(EdECObjectIdentifiers.id_Ed448.Id);
    SignerUtilities.NoRandom.Add("Ed448ph");
    SignerUtilities.Oids["MD2withRSA"] = PkcsObjectIdentifiers.MD2WithRsaEncryption;
    SignerUtilities.Oids["MD4withRSA"] = PkcsObjectIdentifiers.MD4WithRsaEncryption;
    SignerUtilities.Oids["MD5withRSA"] = PkcsObjectIdentifiers.MD5WithRsaEncryption;
    SignerUtilities.Oids["SHA-1withRSA"] = PkcsObjectIdentifiers.Sha1WithRsaEncryption;
    SignerUtilities.Oids["SHA-224withRSA"] = PkcsObjectIdentifiers.Sha224WithRsaEncryption;
    SignerUtilities.Oids["SHA-256withRSA"] = PkcsObjectIdentifiers.Sha256WithRsaEncryption;
    SignerUtilities.Oids["SHA-384withRSA"] = PkcsObjectIdentifiers.Sha384WithRsaEncryption;
    SignerUtilities.Oids["SHA-512withRSA"] = PkcsObjectIdentifiers.Sha512WithRsaEncryption;
    SignerUtilities.Oids["SHA-512(224)withRSA"] = PkcsObjectIdentifiers.Sha512_224WithRSAEncryption;
    SignerUtilities.Oids["SHA-512(256)withRSA"] = PkcsObjectIdentifiers.Sha512_256WithRSAEncryption;
    SignerUtilities.Oids["SHA3-224withRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_224;
    SignerUtilities.Oids["SHA3-256withRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_256;
    SignerUtilities.Oids["SHA3-384withRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_384;
    SignerUtilities.Oids["SHA3-512withRSA"] = NistObjectIdentifiers.IdRsassaPkcs1V15WithSha3_512;
    SignerUtilities.Oids["PSSwithRSA"] = PkcsObjectIdentifiers.IdRsassaPss;
    SignerUtilities.Oids["SHA-1withRSAandMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    SignerUtilities.Oids["SHA-224withRSAandMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    SignerUtilities.Oids["SHA-256withRSAandMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    SignerUtilities.Oids["SHA-384withRSAandMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    SignerUtilities.Oids["SHA-512withRSAandMGF1"] = PkcsObjectIdentifiers.IdRsassaPss;
    SignerUtilities.Oids["RIPEMD128withRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128;
    SignerUtilities.Oids["RIPEMD160withRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160;
    SignerUtilities.Oids["RIPEMD256withRSA"] = TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256;
    SignerUtilities.Oids["SHA-1withDSA"] = X9ObjectIdentifiers.IdDsaWithSha1;
    SignerUtilities.Oids["SHA-1withECDSA"] = X9ObjectIdentifiers.ECDsaWithSha1;
    SignerUtilities.Oids["SHA-224withECDSA"] = X9ObjectIdentifiers.ECDsaWithSha224;
    SignerUtilities.Oids["SHA-256withECDSA"] = X9ObjectIdentifiers.ECDsaWithSha256;
    SignerUtilities.Oids["SHA-384withECDSA"] = X9ObjectIdentifiers.ECDsaWithSha384;
    SignerUtilities.Oids["SHA-512withECDSA"] = X9ObjectIdentifiers.ECDsaWithSha512;
    SignerUtilities.Oids["RIPEMD160withECDSA"] = TeleTrusTObjectIdentifiers.ECSignWithRipeMD160;
    SignerUtilities.Oids["SHA-1withCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_1;
    SignerUtilities.Oids["SHA-224withCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_224;
    SignerUtilities.Oids["SHA-256withCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_256;
    SignerUtilities.Oids["SHA-384withCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_384;
    SignerUtilities.Oids["SHA-512withCVC-ECDSA"] = EacObjectIdentifiers.id_TA_ECDSA_SHA_512;
    SignerUtilities.Oids["SHA-1withPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA1;
    SignerUtilities.Oids["SHA-224withPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA224;
    SignerUtilities.Oids["SHA-256withPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA256;
    SignerUtilities.Oids["SHA-384withPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA384;
    SignerUtilities.Oids["SHA-512withPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_SHA512;
    SignerUtilities.Oids["RIPEMD160withPLAIN-ECDSA"] = BsiObjectIdentifiers.ecdsa_plain_RIPEMD160;
    SignerUtilities.Oids["GOST3410"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94;
    SignerUtilities.Oids["ECGOST3410"] = CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001;
    SignerUtilities.Oids["ECGOST3410-2012-256"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_256;
    SignerUtilities.Oids["ECGOST3410-2012-512"] = RosstandartObjectIdentifiers.id_tc26_signwithdigest_gost_3410_12_512;
    SignerUtilities.Oids["Ed25519"] = EdECObjectIdentifiers.id_Ed25519;
    SignerUtilities.Oids["Ed448"] = EdECObjectIdentifiers.id_Ed448;
    SignerUtilities.Oids["SHA256withSM2"] = GMObjectIdentifiers.sm2sign_with_sha256;
    SignerUtilities.Oids["SM3withSM2"] = GMObjectIdentifiers.sm2sign_with_sm3;
  }

  public static DerObjectIdentifier GetObjectIdentifier(string mechanism)
  {
    string k = mechanism != null ? CollectionUtilities.GetValueOrKey<string>(SignerUtilities.AlgorithmMap, mechanism) : throw new ArgumentNullException(nameof (mechanism));
    return CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>(SignerUtilities.Oids, k);
  }

  public static ICollection<string> Algorithms
  {
    get => CollectionUtilities.ReadOnly<string>(SignerUtilities.Oids.Keys);
  }

  public static Asn1Encodable GetDefaultX509Parameters(DerObjectIdentifier id)
  {
    return SignerUtilities.GetDefaultX509Parameters(id.Id);
  }

  public static Asn1Encodable GetDefaultX509Parameters(string algorithm)
  {
    string source = algorithm != null ? CollectionUtilities.GetValueOrKey<string>(SignerUtilities.AlgorithmMap, algorithm) : throw new ArgumentNullException(nameof (algorithm));
    if (source == "PSSwithRSA")
      return SignerUtilities.GetPssX509Parameters("SHA-1");
    return Platform.EndsWith(source, "withRSAandMGF1") ? SignerUtilities.GetPssX509Parameters(source.Substring(0, source.Length - "withRSAandMGF1".Length)) : (Asn1Encodable) DerNull.Instance;
  }

  private static string GetMechanism(string algorithm)
  {
    string str;
    return !SignerUtilities.AlgorithmMap.TryGetValue(algorithm, out str) ? algorithm.ToUpperInvariant() : str;
  }

  private static Asn1Encodable GetPssX509Parameters(string digestName)
  {
    AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(DigestUtilities.GetObjectIdentifier(digestName), (Asn1Encodable) DerNull.Instance);
    AlgorithmIdentifier maskGenAlgorithm = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) algorithmIdentifier);
    int digestSize = DigestUtilities.GetDigest(digestName).GetDigestSize();
    return (Asn1Encodable) new RsassaPssParameters(algorithmIdentifier, maskGenAlgorithm, new DerInteger(digestSize), new DerInteger(1));
  }

  public static ISigner GetSigner(DerObjectIdentifier id)
  {
    return id != null ? SignerUtilities.GetSigner(id.Id) : throw new ArgumentNullException(nameof (id));
  }

  public static ISigner GetSigner(string algorithm)
  {
    return (algorithm != null ? SignerUtilities.GetSignerForMechanism(SignerUtilities.GetMechanism(algorithm)) : throw new ArgumentNullException(nameof (algorithm))) ?? throw new SecurityUtilityException($"Signer {algorithm} not recognised.");
  }

  private static ISigner GetSignerForMechanism(string mechanism)
  {
    if (Platform.StartsWith(mechanism, "Ed"))
    {
      if (mechanism.Equals("Ed25519"))
        return (ISigner) new Ed25519Signer();
      if (mechanism.Equals("Ed25519ctx"))
        return (ISigner) new Ed25519ctxSigner(Arrays.EmptyBytes);
      if (mechanism.Equals("Ed25519ph"))
        return (ISigner) new Ed25519phSigner(Arrays.EmptyBytes);
      if (mechanism.Equals("Ed448"))
        return (ISigner) new Ed448Signer(Arrays.EmptyBytes);
      if (mechanism.Equals("Ed448ph"))
        return (ISigner) new Ed448phSigner(Arrays.EmptyBytes);
    }
    if (mechanism.Equals("RSA"))
      return (ISigner) new RsaDigestSigner((IDigest) new NullDigest(), (AlgorithmIdentifier) null);
    if (mechanism.Equals("RAWRSASSA-PSS"))
      return (ISigner) PssSigner.CreateRawSigner((IAsymmetricBlockCipher) new RsaBlindedEngine(), (IDigest) new Sha1Digest());
    if (mechanism.Equals("PSSwithRSA"))
      return (ISigner) new PssSigner((IAsymmetricBlockCipher) new RsaBlindedEngine(), (IDigest) new Sha1Digest());
    if (Platform.EndsWith(mechanism, "withRSA"))
      return (ISigner) new RsaDigestSigner(DigestUtilities.GetDigest(mechanism.Substring(0, mechanism.LastIndexOf("with"))));
    if (Platform.EndsWith(mechanism, "withRSAandMGF1"))
      return (ISigner) new PssSigner((IAsymmetricBlockCipher) new RsaBlindedEngine(), DigestUtilities.GetDigest(mechanism.Substring(0, mechanism.LastIndexOf("with"))));
    if (Platform.EndsWith(mechanism, "withDSA"))
      return (ISigner) new DsaDigestSigner((IDsa) new DsaSigner(), DigestUtilities.GetDigest(mechanism.Substring(0, mechanism.LastIndexOf("with"))));
    if (Platform.EndsWith(mechanism, "withECDSA"))
      return (ISigner) new DsaDigestSigner((IDsa) new ECDsaSigner(), DigestUtilities.GetDigest(mechanism.Substring(0, mechanism.LastIndexOf("with"))));
    if (Platform.EndsWith(mechanism, "withCVC-ECDSA") || Platform.EndsWith(mechanism, "withPLAIN-ECDSA"))
      return (ISigner) new DsaDigestSigner((IDsa) new ECDsaSigner(), DigestUtilities.GetDigest(mechanism.Substring(0, mechanism.LastIndexOf("with"))), (IDsaEncoding) PlainDsaEncoding.Instance);
    if (Platform.EndsWith(mechanism, "withECNR"))
      return (ISigner) new DsaDigestSigner((IDsa) new ECNRSigner(), DigestUtilities.GetDigest(mechanism.Substring(0, mechanism.LastIndexOf("with"))));
    if (Platform.EndsWith(mechanism, "withSM2"))
      return (ISigner) new SM2Signer(DigestUtilities.GetDigest(mechanism.Substring(0, mechanism.LastIndexOf("with"))));
    if (mechanism.Equals("GOST3410"))
      return (ISigner) new Gost3410DigestSigner((IDsa) new Gost3410Signer(), (IDigest) new Gost3411Digest());
    if (Platform.StartsWith(mechanism, "ECGOST3410"))
    {
      switch (mechanism)
      {
        case "ECGOST3410":
          return (ISigner) new Gost3410DigestSigner((IDsa) new ECGost3410Signer(), (IDigest) new Gost3411Digest());
        case "ECGOST3410-2012-256":
          return (ISigner) new Gost3410DigestSigner((IDsa) new ECGost3410Signer(), (IDigest) new Gost3411_2012_256Digest());
        case "ECGOST3410-2012-512":
          return (ISigner) new Gost3410DigestSigner((IDsa) new ECGost3410Signer(), (IDigest) new Gost3411_2012_512Digest());
      }
    }
    if (Platform.EndsWith(mechanism, "/ISO9796-2"))
    {
      switch (mechanism)
      {
        case "SHA1WITHRSA/ISO9796-2":
          return (ISigner) new Iso9796d2Signer((IAsymmetricBlockCipher) new RsaBlindedEngine(), (IDigest) new Sha1Digest(), true);
        case "MD5WITHRSA/ISO9796-2":
          return (ISigner) new Iso9796d2Signer((IAsymmetricBlockCipher) new RsaBlindedEngine(), (IDigest) new MD5Digest(), true);
        case "RIPEMD160WITHRSA/ISO9796-2":
          return (ISigner) new Iso9796d2Signer((IAsymmetricBlockCipher) new RsaBlindedEngine(), (IDigest) new RipeMD160Digest(), true);
      }
    }
    if (Platform.EndsWith(mechanism, "/X9.31"))
    {
      string source = mechanism.Substring(0, mechanism.Length - "/X9.31".Length);
      int length = Platform.IndexOf(source, "WITH");
      if (length > 0)
      {
        int startIndex = length + "WITH".Length;
        if (source.Substring(startIndex, source.Length - startIndex).Equals("RSA"))
          return (ISigner) new X931Signer((IAsymmetricBlockCipher) new RsaBlindedEngine(), DigestUtilities.GetDigest(source.Substring(0, length)));
      }
    }
    return (ISigner) null;
  }

  public static string GetEncodingName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(SignerUtilities.AlgorithmMap, oid.Id);
  }

  public static ISigner InitSigner(
    DerObjectIdentifier algorithmOid,
    bool forSigning,
    AsymmetricKeyParameter privateKey,
    SecureRandom random)
  {
    if (algorithmOid == null)
      throw new ArgumentNullException(nameof (algorithmOid));
    return SignerUtilities.InitSigner(algorithmOid.Id, forSigning, privateKey, random);
  }

  public static ISigner InitSigner(
    string algorithm,
    bool forSigning,
    AsymmetricKeyParameter privateKey,
    SecureRandom random)
  {
    string mechanism = algorithm != null ? SignerUtilities.GetMechanism(algorithm) : throw new ArgumentNullException(nameof (algorithm));
    ISigner signerForMechanism = SignerUtilities.GetSignerForMechanism(mechanism);
    if (signerForMechanism == null)
      throw new SecurityUtilityException($"Signer {algorithm} not recognised.");
    ICipherParameters cipherParameters = (ICipherParameters) privateKey;
    if (forSigning && !SignerUtilities.NoRandom.Contains(mechanism))
      cipherParameters = ParameterUtilities.WithRandom(cipherParameters, random);
    signerForMechanism.Init(forSigning, cipherParameters);
    return signerForMechanism;
  }
}
