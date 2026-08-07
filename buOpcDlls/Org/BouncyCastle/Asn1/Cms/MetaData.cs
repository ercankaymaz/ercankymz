// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.MetaData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class MetaData : Asn1Encodable
{
  private DerBoolean hashProtected;
  private DerUtf8String fileName;
  private DerIA5String mediaType;
  private Attributes otherMetaData;

  public MetaData(
    DerBoolean hashProtected,
    DerUtf8String fileName,
    DerIA5String mediaType,
    Attributes otherMetaData)
  {
    this.hashProtected = hashProtected;
    this.fileName = fileName;
    this.mediaType = mediaType;
    this.otherMetaData = otherMetaData;
  }

  private MetaData(Asn1Sequence seq)
  {
    this.hashProtected = DerBoolean.GetInstance((object) seq[0]);
    int index1 = 1;
    if (1 < seq.Count && seq[index1] is DerUtf8String derUtf8String)
    {
      this.fileName = derUtf8String;
      ++index1;
    }
    if (index1 < seq.Count && seq[index1] is DerIA5String derIa5String)
    {
      this.mediaType = derIa5String;
      ++index1;
    }
    if (index1 >= seq.Count)
      return;
    Asn1Sequence asn1Sequence = seq;
    int index2 = index1;
    int num = index2 + 1;
    this.otherMetaData = Attributes.GetInstance((object) asn1Sequence[index2]);
  }

  public static MetaData GetInstance(object obj)
  {
    if (obj is MetaData)
      return (MetaData) obj;
    return obj != null ? new MetaData(Asn1Sequence.GetInstance(obj)) : (MetaData) null;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.hashProtected);
    elementVector.AddOptional((Asn1Encodable) this.fileName, (Asn1Encodable) this.mediaType, (Asn1Encodable) this.otherMetaData);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public virtual bool IsHashProtected => this.hashProtected.IsTrue;

  public virtual DerUtf8String FileName => this.fileName;

  public virtual DerIA5String MediaType => this.mediaType;

  public virtual Attributes OtherMetaData => this.otherMetaData;
}
