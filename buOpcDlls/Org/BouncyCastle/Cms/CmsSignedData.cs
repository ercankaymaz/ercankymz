// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsSignedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsSignedData
{
  private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;
  private readonly CmsProcessable signedContent;
  private SignedData signedData;
  private ContentInfo contentInfo;
  private SignerInformationStore signerInfoStore;
  private IDictionary<string, byte[]> m_hashes;

  private CmsSignedData(CmsSignedData c)
  {
    this.signedData = c.signedData;
    this.contentInfo = c.contentInfo;
    this.signedContent = c.signedContent;
    this.signerInfoStore = c.signerInfoStore;
  }

  public CmsSignedData(byte[] sigBlock)
    : this(CmsUtilities.ReadContentInfo((Stream) new MemoryStream(sigBlock, false)))
  {
  }

  public CmsSignedData(CmsProcessable signedContent, byte[] sigBlock)
    : this(signedContent, CmsUtilities.ReadContentInfo((Stream) new MemoryStream(sigBlock, false)))
  {
  }

  public CmsSignedData(IDictionary<string, byte[]> hashes, byte[] sigBlock)
    : this(hashes, CmsUtilities.ReadContentInfo(sigBlock))
  {
  }

  public CmsSignedData(CmsProcessable signedContent, Stream sigData)
    : this(signedContent, CmsUtilities.ReadContentInfo(sigData))
  {
  }

  public CmsSignedData(Stream sigData)
    : this(CmsUtilities.ReadContentInfo(sigData))
  {
  }

  public CmsSignedData(CmsProcessable signedContent, ContentInfo sigData)
  {
    this.signedContent = signedContent;
    this.contentInfo = sigData;
    this.signedData = SignedData.GetInstance((object) this.contentInfo.Content);
  }

  public CmsSignedData(IDictionary<string, byte[]> hashes, ContentInfo sigData)
  {
    this.m_hashes = hashes;
    this.contentInfo = sigData;
    this.signedData = SignedData.GetInstance((object) this.contentInfo.Content);
  }

  public CmsSignedData(ContentInfo sigData)
  {
    this.contentInfo = sigData;
    this.signedData = SignedData.GetInstance((object) this.contentInfo.Content);
    if (this.signedData.EncapContentInfo.Content == null)
      return;
    this.signedContent = (CmsProcessable) new CmsProcessableByteArray(((Asn1OctetString) this.signedData.EncapContentInfo.Content).GetOctets());
  }

  public int Version => this.signedData.Version.IntValueExact;

  public SignerInformationStore GetSignerInfos()
  {
    if (this.signerInfoStore == null)
    {
      List<SignerInformation> signerInfos = new List<SignerInformation>();
      foreach (object signerInfo in this.signedData.SignerInfos)
      {
        SignerInfo instance = SignerInfo.GetInstance(signerInfo);
        DerObjectIdentifier contentType = this.signedData.EncapContentInfo.ContentType;
        if (this.m_hashes == null)
        {
          signerInfos.Add(new SignerInformation(instance, contentType, this.signedContent, (byte[]) null));
        }
        else
        {
          byte[] calculatedDigest;
          if (!this.m_hashes.TryGetValue(instance.DigestAlgorithm.Algorithm.Id, out calculatedDigest))
            throw new InvalidOperationException();
          signerInfos.Add(new SignerInformation(instance, contentType, (CmsProcessable) null, calculatedDigest));
        }
      }
      this.signerInfoStore = new SignerInformationStore((IEnumerable<SignerInformation>) signerInfos);
    }
    return this.signerInfoStore;
  }

  public IStore<X509V2AttributeCertificate> GetAttributeCertificates()
  {
    return CmsSignedData.Helper.GetAttributeCertificates(this.signedData.Certificates);
  }

  public IStore<X509Certificate> GetCertificates()
  {
    return CmsSignedData.Helper.GetCertificates(this.signedData.Certificates);
  }

  public IStore<X509Crl> GetCrls() => CmsSignedData.Helper.GetCrls(this.signedData.CRLs);

  public IStore<Asn1Encodable> GetOtherRevInfos(DerObjectIdentifier otherRevInfoFormat)
  {
    return CmsSignedData.Helper.GetOtherRevInfos(this.signedData.CRLs, otherRevInfoFormat);
  }

  public DerObjectIdentifier SignedContentType => this.signedData.EncapContentInfo.ContentType;

  public CmsProcessable SignedContent => this.signedContent;

  public ContentInfo ContentInfo => this.contentInfo;

  public byte[] GetEncoded() => this.contentInfo.GetEncoded();

  public byte[] GetEncoded(string encoding) => this.contentInfo.GetEncoded(encoding);

  public static CmsSignedData ReplaceSigners(
    CmsSignedData signedData,
    SignerInformationStore signerInformationStore)
  {
    CmsSignedData cmsSignedData = new CmsSignedData(signedData);
    cmsSignedData.signerInfoStore = signerInformationStore;
    IList<SignerInformation> signers = signerInformationStore.GetSigners();
    Asn1EncodableVector elementVector1 = new Asn1EncodableVector(signers.Count);
    Asn1EncodableVector elementVector2 = new Asn1EncodableVector(signers.Count);
    foreach (SignerInformation signerInformation in (IEnumerable<SignerInformation>) signers)
    {
      elementVector1.Add((Asn1Encodable) CmsSignedData.Helper.FixAlgID(signerInformation.DigestAlgorithmID));
      elementVector2.Add((Asn1Encodable) signerInformation.ToSignerInfo());
    }
    Asn1Set element1 = (Asn1Set) new DerSet(elementVector1);
    Asn1Set element2 = (Asn1Set) new DerSet(elementVector2);
    Asn1Sequence asn1Object = (Asn1Sequence) signedData.signedData.ToAsn1Object();
    Asn1EncodableVector elementVector3 = new Asn1EncodableVector(asn1Object.Count);
    elementVector3.Add(asn1Object[0]);
    elementVector3.Add((Asn1Encodable) element1);
    for (int index = 2; index != asn1Object.Count - 1; ++index)
      elementVector3.Add(asn1Object[index]);
    elementVector3.Add((Asn1Encodable) element2);
    cmsSignedData.signedData = SignedData.GetInstance((object) new BerSequence(elementVector3));
    cmsSignedData.contentInfo = new ContentInfo(cmsSignedData.contentInfo.ContentType, (Asn1Encodable) cmsSignedData.signedData);
    return cmsSignedData;
  }

  public static CmsSignedData ReplaceCertificatesAndCrls(
    CmsSignedData signedData,
    IStore<X509Certificate> x509Certs,
    IStore<X509Crl> x509Crls)
  {
    return CmsSignedData.ReplaceCertificatesAndRevocations(signedData, x509Certs, x509Crls, (IStore<X509V2AttributeCertificate>) null, (IStore<OtherRevocationInfoFormat>) null);
  }

  public static CmsSignedData ReplaceCertificatesAndCrls(
    CmsSignedData signedData,
    IStore<X509Certificate> x509Certs,
    IStore<X509Crl> x509Crls,
    IStore<X509V2AttributeCertificate> x509AttrCerts)
  {
    return CmsSignedData.ReplaceCertificatesAndRevocations(signedData, x509Certs, x509Crls, x509AttrCerts, (IStore<OtherRevocationInfoFormat>) null);
  }

  public static CmsSignedData ReplaceCertificatesAndRevocations(
    CmsSignedData signedData,
    IStore<X509Certificate> x509Certs,
    IStore<X509Crl> x509Crls,
    IStore<X509V2AttributeCertificate> x509AttrCerts,
    IStore<OtherRevocationInfoFormat> otherRevocationInfos)
  {
    CmsSignedData cmsSignedData = new CmsSignedData(signedData);
    Asn1Set certificates = (Asn1Set) null;
    Asn1Set crls = (Asn1Set) null;
    if (x509Certs != null || x509AttrCerts != null)
    {
      List<Asn1Encodable> elements = new List<Asn1Encodable>();
      if (x509Certs != null)
        elements.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetCertificatesFromStore(x509Certs));
      if (x509AttrCerts != null)
        elements.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetAttributeCertificatesFromStore(x509AttrCerts));
      Asn1Set berSetFromList = CmsUtilities.CreateBerSetFromList((IEnumerable<Asn1Encodable>) elements);
      if (berSetFromList.Count > 0)
        certificates = berSetFromList;
    }
    if (x509Crls != null || otherRevocationInfos != null)
    {
      List<Asn1Encodable> elements = new List<Asn1Encodable>();
      if (x509Crls != null)
        elements.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetCrlsFromStore(x509Crls));
      if (otherRevocationInfos != null)
        elements.AddRange((IEnumerable<Asn1Encodable>) CmsUtilities.GetOtherRevocationInfosFromStore(otherRevocationInfos));
      Asn1Set berSetFromList = CmsUtilities.CreateBerSetFromList((IEnumerable<Asn1Encodable>) elements);
      if (berSetFromList.Count > 0)
        crls = berSetFromList;
    }
    SignedData signedData1 = signedData.signedData;
    cmsSignedData.signedData = new SignedData(signedData1.DigestAlgorithms, signedData1.EncapContentInfo, certificates, crls, signedData1.SignerInfos);
    cmsSignedData.contentInfo = new ContentInfo(cmsSignedData.contentInfo.ContentType, (Asn1Encodable) cmsSignedData.signedData);
    return cmsSignedData;
  }
}
