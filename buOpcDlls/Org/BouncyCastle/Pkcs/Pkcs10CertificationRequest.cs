// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs10CertificationRequest
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
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class Pkcs10CertificationRequest : CertificationRequest
{
  internal static readonly Dictionary<string, DerObjectIdentifier> m_algorithms = new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  internal static readonly Dictionary<string, Asn1Encodable> m_exParams = new Dictionary<string, Asn1Encodable>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  internal static readonly Dictionary<DerObjectIdentifier, string> m_keyAlgorithms = new Dictionary<DerObjectIdentifier, string>();
  internal static readonly Dictionary<DerObjectIdentifier, string> m_oids = new Dictionary<DerObjectIdentifier, string>();
  internal static readonly HashSet<DerObjectIdentifier> m_noParams = new HashSet<DerObjectIdentifier>();

  static Pkcs10CertificationRequest()
  {
    Pkcs10CertificationRequest.m_algorithms.Add("MD2WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("MD2WITHRSA", PkcsObjectIdentifiers.MD2WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("MD5WITHRSAENCRYPTION", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("MD5WITHRSA", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("RSAWITHMD5", PkcsObjectIdentifiers.MD5WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-1WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-1WITHRSA", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-224WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-224WITHRSA", PkcsObjectIdentifiers.Sha224WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-256WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-256WITHRSA", PkcsObjectIdentifiers.Sha256WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-384WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-384WITHRSA", PkcsObjectIdentifiers.Sha384WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-512WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-512WITHRSA", PkcsObjectIdentifiers.Sha512WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-512(224)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-512(224)WITHRSA", PkcsObjectIdentifiers.Sha512_224WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-512(256)WITHRSAENCRYPTION", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA-512(256)WITHRSA", PkcsObjectIdentifiers.Sha512_256WithRSAEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA1WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA224WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA256WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA384WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512WITHRSAANDMGF1", PkcsObjectIdentifiers.IdRsassaPss);
    Pkcs10CertificationRequest.m_algorithms.Add("RSAWITHSHA1", PkcsObjectIdentifiers.Sha1WithRsaEncryption);
    Pkcs10CertificationRequest.m_algorithms.Add("RIPEMD128WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    Pkcs10CertificationRequest.m_algorithms.Add("RIPEMD128WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD128);
    Pkcs10CertificationRequest.m_algorithms.Add("RIPEMD160WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    Pkcs10CertificationRequest.m_algorithms.Add("RIPEMD160WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD160);
    Pkcs10CertificationRequest.m_algorithms.Add("RIPEMD256WITHRSAENCRYPTION", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    Pkcs10CertificationRequest.m_algorithms.Add("RIPEMD256WITHRSA", TeleTrusTObjectIdentifiers.RsaSignatureWithRipeMD256);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA1WITHDSA", X9ObjectIdentifiers.IdDsaWithSha1);
    Pkcs10CertificationRequest.m_algorithms.Add("DSAWITHSHA1", X9ObjectIdentifiers.IdDsaWithSha1);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA224WITHDSA", NistObjectIdentifiers.DsaWithSha224);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA256WITHDSA", NistObjectIdentifiers.DsaWithSha256);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA384WITHDSA", NistObjectIdentifiers.DsaWithSha384);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512WITHDSA", NistObjectIdentifiers.DsaWithSha512);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA1WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha1);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA224WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha224);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA256WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha256);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA384WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha384);
    Pkcs10CertificationRequest.m_algorithms.Add("SHA512WITHECDSA", X9ObjectIdentifiers.ECDsaWithSha512);
    Pkcs10CertificationRequest.m_algorithms.Add("ECDSAWITHSHA1", X9ObjectIdentifiers.ECDsaWithSha1);
    Pkcs10CertificationRequest.m_algorithms.Add("GOST3411WITHGOST3410", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    Pkcs10CertificationRequest.m_algorithms.Add("GOST3410WITHGOST3411", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    Pkcs10CertificationRequest.m_algorithms.Add("GOST3411WITHECGOST3410", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    Pkcs10CertificationRequest.m_algorithms.Add("GOST3411WITHECGOST3410-2001", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    Pkcs10CertificationRequest.m_algorithms.Add("GOST3411WITHGOST3410-2001", CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.Sha1WithRsaEncryption, "SHA1WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.Sha224WithRsaEncryption, "SHA224WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.Sha256WithRsaEncryption, "SHA256WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.Sha384WithRsaEncryption, "SHA384WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.Sha512WithRsaEncryption, "SHA512WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.Sha512_224WithRSAEncryption, "SHA512(224)WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.Sha512_256WithRSAEncryption, "SHA512(256)WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94, "GOST3411WITHGOST3410");
    Pkcs10CertificationRequest.m_oids.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001, "GOST3411WITHECGOST3410");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.MD5WithRsaEncryption, "MD5WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(PkcsObjectIdentifiers.MD2WithRsaEncryption, "MD2WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(X9ObjectIdentifiers.IdDsaWithSha1, "SHA1WITHDSA");
    Pkcs10CertificationRequest.m_oids.Add(X9ObjectIdentifiers.ECDsaWithSha1, "SHA1WITHECDSA");
    Pkcs10CertificationRequest.m_oids.Add(X9ObjectIdentifiers.ECDsaWithSha224, "SHA224WITHECDSA");
    Pkcs10CertificationRequest.m_oids.Add(X9ObjectIdentifiers.ECDsaWithSha256, "SHA256WITHECDSA");
    Pkcs10CertificationRequest.m_oids.Add(X9ObjectIdentifiers.ECDsaWithSha384, "SHA384WITHECDSA");
    Pkcs10CertificationRequest.m_oids.Add(X9ObjectIdentifiers.ECDsaWithSha512, "SHA512WITHECDSA");
    Pkcs10CertificationRequest.m_oids.Add(OiwObjectIdentifiers.MD5WithRsa, "MD5WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(OiwObjectIdentifiers.Sha1WithRsa, "SHA1WITHRSA");
    Pkcs10CertificationRequest.m_oids.Add(OiwObjectIdentifiers.DsaWithSha1, "SHA1WITHDSA");
    Pkcs10CertificationRequest.m_oids.Add(NistObjectIdentifiers.DsaWithSha224, "SHA224WITHDSA");
    Pkcs10CertificationRequest.m_oids.Add(NistObjectIdentifiers.DsaWithSha256, "SHA256WITHDSA");
    Pkcs10CertificationRequest.m_keyAlgorithms.Add(PkcsObjectIdentifiers.RsaEncryption, "RSA");
    Pkcs10CertificationRequest.m_keyAlgorithms.Add(X9ObjectIdentifiers.IdDsa, "DSA");
    Pkcs10CertificationRequest.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha1);
    Pkcs10CertificationRequest.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha224);
    Pkcs10CertificationRequest.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha256);
    Pkcs10CertificationRequest.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha384);
    Pkcs10CertificationRequest.m_noParams.Add(X9ObjectIdentifiers.ECDsaWithSha512);
    Pkcs10CertificationRequest.m_noParams.Add(X9ObjectIdentifiers.IdDsaWithSha1);
    Pkcs10CertificationRequest.m_noParams.Add(OiwObjectIdentifiers.DsaWithSha1);
    Pkcs10CertificationRequest.m_noParams.Add(NistObjectIdentifiers.DsaWithSha224);
    Pkcs10CertificationRequest.m_noParams.Add(NistObjectIdentifiers.DsaWithSha256);
    Pkcs10CertificationRequest.m_noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x94);
    Pkcs10CertificationRequest.m_noParams.Add(CryptoProObjectIdentifiers.GostR3411x94WithGostR3410x2001);
    AlgorithmIdentifier hashAlgId1 = new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1, (Asn1Encodable) DerNull.Instance);
    Pkcs10CertificationRequest.m_exParams.Add("SHA1WITHRSAANDMGF1", (Asn1Encodable) Pkcs10CertificationRequest.CreatePssParams(hashAlgId1, 20));
    AlgorithmIdentifier hashAlgId2 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha224, (Asn1Encodable) DerNull.Instance);
    Pkcs10CertificationRequest.m_exParams.Add("SHA224WITHRSAANDMGF1", (Asn1Encodable) Pkcs10CertificationRequest.CreatePssParams(hashAlgId2, 28));
    AlgorithmIdentifier hashAlgId3 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha256, (Asn1Encodable) DerNull.Instance);
    Pkcs10CertificationRequest.m_exParams.Add("SHA256WITHRSAANDMGF1", (Asn1Encodable) Pkcs10CertificationRequest.CreatePssParams(hashAlgId3, 32 /*0x20*/));
    AlgorithmIdentifier hashAlgId4 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha384, (Asn1Encodable) DerNull.Instance);
    Pkcs10CertificationRequest.m_exParams.Add("SHA384WITHRSAANDMGF1", (Asn1Encodable) Pkcs10CertificationRequest.CreatePssParams(hashAlgId4, 48 /*0x30*/));
    AlgorithmIdentifier hashAlgId5 = new AlgorithmIdentifier(NistObjectIdentifiers.IdSha512, (Asn1Encodable) DerNull.Instance);
    Pkcs10CertificationRequest.m_exParams.Add("SHA512WITHRSAANDMGF1", (Asn1Encodable) Pkcs10CertificationRequest.CreatePssParams(hashAlgId5, 64 /*0x40*/));
  }

  private static RsassaPssParameters CreatePssParams(AlgorithmIdentifier hashAlgId, int saltSize)
  {
    return new RsassaPssParameters(hashAlgId, new AlgorithmIdentifier(PkcsObjectIdentifiers.IdMgf1, (Asn1Encodable) hashAlgId), new DerInteger(saltSize), new DerInteger(1));
  }

  protected Pkcs10CertificationRequest()
  {
  }

  public Pkcs10CertificationRequest(byte[] encoded)
    : base((Asn1Sequence) Asn1Object.FromByteArray(encoded))
  {
  }

  public Pkcs10CertificationRequest(Asn1Sequence seq)
    : base(seq)
  {
  }

  public Pkcs10CertificationRequest(Stream input)
    : base((Asn1Sequence) Asn1Object.FromStream(input))
  {
  }

  public Pkcs10CertificationRequest(
    string signatureAlgorithm,
    X509Name subject,
    AsymmetricKeyParameter publicKey,
    Asn1Set attributes,
    AsymmetricKeyParameter signingKey)
    : this((ISignatureFactory) new Asn1SignatureFactory(signatureAlgorithm, signingKey), subject, publicKey, attributes)
  {
  }

  public Pkcs10CertificationRequest(
    ISignatureFactory signatureFactory,
    X509Name subject,
    AsymmetricKeyParameter publicKey,
    Asn1Set attributes)
  {
    if (signatureFactory == null)
      throw new ArgumentNullException(nameof (signatureFactory));
    if (subject == null)
      throw new ArgumentNullException(nameof (subject));
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    if (publicKey.IsPrivate)
      throw new ArgumentException("expected public key", nameof (publicKey));
    this.Init(signatureFactory, subject, publicKey, attributes);
  }

  private void Init(
    ISignatureFactory signatureFactory,
    X509Name subject,
    AsymmetricKeyParameter publicKey,
    Asn1Set attributes)
  {
    this.sigAlgId = (AlgorithmIdentifier) signatureFactory.AlgorithmDetails;
    SubjectPublicKeyInfo subjectPublicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
    this.reqInfo = new CertificationRequestInfo(subject, subjectPublicKeyInfo, attributes);
    this.sigBits = Org.BouncyCastle.X509.X509Utilities.GenerateSignature(signatureFactory, (Asn1Encodable) this.reqInfo);
  }

  public AsymmetricKeyParameter GetPublicKey()
  {
    return PublicKeyFactory.CreateKey(this.reqInfo.SubjectPublicKeyInfo);
  }

  public bool Verify() => this.Verify(this.GetPublicKey());

  public bool Verify(AsymmetricKeyParameter publicKey)
  {
    return this.Verify((IVerifierFactoryProvider) new Asn1VerifierFactoryProvider(publicKey));
  }

  public bool Verify(IVerifierFactoryProvider verifierProvider)
  {
    return this.Verify(verifierProvider.CreateVerifierFactory((object) this.sigAlgId));
  }

  public bool Verify(IVerifierFactory verifier)
  {
    try
    {
      return Org.BouncyCastle.X509.X509Utilities.VerifySignature(verifier, (Asn1Encodable) this.reqInfo, this.sigBits);
    }
    catch (Exception ex)
    {
      throw new SignatureException("exception encoding TBS cert request", ex);
    }
  }

  private void SetSignatureParameters(ISigner signature, Asn1Encodable asn1Params)
  {
    if (asn1Params != null && !(asn1Params is Asn1Null) && Platform.EndsWith(signature.AlgorithmName, "MGF1"))
      throw new NotImplementedException("signature algorithm with MGF1");
  }

  internal static string GetSignatureName(AlgorithmIdentifier sigAlgId)
  {
    Asn1Encodable parameters = sigAlgId.Parameters;
    return parameters != null && !(parameters is Asn1Null) && sigAlgId.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsassaPss) ? Pkcs10CertificationRequest.GetDigestAlgName(RsassaPssParameters.GetInstance((object) parameters).HashAlgorithm.Algorithm) + "withRSAandMGF1" : sigAlgId.Algorithm.Id;
  }

  private static string GetDigestAlgName(DerObjectIdentifier digestAlgOID)
  {
    if (PkcsObjectIdentifiers.MD5.Equals((Asn1Object) digestAlgOID))
      return "MD5";
    if (OiwObjectIdentifiers.IdSha1.Equals((Asn1Object) digestAlgOID))
      return "SHA1";
    if (NistObjectIdentifiers.IdSha224.Equals((Asn1Object) digestAlgOID))
      return "SHA224";
    if (NistObjectIdentifiers.IdSha256.Equals((Asn1Object) digestAlgOID))
      return "SHA256";
    if (NistObjectIdentifiers.IdSha384.Equals((Asn1Object) digestAlgOID))
      return "SHA384";
    if (NistObjectIdentifiers.IdSha512.Equals((Asn1Object) digestAlgOID))
      return "SHA512";
    if (NistObjectIdentifiers.IdSha512_224.Equals((Asn1Object) digestAlgOID))
      return "SHA512(224)";
    if (NistObjectIdentifiers.IdSha512_256.Equals((Asn1Object) digestAlgOID))
      return "SHA512(256)";
    if (TeleTrusTObjectIdentifiers.RipeMD128.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD128";
    if (TeleTrusTObjectIdentifiers.RipeMD160.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD160";
    if (TeleTrusTObjectIdentifiers.RipeMD256.Equals((Asn1Object) digestAlgOID))
      return "RIPEMD256";
    return CryptoProObjectIdentifiers.GostR3411.Equals((Asn1Object) digestAlgOID) ? "GOST3411" : digestAlgOID.Id;
  }

  public X509Extensions GetRequestedExtensions()
  {
    if (this.reqInfo.Attributes != null)
    {
      foreach (Asn1Encodable attribute in this.reqInfo.Attributes)
      {
        AttributePkcs instance1;
        try
        {
          instance1 = AttributePkcs.GetInstance((object) attribute);
        }
        catch (ArgumentException ex)
        {
          throw new ArgumentException("encountered non PKCS attribute in extensions block", (Exception) ex);
        }
        if (PkcsObjectIdentifiers.Pkcs9AtExtensionRequest.Equals((Asn1Object) instance1.AttrType))
        {
          X509ExtensionsGenerator extensionsGenerator = new X509ExtensionsGenerator();
          Asn1Set attrValues = instance1.AttrValues;
          Asn1Sequence asn1Sequence = attrValues != null && attrValues.Count != 0 ? Asn1Sequence.GetInstance((object) attrValues[0]) : throw new InvalidOperationException("pkcs_9_at_extensionRequest present but has no value");
          try
          {
            foreach (object obj in asn1Sequence)
            {
              Asn1Sequence instance2 = Asn1Sequence.GetInstance(obj);
              if (instance2.Count == 2)
              {
                extensionsGenerator.AddExtension(DerObjectIdentifier.GetInstance((object) instance2[0]), false, Asn1OctetString.GetInstance((object) instance2[1]).GetOctets());
              }
              else
              {
                bool critical = instance2.Count == 3 ? DerBoolean.GetInstance((object) instance2[1]).IsTrue : throw new InvalidOperationException($"incorrect sequence size of X509Extension got {instance2.Count.ToString()} expected 2 or 3");
                extensionsGenerator.AddExtension(DerObjectIdentifier.GetInstance((object) instance2[0]), critical, Asn1OctetString.GetInstance((object) instance2[2]).GetOctets());
              }
            }
          }
          catch (ArgumentException ex)
          {
            throw new InvalidOperationException("asn1 processing issue: " + ex.Message, (Exception) ex);
          }
          return extensionsGenerator.Generate();
        }
      }
    }
    return (X509Extensions) null;
  }
}
