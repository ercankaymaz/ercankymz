// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsSignedDataStreamGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsSignedDataStreamGenerator : CmsSignedGenerator
{
  private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;
  private readonly IList<CmsSignedDataStreamGenerator.DigestAndSignerInfoGeneratorHolder> _signerInfs = (IList<CmsSignedDataStreamGenerator.DigestAndSignerInfoGeneratorHolder>) new List<CmsSignedDataStreamGenerator.DigestAndSignerInfoGeneratorHolder>();
  private readonly HashSet<string> _messageDigestOids = new HashSet<string>();
  private readonly IDictionary<string, IDigest> m_messageDigests = (IDictionary<string, IDigest>) new Dictionary<string, IDigest>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private readonly IDictionary<string, byte[]> m_messageHashes = (IDictionary<string, byte[]>) new Dictionary<string, byte[]>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private bool _messageDigestsLocked;
  private int _bufferSize;

  public CmsSignedDataStreamGenerator()
  {
  }

  public CmsSignedDataStreamGenerator(SecureRandom random)
    : base(random)
  {
  }

  public void SetBufferSize(int bufferSize) => this._bufferSize = bufferSize;

  public void AddDigests(params string[] digestOids)
  {
    foreach (string digestOid in digestOids)
      this.ConfigureDigest(digestOid);
  }

  public void AddDigests(IEnumerable<string> digestOids)
  {
    foreach (string digestOid in digestOids)
      this.ConfigureDigest(digestOid);
  }

  public void AddSigner(AsymmetricKeyParameter privateKey, X509Certificate cert, string digestOid)
  {
    this.AddSigner(privateKey, cert, digestOid, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(), (CmsAttributeTableGenerator) null);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string encryptionOid,
    string digestOid)
  {
    this.AddSigner(privateKey, cert, encryptionOid, digestOid, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(), (CmsAttributeTableGenerator) null);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string digestOid,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    this.AddSigner(privateKey, cert, digestOid, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(signedAttr), (CmsAttributeTableGenerator) new SimpleAttributeTableGenerator(unsignedAttr));
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string encryptionOid,
    string digestOid,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    this.AddSigner(privateKey, cert, encryptionOid, digestOid, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(signedAttr), (CmsAttributeTableGenerator) new SimpleAttributeTableGenerator(unsignedAttr));
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string digestOid,
    CmsAttributeTableGenerator signedAttrGenerator,
    CmsAttributeTableGenerator unsignedAttrGenerator)
  {
    this.AddSigner(privateKey, cert, CmsSignedDataStreamGenerator.Helper.GetEncOid(privateKey, digestOid), digestOid, signedAttrGenerator, unsignedAttrGenerator);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    X509Certificate cert,
    string encryptionOid,
    string digestOid,
    CmsAttributeTableGenerator signedAttrGenerator,
    CmsAttributeTableGenerator unsignedAttrGenerator)
  {
    this.DoAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(cert), encryptionOid, digestOid, signedAttrGenerator, unsignedAttrGenerator);
  }

  public void AddSigner(AsymmetricKeyParameter privateKey, byte[] subjectKeyID, string digestOid)
  {
    this.AddSigner(privateKey, subjectKeyID, digestOid, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(), (CmsAttributeTableGenerator) null);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string encryptionOid,
    string digestOid)
  {
    this.AddSigner(privateKey, subjectKeyID, encryptionOid, digestOid, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(), (CmsAttributeTableGenerator) null);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string digestOid,
    Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttr,
    Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttr)
  {
    this.AddSigner(privateKey, subjectKeyID, digestOid, (CmsAttributeTableGenerator) new DefaultSignedAttributeTableGenerator(signedAttr), (CmsAttributeTableGenerator) new SimpleAttributeTableGenerator(unsignedAttr));
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string digestOid,
    CmsAttributeTableGenerator signedAttrGenerator,
    CmsAttributeTableGenerator unsignedAttrGenerator)
  {
    this.AddSigner(privateKey, subjectKeyID, CmsSignedDataStreamGenerator.Helper.GetEncOid(privateKey, digestOid), digestOid, signedAttrGenerator, unsignedAttrGenerator);
  }

  public void AddSigner(
    AsymmetricKeyParameter privateKey,
    byte[] subjectKeyID,
    string encryptionOid,
    string digestOid,
    CmsAttributeTableGenerator signedAttrGenerator,
    CmsAttributeTableGenerator unsignedAttrGenerator)
  {
    this.DoAddSigner(privateKey, CmsSignedGenerator.GetSignerIdentifier(subjectKeyID), encryptionOid, digestOid, signedAttrGenerator, unsignedAttrGenerator);
  }

  private void DoAddSigner(
    AsymmetricKeyParameter privateKey,
    SignerIdentifier signerIdentifier,
    string encryptionOid,
    string digestOid,
    CmsAttributeTableGenerator signedAttrGenerator,
    CmsAttributeTableGenerator unsignedAttrGenerator)
  {
    this.ConfigureDigest(digestOid);
    this._signerInfs.Add(new CmsSignedDataStreamGenerator.DigestAndSignerInfoGeneratorHolder((ISignerInfoGenerator) new CmsSignedDataStreamGenerator.SignerInfoGeneratorImpl(this, privateKey, signerIdentifier, digestOid, encryptionOid, signedAttrGenerator, unsignedAttrGenerator), digestOid));
  }

  internal override void AddSignerCallback(SignerInformation si)
  {
    this.RegisterDigestOid(si.DigestAlgorithmID.Algorithm.Id);
  }

  public Stream Open(Stream outStream) => this.Open(outStream, false);

  public Stream Open(Stream outStream, bool encapsulate)
  {
    return this.Open(outStream, CmsSignedGenerator.Data, encapsulate);
  }

  public Stream Open(Stream outStream, bool encapsulate, Stream dataOutputStream)
  {
    return this.Open(outStream, CmsSignedGenerator.Data, encapsulate, dataOutputStream);
  }

  public Stream Open(Stream outStream, string signedContentType, bool encapsulate)
  {
    return this.Open(outStream, signedContentType, encapsulate, (Stream) null);
  }

  public Stream Open(
    Stream outStream,
    string signedContentType,
    bool encapsulate,
    Stream dataOutputStream)
  {
    if (outStream == null)
      throw new ArgumentNullException(nameof (outStream));
    if (!outStream.CanWrite)
      throw new ArgumentException("Expected writeable stream", nameof (outStream));
    if (dataOutputStream != null && !dataOutputStream.CanWrite)
      throw new ArgumentException("Expected writeable stream", nameof (dataOutputStream));
    this._messageDigestsLocked = true;
    BerSequenceGenerator sGen = new BerSequenceGenerator(outStream);
    sGen.AddObject((Asn1Object) CmsObjectIdentifiers.SignedData);
    BerSequenceGenerator sigGen = new BerSequenceGenerator(sGen.GetRawOutputStream(), 0, true);
    DerObjectIdentifier contentOid = signedContentType == null ? (DerObjectIdentifier) null : new DerObjectIdentifier(signedContentType);
    sigGen.AddObject((Asn1Object) this.CalculateVersion(contentOid));
    Asn1EncodableVector elementVector = new Asn1EncodableVector(this._messageDigestOids.Count);
    foreach (string messageDigestOid in this._messageDigestOids)
      elementVector.Add((Asn1Encodable) new AlgorithmIdentifier(new DerObjectIdentifier(messageDigestOid), (Asn1Encodable) DerNull.Instance));
    new DerSet(elementVector).EncodeTo(sigGen.GetRawOutputStream());
    BerSequenceGenerator eiGen = new BerSequenceGenerator(sigGen.GetRawOutputStream());
    eiGen.AddObject((Asn1Object) contentOid);
    BerOctetStringGenerator octGen = (BerOctetStringGenerator) null;
    Stream s2 = (Stream) null;
    if (encapsulate)
    {
      octGen = new BerOctetStringGenerator(eiGen.GetRawOutputStream(), 0, true);
      s2 = octGen.GetOctetOutputStream(this._bufferSize);
    }
    return (Stream) new CmsSignedDataStreamGenerator.CmsSignedDataOutputStream(this, CmsSignedDataStreamGenerator.AttachDigestsToOutputStream((IEnumerable<IDigest>) this.m_messageDigests.Values, CmsSignedDataStreamGenerator.GetSafeTeeOutputStream(dataOutputStream, s2)), signedContentType, sGen, sigGen, eiGen, octGen);
  }

  private void RegisterDigestOid(string digestOid)
  {
    if (this._messageDigestsLocked)
    {
      if (!this._messageDigestOids.Contains(digestOid))
        throw new InvalidOperationException("Cannot register new digest OIDs after the data stream is opened");
    }
    else
      this._messageDigestOids.Add(digestOid);
  }

  private void ConfigureDigest(string digestOid)
  {
    this.RegisterDigestOid(digestOid);
    string digestAlgName = CmsSignedDataStreamGenerator.Helper.GetDigestAlgName(digestOid);
    if (this.m_messageDigests.ContainsKey(digestAlgName))
      return;
    if (this._messageDigestsLocked)
      throw new InvalidOperationException("Cannot configure new digests after the data stream is opened");
    this.m_messageDigests[digestAlgName] = CmsSignedDataStreamGenerator.Helper.GetDigestInstance(digestAlgName);
  }

  internal void Generate(
    Stream outStream,
    string eContentType,
    bool encapsulate,
    Stream dataOutputStream,
    CmsProcessable content)
  {
    using (Stream outStream1 = this.Open(outStream, eContentType, encapsulate, dataOutputStream))
      content?.Write(outStream1);
  }

  private DerInteger CalculateVersion(DerObjectIdentifier contentOid)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    if (this._certs != null)
    {
      foreach (Asn1Encodable cert in this._certs)
      {
        if (cert is Asn1TaggedObject asn1TaggedObject)
        {
          if (asn1TaggedObject.TagNo == 1)
            flag3 = true;
          else if (asn1TaggedObject.TagNo == 2)
            flag4 = true;
          else if (asn1TaggedObject.TagNo == 3)
          {
            flag1 = true;
            break;
          }
        }
      }
    }
    if (flag1)
      return new DerInteger(5);
    if (this._crls != null)
    {
      foreach (Asn1Encodable crl in this._crls)
      {
        if (crl is Asn1TaggedObject)
        {
          flag2 = true;
          break;
        }
      }
    }
    if (flag2)
      return new DerInteger(5);
    if (flag4)
      return new DerInteger(4);
    return !flag3 && CmsObjectIdentifiers.Data.Equals((Asn1Object) contentOid) && !this.CheckForVersion3(this._signers) ? new DerInteger(1) : new DerInteger(3);
  }

  private bool CheckForVersion3(IList<SignerInformation> signerInfos)
  {
    foreach (SignerInformation signerInfo in (IEnumerable<SignerInformation>) signerInfos)
    {
      if (SignerInfo.GetInstance((object) signerInfo.ToSignerInfo()).Version.IntValueExact == 3)
        return true;
    }
    return false;
  }

  private static Stream AttachDigestsToOutputStream(IEnumerable<IDigest> digests, Stream s)
  {
    Stream s1 = s;
    foreach (IDigest digest in digests)
      s1 = CmsSignedDataStreamGenerator.GetSafeTeeOutputStream(s1, (Stream) new DigestSink(digest));
    return s1;
  }

  private static Stream GetSafeOutputStream(Stream s) => s ?? Stream.Null;

  private static Stream GetSafeTeeOutputStream(Stream s1, Stream s2)
  {
    if (s1 == null)
      return CmsSignedDataStreamGenerator.GetSafeOutputStream(s2);
    return s2 == null ? CmsSignedDataStreamGenerator.GetSafeOutputStream(s1) : (Stream) new TeeOutputStream(s1, s2);
  }

  private class DigestAndSignerInfoGeneratorHolder
  {
    internal readonly ISignerInfoGenerator signerInf;
    internal readonly string digestOID;

    internal DigestAndSignerInfoGeneratorHolder(ISignerInfoGenerator signerInf, string digestOID)
    {
      this.signerInf = signerInf;
      this.digestOID = digestOID;
    }

    internal AlgorithmIdentifier DigestAlgorithm
    {
      get
      {
        return new AlgorithmIdentifier(new DerObjectIdentifier(this.digestOID), (Asn1Encodable) DerNull.Instance);
      }
    }
  }

  private class SignerInfoGeneratorImpl : ISignerInfoGenerator
  {
    private readonly CmsSignedDataStreamGenerator outer;
    private readonly SignerIdentifier _signerIdentifier;
    private readonly string _digestOID;
    private readonly string _encOID;
    private readonly CmsAttributeTableGenerator _sAttr;
    private readonly CmsAttributeTableGenerator _unsAttr;
    private readonly string _encName;
    private readonly ISigner _sig;

    internal SignerInfoGeneratorImpl(
      CmsSignedDataStreamGenerator outer,
      AsymmetricKeyParameter key,
      SignerIdentifier signerIdentifier,
      string digestOID,
      string encOID,
      CmsAttributeTableGenerator sAttr,
      CmsAttributeTableGenerator unsAttr)
    {
      this.outer = outer;
      this._signerIdentifier = signerIdentifier;
      this._digestOID = digestOID;
      this._encOID = encOID;
      this._sAttr = sAttr;
      this._unsAttr = unsAttr;
      this._encName = CmsSignedDataStreamGenerator.Helper.GetEncryptionAlgName(this._encOID);
      string algorithm = $"{CmsSignedDataStreamGenerator.Helper.GetDigestAlgName(this._digestOID)}with{this._encName}";
      if (this._sAttr != null)
        this._sig = SignerUtilities.InitSigner(algorithm, true, key, outer.m_random);
      else if (this._encName.Equals("RSA"))
      {
        this._sig = SignerUtilities.InitSigner("RSA", true, key, outer.m_random);
      }
      else
      {
        if (!this._encName.Equals("DSA"))
          throw new SignatureException($"algorithm: {this._encName} not supported in base signatures.");
        this._sig = SignerUtilities.InitSigner("NONEwithDSA", true, key, outer.m_random);
      }
    }

    public SignerInfo Generate(
      DerObjectIdentifier contentType,
      AlgorithmIdentifier digestAlgorithm,
      byte[] calculatedDigest)
    {
      try
      {
        string algorithm = $"{CmsSignedDataStreamGenerator.Helper.GetDigestAlgName(this._digestOID)}with{this._encName}";
        byte[] input = calculatedDigest;
        Asn1Set authenticatedAttributes = (Asn1Set) null;
        if (this._sAttr != null)
        {
          Org.BouncyCastle.Asn1.Cms.AttributeTable attr = this._sAttr.GetAttributes(this.outer.GetBaseParameters(contentType, digestAlgorithm, calculatedDigest));
          if (contentType == null && attr != null && attr[CmsAttributes.ContentType] != null)
            attr = attr.Remove(CmsAttributes.ContentType);
          authenticatedAttributes = this.outer.GetAttributeSet(attr);
          input = authenticatedAttributes.GetEncoded("DER");
        }
        else if (this._encName.Equals("RSA"))
          input = new DigestInfo(digestAlgorithm, calculatedDigest).GetEncoded("DER");
        this._sig.BlockUpdate(input, 0, input.Length);
        byte[] signature = this._sig.GenerateSignature();
        Asn1Set unauthenticatedAttributes = (Asn1Set) null;
        if (this._unsAttr != null)
        {
          IDictionary<CmsAttributeTableParameter, object> baseParameters = this.outer.GetBaseParameters(contentType, digestAlgorithm, calculatedDigest);
          baseParameters[CmsAttributeTableParameter.Signature] = signature.Clone();
          unauthenticatedAttributes = this.outer.GetAttributeSet(this._unsAttr.GetAttributes(baseParameters));
        }
        Asn1Encodable defaultX509Parameters = SignerUtilities.GetDefaultX509Parameters(algorithm);
        AlgorithmIdentifier algorithmIdentifier = CmsSignedDataStreamGenerator.Helper.GetEncAlgorithmIdentifier(new DerObjectIdentifier(this._encOID), defaultX509Parameters);
        return new SignerInfo(this._signerIdentifier, digestAlgorithm, authenticatedAttributes, algorithmIdentifier, (Asn1OctetString) new DerOctetString(signature), unauthenticatedAttributes);
      }
      catch (IOException ex)
      {
        throw new CmsStreamException("encoding error.", (Exception) ex);
      }
      catch (SignatureException ex)
      {
        throw new CmsStreamException("error creating signature.", (Exception) ex);
      }
    }
  }

  private class CmsSignedDataOutputStream : BaseOutputStream
  {
    private readonly CmsSignedDataStreamGenerator outer;
    private Stream _out;
    private DerObjectIdentifier _contentOID;
    private BerSequenceGenerator _sGen;
    private BerSequenceGenerator _sigGen;
    private BerSequenceGenerator _eiGen;
    private BerOctetStringGenerator _octGen;

    public CmsSignedDataOutputStream(
      CmsSignedDataStreamGenerator outer,
      Stream outStream,
      string contentOID,
      BerSequenceGenerator sGen,
      BerSequenceGenerator sigGen,
      BerSequenceGenerator eiGen,
      BerOctetStringGenerator octGen)
    {
      this.outer = outer;
      this._out = outStream;
      this._contentOID = new DerObjectIdentifier(contentOID);
      this._sGen = sGen;
      this._sigGen = sigGen;
      this._eiGen = eiGen;
      this._octGen = octGen;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this._out.Write(buffer, offset, count);
    }

    public override void WriteByte(byte value) => this._out.WriteByte(value);

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.DoClose();
      base.Dispose(disposing);
    }

    private void DoClose()
    {
      this._out.Dispose();
      this._octGen?.Dispose();
      this._eiGen.Dispose();
      this.outer.m_digests.Clear();
      if (this.outer._certs.Count > 0)
        CmsSignedDataStreamGenerator.CmsSignedDataOutputStream.WriteToGenerator((Asn1Generator) this._sigGen, (Asn1Encodable) new BerTaggedObject(false, 0, this.outer.UseDerForCerts ? (Asn1Encodable) CmsUtilities.CreateDerSetFromList((IEnumerable<Asn1Encodable>) this.outer._certs) : (Asn1Encodable) CmsUtilities.CreateBerSetFromList((IEnumerable<Asn1Encodable>) this.outer._certs)));
      if (this.outer._crls.Count > 0)
        CmsSignedDataStreamGenerator.CmsSignedDataOutputStream.WriteToGenerator((Asn1Generator) this._sigGen, (Asn1Encodable) new BerTaggedObject(false, 1, this.outer.UseDerForCrls ? (Asn1Encodable) CmsUtilities.CreateDerSetFromList((IEnumerable<Asn1Encodable>) this.outer._crls) : (Asn1Encodable) CmsUtilities.CreateBerSetFromList((IEnumerable<Asn1Encodable>) this.outer._crls)));
      foreach (KeyValuePair<string, IDigest> messageDigest in (IEnumerable<KeyValuePair<string, IDigest>>) this.outer.m_messageDigests)
        this.outer.m_messageHashes.Add(messageDigest.Key, DigestUtilities.DoFinal(messageDigest.Value));
      Asn1EncodableVector elementVector = new Asn1EncodableVector();
      foreach (CmsSignedDataStreamGenerator.DigestAndSignerInfoGeneratorHolder signerInf in (IEnumerable<CmsSignedDataStreamGenerator.DigestAndSignerInfoGeneratorHolder>) this.outer._signerInfs)
      {
        AlgorithmIdentifier digestAlgorithm = signerInf.DigestAlgorithm;
        byte[] messageHash = this.outer.m_messageHashes[CmsSignedDataStreamGenerator.Helper.GetDigestAlgName(signerInf.digestOID)];
        this.outer.m_digests[signerInf.digestOID] = (byte[]) messageHash.Clone();
        elementVector.Add((Asn1Encodable) signerInf.signerInf.Generate(this._contentOID, digestAlgorithm, messageHash));
      }
      foreach (SignerInformation signer in (IEnumerable<SignerInformation>) this.outer._signers)
        elementVector.Add((Asn1Encodable) signer.ToSignerInfo());
      CmsSignedDataStreamGenerator.CmsSignedDataOutputStream.WriteToGenerator((Asn1Generator) this._sigGen, (Asn1Encodable) new DerSet(elementVector));
      this._sigGen.Dispose();
      this._sGen.Dispose();
    }

    private static void WriteToGenerator(Asn1Generator ag, Asn1Encodable ae)
    {
      ae.EncodeTo(ag.GetRawOutputStream());
    }
  }
}
