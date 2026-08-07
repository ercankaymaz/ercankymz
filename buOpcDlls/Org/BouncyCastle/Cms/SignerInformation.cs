// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.SignerInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class SignerInformation
{
  private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;
  private SignerID sid;
  private CmsProcessable content;
  private byte[] signature;
  private DerObjectIdentifier contentType;
  private byte[] calculatedDigest;
  private byte[] resultDigest;
  private Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttributeTable;
  private Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributeTable;
  private readonly bool isCounterSignature;
  protected Org.BouncyCastle.Asn1.Cms.SignerInfo info;
  protected AlgorithmIdentifier digestAlgorithm;
  protected AlgorithmIdentifier encryptionAlgorithm;
  protected readonly Asn1Set signedAttributeSet;
  protected readonly Asn1Set unsignedAttributeSet;

  internal SignerInformation(
    Org.BouncyCastle.Asn1.Cms.SignerInfo info,
    DerObjectIdentifier contentType,
    CmsProcessable content,
    byte[] calculatedDigest)
  {
    this.info = info;
    this.sid = new SignerID();
    this.contentType = contentType;
    this.isCounterSignature = contentType == null;
    try
    {
      SignerIdentifier signerId = info.SignerID;
      if (signerId.IsTagged)
      {
        this.sid.SubjectKeyIdentifier = Asn1OctetString.GetInstance((object) signerId.ID).GetEncoded();
      }
      else
      {
        Org.BouncyCastle.Asn1.Cms.IssuerAndSerialNumber instance = Org.BouncyCastle.Asn1.Cms.IssuerAndSerialNumber.GetInstance((object) signerId.ID);
        this.sid.Issuer = instance.Name;
        this.sid.SerialNumber = instance.SerialNumber.Value;
      }
    }
    catch (IOException ex)
    {
      throw new ArgumentException("invalid sid in SignerInfo");
    }
    this.digestAlgorithm = info.DigestAlgorithm;
    this.signedAttributeSet = info.AuthenticatedAttributes;
    this.unsignedAttributeSet = info.UnauthenticatedAttributes;
    this.encryptionAlgorithm = info.DigestEncryptionAlgorithm;
    this.signature = (byte[]) info.EncryptedDigest.GetOctets().Clone();
    this.content = content;
    this.calculatedDigest = calculatedDigest;
  }

  protected SignerInformation(SignerInformation baseInfo)
  {
    this.info = baseInfo.info;
    this.content = baseInfo.content;
    this.contentType = baseInfo.contentType;
    this.isCounterSignature = baseInfo.IsCounterSignature;
    this.sid = baseInfo.sid;
    this.digestAlgorithm = this.info.DigestAlgorithm;
    this.signedAttributeSet = this.info.AuthenticatedAttributes;
    this.unsignedAttributeSet = this.info.UnauthenticatedAttributes;
    this.encryptionAlgorithm = this.info.DigestEncryptionAlgorithm;
    this.signature = (byte[]) this.info.EncryptedDigest.GetOctets().Clone();
    this.calculatedDigest = baseInfo.calculatedDigest;
    this.signedAttributeTable = baseInfo.signedAttributeTable;
    this.unsignedAttributeTable = baseInfo.unsignedAttributeTable;
  }

  public bool IsCounterSignature => this.isCounterSignature;

  public DerObjectIdentifier ContentType => this.contentType;

  public SignerID SignerID => this.sid;

  public int Version => this.info.Version.IntValueExact;

  public AlgorithmIdentifier DigestAlgorithmID => this.digestAlgorithm;

  public string DigestAlgOid => this.digestAlgorithm.Algorithm.Id;

  public Asn1Object DigestAlgParams => this.digestAlgorithm.Parameters?.ToAsn1Object();

  public byte[] GetContentDigest()
  {
    return this.resultDigest != null ? (byte[]) this.resultDigest.Clone() : throw new InvalidOperationException("method can only be called after verify.");
  }

  public AlgorithmIdentifier EncryptionAlgorithmID => this.encryptionAlgorithm;

  public string EncryptionAlgOid => this.encryptionAlgorithm.Algorithm.Id;

  public Asn1Object EncryptionAlgParams => this.encryptionAlgorithm.Parameters?.ToAsn1Object();

  public Org.BouncyCastle.Asn1.Cms.AttributeTable SignedAttributes
  {
    get
    {
      if (this.signedAttributeSet != null && this.signedAttributeTable == null)
        this.signedAttributeTable = new Org.BouncyCastle.Asn1.Cms.AttributeTable(this.signedAttributeSet);
      return this.signedAttributeTable;
    }
  }

  public Org.BouncyCastle.Asn1.Cms.AttributeTable UnsignedAttributes
  {
    get
    {
      if (this.unsignedAttributeSet != null && this.unsignedAttributeTable == null)
        this.unsignedAttributeTable = new Org.BouncyCastle.Asn1.Cms.AttributeTable(this.unsignedAttributeSet);
      return this.unsignedAttributeTable;
    }
  }

  public byte[] GetSignature() => (byte[]) this.signature.Clone();

  public SignerInformationStore GetCounterSignatures()
  {
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = this.UnsignedAttributes;
    if (unsignedAttributes == null)
      return new SignerInformationStore((IEnumerable<SignerInformation>) new List<SignerInformation>(0));
    List<SignerInformation> signerInfos = new List<SignerInformation>();
    foreach (Org.BouncyCastle.Asn1.Cms.Attribute attribute in unsignedAttributes.GetAll(CmsAttributes.CounterSignature))
    {
      Asn1Set attrValues = attribute.AttrValues;
      int count = attrValues.Count;
      foreach (Asn1Encodable asn1Encodable in attrValues)
      {
        Org.BouncyCastle.Asn1.Cms.SignerInfo instance = Org.BouncyCastle.Asn1.Cms.SignerInfo.GetInstance((object) asn1Encodable.ToAsn1Object());
        string digestAlgName = CmsSignedHelper.Instance.GetDigestAlgName(instance.DigestAlgorithm.Algorithm.Id);
        byte[] calculatedDigest = DigestUtilities.DoFinal(CmsSignedHelper.Instance.GetDigestInstance(digestAlgName), this.GetSignature());
        signerInfos.Add(new SignerInformation(instance, (DerObjectIdentifier) null, (CmsProcessable) null, calculatedDigest));
      }
    }
    return new SignerInformationStore((IEnumerable<SignerInformation>) signerInfos);
  }

  public virtual byte[] GetEncodedSignedAttributes()
  {
    return this.signedAttributeSet != null ? this.signedAttributeSet.GetEncoded("DER") : (byte[]) null;
  }

  private bool DoVerify(AsymmetricKeyParameter key)
  {
    DerObjectIdentifier algorithm1 = this.encryptionAlgorithm.Algorithm;
    Asn1Encodable parameters = this.encryptionAlgorithm.Parameters;
    string digestAlgName = SignerInformation.Helper.GetDigestAlgName(this.EncryptionAlgOid);
    if (digestAlgName.Equals(algorithm1.Id))
      digestAlgName = SignerInformation.Helper.GetDigestAlgName(this.DigestAlgOid);
    IDigest digestInstance = SignerInformation.Helper.GetDigestInstance(digestAlgName);
    ISigner signer;
    if (algorithm1.Equals((Asn1Object) PkcsObjectIdentifiers.IdRsassaPss))
    {
      if (parameters == null)
        throw new CmsException("RSASSA-PSS signature must specify algorithm parameters");
      try
      {
        RsassaPssParameters instance = RsassaPssParameters.GetInstance((object) parameters.ToAsn1Object());
        if (!instance.HashAlgorithm.Algorithm.Equals((Asn1Object) this.digestAlgorithm.Algorithm))
          throw new CmsException("RSASSA-PSS signature parameters specified incorrect hash algorithm");
        if (!instance.MaskGenAlgorithm.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdMgf1))
          throw new CmsException("RSASSA-PSS signature parameters specified unknown MGF");
        IDigest digest = DigestUtilities.GetDigest(instance.HashAlgorithm.Algorithm);
        int intValueExact = instance.SaltLength.IntValueExact;
        if (!RsassaPssParameters.DefaultTrailerField.Equals((Asn1Object) instance.TrailerField))
          throw new CmsException("RSASSA-PSS signature parameters must have trailerField of 1");
        IAsymmetricBlockCipher cipher = (IAsymmetricBlockCipher) new RsaBlindedEngine();
        signer = this.signedAttributeSet != null || this.calculatedDigest == null ? (ISigner) new PssSigner(cipher, digest, intValueExact) : (ISigner) PssSigner.CreateRawSigner(cipher, digest, digest, intValueExact, (byte) 188);
      }
      catch (Exception ex)
      {
        throw new CmsException("failed to set RSASSA-PSS signature parameters", ex);
      }
    }
    else
    {
      string algorithm2 = $"{digestAlgName}with{SignerInformation.Helper.GetEncryptionAlgName(this.EncryptionAlgOid)}";
      signer = SignerInformation.Helper.GetSignatureInstance(algorithm2);
    }
    try
    {
      if (this.calculatedDigest != null)
      {
        this.resultDigest = this.calculatedDigest;
      }
      else
      {
        if (this.content != null)
          this.content.Write((Stream) new DigestSink(digestInstance));
        else if (this.signedAttributeSet == null)
          throw new CmsException("data not encapsulated in signature - use detached constructor.");
        this.resultDigest = DigestUtilities.DoFinal(digestInstance);
      }
    }
    catch (IOException ex)
    {
      throw new CmsException("can't process mime object to create signature.", (Exception) ex);
    }
    Asn1Object valuedSignedAttribute1 = this.GetSingleValuedSignedAttribute(CmsAttributes.ContentType, "content-type");
    if (valuedSignedAttribute1 == null)
    {
      if (!this.isCounterSignature && this.signedAttributeSet != null)
        throw new CmsException("The content-type attribute type MUST be present whenever signed attributes are present in signed-data");
    }
    else
    {
      if (this.isCounterSignature)
        throw new CmsException("[For counter signatures,] the signedAttributes field MUST NOT contain a content-type attribute");
      if (!(valuedSignedAttribute1 is DerObjectIdentifier objectIdentifier))
        throw new CmsException("content-type attribute value not of ASN.1 type 'OBJECT IDENTIFIER'");
      if (!objectIdentifier.Equals((Asn1Object) this.contentType))
        throw new CmsException("content-type attribute value does not match eContentType");
    }
    Asn1Object valuedSignedAttribute2 = this.GetSingleValuedSignedAttribute(CmsAttributes.MessageDigest, "message-digest");
    if (valuedSignedAttribute2 == null)
    {
      if (this.signedAttributeSet != null)
        throw new CmsException("the message-digest signed attribute type MUST be present when there are any signed attributes present");
    }
    else
    {
      if (!(valuedSignedAttribute2 is Asn1OctetString asn1OctetString))
        throw new CmsException("message-digest attribute value not of ASN.1 type 'OCTET STRING'");
      if (!Arrays.AreEqual(this.resultDigest, asn1OctetString.GetOctets()))
        throw new CmsException("message-digest attribute value does not match calculated value");
    }
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttributes1 = this.SignedAttributes;
    if (signedAttributes1 != null && signedAttributes1.GetAll(CmsAttributes.CounterSignature).Count > 0)
      throw new CmsException("A countersignature attribute MUST NOT be a signed attribute");
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = this.UnsignedAttributes;
    if (unsignedAttributes != null)
    {
      foreach (Org.BouncyCastle.Asn1.Cms.Attribute attribute in unsignedAttributes.GetAll(CmsAttributes.CounterSignature))
      {
        if (attribute.AttrValues.Count < 1)
          throw new CmsException("A countersignature attribute MUST contain at least one AttributeValue");
      }
    }
    try
    {
      signer.Init(false, (ICipherParameters) key);
      if (this.signedAttributeSet == null)
      {
        if (this.calculatedDigest != null)
        {
          if (!(signer is PssSigner))
            return this.VerifyDigest(this.resultDigest, key, this.GetSignature());
          signer.BlockUpdate(this.resultDigest, 0, this.resultDigest.Length);
        }
        else if (this.content != null)
        {
          try
          {
            this.content.Write((Stream) new SignerSink(signer));
          }
          catch (SignatureException ex)
          {
            throw new CmsStreamException("signature problem: " + ex?.ToString());
          }
        }
      }
      else
      {
        byte[] signedAttributes2 = this.GetEncodedSignedAttributes();
        signer.BlockUpdate(signedAttributes2, 0, signedAttributes2.Length);
      }
      return signer.VerifySignature(this.GetSignature());
    }
    catch (InvalidKeyException ex)
    {
      throw new CmsException("key not appropriate to signature in message.", (Exception) ex);
    }
    catch (IOException ex)
    {
      throw new CmsException("can't process mime object to create signature.", (Exception) ex);
    }
    catch (SignatureException ex)
    {
      throw new CmsException("invalid signature format in message: " + ex.Message, (Exception) ex);
    }
  }

  private bool IsNull(Asn1Encodable o) => o is Asn1Null || o == null;

  private DigestInfo DerDecode(byte[] encoding)
  {
    DigestInfo digestInfo = encoding[0] == (byte) 48 /*0x30*/ ? DigestInfo.GetInstance((object) Asn1Object.FromByteArray(encoding)) : throw new IOException("not a digest info object");
    if (digestInfo.GetEncoded().Length == encoding.Length)
      return digestInfo;
    throw new CmsException("malformed RSA signature");
  }

  private bool VerifyDigest(byte[] digest, AsymmetricKeyParameter key, byte[] signature)
  {
    string encryptionAlgName = SignerInformation.Helper.GetEncryptionAlgName(this.EncryptionAlgOid);
    try
    {
      switch (encryptionAlgName)
      {
        case "RSA":
          IBufferedCipher cipher = CipherUtilities.GetCipher(PkcsObjectIdentifiers.RsaEncryption);
          cipher.Init(false, (ICipherParameters) key);
          DigestInfo digestInfo = this.DerDecode(cipher.DoFinal(signature));
          if (!digestInfo.AlgorithmID.Algorithm.Equals((Asn1Object) this.digestAlgorithm.Algorithm) || !this.IsNull(digestInfo.AlgorithmID.Parameters))
            return false;
          byte[] digest1 = digestInfo.GetDigest();
          return Arrays.FixedTimeEquals(digest, digest1);
        case "DSA":
          ISigner signer = SignerUtilities.GetSigner("NONEwithDSA");
          signer.Init(false, (ICipherParameters) key);
          signer.BlockUpdate(digest, 0, digest.Length);
          return signer.VerifySignature(signature);
        default:
          throw new CmsException($"algorithm: {encryptionAlgName} not supported in base signatures.");
      }
    }
    catch (SecurityUtilityException ex)
    {
      throw;
    }
    catch (GeneralSecurityException ex)
    {
      throw new CmsException("Exception processing signature: " + ex?.ToString(), (Exception) ex);
    }
    catch (IOException ex)
    {
      throw new CmsException("Exception decoding signature: " + ex?.ToString(), (Exception) ex);
    }
  }

  public bool Verify(AsymmetricKeyParameter pubKey)
  {
    if (pubKey.IsPrivate)
      throw new ArgumentException("Expected public key", nameof (pubKey));
    this.GetSigningTime();
    return this.DoVerify(pubKey);
  }

  public bool Verify(X509Certificate cert)
  {
    Org.BouncyCastle.Asn1.Cms.Time signingTime = this.GetSigningTime();
    if (signingTime != null)
      cert.CheckValidity(signingTime.ToDateTime());
    return this.DoVerify(cert.GetPublicKey());
  }

  public Org.BouncyCastle.Asn1.Cms.SignerInfo ToSignerInfo() => this.info;

  private Asn1Object GetSingleValuedSignedAttribute(
    DerObjectIdentifier attrOID,
    string printableName)
  {
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = this.UnsignedAttributes;
    if (unsignedAttributes != null && unsignedAttributes.GetAll(attrOID).Count > 0)
      throw new CmsException($"The {printableName} attribute MUST NOT be an unsigned attribute");
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttributes = this.SignedAttributes;
    if (signedAttributes == null)
      return (Asn1Object) null;
    Asn1EncodableVector all = signedAttributes.GetAll(attrOID);
    switch (all.Count)
    {
      case 0:
        return (Asn1Object) null;
      case 1:
        Asn1Set attrValues = ((Org.BouncyCastle.Asn1.Cms.Attribute) all[0]).AttrValues;
        return attrValues.Count == 1 ? attrValues[0].ToAsn1Object() : throw new CmsException($"A {printableName} attribute MUST have a single attribute value");
      default:
        throw new CmsException($"The SignedAttributes in a signerInfo MUST NOT include multiple instances of the {printableName} attribute");
    }
  }

  private Org.BouncyCastle.Asn1.Cms.Time GetSigningTime()
  {
    Asn1Object valuedSignedAttribute = this.GetSingleValuedSignedAttribute(CmsAttributes.SigningTime, "signing-time");
    if (valuedSignedAttribute == null)
      return (Org.BouncyCastle.Asn1.Cms.Time) null;
    try
    {
      return Org.BouncyCastle.Asn1.Cms.Time.GetInstance((object) valuedSignedAttribute);
    }
    catch (ArgumentException ex)
    {
      throw new CmsException("signing-time attribute value not a valid 'Time' structure");
    }
  }

  public static SignerInformation ReplaceUnsignedAttributes(
    SignerInformation signerInformation,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes)
  {
    Org.BouncyCastle.Asn1.Cms.SignerInfo info = signerInformation.info;
    Asn1Set unauthenticatedAttributes = (Asn1Set) null;
    if (unsignedAttributes != null)
      unauthenticatedAttributes = (Asn1Set) new DerSet(unsignedAttributes.ToAsn1EncodableVector());
    return new SignerInformation(new Org.BouncyCastle.Asn1.Cms.SignerInfo(info.SignerID, info.DigestAlgorithm, info.AuthenticatedAttributes, info.DigestEncryptionAlgorithm, info.EncryptedDigest, unauthenticatedAttributes), signerInformation.contentType, signerInformation.content, (byte[]) null);
  }

  public static SignerInformation AddCounterSigners(
    SignerInformation signerInformation,
    SignerInformationStore counterSigners)
  {
    Org.BouncyCastle.Asn1.Cms.SignerInfo info = signerInformation.info;
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = signerInformation.UnsignedAttributes;
    Asn1EncodableVector elementVector1 = unsignedAttributes == null ? new Asn1EncodableVector(1) : unsignedAttributes.ToAsn1EncodableVector();
    IList<SignerInformation> signers = counterSigners.GetSigners();
    Asn1EncodableVector elementVector2 = new Asn1EncodableVector(signers.Count);
    foreach (SignerInformation signerInformation1 in (IEnumerable<SignerInformation>) signers)
      elementVector2.Add((Asn1Encodable) signerInformation1.ToSignerInfo());
    elementVector1.Add((Asn1Encodable) new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.CounterSignature, (Asn1Set) new DerSet(elementVector2)));
    return new SignerInformation(new Org.BouncyCastle.Asn1.Cms.SignerInfo(info.SignerID, info.DigestAlgorithm, info.AuthenticatedAttributes, info.DigestEncryptionAlgorithm, info.EncryptedDigest, (Asn1Set) new DerSet(elementVector1)), signerInformation.contentType, signerInformation.content, (byte[]) null);
  }
}
