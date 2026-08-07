// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.CertReqMessages
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class CertReqMessages : Asn1Encodable
{
  private readonly Asn1Sequence content;

  private CertReqMessages(Asn1Sequence seq) => this.content = seq;

  public static CertReqMessages GetInstance(object obj)
  {
    switch (obj)
    {
      case CertReqMessages _:
        return (CertReqMessages) obj;
      case Asn1Sequence _:
        return new CertReqMessages((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public CertReqMessages(params CertReqMsg[] msgs)
  {
    this.content = (Asn1Sequence) new DerSequence((Asn1Encodable[]) msgs);
  }

  public virtual CertReqMsg[] ToCertReqMsgArray()
  {
    CertReqMsg[] certReqMsgArray = new CertReqMsg[this.content.Count];
    for (int index = 0; index != certReqMsgArray.Length; ++index)
      certReqMsgArray[index] = CertReqMsg.GetInstance((object) this.content[index]);
    return certReqMsgArray;
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.content;
}
