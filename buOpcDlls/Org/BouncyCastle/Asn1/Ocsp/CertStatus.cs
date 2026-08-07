// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.CertStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class CertStatus : Asn1Encodable, IAsn1Choice
{
  private readonly int tagNo;
  private readonly Asn1Encodable value;

  public CertStatus()
  {
    this.tagNo = 0;
    this.value = (Asn1Encodable) DerNull.Instance;
  }

  public CertStatus(RevokedInfo info)
  {
    this.tagNo = 1;
    this.value = (Asn1Encodable) info;
  }

  public CertStatus(int tagNo, Asn1Encodable value)
  {
    this.tagNo = tagNo;
    this.value = value;
  }

  public CertStatus(Asn1TaggedObject choice)
  {
    this.tagNo = choice.TagNo;
    switch (choice.TagNo)
    {
      case 0:
        this.value = (Asn1Encodable) Asn1Null.GetInstance(choice, false);
        break;
      case 1:
        this.value = (Asn1Encodable) RevokedInfo.GetInstance(choice, false);
        break;
      case 2:
        this.value = (Asn1Encodable) Asn1Null.GetInstance(choice, false);
        break;
      default:
        throw new ArgumentException("Unknown tag encountered: " + Asn1Utilities.GetTagText(choice));
    }
  }

  public static CertStatus GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case CertStatus _:
        return (CertStatus) obj;
      case Asn1TaggedObject _:
        return new CertStatus((Asn1TaggedObject) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public int TagNo => this.tagNo;

  public Asn1Encodable Status => this.value;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerTaggedObject(false, this.tagNo, this.value);
  }
}
