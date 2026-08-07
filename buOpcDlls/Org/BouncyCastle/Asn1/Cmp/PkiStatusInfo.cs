// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiStatusInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiStatusInfo : Asn1Encodable
{
  private readonly DerInteger status;
  private readonly PkiFreeText statusString;
  private readonly DerBitString failInfo;

  public static PkiStatusInfo GetInstance(object obj)
  {
    if (obj == null)
      return (PkiStatusInfo) null;
    return obj is PkiStatusInfo pkiStatusInfo ? pkiStatusInfo : new PkiStatusInfo(Asn1Sequence.GetInstance(obj));
  }

  public static PkiStatusInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return PkiStatusInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  [Obsolete("Use 'GetInstance' instead")]
  public PkiStatusInfo(Asn1Sequence seq)
  {
    this.status = DerInteger.GetInstance((object) seq[0]);
    this.statusString = (PkiFreeText) null;
    this.failInfo = (DerBitString) null;
    if (seq.Count > 2)
    {
      this.statusString = PkiFreeText.GetInstance((object) seq[1]);
      this.failInfo = DerBitString.GetInstance((object) seq[2]);
    }
    else
    {
      if (seq.Count <= 1)
        return;
      object obj = (object) seq[1];
      if (obj is DerBitString)
        this.failInfo = DerBitString.GetInstance(obj);
      else
        this.statusString = PkiFreeText.GetInstance(obj);
    }
  }

  public PkiStatusInfo(int status) => this.status = new DerInteger(status);

  public PkiStatusInfo(int status, PkiFreeText statusString)
  {
    this.status = new DerInteger(status);
    this.statusString = statusString;
  }

  public PkiStatusInfo(int status, PkiFreeText statusString, PkiFailureInfo failInfo)
  {
    this.status = new DerInteger(status);
    this.statusString = statusString;
    this.failInfo = (DerBitString) failInfo;
  }

  public BigInteger Status => this.status.Value;

  public PkiFreeText StatusString => this.statusString;

  public DerBitString FailInfo => this.failInfo;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.status);
    elementVector.AddOptional((Asn1Encodable) this.statusString, (Asn1Encodable) this.failInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
