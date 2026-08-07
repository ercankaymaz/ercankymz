// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.CompressedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class CompressedDataParser
{
  private DerInteger _version;
  private AlgorithmIdentifier _compressionAlgorithm;
  private ContentInfoParser _encapContentInfo;

  public CompressedDataParser(Asn1SequenceParser seq)
  {
    this._version = (DerInteger) seq.ReadObject();
    this._compressionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq.ReadObject().ToAsn1Object());
    this._encapContentInfo = new ContentInfoParser((Asn1SequenceParser) seq.ReadObject());
  }

  public DerInteger Version => this._version;

  public AlgorithmIdentifier CompressionAlgorithmIdentifier => this._compressionAlgorithm;

  public ContentInfoParser GetEncapContentInfo() => this._encapContentInfo;
}
