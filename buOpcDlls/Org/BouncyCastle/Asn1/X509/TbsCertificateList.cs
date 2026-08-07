// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.TbsCertificateList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class TbsCertificateList : Asn1Encodable
{
  internal Asn1Sequence seq;
  internal DerInteger version;
  internal AlgorithmIdentifier signature;
  internal X509Name issuer;
  internal Time thisUpdate;
  internal Time nextUpdate;
  internal Asn1Sequence revokedCertificates;
  internal X509Extensions crlExtensions;

  public static TbsCertificateList GetInstance(object obj)
  {
    if (obj == null)
      return (TbsCertificateList) null;
    return obj is TbsCertificateList tbsCertificateList ? tbsCertificateList : new TbsCertificateList(Asn1Sequence.GetInstance(obj));
  }

  public static TbsCertificateList GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return TbsCertificateList.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  private TbsCertificateList(Asn1Sequence seq)
  {
    if (seq.Count < 3 || seq.Count > 7)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    int num1 = 0;
    this.seq = seq;
    if (seq[0] is DerInteger derInteger)
    {
      this.version = derInteger;
      ++num1;
    }
    else
      this.version = new DerInteger(0);
    Asn1Sequence asn1Sequence1 = seq;
    int index1 = num1;
    int num2 = index1 + 1;
    this.signature = AlgorithmIdentifier.GetInstance((object) asn1Sequence1[index1]);
    Asn1Sequence asn1Sequence2 = seq;
    int index2 = num2;
    int num3 = index2 + 1;
    this.issuer = X509Name.GetInstance((object) asn1Sequence2[index2]);
    Asn1Sequence asn1Sequence3 = seq;
    int index3 = num3;
    int index4 = index3 + 1;
    this.thisUpdate = Time.GetInstance((object) asn1Sequence3[index3]);
    if (index4 < seq.Count && (seq[index4] is Asn1UtcTime || seq[index4] is Asn1GeneralizedTime || seq[index4] is Time))
      this.nextUpdate = Time.GetInstance((object) seq[index4++]);
    if (index4 < seq.Count && !(seq[index4] is Asn1TaggedObject))
      this.revokedCertificates = Asn1Sequence.GetInstance((object) seq[index4++]);
    if (index4 >= seq.Count || !(seq[index4] is Asn1TaggedObject))
      return;
    this.crlExtensions = X509Extensions.GetInstance((object) seq[index4]);
  }

  public int Version => this.version.IntValueExact + 1;

  public DerInteger VersionNumber => this.version;

  public AlgorithmIdentifier Signature => this.signature;

  public X509Name Issuer => this.issuer;

  public Time ThisUpdate => this.thisUpdate;

  public Time NextUpdate => this.nextUpdate;

  public CrlEntry[] GetRevokedCertificates()
  {
    if (this.revokedCertificates == null)
      return new CrlEntry[0];
    CrlEntry[] revokedCertificates = new CrlEntry[this.revokedCertificates.Count];
    for (int index = 0; index < revokedCertificates.Length; ++index)
      revokedCertificates[index] = new CrlEntry(Asn1Sequence.GetInstance((object) this.revokedCertificates[index]));
    return revokedCertificates;
  }

  public IEnumerable<CrlEntry> GetRevokedCertificateEnumeration()
  {
    return this.revokedCertificates == null ? (IEnumerable<CrlEntry>) new List<CrlEntry>(0) : (IEnumerable<CrlEntry>) new TbsCertificateList.RevokedCertificatesEnumeration((IEnumerable<Asn1Encodable>) this.revokedCertificates);
  }

  public X509Extensions Extensions => this.crlExtensions;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.seq;

  private class RevokedCertificatesEnumeration : IEnumerable<CrlEntry>, IEnumerable
  {
    private readonly IEnumerable<Asn1Encodable> en;

    internal RevokedCertificatesEnumeration(IEnumerable<Asn1Encodable> en) => this.en = en;

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public IEnumerator<CrlEntry> GetEnumerator()
    {
      return (IEnumerator<CrlEntry>) new TbsCertificateList.RevokedCertificatesEnumeration.RevokedCertificatesEnumerator(this.en.GetEnumerator());
    }

    private sealed class RevokedCertificatesEnumerator : 
      IEnumerator<CrlEntry>,
      IDisposable,
      IEnumerator
    {
      private readonly IEnumerator<Asn1Encodable> e;

      internal RevokedCertificatesEnumerator(IEnumerator<Asn1Encodable> e) => this.e = e;

      public void Dispose()
      {
        this.e.Dispose();
        GC.SuppressFinalize((object) this);
      }

      public bool MoveNext() => this.e.MoveNext();

      public void Reset() => this.e.Reset();

      object IEnumerator.Current => (object) this.Current;

      public CrlEntry Current => new CrlEntry(Asn1Sequence.GetInstance((object) this.e.Current));
    }
  }
}
