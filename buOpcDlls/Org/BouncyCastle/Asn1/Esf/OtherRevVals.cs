// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.OtherRevVals
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class OtherRevVals : Asn1Encodable
{
  private readonly DerObjectIdentifier otherRevValType;
  private readonly Asn1Object otherRevVals;

  public static OtherRevVals GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OtherRevVals _:
        return (OtherRevVals) obj;
      case Asn1Sequence _:
        return new OtherRevVals((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'OtherRevVals' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private OtherRevVals(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.otherRevValType = seq.Count == 2 ? (DerObjectIdentifier) seq[0].ToAsn1Object() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.otherRevVals = seq[1].ToAsn1Object();
  }

  public OtherRevVals(DerObjectIdentifier otherRevValType, Asn1Encodable otherRevVals)
  {
    if (otherRevValType == null)
      throw new ArgumentNullException(nameof (otherRevValType));
    if (otherRevVals == null)
      throw new ArgumentNullException(nameof (otherRevVals));
    this.otherRevValType = otherRevValType;
    this.otherRevVals = otherRevVals.ToAsn1Object();
  }

  public DerObjectIdentifier OtherRevValType => this.otherRevValType;

  public Asn1Object OtherRevValsObject => this.otherRevVals;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.otherRevValType, (Asn1Encodable) this.otherRevVals);
  }
}
