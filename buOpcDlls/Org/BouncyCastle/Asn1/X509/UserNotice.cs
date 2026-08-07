// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.UserNotice
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class UserNotice : Asn1Encodable
{
  private readonly NoticeReference noticeRef;
  private readonly DisplayText explicitText;

  public UserNotice(NoticeReference noticeRef, DisplayText explicitText)
  {
    this.noticeRef = noticeRef;
    this.explicitText = explicitText;
  }

  public UserNotice(NoticeReference noticeRef, string str)
    : this(noticeRef, new DisplayText(str))
  {
  }

  private UserNotice(Asn1Sequence seq)
  {
    if (seq.Count == 2)
    {
      this.noticeRef = NoticeReference.GetInstance((object) seq[0]);
      this.explicitText = DisplayText.GetInstance((object) seq[1]);
    }
    else if (seq.Count == 1)
    {
      if (seq[0].ToAsn1Object() is Asn1Sequence)
      {
        this.noticeRef = NoticeReference.GetInstance((object) seq[0]);
        this.explicitText = (DisplayText) null;
      }
      else
      {
        this.noticeRef = (NoticeReference) null;
        this.explicitText = DisplayText.GetInstance((object) seq[0]);
      }
    }
    else
    {
      if (seq.Count != 0)
        throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
      this.noticeRef = (NoticeReference) null;
      this.explicitText = (DisplayText) null;
    }
  }

  public static UserNotice GetInstance(object obj)
  {
    if (obj is UserNotice)
      return (UserNotice) obj;
    return obj == null ? (UserNotice) null : new UserNotice(Asn1Sequence.GetInstance(obj));
  }

  public virtual NoticeReference NoticeRef => this.noticeRef;

  public virtual DisplayText ExplicitText => this.explicitText;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptional((Asn1Encodable) this.noticeRef, (Asn1Encodable) this.explicitText);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
