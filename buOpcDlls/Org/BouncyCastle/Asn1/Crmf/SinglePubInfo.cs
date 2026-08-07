// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.SinglePubInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class SinglePubInfo : Asn1Encodable
{
  private readonly DerInteger pubMethod;
  private readonly GeneralName pubLocation;

  private SinglePubInfo(Asn1Sequence seq)
  {
    this.pubMethod = DerInteger.GetInstance((object) seq[0]);
    if (seq.Count != 2)
      return;
    this.pubLocation = GeneralName.GetInstance((object) seq[1]);
  }

  public static SinglePubInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case SinglePubInfo _:
        return (SinglePubInfo) obj;
      case Asn1Sequence _:
        return new SinglePubInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public virtual GeneralName PubLocation => this.pubLocation;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.pubMethod);
    elementVector.AddOptional((Asn1Encodable) this.pubLocation);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
