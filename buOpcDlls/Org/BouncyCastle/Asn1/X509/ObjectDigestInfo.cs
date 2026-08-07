// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.ObjectDigestInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class ObjectDigestInfo : Asn1Encodable
{
  public const int PublicKey = 0;
  public const int PublicKeyCert = 1;
  public const int OtherObjectDigest = 2;
  internal readonly DerEnumerated digestedObjectType;
  internal readonly DerObjectIdentifier otherObjectTypeID;
  internal readonly AlgorithmIdentifier digestAlgorithm;
  internal readonly DerBitString objectDigest;

  public static ObjectDigestInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ObjectDigestInfo _:
        return (ObjectDigestInfo) obj;
      case Asn1Sequence _:
        return new ObjectDigestInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static ObjectDigestInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return ObjectDigestInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public ObjectDigestInfo(
    int digestedObjectType,
    string otherObjectTypeID,
    AlgorithmIdentifier digestAlgorithm,
    byte[] objectDigest)
  {
    this.digestedObjectType = new DerEnumerated(digestedObjectType);
    if (digestedObjectType == 2)
      this.otherObjectTypeID = new DerObjectIdentifier(otherObjectTypeID);
    this.digestAlgorithm = digestAlgorithm;
    this.objectDigest = new DerBitString(objectDigest);
  }

  private ObjectDigestInfo(Asn1Sequence seq)
  {
    this.digestedObjectType = seq.Count <= 4 && seq.Count >= 3 ? DerEnumerated.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    int num = 0;
    if (seq.Count == 4)
    {
      this.otherObjectTypeID = DerObjectIdentifier.GetInstance((object) seq[1]);
      ++num;
    }
    this.digestAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[1 + num]);
    this.objectDigest = DerBitString.GetInstance((object) seq[2 + num]);
  }

  public DerEnumerated DigestedObjectType => this.digestedObjectType;

  public DerObjectIdentifier OtherObjectTypeID => this.otherObjectTypeID;

  public AlgorithmIdentifier DigestAlgorithm => this.digestAlgorithm;

  public DerBitString ObjectDigest => this.objectDigest;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.digestedObjectType);
    elementVector.AddOptional((Asn1Encodable) this.otherObjectTypeID);
    elementVector.Add((Asn1Encodable) this.digestAlgorithm, (Asn1Encodable) this.objectDigest);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
