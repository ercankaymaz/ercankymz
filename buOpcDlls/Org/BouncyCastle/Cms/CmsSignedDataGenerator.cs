// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsSignedDataGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsSignedDataGenerator : CmsSignedGenerator
{
  private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;
  private readonly IList<CmsSignedDataGenerator.SignerInf> signerInfs = (IList<CmsSignedDataGenerator.SignerInf>) new List<CmsSignedDataGenerator.SignerInf>();

  public CmsSignedDataGenerator()
  {
  }

  public CmsSignedDataGenerator(SecureRandom random)
    : base(random)
  {
  }

  public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOID)
  {
    this.AddSigner(privateKey, cert, CmsSignedDataGenerator.Helper.GetEncOid(privateKey, digestOID), digestOID);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string encryptionOID,
    string digestOID)
  {
    this.doAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(cert), encryptionOID, digestOID, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(), (CmsAttributeTableGenerator) null, (Org.BouncyCastle.Asn1.Cms.AttributeTable) null);
  }

  public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOID)
  {
    this.AddSigner(privateKey, subjectKeyID, CmsSignedDataGenerator.Helper.GetEncOid(privateKey, digestOID), digestOID);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string encryptionOID,
    string digestOID)
  {
    this.doAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(subjectKeyID), encryptionOID, digestOID, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(), (CmsAttributeTableGenerator) null, (Org.BouncyCastle.Asn1.Cms.AttributeTable) null);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string digestOID,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    this.AddSigner(privateKey, cert, CmsSignedDataGenerator.Helper.GetEncOid(privateKey, digestOID), digestOID, signedAttr, unsignedAttr);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string encryptionOID,
    string digestOID,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    this.doAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(cert), encryptionOID, digestOID, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(signedAttr), (CmsAttributeTableGenerator) new SimpleAttributeTableGenerator(unsignedAttr), signedAttr);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string digestOID,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    this.AddSigner(privateKey, subjectKeyID, CmsSignedDataGenerator.Helper.GetEncOid(privateKey, digestOID), digestOID, signedAttr, unsignedAttr);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string encryptionOID,
    string digestOID,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    this.doAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(subjectKeyID), encryptionOID, digestOID, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(signedAttr), (CmsAttributeTableGenerator) new SimpleAttributeTableGenerator(unsignedAttr), signedAttr);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string digestOID,
    CmsAttributeTableGenerator signedAttrGen,
    CmsAttributeTableGenerator unsignedAttrGen)
  {
    this.AddSigner(privateKey, cert, CmsSignedDataGenerator.Helper.GetEncOid(privateKey, digestOID), digestOID, signedAttrGen, unsignedAttrGen);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string encryptionOID,
    string digestOID,
    CmsAttributeTableGenerator signedAttrGen,
    CmsAttributeTableGenerator unsignedAttrGen)
  {
    this.doAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(cert), encryptionOID, digestOID, signedAttrGen, unsignedAttrGen, (Org.BouncyCastle.Asn1.Cms.AttributeTable) null);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string digestOID,
    CmsAttributeTableGenerator signedAttrGen,
    CmsAttributeTableGenerator unsignedAttrGen)
  {
    this.AddSigner(privateKey, subjectKeyID, CmsSignedDataGenerator.Helper.GetEncOid(privateKey, digestOID), digestOID, signedAttrGen, unsignedAttrGen);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string encryptionOID,
    string digestOID,
    CmsAttributeTableGenerator signedAttrGen,
    CmsAttributeTableGenerator unsignedAttrGen)
  {
    this.doAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(subjectKeyID), encryptionOID, digestOID, signedAttrGen, unsignedAttrGen, (Org.BouncyCastle.Asn1.Cms.AttributeTable) null);
  }

  public void AddSignerInfoGenerator(SignerInfoGenerator signerInfoGenerator)
  {
    this.signerInfs.Add(new CmsSignedDataGenerator.SignerInf((CmsSignedGenerator) this, signerInfoGenerator.contentSigner, signerInfoGenerator.sigId, signerInfoGenerator.signedGen, signerInfoGenerator.unsignedGen, (Org.BouncyCastle.Asn1.Cms.AttributeTable) null));
  }

  private void doAddSigner(
    AsymmetricKeyParameter privateKey,
    SignerIdentifier signerIdentifier,
    string encryptionOID,
    string digestOID,
    CmsAttributeTableGenerator signedAttrGen,
    CmsAttributeTableGenerator unsignedAttrGen,
    Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable)
  {
    this.signerInfs.Add(new CmsSignedDataGenerator.SignerInf((CmsSignedGenerator) this, privateKey, this.m_random, signerIdentifier, digestOID, encryptionOID, signedAttrGen, unsignedAttrGen, baseSignedTable));
  }

  public CmsSignedData Generate(CmsProcessable content) => this.Generate(content, false);

  public CmsSignedData Generate(string signedContentType, CmsProcessable content, bool encapsulate)
  {
    Asn1EncodableVector elementVector1 = new Asn1EncodableVector();
    Asn1EncodableVector elementVector2 = new Asn1EncodableVector();
    this.m_digests.Clear();
    foreach (SignerInformation signer in (IEnumerable<SignerInformation>) this._signers)
    {
      elementVector1.Add((Asn1Encodable) CmsSignedDataGenerator.Helper.FixAlgID(signer.DigestAlgorithmID));
      elementVector2.Add((Asn1Encodable) signer.ToSignerInfo());
    }
    DerObjectIdentifier contentType = signedContentType == null ? (DerObjectIdentifier) null : new DerObjectIdentifier(signedContentType);
    foreach (CmsSignedDataGenerator.SignerInf signerInf in (IEnumerable<CmsSignedDataGenerator.SignerInf>) this.signerInfs)
    {
      try
      {
        elementVector1.Add((Asn1Encodable) signerInf.DigestAlgorithmID);
        elementVector2.Add((Asn1Encodable) signerInf.ToSignerInfo(contentType, content));
      }
      catch (IOException ex)
      {
        throw new CmsException("encoding error.", (Exception) ex);
      }
      catch (InvalidKeyException ex)
      {
        throw new CmsException("key inappropriate for signature.", (Exception) ex);
      }
      catch (SignatureException ex)
      {
        throw new CmsException("error creating signature.", (Exception) ex);
      }
      catch (CertificateEncodingException ex)
      {
        throw new CmsException("error creating sid.", (Exception) ex);
      }
    }
    Asn1Set certificates = (Asn1Set) null;
    if (this._certs.Count != 0)
      certificates = this.UseDerForCerts ? CmsUtilities.CreateDerSetFromList((IEnumerable<Asn1Encodable>) this._certs) : CmsUtilities.CreateBerSetFromList((IEnumerable<Asn1Encodable>) this._certs);
    Asn1Set crls = (Asn1Set) null;
    if (this._crls.Count != 0)
      crls = this.UseDerForCrls ? CmsUtilities.CreateDerSetFromList((IEnumerable<Asn1Encodable>) this._crls) : CmsUtilities.CreateBerSetFromList((IEnumerable<Asn1Encodable>) this._crls);
    Asn1OctetString content1 = (Asn1OctetString) null;
    if (encapsulate)
    {
      MemoryStream outStream = new MemoryStream();
      if (content != null)
      {
        try
        {
          content.Write((Stream) outStream);
        }
        catch (IOException ex)
        {
          throw new CmsException("encapsulation error.", (Exception) ex);
        }
      }
      content1 = (Asn1OctetString) new BerOctetString(outStream.ToArray());
    }
    ContentInfo contentInfo = new ContentInfo(contentType, (Asn1Encodable) content1);
    SignedData content2 = new SignedData((Asn1Set) new DerSet(elementVector1), contentInfo, certificates, crls, (Asn1Set) new DerSet(elementVector2));
    ContentInfo sigData = new ContentInfo(CmsObjectIdentifiers.SignedData, (Asn1Encodable) content2);
    return new CmsSignedData(content, sigData);
  }

  public CmsSignedData Generate(CmsProcessable content, bool encapsulate)
  {
    return this.Generate(CmsSignedGenerator.Data, content, encapsulate);
  }

  public SignerInformationStore GenerateCounterSigners(SignerInformation signer)
  {
    return this.Generate((string) null, (CmsProcessable) new CmsProcessableByteArray(signer.GetSignature()), false).GetSignerInfos();
  }

  private class SignerInf
  {
    private readonly CmsSignedGenerator outer;
    private readonly ISignatureFactory sigCalc;
    private readonly SignerIdentifier signerIdentifier;
    private readonly string digestOID;
    private readonly string encOID;
    private readonly CmsAttributeTableGenerator sAttr;
    private readonly CmsAttributeTableGenerator unsAttr;
    private readonly Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable;

    internal SignerInf(
      CmsSignedGenerator outer,
      AsymmetricKeyParameter key,
      SecureRandom random,
      SignerIdentifier signerIdentifier,
      string digestOID,
      string encOID,
      CmsAttributeTableGenerator sAttr,
      CmsAttributeTableGenerator unsAttr,
      Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable)
    {
      string algorithm = $"{CmsSignedDataGenerator.Helper.GetDigestAlgName(digestOID)}with{CmsSignedDataGenerator.Helper.GetEncryptionAlgName(encOID)}";
      this.outer = outer;
      this.sigCalc = (ISignatureFactory) new Asn1SignatureFactory(algorithm, key, random);
      this.signerIdentifier = signerIdentifier;
      this.digestOID = digestOID;
      this.encOID = encOID;
      this.sAttr = sAttr;
      this.unsAttr = unsAttr;
      this.baseSignedTable = baseSignedTable;
    }

    internal SignerInf(
      CmsSignedGenerator outer,
      ISignatureFactory sigCalc,
      SignerIdentifier signerIdentifier,
      CmsAttributeTableGenerator sAttr,
      CmsAttributeTableGenerator unsAttr,
      Org.BouncyCastle.Asn1.Cms.AttributeTable baseSignedTable)
    {
      this.outer = outer;
      this.sigCalc = sigCalc;
      this.signerIdentifier = signerIdentifier;
      this.digestOID = new DefaultDigestAlgorithmIdentifierFinder().Find((AlgorithmIdentifier) sigCalc.AlgorithmDetails).Algorithm.Id;
      this.encOID = ((AlgorithmIdentifier) sigCalc.AlgorithmDetails).Algorithm.Id;
      this.sAttr = sAttr;
      this.unsAttr = unsAttr;
      this.baseSignedTable = baseSignedTable;
    }

    internal AlgorithmIdentifier DigestAlgorithmID
    {
      get
      {
        return new AlgorithmIdentifier(new DerObjectIdentifier(this.digestOID), (Asn1Encodable) DerNull.Instance);
      }
    }

    internal CmsAttributeTableGenerator SignedAttributes => this.sAttr;

    internal CmsAttributeTableGenerator UnsignedAttributes => this.unsAttr;

    internal SignerInfo ToSignerInfo(DerObjectIdentifier contentType, CmsProcessable content)
    {
      AlgorithmIdentifier digestAlgorithmId = this.DigestAlgorithmID;
      string digestAlgName = CmsSignedDataGenerator.Helper.GetDigestAlgName(this.digestOID);
      string algorithm = $"{digestAlgName}with{CmsSignedDataGenerator.Helper.GetEncryptionAlgName(this.encOID)}";
      byte[] hash;
      if (!this.outer.m_digests.TryGetValue(this.digestOID, out hash))
      {
        IDigest digestInstance = CmsSignedDataGenerator.Helper.GetDigestInstance(digestAlgName);
        content?.Write((Stream) new DigestSink(digestInstance));
        hash = DigestUtilities.DoFinal(digestInstance);
        this.outer.m_digests.Add(this.digestOID, (byte[]) hash.Clone());
      }
      Asn1Set authenticatedAttributes = (Asn1Set) null;
      IStreamCalculator<IBlockResult> calculator = this.sigCalc.CreateCalculator();
      using (Stream stream = calculator.Stream)
      {
        if (this.sAttr != null)
        {
          Org.BouncyCastle.Asn1.Cms.AttributeTable attr = this.sAttr.GetAttributes(this.outer.GetBaseParameters(contentType, digestAlgorithmId, hash));
          if (contentType == null && attr != null && attr[CmsAttributes.ContentType] != null)
            attr = attr.Remove(CmsAttributes.ContentType);
          authenticatedAttributes = this.outer.GetAttributeSet(attr);
          authenticatedAttributes.EncodeTo(stream, "DER");
        }
        else
          content?.Write(stream);
      }
      byte[] contents = calculator.GetResult().Collect();
      Asn1Set unauthenticatedAttributes = (Asn1Set) null;
      if (this.unsAttr != null)
      {
        IDictionary<CmsAttributeTableParameter, object> baseParameters = this.outer.GetBaseParameters(contentType, digestAlgorithmId, hash);
        baseParameters[CmsAttributeTableParameter.Signature] = contents.Clone();
        unauthenticatedAttributes = this.outer.GetAttributeSet(this.unsAttr.GetAttributes(baseParameters));
      }
      Asn1Encodable defaultX509Parameters = SignerUtilities.GetDefaultX509Parameters(algorithm);
      AlgorithmIdentifier algorithmIdentifier = CmsSignedDataGenerator.Helper.GetEncAlgorithmIdentifier(new DerObjectIdentifier(this.encOID), defaultX509Parameters);
      return new SignerInfo(this.signerIdentifier, digestAlgorithmId, authenticatedAttributes, algorithmIdentifier, (Asn1OctetString) new DerOctetString(contents), unauthenticatedAttributes);
    }
  }
}
