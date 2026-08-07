// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsEnvelopedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsEnvelopedData
{
  internal RecipientInformationStore recipientInfoStore;
  internal ContentInfo contentInfo;
  private AlgorithmIdentifier encAlg;
  private Asn1Set unprotectedAttributes;

  public CmsEnvelopedData(byte[] envelopedData)
    : this(CmsUtilities.ReadContentInfo(envelopedData))
  {
  }

  public CmsEnvelopedData(Stream envelopedData)
    : this(CmsUtilities.ReadContentInfo(envelopedData))
  {
  }

  public CmsEnvelopedData(ContentInfo contentInfo)
  {
    this.contentInfo = contentInfo;
    EnvelopedData instance = EnvelopedData.GetInstance((object) contentInfo.Content);
    Asn1Set recipientInfos = instance.RecipientInfos;
    EncryptedContentInfo encryptedContentInfo = instance.EncryptedContentInfo;
    this.encAlg = encryptedContentInfo.ContentEncryptionAlgorithm;
    CmsSecureReadable secureReadable = (CmsSecureReadable) new CmsEnvelopedHelper.CmsEnvelopedSecureReadable(this.encAlg, (CmsReadable) new CmsProcessableByteArray(encryptedContentInfo.EncryptedContent.GetOctets()));
    this.recipientInfoStore = CmsEnvelopedHelper.BuildRecipientInformationStore(recipientInfos, secureReadable);
    this.unprotectedAttributes = instance.UnprotectedAttrs;
  }

  public AlgorithmIdentifier EncryptionAlgorithmID => this.encAlg;

  public string EncryptionAlgOid => this.encAlg.Algorithm.Id;

  public RecipientInformationStore GetRecipientInfos() => this.recipientInfoStore;

  public ContentInfo ContentInfo => this.contentInfo;

  public Org.BouncyCastle.Asn1.Cms.AttributeTable GetUnprotectedAttributes()
  {
    return this.unprotectedAttributes == null ? (Org.BouncyCastle.Asn1.Cms.AttributeTable) null : new Org.BouncyCastle.Asn1.Cms.AttributeTable(this.unprotectedAttributes);
  }

  public byte[] GetEncoded() => this.contentInfo.GetEncoded();
}
