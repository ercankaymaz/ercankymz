// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsAuthenticatedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsAuthenticatedData
{
  internal RecipientInformationStore recipientInfoStore;
  internal ContentInfo contentInfo;
  private AlgorithmIdentifier macAlg;
  private Asn1Set authAttrs;
  private Asn1Set unauthAttrs;
  private byte[] mac;

  public CmsAuthenticatedData(byte[] authData)
    : this(CmsUtilities.ReadContentInfo(authData))
  {
  }

  public CmsAuthenticatedData(Stream authData)
    : this(CmsUtilities.ReadContentInfo(authData))
  {
  }

  public CmsAuthenticatedData(ContentInfo contentInfo)
  {
    this.contentInfo = contentInfo;
    AuthenticatedData instance = AuthenticatedData.GetInstance((object) contentInfo.Content);
    Asn1Set recipientInfos = instance.RecipientInfos;
    this.macAlg = instance.MacAlgorithm;
    CmsSecureReadable secureReadable = (CmsSecureReadable) new CmsEnvelopedHelper.CmsAuthenticatedSecureReadable(this.macAlg, (CmsReadable) new CmsProcessableByteArray(Asn1OctetString.GetInstance((object) instance.EncapsulatedContentInfo.Content).GetOctets()));
    this.recipientInfoStore = CmsEnvelopedHelper.BuildRecipientInformationStore(recipientInfos, secureReadable);
    this.authAttrs = instance.AuthAttrs;
    this.mac = instance.Mac.GetOctets();
    this.unauthAttrs = instance.UnauthAttrs;
  }

  public byte[] GetMac() => Arrays.Clone(this.mac);

  public AlgorithmIdentifier MacAlgorithmID => this.macAlg;

  public string MacAlgOid => this.macAlg.Algorithm.Id;

  public RecipientInformationStore GetRecipientInfos() => this.recipientInfoStore;

  public ContentInfo ContentInfo => this.contentInfo;

  public Org.BouncyCastle.Asn1.Cms.AttributeTable GetAuthAttrs()
  {
    return this.authAttrs == null ? (Org.BouncyCastle.Asn1.Cms.AttributeTable) null : new Org.BouncyCastle.Asn1.Cms.AttributeTable(this.authAttrs);
  }

  public Org.BouncyCastle.Asn1.Cms.AttributeTable GetUnauthAttrs()
  {
    return this.unauthAttrs == null ? (Org.BouncyCastle.Asn1.Cms.AttributeTable) null : new Org.BouncyCastle.Asn1.Cms.AttributeTable(this.unauthAttrs);
  }

  public byte[] GetEncoded() => this.contentInfo.GetEncoded();
}
