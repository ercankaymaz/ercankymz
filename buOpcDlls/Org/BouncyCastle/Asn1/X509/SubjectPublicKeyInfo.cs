// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class SubjectPublicKeyInfo : Asn1Encodable
{
  private readonly AlgorithmIdentifier algID;
  private readonly DerBitString keyData;

  public static SubjectPublicKeyInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return SubjectPublicKeyInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static SubjectPublicKeyInfo GetInstance(object obj)
  {
    if (obj is SubjectPublicKeyInfo)
      return (SubjectPublicKeyInfo) obj;
    return obj != null ? new SubjectPublicKeyInfo(Asn1Sequence.GetInstance(obj)) : (SubjectPublicKeyInfo) null;
  }

  public SubjectPublicKeyInfo(AlgorithmIdentifier algID, Asn1Encodable publicKey)
  {
    this.keyData = new DerBitString(publicKey);
    this.algID = algID;
  }

  public SubjectPublicKeyInfo(AlgorithmIdentifier algID, byte[] publicKey)
  {
    this.keyData = new DerBitString(publicKey);
    this.algID = algID;
  }

  private SubjectPublicKeyInfo(Asn1Sequence seq)
  {
    this.algID = seq.Count == 2 ? AlgorithmIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.keyData = DerBitString.GetInstance((object) seq[1]);
  }

  public AlgorithmIdentifier AlgorithmID => this.algID;

  public Asn1Object ParsePublicKey() => Asn1Object.FromByteArray(this.keyData.GetOctets());

  public DerBitString PublicKeyData => this.keyData;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.algID, (Asn1Encodable) this.keyData);
  }
}
