// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.OriginatorPublicKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class OriginatorPublicKey : Asn1Encodable
{
  private readonly AlgorithmIdentifier mAlgorithm;
  private readonly DerBitString mPublicKey;

  public OriginatorPublicKey(AlgorithmIdentifier algorithm, byte[] publicKey)
  {
    this.mAlgorithm = algorithm;
    this.mPublicKey = new DerBitString(publicKey);
  }

  private OriginatorPublicKey(Asn1Sequence seq)
  {
    this.mAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[0]);
    this.mPublicKey = DerBitString.GetInstance((object) seq[1]);
  }

  public static OriginatorPublicKey GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return OriginatorPublicKey.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static OriginatorPublicKey GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OriginatorPublicKey _:
        return (OriginatorPublicKey) obj;
      case Asn1Sequence _:
        return new OriginatorPublicKey(Asn1Sequence.GetInstance(obj));
      default:
        throw new ArgumentException("Invalid OriginatorPublicKey: " + Platform.GetTypeName(obj));
    }
  }

  public AlgorithmIdentifier Algorithm => this.mAlgorithm;

  public DerBitString PublicKey => this.mPublicKey;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.mAlgorithm, (Asn1Encodable) this.mPublicKey);
  }
}
