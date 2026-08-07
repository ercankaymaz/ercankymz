// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CrlValidatedID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CrlValidatedID : Asn1Encodable
{
  private readonly OtherHash crlHash;
  private readonly CrlIdentifier crlIdentifier;

  public static CrlValidatedID GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case CrlValidatedID _:
        return (CrlValidatedID) obj;
      case Asn1Sequence _:
        return new CrlValidatedID((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'CrlValidatedID' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private CrlValidatedID(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.crlHash = seq.Count >= 1 && seq.Count <= 2 ? OtherHash.GetInstance((object) seq[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    if (seq.Count <= 1)
      return;
    this.crlIdentifier = CrlIdentifier.GetInstance((object) seq[1].ToAsn1Object());
  }

  public CrlValidatedID(OtherHash crlHash)
    : this(crlHash, (CrlIdentifier) null)
  {
  }

  public CrlValidatedID(OtherHash crlHash, CrlIdentifier crlIdentifier)
  {
    this.crlHash = crlHash != null ? crlHash : throw new ArgumentNullException(nameof (crlHash));
    this.crlIdentifier = crlIdentifier;
  }

  public OtherHash CrlHash => this.crlHash;

  public CrlIdentifier CrlIdentifier => this.crlIdentifier;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.crlHash.ToAsn1Object());
    if (this.crlIdentifier != null)
      elementVector.Add((Asn1Encodable) this.crlIdentifier.ToAsn1Object());
    return (Asn1Object) new DerSequence(elementVector);
  }
}
