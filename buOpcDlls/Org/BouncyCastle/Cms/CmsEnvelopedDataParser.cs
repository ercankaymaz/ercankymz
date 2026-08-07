// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsEnvelopedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsEnvelopedDataParser : CmsContentInfoParser
{
  internal RecipientInformationStore recipientInfoStore;
  internal EnvelopedDataParser envelopedData;
  private AlgorithmIdentifier _encAlg;
  private Org.BouncyCastle.Asn1.Cms.AttributeTable _unprotectedAttributes;
  private bool _attrNotRead;

  public CmsEnvelopedDataParser(byte[] envelopedData)
    : this((Stream) new MemoryStream(envelopedData, false))
  {
  }

  public CmsEnvelopedDataParser(Stream envelopedData)
    : base(envelopedData)
  {
    this._attrNotRead = true;
    this.envelopedData = new EnvelopedDataParser((Asn1SequenceParser) this.contentInfo.GetContent(16 /*0x10*/));
    Asn1Set instance = Asn1Set.GetInstance((object) this.envelopedData.GetRecipientInfos().ToAsn1Object());
    EncryptedContentInfoParser encryptedContentInfo = this.envelopedData.GetEncryptedContentInfo();
    this._encAlg = encryptedContentInfo.ContentEncryptionAlgorithm;
    CmsSecureReadable secureReadable = (CmsSecureReadable) new CmsEnvelopedHelper.CmsEnvelopedSecureReadable(this._encAlg, (CmsReadable) new CmsProcessableInputStream(((Asn1OctetStringParser) encryptedContentInfo.GetEncryptedContent(4)).GetOctetStream()));
    this.recipientInfoStore = CmsEnvelopedHelper.BuildRecipientInformationStore(instance, secureReadable);
  }

  public AlgorithmIdentifier EncryptionAlgorithmID => this._encAlg;

  public string EncryptionAlgOid => this._encAlg.Algorithm.Id;

  public Asn1Object EncryptionAlgParams => this._encAlg.Parameters?.ToAsn1Object();

  public RecipientInformationStore GetRecipientInfos() => this.recipientInfoStore;

  public Org.BouncyCastle.Asn1.Cms.AttributeTable GetUnprotectedAttributes()
  {
    if (this._unprotectedAttributes == null && this._attrNotRead)
    {
      Asn1SetParser unprotectedAttrs = this.envelopedData.GetUnprotectedAttrs();
      this._attrNotRead = false;
      if (unprotectedAttrs != null)
        this._unprotectedAttributes = CmsUtilities.ParseAttributeTable(unprotectedAttrs);
    }
    return this._unprotectedAttributes;
  }
}
