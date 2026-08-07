// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.EncryptedContentInfoParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class EncryptedContentInfoParser
{
  private readonly DerObjectIdentifier m_contentType;
  private readonly AlgorithmIdentifier m_contentEncryptionAlgorithm;
  private readonly Asn1TaggedObjectParser m_encryptedContent;

  public EncryptedContentInfoParser(Asn1SequenceParser seq)
  {
    this.m_contentType = (DerObjectIdentifier) seq.ReadObject();
    this.m_contentEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq.ReadObject().ToAsn1Object());
    this.m_encryptedContent = (Asn1TaggedObjectParser) seq.ReadObject();
  }

  public DerObjectIdentifier ContentType => this.m_contentType;

  public AlgorithmIdentifier ContentEncryptionAlgorithm => this.m_contentEncryptionAlgorithm;

  public IAsn1Convertible GetEncryptedContent(int tag)
  {
    return Asn1Utilities.ParseContextBaseUniversal(this.m_encryptedContent, 0, false, tag);
  }
}
