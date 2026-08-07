// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.Ocsp.CertHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.Ocsp;

public class CertHash : Asn1Encodable
{
  private readonly AlgorithmIdentifier hashAlgorithm;
  private readonly byte[] certificateHash;

  public static CertHash GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case CertHash _:
        return (CertHash) obj;
      case Asn1Sequence _:
        return new CertHash((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private CertHash(Asn1Sequence seq)
  {
    this.hashAlgorithm = seq.Count == 2 ? AlgorithmIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.certificateHash = Asn1OctetString.GetInstance((object) seq[1]).GetOctets();
  }

  public CertHash(AlgorithmIdentifier hashAlgorithm, byte[] certificateHash)
  {
    if (hashAlgorithm == null)
      throw new ArgumentNullException(nameof (hashAlgorithm));
    if (certificateHash == null)
      throw new ArgumentNullException(nameof (certificateHash));
    this.hashAlgorithm = hashAlgorithm;
    this.certificateHash = (byte[]) certificateHash.Clone();
  }

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public byte[] CertificateHash => (byte[]) this.certificateHash.Clone();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.hashAlgorithm, (Asn1Encodable) new DerOctetString(this.certificateHash));
  }
}
