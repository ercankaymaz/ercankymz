// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OcspResponsesID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OcspResponsesID : Asn1Encodable
{
  private readonly OcspIdentifier ocspIdentifier;
  private readonly OtherHash ocspRepHash;

  public static OcspResponsesID GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OcspResponsesID _:
        return (OcspResponsesID) obj;
      case Asn1Sequence _:
        return new OcspResponsesID((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'OcspResponsesID' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OcspResponsesID(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.ocspIdentifier = seq.Count >= 1 && seq.Count <= 2 ? OcspIdentifier.GetInstance((object) seq[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    if (seq.Count <= 1)
      return;
    this.ocspRepHash = OtherHash.GetInstance((object) seq[1].ToAsn1Object());
  }

  public OcspResponsesID(OcspIdentifier ocspIdentifier)
    : this(ocspIdentifier, (OtherHash) null)
  {
  }

  public OcspResponsesID(OcspIdentifier ocspIdentifier, OtherHash ocspRepHash)
  {
    this.ocspIdentifier = ocspIdentifier != null ? ocspIdentifier : throw new ArgumentNullException(nameof (ocspIdentifier));
    this.ocspRepHash = ocspRepHash;
  }

  public OcspIdentifier OcspIdentifier => this.ocspIdentifier;

  public OtherHash OcspRepHash => this.ocspRepHash;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.ocspIdentifier.ToAsn1Object());
    if (this.ocspRepHash != null)
      elementVector.Add((Asn1Encodable) this.ocspRepHash.ToAsn1Object());
    return (Asn1Object) new DerSequence(elementVector);
  }
}
