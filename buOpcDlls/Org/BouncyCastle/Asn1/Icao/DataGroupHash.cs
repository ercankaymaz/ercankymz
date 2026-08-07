// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Icao.DataGroupHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Icao;

public class DataGroupHash : Asn1Encodable
{
  private readonly DerInteger dataGroupNumber;
  private readonly Asn1OctetString dataGroupHashValue;

  public static DataGroupHash GetInstance(object obj)
  {
    if (obj is DataGroupHash)
      return (DataGroupHash) obj;
    return obj != null ? new DataGroupHash(Asn1Sequence.GetInstance(obj)) : (DataGroupHash) null;
  }

  private DataGroupHash(Asn1Sequence seq)
  {
    this.dataGroupNumber = seq.Count == 2 ? DerInteger.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.dataGroupHashValue = Asn1OctetString.GetInstance((object) seq[1]);
  }

  public DataGroupHash(int dataGroupNumber, Asn1OctetString dataGroupHashValue)
  {
    this.dataGroupNumber = new DerInteger(dataGroupNumber);
    this.dataGroupHashValue = dataGroupHashValue;
  }

  public int DataGroupNumber => this.dataGroupNumber.IntValueExact;

  public Asn1OctetString DataGroupHashValue => this.dataGroupHashValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.dataGroupNumber, (Asn1Encodable) this.dataGroupHashValue);
  }
}
