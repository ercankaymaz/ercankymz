// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.CompressedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class CompressedData : Asn1Encodable
{
  private DerInteger version;
  private AlgorithmIdentifier compressionAlgorithm;
  private ContentInfo encapContentInfo;

  public CompressedData(AlgorithmIdentifier compressionAlgorithm, ContentInfo encapContentInfo)
  {
    this.version = new DerInteger(0);
    this.compressionAlgorithm = compressionAlgorithm;
    this.encapContentInfo = encapContentInfo;
  }

  public CompressedData(Asn1Sequence seq)
  {
    this.version = (DerInteger) seq[0];
    this.compressionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.encapContentInfo = ContentInfo.GetInstance((object) seq[2]);
  }

  public static CompressedData GetInstance(Asn1TaggedObject ato, bool explicitly)
  {
    return CompressedData.GetInstance((object) Asn1Sequence.GetInstance(ato, explicitly));
  }

  public static CompressedData GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case CompressedData _:
        return (CompressedData) obj;
      case Asn1Sequence _:
        return new CompressedData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid CompressedData: " + Platform.GetTypeName(obj));
    }
  }

  public DerInteger Version => this.version;

  public AlgorithmIdentifier CompressionAlgorithmIdentifier => this.compressionAlgorithm;

  public ContentInfo EncapContentInfo => this.encapContentInfo;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new BerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.compressionAlgorithm,
      (Asn1Encodable) this.encapContentInfo
    });
  }
}
