// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.DigestInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class DigestInfo : Asn1Encodable
{
  private readonly byte[] digest;
  private readonly AlgorithmIdentifier algID;

  public static DigestInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return DigestInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static DigestInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case DigestInfo _:
        return (DigestInfo) obj;
      case Asn1Sequence _:
        return new DigestInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public DigestInfo(AlgorithmIdentifier algID, byte[] digest)
  {
    this.digest = digest;
    this.algID = algID;
  }

  private DigestInfo(Asn1Sequence seq)
  {
    this.algID = seq.Count == 2 ? AlgorithmIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.digest = Asn1OctetString.GetInstance((object) seq[1]).GetOctets();
  }

  public AlgorithmIdentifier AlgorithmID => this.algID;

  public byte[] GetDigest() => this.digest;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.algID, (Asn1Encodable) new DerOctetString(this.digest));
  }
}
