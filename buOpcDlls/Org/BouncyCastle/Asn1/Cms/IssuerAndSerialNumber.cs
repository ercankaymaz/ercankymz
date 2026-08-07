// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.IssuerAndSerialNumber
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class IssuerAndSerialNumber : Asn1Encodable
{
  private X509Name name;
  private DerInteger serialNumber;

  public static IssuerAndSerialNumber GetInstance(object obj)
  {
    if (obj == null)
      return (IssuerAndSerialNumber) null;
    return obj is IssuerAndSerialNumber issuerAndSerialNumber ? issuerAndSerialNumber : new IssuerAndSerialNumber(Asn1Sequence.GetInstance(obj));
  }

  private IssuerAndSerialNumber(Asn1Sequence seq)
  {
    this.name = X509Name.GetInstance((object) seq[0]);
    this.serialNumber = (DerInteger) seq[1];
  }

  public IssuerAndSerialNumber(X509Name name, BigInteger serialNumber)
  {
    this.name = name;
    this.serialNumber = new DerInteger(serialNumber);
  }

  public IssuerAndSerialNumber(X509Name name, DerInteger serialNumber)
  {
    this.name = name;
    this.serialNumber = serialNumber;
  }

  public X509Name Name => this.name;

  public DerInteger SerialNumber => this.serialNumber;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.name, (Asn1Encodable) this.serialNumber);
  }
}
