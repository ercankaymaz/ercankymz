// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.PKMacValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class PKMacValue : Asn1Encodable
{
  private readonly AlgorithmIdentifier algID;
  private readonly DerBitString macValue;

  private PKMacValue(Asn1Sequence seq)
  {
    this.algID = AlgorithmIdentifier.GetInstance((object) seq[0]);
    this.macValue = DerBitString.GetInstance((object) seq[1]);
  }

  public static PKMacValue GetInstance(object obj)
  {
    switch (obj)
    {
      case PKMacValue _:
        return (PKMacValue) obj;
      case Asn1Sequence _:
        return new PKMacValue((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static PKMacValue GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return PKMacValue.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public PKMacValue(PbmParameter pbmParams, DerBitString macValue)
    : this(new AlgorithmIdentifier(CmpObjectIdentifiers.passwordBasedMac, (Asn1Encodable) pbmParams), macValue)
  {
  }

  public PKMacValue(AlgorithmIdentifier algID, DerBitString macValue)
  {
    this.algID = algID;
    this.macValue = macValue;
  }

  public virtual AlgorithmIdentifier AlgID => this.algID;

  public virtual DerBitString MacValue => this.macValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.algID, (Asn1Encodable) this.macValue);
  }
}
