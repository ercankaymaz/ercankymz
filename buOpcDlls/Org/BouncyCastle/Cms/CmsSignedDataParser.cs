// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsSignedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.IO;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsSignedDataParser : CmsContentInfoParser
{
  private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;
  private SignedDataParser _signedData;
  private DerObjectIdentifier _signedContentType;
  private CmsTypedStream _signedContent;
  private IDictionary<string, IDigest> m_digests;
  private HashSet<string> _digestOids;
  private SignerInformationStore _signerInfoStore;
  private Asn1Set _certSet;
  private Asn1Set _crlSet;
  private bool _isCertCrlParsed;

  public CmsSignedDataParser(byte[] sigBlock)
    : this((Stream) new MemoryStream(sigBlock, false))
  {
  }

  public CmsSignedDataParser(CmsTypedStream signedContent, byte[] sigBlock)
    : this(signedContent, (Stream) new MemoryStream(sigBlock, false))
  {
  }

  public CmsSignedDataParser(Stream sigData)
    : this((CmsTypedStream) null, sigData)
  {
  }

  public CmsSignedDataParser(CmsTypedStream signedContent, Stream sigData)
    : base(sigData)
  {
    try
    {
      this._signedContent = signedContent;
      this._signedData = SignedDataParser.GetInstance((object) this.contentInfo.GetContent(16 /*0x10*/));
      this.m_digests = (IDictionary<string, IDigest>) new Dictionary<string, IDigest>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      this._digestOids = new HashSet<string>();
      Asn1SetParser digestAlgorithms = this._signedData.GetDigestAlgorithms();
      IAsn1Convertible asn1Convertible;
      while ((asn1Convertible = digestAlgorithms.ReadObject()) != null)
      {
        AlgorithmIdentifier instance = AlgorithmIdentifier.GetInstance((object) asn1Convertible.ToAsn1Object());
        try
        {
          string id = instance.Algorithm.Id;
          string digestAlgName = CmsSignedDataParser.Helper.GetDigestAlgName(id);
          if (!this.m_digests.ContainsKey(digestAlgName))
          {
            this.m_digests[digestAlgName] = CmsSignedDataParser.Helper.GetDigestInstance(digestAlgName);
            this._digestOids.Add(id);
          }
        }
        catch (SecurityUtilityException ex)
        {
        }
      }
      ContentInfoParser encapContentInfo = this._signedData.GetEncapContentInfo();
      Asn1OctetStringParser content = (Asn1OctetStringParser) encapContentInfo.GetContent(4);
      if (content != null)
      {
        CmsTypedStream cmsTypedStream = new CmsTypedStream(encapContentInfo.ContentType.Id, content.GetOctetStream());
        if (this._signedContent == null)
          this._signedContent = cmsTypedStream;
        else
          cmsTypedStream.Drain();
      }
      this._signedContentType = this._signedContent == null ? encapContentInfo.ContentType : new DerObjectIdentifier(this._signedContent.ContentType);
    }
    catch (IOException ex)
    {
      throw new CmsException("io exception: " + ex.Message, (Exception) ex);
    }
  }

  public int Version => this._signedData.Version.IntValueExact;

  public ISet<string> DigestOids
  {
    get => (ISet<string>) new HashSet<string>((IEnumerable<string>) this._digestOids);
  }

  public SignerInformationStore GetSignerInfos()
  {
    if (this._signerInfoStore == null)
    {
      this.PopulateCertCrlSets();
      List<SignerInformation> signerInfos1 = new List<SignerInformation>();
      Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      foreach (KeyValuePair<string, IDigest> digest in (IEnumerable<KeyValuePair<string, IDigest>>) this.m_digests)
        dictionary[digest.Key] = DigestUtilities.DoFinal(digest.Value);
      try
      {
        Asn1SetParser signerInfos2 = this._signedData.GetSignerInfos();
        IAsn1Convertible asn1Convertible;
        while ((asn1Convertible = signerInfos2.ReadObject()) != null)
        {
          SignerInfo instance = SignerInfo.GetInstance((object) asn1Convertible.ToAsn1Object());
          string digestAlgName = CmsSignedDataParser.Helper.GetDigestAlgName(instance.DigestAlgorithm.Algorithm.Id);
          byte[] calculatedDigest = dictionary[digestAlgName];
          signerInfos1.Add(new SignerInformation(instance, this._signedContentType, (CmsProcessable) null, calculatedDigest));
        }
      }
      catch (IOException ex)
      {
        throw new CmsException("io exception: " + ex.Message, (Exception) ex);
      }
      this._signerInfoStore = new SignerInformationStore((IEnumerable<SignerInformation>) signerInfos1);
    }
    return this._signerInfoStore;
  }

  public IStore<X509V2AttributeCertificate> GetAttributeCertificates()
  {
    this.PopulateCertCrlSets();
    return CmsSignedDataParser.Helper.GetAttributeCertificates(this._certSet);
  }

  public IStore<X509Certificate> GetCertificates()
  {
    this.PopulateCertCrlSets();
    return CmsSignedDataParser.Helper.GetCertificates(this._certSet);
  }

  public IStore<X509Crl> GetCrls()
  {
    this.PopulateCertCrlSets();
    return CmsSignedDataParser.Helper.GetCrls(this._crlSet);
  }

  public IStore<Asn1Encodable> GetOtherRevInfos(DerObjectIdentifier otherRevInfoFormat)
  {
    this.PopulateCertCrlSets();
    return CmsSignedDataParser.Helper.GetOtherRevInfos(this._crlSet, otherRevInfoFormat);
  }

  private void PopulateCertCrlSets()
  {
    if (this._isCertCrlParsed)
      return;
    this._isCertCrlParsed = true;
    try
    {
      this._certSet = CmsSignedDataParser.GetAsn1Set(this._signedData.GetCertificates());
      this._crlSet = CmsSignedDataParser.GetAsn1Set(this._signedData.GetCrls());
    }
    catch (IOException ex)
    {
      throw new CmsException("problem parsing cert/crl sets", (Exception) ex);
    }
  }

  public DerObjectIdentifier SignedContentType => this._signedContentType;

  public CmsTypedStream GetSignedContent()
  {
    if (this._signedContent == null)
      return (CmsTypedStream) null;
    Stream stream = this._signedContent.ContentStream;
    foreach (IDigest readDigest in (IEnumerable<IDigest>) this.m_digests.Values)
      stream = (Stream) new DigestStream(stream, readDigest, (IDigest) null);
    return new CmsTypedStream(this._signedContent.ContentType, stream);
  }

  public static Stream ReplaceSigners(
    Stream original,
    SignerInformationStore signerInformationStore,
    Stream outStr)
  {
    CmsSignedDataStreamGenerator dataStreamGenerator = new CmsSignedDataStreamGenerator();
    CmsSignedDataParser signedDataParser = new CmsSignedDataParser(original);
    dataStreamGenerator.AddSigners(signerInformationStore);
    CmsTypedStream signedContent = signedDataParser.GetSignedContent();
    bool encapsulate = signedContent != null;
    Stream outStr1 = dataStreamGenerator.Open(outStr, signedDataParser.SignedContentType.Id, encapsulate);
    if (encapsulate)
      Streams.PipeAll(signedContent.ContentStream, outStr1);
    dataStreamGenerator.AddAttributeCertificates(signedDataParser.GetAttributeCertificates());
    dataStreamGenerator.AddCertificates(signedDataParser.GetCertificates());
    dataStreamGenerator.AddCrls(signedDataParser.GetCrls());
    outStr1.Dispose();
    return outStr;
  }

  public static Stream ReplaceCertificatesAndCrls(
    Stream original,
    IStore<X509Certificate> x509Certs,
    IStore<X509Crl> x509Crls,
    IStore<X509V2AttributeCertificate> x509AttrCerts,
    Stream outStr)
  {
    CmsSignedDataStreamGenerator dataStreamGenerator = new CmsSignedDataStreamGenerator();
    CmsSignedDataParser signedDataParser = new CmsSignedDataParser(original);
    dataStreamGenerator.AddDigests((IEnumerable<string>) signedDataParser.DigestOids);
    CmsTypedStream signedContent = signedDataParser.GetSignedContent();
    bool encapsulate = signedContent != null;
    Stream outStr1 = dataStreamGenerator.Open(outStr, signedDataParser.SignedContentType.Id, encapsulate);
    if (encapsulate)
      Streams.PipeAll(signedContent.ContentStream, outStr1);
    if (x509AttrCerts != null)
      dataStreamGenerator.AddAttributeCertificates(x509AttrCerts);
    if (x509Certs != null)
      dataStreamGenerator.AddCertificates(x509Certs);
    if (x509Crls != null)
      dataStreamGenerator.AddCrls(x509Crls);
    dataStreamGenerator.AddSigners(signedDataParser.GetSignerInfos());
    outStr1.Dispose();
    return outStr;
  }

  private static Asn1Set GetAsn1Set(Asn1SetParser asn1SetParser)
  {
    return asn1SetParser != null ? Asn1Set.GetInstance((object) asn1SetParser.ToAsn1Object()) : (Asn1Set) null;
  }
}
