// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.Request
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class Request : Asn1Encodable
{
  private readonly CertID reqCert;
  private readonly X509Extensions singleRequestExtensions;

  public static Request GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return Request.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static Request GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Request _:
        return (Request) obj;
      case Asn1Sequence _:
        return new Request((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public Request(CertID reqCert, X509Extensions singleRequestExtensions)
  {
    this.reqCert = reqCert != null ? reqCert : throw new ArgumentNullException(nameof (reqCert));
    this.singleRequestExtensions = singleRequestExtensions;
  }

  private Request(Asn1Sequence seq)
  {
    this.reqCert = CertID.GetInstance((object) seq[0]);
    if (seq.Count != 2)
      return;
    this.singleRequestExtensions = X509Extensions.GetInstance((Asn1TaggedObject) seq[1], true);
  }

  public CertID ReqCert => this.reqCert;

  public X509Extensions SingleRequestExtensions => this.singleRequestExtensions;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.reqCert);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.singleRequestExtensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
