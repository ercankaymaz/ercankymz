// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.ContentInfoParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class ContentInfoParser
{
  private readonly DerObjectIdentifier m_contentType;
  private readonly Asn1TaggedObjectParser m_content;

  public ContentInfoParser(Asn1SequenceParser seq)
  {
    this.m_contentType = (DerObjectIdentifier) seq.ReadObject();
    this.m_content = (Asn1TaggedObjectParser) seq.ReadObject();
  }

  public DerObjectIdentifier ContentType => this.m_contentType;

  public IAsn1Convertible GetContent(int tag)
  {
    return this.m_content == null ? (IAsn1Convertible) null : Asn1Utilities.ParseExplicitContextBaseObject(this.m_content, 0);
  }
}
