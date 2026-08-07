// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.KeySpecificInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class KeySpecificInfo : Asn1Encodable
{
  private DerObjectIdentifier algorithm;
  private Asn1OctetString counter;

  public KeySpecificInfo(DerObjectIdentifier algorithm, Asn1OctetString counter)
  {
    this.algorithm = algorithm;
    this.counter = counter;
  }

  public KeySpecificInfo(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.algorithm = (DerObjectIdentifier) enumerator.Current;
    enumerator.MoveNext();
    this.counter = (Asn1OctetString) enumerator.Current;
  }

  public DerObjectIdentifier Algorithm => this.algorithm;

  public Asn1OctetString Counter => this.counter;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.algorithm, (Asn1Encodable) this.counter);
  }
}
