// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Icao.CscaMasterList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Icao;

public class CscaMasterList : Asn1Encodable
{
  private DerInteger version = new DerInteger(0);
  private X509CertificateStructure[] certList;

  public static CscaMasterList GetInstance(object obj)
  {
    if (obj is CscaMasterList)
      return (CscaMasterList) obj;
    return obj != null ? new CscaMasterList(Asn1Sequence.GetInstance(obj)) : (CscaMasterList) null;
  }

  private CscaMasterList(Asn1Sequence seq)
  {
    if (seq == null || seq.Count == 0)
      throw new ArgumentException("null or empty sequence passed.");
    this.version = seq.Count == 2 ? DerInteger.GetInstance((object) seq[0]) : throw new ArgumentException("Incorrect sequence size: " + seq.Count.ToString());
    Asn1Set instance = Asn1Set.GetInstance((object) seq[1]);
    this.certList = new X509CertificateStructure[instance.Count];
    for (int index = 0; index < this.certList.Length; ++index)
      this.certList[index] = X509CertificateStructure.GetInstance((object) instance[index]);
  }

  public CscaMasterList(X509CertificateStructure[] certStructs)
  {
    this.certList = CscaMasterList.CopyCertList(certStructs);
  }

  public virtual int Version => this.version.IntValueExact;

  public X509CertificateStructure[] GetCertStructs() => CscaMasterList.CopyCertList(this.certList);

  private static X509CertificateStructure[] CopyCertList(X509CertificateStructure[] orig)
  {
    return (X509CertificateStructure[]) orig.Clone();
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.version, (Asn1Encodable) new DerSet((Asn1Encodable[]) this.certList));
  }
}
