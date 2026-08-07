// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.PopoPrivKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class PopoPrivKey : Asn1Encodable, IAsn1Choice
{
  public const int thisMessage = 0;
  public const int subsequentMessage = 1;
  public const int dhMAC = 2;
  public const int agreeMAC = 3;
  public const int encryptedKey = 4;
  private readonly int tagNo;
  private readonly Asn1Encodable obj;

  public static PopoPrivKey GetInstance(object obj)
  {
    if (obj == null)
      return (PopoPrivKey) null;
    return obj is PopoPrivKey popoPrivKey ? popoPrivKey : new PopoPrivKey(Asn1TaggedObject.GetInstance(obj, 128 /*0x80*/));
  }

  public static PopoPrivKey GetInstance(Asn1TaggedObject tagged, bool isExplicit)
  {
    return Asn1Utilities.GetInstanceFromChoice<PopoPrivKey>(tagged, isExplicit, new Func<object, PopoPrivKey>(PopoPrivKey.GetInstance));
  }

  private PopoPrivKey(Asn1TaggedObject obj)
  {
    this.tagNo = obj.TagNo;
    switch (this.tagNo)
    {
      case 0:
        this.obj = (Asn1Encodable) DerBitString.GetInstance(obj, false);
        break;
      case 1:
        this.obj = (Asn1Encodable) SubsequentMessage.ValueOf(DerInteger.GetInstance(obj, false).IntValueExact);
        break;
      case 2:
        this.obj = (Asn1Encodable) DerBitString.GetInstance(obj, false);
        break;
      case 3:
        this.obj = (Asn1Encodable) PKMacValue.GetInstance(obj, false);
        break;
      case 4:
        this.obj = (Asn1Encodable) EnvelopedData.GetInstance(obj, false);
        break;
      default:
        throw new ArgumentException("unknown tag in PopoPrivKey", nameof (obj));
    }
  }

  public PopoPrivKey(PKMacValue pkMacValue)
  {
    this.tagNo = 3;
    this.obj = (Asn1Encodable) pkMacValue;
  }

  public PopoPrivKey(SubsequentMessage msg)
  {
    this.tagNo = 1;
    this.obj = (Asn1Encodable) msg;
  }

  public virtual int Type => this.tagNo;

  public virtual Asn1Encodable Value => this.obj;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerTaggedObject(false, this.tagNo, this.obj);
  }
}
