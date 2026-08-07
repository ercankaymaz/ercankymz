// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.ServiceLocator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class ServiceLocator : Asn1Encodable
{
  private readonly X509Name issuer;
  private readonly Asn1Object locator;

  public static ServiceLocator GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return ServiceLocator.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static ServiceLocator GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ServiceLocator _:
        return (ServiceLocator) obj;
      case Asn1Sequence _:
        return new ServiceLocator((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public ServiceLocator(X509Name issuer)
    : this(issuer, (Asn1Object) null)
  {
  }

  public ServiceLocator(X509Name issuer, Asn1Object locator)
  {
    this.issuer = issuer != null ? issuer : throw new ArgumentNullException(nameof (issuer));
    this.locator = locator;
  }

  private ServiceLocator(Asn1Sequence seq)
  {
    this.issuer = X509Name.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    this.locator = seq[1].ToAsn1Object();
  }

  public X509Name Issuer => this.issuer;

  public Asn1Object Locator => this.locator;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.issuer);
    elementVector.AddOptional((Asn1Encodable) this.locator);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
