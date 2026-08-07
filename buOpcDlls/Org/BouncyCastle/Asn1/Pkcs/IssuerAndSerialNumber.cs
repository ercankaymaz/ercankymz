// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.IssuerAndSerialNumber
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class IssuerAndSerialNumber : Asn1Encodable
{
  private readonly X509Name name;
  private readonly DerInteger certSerialNumber;

  public static IssuerAndSerialNumber GetInstance(object obj)
  {
    switch (obj)
    {
      case IssuerAndSerialNumber _:
        return (IssuerAndSerialNumber) obj;
      case Asn1Sequence _:
        return new IssuerAndSerialNumber((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private IssuerAndSerialNumber(Asn1Sequence seq)
  {
    this.name = seq.Count == 2 ? X509Name.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.certSerialNumber = DerInteger.GetInstance((object) seq[1]);
  }

  public IssuerAndSerialNumber(X509Name name, BigInteger certSerialNumber)
  {
    this.name = name;
    this.certSerialNumber = new DerInteger(certSerialNumber);
  }

  public IssuerAndSerialNumber(X509Name name, DerInteger certSerialNumber)
  {
    this.name = name;
    this.certSerialNumber = certSerialNumber;
  }

  public X509Name Name => this.name;

  public DerInteger CertificateSerialNumber => this.certSerialNumber;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.name, (Asn1Encodable) this.certSerialNumber);
  }
}
