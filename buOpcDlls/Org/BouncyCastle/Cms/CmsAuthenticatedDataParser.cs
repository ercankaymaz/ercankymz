// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsAuthenticatedDataParser
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

public class CmsAuthenticatedDataParser : CmsContentInfoParser
{
  internal RecipientInformationStore _recipientInfoStore;
  internal AuthenticatedDataParser authData;
  private AlgorithmIdentifier macAlg;
  private byte[] mac;
  private Org.BouncyCastle.Asn1.Cms.AttributeTable authAttrs;
  private Org.BouncyCastle.Asn1.Cms.AttributeTable unauthAttrs;
  private bool authAttrNotRead;
  private bool unauthAttrNotRead;

  public CmsAuthenticatedDataParser(byte[] envelopedData)
    : this((Stream) new MemoryStream(envelopedData, false))
  {
  }

  public CmsAuthenticatedDataParser(Stream envelopedData)
    : base(envelopedData)
  {
    this.authAttrNotRead = true;
    this.authData = new AuthenticatedDataParser((Asn1SequenceParser) this.contentInfo.GetContent(16 /*0x10*/));
    Asn1Set instance = Asn1Set.GetInstance((object) this.authData.GetRecipientInfos().ToAsn1Object());
    this.macAlg = this.authData.GetMacAlgorithm();
    CmsSecureReadable secureReadable = (CmsSecureReadable) new CmsEnvelopedHelper.CmsAuthenticatedSecureReadable(this.macAlg, (CmsReadable) new CmsProcessableInputStream(((Asn1OctetStringParser) this.authData.GetEnapsulatedContentInfo().GetContent(4)).GetOctetStream()));
    this._recipientInfoStore = CmsEnvelopedHelper.BuildRecipientInformationStore(instance, secureReadable);
  }

  public AlgorithmIdentifier MacAlgorithmID => this.macAlg;

  public string MacAlgOid => this.macAlg.Algorithm.Id;

  public Asn1Object MacAlgParams => this.macAlg.Parameters?.ToAsn1Object();

  public RecipientInformationStore GetRecipientInfos() => this._recipientInfoStore;

  public byte[] GetMac()
  {
    if (this.mac == null)
    {
      this.GetAuthAttrs();
      this.mac = this.authData.GetMac().GetOctets();
    }
    return Arrays.Clone(this.mac);
  }

  public Org.BouncyCastle.Asn1.Cms.AttributeTable GetAuthAttrs()
  {
    if (this.authAttrs == null && this.authAttrNotRead)
    {
      Asn1SetParser authAttrs = this.authData.GetAuthAttrs();
      this.authAttrNotRead = false;
      if (authAttrs != null)
        this.authAttrs = CmsUtilities.ParseAttributeTable(authAttrs);
    }
    return this.authAttrs;
  }

  public Org.BouncyCastle.Asn1.Cms.AttributeTable GetUnauthAttrs()
  {
    if (this.unauthAttrs == null && this.unauthAttrNotRead)
    {
      Asn1SetParser unauthAttrs = this.authData.GetUnauthAttrs();
      this.unauthAttrNotRead = false;
      if (unauthAttrs != null)
        this.unauthAttrs = CmsUtilities.ParseAttributeTable(unauthAttrs);
    }
    return this.unauthAttrs;
  }
}
