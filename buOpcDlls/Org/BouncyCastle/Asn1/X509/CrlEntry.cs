// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.CrlEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class CrlEntry : Asn1Encodable
{
  internal Asn1Sequence seq;
  internal DerInteger userCertificate;
  internal Time revocationDate;
  internal X509Extensions crlEntryExtensions;

  public CrlEntry(Asn1Sequence seq)
  {
    this.seq = seq.Count >= 2 && seq.Count <= 3 ? seq : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.userCertificate = DerInteger.GetInstance((object) seq[0]);
    this.revocationDate = Time.GetInstance((object) seq[1]);
  }

  public DerInteger UserCertificate => this.userCertificate;

  public Time RevocationDate => this.revocationDate;

  public X509Extensions Extensions
  {
    get
    {
      if (this.crlEntryExtensions == null && this.seq.Count == 3)
        this.crlEntryExtensions = X509Extensions.GetInstance((object) this.seq[2]);
      return this.crlEntryExtensions;
    }
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.seq;
}
