// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.ProofOfPossession
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class ProofOfPossession : Asn1Encodable, IAsn1Choice
{
  public const int TYPE_RA_VERIFIED = 0;
  public const int TYPE_SIGNING_KEY = 1;
  public const int TYPE_KEY_ENCIPHERMENT = 2;
  public const int TYPE_KEY_AGREEMENT = 3;
  private readonly int tagNo;
  private readonly Asn1Encodable obj;

  private ProofOfPossession(Asn1TaggedObject tagged)
  {
    this.tagNo = tagged.TagNo;
    switch (this.tagNo)
    {
      case 0:
        this.obj = (Asn1Encodable) DerNull.Instance;
        break;
      case 1:
        this.obj = (Asn1Encodable) PopoSigningKey.GetInstance(tagged, false);
        break;
      case 2:
      case 3:
        this.obj = (Asn1Encodable) PopoPrivKey.GetInstance(tagged, true);
        break;
      default:
        throw new ArgumentException("unknown tag: " + this.tagNo.ToString(), nameof (tagged));
    }
  }

  public static ProofOfPossession GetInstance(object obj)
  {
    switch (obj)
    {
      case ProofOfPossession _:
        return (ProofOfPossession) obj;
      case Asn1TaggedObject _:
        return new ProofOfPossession((Asn1TaggedObject) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public ProofOfPossession()
  {
    this.tagNo = 0;
    this.obj = (Asn1Encodable) DerNull.Instance;
  }

  public ProofOfPossession(PopoSigningKey Poposk)
  {
    this.tagNo = 1;
    this.obj = (Asn1Encodable) Poposk;
  }

  public ProofOfPossession(int type, PopoPrivKey privkey)
  {
    this.tagNo = type;
    this.obj = (Asn1Encodable) privkey;
  }

  public virtual int Type => this.tagNo;

  public virtual Asn1Encodable Object => this.obj;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerTaggedObject(false, this.tagNo, this.obj);
  }
}
